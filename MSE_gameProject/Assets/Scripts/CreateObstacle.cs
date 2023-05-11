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
    [SerializeField] Material[] playerObstacleMaterial;
    [SerializeField] LayerMask layerMask;
    private GameObject cursorObj;
    private bool canPlace;
    private ObstacleState obstacleState;
    public int createobstacle;
    private GameObject gameManager;
    private GameObject[,] board;

    //public int[,] mapdata;
    
        // Start is called before the first frame update
    void Start()
    {
        obstacleState = ObstacleState.HORIZONTAL;
        cursorObj = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
        cursorObj.SetActive(false);
        canPlace = true;
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        createobstacle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (createobstacle == 0) return;

        if (Input.GetKeyDown(KeyCode.R)) ChangeObstacleState();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            cursorObj.SetActive(true);
            Vector3 cursorPosition = new Vector3(hit.transform.position.x + (cursorObj.transform.localScale.x * 0.5f), hit.transform.position.y + (hit.transform.GetChild(0).localScale.y + cursorObj.transform.localScale.y)*0.5f, hit.transform.position.z);

            if (cursorObj.transform.position != cursorPosition) cursorObj.transform.position = cursorPosition;

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
                        board[(int)hit.transform.position.x, -(int)hit.transform.position.z].GetComponent<TileManager>().occupiedOtc = 1;
                        board[(int)hit.transform.position.x+1, -(int)hit.transform.position.z].GetComponent<TileManager>().occupiedOtc = 1;
                        break;
                    case ObstacleState.VERTICAL:
                        board[(int)hit.transform.position.x, -(int)hit.transform.position.z].GetComponent<TileManager>().occupiedOtc = 1;
                        board[(int)hit.transform.position.x, -(int)hit.transform.position.z + 1].GetComponent<TileManager>().occupiedOtc = 1;
                        break;
                }
                createobstacle = 0;
                gameManager.GetComponent<GameManager>().TurnChange();
            }

        }
        else
        {
            cursorObj.SetActive(false);
        }
    }

    private void PlaceObstacle(Vector3 cursorPosition)
    {
        Transform go = Instantiate(obstaclePrefab, cursorPosition, Quaternion.identity).transform.GetChild(0);
        go.localPosition = cursorObj.transform.GetChild(0).localPosition;
        go.localRotation = cursorObj.transform.GetChild(0).localRotation;
        go.gameObject.GetComponent<Renderer>().material = playerObstacleMaterial[gameManager.GetComponent<GameManager>().GetIndex()];
    }
    private bool CheckValid(Transform t)
    {  
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardManager>().gameBoard;
        switch (obstacleState)
        { 
            case ObstacleState.HORIZONTAL:
                if ((int)t.position.x == 16) return false;
                if (board[(int)t.position.x, -(int)t.position.z].GetComponent<TileManager>().occupiedOtc == 0
                && board[(int)t.position.x, -(int)t.position.z].GetComponent<TileManager>().occupiedPlayer == 0
                && board[(int)t.position.x+1, -(int)t.position.z].GetComponent<TileManager>().occupiedOtc == 0
                && board[(int)t.position.x+1, -(int)t.position.z].GetComponent<TileManager>().occupiedPlayer == 0)
                {
                    return true;
                }
                return false;
            case ObstacleState.VERTICAL:
                if (-(int)t.position.z == 16) return false;
                if (board[(int)t.position.x, -(int)t.position.z].GetComponent<TileManager>().occupiedOtc == 0
                && board[(int)t.position.x, -(int)t.position.z].GetComponent<TileManager>().occupiedPlayer == 0
                && board[(int)t.position.x, -(int)t.position.z+1].GetComponent<TileManager>().occupiedOtc == 0
                && board[(int)t.position.x, -(int)t.position.z+1].GetComponent<TileManager>().occupiedPlayer == 0)
                    return true;
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
