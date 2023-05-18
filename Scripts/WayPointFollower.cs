using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints = { };
    int currenWayPointIndex = 0;

    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(wayPoints[currenWayPointIndex].transform.position, transform.position) < 0.1f)
        {
            if(currenWayPointIndex == 1)
            {
                currenWayPointIndex = 0;
            }
            else if(currenWayPointIndex == 0)
            {
                currenWayPointIndex = 1;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currenWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
