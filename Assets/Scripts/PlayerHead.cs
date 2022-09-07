using UnityEngine;
using UnityEngine.Events;

public class PlayerHead : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public MeshRenderer _meshRenderer;
    public Rigidbody _rigidbody;
    public Player _player;
    public event UnityAction Bump;
    public event UnityAction<int> FoodSwallow;
    Vector3 movement;
    public AudioSource _death;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 newPosition)
    {
        _rigidbody.MovePosition(newPosition);
    }


    public float _leftSide = -10.0f;
    public float _rightSide = 10.0f;
    public float _sidewaysSpeed;
    public float spd;
    public float _maxSpeed;

    private void FixedUpdate()
    {
        
        
        if (Input.GetKey(KeyCode.A) && _rigidbody.transform.position.x > _leftSide)
        {
            //movement = new Vector3(-_sidewaysSpeed * Time.fixedDeltaTime, 0, 1) ;
            //_rigidbody.AddForce(movement,ForceMode.VelocityChange);
            _rigidbody.AddForce(-5, 10, 7, ForceMode.VelocityChange);
            if (_rigidbody.velocity.magnitude > _maxSpeed)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            }
            Debug.Log(_rigidbody.velocity.magnitude);
            //movement = (Vector3.forward * _sidewaysSpeed * Time.deltaTime/* + _rigidbody.transform.forward*/) ;
            //_rigidbody.velocity = movement;
            //movement = _rigidbody.transform.position - new Vector3(-_sidewaysSpeed * Time.deltaTime, 0, 0);/*.normalized - _rigidbody.transform.forward*/
            //_rigidbody.AddForce(movement, ForceMode.VelocityChange);
            //movement = movement + transform.TransformDirection(Vector3.left);
            //movement = Vector3.Normalize(movement);
            //movement = movement * _sidewaysSpeed;
            //_rigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime);
            //_rigidbody.transform.position = (Vector3.left + _rigidbody.transform.forward) * Time.deltaTime;

            ////_rigidbody.transform.Rotate(_sidewaysSpeed * Time.deltaTime * (Vector3.left + _rigidbody.transform.forward));
            //_rigidbody.transform.position = _rigidbody.transform.position - new Vector3(_sidewaysSpeed * Time.deltaTime, 0, 0);
            //_rigidbody.AddForce(_sidewaysSpeed * Time.deltaTime * (Vector3.left + _rigidbody.transform.forward));
            //transform.Translate(_sidewaysSpeed * Time.deltaTime * (Vector3.left + _rigidbody.transform.forward));
        }
        if (Input.GetKey(KeyCode.D) && _rigidbody.transform.position.x < _rightSide)
        {
            _rigidbody.AddForce(5, 10, 7, ForceMode.VelocityChange);
            if (_rigidbody.velocity.magnitude > _maxSpeed)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            }
            Debug.Log(_rigidbody.velocity.magnitude);
            //if (_rigidbody.velocity.magnitude > _maxSpeed)
            //{
            //    _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            //}
            //movement = new Vector3(spd, 0, 1) * _sidewaysSpeed * Time.fixedDeltaTime;
            ////_rigidbody.AddForce(movement, ForceMode.VelocityChange);
            //_rigidbody.transform.position = _rigidbody.transform.position + new Vector3(_sidewaysSpeed * Time.deltaTime, 0, 0);
            //_rigidbody.AddForce(_sidewaysSpeed * Time.deltaTime * (Vector3.right + _rigidbody.transform.forward));
            //transform.Translate(_sidewaysSpeed * Time.deltaTime * (Vector3.right + _rigidbody.transform.forward));
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Bump?.Invoke();
            obstacle.TryBreak();
            _player.Die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            FoodSwallow?.Invoke(food.Swallow());
        }
    }






    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out FinishLine finish))
        {
            return;
        }
        _player.Win();
    }

}
