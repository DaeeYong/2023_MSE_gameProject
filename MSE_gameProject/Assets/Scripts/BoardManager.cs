using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Number of tiles 17x17
    private int height = 17; 
    private int width = 17;
    //space between tiles  = Size of tile
    private float spaceSize = 1f;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject playerPrefab;
    private GameObject[,] gameBoard;
    

    // Start is called before the first frame update
    void Start()
    {
        CreateBoard();
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreatePlayer()
    {
        Instantiate(playerPrefab, new Vector3(gameBoard[16, 8].transform.position.x, 0, gameBoard[16, 8].transform.position.z), Quaternion.identity);
    }

    private void CreateBoard()
    {
        gameBoard = new GameObject[width, height];


        if(tilePrefab == null)
        {
            Debug.LogError("ERROR : Tile prefab on the MakeBoard script is not assigned");
            return;
        }

        //Create a board instantiating objects of tiles
        //x, y : board position (x, z in world position)
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                gameBoard[x, y] = Instantiate(tilePrefab, new Vector3((x-Mathf.FloorToInt(width/2)) * spaceSize, 0, (y-Mathf.FloorToInt(height/2)) * spaceSize), Quaternion.identity);
                gameBoard[x, y].GetComponent<TileManager>().SetPosition(x, y);
                gameBoard[x, y].transform.parent = transform;
                gameBoard[x, y].gameObject.name = "Space (X: " + x.ToString() + " , Y:" + y.ToString() + ")";
            }
        }
    }

    //Get the board position from wolrd position
    public Vector2Int GetBoardPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / spaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / spaceSize);
        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x, y);
    }

    //Get the world position of board position
    public Vector3 GetWorldPosFromBoardPos(Vector2Int boardPos)
    {
        float x = boardPos.x * spaceSize;
        float y = boardPos.y * spaceSize;

        return new Vector3(x, 0, y);
    }
}
