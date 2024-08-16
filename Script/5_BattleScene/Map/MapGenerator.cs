using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus.Components;
using UnityEditor;
using Unity.VisualScripting;

public class MapGenerator : MonoBehaviour
{
    List<GameObject> maps = new List<GameObject>();
    GameObject map;
    public static MapGenerator instance;
    [SerializeField] GameObject navMesh;
    int souls = 0;

    int selectNum = -1;
    int currentNum = -1;
    public int stageNum = 0; // 현재 진행 중인 스테이지

    private UI_Result ui_Result;
    private UI_Boss ui_Boss;

    // battle ui에서 사용
    [HideInInspector]
    public int count;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Start()
    {
        MapBuild();
    }

    public void SetInfo(GameObject go)
    {
        navMesh = go;
    }

    public void Init()
    {
        MapBuild();
    }

    public Transform GetMapPortal()
    {
        return maps[stageNum].GetComponentInChildren<EntrancePortal>().transform;
    }

    public void MapBuild()
    {
        //int count = Random.Range(3, 5);
        count = Random.Range(3, 5);

        for (int i = 0; i < count; i++)
        {
            while (true)
            {
                selectNum = Random.Range(1, 4);

                if (selectNum != currentNum)
                {
                    map = Instantiate(Resources.Load<GameObject>($"Map/Map{selectNum}"), transform.position + new Vector3(i * 150, 0, 0), Quaternion.identity);
                    maps.Add(map);

                    currentNum = selectNum;
                    break;
                }
            }
        }
        Updates();

        Managers.UI.ShowSceneUI<UI_Battle>(); // 배틀맵 UI 생성

        StartCoroutine(DelayBuild());
    }

    IEnumerator DelayBuild()
    {
        navMesh.GetComponent<NavMeshBuild>().enabled = true;
        yield return null;
    }

    void Updates()
    {
        for (int i = 0; i < maps.Count; i++)
        {
            if (i == maps.Count - 1)
            {
                GameObject bossMap = Instantiate(Resources.Load<GameObject>($"Map/BossMap"), transform.position + new Vector3(0, 150, 0), Quaternion.identity);
                maps[i].transform.GetComponentInChildren<EntrancePortal>().GetEntrance(bossMap.transform.GetChild(0).transform);
            }
            else if (i == 0)
            {
                Managers.Game.player.gameObject.transform.position = maps[i].transform.GetChild(0).transform.position;
                maps[i].transform.GetComponentInChildren<EntrancePortal>().GetEntrance(maps[i + 1].transform.GetChild(0).transform);
            }
            else
            {
                maps[i].transform.GetComponentInChildren<EntrancePortal>().GetEntrance(maps[i + 1].transform.GetChild(0).transform);
            }
        }
    }

    public int GetSoul()
    {
        return souls;
    }

    public void GetUI(UI_Boss ui)
    {
        ui_Boss = ui;
    }

    public void AddSoul()
    {
        souls++;
    }

    public void Hit(float max, float min)
    {
        ui_Boss.UpdateFillAmount(max, min);
    }

    public void StageClear()
    {
        Managers.UI.ClosePopupUI(ui_Boss);
        Invoke("ActiveUI", 5.0f);
    }

    private void ActiveUI()
    {
        if (ui_Result != null) return;
        ui_Result = Managers.UI.ShowPopupUI<UI_Result>();
    }
}
