using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D coll)
    {
	if (coll.gameObject.tag == "Player")
        	// reload the scene
        	SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}
