using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp : MonoBehaviour
{
    public int startHP = 100;
    private int currentHp;


    void Start()
    {
        currentHp = startHP;
    }
    public int GetHP()
    {
        return currentHp;

    }
    public void Hit(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            currentHp = 0;
            Debug.Log("düşman  öldü" + currentHp);

        }
        Debug.Log("düşman vuruldu" + currentHp);
    }

    void Update()
    {
        
    }
}
