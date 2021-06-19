using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MonsterNumOne : MonsterController
{
    //[SerializeField]private Animator anim;
    /*public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;*/
    // Start is called before the first frame update
    
    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        currentState = MonsterState.idle;
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        forward = Vector3.left;

        monster_dead = false;
        can_attack = true;
        turn_left = false;
        get_hit = false;

        health = maxHealth.initialValue;
        healthBar.SetHealth(health, maxHealth.initialValue);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health, maxHealth.initialValue);
        if (monster_dead)
        {
            return;
        }
        
        if (forward.x < 0 && !turn_left)
        {
            Flip();
        }
        else if(forward.x > 0 && turn_left)
        {
            Flip();
        }
        
        /*else if(forward.x > 0 && last_position.x < 0)
        {
            Flip();
        }*/
        Move();
        Attack();
        

        forward = transform.position - last_position;
        forward = forward.normalized;
        last_position = transform.position;
    }


    /*private void Check_distance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }*/
}
