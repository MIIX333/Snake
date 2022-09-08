using UnityEngine;

public class ForceRestartButton : MonoBehaviour
{
    [SerializeField] private Game _game;

    public void ForceRestart()
    {
        _game.ReloadLevel();
    }
}