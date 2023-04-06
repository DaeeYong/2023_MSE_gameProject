using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    BoardManager board;
    PlayerManager player;

    [SerializeField] private LayerMask TileLayer;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TileManager tileMouseOver = IsMouseOverATile();
        
        if(tileMouseOver != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 pos = tileMouseOver.transform.position;
                Debug.Log(pos);
                player = FindObjectOfType<PlayerManager>();
                Vector3 destination = new Vector3(pos.x, player.transform.position.y, pos.z);
                player.transform.position = destination;
                
            }
        }
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
