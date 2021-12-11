using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class templateScript : MonoBehaviour
{
    [SerializeField]
    private GameObject finalObject;//your gameobject that you want to place

    private Vector2 mousePos;

    public int gridSize = 3;

    [SerializeField]
    public LayerMask allTileLayers;
    [SerializeField]
    public game_manager Game_Manager;
    private void Start()
    {
        GameObject myObj = GameObject.Find("templateScript");
        Game_Manager = GetComponent<game_manager>();
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(Mathf.Round(mousePos.x / gridSize) * gridSize, Mathf.Round(mousePos.y / gridSize) * gridSize);

        //       Debug.Log(mousePos);
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos,Vector2.zero,Mathf.Infinity,allTileLayers);

            if(rayHit.collider == null)
            {
                placeObj();
            }//makes sure objects dont stack
        }//place

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, allTileLayers);

            if (rayHit.collider != null)
            {
                var hitReciver = rayHit.collider.gameObject.GetComponent<plant>();
                if (hitReciver != null && hitReciver.plantMode == "grown")
                {
                    hitReciver.Destroy();
                    Game_Manager.addMoney();
                }
            }
        }//Destroy


    }
    void placeObj() 
    {
        Instantiate(finalObject, transform.position, Quaternion.identity);
    }
}
