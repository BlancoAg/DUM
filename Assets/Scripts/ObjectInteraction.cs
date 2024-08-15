using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    DialogueSystem dialoguesystem;
    QuestTrigger questTrigger;
    private List<string> dialogues;
    private PuppetController puppetCont;
    public PuppetController targetPuppet;

    private CameraLookAt look_at_script;
    public GameObject talkicon;
    public GameObject indicadorF;  // Indicador para objetos con Tag "NPC"
    public GameObject indicadorE;  // Indicador para objetos con Tag "Card" o "Activable"

    public float talk_distance;

    private void Start()
    {
        dialoguesystem = GetComponent<DialogueSystem>();
        puppetCont = GetComponent<PuppetController>();
        look_at_script = GetComponentInChildren<Camera>().GetComponent<CameraLookAt>();

        // Asegúrate de que los indicadores estén desactivados al inicio
        if (indicadorF != null) indicadorF.SetActive(false);
        if (indicadorE != null) indicadorE.SetActive(false);
    }

    private void Update()
    {
        CheckObjectTags();

        if (Input.GetMouseButtonDown(0))
        {
            Camera cameraComponent = GetComponentInChildren<Camera>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider != null && hit.collider.CompareTag("Activator"))
                {
                    hit.collider.gameObject.GetComponent<Activator>().Execute();
                }

                questTrigger = hit.collider.gameObject.GetComponent<QuestTrigger>();
                if (questTrigger != null)
                {
                    questTrigger.Trigger();
                }
            }
        }

        if (Input.GetKeyDown("f"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (dialoguesystem.talking)
            {
                dialoguesystem.skip();
            }

            if (Physics.Raycast(ray, out hit, talk_distance))
            {
                if (hit.collider != null && hit.collider.CompareTag("NPC"))
                {
                    if (dialoguesystem.endend)
                    {
                        look_at_script.start_looking(hit.transform, 0f);
                        dialogues = hit.collider.gameObject.GetComponent<DialogueSystem>().gestor_de_dialogo();
                    }

                    if (dialoguesystem.talking)
                    {
                        dialoguesystem.skip();
                    }
                    else if (dialoguesystem.endend)
                    {
                        GlobalVariables.character_talking = true;
                        dialoguesystem.Talk(dialogues);
                    }
                }
            }
        }
    }

    private void CheckObjectTags()
    {
        Camera cameraComponent = GetComponentInChildren<Camera>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3))
        {
            // Activar talkicon si se está viendo un NPC y no hay diálogo en curso
            if (talkicon != null)
            {
                talkicon.SetActive(hit.collider.CompareTag("NPC") && !GlobalVariables.character_talking);
            }

            // Activar indicadorF si está viendo un objeto con el Tag "NPC"
            if (indicadorF != null)
            {
                indicadorF.SetActive(hit.collider.CompareTag("NPC"));
            }

            // Activar indicadorE si está viendo un objeto con el Tag "Card" o "Activable"
            if (indicadorE != null)
            {
                bool isCardOrActivable = hit.collider.CompareTag("Card") || hit.collider.CompareTag("Activable");
                indicadorE.SetActive(isCardOrActivable);
            }
        }
        else
        {
            // Desactivar todos los indicadores si no se está viendo ningún objeto relevante
            if (talkicon != null) talkicon.SetActive(false);
            if (indicadorF != null) indicadorF.SetActive(false);
            if (indicadorE != null) indicadorE.SetActive(false);
        }
    }
}
