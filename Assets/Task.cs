using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private string taskName;
    [SerializeField] private string description;
    [SerializeField] private Vector2 location;
    [SerializeField] private float range;
    [SerializeField] private bool isCompleted;

    public string TaskName => taskName;
    public string Description => description;
    public bool IsCompleted => isCompleted;

    public virtual void Use()
    {
        Debug.Log($"Task {taskName} is being used.");
    }

    public void Complete()
    {
        if (!isCompleted)
        {
            isCompleted = true;
            Debug.Log($"Task {taskName} has been completed.");
        }
        else
        {
            Debug.Log($"Task {taskName} is already completed.");
        }
    }

    public void Cancel()
    {
        if (!isCompleted)
        {
            Debug.Log($"Task {taskName} has been canceled.");
        }
        else
        {
            Debug.Log($"Task {taskName} is already completed and cannot be canceled.");
        }
    }

    public void CheckStatus(Vector2 playerPosition)
    {
        if (isCompleted)
        {
            Debug.Log($"Task {taskName} is already completed.");
        }
        else if (Vector2.Distance(playerPosition, location) <= range)
        {
            Debug.Log($"Task {taskName} is within range but not completed yet.");
        }
        else
        {
            Debug.Log($"Task {taskName} is out of range.");
        }
    }
}
