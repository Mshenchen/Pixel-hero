using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;
    public GameObject DialogueBox;
    [TextArea(1, 3)]
    public string[] dialogueLines;
    public Text dialogueText;
    private int currentLine;
    private bool isScrolling;
    public float textSpeed;
    public bool isShowDialogue;
    
    void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueBox.activeInHierarchy)
        {
            
            
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (isScrolling == false)
                    {
                        currentLine++;
                        if (currentLine < dialogueLines.Length)
                        {
                            //dialogueText.text = dialogueLines[currentLine];
                            StartCoroutine(ScrollingText());
                        }
                        else
                        {
                            DialogueBox.SetActive(false);
                            FindObjectOfType<PlayerMovement>().canMove = true;
                        }
                    }
                    
                }
            
            
        }
    }
    public void ShowDialogue(string[] _newLines)
    {
        if (isShowDialogue == true)
        {
            dialogueLines = _newLines;
            currentLine = 0;
            StartCoroutine(ScrollingText());
            //dialogueText.text = dialogueLines[currentLine];
            DialogueBox.SetActive(true);
            FindObjectOfType<PlayerMovement>().canMove = false;
        }
        
    }
    IEnumerator ScrollingText()
    {
        isScrolling = true;
        dialogueText.text = "";
        foreach(char letter in dialogueLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        isScrolling = false;
    }


}
