using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E69 RID: 3689
	internal class XTeamMonitorStateMgr
	{
		// Token: 0x0600C5A7 RID: 50599 RVA: 0x002BAB70 File Offset: 0x002B8D70
		public void SetState(ulong uid, XTeamMonitorState state)
		{
			bool flag = !this.m_Entities.Contains(uid);
			if (!flag)
			{
				this.m_EntityStates[uid] = state;
				bool flag2 = state == XTeamMonitorState.TMS_Loading;
				if (flag2)
				{
					this.m_LoadingEntities.Add(uid);
				}
				else
				{
					this.m_LoadingEntities.Remove(uid);
				}
			}
		}

		// Token: 0x0600C5A8 RID: 50600 RVA: 0x002BABC8 File Offset: 0x002B8DC8
		public void SetTotalCount(List<XTeamBloodUIData> list)
		{
			this.m_Entities.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].uid != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this.m_Entities.Add(list[i].uid);
				}
			}
		}

		// Token: 0x0600C5A9 RID: 50601 RVA: 0x002BAC35 File Offset: 0x002B8E35
		public void Reset()
		{
			this.m_EntityStates.Clear();
			this.m_LoadingEntities.Clear();
			this.m_Entities.Clear();
		}

		// Token: 0x0600C5AA RID: 50602 RVA: 0x002BAC5C File Offset: 0x002B8E5C
		public XTeamMonitorState GetState(ulong uid)
		{
			XTeamMonitorState xteamMonitorState;
			bool flag = this.m_EntityStates.TryGetValue(uid, out xteamMonitorState);
			XTeamMonitorState result;
			if (flag)
			{
				result = xteamMonitorState;
			}
			else
			{
				result = XTeamMonitorState.TMS_Loading;
			}
			return result;
		}

		// Token: 0x0600C5AB RID: 50603 RVA: 0x002BAC88 File Offset: 0x002B8E88
		public bool HasLoadingEntity()
		{
			return this.m_LoadingEntities.Count > 0 || this.m_EntityStates.Count < this.m_Entities.Count;
		}

		// Token: 0x04005692 RID: 22162
		private Dictionary<ulong, XTeamMonitorState> m_EntityStates = new Dictionary<ulong, XTeamMonitorState>();

		// Token: 0x04005693 RID: 22163
		private HashSet<ulong> m_LoadingEntities = new HashSet<ulong>();

		// Token: 0x04005694 RID: 22164
		private HashSet<ulong> m_Entities = new HashSet<ulong>();
	}
}
