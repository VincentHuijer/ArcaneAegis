using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public enum GameState {FreeRoam, Dialogue, Battle}
    public class GameController : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;

        GameState state;

        private void Update()
        {
            if (state == GameState.FreeRoam)
            {
                playerController.HandleUpdate();
            }
            else if (state == GameState.Dialogue){
        }
        
        else if (state == GameState.Battle){}
            
            }
    }