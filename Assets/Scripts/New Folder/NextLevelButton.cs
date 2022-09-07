using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] Game _game;

    public void NextLevel()
    {
        _game.NextLevel();
    }

}
