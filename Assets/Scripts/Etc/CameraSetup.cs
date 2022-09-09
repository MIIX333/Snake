using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private PlayerHead _playerHead;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;

    private Vector3 GetTargetPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, _playerHead.transform.position.z + _offset);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), _speed * Time.fixedDeltaTime);
    }
}