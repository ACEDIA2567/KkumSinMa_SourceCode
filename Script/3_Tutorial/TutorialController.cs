using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public static TutorialController instance;

    [SerializeField]
    private List<TutorialBase> tutorials;

    private Player player;

    private TutorialBase currentTutorial = null;
    private int currentIndex = -1;
    private bool isCompleted = false;

    [HideInInspector] public Stack<GameObject> uis = new Stack<GameObject>();
    [HideInInspector] public UI_Player_Tutorial uI_Player;

    // cams
    [HideInInspector] public CinemachineVirtualCamera[] virtualCams;
    [HideInInspector] public CinemachineVirtualCamera playerCam;

    // transform
    [HideInInspector] public Transform[] npcs;

    private void Awake()
    {
        instance = this;

        player = Managers.Game.player;
        virtualCams = new CinemachineVirtualCamera[4];
        playerCam = player.GetComponentInChildren<CinemachineVirtualCamera>();
        npcs = new Transform[4];
    }

    private void Start()
    {
        SetNextTutorial();
    }

    private void Update()
    {
        if (currentTutorial != null)
        {
            currentTutorial.Execute(this);
        }
    }

    public void SetNextTutorial()
    {
        // ���� Ʃ�丮���� Exit() �޼ҵ� ȣ��
        if( currentTutorial != null )
        {
            currentTutorial.Exit();
        }

        // ������ Ʃ�丮���� �����ߴٸ� CompletedAllTutorials() �޼ҵ� ȣ��
        if ( currentIndex >= tutorials.Count -1)
        {
            CompletedAllTutorials();
            return;
        }

        // ���� Ʃ�丮�� ������ currentTutorial�� ���
        currentIndex++;
        currentTutorial = tutorials[currentIndex];

        // ���� �ٲ� Ʃ�丮���� Enter() �޼ҵ� ȣ��
        currentTutorial.Enter();
    }

    private void CompletedAllTutorials()
    {
        currentTutorial = null ;

        // �ʵ忡 ���ʿ��� ������Ʈ ����
        Poolable[] poolObjs = FindObjectsOfType<Poolable>();
        for (int i = 0; i < poolObjs.Length; i++)
        {
            Destroy(poolObjs[i].gameObject);
        }

        // Ʃ�丮�� �Ϸ� �� Ʃ�丮�� ���ӿ�����Ʈ ����
        DestroyTutorial();
    }

    public void SaveCompleteState()
    {
        isCompleted = true;
        PlayerPrefs.SetInt("TutorialComplete", System.Convert.ToInt16(isCompleted));
    }

    public void DestroyTutorial()
    {
        SaveCompleteState();
        // �÷��̾� ��ġ �ʱ�ȭ
        player.transform.position = new Vector2(0, 0);

        Destroy(gameObject.transform.parent.gameObject);
    }
}
