using UnityEngine;

public class ComebackCard : MonoBehaviour, ICard
{
    public Vector3 savedPosition;
    public bool positionSaved = false;

    public GameObject player;

    private CharacterController characterController;
    //private FirstPersonController firstPersonController;

    private bool ready;

    void Start()
    {
        player = GameObject.Find("Player");
        characterController = player.GetComponent<CharacterController>();
        //firstPersonController = player.GetComponent<FirstPersonController>();
    }

    public void card_preparation(bool status)
    {
        Debug.Log("estatus: " + status);
        if (!status)
        {
            Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }


    public void cast_card()
    {
        if (positionSaved)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = savedPosition;
            positionSaved = false;
            player.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            
            //player.GetComponent<FirstPersonController>().enabled = false;
            savedPosition = player.transform.position;
            
            //player.GetComponent<FirstPersonController>().enabled = true;
            positionSaved = true;
        }
        ready = false;
    }
}
