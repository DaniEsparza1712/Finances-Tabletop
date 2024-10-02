using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPosManager : MonoBehaviour
{
    public enum PosState
    {
        Moving,
        Static
    }
    [Header("State")]
    public PosState _posState;
    private PosState GetPosState => _posState;
    [Header("Positions")]
    private Transform _playerTransform;
    public List<Transform> _wayPoints = new List<Transform>();
    [Header("Events")]
    public UnityEvent onChangeToStatic;
    public UnityEvent onChangeToMoving;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _posState = PosState.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (_posState == PosState.Moving && _wayPoints.Count > 0)
        {
            if (Vector3.Distance(_playerTransform.position, _wayPoints[0].position) < 0 + 0.2f)
            {
                _wayPoints.Remove(_wayPoints[0]);
            }
        }
        if (_wayPoints.Count == 0 && _posState != PosState.Static)
        {
            ChangePosState(PosState.Static);
        }
    }

    private void FixedUpdate()
    {
        if (_posState == PosState.Moving && _wayPoints.Count > 0)
        {
            var dir = (_wayPoints[0].position - _playerTransform.position).normalized;
            _playerTransform.position += dir * speed;
        }
    }

    public void ChangePosState(PosState state)
    {
        _posState = state;
        if (state == PosState.Moving)
            onChangeToMoving.Invoke();
        else
            onChangeToStatic.Invoke();
    }

    public void AddWayPoint(Transform wayPoint)
    {
        _wayPoints.Add(wayPoint);
    }
}
