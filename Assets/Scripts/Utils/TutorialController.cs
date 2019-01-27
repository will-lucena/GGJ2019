using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<GameObject> checkpoints;

    private GameObject lastCheckpoint;

    private void Start()
    {
        player.notifyCheckpoint += showHud;
    }

    private void showHud(string checkpointName)
    {
        GameObject result = checkpoints.Find(item => item.name == checkpointName);

        if (lastCheckpoint && lastCheckpoint != result)
        {
            lastCheckpoint.SetActive(false);
        }

        if (result)
        {
            result.transform.GetChild(0).gameObject.SetActive(true);
            lastCheckpoint = result;
            Debug.Log(result.name);
        }
    }
}
