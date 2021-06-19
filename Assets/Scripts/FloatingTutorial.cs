using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTutorial : MonoBehaviour
{
    public bool close_tut;
    // Start is called before the first frame update
    void Start()
    {
        close_tut = false;
        transform.localPosition += new Vector3(0, 1.5f, 0);
    }

    private void Update()
    {
        if(close_tut)
        {
            Destroy(gameObject);
        }
    }

}
