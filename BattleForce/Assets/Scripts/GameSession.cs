using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;

    int currentLevel;
  //  int score = 300;

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions >1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        livesText.text = "Lives : " +playerLives.ToString();
        scoreText.text = "Score : " + score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if( playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = "Lives : " + playerLives.ToString();

    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();
    }

    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }

    public int GetScore()
    {
        return score;
    }

    public int getLevel()
    {
        return currentLevel;
    }
}
