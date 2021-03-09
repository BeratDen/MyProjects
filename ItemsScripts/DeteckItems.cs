using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteckItems : MonoBehaviour
{
    PlayerHP playerHP;
    private void Start()
    {
        playerHP = GetComponent<PlayerHP>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealtItem"))
        {
            playerHP.AddHP(20);
            other.gameObject.SetActive(false);
            print("20 can eklendi" + playerHP.GetHealth());
        } 
    }

}
