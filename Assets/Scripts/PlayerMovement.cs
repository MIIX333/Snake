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


        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 delta = Input.mousePosition - _previousMousePosition;
        //    if (this.gameObject.transform.position.x > _leftSide)
        //    {
        //        transform.Translate(Vector3.left * Time.deltaTime * _sidewaysSpeed);
        //    }

        //}
        //_previousMousePosition = Input.mousePosition;
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 delta = Input.mousePosition - _previousMousePosition;
        //    if (this.gameObject.transform.position.x < _rightSide)
        //    {
        //        transform.Translate(Vector3.right * Time.deltaTime * _sidewaysSpeed * -1);
        //    }

        //}
        //_previousMousePosition = Input.mousePosition;
}
