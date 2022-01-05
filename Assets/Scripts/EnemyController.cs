using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    public ScoreController score;

    // private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // isAttack = true;
        // if(isAttack){
            if(col.gameObject.tag == "Player"){
                // isDead = true;
                Debug.Log(col.otherCollider);
                Destroy(gameObject);

                // float manaIncrement = 0.2f;
                // score.IncreaseMana(manaIncrement);
            }
        // }
    }

}
