using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    
    [SerializeField] private float waterLevel = -1;
    void Start()
    {     
    }

    // Update is called once per frame
    void Update()
    {
        print(transform.position.y);
        if(transform.position.y > waterLevel){
            Destroy(gameObject);   
        }
        transform.position = new Vector2(transform.position.x,transform.position.y + 0.05f);
    }
}
