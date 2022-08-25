using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    public float _leftSide = -3.8f;
    public float _rightSide = 3.8f;
    [SerializeField] private Vector3 _previousMousePosition;
    public float _sidewaysSpeed;


    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.World);
        if (Input.GetKey(KeyCode.A) && transform.position.x > _leftSide)
        {
            transform.Translate(_sidewaysSpeed * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < _rightSide)
        {
            transform.Translate(_sidewaysSpeed * -1 * Time.deltaTime * Vector3.left);
        }
    }
}
