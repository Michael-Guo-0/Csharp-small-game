using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LDSceneController : MonoBehaviour
{
    public int waves;
    public int current_enemies;
    public int waves_enemies;
    public Text win_text;
    public Text count_waves;
    private bool can_create;
    public bool scene_clear;

    public GameObject RoadLock;
    public GameObject bat;
    public GameObject frog;
    public GameObject ghost;
    public TownController town_controller;

    //public Vector2 midPoint;

    // Start is called before the first frame update
    void Start()
    {
        RoadLock.SetActive(true);
        //waves = 5;
        //waves_enemies = 10;
        //clear = false;
        can_create = true;
        //count_waves = GetComponent<TextMesh>();
        count_waves.text = "";
        win_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(scene_clear)
        {
            RoadLock.SetActive(false);
            return;
        }
        count_waves.text = "Waves: " + waves;
        if(waves == 0)
        {
            OpenRoad();
            win_text.text = "Scene Clear!";
            scene_clear = true;
            //town_controller.GetComponent<TownController>().UpdateSceneClear(3);
            //SendMessage("UpdateSceneClear", "LittleDemon");
            return;
        }
        CreateEnemies();
        if (CheckEnemiesNumber() == 0)
        {
            waves--;
            can_create = true;
        }
        
    }

    public void OpenRoad()
    {
        RoadLock.SetActive(false);
        //SceneTrans.SetActive(true);
    }

    public void CreateEnemies()
    {
        int max_x = 15, max_y = 7, min_x = -15, min_y = -7;
        if(can_create)
        {
            for(int i = 0; i < waves_enemies; i++)
            {
                switch(Random.Range(0,3))
                {
                    case 0:
                        Instantiate(bat, new Vector3((float)Random.Range(min_x, max_x), (float)Random.Range(min_y, max_y), 0f), Quaternion.identity);
                    break;
                    case 1:
                        Instantiate(frog, new Vector3((float)Random.Range(min_x, max_x), (float)Random.Range(min_y, max_y), 0f), Quaternion.identity);
                    break;
                    case 2:
                        Instantiate(ghost, new Vector3((float)Random.Range(min_x, max_x), (float)Random.Range(min_y, max_y), 0f), Quaternion.identity);
                    break;
                }
            }
            can_create = false;
        }


    }



    public int CheckEnemiesNumber()
    {
        GameObject[] obj_number = GameObject.FindGameObjectsWithTag("Enemy");
        return obj_number.Length;
    }

}
