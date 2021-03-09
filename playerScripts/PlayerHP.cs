using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    void Start()
    {
        currentHP = maxHP;   
    }
    public int GetHealth()
    {
        return currentHP;
    }
    public void DeductHp(int damage)
    {
        currentHP = currentHP - damage;
        print("oyuncu hasar alıyor" +currentHP);
        if (currentHP <= 0)
        {
            Killplayer();
        }
    }

    private void Killplayer()
    {
        Debug.Log("Oyuncu öldü");
    }

    public void AddHP(int value) 
    {      
        currentHP = currentHP + value;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
