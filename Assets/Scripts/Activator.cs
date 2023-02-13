using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject target;

    public void Execute(){
        Debug.Log(target.name);
        IActivate currenttarget = target.GetComponent<IActivate>();
        Debug.Log(currenttarget);
        currenttarget.Active();
        //ICard currentCard = cardsInHand[currentCardIndex].GetComponent<ICard>();
    }

}
