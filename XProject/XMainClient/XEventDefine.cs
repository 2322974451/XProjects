using System;

namespace XMainClient
{

	internal enum XEventDefine
	{

		XEvent_Invalid = -1,

		XEvent_Idle,

		XEvent_Move,

		XEvent_Jump,

		XEvent_Fall,

		XEvent_Charge,

		XEvent_Freeze,

		XEvent_BeHit,

		XEvent_Attack,

		XEvent_Hit,

		XEvent_QTE,

		XEvent_OnSkillFired,

		XEvent_OnJAPassed,

		XEvent_Rotation,

		XEvent_Endure,

		XEvent_CameraShake,

		XEvent_CameraSolo,

		XEvent_CameraMotion,

		XEvent_CameraMotionEnd,

		XEvent_CameraAction,

		XEvent_CameraCloseUp,

		XEvent_CameraCloseUpEnd,

		XEvent_AttackShowBegin,

		XEvent_AttackShow,

		XEvent_AttackShowEnd,

		XEvent_EquipChange,

		XEvent_PlaySound,

		XEvent_NaviMove,

		XEvent_OnEntityCreated,

		XEvent_OnEntityDeleted,

		XEvent_FadeIn,

		XEvent_FadeOut,

		XEvent_LoadEquip,

		XEvent_UnloadEquip,

		XEvent_AddItem,

		XEvent_RemoveItem,

		XEvent_ItemNumChanged,

		XEvent_SwapItem,

		XEvent_UpdateItem,

		XEvent_VirtualItemChanged,

		XEvent_ItemChangeFinished,

		XEvent_AIAutoFight,

		XEvent_SkillExternal,

		XEvent_OnRevived,

		XEvent_AIEnterFight,

		XEvent_AIRestart,

		XEvent_AIStartSkill = 46,

		XEvent_AISkillHurt,

		XEvent_AIEndSkill,

		XEvent_AIStop,

		XEvent_AIEvent,

		XEvent_GuildPositionChanged = 60,

		XEvent_GuildLevelChanged,

		XEvent_InGuildStateChanged,

		XEvent_GuildInfoChange,

		XEvent_FriendInfoChange = 70,

		XEvent_BuffAdd = 100,

		XEvent_BuffRemove,

		XEvent_AttributeChange,

		XEvent_HUDAdd,

		XEvent_RealDead,

		XEvent_LeaveScene,

		XEvent_HUDDoodad,

		XEvent_BuffBillboardAdd,

		XEvent_BuffBillboardRemove,

		XEvent_Bubble,

		XEvent_BillboardHide,

		XEvent_BillboardShowCtrl,

		XEvent_TeamMemberCountChanged = 119,

		XEvent_JoinTeam,

		XEvent_LeaveTeam,

		XEvent_OnReconnected = 123,

		XEvent_SpotOn,

		XEvent_Highlight,

		XEvent_FriendList,

		XEvent_GuildMemberList,

		XEvent_Enmity,

		XEvent_OnEntityTransfer,

		XEvent_ArmorBroken,

		XEvent_ArmorRecover,

		XEvent_WoozyOn,

		XEvent_WoozyOff,

		XEvent_StrengthPresevedOn,

		XEvent_StrengthPresevedOff,

		XEvent_AudioOperation,

		XEvent_CoolDownAllSkills,

		XEvent_InitCoolDownAllSkills,

		XEvent_DesignationInfoChange = 140,

		XEvent_ProjectDamage,

		XEvent_EnableAI,

		XEvent_OnMounted,

		XEvent_OnUnMounted,

		XEvent_TitleChange,

		XEvent_BuffChange,

		XEvent_ComboChange,

		XEvent_Manipulation_On,

		XEvent_Manipulation_Off,

		XEvent_TaskStateChange,

		XEvent_DoodadCreate,

		XEvent_DoodadDelete,

		XEvent_ActivityTaskUpdate,

		XEvent_FightGroupChanged,

		XEvent_HomeFeasting,

		XEvent_BattleEnd,

		XEvent_PlayerLevelChange,

		XEvent_MentorshipRelationOperation,

		XEvent_Prerogative,

		XEvent_NpcFavorFxChange,

		XEvent_DragonGuildInfoChange,

		XEvent_BigMeleePointChange,

		XEvent_BigMeleeEnemyChange,

		XEvent_EntityAttributeChange,

		XEvent_Move_Mob,

		XEvent_Num
	}
}
