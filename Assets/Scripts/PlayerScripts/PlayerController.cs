using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum PlayerState
{
    walk,
    attack,
    get_hit,
    storm_atk,
    dead
}
public class PlayerController : MonoBehaviour
{
    // player states
    private Rigidbody2D player_rb;
    private Vector3 movement;
    private float direction;
    private Animator anim;
    private SpriteRenderer sp;
    public float speed;
    public Vector3 forward { get; private set; }
    private Vector3 position_last;
    public VectorValue startingPosition;
    //public GameObject prefeb_fly_obj;

    public PlayerState currentState;
    public int level;
    // player status
    public FloatValue maxHealth;
    public Signal playerHealthSignal;
    public float currentHealth;
    public int strength;
    public int defense;
    public int exp;
    public bool storm_atk;
    public bool invincible;
    public HealthManager healthBar;
    public Image UIHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        // init animation
        anim = GetComponent<Animator>();
        // init player rigidbody
        player_rb = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>();
        // set speed to 5
        speed = 5.0f;


        // set player status
        level = 1;
        currentHealth = maxHealth.initialValue;
        strength = 10;
        exp = 0;
        transform.position = startingPosition.initialValue;

        storm_atk = false;
        invincible = false;

        // set last position
        position_last = transform.position;
        // default throw wepon left
        forward = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth, maxHealth.initialValue);
        SetUIHealth(currentHealth, maxHealth.initialValue);
       // if (currentState == PlayerState.dead)
        if(currentHealth <= 0)
        {
            // gai xie
            currentState = PlayerState.dead;
            startingPosition.initialValue = new Vector2(-1, -4);
            //transform.position = new Vector2(-1, -4);
            SceneManager.LoadScene("Dead");
            return;
        }
        /* debug get hit function
        if (Input.GetKey("q"))
        {
            Test_Get_Hit();
        }*/
        // make sure to stop after each move
        movement = Vector3.zero;
        // control moving
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("x") && currentState != PlayerState.attack && currentState != PlayerState.storm_atk
            && currentState != PlayerState.get_hit)
        {
            //Debug.Log("x pressed");
            StartCoroutine(Atk_cd());
        }
        if (Input.GetKey("z") && storm_atk == false)
        {

            StartCoroutine(Crit_atk_cd());

        }

        // update animation
        /*if (currentState == PlayerState.walk)
        {
            Update_animation();
        }*/
        Update_animation();

        if (movement.x != 0)
            direction = movement.x;
        //Debug.Log("check direction: " + direction);

        // check movement direction
        if (movement != Vector3.zero)
        {
            forward = transform.position - position_last;
            forward = forward.normalized;
            position_last = transform.position;
        }
    }

    private void Update_animation()
    {
        // if player stop, idling
        if (movement != Vector3.zero)
        {
            Player_move();
            anim.SetFloat("moveX", direction);
            //anim.SetB("moving",)
            anim.SetBool("walk", true);
        }
        // if player move lef or right play animation moving
        else
        {
            anim.SetBool("walk", false);
        }
    }
    private void Player_move()
    {
        //player_rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
        transform.position += movement * speed * Time.deltaTime;
    }


    public void Get_Hit(float damage)
    {
        damage = damage - defense;
        if(damage <= 0)
        {
            damage = 0;
        }
        if ((int)damage > 0 && invincible == false)
        {
            currentHealth = currentHealth - damage;
            playerHealthSignal.Raise();
            if ((int)currentHealth <= 0)
            {
                currentHealth = 0;
                StartCoroutine(Dead_Anim());
                Debug.Log("DEAD" + currentState);
                //Destroy(gameObject, 0.7f);
                // and game over
                return;
            }
            //currentState = PlayerState.get_hit;
            StartCoroutine(Invincible_cd());
            Debug.Log("Get Hit");
        }
        
    }

    public void Get_exp(int experience)
    {
        exp += experience;
    }

    public void Reborn()
    {
        currentHealth = maxHealth.initialValue;
        currentState = PlayerState.walk;
    }

    public int GetDamage()
    {
        int rand = Random.Range(0, 7);
        int damage = (int)(strength * 1.5f) + rand;
        return damage;
    }

    public void UpdateStrength(int num)
    {
        this.strength += num;
    }

    public bool GetInvicible()
    {
        return invincible;
    }

    private IEnumerator Atk_cd()
    {
        anim.SetBool("atk", true);
        currentState = PlayerState.attack;
        //Debug.Log("attacking!");
        yield return null;
        anim.SetBool("atk", false);
        yield return new WaitForSeconds(.5f);
        currentState = PlayerState.walk;
        //Debug.Log("finished!");
    }

    private IEnumerator Crit_atk_cd()
    {
        anim.SetBool("storm_atk", true);
        storm_atk = true;
        invincible = true;
        sp.color = Color.red;
        currentState = PlayerState.storm_atk;
        //currentState = PlayerState.attack;
        //Debug.Log("attacking!");
        yield return null;
        anim.SetBool("storm_atk", false);
        //yield return new WaitForSeconds(5);
        yield return new WaitForSecondsRealtime(5);
        currentState = PlayerState.walk;
        sp.color = Color.white;
        storm_atk = false;
        invincible = false;
    }

    private IEnumerator Invincible_cd()
    {
        anim.SetBool("get_hit", true);
        currentState = PlayerState.get_hit;
        
        for (int i = 0; i < 10; i++)
        {
            sp.enabled = false;
            yield return new WaitForSecondsRealtime(0.0833f);
            sp.enabled = true;
            yield return new WaitForSecondsRealtime(0.0833f);
            
        }
        anim.SetBool("get_hit", false);


        currentState = PlayerState.walk;
        invincible = true;

        yield return new WaitForSecondsRealtime(3);
        invincible = false;
        

    }

    private IEnumerator Dead_Anim()
    {
        currentState = PlayerState.dead;
        anim.SetBool("dead", true);
        yield return new WaitForSecondsRealtime(0.7f);
        anim.SetBool("dead", false);
        //anim.SetBool("dead", false);
    }


    private void SetUIHealth(float health, float maxHealth)
    {
        UIHealthBar.fillAmount = health / maxHealth;
    }
}
