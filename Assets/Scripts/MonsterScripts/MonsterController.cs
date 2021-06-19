using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    idle,
    move,
    attack,
    interrupt,
    dead
}

public class MonsterController : MonoBehaviour
{
    // show damage when monster get hit
    public GameObject floatingPoints;

    private Vector2 velocity;
    // monsters actions
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected bool turn_left;
    protected bool can_attack;
    protected bool get_hit;
    protected bool monster_dead;
    public MonsterState currentState;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // monsters status
    public FloatValue maxHealth;
    public float health;
    public float damage;
    public float moveSpeed;
    public string name;
    public HealthManager healthBar;


    // direction
    public Vector3 forward;
    public Vector3 last_position;
    public float destory_time;



    // Start is called before the first frame update
    void Start()
    {
        /*anim = GetComponent<Animator>();
        currentState = MonsterState.idle;
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;*/
    }

    // Update is called once per frame
    void Update()
    {
        /*
        debug attack()
        WaitForSecondsRealtime and hasExist time can be used together
        if(Input.GetKey("q"))
        {
            Debug.Log("attack1");
            Attack();
        }
        */
        /*Move();

        if (health <= 0)
        {
            health = 0;
            currentState = MonsterState.dead;
            Destroy(gameObject);
            return;
        }*/
    }


    public void Attack()
    {
        if(Vector3.Distance(target.position, transform.position) <= attackRadius 
            && can_attack 
            && currentState != MonsterState.dead
            && currentState != MonsterState.interrupt)
        {
            StartCoroutine(Atk_cd());
        }
        
    }

    public void Move()
    {
        //currentState = MonsterState.move;
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius 
            && currentState != MonsterState.dead
            && currentState != MonsterState.interrupt
            && currentState != MonsterState.attack)
        {
            currentState = MonsterState.move;
            //Flip();
            anim.SetBool("move", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if(currentState != MonsterState.dead && currentState != MonsterState.interrupt)
        {
            anim.SetBool("move", false);
            currentState = MonsterState.idle;
        }
    }

    public void Get_Hit(float damage)
    {
        GameObject points = Instantiate(floatingPoints, transform.position, Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<TextMesh>().text = "-" + ((int)damage).ToString();
        health = health - damage;
        if ((int)health > 0)
        {
            StartCoroutine(Interrupt_timer());
        }
        else if((int)health <= 0)
        {
            health = 0;
            monster_dead = true;
            StartCoroutine(Dead());
            Debug.Log("DEAD");
            gameObject.SetActive(false);
            Destroy(gameObject, destory_time);
            
            //Destroy(gameObject, 1F);
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

    private IEnumerator Atk_cd()
    {
        anim.SetBool("attack", true);
        //anim.SetBool("move", false);
        can_attack = false;
        currentState = MonsterState.attack;
        yield return null;
        anim.SetBool("attack", false);
        //Debug.Log("state: " + currentState);
        yield return new WaitForSecondsRealtime(2);
        can_attack = true;
        //Debug.Log("state: " + currentState);
        currentState = MonsterState.move;
    }

    private IEnumerator Interrupt_timer()
    {
        anim.SetBool("interrupt", true);
        //floatingPoints.GetComponent<>
        
        currentState = MonsterState.interrupt;
        yield return null;
        //Flip();
        anim.SetBool("interrupt", false);
        yield return new WaitForSecondsRealtime(0.5f);
        //Destroy(floatingPoints);
        currentState = MonsterState.move;

    }

    private IEnumerator Dead()
    {
        anim.SetBool("dead", true);
        currentState = MonsterState.dead;
        yield return null;
        anim.SetBool("dead", false);
        //yield return new WaitForSecondsRealtime(0.7f);
        //yield return new WaitForSecondsRealtime(0.5f);
        //Destroy(gameObject);
    }
}
