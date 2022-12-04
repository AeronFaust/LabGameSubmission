using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "Player";
    const string SCORE_KEY = "Score";

    [SerializeField] string playerName;
    [SerializeField] float playerScore;
    [SerializeField] int playerLives;
    [SerializeField] int difficulty;

    [SerializeField] float finalScore;

    [SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;


    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerLives = PersistentData.Instance.GetLives();
        difficulty = PersistentData.Instance.GetDifficulty();
        playerScore = PersistentData.Instance.GetScore();

        finalScore = (playerScore + (5 * playerLives)) * ((difficulty+2)/3);

        SaveHighScores();
        ShowHighScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveHighScores()
    {
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                float currentScore = PlayerPrefs.GetFloat(currentScoreKey);
                if (finalScore > currentScore)
                {
                    float tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetFloat(currentScoreKey, finalScore);

                    playerName = tempName;
                    finalScore = tempScore;

                }
            }
            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetFloat(currentScoreKey, finalScore);
                return;
            }
        }
    }

    public void ShowHighScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetFloat(SCORE_KEY + (i + 1)).ToString();
        }
    }
}
