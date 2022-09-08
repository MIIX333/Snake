using UnityEngine;
using UnityEngine.Events;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private float _leftSide;
    [SerializeField] private float _rightSide;
    [SerializeField] private float _sidewaysSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Player _player;
    public ParticleSystem _particleSystem;
    public MeshRenderer _meshRenderer;
    public Rigidbody _rigidbody;
    public AudioSource _death;
    public event UnityAction Bump;
    public event UnityAction<int> FoodSwallow;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 newPosition)
    {
        _rigidbody.MovePosition(newPosition);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && _rigidbody.transform.position.x > _leftSide)
        {
            _rigidbody.AddForce(-5, 10, 7, ForceMode.VelocityChange);
            if (_rigidbody.velocity.magnitude > _maxSpeed)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) && _rigidbody.transform.position.x < _rightSide)
        {
            _rigidbody.AddForce(5, 10, 7, ForceMode.VelocityChange);
            if (_rigidbody.velocity.magnitude > _maxSpeed)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
            }
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
        if (!collision.collider.TryGetComponent(out FinishLine _))
        {
            return;
        }
        _player.Win();
    }
}