﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfUpgrade
{
    health,
    healthRegen,
    speed,
    maxAmmo,
    ammoStart,
    stamina,
    staminaRegen
}

public class ItemOfUpgrade : MonoBehaviour
{
    public TypeOfUpgrade typeOfUpgrade;
    public TextMesh textPrice;
    public TextMesh textName;
    public float price;

    bool playerIn;
    PlayerGameplayValues playerValues;
    ControllerBehaviour playerController;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerGameplayValues>() != null)
        {
            playerIn = true;
            playerValues=other.GetComponent<PlayerGameplayValues>();
            playerController = other.GetComponent<ControllerBehaviour>();
            //player is buying

            Debug.Log(typeOfUpgrade);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        playerIn = false;
        playerValues = null;
        playerController = null;
    }

    public void Update()
    {
        textPrice.text = price.ToString();
        textName.text = typeOfUpgrade.ToString();

        if (playerController!=null)
        if (Input.GetButtonDown("A_Button" + playerController.data.playerID) && playerIn==true)
        {
            if (typeOfUpgrade == TypeOfUpgrade.health)
            {
                 if (GameManagerValues.instance.score >= price)
                {
                    playerValues.UpgradeHealth();
               }

            
            }

            if (typeOfUpgrade == TypeOfUpgrade.healthRegen)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeHealthRegen();
                }
            }

            if (typeOfUpgrade == TypeOfUpgrade.speed)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeSpeed();
                 }
            }

            if (typeOfUpgrade == TypeOfUpgrade.maxAmmo)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeMaxAmmo();
                }
            }

            if (typeOfUpgrade == TypeOfUpgrade.ammoStart)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeStartAmmo();
                }
            }

            if (typeOfUpgrade == TypeOfUpgrade.stamina)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeStamina();
             }
            }

            if (typeOfUpgrade == TypeOfUpgrade.staminaRegen)
            {
                    if (GameManagerValues.instance.score >= price)
                    {
                        playerValues.UpgradeStaminaRegen();
                }
            }
        }

    }
}
