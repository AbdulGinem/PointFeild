using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class FollowAI : MonoBehaviour
{
    public bool followingPlayer { get; private set; }

    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _minDistance = 2f;
    [SerializeField] private float _triggerRadius = 6f;
    [SerializeField] private Transform _player;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        //Init player transform
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
#if UNITY_EDITOR
            if (_player == null)
                Debug.LogWarning(gameObject.name + "Could not find a Gameobject with the tag \"Player\"");
#endif
        }

        //Init collider
        var collider = GetComponent<SphereCollider>();
        collider.radius = _triggerRadius;
        collider.isTrigger = true;

        //Init rigidbody
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }

    private void Update()
    {
        if (followingPlayer && Vector3.Distance(_transform.position, _player.position) > _minDistance)
        {
            Vector3 direction = _player.position - _transform.position;
            _transform.position += direction.normalized * _moveSpeed * Time.deltaTime;

            _transform.LookAt(_player);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.transform == _player)
            followingPlayer = true;
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.transform == _player)
            followingPlayer = false;
    }
}