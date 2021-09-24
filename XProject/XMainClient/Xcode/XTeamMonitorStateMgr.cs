using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamMonitorStateMgr
	{

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

		public void Reset()
		{
			this.m_EntityStates.Clear();
			this.m_LoadingEntities.Clear();
			this.m_Entities.Clear();
		}

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

		public bool HasLoadingEntity()
		{
			return this.m_LoadingEntities.Count > 0 || this.m_EntityStates.Count < this.m_Entities.Count;
		}

		private Dictionary<ulong, XTeamMonitorState> m_EntityStates = new Dictionary<ulong, XTeamMonitorState>();

		private HashSet<ulong> m_LoadingEntities = new HashSet<ulong>();

		private HashSet<ulong> m_Entities = new HashSet<ulong>();
	}
}
