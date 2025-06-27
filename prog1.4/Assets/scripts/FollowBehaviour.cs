using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
    Vector3 startposition;
    Vector3 moveTo;
    GameObject player;
    private float moveSpeed = 5;
    private bool isReturning = false;
    private bool isMovingToPlayer = false;
    private bool isPositionSet = false;
    private float lerpTimer = 0;
    private float lerpDuration = 1;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(WaitAtStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (isReturning)
        {
            ReturnToStart();
        }
        else if (isMovingToPlayer)
        {
            FollowTarget();
        }
    }
    private void FollowTarget()
    {
        transform.position = startposition;
        if (!isPositionSet)
        {
            moveTo = player.transform.position;
            isPositionSet = true;
        }
        lerpTimer += Time.deltaTime;
        float t = Mathf.Clamp01(lerpTimer / lerpDuration);
        transform.position = Vector3.Lerp(startposition, moveTo, t);
        float distance = Vector3.Distance(transform.position, moveTo);
        if (distance < 0.05)
        {
            Debug.Log("should move back");
            isReturning = true;
            moveTo = new Vector3(0, 0, 0);
            isMovingToPlayer = false;
            isPositionSet = false;
            lerpTimer = 0;
        }
    }
    private void ReturnToStart()
    {
        Vector3 direction = (startposition - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, startposition, moveSpeed * Time.deltaTime);
        float distanceToStart = Vector3.Distance(transform.position, startposition);
        if (distanceToStart < 0.05)
        {
            isReturning = false;
            isMovingToPlayer = true;
        }
    }
    private IEnumerator WaitAtStart()
    {
        yield return new WaitForSeconds(1);
        isMovingToPlayer = true;
    }
}
