using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData

{
    public int cardCount;
    public Vector3 playerPosition;
    //public SerializableDictionary<string, bool> cardsCollected;
    public GameData() 
    {
        this.cardCount = 0;
        playerPosition = Vector3.zero;
        //cardsCollected = new SerializableDictionary<string, bool>();
    }

}