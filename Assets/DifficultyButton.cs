using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDifficultyOne()
    {
        PersistentData.Instance.SetDifficulty(1);
    }

    public void setDifficultyTwo()
    {
        PersistentData.Instance.SetDifficulty(2);
    }

    public void setDifficultyThree()
    {
        PersistentData.Instance.SetDifficulty(3);
    }
}
