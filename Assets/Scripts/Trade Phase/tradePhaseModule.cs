using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Catan.GameManagement;
using Catan.ResourcePhase;

public class tradePhaseModule : MonoBehaviour
{
    public Resource[][] resources;
    public void getAllresources()
    { 
         var GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        resources = new Resource [GM.Players.Length][];
         for (int i = 0; i < GM.Players.Length; i++)
        {
            resources[i] = GM.Players[i].resources;
        }
    }
    void Start()
    {
        getAllresources();
    }

}
