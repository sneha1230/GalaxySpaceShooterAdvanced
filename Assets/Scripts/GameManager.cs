using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //if gameover is true then game over screen will disappear then  press space key to respawn the player
    //else gameover screen will appear
    public bool gameOver = true;
    public GameObject player;
    public UIManager uiManager;
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //game over scene to be inactive and player needs to respawn
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                uiManager.HideGameOverScreen();
            }
        }
    }
}
