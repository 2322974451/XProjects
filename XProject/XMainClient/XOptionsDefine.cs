using System;

namespace XMainClient
{
	// Token: 0x020009F2 RID: 2546
	internal enum XOptionsDefine
	{
		// Token: 0x0400361D RID: 13853
		OD_START,
		// Token: 0x0400361E RID: 13854
		OD_SOUND,
		// Token: 0x0400361F RID: 13855
		BA_SOUND,
		// Token: 0x04003620 RID: 13856
		OD_MUSIC,
		// Token: 0x04003621 RID: 13857
		BA_MUSIC,
		// Token: 0x04003622 RID: 13858
		OD_VOICE,
		// Token: 0x04003623 RID: 13859
		BA_VOICE,
		// Token: 0x04003624 RID: 13860
		OD_VOLUME = 10,
		// Token: 0x04003625 RID: 13861
		OD_RADIO_WIFI,
		// Token: 0x04003626 RID: 13862
		OD_RADIO_TEAM,
		// Token: 0x04003627 RID: 13863
		OD_RADIO_CAMP,
		// Token: 0x04003628 RID: 13864
		OD_RADIO_PRIVATE,
		// Token: 0x04003629 RID: 13865
		OD_RADIO_PUBLIC,
		// Token: 0x0400362A RID: 13866
		OD_RADIO_WORLD,
		// Token: 0x0400362B RID: 13867
		OD_RADIO_AUTO_PALY,
		// Token: 0x0400362C RID: 13868
		OD_QUALITY = 20,
		// Token: 0x0400362D RID: 13869
		OD_FLOWERRAIN,
		// Token: 0x0400362E RID: 13870
		OD_SAMESCREENNUM,
		// Token: 0x0400362F RID: 13871
		OD_TEAM_USE_PASSWORD,
		// Token: 0x04003630 RID: 13872
		OD_RADIO,
		// Token: 0x04003631 RID: 13873
		OD_3D_TOUCH,
		// Token: 0x04003632 RID: 13874
		OD_SMOOTH,
		// Token: 0x04003633 RID: 13875
		OD_RESOLUTION,
		// Token: 0x04003634 RID: 13876
		OD_POWERSAVE,
		// Token: 0x04003635 RID: 13877
		OD_NOTIFICATION,
		// Token: 0x04003636 RID: 13878
		OD_BLOCKOTHERPLAYERS,
		// Token: 0x04003637 RID: 13879
		OD_TAILCAMERA_SPEED,
		// Token: 0x04003638 RID: 13880
		OD_LOCALSETTING_END = 999,
		// Token: 0x04003639 RID: 13881
		OD_PUSH_ENERGY,
		// Token: 0x0400363A RID: 13882
		OD_LEVEL_SEAL_REMOVE,
		// Token: 0x0400363B RID: 13883
		OD_RISK_DICE,
		// Token: 0x0400363C RID: 13884
		OD_RISK_BOX,
		// Token: 0x0400363D RID: 13885
		OD_RISK,
		// Token: 0x0400363E RID: 13886
		OD_SEAL,
		// Token: 0x0400363F RID: 13887
		OD_BATTLE_OPTION_START = 1100,
		// Token: 0x04003640 RID: 13888
		OD_VIEW,
		// Token: 0x04003641 RID: 13889
		OD_OPERATE,
		// Token: 0x04003642 RID: 13890
		OD_OTHER,
		// Token: 0x04003643 RID: 13891
		OD_TailCameraSpeed25D = 1111,
		// Token: 0x04003644 RID: 13892
		OD_TailCameraSpeed3D,
		// Token: 0x04003645 RID: 13893
		OD_TailCameraSpeed3DFree,
		// Token: 0x04003646 RID: 13894
		OD_ManualCameraSpeedXInBattle25D = 1121,
		// Token: 0x04003647 RID: 13895
		OD_ManualCameraSpeedXInBattle3D,
		// Token: 0x04003648 RID: 13896
		OD_ManualCameraSpeedXInBattle3DFree,
		// Token: 0x04003649 RID: 13897
		OD_Vertical3D = 1132,
		// Token: 0x0400364A RID: 13898
		OD_Vertical3DFree,
		// Token: 0x0400364B RID: 13899
		OD_Distance3DFree = 1143,
		// Token: 0x0400364C RID: 13900
		ManualCameraSpeedXInHallAutoLock = 2011,
		// Token: 0x0400364D RID: 13901
		ManualCameraSpeedXInHallFreeLock,
		// Token: 0x0400364E RID: 13902
		ManualCameraDampXInHallAutoLock = 2021,
		// Token: 0x0400364F RID: 13903
		ManualCameraDampXInHallFreeLock,
		// Token: 0x04003650 RID: 13904
		ManualCameraSpeedYInHallAutoLock = 2031,
		// Token: 0x04003651 RID: 13905
		ManualCameraSpeedYInHallFreeLock,
		// Token: 0x04003652 RID: 13906
		ManualCameraDampYInHallAutoLock = 2041,
		// Token: 0x04003653 RID: 13907
		ManualCameraDampYInHallFreeLock,
		// Token: 0x04003654 RID: 13908
		ManualCameraDampXInBattleAutoLock = 2051,
		// Token: 0x04003655 RID: 13909
		ManualCameraDampXInBattleFreeLock,
		// Token: 0x04003656 RID: 13910
		ManualCameraSpeedYInBattleAutoLock = 2061,
		// Token: 0x04003657 RID: 13911
		ManualCameraSpeedYInBattleFreeLock,
		// Token: 0x04003658 RID: 13912
		ManualCameraDampYInBattleAutoLock = 2071,
		// Token: 0x04003659 RID: 13913
		ManualCameraDampYInBattleFreeLock,
		// Token: 0x0400365A RID: 13914
		RangeWeightAutoLock = 2081,
		// Token: 0x0400365B RID: 13915
		RangeWeightFreeLock,
		// Token: 0x0400365C RID: 13916
		BossWeightAutoLock = 2091,
		// Token: 0x0400365D RID: 13917
		BossWeightFreeLock,
		// Token: 0x0400365E RID: 13918
		EliteWeightAutoLock = 2101,
		// Token: 0x0400365F RID: 13919
		EliteWeightFreeLock,
		// Token: 0x04003660 RID: 13920
		EnemyWeightAutoLock = 2111,
		// Token: 0x04003661 RID: 13921
		EnemyWeightFreeLock,
		// Token: 0x04003662 RID: 13922
		PupetWeightAutoLock = 2121,
		// Token: 0x04003663 RID: 13923
		PupetWeightFreeLock,
		// Token: 0x04003664 RID: 13924
		RoleWeightAutoLock = 2131,
		// Token: 0x04003665 RID: 13925
		RoleWeightFreeLock,
		// Token: 0x04003666 RID: 13926
		ImmortalWeightAutoLock = 2141,
		// Token: 0x04003667 RID: 13927
		ImmortalWeightFreeLock,
		// Token: 0x04003668 RID: 13928
		WithinScopeAutoLock = 2151,
		// Token: 0x04003669 RID: 13929
		WithinScopeFreeLock,
		// Token: 0x0400366A RID: 13930
		WithinRangeAutoLock = 2161,
		// Token: 0x0400366B RID: 13931
		WithinRangeFreeLock,
		// Token: 0x0400366C RID: 13932
		AssistAngleAutoLock = 2171,
		// Token: 0x0400366D RID: 13933
		AssistAngleFreeLock,
		// Token: 0x0400366E RID: 13934
		ProfRangeAutoLock = 2181,
		// Token: 0x0400366F RID: 13935
		ProfRangeFreeLock,
		// Token: 0x04003670 RID: 13936
		ProfRangeLongAutoLock = 2191,
		// Token: 0x04003671 RID: 13937
		ProfRangeLongFreeLock,
		// Token: 0x04003672 RID: 13938
		ProfRangeAllAutoLock = 2201,
		// Token: 0x04003673 RID: 13939
		ProfRangeAllFreeLock,
		// Token: 0x04003674 RID: 13940
		CameraAdjustScopeAutoLock = 2211,
		// Token: 0x04003675 RID: 13941
		CameraAdjustScopeFreeLock,
		// Token: 0x04003676 RID: 13942
		ProfScopeAutoLock = 2221,
		// Token: 0x04003677 RID: 13943
		ProfScopeFreeLock,
		// Token: 0x04003678 RID: 13944
		OD_LOCK_ROCKER = 3011,
		// Token: 0x04003679 RID: 13945
		OD_3D_TOUCH_BATTLE,
		// Token: 0x0400367A RID: 13946
		OD_Gyro,
		// Token: 0x0400367B RID: 13947
		OD_Shield_Skill_Fx,
		// Token: 0x0400367C RID: 13948
		OD_Shield_Summon,
		// Token: 0x0400367D RID: 13949
		OD_Shield_NoTeam_Chat,
		// Token: 0x0400367E RID: 13950
		OD_Shield_My_Skill_Fx,
		// Token: 0x0400367F RID: 13951
		OD_Awake_Slot,
		// Token: 0x04003680 RID: 13952
		OD_BATTLE_OPTION_END,
		// Token: 0x04003681 RID: 13953
		OD_STOP_BLOCK_REDPOINT = 10000,
		// Token: 0x04003682 RID: 13954
		OD_TEAM_PASSWORD,
		// Token: 0x04003683 RID: 13955
		OD_GUILD_SKILL_LOCK,
		// Token: 0x04003684 RID: 13956
		OD_SKIP_TUTORIAL,
		// Token: 0x04003685 RID: 13957
		OD_NO_ENCHANT_REPLACE_CONFIRM = 10005,
		// Token: 0x04003686 RID: 13958
		OD_NO_ARTIFACTCOMPOSE_REPLACE_CONFIRM = 10010,
		// Token: 0x04003687 RID: 13959
		OD_NO_SMELTSTONE_EXCHANGED_CONFIRM = 10015,
		// Token: 0x04003688 RID: 13960
		OD_NO_FUSE_CONFIRM,
		// Token: 0x04003689 RID: 13961
		OD_NO_INSCRIPTION_CONFIRM,
		// Token: 0x0400368A RID: 13962
		OD_NO_RECAST_CONFIRM,
		// Token: 0x0400368B RID: 13963
		OD_NO_CAPACITYDOWN_TIPS,
		// Token: 0x0400368C RID: 13964
		OD_RECYCLE_TIPS = 10050,
		// Token: 0x0400368D RID: 13965
		OD_NO_REFINED_CONFIRM,
		// Token: 0x0400368E RID: 13966
		OD_NO_PVEATTRMODIFY_CONFIRM = 10051,
		// Token: 0x0400368F RID: 13967
		OD_RECRUIT_FIRST_GROUP = 10020,
		// Token: 0x04003690 RID: 13968
		OD_RECRUIT_FIRST_MEMBER,
		// Token: 0x04003691 RID: 13969
		OD_PREROGATIVE_PreChatBubble = 10031,
		// Token: 0x04003692 RID: 13970
		OD_PREROGATIVE_PreChatAdorn,
		// Token: 0x04003693 RID: 13971
		OD_PREROGATIVE_PreChatColor,
		// Token: 0x04003694 RID: 13972
		OD_PREROGATIVE_PreTeamBorder,
		// Token: 0x04003695 RID: 13973
		OD_PREROGATIVE_PreTeamBackground,
		// Token: 0x04003696 RID: 13974
		OD_BackFlow_IsSystemOpen = 10040
	}
}
