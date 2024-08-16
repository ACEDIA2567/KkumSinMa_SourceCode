using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TutorialCamChange : TutorialBase
{
    enum CurrentCam
    {
        Player,
        Merchant,
        Anvil,
        Digger,
        Portal,
    }

    enum ChangeCam
    {
        Player,
        Merchant,
        Anvil,
        Digger,
        Portal,
    }

    [SerializeField]
    CurrentCam current;
    [SerializeField]
    ChangeCam change;

    private CinemachineVirtualCamera currentCam;
    private CinemachineVirtualCamera changeCam;


    public override void Enter()
    {
        switch (current)
        {
            case CurrentCam.Player:
                currentCam = TutorialController.instance.playerCam; break;
            case CurrentCam.Merchant:
                currentCam = TutorialController.instance.virtualCams[3]; break;
            case CurrentCam.Anvil:
                currentCam = TutorialController.instance.virtualCams[0]; break;
            case CurrentCam.Portal:
                currentCam = TutorialController.instance.virtualCams[2]; break;
            case CurrentCam.Digger:
                currentCam = TutorialController.instance.virtualCams[1]; break;
        }

        switch (change)
        {
            case ChangeCam.Player:
                changeCam = TutorialController.instance.playerCam; break;
            case ChangeCam.Merchant:
                changeCam = TutorialController.instance.virtualCams[3]; break;
            case ChangeCam.Anvil:
                changeCam = TutorialController.instance.virtualCams[0]; break;
            case ChangeCam.Portal:
                changeCam = TutorialController.instance.virtualCams[2]; break;
            case ChangeCam.Digger:
                changeCam = TutorialController.instance.virtualCams[1]; break;
        }
    }

    public override void Execute(TutorialController controller)
    {
        if (ActiveCam())
        {
            controller.SetNextTutorial();
        }
    }

    private bool ActiveCam()
    {
        changeCam.gameObject.SetActive(true);
        currentCam.gameObject.SetActive(false);

        return true;
    }

    public override void Exit()
    {

    }
}
