using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using System.Linq;


public class DialogueSystem : MonoBehaviour
{
    public int rowNumber;
    public int next_line_id; // Renamed from 'id'
    public int id; // Retained for the current dialogue ID
    private GameObject letters;
    private GameObject TextBox;
    private GameObject pressbuttonbutton;
    public GameObject interaction_indicator;
    public PlayerMovementTutorial movement;
    public string letter;
    private readonly List<string[]> data = new List<string[]>();

    // Tutorial
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

    private float real_sensibility;
    

private void Start()
{
    talking = false;
    waiting = false;
    endend = true;
    // Find a game object with the "Player" tag
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    //interaction_indicator = GameObject.Find("need_talk").gameObject;
    //interaction_indicator = gameObject.Find("need_talk").gameObject;
    // GameObject interaction_indicato = GameObject.Find("need_talk");

    if (player != null)
    {
        //Debug.Log("hay jugador");
        TextBox = player.transform.Find("Interfaz/DialogueBox").gameObject;
        //Debug.Log(TextBox);
        pressbuttonbutton = player.transform.Find("Interfaz/DialogueBox/pressbutton").gameObject;
        letters = TextBox.transform.Find("Text (TMP)").gameObject;
        textComponent = letters.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
    }
    else
    {
        //Debug.LogError("No game object with the 'Player' tag found.");
    }
}


    public void Talk(List<string> dialogue)
    {

        if (dialogue.Count > 1)
        {
            more_lines = true;
        }
        else
        {
            more_lines = false;
        }
        waiting_input = false;
        endend = false;
        talking = true;
        shown = false;
        index = 0;
        movement.enabled = false;
        original_speed = textSpeed;
        //Debug.Log(gameObject.name);
        TextBox.SetActive(true);
        letters.SetActive(true);
        //Debug.Log(interaction_indicator.name);
        //interaction_indicator.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(TypeLine(dialogue));
        
    }

    IEnumerator<WaitForSeconds> TypeLine(List<string> dialogue)
    {
        foreach (var word in dialogue)
        {
            if (word == dialogue[dialogue.Count - 1])
            {
                break;
            }
            lines[index] = word + "...";
            if (word.Length <= 0)
            {
                break;
            }
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
            pressbuttonbutton.SetActive(true);
            yield return new WaitForSeconds(1f);
            while (more_lines)
            {
                textSpeed = original_speed;
                if (Input.GetKey("f"))
                {
                    pressbuttonbutton.SetActive(false);
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

    public void next_line()
    {
        waiting = true;
    }

    public void skip()
    {
        if (!waiting_input)
        {
            textSpeed = 0f;
        }
    }

    public void end()
    {
        StopCoroutine("TypeLine");
        textSpeed = original_speed;
        movement.enabled = true;
        TextBox.SetActive(false);
        letters.SetActive(false);
        pressbuttonbutton.SetActive(false);
        textComponent.text = "";
        talking = false;
        waiting = false;
        endend = true;
    }

    public void _continue(int id)
    {
        // Assign the received id to next_line_id
        next_line_id = id;
    }

    public List<string> GetCellsInRow(int rowNumber)
    {
        TextAsset file = Resources.Load<TextAsset>("Dialogues");
        List<string> cells = new List<string>();

        using (StringReader reader = new StringReader(file.text))
        {
            string line;
            int lineNumber = 0;

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;

                if (lineNumber == rowNumber)
                {
                    cells = line.Split(',').Skip(1).ToList();
                    next_line_id = int.Parse(cells.Last());

                    rowNumber = 2;
                    return cells;
                }
            }
        }
        return cells;
    }

    public List<string> gestor_de_dialogo()
    {
        List<string> row = GetCellsInRow(next_line_id); // Use next_line_id
        return row;
    }

    public void need_interaction(){
        interaction_indicator.GetComponent<SpriteRenderer>().enabled = true;

    }
}
