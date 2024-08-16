using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Maintenance : BaseScene
{
    private bool isTutorialCompleted = true;

    void Start()
    {
//        Init();
    }
    protected override void Init()
    {
        base.Init();
        SceneType = SceneType.MaintenanceScene;

        // Create Player
        GameObject player = Managers.Resource.Instantiate("Player");
       
        player.GetOrAddComponent<Player>().Init();
        player.GetOrAddComponent<PlayerInputHandler>().Init();
        player.GetOrAddComponent<PlayerInventory>().Init();
        Util.FindChild(player, "UnitRoot", true).GetOrAddComponent<PlayerAnimationEvents>().Init();
        player.GetOrAddComponent<PlayerInteraction>().Init();
        Managers.Resource.Load<Material>("SPUM/Materials/SpriteDiffuse").color = Color.white;

        player.GetOrAddComponent<BehaviourMove>().Init();
        player.GetOrAddComponent<BehaviourAttack>().Init();
        player.GetOrAddComponent<BehaviourSkill>().Init();
        player.GetOrAddComponent<BehaviourPotion>().Init();
        player.GetOrAddComponent<BehaviourInteract>().Init();

        if (!PlayerPrefs.HasKey("TutorialComplete"))
        {
            Managers.Resource.Instantiate("Tutorial");

            Managers.Game.player.canMove = false;
            Managers.Game.player.canAttack = false;
            Managers.Game.player.canHeal = false;
            Managers.Game.player.useSkill = false;

            isTutorialCompleted = false;
        }

        // UI 积己
        Managers.UI.ShowSceneUI<UI_Maintenance>();
        Managers.UI.ShowHUD<UI_HUD>();
        Managers.UI.ShowSceneUI<UI_Player>().Init();

        // 澜厩 免仿
        Managers.Sound.PlaySound(Managers.Sound.clipBGM[(int)BGMClip.Maintenance]);

        // NPC 积己
        InstantiateNPC();
        
        // Create Player
        InstantiatePlayer();
        Managers.Data.playerData.Load();

    }

    public override void Clear()
    {
    }

    void InstantiatePlayer()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj == null)
        {
            playerObj = Managers.Resource.Instantiate("Player", null, "");
        }
        playerObj.transform.position = Vector3.zero;
        // Player HP recover
        Managers.Game.player.StatHandler.GetStat<int>(StatSpecies.HP).value =
            Managers.Game.player.StatHandler.GetStat<int>(StatSpecies.MaxHP).value +
            Managers.Game.player.StatHandler.GetStat<int>(StatSpecies.plusHP).value;
    }


    /// <summary>
    /// npc 积己
    /// </summary>
    private void InstantiateNPC()
    {
        GameObject root = GameObject.Find("NPCs");
        if(root == null)
        {
            root = new GameObject { name = "NPCs" };
        }

        GameObject[] npcs = Resources.LoadAll<GameObject>("Prefabs/NPC");


        for (int i = 0; i < npcs.Length; i++)
        {
            GameObject obj = Instantiate(npcs[i]);
            obj.transform.parent = root.transform;

            CinemachineVirtualCamera cam = obj.GetComponentInChildren<CinemachineVirtualCamera>();
            cam.gameObject.SetActive(false);

            if (!isTutorialCompleted)
            {

                TutorialController.instance.npcs[i] = obj.transform;
                TutorialController.instance.virtualCams[i] = cam;
            }
        }
    }
}
