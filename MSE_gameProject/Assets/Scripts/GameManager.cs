using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] Material[] playerMaterial;
    [SerializeField] private GameObject[] buttons;
    private GameObject[,] board;
    private GameObject[] player = new GameObject[2]; 
    private GameObject turn;
    private int index;
    private GameObject timer;

    // Start is called before the first frame update
    private void Start()
    {   
        CreateBoard();
        CreatePlayers();
        timer = GameObject.FindGameObjectWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if(player[0].transform.position.x == 0 || player[1].transform.position.x == 16)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        buttons[2].SetActive(true);
        Destroy(buttons[0]);
        Destroy(buttons[1]);
        Destroy(timer);
    }

    public void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        player[0].transform.GetChild(0).GetComponent<Renderer>().material = playerMaterial[0];
        board[16, 8].GetComponent<TileManager>().occupiedPlayer = 1;
        player[1] = Instantiate(playerPrefab, new Vector3(board[0, 8].transform.position.x, 0, board[0, 8].transform.position.z), Quaternion.identity);
        player[1].transform.GetChild(0).GetComponent<Renderer>().material = playerMaterial[1];
        board[0, 8].GetComponent<TileManager>().occupiedPlayer = 1;
        
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

    public int getIndex() { return index; }
}

