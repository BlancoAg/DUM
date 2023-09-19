using UnityEngine;

public class ComebackCard : MonoBehaviour, ICard
{
    public Vector3 savedPosition;
    public bool positionSaved = false;
    public GameObject ComeBackCardMark;

    public AudioClip clip;
    public AudioSource sauce;
    private bool ready;

    public void card_preparation(bool status)
    {
        //Debug.Log("estatus: " + status);
        if (!status)
        {
            //Debug.Log("despreparacion");
            ready = false;
            return; 
        }
        ready = status;
        //Debug.Log("Card "+ gameObject.name +" is ready");
        return; 
    }


    public void cast_card()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerMainScript>();
        if (positionSaved)
        {

            player.transform.position = savedPosition;
            sauce.PlayOneShot(clip);
            Destroy(GameObject.Find("ComeBackCardMark(Clone)"));
            positionSaved = false;
        }
        else
        {   
            savedPosition = player.transform.position;
            Vector3 pos = player.transform.position;
            Instantiate(ComeBackCardMark, pos + new Vector3(0,1,0) , Quaternion.identity);
            positionSaved = true;
        }
        ready = false;
    }
}
