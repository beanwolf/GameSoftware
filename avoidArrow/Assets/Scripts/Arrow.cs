using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;
//    int arrside = Random.Range(0, 4);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = speed * Time.deltaTime;
        //if (arrside == 0)
        //{
        //    transform.Translate(-yMove, 0, 0);
        //}
        //else if(arrside == 1)
        //{
        //    transform.Translate(0, 0, 0);
        //}
        transform.Translate(0, -yMove, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            
        }
    }
}
