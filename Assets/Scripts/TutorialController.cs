using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialController : MonoBehaviour
{
    public GameObject floatingTutorial;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(floatingTutorial, transform.position, Quaternion.identity);
    }
}
