using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;

    [SerializeField] private GameObject[] checkPointsRight;

    [SerializeField] private GameObject[] checkPointsLeft;

    private GameObject[] chosenPath;

    private NavMeshAgent agent;

    private GameObject cp;

    int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        startPoint.GetComponent<MeshRenderer>().enabled = false;

        foreach(var go in checkPointsRight)
        {
            go.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (var go in checkPointsLeft)
        {
            go.GetComponent<MeshRenderer>().enabled = false;
        }

        currentIndex = 0;

        cp = startPoint;

        agent.speed = 5.0f;

        agent.SetDestination(cp.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(cp == startPoint)
        {
            currentIndex = 0;

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                chosenPath = checkPointsLeft;
            }

            else
            {
                chosenPath = checkPointsRight;
            }

        }

        if (Vector3.Distance(this.transform.position, cp.transform.position) < 2.5f)
        {
            if (currentIndex >= chosenPath.Length - 1)
            {
                cp = startPoint;
            }
            else
            {
                currentIndex += 1;
                cp = chosenPath[currentIndex];
            }
                
            agent.SetDestination(cp.transform.position);
        }

        //Debug.Log(cp.name);
    }
}
