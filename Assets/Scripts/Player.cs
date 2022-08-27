using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Segment> _segments;
    private PlayerBody _playerBody;
    [SerializeField] private PlayerHead _playerHead;
    public float _forwardSpeed;
    [SerializeField] private float _segmentsSpeed;
    public PlayerMovement _playerMovement;




    private void Awake()
    {
        _playerBody = GetComponent<PlayerBody>();
        _segments = _playerBody.SegmentAssembly();
    }
    private void FixedUpdate()
    {
        Move(_playerHead.transform.position + _playerHead.transform.forward * _forwardSpeed * Time.fixedDeltaTime /*+ _playerHead.transform.right * sidespeed * Time.fixedDeltaTime*/);
        //_playerHead.transform.up = _playerMovement.GetDirection(_playerHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _playerHead.transform.position;
        foreach (var segment in _segments)
        {
            Vector3 position = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPosition, _segmentsSpeed*Time.fixedDeltaTime);
            previousPosition = position;
        }
        _playerHead.Move(nextPosition);
    }
}
