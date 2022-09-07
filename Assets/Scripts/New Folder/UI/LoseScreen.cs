using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private GameObject _panel;


    public void Restart()
    {
        _restartButton.gameObject.SetActive(true);
        _status.text = "You Lose";
        _status.gameObject.SetActive(true);
        Color32 LoseColor = new(255, 102, 71, 100);
        _panel.GetComponent<Image>().color = LoseColor;
        _panel.SetActive(true);
    }

}
