using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOutside : MonoBehaviour
{
    public int sceneBuildIndex;

    //level move zoned enter, if collider is a player
    //move to another scene

    private void onTriggerEnter2D(Collider2D other)
    {
        print("Trigger entered");
        //could use other.GetComponent<Player>() to see if game object has a player component

        if(other.tag == "player")
        {
            //player entered, so move level
            print("Switching scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
