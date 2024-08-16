# KkumSinMa_SourceCode

📦Scripts    
 ┣ 📂0_Util    
 ┃ ┣ 📜AudioClips.cs    
 ┃ ┣ 📜Define.cs    
 ┃ ┣ 📜Extension.cs    
 ┃ ┣ 📜Interfaces.cs    
 ┃ ┣ 📜SceneChanger.cs    
 ┃ ┣ 📜UIBase.cs    
 ┃ ┗ 📜Util.cs    
 ┣ 📂1_Managers    
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
 ┣ 📂2_Scene    
 ┃ ┣ 📜BaseScene.cs    
 ┃ ┣ 📜Battle.cs    
 ┃ ┣ 📜Maintenance.cs    
 ┃ ┣ 📜StartScene.cs    
 ┃ ┗ 📜Tutorial.cs    
 ┣ 📂3_Tutorial    
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
 ┣ 📂4_MaintananceScene    
 ┃ ┣ 📂Items    
 ┃ ┃ ┣ 📜Item.cs    
 ┃ ┃ ┣ 📜ItemSkills.cs    
 ┃ ┃ ┗ 📜PotionSkill.cs    
 ┃ ┣ 📂NPC    
 ┃ ┃ ┣ 📜CharacterNPC.cs    
 ┃ ┃ ┣ 📜ForgeNPC.cs    
 ┃ ┃ ┣ 📜MapNPC.cs    
 ┃ ┃ ┣ 📜NPC.cs    
 ┃ ┃ ┣ 📜PotalExit.cs    
 ┃ ┃ ┗ 📜StoreNPC.cs    
 ┃ ┣ 📂Player    
 ┃ ┃ ┣ 📂Behaviours    
 ┃ ┃ ┃ ┣ 📂Input    
 ┃ ┃ ┃ ┃ ┣ 📜InputAttack.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputBase.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputInteract.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputMove.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputPotion.cs    
 ┃ ┃ ┃ ┃ ┣ 📜InputSkill.cs    
 ┃ ┃ ┃ ┃ ┗ 📜PlayerInputHandler.cs    
 ┃ ┃ ┃ ┣ 📂StageSkill    
 ┃ ┃ ┃ ┃ ┗ 📜StageSkill.cs    
 ┃ ┃ ┃ ┣ 📂State    
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
 ┃ ┣ 📂Enemy    
 ┃ ┃ ┣ 📂Boss    
 ┃ ┃ ┃ ┣ 📜BossAnimator.cs    
 ┃ ┃ ┃ ┣ 📜BossEnemy.cs    
 ┃ ┃ ┃ ┣ 📜BossMovement.cs    
 ┃ ┃ ┃ ┗ 📜BossSkill.cs    
 ┃ ┃ ┣ 📂Citizen    
 ┃ ┃ ┃ ┣ 📜CitizenAnimator.cs    
 ┃ ┃ ┃ ┣ 📜CitizenEnemy.cs    
 ┃ ┃ ┃ ┗ 📜CitizenMovement.cs    
 ┃ ┃ ┣ 📂EnemyAttack    
 ┃ ┃ ┃ ┣ 📜Explosion.cs    
 ┃ ┃ ┃ ┣ 📜LineAtoB.cs    
 ┃ ┃ ┃ ┣ 📜MeleeAttack.cs    
 ┃ ┃ ┃ ┣ 📜ProjectileController.cs    
 ┃ ┃ ┃ ┗ 📜ProjectilePool.cs    
 ┃ ┃ ┣ 📂Normal    
 ┃ ┃ ┃ ┣ 📜MeleeEnemy.cs    
 ┃ ┃ ┃ ┣ 📜NormalEnemy.cs    
 ┃ ┃ ┃ ┣ 📜NormalEnemyMovement.cs    
 ┃ ┃ ┃ ┗ 📜RangedEnemy.cs    
 ┃ ┃ ┣ 📂Spawner    
 ┃ ┃ ┃ ┣ 📜BossSpawner.cs    
 ┃ ┃ ┃ ┗ 📜EnemySpawner.cs    
 ┃ ┃ ┣ 📜Enemy.cs    
 ┃ ┃ ┣ 📜EnemyAnimator.cs    
 ┃ ┃ ┣ 📜EnemyStatus.cs    
 ┃ ┃ ┗ 📜Soul.cs    
 ┃ ┣ 📂Map    
 ┃ ┃ ┣ 📜BossMap.cs    
 ┃ ┃ ┣ 📜CitizenPortal.cs    
 ┃ ┃ ┣ 📜EntrancePortal.cs    
 ┃ ┃ ┣ 📜Escape.cs    
 ┃ ┃ ┣ 📜MapGenerator.cs    
 ┃ ┃ ┣ 📜NavMeshBuild.cs    
 ┃ ┃ ┗ 📜NormalMapManager.cs    
 ┃ ┗ 📜DMGtxt.cs    
 ┣ 📂UI    
 ┃ ┣ 📂Effect    
 ┃ ┃ ┣ 📜ArrowBlink.cs    
 ┃ ┃ ┣ 📜EyeBlink.cs    
 ┃ ┃ ┣ 📜TypingEffect.cs    
 ┃ ┃ ┣ 📜UpdateColorAlpha.cs    
 ┃ ┃ ┗ 📜ZoomToUI.cs    
 ┃ ┣ 📂Item    
 ┃ ┃ ┣ 📜UI_CharacterForce_Item.cs    
 ┃ ┃ ┣ 📜UI_EquipmentForce_item.cs    
 ┃ ┃ ┗ 📜UI_Store_Item.cs    
 ┃ ┣ 📂Popup    
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
 ┃ ┣ 📂Scene    
 ┃ ┃ ┣ 📜UI_Battle.cs    
 ┃ ┃ ┣ 📜UI_Boss.cs    
 ┃ ┃ ┣ 📜UI_HUD.cs    
 ┃ ┃ ┣ 📜UI_Maintenance.cs    
 ┃ ┃ ┣ 📜UI_Player.cs    
 ┃ ┃ ┣ 📜UI_Scene.cs    
 ┃ ┃ ┣ 📜UI_Start.cs    
 ┃ ┃ ┣ 📜UI_Tutorial.cs    
 ┗ ┗ ┗ 📜ParallaxBackground.cs    
