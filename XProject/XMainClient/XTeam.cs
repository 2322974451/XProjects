using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeam
	{

		public bool bAllReady
		{
			get
			{
				return this._bAllReady;
			}
		}

		public bool bLeaderChanged
		{
			get
			{
				return this.m_bLeaderChanged;
			}
		}

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

		public void PreUpdate()
		{
			this.m_bLeaderChanged = false;
		}

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

		public void Reset()
		{
			this.members.Clear();
			this.myData = null;
			this.leaderData = null;
		}

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

		public XTeamBriefData teamBrief = new XTeamBriefData();

		public List<XTeamMember> members = new List<XTeamMember>();

		public XTeamMember myData = null;

		private int joinIndex = 0;

		private bool _bAllReady = false;

		public XTeamMember leaderData = null;

		private bool m_bLeaderChanged;
	}
}
