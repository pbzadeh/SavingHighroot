using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    
    public TextMeshProUGUI textcomp;
    public string[] lines;
    public float textspeed;

    private int idx;
    // Start is called before the first frame update
    void Start()
    {
        textcomp.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textcomp.text == lines[idx]){
                nextline();
            }
            else{
                StopAllCoroutines();
                textcomp.text = lines[idx];
            }
            
        }

    }
    void StartDialogue(){
        idx = 0;
        StartCoroutine(typeline());
    }

    IEnumerator typeline(){
        foreach(char c in lines[idx].ToCharArray()){
            textcomp.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void nextline(){
        if(idx < lines.Length - 1){
            idx++;
            textcomp.text = string.Empty;
            StartCoroutine(typeline());
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
