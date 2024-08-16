using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrancePortal : MonoBehaviour
{
    [SerializeField] Transform entrance;

    public void GetEntrance(Transform transform)
    {
        entrance = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = entrance.position;
            collision.gameObject.GetComponent<BehaviourPotion>().PotionCount = 3;
            Managers.UI.FindUI<UI_Player>().UpdatePotionCount();
            MapGenerator.instance.stageNum++;
        }
    }
}
