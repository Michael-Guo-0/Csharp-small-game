using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    //private int damage;
    public float thrust;
    public float knockTime;
    public GameObject play;
    private void OnTriggerEnter2D(Collider2D other)
    {
        play = GameObject.FindWithTag("Player");
        float damage = play.GetComponent<PlayerController>().GetDamage();

        if(other.gameObject.CompareTag("Enemy") && other.isTrigger)
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (other.GetComponentInParent<MonsterController>() is MonsterController)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<MonsterController>().Get_Hit(damage);

                    //enemy.isKinematic = false;
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(Knock_Co(enemy));
                }
            }
            else if(other.GetComponentInParent<LittleMonsters>() is LittleMonsters)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<LittleMonsters>().Get_Hit(damage);

                    //enemy.isKinematic = false;
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(Knock_Co(enemy));
                }
            }
            //Debug.Log("Enemy knock back");
            
        }
        
    }
    private IEnumerator Knock_Co(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            
            //enemy.isKinematic = true;
        }
    }
}
