using System;

namespace XMainClient
{
	// Token: 0x02000EF0 RID: 3824
	internal class XStateMgr
	{
		// Token: 0x0600CAF5 RID: 51957 RVA: 0x002E0AD4 File Offset: 0x002DECD4
		public static bool IsMoveState(XStateDefine state)
		{
			return state == XStateDefine.XState_Move;
		}

		// Token: 0x0600CAF6 RID: 51958 RVA: 0x002E0AEC File Offset: 0x002DECEC
		public static bool IsUnBattleState(XStateDefine state)
		{
			return state == XStateDefine.XState_Idle || XStateMgr.IsMoveState(state);
		}

		// Token: 0x0600CAF7 RID: 51959 RVA: 0x002E0B0C File Offset: 0x002DED0C
		public static bool IsAirState(XStateDefine state)
		{
			return state == XStateDefine.XState_Fall || state == XStateDefine.XState_Jump;
		}

		// Token: 0x0600CAF8 RID: 51960 RVA: 0x002E0B2C File Offset: 0x002DED2C
		public static bool IsStunState(XStateDefine state)
		{
			return state == XStateDefine.XState_Freeze;
		}

		// Token: 0x0600CAF9 RID: 51961 RVA: 0x002E0B44 File Offset: 0x002DED44
		public static bool IsUnControlledState(XStateDefine state)
		{
			return XStateMgr.IsStunState(state) || state == XStateDefine.XState_BeHit || state == XStateDefine.XState_Death;
		}
	}
}
