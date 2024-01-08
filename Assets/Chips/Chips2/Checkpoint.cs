
using System.Collections.Generic;
using System;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public static List<Vector3> collectedCheckpointPositions = new List<Vector3>();
    private bool shouldResetCheckpoints = false;
    public static Checkpoint instance;
    private void Awake()
    {
        instance = this;
       

        if (!shouldResetCheckpoints)
        {
            LoadCheckpoints();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsCheckpointCollected(transform.position))
            {
                collectedCheckpointPositions.Add(transform.position);
                SaveCheckpoints();
            }
        }
    }

    public static void TeleportToLastCheckpoint(Transform playerTransform)
    {
        if (collectedCheckpointPositions.Count > 0)
        {
            playerTransform.position = collectedCheckpointPositions[collectedCheckpointPositions.Count - 1];
        }
    }

    bool IsCheckpointCollected(Vector3 checkpointPosition)
    {
        return collectedCheckpointPositions.Contains(checkpointPosition);
    }

    void SaveCheckpoints()
    {
        PlayerPrefs.SetInt("CheckpointCount", collectedCheckpointPositions.Count);
        
        for (int i = 0; i < collectedCheckpointPositions.Count; i++)
        {
            PlayerPrefs.SetFloat("CheckpointPosX_" + i, collectedCheckpointPositions[i].x);
            PlayerPrefs.SetFloat("CheckpointPosY_" + i, collectedCheckpointPositions[i].y);
            PlayerPrefs.SetFloat("CheckpointPosZ_" + i, collectedCheckpointPositions[i].z);
        }
        
        PlayerPrefs.Save();
    }

    void LoadCheckpoints()
    {
        int count = PlayerPrefs.GetInt("CheckpointCount", 0);
        collectedCheckpointPositions.Clear();
       
        for (int i = 0; i < count; i++)
        {
            float posX = PlayerPrefs.GetFloat("CheckpointPosX_" + i, 0);
            float posY = PlayerPrefs.GetFloat("CheckpointPosY_" + i, 0);
            float posZ = PlayerPrefs.GetFloat("CheckpointPosZ_" + i, 0);
            
            collectedCheckpointPositions.Add(new Vector3(posX, posY, posZ));
        }
    }

    public void ResetCheckpoints()
    {
        shouldResetCheckpoints = true;
        collectedCheckpointPositions.Clear();
        PlayerPrefs.DeleteKey("CheckpointCount");
        PlayerPrefs.Save();
    }
}