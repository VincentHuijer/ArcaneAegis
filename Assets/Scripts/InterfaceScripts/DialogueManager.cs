using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;
    [SerializeField] int lettersPerSecond;

    public event Action onShowDialogue;
    public event Action onHideDialogue;

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialogue dialogue;
    int currentLine = 0;
    bool isTyping; 
    

    public IEnumerator ShowDialogue(Dialogue dialogue)
    {
        yield return new WaitForEndOfFrame();
        onShowDialogue?.Invoke();
        this.dialogue = dialogue; //hierdoor kan je het dus als een variabele gebruiken.
        dialogueBox.SetActive(true);
        StartCoroutine(TypeDialogue(dialogue.Lines[0]));
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isTyping) //if ik mijn dialogue al heb gestart, en ik druk de linkermuisknop (interact knop)
        {
            ++currentLine; //voeg ik een nummer aan dit variabele
            if (currentLine < dialogue.Lines.Count) //als dit minder is dan het totaal aantal lines....
            {
                StartCoroutine(TypeDialogue(dialogue.Lines[currentLine])); //...toon de volgende line. tot het einde.
            }
            else
            {
                dialogueBox.SetActive(false); //als het af is gaat de dialoguebox uit.
                currentLine = 0; // TODO: Zet de dialogue op 0 zodat je het opnieuw kan afspelen. Kan problemen oplopen als een dialogue niet op 0 moet beginnen.
                onHideDialogue?.Invoke(); //vertel het systeem om het de verstoppen.
            }
        }
    }
    public IEnumerator TypeDialogue(string line)
    {
        isTyping = true;
        dialogueText.text = ""; //eerst wordt het op 0 gezet
        foreach (var letter in line.ToCharArray()) //vervolgens voor iedere letter wordt het op het scherm getoond.
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }
}
