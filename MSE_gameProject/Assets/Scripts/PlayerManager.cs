using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private LayerMask TileLayer;

    private GameObject[,] board;
    public int playermoving;
    private GameObject timer;
    private GameObject gameManager;
    [SerializeField] Material[] obstacleMaterial;
    Vector3[] available = new Vector3[4];

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardManager>().gameBoard;
        timer = GameObject.FindGameObjectWithTag("Timer");
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        playermoving = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playermoving == 1)
        {
            available[0] = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            available[1] = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            available[2] = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            available[3] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);

            showAvailable();
            TileManager tileMouseOver = IsMouseOverATile();
            
            if(tileMouseOver != null && tileMouseOver.isOccupied == 0)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    if(isValid(tileMouseOver.transform.position))
                    {
                        board[(int)transform.position.x, -(int)transform.position.z].GetComponent<TileManager>().isOccupied = 0;
                        tileMouseOver.isOccupied = 1;
                        Vector3 pos = tileMouseOver.transform.position;
                        Debug.Log(pos);
                    
                        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
                        timer.GetComponent<TimerManager>().makeZerotime();
                        gameManager.GetComponent<GameManager>().TurnChange();
                        playermoving = 0;
                    }
                }
            }
        }
        else
            removeAvailable();
    }

    private void showAvailable()
    {
        for(int i = 0; i < available.Length; i++)
        {
            if(available[i].x >= 0 && available[i].x < 17 && -(int)available[i].z >= 0 && -(int)available[i].z < 17)
            {
                board[(int)available[i].x, -(int)available[i].z].transform.GetChild(0).GetComponent<Renderer>().material = obstacleMaterial[1];
            }
        }
    }
    private void removeAvailable()
    {
        for(int i = 0; i < available.Length; i++)
        {
            if(available[i].x >= 0 && available[i].x < 17 && -(int)available[i].z >= 0 && -(int)available[i].z < 17)
            {
                board[(int)available[i].x, -(int)available[i].z].transform.GetChild(0).GetComponent<Renderer>().material = obstacleMaterial[2];
            }
        }
    }

    private bool isValid(Vector3 click)
    {
        for(int i = 0; i < available.Length; i++)
        {
            if(click == available[i])
            {
                return true;
            }
        }
        return false;
    
    }

    //Return the tile if mouse is over
    private TileManager IsMouseOverATile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f, TileLayer))
        {
            return hitInfo.transform.GetComponent<TileManager>();
        }
        else
        {
            return null;
        }
    }

    
}

