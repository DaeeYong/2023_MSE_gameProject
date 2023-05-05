using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject[] buttons;
    private GameObject[,] board;
    private GameObject[] player = new GameObject[2]; 
    private GameObject turn;
    private int index;

    // Start is called before the first frame update
    private void Start()
    {   
        CreateBoard();
        CreatePlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateBoard()
    {
        GameObject gameBoard = GameObject.FindGameObjectWithTag("Board");
        gameBoard.GetComponent<BoardManager>().CreateBoard();
        board = gameBoard.GetComponent<BoardManager>().gameBoard;
    }

    private void CreatePlayers()
    {
        player[0] = Instantiate(playerPrefab, new Vector3(board[16, 8].transform.position.x, 0, board[16, 8].transform.position.z), Quaternion.identity);
        board[16, 8].GetComponent<TileManager>().isOccupied = 1;
        player[1] = Instantiate(playerPrefab, new Vector3(board[0, 8].transform.position.x, 0, board[0, 8].transform.position.z), Quaternion.identity);
        board[0, 8].GetComponent<TileManager>().isOccupied = 1;
        
        turn = player[0];    
    }

    public void TurnChange()
    {
        if(index == player.Length-1)
        {
            Debug.Log(index);
            turn = player[0];
            index = 0;
        }
        else
        {
            Debug.Log(index);
            index++;
            turn = player[index];
        }
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
    }

    public void setActionMovement()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        turn.GetComponent<PlayerManager>().playermoving = 1;
    }
    public void setActionObstacle()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        GameObject.FindGameObjectWithTag("Obstacle").GetComponent<CreateObstacle>().createobstacle = 1;
    }
}
