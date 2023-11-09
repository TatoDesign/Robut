using System.Collections;
using UnityEngine;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialoguesLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private AudioClip beepSound;  // Agrega un campo para el sonido "beep"
    public AudioSource audioSource;  // Componente AudioSource
    public static bool robutCanCome = false;
    public static bool playerCanMove = false;
    public bool viene = false;
    public float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            if (!didDialogueStart)
            {
                startDialogue1();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (dialogueText.text == dialoguesLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialoguesLines[lineIndex];
                }
            }
        }

        viene = robutCanCome;

        // Robut
        if (Input.GetKeyDown(KeyCode.O))
        {
            robutCanCome = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            robutCanCome = false;
        }

        // Player move
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerCanMove = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerCanMove = false;
        }
    }

    private void startDialogue1()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialoguesLines[lineIndex])
        {
            dialogueText.text += ch;
            audioSource.PlayOneShot(beepSound);  // Reproduce el sonido de "beep"
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialoguesLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            robutCanCome = true;
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            StatesMachineScript.StatesMachine += 1;
            Destroy(gameObject);
        }
    }
}
