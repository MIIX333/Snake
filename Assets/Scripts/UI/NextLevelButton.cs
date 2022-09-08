using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] Game _game;

    public void NextLevel()
    {
        _game.NextLevel();
    }
}