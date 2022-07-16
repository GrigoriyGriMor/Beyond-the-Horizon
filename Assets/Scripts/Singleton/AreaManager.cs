using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    private static AreaManager instance;
    public static AreaManager Instance => instance;
    [SerializeField]
    private PlayerController playerController;
    public TargetQuest[] targetQuests;
    [HideInInspector]
    public TargetManager targetManager;
    [HideInInspector]
    public QuestManager questManager;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!playerController) SetPlayerController(PlayerParameters.Instance.GetPlayerController());  //crutch
    }
    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        targetManager = playerController.GetComponent<TargetManager>();
        questManager = playerController.GetComponent<QuestManager>();
    }
}

[System.Serializable]
public class TargetQuest
{
    public int ID;
    public StepTarget[] stepTargets;
}

[System.Serializable]
public class StepTarget
{
    public ActionTarget[] actionTargets;
}

[System.Serializable]
public class ActionTarget
{
    public Transform actionTarget;
}
