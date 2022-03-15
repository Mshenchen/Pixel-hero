using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    public bool isEnterd;
    [TextArea(1,3)]
    public string[] lines;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEnterd = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEnterd = false;
        }
    }
    private void Update()
    {
        if (isEnterd && Input.GetKeyDown(KeyCode.Space))
        {
            Dialogue.instance.ShowDialogue(lines);
        }
    }
}
