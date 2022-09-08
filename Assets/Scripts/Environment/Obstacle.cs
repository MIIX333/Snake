using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _priceInBlock;
    [SerializeField] private int _currentLenght;
    [SerializeField] private Vector2Int _priceRange;
    [SerializeField] private Material _material;
    [SerializeField] private GameObject _gameObject;
    public event UnityAction<int> Process;

    public int LeftCount => _priceInBlock - _currentLenght;

    private void Start()
    {
        _priceInBlock = Random.Range(_priceRange.x, _priceRange.y);
        Process?.Invoke(LeftCount);
        _gameObject = this.gameObject;
        _material = _gameObject.GetComponent<MeshRenderer>().material;
        float color = _priceInBlock / 10f;
        _material.SetFloat("_gradient", color);
    }

    public void TryBreak()
    {
        _currentLenght++;
        Process?.Invoke(LeftCount);
        if (_currentLenght == _priceInBlock)
        {
            Destroy(gameObject);
        }
    }
}