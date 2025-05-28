using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad : MonoBehaviour
{
    //Start is called before the first frame update
    public float scrollingspeed;
    public bool scrolling;
    Material backaroundMaterial:
    public int[] myintArray;
    private void Awake(){
        backaroundMaterial = GetComponent<Renderer>().material;
    }
    void Start()
    {

        Debug.Log("it worked");
        myArray();


    }
    private void FixedUpdate(){
        if(scrolling){
            Vector2 offset =new Vector2(scrollingspeed * Time.time,0);
            backaroundMaterial.mainTextureOffset;
        }
    }

    // update is called onec per frame
    void update()
    {

    }
    void myArray(){
        myintArray ={1,2,3,4,5};
        for(int index = 0; index<myintArray.Length;index++){
            Debug.log(myintArray[index]);

        }

    }
}