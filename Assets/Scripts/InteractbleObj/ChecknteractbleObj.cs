using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// проверка interactbleObjectController висит на плеере
/// </summary>
/// 
public class ChecknteractbleObj : MonoBehaviour
{
    Transform thisTransform;
    RaycastHit hit;

    [SerializeField]
    PlayerController playerController;

    [Header("Мах расстояние до обьекта")]
    [SerializeField]
    private float maxDistationInteractbleObj = 1.0f;

    private int currentIdObject;

    private int lastCurrentObject;

    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        CheckObj();
    }

    private void CheckObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.TryGetComponent<InteractbleObjectController>(out InteractbleObjectController interactbleObjectController))
            {
                float dist = Vector3.Distance(thisTransform.position, hit.transform.position);

                if (dist < maxDistationInteractbleObj)
                {
                    currentIdObject = interactbleObjectController.GetInstanceID();
                    if (lastCurrentObject != currentIdObject)
                        CanUseObject(interactbleObjectController);

                    lastCurrentObject = currentIdObject;
                }
                else
                {
                    currentIdObject = 0;
                    lastCurrentObject = currentIdObject;
                    OutUseObject();
                }
            }
            else
            {
                currentIdObject = 0;
                lastCurrentObject = currentIdObject;
                OutUseObject();
            }
        }
    }

    private void CanUseObject(InteractbleObjectController interactbleObjectController)
    {
        playerController.CanUseObject(interactbleObjectController.Get_name(), interactbleObjectController.Get_event().ToString(), interactbleObjectController);
    }

    private void OutUseObject()
    {
        playerController.OutUseObject();
    }
}
