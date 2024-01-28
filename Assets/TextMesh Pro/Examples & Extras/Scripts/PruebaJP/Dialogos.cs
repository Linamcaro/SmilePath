using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI dialoguetext;
    public string[] lines;
    public float textspeed = 0.2f;
    int indexe = 0;

    GameObject creditos;

    private void Start()
    {
        dialoguetext.text  = string.Empty;
        StartDialog();

        if (SceneManager.GetActiveScene().name == "DialogosFinal")
        {
            creditos = GameObject.Find("Creditos");
            creditos.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (dialoguetext.text== lines[indexe])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialoguetext.text = lines[indexe];
            }
        }
    }
    public void StartDialog()
    {
        indexe = 0;
        StartCoroutine(Writeline());
    }

    IEnumerator Writeline()
    {
        foreach (var letter in lines[indexe].ToCharArray())
        {
            dialoguetext.text += letter;
            yield return new WaitForSeconds(textspeed); 
        }
    }
    public void NextLine()
    {
      
        if (indexe < lines.Length - 1)
        {
            indexe++;
            dialoguetext.text = string.Empty;
            StartCoroutine(Writeline());
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("entré");
            if(SceneManager.GetActiveScene().name == "DialogosFinal")
            {
                var dialogCanvas = GameObject.Find("Canvas");

                dialogCanvas.SetActive(false);
                creditos.SetActive(true);
            }
            else
            {
                GameManager.Instance.ChangeScene(2, true);
            }
        }
    }

    public void GoBackToMenuButton()
    {
        GameManager.Instance.ChangeScene(0, true);
    }
}
