using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    public GameObject monster;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //monster = GameObject.FindWithTag("Enemy");
        float damage = 0;
        if(monster.GetComponentInParent<MonsterController>() is MonsterController)
        {
            damage = monster.GetComponent<MonsterController>().GetDamage();
        }
        else if(monster.GetComponent<LittleMonsters>() is LittleMonsters)
        {
            damage = monster.GetComponent<LittleMonsters>().GetDamage();
        }
        Debug.Log("1. what trigger: " + other);
        Debug.Log(other);
        if(other.gameObject.CompareTag("Player") && other.isTrigger)
        {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            if (player != null && !player.GetComponent<PlayerController>().GetInvicible())
            {
                //player.isKinematic = false;
                player.GetComponent<PlayerController>().Get_Hit(damage);
                //player.isKinematic = true;
                Debug.Log("monster damage player: " + damage);
                //player.isKinematic = true;
            }

            //player.isKinematic = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("other exist");
    }

}
