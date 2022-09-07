using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] Game _game;

    public void Restart()
    {
        _game.ReturnToFirstLevel();
    }
}
