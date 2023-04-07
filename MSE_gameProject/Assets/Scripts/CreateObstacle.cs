using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacle : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] LayerMask layerMask;
    private GameObject preCell;
    private GameObject cursorObj;

    // Start is called before the first frame update
    void Start()
    {
        cursorObj = Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
        cursorObj.SetActive(false);
        preCell = null;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            cursorObj.SetActive(true);
            Vector3 cursorPosition = new Vector3(hit.transform.position.x + (cursorObj.transform.localScale.x * 0.5f), hit.transform.position.y + (hit.transform.GetChild(0).localScale.y + cursorObj.transform.localScale.y)*0.5f, hit.transform.position.z);

            if ((preCell == null || preCell != hit.transform.gameObject))
            {

                cursorObj.transform.position = cursorPosition;
                preCell = hit.transform.gameObject;
                Debug.Log(hit.collider.gameObject.transform.parent.name + ": " + hit.collider.gameObject.name);
            }

            if (Input.GetMouseButtonDown(0) && hit.transform != null)
            {
                Instantiate(obstaclePrefab, cursorPosition, Quaternion.identity);
            }



        }
        else
        {
            cursorObj.SetActive(false);
        }

    }


}