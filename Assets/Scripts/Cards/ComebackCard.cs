using UnityEngine;

public class ComebackCard : MonoBehaviour, ICard
{
    public Vector3 savedPosition;
    public bool positionSaved = false;


    private bool ready;

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
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if (positionSaved)
        {
            player.transform.position = savedPosition;
            positionSaved = false;
        }
        else
        {
            savedPosition = player.transform.position;
            positionSaved = true;
        }
        ready = false;
    }
}
