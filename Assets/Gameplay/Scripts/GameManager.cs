using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private GameState gameState;
    private void Start()
    {
        gameState = GameState.GameMenu;
    }

    public void ChangeState(GameState newState)
    {
        if (gameState != newState)
        {
            gameState = newState;
            if (newState == GameState.GameMenu)
            {
                UIManager.Instance.OpenUI(NumberUI.MainMenu);
            }
            else if(newState == GameState.GamePlay)
            {
                UIManager.Instance.OpenUI(NumberUI.GamePlay);
            }
            else if(newState == GameState.Pause)
            {
                UIManager.Instance.OpenUI(NumberUI.Pause);

            }else if(newState == GameState.EndGame)
            {
                UIManager.Instance.OpenUI(NumberUI.Results);
            }
        }
    }

    public bool IsState(GameState checkState)
    {
        return gameState == checkState;
    }
}


