using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum mapObject
{
    escapePortal,
    nextPortal
}

public class NormalMapManager : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private GameObject nextDoor;
    [SerializeField] private GameObject escapePortal;
    [SerializeField] private GameObject nextPortal;

    public void AddCount()
    {
        count++;
    }

    public void SubtractCount()
    {
        count--;
        if (count == 0)
        {
            nextDoor.SetActive(false);
            Managers.UI.FindUI<UI_Battle>().SetClear();
            Managers.UI.ShowPopupUI<UI_StageClear>();
        }
    }

    public Vector3 GetPos(mapObject mapEnum)
    {
        switch (mapEnum)
        {
            case mapObject.escapePortal:
                return escapePortal.transform.position;
            case mapObject.nextPortal:
                return nextPortal.transform.position;
            default:
                return Vector3.zero;
        }
    }
}
