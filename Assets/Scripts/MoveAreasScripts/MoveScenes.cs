using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    public int sceneBuildIndex;

    //[SerializeField] private string Outside;

    //level move zoned enter, if collider is a player
    //move to another scene

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered");
        print("Trigger entered");
        if (other.CompareTag("Player"))
        //if (other.GetComponent<Player>())
        { 
                Debug.Log("Player registered");
                //player entered, so move level
                print("Switching scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            //SceneManager.LoadScene(Outside);
            }
        }
    }

