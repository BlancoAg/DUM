using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    void card_preparation(bool status, GameObject handgameObject);
    void cast_card(GameObject handGameObject);
    
    string tell_description();
}

