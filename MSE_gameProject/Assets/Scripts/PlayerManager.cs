using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private LayerMask TileLayer;

    private GameObject[,] board;
    public int playermoving;
    private GameObject timer;
    private GameObject gameManager;
    [SerializeField] Material[] availableMaterial;
    private ArrayList available;

    // Start is called before the first frame update
    void Start()
    {
        available = new ArrayList();
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
            calculateAvailable();
            showAvailable();
            TileManager tileMouseOver = IsMouseOverATile();
            
            if(tileMouseOver != null && tileMouseOver.occupiedOtc == 0 && tileMouseOver.occupiedPlayer == 0)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    if(isValid(tileMouseOver.transform.position))
                    {
                        board[(int)transform.position.x, -(int)transform.position.z].GetComponent<TileManager>().occupiedPlayer = 0;
                        tileMouseOver.occupiedPlayer = 1;
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
        {
             removeAvailable();
             available.Clear();
        }
    }

    private void calculateAvailable() 
    {
        if(inBoard(new Vector2(transform.position.x - 1, -(int)transform.position.z)))
        {
            if(board[(int)transform.position.x - 1, -(int)transform.position.z].GetComponent<TileManager>().occupiedPlayer == 0)
            {
                available.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
            }
            else
            {
                if(inBoard(new Vector2(transform.position.x - 2, -(int)transform.position.z)))
                {
                    if(board[(int)transform.position.x - 2, -(int)transform.position.z].GetComponent<TileManager>().occupiedOtc == 0)
                    {
                        available.Add(new Vector3(transform.position.x - 2, transform.position.y, transform.position.z));
                    }
                    else
                    {
                        if(inBoard(new Vector2(transform.position.x - 1, -((int)transform.position.z - 1))))
                            available.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1));
                        if(inBoard(new Vector2(transform.position.x - 1, -((int)transform.position.z + 1))))
                            available.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1));
                    }
                }
            }
        }
        
        if(inBoard(new Vector2(transform.position.x + 1, -(int)transform.position.z)))
        {
            if(board[(int)transform.position.x + 1, -(int)transform.position.z].GetComponent<TileManager>().occupiedPlayer == 0)
            {
                available.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
            }
            else
            {
                if(inBoard(new Vector2(transform.position.x + 2, -(int)transform.position.z)))
                {
                    if(board[(int)transform.position.x + 2, -(int)transform.position.z].GetComponent<TileManager>().occupiedOtc == 0)
                    {
                        available.Add(new Vector3(transform.position.x + 2, transform.position.y, transform.position.z));
                    }
                    else
                    {
                        if(inBoard(new Vector2(transform.position.x + 1, -((int)transform.position.z - 1))))
                            available.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1));
                        if(inBoard(new Vector2(transform.position.x + 1, -((int)transform.position.z + 1))))
                            available.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1));
                    }
                }
            }
        }

        if(inBoard(new Vector2(transform.position.x, -((int)transform.position.z - 1))))
        {
            if(board[(int)transform.position.x, -((int)transform.position.z - 1)].GetComponent<TileManager>().occupiedPlayer == 0)
            {
                available.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1));
            }
            else
            {
                if(inBoard(new Vector2(transform.position.x, -((int)transform.position.z - 2))))
                {
                    if(board[(int)transform.position.x, -((int)transform.position.z - 2)].GetComponent<TileManager>().occupiedOtc == 0)
                    {
                        available.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z - 2));
                    }
                    else
                    {
                        if(inBoard(new Vector2(transform.position.x - 1, -((int)transform.position.z - 1))))
                            available.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z - 1));
                        if(inBoard(new Vector2(transform.position.x + 1, -((int)transform.position.z - 1))))
                            available.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z - 1));
                    }
                }
            }
        }

        if(inBoard(new Vector2(transform.position.x, -((int)transform.position.z + 1))))
        {
            if(board[(int)transform.position.x, -((int)transform.position.z + 1)].GetComponent<TileManager>().occupiedPlayer == 0)
            {
                available.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
            }
            else
            {
                if(inBoard(new Vector2(transform.position.x, -((int)transform.position.z + 2))))
                {
                    if(board[(int)transform.position.x, -((int)transform.position.z + 2)].GetComponent<TileManager>().occupiedOtc == 0)
                    {
                        available.Add(new Vector3(transform.position.x, transform.position.y, transform.position.z + 2));
                    }
                    else
                    {
                        if(inBoard(new Vector2(transform.position.x - 1, -((int)transform.position.z + 1))))
                            available.Add(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 1));
                        if(inBoard(new Vector2(transform.position.x + 1, -((int)transform.position.z + 1))))
                            available.Add(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 1));
                    }
                }
            }
        }
    }

    private bool inBoard(Vector2 point) 
    {
        if(point.x >= 0 && point.x < 17 && point.y >= 0 && point.y < 17)
        {
            return true;
        }
        return false;
    }

    private void showAvailable()
    {
        for(int i = 0; i < available.Count; i++)
        {
            if(inBoard(new Vector2(((Vector3)available[i]).x, -((int)((Vector3)available[i]).z))))
            {
                board[(int)((Vector3)available[i]).x, -(int)((Vector3)available[i]).z].transform.GetChild(0).GetComponent<Renderer>().material = availableMaterial[0];
            }
        }
    }
    
    private void removeAvailable()
    {
        for(int i = 0; i < available.Count; i++)
        {
            if(inBoard(new Vector2(((Vector3)available[i]).x, -((int)((Vector3)available[i]).z))))
            {
                board[(int)((Vector3)available[i]).x, -(int)((Vector3)available[i]).z].transform.GetChild(0).GetComponent<Renderer>().material = availableMaterial[1];
            }
        }
    }

    private bool isValid(Vector3 click)
    {
        for(int i = 0; i < available.Count; i++)
        {
            if(click.Equals(available[i]))
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

