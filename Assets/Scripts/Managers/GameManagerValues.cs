﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerValues : Singleton<GameManagerValues>
{
    public ControllerBehaviour Player1;
    public ControllerBehaviour Player2;

    public float score;

    public float comboScoreMultiplier;
    public float comboNumberMinToGetMultiplier;

    public Text scoreText;
    public Text TimerText;

    public float comboValue;
    public float comboValueEachMobKilled;

    public float timerBeforeLoosingCombo;

    public float timer;
    public bool timerGoingOn;

    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = (score.ToString()+ " p");
        Menu.instance.comboValues.text = comboValue.ToString();

        if (timer > 0 && timerGoingOn == true)
        {
            TimerText.gameObject.SetActive(true);
        }
        else
        {
            TimerText.gameObject.SetActive(false);
        }

        TimerText.text = timer.ToString("F2") + " sec left";


        if (Player1 != null && Player2!=null)
        {
            if (Player1.data.state == ControllerData.PlayerStates.Dead && Player2.data.state == ControllerData.PlayerStates.Dead && Menu.instance.gameRunning == true)
            {
                //Game finished
                SoundManager.instance.PlayUniqueSound(SoundManager.instance.gameOver);

                Debug.Log("Game Finished");
                Menu.instance.gameRunning = false;

                UIManager.instance.GameOver();
            }
        }
        

        if(comboValue > 1 && timerGoingOn==false)  //start cooldown before loosing combo
        {
            SoundManager.instance.PlayUniqueSound(SoundManager.instance.combatStart);
            timer = timerBeforeLoosingCombo;
            timerGoingOn = true;
        }

        if (comboValue > 1 && comboValue % comboNumberMinToGetMultiplier == 0)
        {
            comboValueEachMobKilled = comboValue;
        }



        if (timer > 0 && timerGoingOn==true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && timerGoingOn == true)
        {
            //gain score
            if (comboValue > 1)
            {
                score += comboValue * (comboScoreMultiplier * (comboValueEachMobKilled / instance.comboNumberMinToGetMultiplier));
            }


            SoundManager.instance.PlayUniqueSound(SoundManager.instance.combatEnd);

            comboValue = 0;
            comboValueEachMobKilled = 0;

            timerGoingOn = false;



        }

       



    }


   
}
