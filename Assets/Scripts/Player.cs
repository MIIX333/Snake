using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    private List<Segment> _segments;
    private PlayerBody _playerBody;
    [SerializeField] private PlayerHead _playerHead;
    public float _forwardSpeed;
    [SerializeField] private float _segmentsSpeed;
    public PlayerMovement _playerMovement;
    public event UnityAction<int> LengthUpdate;
    [SerializeField] private Segment _segment;
    [SerializeField] private int _segmentsNumber;
    public Obstacle _obstacle;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private WinScreen _winScreen;
    public Camera _mainCamera;
    public FinishLine _finishLine;

    private void Awake()
    {
        _playerBody = GetComponent<PlayerBody>();
        _segments = _playerBody.SegmentAssembly(_segmentsNumber);
        LengthUpdate?.Invoke(_segments.Count);
        _counter.text = Convert.ToString(_segments.Count);
    }

    private void OnEnable()
    {
        _playerHead.Bump += WhenPlayerBump;
        _playerHead.FoodSwallow += WhenFoodSwallow;
    }

    private void OnDisable()
    {
        _playerHead.Bump -= WhenPlayerBump;
        _playerHead.FoodSwallow -= WhenFoodSwallow;
    }



    private void FixedUpdate()
    {
        Move(_playerHead._rigidbody.transform.position + _playerHead._rigidbody.transform.forward * _forwardSpeed * Time.fixedDeltaTime /*+ _playerHead.transform.right * sidespeed * Time.fixedDeltaTime*/);
        //_playerHead.transform.up = _playerMovement.GetDirection(_playerHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _playerHead._rigidbody.transform.position;
        foreach (var segment in _segments)
        {
            Vector3 position = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPosition, _segmentsSpeed*Time.fixedDeltaTime);
            previousPosition = position;
        }
        _playerHead.Move(nextPosition);
    }

    private void WhenPlayerBump()
    {
        _segment = _segments[_segments.Count-1];
        _segments.Remove(_segment);
        Destroy(_segment.gameObject);
        LengthUpdate?.Invoke(_segments.Count);
    }

    private void WhenFoodSwallow(int foodCount)
    {
        _segments.AddRange(_playerBody.SegmentAssembly(foodCount));
        LengthUpdate?.Invoke(_segments.Count);
    }

    public void Die()
    {
        if (_segments.Count <= 0)
        {
            _playerHead._rigidbody.velocity = Vector3.zero;
            _playerHead._rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _playerHead._particleSystem.Play();
            _playerHead._death.Play();
            _playerHead._meshRenderer.enabled = false;
            _loseScreen.Restart();
            Debug.Log("Lol");
        }
    }
    public void Win()
    {
        //_playerHead._rigidbody.velocity = Vector3.zero;
        //_playerHead._rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        //foreach (var item in _segments)
        //{
        //    _segment.rg.velocity = Vector3.zero;
        //    _segment.rg.constraints = RigidbodyConstraints.FreezeAll;
        //}
        _mainCamera.GetComponent<Camera>().enabled = false;
        _finishLine._particleSystem.Play();
        
        _winScreen.NextLevel();
        Debug.Log("Get Gud");
    }

}
