using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlQuestTrigger : ControlQuestBase
{
    private void OnTriggerEnter(Collider other)
    {
        QuestManager questManager = other.transform.GetComponentInChildren<QuestManager>();

        if (questManager)
        {
            CheckQuestPlayer(questManager);
        }
    }
}
