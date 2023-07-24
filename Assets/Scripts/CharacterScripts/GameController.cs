using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public enum GameState { FreeRoam, Dialogue, Battle } //freeRoam = kunnen rondlopen, Dialogue = in een gesprek, Battle = in een gevecht.
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;

    private void Start() //we moeten wisselen tussen states. We doen dit door de instantie van de dialogue manager voor show en hide.
    {
        DialogueManager.Instance.onShowDialogue += () =>
        {
            state = GameState.Dialogue;
        };


        {
            DialogueManager.Instance.onHideDialogue += () => //als de dialogue gesloten is dan ben je weer vrij om te lopen (freeRoam)
            {
                if (state == GameState.Dialogue) 
                    state = GameState.FreeRoam;
            };
        }
    }
    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialogue)
        {
            DialogueManager.Instance.HandleUpdate();
        }

        else if (state == GameState.Battle) { }

    }
}