using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Number of tiles 17x17
    private int height = 17; 
    private int width = 17;
    private float spaceSize = 1f;

    [SerializeField] private GameObject tilePrefab;
    public GameObject[,] gameBoard;

    public void CreateBoard()
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
                gameBoard[x, y] = Instantiate(tilePrefab, new Vector3(x * spaceSize, 0, -y * spaceSize), Quaternion.identity);
                //gameBoard[x, y] = Instantiate(tilePrefab, new Vector3((x) * spaceSize, 0, (-y) * spaceSize), Quaternion.identity);
                gameBoard[x, y].GetComponent<TileManager>().SetPosition(x, y);
                gameBoard[x, y].transform.parent = transform;
                gameBoard[x, y].gameObject.name = "Space (X: " + x.ToString() + " , Y:" + y.ToString() + ")";
            }
        }
    }

}
