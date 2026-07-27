using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseNavigation : MonoBehaviour
{
    private NavMeshAgent playerNavAgent;

    [SerializeField]
    private GameObject clickMarker;

    private LineRenderer lineToClick;
    // Start is called before the first frame update
    void Start()
    {
        playerNavAgent = transform.GetComponent<NavMeshAgent>();
        clickMarker.SetActive(false);

        lineToClick = GetComponent<LineRenderer>();
        lineToClick.startWidth = 0.2f;
        lineToClick.endWidth = 0.2f;
        lineToClick.positionCount = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ClickToMove();
        }


        if (Vector3.Distance(playerNavAgent.destination, transform.position) <= playerNavAgent.stoppingDistance)
        {
            clickMarker.SetActive(false);
        }
        else if (playerNavAgent.hasPath)
        {
            DrawPath();
        }

    }

    private void ClickToMove()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(mouseRay,out hit, Mathf.Infinity))
        {
            playerNavAgent.SetDestination(hit.point);

            clickMarker.SetActive(true);

            clickMarker.transform.position = hit.point;

            clickMarker.transform.rotation = Quaternion.LookRotation(clickMarker.transform.forward, hit.normal);
        }


    }

    private void DrawPath()
    {
        int pathLength = playerNavAgent.path.corners.Length;

        lineToClick.positionCount = pathLength;

        lineToClick.SetPosition(0, transform.position);

        if (pathLength < 2)
        {
            return;
        }

        for (int i = 1; i < pathLength; i++)
        {
            Vector3 pointPos = playerNavAgent.path.corners[i];
            lineToClick.SetPosition(i, pointPos);
        }

    }


}
