using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Menu = 0,
    Game = 1,
    GameEnd = 2,
}
public class GameManager : MonoBehaviour
{
    public static void LoadScene(SceneType type)
    {
        SceneManager.LoadScene(type.ToString());
    }
}
