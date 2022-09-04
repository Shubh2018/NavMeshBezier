using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject[] checkPoints;

    private NavMeshAgent agent;

    private GameObject cp;

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        currentIndex = 0;

        cp = checkPoints[currentIndex];

        agent.speed = 5.0f;

        agent.SetDestination(cp.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, cp.transform.position) < 2.5f)
        {
            if (currentIndex == checkPoints.Length - 1)
                currentIndex = 0;
            else
                currentIndex += 1;

            cp = checkPoints[currentIndex];

            agent.SetDestination(cp.transform.position);
        }
    }
}
