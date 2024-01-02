using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Instantiate Objects
public class Insta : MonoBehaviour
{
    public Transform[] Pos;
    public GameObject[] Objects;
   public static int Number_Small_Objects;
       public static int Number_Middle_Objects;
   public static int Number_Large_Objects;
     int RandomPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (Number_Small_Objects<7){
RandomPos = Random.Range(0,Pos.Length);
            Instantiate(Objects[0],Pos[RandomPos].position,Pos[RandomPos].rotation);
            Number_Small_Objects++;
        }

                while (Number_Middle_Objects<3){
RandomPos = Random.Range(0,Pos.Length);
            Instantiate(Objects[1],Pos[RandomPos].position,Pos[RandomPos].rotation);
            Number_Middle_Objects++;
        }   
        
        
             while (Number_Large_Objects<2){
RandomPos = Random.Range(0,Pos.Length);
            Instantiate(Objects[2],Pos[RandomPos].position,Pos[RandomPos].rotation);
            Number_Large_Objects++;
        }
    }
}
