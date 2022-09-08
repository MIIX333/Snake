using UnityEngine;
using TMPro;

public class ObstacleSetup : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    [SerializeField] Obstacle _obstacle;

    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
    }

    private void OnEnable()
    {
        _obstacle.Process += OnSwallowProcess;
    }

    private void OnDisable()
    {
        _obstacle.Process -= OnSwallowProcess;
    }

    private void OnSwallowProcess(int leftToSwallow)
    {
        _counter.text = leftToSwallow.ToString();
    }
}