using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyObject : MonoBehaviour
{
    // parameters of the axes
    [SerializeField] private float destory_time = 3;
    [SerializeField] private float flying_speed = 10;
    [SerializeField] private int damage = 20;
    [SerializeField] private float rotate_speed;
    // direction of the axe
    private Vector3 forward;
    //private Vector3 rotate;
    
    
    // Start is called before the first frame update
    void Start()
    {

        //forward = transform.forward;
        //forward = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        //forward = transform.forward.normalized;
        //forward = forward.normalized;

        // Remove these flying obj in three seconds.
        Destroy(gameObject, destory_time);
    }
    
    private void FixedUpdate()
    {
        // Which direction the flying props move, the speed, and the relative sapce world.
        transform.Translate(Time.fixedDeltaTime * forward * flying_speed, Space.World);
        // Flying obj rotate automatically.
        transform.Rotate(Vector3.forward * rotate_speed * Time.fixedDeltaTime);
        //transform.Rotate(new Vector3(0, 0, 45) * rotate_speed * Time.fixedDeltaTime);
        //Debug.Log("position: " + transform.position);
    }
    // get the direction from player controller.
    public void Init(Vector3 direction)
    {
        forward = direction;
    }
}
