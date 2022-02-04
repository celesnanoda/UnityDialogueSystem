using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    WeaponConfig config;
    void Start()
    {
        Shoot();
    }

    public void Shoot()
    {
        Debug.Log($"Did {config.damage} damage with {config.name}.");
    }
}
