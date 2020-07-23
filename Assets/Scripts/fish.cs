using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    
    [SerializeField]private GameObject bubble;
    private float speed = 0.03f;
    private float time = 1f;
    [SerializeField]private float boundaryLeft = -5f;
    [SerializeField]private float boundaryRight = 5f;
    [SerializeField]private bool startFromLeft = true;

    private string changLoopString = "changeLoop";
    private string createBubbleString = "createBubble";
    void Start()
    {
        time = Random.Range(1f, 3.0f);
        StartCoroutine(createBubbleString);
        StartCoroutine(changLoopString);
        if (!startFromLeft){
            changeDirection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed,transform.position.y);
        checkBoundary();
    }

    IEnumerator changeLoop(){
        time = Random.Range(1f, 3.0f);
        yield return new WaitForSeconds(time);
        changeDirection();
        StartCoroutine(changLoopString);
    }

    IEnumerator createBubble(){
        yield return new WaitForSeconds(time);
        Instantiate(bubble, transform.position, Quaternion.identity);
        StartCoroutine(createBubbleString);
    }

    void changeDirection(){
        transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        speed = -speed;
    }

    void checkBoundary(){
        if(transform.position.x < boundaryLeft || transform.position.x > boundaryRight ){
            StopCoroutine(changLoopString);
            changeDirection();
            StartCoroutine(changLoopString);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "bait"){return;}
        print(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        StopCoroutine(changLoopString);
        StopCoroutine(createBubbleString);
        speed = 0;
        gameObject.transform.parent = col.gameObject.transform;
        col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
