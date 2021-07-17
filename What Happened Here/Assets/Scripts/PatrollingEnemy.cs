using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : Enemy
{
    Vector3[] waypoints;
    int targetIndex = 0;
    public float speed = 5f;
    Vector3 targetPos;
    Vector3 velocityToTarget;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        waypoints = new Vector3[children.Length];
        for (int i = 0; i < children.Length; i++)
        {
            waypoints[i] = children[i].position;
        }
        if (children.Length > 0)
        {
            targetPos = waypoints[++targetIndex];
            velocityToTarget = (targetPos - transform.position).normalized * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocityToTarget * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            targetIndex = (targetIndex + 1) % waypoints.Length;
            targetPos = waypoints[targetIndex];
            velocityToTarget = (targetPos - transform.position).normalized * speed;
        }

        
    }
}
