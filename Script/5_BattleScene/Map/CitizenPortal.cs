using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenPortal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CitizenMovement>(out CitizenMovement movement))
        {
            if (collision.transform.root.gameObject.TryGetComponent<NormalMapManager>(out NormalMapManager normalMapManager))
            {
                normalMapManager.SubtractCount();
            }
            Managers.Pool.Push(collision.transform.parent.gameObject);
        }
    }
}
