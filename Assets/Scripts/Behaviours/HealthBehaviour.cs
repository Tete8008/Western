﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    [System.NonSerialized] public Image healthBar;

    public PlayerGameplayValues playerStats;
    ControllerBehaviour controllerBehaviour;

    public void Start()
    {
        playerStats = GetComponent<PlayerGameplayValues>();
        controllerBehaviour = GetComponent<ControllerBehaviour>();
        if (controllerBehaviour.data.playerID == "_1")
        {
            healthBar = UIManager.instance.menu.player1lifebar;
        }
        else
        {
            healthBar = UIManager.instance.menu.player2lifebar;
        }
    }

    public void Update()
    {
        healthBar.fillAmount = playerStats.health / playerStats.maxHealth;

        if (Input.GetKeyDown(KeyCode.Space) && playerStats.health > 0)
        {
            playerStats.health -= 10;
        }

        FillingUpHealth();
        PlayerDead();
    }


    public void FillingUpHealth()
    {
        if (playerStats.health < playerStats.maxHealth && controllerBehaviour.data.state!=ControllerData.PlayerStates.Dead)
        {
            playerStats.health += Time.deltaTime * playerStats.healthRegen;
        }
    }

    public void PlayerDead()
    {
        if (playerStats.health <= 0 && controllerBehaviour.data.state== ControllerData.PlayerStates.Alive)
        {
            SoundManager.instance.PlayDie();
           controllerBehaviour.data.state = ControllerData.PlayerStates.Dead;
        }
    }
}
