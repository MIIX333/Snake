using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerFoodCounter : MonoBehaviour
{

    [SerializeField] private TMP_Text _counter;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.LengthUpdate += OnLenghtUpdated;
    }

    private void OnDisable()
    {
        _player.LengthUpdate -= OnLenghtUpdated;
    }

    private void OnLenghtUpdated(int lenght)
    {
        _counter.text = lenght.ToString();
    }

}
