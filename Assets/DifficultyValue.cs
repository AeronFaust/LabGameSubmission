using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyValue : MonoBehaviour
{
    [SerializeField] Text difficulty;
    [SerializeField] int value;

    void Start() 
    {
        displayDifficulty();
    }

    void Update() 
    {
    }

    public void displayDifficulty()
    {
        value = PersistentData.Instance.GetDifficulty();
        difficulty.text = "" + value;
    }
}
