using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BalloonBehavior : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    [SerializeField] float TimeSpan;

    int PosIndex;
    Transform NextPos;

    public AudioSource audioPlayer;

    [SerializeField] float startScale;
    [SerializeField] float maxScale;
    [SerializeField] float growth;
    [SerializeField] static float scoreToGet = 10;
    float startingScore = scoreToGet;

    Scorekeeper scoreKeeper;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<Scorekeeper>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject ground = GameObject.FindGameObjectWithTag("Ground");     
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(ground.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        
        transform.localScale = new Vector3(startScale,startScale,1);
        NextPos = Positions[0];
        InvokeRepeating("Grow", TimeSpan, TimeSpan);
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
            scoreKeeper.AddPoints(scoreToGet);

            audioPlayer.Play();
            Destroy(gameObject);
        }
    }

    private void Grow()
    {
        if(startScale < maxScale)
        {
            startScale += growth;
            transform.localScale = new Vector3(startScale,startScale,1);
            scoreToGet -= startingScore/(maxScale/growth);
        }
        else
        {
            scoreKeeper.RemoveLife();

            audioPlayer.Play();
            Destroy(gameObject);
        }
    }
}

