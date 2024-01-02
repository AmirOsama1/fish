using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDes : MonoBehaviour
{
   public int index; //To check if StateOfGameObject Large,small,Middle
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This Function use to say what u want to do after Destroy object
    private void OnDestroy() {
        if( index ==0){
            Insta. Number_Small_Objects --;
        }
        if( index ==1){
            Insta. Number_Middle_Objects --;
        }if( index ==2){
            Insta. Number_Large_Objects --;
        }
    }
}
