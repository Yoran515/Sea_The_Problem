using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTask : Task
{
    public float speed = 5f;
    public float maxX = 7f;
    public float minX = -7f;

    public bool TaskisActive;

    public GameObject MinigameBoat;
    void FixedUpdate()
    {
      
     
        if(TaskisActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");


            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;


            transform.position += movement;

            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        }
    }

  public override void Use()
    {
        if (!TaskisActive)
        {
            Debug.Log($"Activating {TaskName}");
            TaskisActive = true;
            if (MinigameBoat != null)
            {
                MinigameBoat.SetActive(true);
            }
        }
    }
}
