using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCreate : MonoBehaviour
{
    public WindBehavior WindPrefab;
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WindBlows", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WindBlows()
    {
        Instantiate(WindPrefab, SpawnPoint.position, transform.rotation);
    }
}
