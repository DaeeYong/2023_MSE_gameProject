using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private int posX, posY;

    //Save a reference to the gameobject that gets placed on this tile
    public GameObject objectInThisTile = null;

    //Save if the tile space is occupied or not
    public bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() {
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    private void OnMouseExit() {
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    }

    //Set the position of this tile
    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    //Get the position of this tile
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }
}
