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

            Debug.Log("this is input.x" + input.x);
            Debug.Log("this is input.y" + input.y);
            //if (input.x != 0) input.y = 0; //als ik naar links of rechts ga, dan wil ik dat mn input.y gelijk is aan 0 (stopt schuin lopen)
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position; //in deze variable kan je een positie opslaan.
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos)); //dit runned constant
            }
        }
    }
    IEnumerator Move(Vector3 targetPos) //opzoeken wat een IEnumerable is
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