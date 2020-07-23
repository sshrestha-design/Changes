using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingLine : MonoBehaviour
{

    [SerializeField]private GameObject bait;
    private LineRenderer lineRenderer;
    [SerializeField]private Vector3 start = new Vector3(0,0,0);
    [SerializeField]private Vector3 end = new Vector3(0,-1.0f,0);
    // Start is called before the first frame update
    [SerializeField]private float lineSpeed = 0.03f;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; 

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(0,end);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            if (end.y > -6){
                end.y -= lineSpeed;
            }
            print(end);
        }  

        if(Input.GetKey(KeyCode.X))
        {
            if (end.y < -1){
                end.y += lineSpeed;
            }else{
                bait.GetComponent<BoxCollider2D>().enabled = true;
                foreach (Transform child in bait.transform) {
                        Destroy(child.gameObject);
                }
            }

            print(end);
        }   

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(0,end);
        bait.transform.position = end;
    }
}
