using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ALL_IN_ONE : MonoBehaviour
{
    public float range = 2f;
    public float moveSpeed = 5f;
    AudioSource Source;
  public  AudioClip clip;

    private const string SmallTag = "small";
    private const string MiddleTag = "middle";
    private const string LargeTag = "large";
    bool small = true;
    bool middle = false;
    bool large=false;
    

    public Image image ;
    private float Mana;
    


    void Start()
    {
        Mana=0;
        Source=GetComponent<AudioSource>();
        
    }

    void Update()
    {
        Source.clip=clip;
        if(Mana>=100){
    SceneManager.LoadScene(0);

}
        image.fillAmount=Mana/100;

        if(Mana>=30){
            middle=true;
            transform.localScale =new Vector3(1.2f,1.2f,1.2f);
        }
        if(Mana>=65){
            large=true;
                        transform.localScale =new Vector3(2f,2f,2f);

        }
        MoveTowardsMouse();
        Attack();
    }

    void MoveTowardsMouse()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
       Vector3 direction = mousePosition - transform.position;
    float angle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
    Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    transform.rotation = rotation;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return new Vector3(worldMousePosition.x, worldMousePosition.y, 0f);
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag(SmallTag)&&small) 
            {
                Destroy(enemy.gameObject);
                Mana+=2f;
                Source.PlayOneShot(clip);
            }
            if (enemy.CompareTag(MiddleTag)&&middle) 
            {
                Destroy(enemy.gameObject);
                Mana+=5f;
                                Source.PlayOneShot(clip);

            }
              if (enemy.CompareTag(MiddleTag)&&!middle )
            {
                Destroy(gameObject);
                                Source.PlayOneShot(clip);

               
            }
            if (enemy.CompareTag(LargeTag)&&large )
            {
                Destroy(enemy.gameObject);
                Mana+=7f;
                                Source.PlayOneShot(clip);

            }
             if (enemy.CompareTag(LargeTag)&&!large )
            {
                Destroy(gameObject);
                                Source.PlayOneShot(clip);

               
            }
        }
    

    }
    private void OnDestroy() {
            SceneManager.LoadScene(0);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
