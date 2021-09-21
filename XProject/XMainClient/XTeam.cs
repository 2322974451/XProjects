using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D40 RID: 3392
	internal class XTeam
	{
		// Token: 0x17003311 RID: 13073
		// (get) Token: 0x0600BBF2 RID: 48114 RVA: 0x0026B584 File Offset: 0x00269784
		public bool bAllReady
		{
			get
			{
				return this._bAllReady;
			}
		}

		// Token: 0x17003312 RID: 13074
		// (get) Token: 0x0600BBF3 RID: 48115 RVA: 0x0026B59C File Offset: 0x0026979C
		public bool bLeaderChanged
		{
			get
			{
				return this.m_bLeaderChanged;
			}
		}

		// Token: 0x0600BBF4 RID: 48116 RVA: 0x0026B5B4 File Offset: 0x002697B4
		public void AddMember(TeamMember data)
		{
			for (int i = 0; i < this.members.Count; i++)
			{
				XTeamMember xteamMember = this.members[i];
				bool flag = xteamMember.uid == data.memberID;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Duplicated member: ", xteamMember.uid.ToString(), null, null, null, null);
					return;
				}
			}
			string leaderName = this.teamBrief.leaderName;
			int num = this.joinIndex;
			this.joinIndex = num + 1;
			XTeamMember xteamMember2 = XTeamMember.CreateTeamMember(data, leaderName, num);
			this.members.Add(xteamMember2);
			bool flag2 = this.myData == null;
			if (flag2)
			{
				XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
				bool flag3 = xplayerData != null && xplayerData.EntityID == data.memberID;
				if (flag3)
				{
					this.myData = xteamMember2;
				}
			}
			bool bIsLeader = xteamMember2.bIsLeader;
			if (bIsLeader)
			{
				this.leaderData = xteamMember2;
				this.m_bLeaderChanged = true;
			}
			XSingleton<XDebug>.singleton.AddGreenLog("Add Teammember ", xteamMember2.name, ", uid = ", data.memberID.ToString(), "  count = ", this.members.Count.ToString());
		}

		// Token: 0x0600BBF5 RID: 48117 RVA: 0x0026B6FC File Offset: 0x002698FC
		public string RemoveMember(ulong uid)
		{
			string text = "";
			for (int i = 0; i < this.members.Count; i++)
			{
				bool flag = this.members[i].uid == uid;
				if (flag)
				{
					text = this.members[i].name;
					this.members.RemoveAt(i);
					XSingleton<XDebug>.singleton.AddGreenLog("Remove Teammember ", text, ", uid = ", uid.ToString(), ", count = ", this.members.Count.ToString());
					break;
				}
			}
			bool flag2 = string.IsNullOrEmpty(text);
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Cant find teammember ", uid.ToString(), " when remove", null, null, null);
			}
			bool flag3 = this.leaderData != null && this.leaderData.uid == uid;
			if (flag3)
			{
				this.leaderData = null;
			}
			return text;
		}

		// Token: 0x0600BBF6 RID: 48118 RVA: 0x0026B7F8 File Offset: 0x002699F8
		public void UpdateMember(TeamMember data)
		{
			for (int i = 0; i < this.members.Count; i++)
			{
				XTeamMember xteamMember = this.members[i];
				bool flag = xteamMember.uid == data.memberID;
				if (flag)
				{
					ExpTeamMemberState state = xteamMember.state;
					xteamMember.SetData(data, this.teamBrief.leaderName, xteamMember.joinIndex);
					ExpTeamMemberState state2 = xteamMember.state;
					bool flag2 = xteamMember == this.leaderData && !xteamMember.bIsLeader;
					if (flag2)
					{
						this.leaderData = null;
					}
					bool flag3 = state == ExpTeamMemberState.EXPTEAM_IDLE && state2 == ExpTeamMemberState.EXPTEAM_DISAGREE;
					if (flag3)
					{
						bool flag4 = this.teamBrief.rowData.Type == 15;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RefusePartner", new object[]
							{
								xteamMember.name
							}), "fece00");
						}
						else
						{
							bool flag5 = this.teamBrief.rowData.Type == 17;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RefuseCreateTeamLeague", new object[]
								{
									xteamMember.name
								}), "fece00");
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_REFUSE_BATTLE", new object[]
								{
									xteamMember.name
								}), "fece00");
							}
						}
					}
					break;
				}
			}
		}

		// Token: 0x0600BBF7 RID: 48119 RVA: 0x0026B968 File Offset: 0x00269B68
		private void UpdateTeamState()
		{
			this._bAllReady = true;
			foreach (XTeamMember xteamMember in this.members)
			{
				bool flag = xteamMember.position != XTeamPosition.TP_LEADER && xteamMember.state == ExpTeamMemberState.EXPTEAM_IDLE;
				if (flag)
				{
					this._bAllReady = false;
					break;
				}
			}
		}

		// Token: 0x0600BBF8 RID: 48120 RVA: 0x0026B9E4 File Offset: 0x00269BE4
		public void PreUpdate()
		{
			this.m_bLeaderChanged = false;
		}

		// Token: 0x0600BBF9 RID: 48121 RVA: 0x0026B9F0 File Offset: 0x00269BF0
		public void OnUpdate()
		{
			bool flag = this.myData == null;
			if (flag)
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag2 = player != null;
				if (flag2)
				{
					for (int i = 0; i < this.members.Count; i++)
					{
						bool flag3 = this.members[i].uid == player.ID;
						if (flag3)
						{
							this.myData = this.members[i];
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600BBFA RID: 48122 RVA: 0x0026BA74 File Offset: 0x00269C74
		public void PostUpdate()
		{
			bool flag = this.leaderData == null || this.leaderData.name != this.teamBrief.leaderName;
			if (flag)
			{
				bool flag2 = this.leaderData != null;
				if (flag2)
				{
					this.leaderData.position = XTeamPosition.TP_MEMBER;
				}
				for (int i = 0; i < this.members.Count; i++)
				{
					bool flag3 = this.members[i].name == this.teamBrief.leaderName;
					if (flag3)
					{
						this.leaderData = this.members[i];
						this.leaderData.position = XTeamPosition.TP_LEADER;
						this.m_bLeaderChanged = true;
						break;
					}
				}
			}
		}

		// Token: 0x0600BBFB RID: 48123 RVA: 0x0026BB37 File Offset: 0x00269D37
		public void Reset()
		{
			this.members.Clear();
			this.myData = null;
			this.leaderData = null;
		}

		// Token: 0x0600BBFC RID: 48124 RVA: 0x0026BB54 File Offset: 0x00269D54
		public XTeamMember FindMember(ulong uid)
		{
			for (int i = 0; i < this.members.Count; i++)
			{
				bool flag = this.members[i].uid == uid;
				if (flag)
				{
					return this.members[i];
				}
			}
			return null;
		}

		// Token: 0x0600BBFD RID: 48125 RVA: 0x0026BBAC File Offset: 0x00269DAC
		public void OnEntityMatchingInfo(AllyMatchRoleID data)
		{
			ulong roleID = data.roleID;
			ulong allyID = data.allyID;
			for (int i = 0; i < this.members.Count; i++)
			{
				bool flag = this.members[i].uid == roleID;
				if (flag)
				{
					this.members[i].entityID = allyID;
					break;
				}
			}
		}

		// Token: 0x04004C3E RID: 19518
		public XTeamBriefData teamBrief = new XTeamBriefData();

		// Token: 0x04004C3F RID: 19519
		public List<XTeamMember> members = new List<XTeamMember>();

		// Token: 0x04004C40 RID: 19520
		public XTeamMember myData = null;

		// Token: 0x04004C41 RID: 19521
		private int joinIndex = 0;

		// Token: 0x04004C42 RID: 19522
		private bool _bAllReady = false;

		// Token: 0x04004C43 RID: 19523
		public XTeamMember leaderData = null;

		// Token: 0x04004C44 RID: 19524
		private bool m_bLeaderChanged;
	}
}
