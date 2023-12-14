using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelScreen;

    public void CompleteLevel ()
    {
        completeLevelScreen.SetActive(true);
    }

    // Start is called before the first frame update
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("Game Over!");
            Invoke("RestartGame", restartDelay);
        }
    }

    void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
