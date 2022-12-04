using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public float Speed = 8f;

    private void Start()
    {
        GameObject fence = GameObject.FindGameObjectWithTag("Fence");     
        Physics2D.IgnoreCollision(fence.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	Destroy (gameObject);
    }
}
