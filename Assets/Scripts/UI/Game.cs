using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private Image _statusImage;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _levelCounterText;

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "Level Index";

    private void Start()
    {
        _restartButton.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        _status.gameObject.SetActive(false);
        _statusImage.gameObject.SetActive(false);
        _panel.SetActive(false);
        _levelCounterText.text = LevelIndex + 1 + " level";
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        LevelIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToFirstLevel()
    {
        LevelIndex = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}