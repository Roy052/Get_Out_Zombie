using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    None = 0,
    Audio = 1,
    Vision = 2,
}

public class ZombieAI : Singleton
{
    const float ForgetTime = 3f;

    public float moveSpeed;
    public InfoType currentInfoType;
    public Vector2 currentMovePos;

    List<Vector2> path = new List<Vector2>();
    float currentTime;
    float speed = 4f;
    int currentWaypoint = 0;

    private void Awake()
    {
        zombieAI = this;
    }

    private void OnDestroy()
    {
        if(zombieAI == this)
            zombieAI = null;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        //1. Forget
        if (currentTime >= ForgetTime)
        {
            currentInfoType = InfoType.None;
            return;
        }

        //2. Arrive
        if (Vector2.Distance(transform.position, currentMovePos) <= 0.1f)
        {
            currentInfoType = InfoType.None;
            return;
        }

        //3. Move
        if(currentInfoType != InfoType.None)
        {
            // Move towards the next waypoint on the path
            if (currentWaypoint < path.Count)
            {
                Vector2 direction = (path[currentWaypoint] - (Vector2)transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;

                // Check if the enemy has reached the current waypoint
                if (Vector2.Distance(transform.position, path[currentWaypoint]) < 0.1f)
                {
                    currentWaypoint++;
                }
            }
            else
                FindWay();
        }
    }

    public void FindWay()
    {
        path = pathfinding.FindPath(transform.position, currentMovePos);
        currentWaypoint = 0;
    }

    public void AddInformation(InfoType type, Vector2 movePos)
    {
        if (currentInfoType > type)
            return;

        currentInfoType = type;
        currentMovePos = movePos;
        currentTime = 0f;
    }
}
