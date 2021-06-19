using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Debug.Log("Player Go through");
            //Debug.Log("Load " + sceneToLoad);
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            //Debug.Log("load scene");
        }
    }

}
