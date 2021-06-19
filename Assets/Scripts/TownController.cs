using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    public bool hugewhite_clear;
    public bool dodgeball_clear;
    public bool littledemon_clear;

    public GameObject hugewhite_roadlock;
    public GameObject dodgeball_roadlock;
    public GameObject littledemon_roadlock;

    public bool game_win;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        hugewhite_roadlock.SetActive(false);
        GameObject.DontDestroyOnLoad(hugewhite_roadlock);
        dodgeball_roadlock.SetActive(false);
        GameObject.DontDestroyOnLoad(dodgeball_roadlock);
        littledemon_roadlock.SetActive(false);
        GameObject.DontDestroyOnLoad(littledemon_roadlock);
    }

    // Update is called once per frame
    void Update()
    {
        if(hugewhite_clear && dodgeball_clear && littledemon_clear)
        {
            // you win
            game_win = true;
            // write text here

            // end game scene
        }
    }

    public void UpdateSceneClear(int scene_number)
    {
        Debug.Log("check!!!!!!!!!!!!!!!!!!!!!!");
        switch(scene_number)
        {
            case 1:
                hugewhite_clear = true;
                hugewhite_roadlock.SetActive(true);
                break;
            case 2:
                dodgeball_clear = true;
                dodgeball_roadlock.SetActive(true);
                break;
            case 3:
                littledemon_clear = true;
                littledemon_roadlock.SetActive(true);
                break;


        }
    }
}
