using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pickup : MonoBehaviour
{
    private float time = 7;
    private int score = 0;
    private PlayerMovement playermovement;
    // Start is called before the first frame update
    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 0)
        {
            Debug.Log($"game over. score: {score}");
            playermovement.enabled = false;
            enabled = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            score += 10;
            Debug.Log($"picked up coin. +10 score");
        }
    }
}
