using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SBallController : MonoBehaviour
{
    public GameObject player;
    public GameObject Ball;
    public GameObject Trap;
    public GameObject RoadLock;
    public TownController town_controller;

    public int timeLeft;
    public GameObject TextTime;
    private bool time_start;
    //private bool can_spawn;
    public bool game_over;
    public bool scene_clear;

    // Start is called before the first frame update
    void Start()
    {
        //can_spawn = false;
        time_start = false;
        //SpanwBalls()
        RoadLock.SetActive(false);
        TextTime.SetActive(false);
        TextTime.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (game_over)
        {
            TextTime.SetActive(false);
            RoadLock.SetActive(false);
            return;
        }
        if((int)(player.GetComponent<PlayerController>().currentHealth) <= 0)
        {
            game_over = true;
            // you lose
        }
        if (timeLeft <= 0)
        {
            game_over = true;
            scene_clear = true;
            //town_controller.GetComponent<TownController>().UpdateSceneClear(2);
            //SendMessage("UpdateSceneClear", "DodgeMagic");
        }
        if(Trap.GetComponent<TrapTrigger>().trap_on)
        {
            Trap.SetActive(false);
            RoadLock.SetActive(true);
            TextTime.SetActive(true);
            SpanwBalls();
            Trap.GetComponent<TrapTrigger>().trap_on = false;
        }
        if (timeLeft > 0 && time_start == false)
        {
            StartCoroutine(TimeCounter());
        }
    }


    IEnumerator TimeCounter()
    {
        time_start = true;
        yield return new WaitForSeconds(1);
        timeLeft--;
        //Debug.Log("Time left 1: " + timeLeft);
        TextTime.GetComponent<Text>().text = "Time: " + timeLeft.ToString();
        //Debug.Log("Time left 2: " + timeLeft);
        time_start = false;
    }

    private void SpanwBalls()
    {
        Destroy(Instantiate(Ball, new Vector3(-12, 7, 0f), Quaternion.identity), timeLeft);
        Destroy(Instantiate(Ball, new Vector3(-12, 0, 0f), Quaternion.identity), timeLeft);
        Destroy(Instantiate(Ball, new Vector3(-12, -7, 0f), Quaternion.identity), timeLeft);
        Destroy(Instantiate(Ball, new Vector3(12, 7, 0f), Quaternion.identity), timeLeft);
        Destroy(Instantiate(Ball, new Vector3(12, 0, 0f), Quaternion.identity), timeLeft);
        Destroy(Instantiate(Ball, new Vector3(12, -7, 0f), Quaternion.identity), timeLeft);
    }
}
