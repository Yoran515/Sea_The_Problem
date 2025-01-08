using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] private List<Wave> waves = new List<Wave>();
    [SerializeField] Transform playerPos;
    private int currentWave = 0;

    void FixedUpdate()
    {
        WaveHandler();
        WaveInteractor();
    }

    void WaveInteractor()
    {   
        foreach (Task task in waves[currentWave].tasks)
        {
            float distance = Vector3.Distance(playerPos.position, task.Position);
            if (!task.IsCompleted)
            {
                if (distance <= task.Range)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        task.Use();

                    }
                }
            }

        }
    }

    void WaveHandler()
    {
        if (currentWave < waves.Count)
        {
            bool allTasksCompleted = true;

            // Access the tasks list inside the current wave
            foreach (Task task in waves[currentWave].tasks)
            {
                if (!task.IsCompleted)
                {
                    allTasksCompleted = false;
                    break;
                }
                
            }

            if (allTasksCompleted)
            {
                currentWave++;
                Debug.Log("Wave " + currentWave + " completed!");
            }
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
}

[System.Serializable]
public class Wave
{
    public List<Task> tasks = new List<Task>();
}
