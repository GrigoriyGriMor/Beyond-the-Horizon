using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorQuestTrigger : ActivatorQuestBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out QuestManager questManager))
        {
            SetQuestPlayer(questManager);
        }
        else
        {
            print(" Not QuestManager");
        }
    }
}
