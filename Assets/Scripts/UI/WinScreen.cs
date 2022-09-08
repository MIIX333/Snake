using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private Image _statusImage;
    [SerializeField] private GameObject _panel;

    public void NextLevel()
    {
        _nextLevelButton.gameObject.SetActive(true);
        _status.text = "You Win";
        _statusImage.gameObject.SetActive(true);
        _status.gameObject.SetActive(true);
        Color32 WinColor = new(45, 179, 48, 100);
        _panel.GetComponent<Image>().color = WinColor;
        _panel.SetActive(true);
    }
}