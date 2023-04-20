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
    [SerializeField] Material[] obstacleMaterial;
    [SerializeField] LayerMask layerMask;
    private GameObject preCell;
    private GameObject cursorObj;
    private bool canPlace;
    private ObstacleState obstacleState;

    public int[,] mapdata;
    
        // Start is called before the first frame update
    void Start()
    {
        obstacleState = ObstacleState.HORIZONTAL;
        cursorObj = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
        cursorObj.SetActive(false);
        preCell = null;
        mapdata = new int[17, 17];
        canPlace = true;
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
                printLog(hit.transform);
            }

            if (!CheckValid(hit.transform))
            {
                canPlace = false;
                cursorObj.transform.GetChild(0).GetComponent<Renderer>().material = obstacleMaterial[1];
            }
            else
            {
                cursorObj.transform.GetChild(0).GetComponent<Renderer>().material = obstacleMaterial[0];
                canPlace = true;
            }

            if (Input.GetMouseButtonDown(0) && hit.transform != null && canPlace)
            {
                PlaceObstacle(cursorPosition);

                switch (obstacleState)
                {
                    case ObstacleState.HORIZONTAL:
                        mapdata[(int)hit.transform.position.x + 8, -(int)hit.transform.position.z + 8] = 3;
                        mapdata[(int)hit.transform.position.x + 8 + 1, -(int)hit.transform.position.z + 8] = 3;
                        break;
                    case ObstacleState.VERTICAL:
                        mapdata[(int)hit.transform.position.x + 8, -(int)hit.transform.position.z + 8] = 3;
                        mapdata[(int)hit.transform.position.x + 8, -(int)hit.transform.position.z + 8 + 1] = 3;
                        break;
                }
            }

        }
        else
        {
            cursorObj.SetActive(false);
        }

    }

    private void printLog(Transform t)
    {
        string debugMsg = "";
        switch (obstacleState)
        {
            case ObstacleState.HORIZONTAL:
                debugMsg = debugMsg + "orgin arr value: " + mapdata[(int)t.position.x + 8, -(int)t.position.z + 8];
                debugMsg = debugMsg + "right arr value: " + mapdata[(int)t.position.x + 8 + 1, -(int)t.position.z + 8];
                Debug.Log(debugMsg);
                break;
            case ObstacleState.VERTICAL:
                debugMsg = "";
                debugMsg = debugMsg + "orgin arr value: " + mapdata[(int)t.position.x + 8, -(int)t.position.z + 8];
                debugMsg = debugMsg + "down arr value: " + mapdata[(int)t.position.x + 8, -(int)t.position.z + 8 + 1];
                Debug.Log(debugMsg);
                break;
        }
    }
    private void PlaceObstacle(Vector3 cursorPosition)
    {
        GameObject go = Instantiate(obstaclePrefab, cursorPosition, Quaternion.identity);
        go.transform.GetChild(0).localPosition = cursorObj.transform.GetChild(0).localPosition;
        go.transform.GetChild(0).localRotation = cursorObj.transform.GetChild(0).localRotation;
    }
    private bool CheckValid(Transform t)
    {   
        switch (obstacleState)
        { 
            case ObstacleState.HORIZONTAL:
                if ((int)t.position.x + 8 == 16) return false;
                if (mapdata[(int)t.position.x + 8, -(int)t.position.z + 8] == 0 && mapdata[(int)t.position.x + 8 + 1, -(int)t.position.z + 8] == 0) return true;
                else return false;
            case ObstacleState.VERTICAL:
                if (-(int)t.position.z + 8 == 16) return false;
                if (mapdata[(int)t.position.x + 8, -(int)t.position.z + 8] == 0 && mapdata[(int)t.position.x + 8, -(int)t.position.z + 8 + 1] == 0) return true;
                else return false;
            default: return false;
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