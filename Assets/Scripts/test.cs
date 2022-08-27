using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //Vector3 pos;
    //public float offset;
    //public Vector2 turn;
    //public float sense;



        public Rigidbody rb;
        public float strength = 100;
        public float rotX;
        public float rotY;
        bool rotate;
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                rotate = true;
                rotX = Input.GetAxis("Mouse X") * strength;
                rotY = Input.GetAxis("Mouse Y") * strength;
            }
            else
            {
                rotate = false;
            }
        }
        void FixedUpdate()
        {
            if (rotate)
            {
                rb.AddTorque(rotY, -rotX, 0);
            }
        }
    // Update is called once per frame
    //void Update()
    //{
    //    //pos = Input.mousePosition;
    //    //pos.z = offset;
    //    //transform.position = Camera.main.ScreenToWorldPoint(pos);
    //    //turn.y = +Input.GetAxis("Mouse Y") * sense;
    //    //transform.rotation = Quaternion.Euler(0, turn.y, 0);

    //    float rot = Input.GetAxis("Mouse X") * sense * Time.deltaTime;

    //    Quaternion newRotation = transform.localRotation * Quaternion.Euler(0, rot, 0);

    //    transform.localRotation = newRotation;


    //}
}
