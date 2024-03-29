// PreferencesApplier will make changes to this region based on preferences
#region ApplyPreferences
#define ENABLE_HIERARCHY_FOLDER_MENU_ITEMS
#endregion

using System;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace Sisus.HierarchyFolders
{
	[InitializeOnLoad]
	public static class HierarchyFolderMenuItems
	{
		private static readonly SortTransformsByHierarchyOrder SortByHierarchyOrder = new SortTransformsByHierarchyOrder();

		private static bool alreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame;

		/// <summary>
		/// This is initialized on load due to the usage of the InitializeOnLoad attribute.
		/// </summary>
		static HierarchyFolderMenuItems()
		{
			EditorApplication.delayCall += ApplyPreferencesWhenAssetDatabaseReady;
		}

		private static void ApplyPreferencesWhenAssetDatabaseReady()
		{
			if(!PreferencesApplier.ReadyToApplyPreferences())
			{
				EditorApplication.delayCall += ApplyPreferencesWhenAssetDatabaseReady;
				return;
			}

			var classType = typeof(HierarchyFolderMenuItems);
			var preferences = HierarchyFolderPreferences.Get();
			bool enabled = preferences.enableMenuItems;

			PreferencesApplier.ApplyPreferences(classType,
			new[] { "#define ENABLE_HIERARCHY_FOLDER_MENU_ITEMS" },
			new[] { enabled });

			preferences.onPreferencesChanged += (changedPreferences) =>
			{
				if(changedPreferences.enableMenuItems != enabled)
				{
					var script = PreferencesApplier.FindScriptFile(classType);
					if(script != null)
					{
						AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(script));
					}
					#if DEV_MODE
					else { Debug.LogWarning("Could not find script asset "+classType.Name+".cs"); }
					#endif
				}
			};
		}

		internal static void CreateHierarchyFolder()
		{
			if(Selection.transforms.Length > 1)
			{
				CreateHierarchyFolderParent();
			}
			else
			{
				CreateHierarchyFolderSibling();
			}
		}

		#if ENABLE_HIERARCHY_FOLDER_MENU_ITEMS
		[UsedImplicitly, MenuItem("GameObject/Hierarchy Folder %#g", false, -51)]
		#endif
		private static void CreateHierarchyFolderFromMainMenuOrContextMenu(MenuCommand command)
		{
			if(alreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame)
			{
				return;
			}

			// If more than one GameObjects are selected in the hierarchy, create a new folder and move all selected GameObjects under it.
			if(Selection.transforms.Length > 1)
			{
				var rightClickedGameObject = command.context as GameObject;
				if(rightClickedGameObject != null)
				{
					alreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame = true;
					EditorApplication.delayCall += ResetAlreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame;
				}

				CreateHierarchyFolderParent();
			}
			else
			{
				// If creating HierarchyFolder from context menu, add it as child of right-clicked GameObject.
				// This is how most existing context menu items in Unity function.
				var rightClickedGameObject = command.context as GameObject;
				if(rightClickedGameObject != null)
				{
					CreateHierarchyFolderChild(rightClickedGameObject.transform);
				}
				else
				{
					CreateHierarchyFolderSibling();
				}
			}
		}

		private static void ResetAlreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame()
		{
			alreadyCreatedHierarchyFolderFromContextMenuForMultipleTargetsThisFrame = false;
		}

		internal static void CreateHierarchyFolderChild([CanBeNull]Transform parent)
		{
			var folder = CreateHierarchyFolderInternal(parent is RectTransform);

			if(parent != null)
			{
				folder.transform.UndoableSetParent(parent, "Hierarchy Folder");
			}

			Undo.RegisterCreatedObjectUndo(folder, "Hierarchy Folder");

			Selection.activeGameObject = folder;

			var hierarchyWindow = HierarchyWindowUtility.GetHierarchyWindow();
			if(hierarchyWindow != null)
			{
				hierarchyWindow.Focus();
			}
		}

		internal static void CreateHierarchyFolderParent()
		{
			int count = Selection.transforms.Length;

			var members = new Transform[count];
			Array.Copy(Selection.transforms, 0, members, 0, count);
			Array.Sort(members, SortByHierarchyOrder);

			var firstMember = members[0];
			var hierarchyFolderParent = firstMember.parent;

			var folder = CreateHierarchyFolderInternal(firstMember is RectTransform);

			// if not all selected have the same parent, then create folders as last item in hierarchy
			for(int n = 1; n < count; n++)
			{
				if(members[n].parent != hierarchyFolderParent)
				{
					hierarchyFolderParent = null;
					break;
				}
			}
			
			if(hierarchyFolderParent != null)
			{
				folder.transform.UndoableSetParent(hierarchyFolderParent, "Hierarchy Folder Parent");
			}
			int hierarchyFolderSiblingIndex = firstMember.GetSiblingIndex();
			folder.transform.SetSiblingIndex(hierarchyFolderSiblingIndex);

			Undo.RegisterCreatedObjectUndo(folder, "Hierarchy Folder Parent");

			#if UNITY_EDITOR
			if(EditorApplication.isPlayingOrWillChangePlaymode && HierarchyFolderPreferences.Get().playModeBehaviour == StrippingType.FlattenHierarchy)
			{
				int moveToIndex = HierarchyFolderUtility.GetLastChildIndexInFlatMode(folder);
				for(int n = count - 1; n >= 0; n--)
				{
					Undo.SetTransformParent(members[n], hierarchyFolderParent, "Hierarchy Folder Parent");
					members[n].SetSiblingIndex(moveToIndex);
				}
				return;
			}
			#endif

			for(int n = 0; n < count; n++)
			{
				Undo.SetTransformParent(members[n], folder.transform, "Hierarchy Folder Parent");
				members[n].SetAsLastSibling();
			}
			
			Selection.activeGameObject = folder;
		}

		internal static void CreateHierarchyFolderSibling()
		{
			var selected = Selection.activeTransform;

			var folder = CreateHierarchyFolderInternal(selected is RectTransform);

			if(selected != null)
			{
				int moveToIndex = selected.GetSiblingIndex();
				folder.transform.UndoableSetParent(selected.parent, "Hierarchy Folder");
				folder.transform.SetSiblingIndex(moveToIndex);
			}

			Undo.RegisterCreatedObjectUndo(folder, "Hierarchy Folder");

			Selection.activeGameObject = folder;

			var hierarchyWindow = HierarchyWindowUtility.GetHierarchyWindow();
			if(hierarchyWindow != null)
			{
				hierarchyWindow.Focus();
			}
		}

		#if ENABLE_HIERARCHY_FOLDER_MENU_ITEMS
		[UsedImplicitly, MenuItem("Tools/Hierarchy/Convert Selected to Hierarchy Folders %&#g", false, -31)]
		#endif
		private static void ConvertToHierarchyFolder()
		{
			var selectedTransforms = Selection.transforms;
			int selectedCount = selectedTransforms.Length;
			var transforms = new Transform[selectedCount];
			Array.Copy(selectedTransforms, 0, transforms, 0, selectedCount);
			Array.Sort(transforms, SortByHierarchyOrder);

			for(int n = selectedCount - 1; n >= 0; n--)
			{
				var transform = transforms[n];
				var gameObject = transform.gameObject;

				// Skip inactive GameObjects, since stripping them could have the side effect of child GameObjects becoming active in the hierarchy.
				if(!gameObject.activeSelf)
				{
					Debug.LogWarning("Won't convert " + gameObject.name + " because it is inactive.", gameObject);
					continue;
				}

				var components = gameObject.GetComponents<Component>();

				// Handle GameObjects that have extraneous components besides the Transform or RectTransform component.
				if(components.Length > 1)
				{
					if(gameObject.IsHierarchyFolder())
					{
						continue;
					}

					#if UNITY_2018_3_OR_NEWER
					if(PrefabUtility.GetPrefabInstanceStatus(gameObject) == PrefabInstanceStatus.Connected)
					#else
					if(PrefabUtility.GetPrefabType(gameObject) == PrefabType.PrefabInstance)
					#endif
					{
						Debug.LogWarning("Won't convert " + gameObject.name + " because it is a prefab instance and has extraneous components.", gameObject);
						continue;
					}

					// No benefit in flattening a target with no children.
					if(transform.childCount == 0)
					{
						Debug.LogWarning("Won't convert " + gameObject.name + " because it has extraneous components.", gameObject);
						continue;
					}

					// Never should unparent children of the Canvas.
					if(gameObject.GetComponent<Canvas>() != null)
					{
						Debug.LogWarning("Won't convert " + gameObject.name + " because it has the Canvas component.", gameObject);
						continue;
					}

					// Can't convert the target, but ask user if should flatten it instead.
					if(!EditorUtility.DisplayDialog("Flatten Unconvertable Target?", "Selected GameObject \"" + gameObject.name + "\" contains extraneous components ("+ string.Join(", ", components.Where((c) => c != transform).Select((c) => c == null ? "<Missing Script>" : c.GetType().Name).ToArray()) + ") and as such can't directly be converted into a hierarchy folder.\n\nWould you like to create a new hierarchy folder as a parent of the target and move all " + transform.childCount + " children of the target under the new hierarchy folder?\n\nThis would result in a flatter hierarchy potentially improving performance.", "Flatten Target", "Skip"))
					{
						continue;
					}

					Undo.RegisterFullObjectHierarchyUndo(gameObject, "Convert To Hierarchy Folder");

					var folder = CreateHierarchyFolderInternal(transform is RectTransform);
					folder.name = gameObject.name;
					Undo.RegisterCreatedObjectUndo(folder, "Convert To Hierarchy Folder");

					var folderTransform = folder.transform;
					folderTransform.UndoableSetParent(transform.parent, "Convert To Hierarchy Folder");
					folderTransform.SetSiblingIndex(transform.GetSiblingIndex());

					transform.UndoableSetParent(folderTransform, "Convert To Hierarchy Folder");

					int childCount = transform.childCount;
					if(childCount > 0)
					{
						for(int c = 0; c < childCount; c++)
						{
							var child = transform.GetChild(0);
							child.UndoableSetParent(folderTransform, "Convert To Hierarchy Folder");
						}
					}
					continue;
				}

				#if UNITY_2018_3_OR_NEWER
				if(PrefabUtility.GetPrefabInstanceStatus(gameObject) == PrefabInstanceStatus.Connected)
				#else
				if(PrefabUtility.GetPrefabType(gameObject) == PrefabType.PrefabInstance)
				#endif
				{
					if(EditorUtility.DisplayDialog("Convert Prefab Instance?", "Are you sure you want to convert the selected prefab instance \"" + gameObject.name + "\" into a hierarchy folder?\n\nIf you select \"Yes\" the prefab instance root will be unpacked as part of the conversion.", "Unpack and Convert", "Skip"))
					{
						Undo.RegisterFullObjectHierarchyUndo(gameObject, "Convert To Hierarchy Folder");

						#if UNITY_2018_3_OR_NEWER
						PrefabUtility.UnpackPrefabInstance(gameObject, PrefabUnpackMode.OutermostRoot, InteractionMode.UserAction);
						#else
						PrefabUtility.DisconnectPrefabInstance(gameObject);
						#endif
					}
					else
					{
						continue;
					}
				}
				else
				{
					Undo.RegisterFullObjectHierarchyUndo(gameObject, "Convert To Hierarchy Folder");
				}
				
				Undo.AddComponent<HierarchyFolder>(gameObject);
			}
		}

		#if ENABLE_HIERARCHY_FOLDER_MENU_ITEMS
		[UsedImplicitly, MenuItem("Tools/Hierarchy/Convert Scene Root to Hierarchy Folders", false, -30)]
		#endif
		private static void ConvertAllEmptyRootGameObjectsToHierarchyFolder()
		{
			for(int s = UnityEngine.SceneManagement.SceneManager.sceneCount - 1; s >= 0; s--)
			{
				var scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(s);
				var root = scene.GetRootGameObjects();

				for(int n = root.Length - 1; n >= 0; n--)
				{
					var gameObject = root[n];
				
					// Skip inactive GameObjects, since stripping them could have the side effect of child GameObjects becoming active in the hierarchy.
					if(!gameObject.activeSelf)
					{
						continue;
					}

					// Skip GameObjects that have any extraneous components besides the Transform or RectTransform component.
					var components = gameObject.GetComponents<Component>();
					if(components.Length > 1)
					{
						continue;
					}

					// Skip prefab instances - it doesn't feel intuitive for a prefab instance
					// to be a hierarchy folder, and unpacking the prefab instance would be too destructive.
					#if UNITY_2018_3_OR_NEWER
					if(PrefabUtility.GetPrefabInstanceStatus(gameObject) == PrefabInstanceStatus.Connected)
					#else
					if(PrefabUtility.GetPrefabType(gameObject) == PrefabType.PrefabInstance)
					#endif
					{
						continue;
					}

					Undo.RegisterFullObjectHierarchyUndo(gameObject, "Convert To Hierarchy Folder");
					Undo.AddComponent<HierarchyFolder>(gameObject);
				}
			}
		}

		private static GameObject CreateHierarchyFolderInternal(bool useRectTransform)
		{
			string name = HierarchyFolderPreferences.Get().defaultName;
			var folder = useRectTransform ? new GameObject(name, typeof(RectTransform), typeof(HierarchyFolder)) : new GameObject(name, typeof(HierarchyFolder));
			return folder;
		}

		[UsedImplicitly, MenuItem("Tools/Hierarchy/Convert Selected to Hierarchy Folders %&#g", true)]
		internal static bool ShouldDisplayConvertToHierarchyFolder()
		{
			for(int n = Selection.transforms.Length - 1; n >= 0; n--)
			{
				if(!Selection.transforms[n].gameObject.IsHierarchyFolder())
				{
					return true;
				}
			}
			return false;
		}

		#if DEV_MODE
		[UsedImplicitly, MenuItem("Tools/Reveal Hidden Components")]
		private static void RevealHiddenComponents()
		{
			foreach(var gameObject in Selection.gameObjects)
			{
				foreach(var component in gameObject.GetComponents<Component>())
				{
					component.hideFlags = HideFlags.None;
				}
			}
		}
		#endif
	}
}