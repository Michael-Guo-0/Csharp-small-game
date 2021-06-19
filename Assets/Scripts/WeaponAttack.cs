using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject fly_obj_prefeb;
    // Start is called before the first frame update
    private PlayerController player;
    // How many axes will fly out.
    [SerializeField] private int attack_times;
    private void OnEnable()
    {
        player = gameObject.GetComponent<PlayerController>();
    }

    // Functions for creating flying object
    private void CreateFlyObj(Vector3 direction)
    {
        var game_obj = Instantiate(fly_obj_prefeb, transform.position, Quaternion.identity);
        var fly = game_obj.GetComponent<FlyObject>();
        fly.Init(direction);        //Debug.Log("axis: " + Quaternion.Euler(transform.forward));
        //float destory_time = 3f;
        //Destroy(game_obj, destory_time);

    }

    private void CreateFlyObjectAttack()
    {
        // According to the number of flight props, to distribute the angle.
        float angle = 360 / attack_times;
        
        //Debug.Log("Check trigger");
        for (int i = 0; i < attack_times; i++)
        {
            // According to the z-axis rotation, clockwise may be counterclockwise
            Vector3 newVec = Quaternion.AngleAxis(angle * i, Vector3.forward) * Vector3.right;
            CreateFlyObj(newVec);
        }
    }
}
