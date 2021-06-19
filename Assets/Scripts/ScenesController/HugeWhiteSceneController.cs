using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HugeWhiteSceneController : MonoBehaviour
{
    public GameObject RoadLock;
    public GameObject Monster;
    public Text win_text;
    public TownController town_controller;

    public bool scene_clear = false;

    // Start is called before the first frame update
    void Start()
    {
        RoadLock.SetActive(true);
        win_text.text = "";
        //town_controller.GetComponent<TownController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_clear)
        {
            RoadLock.SetActive(false);
            return;
        }
        //Debug.Log((int)(Monster.GetComponent<MonsterController>().health));
        if ((int)(Monster.GetComponent<MonsterController>().health) <= 0)
        {
            scene_clear = true;
            win_text.text = "Scene clear!";
            SceneManager.LoadScene("Win");
            //town_controller.GetComponent<TownController>().UpdateSceneClear(1);
            //SendMessage("UpdateSceneClear", "HugeWhite");
        }
    }

}
