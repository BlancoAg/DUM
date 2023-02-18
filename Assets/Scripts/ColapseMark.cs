using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColapseMark : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale , new Vector3 (0,0,0) , Time.deltaTime * speed);
        
    }

    public void colapse(){
    }
}
