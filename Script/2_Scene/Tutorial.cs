using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : BaseScene
{
    AudioClips clips;

    protected override void Init()
    {
        base.Init();

        SceneType = SceneType.Tutorial;

        GameObject player = GameObject.Find("Player");

        player.GetOrAddComponent<Player>().Init();
        Managers.Game.player.AnimationEvents = Util.FindChild<PlayerAnimationEvents>(player, "UnitRoot", true);
        player.GetOrAddComponent<PlayerInputHandler>().Init();
        player.GetOrAddComponent<PlayerInteraction>().Init();
        player.GetOrAddComponent<BehaviourMove>().Init();
        player.GetOrAddComponent<BehaviourAttack>().Init();
    }

    private void Start()
    {

    }


    public override void Clear()
    {

    }
}
