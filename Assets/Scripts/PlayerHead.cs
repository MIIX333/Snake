using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 newPosition)
    {
        _rigidbody.MovePosition(newPosition);
    }


    public float _leftSide = -3.8f;
    public float _rightSide = 3.8f;
    public float _sidewaysSpeed;

    private void FixedUpdate()
    {
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
