using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New GameObjDataTest", menuName = "GameObjDataTest", order = 115)]

public class GameObjectDataTest : ScriptableObject
{
    public  ItemAndId[] soGameObjectData;
}


[System.Serializable]
public class ItemAndId
{
    public int ID;
    public ItemBaseParametrs itemBaseParametrs;
}
