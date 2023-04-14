using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Extensions
{
    public static int findIndex<T>(this T[] array, T item) 
    {
        return Array.FindIndex(array, val => val.Equals(item));
    }
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject[,] board;
    private GameObject[] player = new GameObject[2]; 
    private GameObject turn;

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
        player[1] = Instantiate(playerPrefab, new Vector3(board[0, 8].transform.position.x, 0, board[0, 8].transform.position.z), Quaternion.identity);
        turn = player[0];    
    }

    public void TurnChage()
    {
        int index = player.findIndex(turn);
        if(index == player.Length-1)
        {
            turn = player[0];
            Debug.Log(turn);
        }
        else
        {
            turn = player[index++];
            Debug.Log(turn);
        }
    }
}
