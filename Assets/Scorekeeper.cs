using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] Text welcome;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] Text liveText;

    [SerializeField] float score;
    [SerializeField] int level;
    [SerializeField] int lives;
    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        score = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        lives = PersistentData.Instance.GetLives();

        DisplayName();
        DisplayScores();
        DisplayLevel();
        DisplayLives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(float points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScores();

        AdvanceLevel();
    }

    public void RemoveLife()
    {
        lives--;
        PersistentData.Instance.SetLives(lives);
        DisplayLives();

        if (lives > 0) RestartLevel();
        else SceneManager.LoadScene("GameOver");
    }

    public void DisplayName()
    {
        welcome.text = "Hello, " + playerName;
    }

    public void DisplayScores()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        levelText.text = "Level: " + (level - 2);
    }

    public void DisplayLives()
    {
        liveText.text  = "Lives: " + lives;;
    }

    public void AdvanceLevel()
    {
        int rounds = PersistentData.Instance.GetRounds();
        rounds--;
        PersistentData.Instance.SetRounds(rounds);
        if (rounds > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene("HighScores");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
