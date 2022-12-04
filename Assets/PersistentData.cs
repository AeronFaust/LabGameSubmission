using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] float playerScore;
    [SerializeField] int playerLives;
    [SerializeField] string playerName;
    [SerializeField] float playerBGM;
    [SerializeField] float playerSFX;
    [SerializeField] int difficulty;
    [SerializeField] int rounds;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0f;
        playerLives = 3;
        playerName = "";
        playerBGM = 1;
        playerSFX = 1;
        difficulty = 1;
        rounds = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void SetLives(int l)
    {
        playerLives = l;
    }

    public void SetScore(float s)
    {
        playerScore = s;
    }

    public void SetBGM(float value)
    {
        playerBGM = value;
    }
    
    public void SetSFX(float value)
    {
        playerSFX = value;
    }
    
    public void SetDifficulty(int value)
    {
        difficulty = value;
    }
    
    public void SetRounds(int value)
    {
        rounds = value;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetLives()
    {
        return playerLives;
    }

    public float GetScore()
    {
        return playerScore;
    }

    public float GetBGM()
    {
        return playerBGM;
    }
    
    public float GetSFX()
    {
        return playerSFX;
    }
    
    public int GetDifficulty()
    {
        return difficulty;
    }
    
    public int GetRounds()
    {
        return rounds;
    }
}
