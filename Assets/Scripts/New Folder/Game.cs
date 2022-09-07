using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _status;
    [SerializeField] private GameObject _panel;
    //public int oi;
    //[SerializeField] private LevelCounter _levelCounter;
    [SerializeField] private TMP_Text _levelCounterText;
    public static int _counter = 1;
    

    //public int op;
    //public string FirstLevel = "First Level";

    private void Start()
    {
        _restartButton.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(false);
        _status.gameObject.SetActive(false);
        _panel.SetActive(false);
        _levelCounterText.text = _counter + "level";

        //SceneManager.LoadScene(Random.Range(0, 101));
        //int op = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(op);

        //PlayerPrefs.SetInt("First Level", SceneManager.GetActiveScene().buildIndex);
        //Debug.Log(PlayerPrefs.GetInt("First Level"));
        

        //oi = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("First level index", oi);
        //Debug.Log(oi);
        ////int firstLevelIndex = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("First level index", SceneManager.GetActiveScene().buildIndex);
        //Debug.Log(PlayerPrefs.GetInt("First level index"));
        //PlayerPrefs.Save();
        //int FirstLevelIndex = SceneManager.GetActiveScene().buildsIndex;
        //PlayerPrefs.SetInt("First level index", FirstLevelIndex);
        //PlayerPrefs.Save();
    }

    //public int FirstLevelIndex
    //{
    //    get => PlayerPrefs.GetInt("First level index", 0);
    //    set
    //    {
    //        PlayerPrefs.SetInt("First level index", value);
    //        PlayerPrefs.Save();
    //    }
    //}

    //private void Awake()
    //{
    //    FirstLevelIndex = PlayerPrefs.GetInt("First level index");
    //    PlayerPrefs.SetInt("First level index",)
    //}



    public void NextLevel()
    {
        //int oi = SceneManager.GetActiveScene().buildIndex;
        //int randomLevel = Random.Range(0, 101);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("First level index"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _counter++;
    }
    public void ReturnToFirstLevel()
    {
        //SceneManager.LoadScene(LevelIndex);
        //Debug.Log(PlayerPrefs.GetInt("First level index"));
        //PlayerPrefs.GetInt("First level index");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _counter = 1;
    }
}
