using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class TutorialDestroyTagObjects : TutorialBase
{
    [SerializeField] private GameObject monster;

    [SerializeField] private List<GameObject> objects;

    private bool isDead = false;

    public override void Enter()
    {
        Managers.Scene.CurrentScene.SceneType = SceneType.BattleScene;

        Managers.Game.player.canMove = true;
        Managers.Game.player.canAttack = true;
        Managers.Game.player.useSkill = true;

        // �ı��ؾ��� ������Ʈ���� Ȱ��ȭ
        monster.SetActive(true);
        objects.Add(monster);
    }

    public override void Execute(TutorialController controller)
    {
        if(monster.GetComponentInChildren<Enemy>().status.health == 0)
        {
            Invoke("Dead", 2f);
        }

        if (objects.Count == 0)
        {
            controller.SetNextTutorial();
        }
    }

    public void Dead()
    {
        objects.Clear();
        monster.SetActive(false);
    }

    public override void Exit()
    {

    }
}
