﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowData : MonoBehaviour
{
    public bool isFiring;

    public GameObject bullet;

    public float bulletSpeed;
    public float timeBetweenShots;
    public int magazineSize;

    public Transform firePoint;
}
