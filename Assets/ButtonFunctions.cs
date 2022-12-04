using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;
    [SerializeField] int difficulty;
    
    // Start is called before the first frame update
    void Start()
    {
        difficulty = PersistentData.Instance.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + difficulty);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("instructions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void Restart()
    {
        PersistentData.Instance.SetScore(0f);
        PersistentData.Instance.SetLives(3);
        PersistentData.Instance.SetName("");
        PersistentData.Instance.SetRounds(3);

        SceneManager.LoadScene("menu");
    }
}
