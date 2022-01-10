using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    public ScoreController score;

    int scoreFromEnemy = 50;

    // private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if(col.gameObject.tag == "Player"){
    //         Destroy(gameObject);

    //         score.IncreaseCurrentScore(scoreFromEnemy);
    //     }
    // }

    // void UpdateScore(){
    //     int scoreIncrement = 50;
    //     score = GameObject.Find("Score Controller Object").GetComponent<ScoreController>();
    //     score.IncreaseCurrentScore(scoreIncrement);
    // }

}
