using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMonsters : MonoBehaviour
{
    // show damage when monster get hit
    public GameObject floatingPoints;
    private Vector2 velocity;

    // monsters actions
    private bool turn_left;
    public Transform target;
    public Transform homePosition;
    //public Animator anim;

    // monsters status
    public FloatValue maxHealth;
    private float health;
    public float damage;
    public float moveSpeed;
    public string name;
    public HealthManager healthBar;
    

    // direction
    public Vector3 forward;
    public Vector3 last_position;

    void Start()
    {
        //anim = GetComponent<Animator>();
        GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        forward = Vector3.left;

        turn_left = false;

        health = maxHealth.initialValue;
        healthBar.SetHealth(health, maxHealth.initialValue);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health, maxHealth.initialValue);
        if (forward.x < 0 && !turn_left)
        {
            Flip();
        }
        else if (forward.x > 0 && turn_left)
        {
            Flip();
        }
        Chase();

        forward = transform.position - last_position;
        forward = forward.normalized;
        last_position = transform.position;
    }

    public void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        /*if(name == "bat")
        {
            anim.Play("Mon-bat");
        }
        else if(name == "frog")
        {
            anim.Play("Mon-frog");
        }
        else if(name == "ghost")
        {
            anim.Play("Mon-ghost");
        }*/
    }

    public void Get_Hit(float damage)
    {
        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "-" + ((int)damage).ToString();
        health = health - damage;
        if ((int)health <= 0)
        {
            health = 0;
            //Destroy(gameObject);
            gameObject.SetActive(false);
            Destroy(gameObject, 1F);
        }
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Flip()
    {
        turn_left = !turn_left;
        transform.Rotate(0, 180, 0);
    }


}
