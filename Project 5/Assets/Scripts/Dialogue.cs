using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;

    public string[] newlines;

    public float textspeed;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (textComponent.text == newlines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = newlines[index];
            }
        }
    }
    void StartDialogue(){
        newlines = new string[lines.Length + 1];
        lines.CopyTo(newlines, 0);
        newlines[lines.Length] = GetJoke();
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach (char c in newlines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine(){
        if (index < newlines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            gameObject.SetActive(false);
            index = 0;
            textComponent.text = newlines[index];
            newlines[lines.Length] = GetJoke();
        }
    }

    private string GetJoke(){
        string[] s = {
            "Seal you later!", 
            "Nice to seal you!", 
            "Seal ya!",
        };

        int sec = Random.Range(0, s.Length);
        string selection = s[sec];
        return selection;
    }
}
