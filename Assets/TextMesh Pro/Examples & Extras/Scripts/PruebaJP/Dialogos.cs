using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI dialoguetext;
    public string[] lines;
    public float textspeed = 0.2f;
    int indexe = 0;
    private void Start()
    {
        dialoguetext.text  = string.Empty;
        StartDialog();
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
            GameManager.Instance.ChangeScene(2, true);
        }
    }
}
