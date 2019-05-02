﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [System.NonSerialized] public List<PlayerBehaviour> players;
    public GameObject playerPrefab;

    public void SpawnPlayer(int playerNumber)
    {
        if (playerNumber > PlayerSpawn.levelSpawns[LevelManager.instance.currentArena].Count)
        {
            Debug.Log("no spawn point available");
            return;
        }
        if (players == null)
        {
            players = new List<PlayerBehaviour>();
        }
        print("spawning player" + playerNumber);
        players.Add(Instantiate(playerPrefab, PlayerSpawn.levelSpawns[LevelManager.instance.currentArena][playerNumber].self.position, PlayerSpawn.levelSpawns[LevelManager.instance.currentArena][playerNumber].self.rotation).GetComponent<PlayerBehaviour>());
        players[players.Count - 1].gameObject.name = "Player" + playerNumber;
        PlayerData playerData = SaveManager.instance.playerDatas[playerNumber];
        players[playerNumber].credits = playerData.credits;
        players[playerNumber].maxAmmoUpgradeLevel = playerData.maxAmmoUpgradeLevel;
        players[playerNumber].maxHealthUpgradeLevel = playerData.maxHealthUpgradeLevel;
        players[playerNumber].maxStaminaUpgradeLevel = playerData.maxStaminaUpgradeLevel;
        players[playerNumber].speedUpgradeLevel = playerData.speedUpgradeLevel;
        players[playerNumber].startAmmoUpgradeLevel = playerData.startAmmoUpgradeLevel;
    }
}
