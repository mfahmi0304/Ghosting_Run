using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    [Header("Movement")]
    public float moveAccel;
    public float maxSpeed;

    [Header("Jump")]
    public float jumpAccel;

    [Header("Ground Raycast")]
    public float groundRaycastDistance;
    public LayerMask groundLayerMask;

    [Header("Scoring")]
    public ScoreController score;
    public float scoringRatio;

    public EnemyController enemy;

    private Rigidbody2D rig;
    private Animator anim;
    private CharacterSoundController sound;

    private bool isJumping;
    private bool isAttack;
    private bool isOnGround;

    private float lastPositionX;

    public string enemyName;

    public int lives = 5;
    public int scoreEnemy = 0;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<CharacterSoundController>();


        lastPositionX = transform.position.x;
    }
    private void Update()
    {
        isAttack = false;
        

        // read input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                isJumping = true;

                sound.PlayJump();
            }
        }

        if(Input.GetMouseButtonDown(0)){
            isAttack = true;
            anim.SetBool("isAttack", true);
        }

        // if(isAttack){
            
        // }
        

        // change animation
        anim.SetBool("isOnGround", isOnGround);
        anim.SetBool("isAttack", isAttack);

        // calculate score
        int distancePassed = Mathf.FloorToInt(transform.position.x - lastPositionX);
        int scoreIncrement = Mathf.FloorToInt(distancePassed / scoringRatio);

        if (scoreIncrement > 0)
        {
            score.IncreaseCurrentScore(scoreIncrement);
            lastPositionX += distancePassed;
        }

    }
    private void FixedUpdate()
    {
        // raycast ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastDistance, groundLayerMask);
        if (hit)
        {
            if (!isOnGround && rig.velocity.y <= 0)
            { isOnGround = true;}
        }
        else { isOnGround = false; }

        // calculate velocity vector
        Vector2 velocityVector = rig.velocity;
        if (isJumping)
        {
            velocityVector.y += jumpAccel;
            isJumping = false;
        }

        velocityVector.x = Mathf.Clamp(velocityVector.x + moveAccel * Time.deltaTime, 0.0f, maxSpeed);
        rig.velocity = velocityVector;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(isAttack);
        // isAttack = true;
        if(isAttack){
            if(col.gameObject.tag == "Enemy"){
                enemyName = col.gameObject.name;
                if(enemyName == "Yul"){
                    scoreEnemy = 10;
                }
                else if(enemyName == "Ayang"){
                    scoreEnemy = 20;
                }
                else if(enemyName == "Kunti"){
                    scoreEnemy = 25;
                }
                else if(enemyName == "Poci"){
                    scoreEnemy = 50;
                }
                else if(enemyName == "Uwo"){
                    scoreEnemy = 100;
                }
                Destroy(col.gameObject);
                score.IncreaseCurrentScore(scoreEnemy);
            }
        }
        else{
            if(col.gameObject.tag == "Enemy"){
                if(lives > 1){
                    lives -= 1;
                }
                else{
                    Debug.Log("Game Over");
                }
                Debug.Log(lives);
                Destroy(col.gameObject);
            }
        }
    }
   
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3.down * groundRaycastDistance), Color.white);
    }
}
