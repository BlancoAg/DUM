using UnityEngine;

public class Wind : MonoBehaviour
{
    public GameObject player;
    public GameObject stoneCard;
    private PlayerMainScript pms;
    private StoneStance stoneSt;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {  
            pms = player.GetComponent<PlayerMainScript>();
            stoneSt = stoneCard.GetComponent<StoneStance>();

            if(!stoneSt.stoned && pms != null)
            {
                pms.StartWind();
            }
        }
    }
}