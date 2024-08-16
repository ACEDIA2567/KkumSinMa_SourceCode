using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class TutorialTrigger : TutorialBase
{
    enum NpcPosition
    {
        equipment,
        character,
        portal,
        Store,
    }

    [SerializeField] private Player player;
    [SerializeField] private NpcPosition npcPosition;

    private Transform triggerObject;


    public bool isTrigger { set; get; } = false;

    public override void Enter()
    {
        Managers.Game.player.canMove = true;
        player = Managers.Game.player;

        switch(npcPosition)
        {
            case NpcPosition.Store:
                triggerObject = TutorialController.instance.npcs[(int)NpcPosition.Store]; break;
            case NpcPosition.equipment:
                triggerObject = TutorialController.instance.npcs[(int)NpcPosition.equipment]; break;
            case NpcPosition.character:
                triggerObject = TutorialController.instance.npcs[(int)NpcPosition.character]; break;
            case NpcPosition.portal:
                triggerObject = TutorialController.instance.npcs[(int)NpcPosition.portal]; break;
        }
    }

    public override void Execute(TutorialController controller)
    {
        // �浹 ����
        transform.position = player.transform.position;

        if (isTrigger)
        {
            controller.SetNextTutorial();
        }
    }

    public override void Exit()
    {
        // �÷��̾� �̵� �Ұ���
        Managers.Game.player.canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.Equals(triggerObject))
        {
            isTrigger = true;
        }
    }
}
