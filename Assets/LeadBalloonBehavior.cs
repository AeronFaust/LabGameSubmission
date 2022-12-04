using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class LeadBalloonBehavior : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

    int PosIndex;
    Transform NextPos;

    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");     
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ground.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        NextPos = Positions[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveBallon();
    }

    private void MoveBallon()
    {
        if (transform.position == NextPos.position)
        {
            PosIndex++;

            if(PosIndex >= Positions.Length)
            {
                PosIndex = 0;
            }

            NextPos = Positions[PosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Dart")
        {
            audioPlayer.Play();
        }
    }

}

