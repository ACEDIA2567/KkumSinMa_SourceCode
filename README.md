# KkumSinMa_SourceCode

## 꿈신마 Git_Hub : https://github.com/dudgus818/SpartaFinal
## 소스코드: [다운로드](https://github.com/user-attachments/files/22098340/Scripts.zip)
## 소스코드(제가 작성한 코드만 모아둔 파일입니다.):[다운로드](https://github.com/user-attachments/files/22098319/KkumSinMa.zip)

<hr>

## 소스 코드 트리
📦Scripts    
 ┣ 📂0_Util ▶ 유틸     
 ┃ ┣ 📜AudioClips.cs    
 ┃ ┣ 📜Define.cs    
 ┃ ┣ 📜Extension.cs    
 ┃ ┣ 📜Interfaces.cs    
 ┃ ┣ 📜SceneChanger.cs    
 ┃ ┣ 📜UIBase.cs    
 ┃ ┗ 📜Util.cs    
 ┣ 📂1_Managers ▶ 게임 관리    
 ┃ ┣ 📜CameraManager.cs    
 ┃ ┣ 📜DataManager.cs    
 ┃ ┣ 📜GameManager.cs    
 ┃ ┣ 📜GuideArrow.cs    
 ┃ ┣ 📜ItemManager.cs    
 ┃ ┣ 📜LoadingManager.cs    
 ┃ ┣ 📜LoadSceneManager.cs    
 ┃ ┣ 📜Managers.cs    
 ┃ ┣ 📜PlayerData.cs    
 ┃ ┣ 📜Poolable.cs    
 ┃ ┣ 📜PoolManager.cs    
 ┃ ┣ 📜ReadSpreadSheet.cs    
 ┃ ┣ 📜ResourceManager.cs    
 ┃ ┣ 📜SoundManager.cs    
 ┃ ┣ 📜UIInputManager.cs    
 ┃ ┗ 📜UIManager.cs    
 ┣ 📂2_Scene ▶ 씬의 실행 세팅    
 ┃ ┣ 📜BaseScene.cs    
 ┃ ┣ 📜Battle.cs    
 ┃ ┣ 📜Maintenance.cs    
 ┃ ┣ 📜StartScene.cs    
 ┃ ┗ 📜Tutorial.cs    
 ┣ 📂3_Tutorial ▶ 튜토리얼 관련    
 ┃ ┣ 📜DialogSystem.cs    
 ┃ ┣ 📜TutorialBase.cs    
 ┃ ┣ 📜TutorialCamChange.cs    
 ┃ ┣ 📜TutorialController.cs    
 ┃ ┣ 📜TutorialDestroyTagObjects.cs    
 ┃ ┣ 📜TutorialDialog.cs    
 ┃ ┣ 📜TutorialEyeBlink.cs    
 ┃ ┣ 📜TutorialEyeOpen.cs    
 ┃ ┣ 📜TutorialFadeEffect.cs    
 ┃ ┣ 📜TutorialGenerateUI.cs    
 ┃ ┣ 📜TutorialMovement.cs    
 ┃ ┣ 📜TutorialNarration.cs    
 ┃ ┣ 📜TutorialTouchScreen.cs    
 ┃ ┣ 📜TutorialTrigger.cs    
 ┃ ┣ 📜TutorialUseSoul.cs    
 ┃ ┗ 📜UI_Player_Tutorial.cs    
 ┣ 📂4_MaintananceScene ▶ 정비씬    
 ┃ ┣ 📂Items ▶ 아이템 관련    
 ┃ ┃ ┣ 📜Item.cs    
 ┃ ┃ ┣ 📜ItemSkills.cs    
 ┃ ┃ ┗ 📜PotionSkill.cs    
 ┃ ┣ 📂NPC ▶ NPC 관련     
 ┃ ┃ ┣ 📜CharacterNPC.cs    
 ┃ ┃ ┣ 📜ForgeNPC.cs    
 ┃ ┃ ┣ 📜MapNPC.cs    
 ┃ ┃ ┣ 📜NPC.cs    
 ┃ ┃ ┣ 📜PotalExit.cs    
 ┃ ┃ ┗ 📜StoreNPC.cs    
 ┃ ┣ 📂Player ▶ 플레이어 관련    
 ┃ ┃ ┣ 📂Behaviours  ▶ 플레이어 행동        
 ┃ ┃ ┃ ┣ 📂Input ▶ 플레이어 입력 관련    
 ┃ ┃ ┃ ┃ ┣ 📜InputAttack.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputBase.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputInteract.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputMove.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputPotion.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputSkill.cs    
 ┃ ┃ ┃ ┃ ┗ 📜PlayerInputHandler.cs    
 ┃ ┃ ┃ ┣ 📂StageSkill ▶ 플레이어 스테이지 스킬    
 ┃ ┃ ┃ ┃ ┗ 📜StageSkill.cs    
 ┃ ┃ ┃ ┣ 📂State ▶ 플레이어의 상태머신     
 ┃ ┃ ┃ ┃ ┣ 📜PlayerStateHandler.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateAttack.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateBase.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateDie.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateHide.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateHit.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateIdle.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateInteract.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateMachine.cs    
 ┃ ┃ ┃ ┃ ┣ 📜StateMove.cs    
 ┃ ┃ ┃ ┃ ┗ 📜StateSkill.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourAttack.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourBase.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourInteract.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourMove.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourPotion.cs    
 ┃ ┃ ┃ ┣ 📜BehaviourSkill.cs    
 ┃ ┃ ┣ 📜Player.cs    
 ┃ ┃ ┣ 📜PlayerAnimationEvents.cs    
 ┃ ┃ ┣ 📜PlayerInteraction.cs    
 ┃ ┃ ┣ 📜PlayerInventory.cs    
 ┃ ┃ ┗ 📜PlayerStatHandler.cs    
 ┣ 📂5_BattleScene    
 ┃ ┣ 📂Enemy ▶ 적 관련    
 ┃ ┃ ┣ 📂Boss ▶ 적(보스) 정보    
 ┃ ┃ ┃ ┣ 📜BossAnimator.cs    
 ┃ ┃ ┃ ┣ 📜BossEnemy.cs    
 ┃ ┃ ┃ ┣ 📜BossMovement.cs    
 ┃ ┃ ┃ ┗ 📜BossSkill.cs    
 ┃ ┃ ┣ 📂Citizen ▶ 적(시민) 정보     
 ┃ ┃ ┃ ┣ 📜CitizenAnimator.cs    
 ┃ ┃ ┃ ┣ 📜CitizenEnemy.cs    
 ┃ ┃ ┃ ┗ 📜CitizenMovement.cs    
 ┃ ┃ ┣ 📂EnemyAttack ▶ 적의 공격     
 ┃ ┃ ┃ ┣ 📜Explosion.cs    
 ┃ ┃ ┃ ┣ 📜LineAtoB.cs    
 ┃ ┃ ┃ ┣ 📜MeleeAttack.cs    
 ┃ ┃ ┃ ┣ 📜ProjectileController.cs    
 ┃ ┃ ┃ ┗ 📜ProjectilePool.cs    
 ┃ ┃ ┣ 📂Normal ▶ 적(일반) 정보    
 ┃ ┃ ┃ ┣ 📜MeleeEnemy.cs    
 ┃ ┃ ┃ ┣ 📜NormalEnemy.cs    
 ┃ ┃ ┃ ┣ 📜NormalEnemyMovement.cs    
 ┃ ┃ ┃ ┗ 📜RangedEnemy.cs    
 ┃ ┃ ┣ 📂Spawner ▶ 적의 스폰      
 ┃ ┃ ┃ ┣ 📜BossSpawner.cs    
 ┃ ┃ ┃ ┗ 📜EnemySpawner.cs    
 ┃ ┃ ┣ 📜Enemy.cs    
 ┃ ┃ ┣ 📜EnemyAnimator.cs    
 ┃ ┃ ┣ 📜EnemyStatus.cs    
 ┃ ┃ ┗ 📜Soul.cs    
 ┃ ┣ 📂Map ▶ 전투 맵 관련    
 ┃ ┃ ┣ 📜BossMap.cs    
 ┃ ┃ ┣ 📜CitizenPortal.cs    
 ┃ ┃ ┣ 📜EntrancePortal.cs    
 ┃ ┃ ┣ 📜Escape.cs    
 ┃ ┃ ┣ 📜MapGenerator.cs    
 ┃ ┃ ┣ 📜NavMeshBuild.cs    
 ┃ ┃ ┗ 📜NormalMapManager.cs    
 ┃ ┗ 📜DMGtxt.cs    
 ┣ 📂UI ▶ UI 관련    
 ┃ ┣ 📂Effect ▶ UI 효과    
 ┃ ┃ ┣ 📜ArrowBlink.cs    
 ┃ ┃ ┣ 📜EyeBlink.cs    
 ┃ ┃ ┣ 📜TypingEffect.cs    
 ┃ ┃ ┣ 📜UpdateColorAlpha.cs    
 ┃ ┃ ┗ 📜ZoomToUI.cs    
 ┃ ┣ 📂Item ▶ UI 아이템    
 ┃ ┃ ┣ 📜UI_CharacterForce_Item.cs    
 ┃ ┃ ┣ 📜UI_EquipmentForce_item.cs    
 ┃ ┃ ┗ 📜UI_Store_Item.cs    
 ┃ ┣ 📂Popup ▶ UI 활성화    
 ┃ ┃ ┣ 📜UI_BackToMain.cs    
 ┃ ┃ ┣ 📜UI_CharacterForce.cs    
 ┃ ┃ ┣ 📜UI_CharacterInfo.cs    
 ┃ ┃ ┣ 📜UI_EquipmentForce.cs    
 ┃ ┃ ┣ 📜UI_Exit.cs    
 ┃ ┃ ┣ 📜UI_Map.cs    
 ┃ ┃ ┣ 📜UI_MiniMap.cs    
 ┃ ┃ ┣ 📜UI_Options.cs    
 ┃ ┃ ┣ 📜UI_PopUp.cs    
 ┃ ┃ ┣ 📜UI_Respawn.cs    
 ┃ ┃ ┣ 📜UI_Result.cs    
 ┃ ┃ ┣ 📜UI_StageClear.cs    
 ┃ ┃ ┣ 📜UI_Store.cs    
 ┃ ┃ ┗ 📜UI_StoreBuy.cs    
 ┃ ┣ 📂Scene ▶ 씬마다 UI 설정    
 ┃ ┃ ┣ 📜UI_Battle.cs    
 ┃ ┃ ┣ 📜UI_Boss.cs    
 ┃ ┃ ┣ 📜UI_HUD.cs    
 ┃ ┃ ┣ 📜UI_Maintenance.cs    
 ┃ ┃ ┣ 📜UI_Player.cs    
 ┃ ┃ ┣ 📜UI_Scene.cs    
 ┃ ┃ ┣ 📜UI_Start.cs    
 ┃ ┃ ┣ 📜UI_Tutorial.cs    
 ┗ ┗ ┗ 📜ParallaxBackground.cs    


