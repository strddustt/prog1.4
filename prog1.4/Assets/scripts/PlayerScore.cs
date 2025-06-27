using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerScore : MonoBehaviour
{
    // To Do's:
    private int score;
    private List<int> coins = new List<int>();
    void Start()
    { 

    }

    void Update()
    {
        if (score >= 50)
        {
            Debug.Log("you won");
        }


        if (Input.GetKeyDown(KeyCode.Space) )
        {
            int i = Random.Range(1, 6);
            AddCoin(i);
        }
    }
    private void LateUpdate()
    {
        //code
    }

    // Functie om een munt toe te voegen
    void AddCoin(int coinValue)
    {
        coins.Add(coinValue);
        score += coinValue;
        Debug.Log($"picked up coin. score = {score}"); 
    }
}