using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //public PlayerHead _playerHead;
    //public Player Player;

    private void Update()
    {
    }
    //public Vector3 GetDirection(Vector3 playerHeadPosition)
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    //Vector3 direction = playerHeadPosition - mousePosition;
    //    //Vector3 direction = new Vector3(0,0,mousePosition.x);
    //    Vector3 dir = Vector3.RotateTowards(_playerHead.transform.forward, mousePosition, Player._forwardSpeed, 0.0f);
    //    transform.rotation = Quaternion.LookRotation(dir);
    //    //Vector3 direction = new Vector3(mousePosition.x - playerHeadPosition.x, mousePosition.y - playerHeadPosition.y, 0);
    //    return dir;
    //}
    //public Vector3 GetDirection(Vector3 playerHeadPosition)
    //{
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //    //Vector3 direction = playerHeadPosition - mousePosition;
    //    //Vector3 direction = new Vector3(0,0,mousePosition.x);
    //    Vector3 direction = new Vector3(mousePosition.x - playerHeadPosition.x, mousePosition.y - playerHeadPosition.y,0);
    //    return direction;
    //}

    //public Vector3 touchLastPos;
    //public float sidewaysSpeed;
    //public float Sensitivity = 10;
    //public Rigidbody componentRigidbody;
    //public float ForwardSpeed = 5;

    //private void Start()
    //{
    //    componentRigidbody = GetComponent<Rigidbody>();
    //}
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchLastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        sidewaysSpeed = 0;
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector3 delta = (Vector3)Camera.main.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
    //        sidewaysSpeed += delta.x * Sensitivity;
    //        touchLastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //    }

    //}
    //private void FixedUpdate()
    //{
    //    if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
    //    componentRigidbody.velocity = new Vector2(sidewaysSpeed * 5, ForwardSpeed);

    //    sidewaysSpeed = 0;
    //}


    ////[SerializeField] private float _speed;
    //public float _leftSide = -3.8f;
    //public float _rightSide = 3.8f;
    ////[SerializeField] private Vector3 _previousMousePosition;
    //public float _sidewaysSpeed;
    ////public Generator _generator;



    //void Update()
    //{
    //    transform.Translate(_speed * Time.deltaTime * Vector3.forward, Space.World);
    //    if (Input.GetKey(KeyCode.A) && transform.position.x > _leftSide)
    //    {
    //        transform.Translate(_sidewaysSpeed * Time.deltaTime * Vector3.left);
    //    }
    //    if (Input.GetKey(KeyCode.D) && transform.position.x < _rightSide)
    //    {
    //        transform.Translate(_sidewaysSpeed * -1 * Time.deltaTime * Vector3.left);
    //    }
    //}

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
