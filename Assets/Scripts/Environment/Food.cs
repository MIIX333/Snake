using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    private int _foodCount;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private Vector2Int _foodRange;

    private void Start()
    {
        _foodCount = Random.Range(_foodRange.x, _foodRange.y);
        _counter.text = _foodCount.ToString();
    }

    public int Swallow()
    {
        Destroy(gameObject);
        return _foodCount;
    }
}
