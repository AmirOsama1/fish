using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Fish AI
public class AI : MonoBehaviour
{
    public float moveSpeed=7f;
    public float WaitTime=3f;
      public float rotationSpeed = 5f;
    Vector2 Range;
    // Start is called before the first frame update
    void Start()
    {
             Range = new Vector3 (Random.Range(-35,18),Random.Range(-20,9));   

     InvokeRepeating("wait",WaitTime,WaitTime);
    }

    // Update is called once per frame
    void Update()
    {
           RotateTowardsTarget();
        
           transform.position = Vector2.MoveTowards(transform.position, Range, moveSpeed * Time.deltaTime);
  }
   void RotateTowardsTarget()
    {
        RotateTowards(Range);
    }

    void RotateTowards(Vector2 target)
    {
        Vector2 direction = target - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
  void wait(){
     Range = new Vector3 (Random.Range(-35,18),Random.Range(-20,9));   
  }
}
