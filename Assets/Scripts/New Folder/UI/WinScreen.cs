using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private GameObject _panel;

    public void NextLevel()
    {
        _nextLevelButton.gameObject.SetActive(true);
        _status.text = "You Win";
        _status.gameObject.SetActive(true);
        Color32 WinColor = new(45, 179, 48, 100);
        _panel.GetComponent<Image>().color = WinColor;
        _panel.SetActive(true);
    }
}
