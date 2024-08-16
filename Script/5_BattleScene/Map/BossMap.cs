using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMap : MonoBehaviour
{
    BossSpawner spawn;
    bool spawnCheck = false;

    private void Awake()
    {
        spawn = GetComponentInChildren<BossSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && spawnCheck == false)
        {
            // 보스 ui 생성
            MapGenerator.instance.GetUI(Managers.UI.ShowPopupUI<UI_Boss>());

            spawn.SpawnStart();
            Managers.Sound.PlaySound(Managers.Sound.clipBGM[(int)BGMClip.Boss]);
            spawnCheck = true;
        }
    }
}
