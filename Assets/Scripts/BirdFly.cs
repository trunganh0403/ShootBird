using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float speedFly = 1f;
    bool isRight;
    Vector3 isScale;
    void Start()
    {
        isScale = transform.localScale;
        DirPly();
    }

    // Update is called once per frame
    void Update()
    {
       Fly();
        
        
    }
    
    public void Fly()
    {
        if (isRight )
        {
            if(isScale.x >0) 
            {
                isScale.x = -1.5f;
                transform.localScale = isScale;
            }    
            transform.position =  Vector3.MoveTowards(transform.position, Vector3.left*20, speedFly*Time.deltaTime);
        }  
        else
        {
            if (isScale.x <0)
            {
                isScale.x = -1.5f;
                transform.localScale = isScale;
            }

            transform.position =  Vector3.MoveTowards(transform.position, Vector3.right*20, speedFly*Time.deltaTime);
        }    
      
    }    
    public void DirPly()
    {
        if (transform.position.x >=0) 
        { 
            isRight = true;
        }
        else
        {
            isRight= false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }
    }
}
