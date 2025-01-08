using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceberg : MonoBehaviour
{
    public GameObject mountain; 
    public float spawnInterval = 0f;
    public float movementSpeed = 3f; 
    public float spawnXRange = 8f; 
    public float destroyYPosition = -6f;
    public Transform Leftside;
    public Transform Rightside;
    public bool Left;
    public bool Right;
    public int Chance;
    public Rigidbody2D rb;
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.down * movementSpeed * Time.fixedDeltaTime);
 /*       mountain.transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);*/
        spawnInterval += Time.deltaTime;
        if(spawnInterval >= 2f) 
        {
            if(Chance == 0)
            {
                Chance = Random.Range(1, 3);
            }
            spawnInterval = 0;
        }

      

        if (Chance == 1) 
        { 
            mountain.transform.position = Leftside.transform.position;
            Instantiate(mountain);
            Left = true ;
            Right = false ;
            Chance = 0;
        }
        if (Chance == 2)
        {
            mountain.transform.position = Rightside.transform.position;
            Instantiate(mountain);
            Left = false;
            Right = true;
            Chance = 0;
        }

      

    }
}
