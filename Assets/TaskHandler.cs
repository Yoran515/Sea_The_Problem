using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{

    [SerializeField] private List<Task> tasks = new List<Task>();

    [SerializeField] private List<List<Task>> waves = new List<List<Task>>();

    private int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        WaveHandler();
    }

    void WaveHandler()
    {
        if (currentWave < waves.Count)
        {
            bool allTasksCompleted = true;
            foreach (Task task in waves[currentWave])
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
                Debug.Log("Wave " + (currentWave) + " completed!");
            }
        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }
    void CheckTaskStatus()
    {

    }
}
