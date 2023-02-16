using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Rotation : MonoBehaviour
{
    public float i = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.rotation = new Vector3(0,i,0);

        i = i + 0.1f;       
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, i , transform.rotation.eulerAngles.z);

        if(i == 360f){  
            i = 0;
        }
    }
}
