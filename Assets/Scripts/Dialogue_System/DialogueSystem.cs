using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
public class DialogueSystem : MonoBehaviour
{
    public int id;
    private GameObject letters;
    private GameObject TextBox;
    public PlayerMovementTutorial movement;
    public string letter;
    //private GameObject interfaz;
    private readonly List<string[]> data = new List<string[]>();


    //tutorial 
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float original_speed;
    public bool talking;
    public bool waiting;
    public bool endend;
    public bool shown;
    public bool waiting_input;
    public bool more_lines;
    private int index;

    private void Start() {
        talking = false;
        waiting = false;
        endend = true;
        TextBox = transform.Find("Interfaz/DialogueBox").gameObject;
        letters = TextBox.transform.Find("Text (TMP)").gameObject;
        textComponent = letters.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        //Talk();
    }

    public void Talk(List<string> dialogue)
    {
        if(dialogue.Count>1){
            more_lines = true;
        }else{
            more_lines = false;
        }
        waiting_input = false;
        endend = false;
        talking = true;
        shown = false;
        index = 0;
        movement.enabled = false;
        original_speed = textSpeed;
        TextBox.SetActive(true);
        letters.SetActive(true);
        StartCoroutine(TypeLine(dialogue));

        // TextAsset csvFile = Resources.Load<TextAsset>("Dialogues"); // Assumes the file is named "Dialogues.csv"
        // StringReader reader = new StringReader(csvFile.text);
        // //Debug.Log(csvFile);
        // // Read data from the CSV file
        // while (reader.Peek() != -1)
        // {
        //     string line = reader.ReadLine();
        //     string[] values = line.Split(',');
        //     data.Add(values);
        // }
            

    }

    IEnumerator<WaitForSeconds> TypeLine(List<string> dialogue)
    {
    foreach (var word in dialogue)
    {
        lines[index] = word + "...";
        if(word.Length<=0){
            break;
        }
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
         while(more_lines && !Input.GetKeyDown("f")){
             textSpeed = original_speed;
             if(Input.GetKey("f")){
                break;
             }
             waiting_input = true;
            yield return new WaitForSeconds(0.1f);
            }
         waiting_input = false;
         
         textComponent.text = "";
    }       
            end();
            more_lines = false;
            waiting = true;
    }

    public void next_line(){
            waiting = true;
    }

    public void skip(){
        if(!waiting_input){
            textSpeed = 0f;
        }
    }
    public void end(){
            //StopCoroutine(TypeLine());
            textSpeed = original_speed;
            movement.enabled = true;
            TextBox.SetActive(false);
            letters.SetActive(false);
            textComponent.text = "";
            talking = false;
            waiting = false;
            endend = true;
    }

    }
