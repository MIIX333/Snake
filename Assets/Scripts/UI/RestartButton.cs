using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Game _game;

    public void Restart()
    {
        _game.ReturnToFirstLevel();
    }
}