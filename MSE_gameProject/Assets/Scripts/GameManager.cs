using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    MYTURN,
    SENDING,
    UPDATING,
    WAITING,
    OTHERTURN,
    AFTERVALID
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] Material[] playerMaterial;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject actionBTN;
    private GameClient client;
    private GameObject[,] board;
    private GameObject[] player = new GameObject[2]; 
    private GameObject turn;
    public CreateObstacle creatingObstacle;
    private int index;
    private GameObject timer;
    private bool myturn = false;
    private PlayerForm fetchedData;
    public int playerType = 0;
    public PlayerState state;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {   
        CreateBoard();
        CreatePlayers();
        timer = GameObject.FindGameObjectWithTag("Timer");
        client = GameClient.GetInstance();
        myturn = client.turnindex > 1 ? false : true;
        if (myturn)
        {
            SetPlayerState(PlayerState.MYTURN);
            StartCoroutine(client.InitGame());
            playerType = 1;
        }
        else
        {
            SetPlayerState(PlayerState.OTHERTURN);
            playerType = 2;
            GetData();
        }
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
        if(timer.GetComponent<TimerManager>().leftTime <= 0)
        {
            turn.GetComponent<PlayerManager>().playermoving = 0;
            GameObject.FindGameObjectWithTag("Obstacle").GetComponent<CreateObstacle>().createobstacle = 0;
        }
         timer.GetComponent<TimerManager>().leftTime = 30;
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

    public void SetActionMovement()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        turn.GetComponent<PlayerManager>().playermoving = 1;
    }
    public void SetActionObstacle()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        GameObject.FindGameObjectWithTag("Obstacle").GetComponent<CreateObstacle>().createobstacle = 1;
    }

    public int GetIndex() { return index; }

    public void SetPlayerState(PlayerState state)
    {
        if (state == PlayerState.MYTURN) actionBTN.SetActive(true);
        if (state == PlayerState.OTHERTURN) actionBTN.SetActive(false);
        this.state = state;
        Debug.Log("State change: " + state);
    }

    //상대 턴 일 때 데이터 풀링
    public void GetData()
    {
        StartCoroutine(GetDataPooling());
    }
    IEnumerator GetDataPooling()
    {
        while (state == PlayerState.OTHERTURN)
        {
            yield return StartCoroutine(client.EFetchPosition(playerType));

            /*Debug.Log(fetchedData + ": " + new Vector2(turn.transform.position.x, -turn.transform.position.z));
            if (fetchedData.x == -1 && fetchedData.y == -1)
                yield return 0.1;
            else if (Vector2.Distance(fetchedData, new Vector2(turn.transform.position.x, -turn.transform.position.z)) < Mathf.Epsilon)
                yield return 0.1;
            else
            {
                Debug.Log("received changed data");
                SetPlayerState(PlayerState.UPDATING);
                turn.transform.position = new Vector3(fetchedData.x, turn.transform.position.y, -fetchedData.y);
                Debug.Log("GetDataPooling: Update finish");
                yield return StartCoroutine(client.ESetTurn(playerType));
            }*/

            if (fetchedData.getCol1() == -1 && fetchedData.getRow1() == -1 && fetchedData.getCol2() == -1 && fetchedData.getRow2() == -1)
                yield return 0.1;
            else if (fetchedData.getAction() == "moving"){
                if(Vector2.Distance(new Vector2(fetchedData.getCol1(), fetchedData.getRow1()), new Vector2(turn.transform.position.x, -turn.transform.position.z)) < Mathf.Epsilon)
                    yield return 0.1;
                else
                {
                    Debug.Log("received changed player data");
                    SetPlayerState(PlayerState.UPDATING);
                    turn.transform.position = new Vector3(fetchedData.getCol1(), turn.transform.position.y, -fetchedData.getRow1());
                    Debug.Log("GetDataPooling: Update finish");
                    yield return StartCoroutine(client.ESetTurn(playerType));
                }
            }
            else if (fetchedData.getAction() == "blocking"){
                if(board[fetchedData.getCol1(), fetchedData.getRow1()].GetComponent<TileManager>().occupiedOtc == 1 &&
                board[fetchedData.getCol2(), fetchedData.getRow2()].GetComponent<TileManager>().occupiedOtc == 1)
                    yield return 0.1;
                else
                {
                    Debug.Log("received changed obstacle data");
                    SetPlayerState(PlayerState.UPDATING);
                    if(fetchedData.getCol1() != fetchedData.getCol2()) {
                        creatingObstacle.setObstacleState(1);
                    }
                    else if(fetchedData.getRow1() != fetchedData.getRow2()) {
                        creatingObstacle.setObstacleState(0);
                    }
                    Vector3 pos = new Vector3(fetchedData.getCol1() + (creatingObstacle.cursorObj.transform.localScale.x * 0.5f), 
                    (creatingObstacle.offset + creatingObstacle.cursorObj.transform.localScale.y)*0.5f, 
                    -fetchedData.getRow1());
                    creatingObstacle.PlaceObstacle(pos);
                    Debug.Log("GetDataPooling: Update finish");
                    yield return StartCoroutine(client.ESetTurn(playerType));
                }
            }
        }

        
    }

    public void WaitUpdateFinish()
    {
        StartCoroutine(WaitUpdateEnd());
    }
    IEnumerator WaitUpdateEnd()
    {
        while(state == PlayerState.WAITING)
        {
            yield return StartCoroutine(client.EGetTurn(playerType));
        }
        yield return null;
    }
    //client 에서 받아온 데이터 받기
    public void setFetchedData(PlayerForm playerData)
    {
        fetchedData = playerData;
    }

    /*public void WaitValid()
    {
        StartCoroutine(WaitValidData());
    }
    IEnumerator WaitValidData()
    {
        while(state == PlayerState.WAITING)
        {
            yield return StartCoroutine(client.EFetchOValid());
        }
        yield return null;
    }*/

    public void SetValidPlace(bool valid)
    {
        creatingObstacle.validPlace = valid;
    }

    public static GameManager GetInstance() { return instance; }
}

