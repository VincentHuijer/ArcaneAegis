using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    public Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask interactableLayer;
    private void Awake() //Wanneer de script instance is geladen, wordt deze code afgespeeld.
    {
     animator = GetComponent<Animator>();     
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            
            //if (input.x != 0) input.y = 0; //als ik naar links of rechts ga, dan wil ik dat mn input.y gelijk is aan 0 (stopt schuin lopen)
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position; //in deze variable kan je een positie opslaan.
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos)); //dit runned constant
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Interact();
        }
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir; //Welke positie je ook bent. + waar je naar kijkt. = de interact positie om te kunnen interacten met NPCs of objecten.

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f); //Als je de game speelt en klikt met linker muisknop, zie je in de scene een rode streep met je line of sight voor interacties.


        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer); //hierin kijken we of we overlappen met de interactpositie en de interactable layer. .
        if (collider != null) //Als op het einde van de interactPos lijn, er een interactableLayer is, dan doe iets (interacten)
        {
            collider.GetComponent<Interactable>()?.Interact(); //we gebruiken de collider of iets overlapt, als het een interactable is(npc/challenger) run interact.
        } 
    }

    private bool isWalkable(Vector3 targetPos) //bekijkt of iets is waarop je kan lopen (background) of dat er een object is. Dan niet.
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null) //als de positie waar we heen willen lopen zou overlappen met een solid object dan is het lopen false.
        {
            return false;
        }

        return true;
    }

    public IEnumerator Move(Vector3 targetPos) //opzoeken wat een IEnumerable is
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            //als de targetPosition - de originele beweging, als er iets over blijft, dan ga ik iets doen. 
            //Epsilon is een kleine float value
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime); //deltaTime = interval in seconds from last to current frame
            //we pakken de originele positie, we bewegen naar de bestemde targetposition, met een snelheid movespeed
            yield return null; // Wait for the next frame
        }
        transform.position = targetPos;  // Ensure the player reaches exactly the target position

        isMoving = false;
    }
}