using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleState
{
    HORIZONTAL,
    VERTICAL
}
public class CreateObstacle : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] LayerMask layerMask;
    private GameObject preCell;
    private GameObject cursorObj;
    private ObstacleState obstacleState;

    // Start is called before the first frame update
    void Start()
    {
        obstacleState = ObstacleState.HORIZONTAL;
        cursorObj = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
        cursorObj.SetActive(false);
        preCell = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeObstacleState();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            cursorObj.SetActive(true);
            Vector3 cursorPosition = new Vector3(hit.transform.position.x + (cursorObj.transform.localScale.x * 0.5f), hit.transform.position.y + (hit.transform.GetChild(0).localScale.y + cursorObj.transform.localScale.y)*0.5f, hit.transform.position.z);

            if ((preCell == null || preCell != hit.transform.gameObject))
            {

                cursorObj.transform.position = cursorPosition;
                preCell = hit.transform.gameObject;
                Debug.Log(hit.collider.gameObject.transform.parent.name + ": " + hit.collider.gameObject.name);
                Debug.Log(hit.collider.gameObject.transform.parent.position);
            }

            if (Input.GetMouseButtonDown(0) && hit.transform != null)
            {
                GameObject go =Instantiate(obstaclePrefab, cursorPosition, Quaternion.identity);
                go.transform.GetChild(0).localPosition = cursorObj.transform.GetChild(0).localPosition;
                go.transform.GetChild(0).localRotation = cursorObj.transform.GetChild(0).localRotation;
            }



        }
        else
        {
            cursorObj.SetActive(false);
        }

    }

    private void ChangeObstacleState()
    {
        if (obstacleState == ObstacleState.HORIZONTAL)
        {   
            obstacleState = ObstacleState.VERTICAL;
            cursorObj.transform.GetChild(0).Rotate(new Vector3(0, -90, 0), Space.World);
            cursorObj.transform.GetChild(0).localPosition = new Vector3(0, 0f, -1);
        }
        else
        {
            obstacleState = ObstacleState.HORIZONTAL;
            cursorObj.transform.GetChild(0).Rotate(new Vector3(0, 90, 0), Space.World);
            cursorObj.transform.GetChild(0).localPosition = new Vector3(0.5f, 0f, - 0.5f);
        }
    }
}