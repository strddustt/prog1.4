using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlacer : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-9f, 10f), 1f, UnityEngine.Random.Range(-9f, 10f));
            Instantiate(coin, position, Quaternion.identity); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
