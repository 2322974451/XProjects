using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamMonitorHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_TeamGo = base.PanelObject.transform.Find("TeamPanel").gameObject;
			Transform transform = this.m_TeamGo.transform.FindChild("TeammateTpl");
			this.m_TeamUIPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			transform = base.PanelObject.transform.FindChild("RankPanel");
			bool flag = transform != null;
			if (flag)
			{
				DlgHandlerBase.EnsureCreate<XSceneDamageRankHandler>(ref this.m_DamageRankHandler, transform.gameObject, this, false);
			}
			bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				this.m_RankCheckBox = (base.PanelObject.transform.Find("TabList/Rank").GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_TeamCheckBox = (base.PanelObject.transform.Find("TabList/Team").GetComponent("XUICheckBox") as IXUICheckBox);
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				if (sceneType == SceneType.SCENE_PKTWO || sceneType == SceneType.SCENE_CUSTOMPKTWO)
				{
					this.m_RankCheckBox.SetVisible(false);
					this.m_TeamCheckBox.SetVisible(false);
				}
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			bool flag = !XSingleton<XScene>.singleton.bSpectator;
			if (flag)
			{
				this.m_RankCheckBox.ID = 0UL;
				this.m_TeamCheckBox.ID = 1UL;
				this.m_RankCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
				this.m_TeamCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
			}
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSceneDamageRankHandler>(ref this.m_DamageRankHandler);
			for (int i = 0; i < this.m_Members.Count; i++)
			{
				this.m_Members[i].Unload();
			}
			base.OnUnload();
		}

		private bool _OnTabSelectionChanged(IXUICheckBox ckb)
		{
			bool flag = !ckb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = ckb.ID == 0UL;
				if (flag2)
				{
					bool flag3 = this.m_DamageRankHandler != null;
					if (flag3)
					{
						this.m_DamageRankHandler.SetVisible(true);
					}
					this.m_TeamGo.SetActive(false);
				}
				else
				{
					bool flag4 = this.m_DamageRankHandler != null;
					if (flag4)
					{
						this.m_DamageRankHandler.SetVisible(false);
					}
					this.m_TeamGo.SetActive(true);
				}
				result = true;
			}
			return result;
		}

		public override void OnUpdate()
		{
			bool flag = !this.active;
			if (!flag)
			{
				base.OnUpdate();
				for (int i = 0; i < this.m_Members.Count; i++)
				{
					this.m_Members[i].Update();
				}
				bool flag2 = this.m_DamageRankHandler != null && this.m_DamageRankHandler.active;
				if (flag2)
				{
					this.m_DamageRankHandler.OnUpdate();
				}
				this._ReqQueryRoleStates();
			}
		}

		private void _ReqQueryRoleStates()
		{
			bool flag = this.m_StateMgr.HasLoadingEntity();
			if (flag)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				bool flag2 = realtimeSinceStartup - this.m_LastStateQueryTime < 1f;
				if (!flag2)
				{
					this.m_LastStateQueryTime = realtimeSinceStartup;
					PtcC2G_QueryRoleStateReq ptcC2G_QueryRoleStateReq = new PtcC2G_QueryRoleStateReq();
					for (int i = 0; i < this.m_Members.Count; i++)
					{
						XTeamMemberMonitor xteamMemberMonitor = this.m_Members[i];
						bool flag3 = xteamMemberMonitor.Entity == null && this.m_StateMgr.GetState(xteamMemberMonitor.Data.entityID) == XTeamMonitorState.TMS_Loading;
						if (flag3)
						{
							ptcC2G_QueryRoleStateReq.Data.roleids.Add(xteamMemberMonitor.Data.entityID);
						}
					}
					bool flag4 = ptcC2G_QueryRoleStateReq.Data.roleids.Count > 0;
					if (flag4)
					{
						XSingleton<XClientNetwork>.singleton.Send(ptcC2G_QueryRoleStateReq);
					}
				}
			}
		}

		public void OnQueryRoleStates(QueryRoleStateAck data)
		{
			bool flag = data.roleids.Count != data.state.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("data.roleids.Count != data.state.Count ", data.roleids.Count.ToString(), " != ", data.state.Count.ToString(), null, null);
			}
			else
			{
				for (int i = 0; i < data.roleids.Count; i++)
				{
					this.m_StateMgr.SetState(data.roleids[i], (XTeamMonitorState)data.state[i]);
				}
			}
		}

		public void TemporarilyHide(bool bHide)
		{
			this.m_bTempHide = bHide;
			this.OnTeamInfoChanged();
		}

		public void TeamInfoChangeOnBattle(XTeam team)
		{
			bool flag = team == null;
			if (flag)
			{
				this._teamList.Clear();
				this.OnTeamInfoChanged();
			}
			else
			{
				bool flag2 = team.members.Count != this._teamList.Count;
				if (flag2)
				{
					int count = this._teamList.Count;
					bool flag3 = team.members.Count < count;
					if (flag3)
					{
						for (int i = count - 1; i >= team.members.Count; i--)
						{
							this._teamList.RemoveAt(i);
						}
					}
					else
					{
						for (int j = count; j < team.members.Count; j++)
						{
							XTeamBloodUIData item = new XTeamBloodUIData();
							this._teamList.Add(item);
						}
					}
				}
				for (int k = 0; k < this._teamList.Count; k++)
				{
					this._teamList[k].uid = team.members[k].uid;
					this._teamList[k].entityID = team.members[k].entityID;
					this._teamList[k].level = (uint)team.members[k].level;
					this._teamList[k].name = team.members[k].name;
					this._teamList[k].profession = team.members[k].profession;
					this._teamList[k].bIsLeader = team.members[k].bIsLeader;
				}
				this.OnTeamInfoChanged();
			}
		}

		public void TeamInfoChangeOnSpectate(List<XTeamBloodUIData> list)
		{
			bool flag = list.Count != this._teamList.Count;
			if (flag)
			{
				int count = this._teamList.Count;
				bool flag2 = list.Count < count;
				if (flag2)
				{
					for (int i = count - 1; i >= list.Count; i--)
					{
						this._teamList.RemoveAt(i);
					}
				}
				else
				{
					for (int j = count; j < list.Count; j++)
					{
						XTeamBloodUIData item = new XTeamBloodUIData();
						this._teamList.Add(item);
					}
				}
			}
			for (int k = 0; k < this._teamList.Count; k++)
			{
				this._teamList[k] = list[k];
			}
			this.OnTeamInfoChanged();
		}

		public void InitWhenShowMainUIByTeam(XTeam team)
		{
			this.InitWhenShowMainUI();
			this.TeamInfoChangeOnBattle(team);
		}

		public void InitWhenShowMainUIByBloodList(List<XTeamBloodUIData> list)
		{
			this.InitWhenShowMainUI();
			this.TeamInfoChangeOnSpectate(list);
		}

		public void InitWhenShowMainUI()
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			SceneType type = (SceneType)sceneData.type;
			if (type <= SceneType.SCENE_TOWER)
			{
				if (type == SceneType.SCENE_ABYSSS)
				{
					this.m_bShowMonitor = (XSingleton<XGame>.singleton.SyncMode || XSingleton<XLevelSpawnMgr>.singleton.HasRobot);
					goto IL_8A;
				}
				if (type != SceneType.SCENE_TOWER)
				{
					goto IL_78;
				}
			}
			else if (type != SceneType.SCENE_GMF && type != SceneType.SCENE_GPR && type != SceneType.SCENE_LEAGUE_BATTLE)
			{
				goto IL_78;
			}
			this.m_bShowMonitor = XSingleton<XScene>.singleton.bSpectator;
			goto IL_8A;
			IL_78:
			this.m_bShowMonitor = XSingleton<XGame>.singleton.SyncMode;
			IL_8A:
			this.m_bTempHide = false;
			bool flag = !XSingleton<XScene>.singleton.bSpectator;
			if (flag)
			{
				byte teamInfoDefaultTab = sceneData.TeamInfoDefaultTab;
				if (teamInfoDefaultTab != 0)
				{
					if (teamInfoDefaultTab == 1)
					{
						this.m_RankCheckBox.bChecked = true;
					}
				}
				else
				{
					this.m_TeamCheckBox.bChecked = true;
				}
			}
		}

		public void OnTeamInfoChanged()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag)
			{
				base.SetVisible(false);
			}
			else
			{
				bool flag2 = (!XSingleton<XScene>.singleton.bSpectator && !this._TeamDoc.bInTeam && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_PVP && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_HEROBATTLE && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_PKTWO && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_CRAZYBOMB && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_GHOSTACTION && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_HORSERACING && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_WEEKEND4V4_DUCK) || !this.m_bShowMonitor || this.m_bTempHide;
				if (flag2)
				{
					base.SetVisible(false);
				}
				else
				{
					bool flag3 = (this._TeamDoc.bInTeam || XSingleton<XScene>.singleton.bSpectator || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PKTWO || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_GHOSTACTION || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_DUCK) && !this.active;
					if (flag3)
					{
						base.SetVisible(true);
					}
					bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
					int num;
					if (bSpectator)
					{
						num = this._teamList.Count;
					}
					else
					{
						num = this._teamList.Count - 1;
					}
					this.m_StateMgr.SetTotalCount(this._teamList);
					bool flag4 = this.m_Members.Count < num;
					if (flag4)
					{
						for (int i = this.m_Members.Count; i < num; i++)
						{
							XTeamMemberMonitor xteamMemberMonitor = new XTeamMemberMonitor(this.m_StateMgr);
							GameObject gameObject = this.m_TeamUIPool.FetchGameObject(false);
							gameObject.transform.localPosition = new Vector3(this.m_TeamUIPool.TplPos.x, this.m_TeamUIPool.TplPos.y - (float)(this.m_TeamUIPool.TplHeight * i));
							xteamMemberMonitor.SetGo(gameObject);
							this.m_Members.Add(xteamMemberMonitor);
						}
					}
					int j = 0;
					int num2 = 0;
					while (num2 < this._teamList.Count && j < this.m_Members.Count)
					{
						bool flag5 = this._teamList[num2].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (!flag5)
						{
							this.m_Members[j].SetMemberData(this._teamList[num2]);
							this.m_Members[j].SetActive(true);
							j++;
						}
						num2++;
					}
					while (j < num)
					{
						this.m_Members[j].SetMemberData(null);
						this.m_Members[j].SetActive(true);
						j++;
					}
					while (j < this.m_Members.Count)
					{
						this.m_Members[j].SetActive(false);
						j++;
					}
					this.HideVoice();
				}
			}
		}

		public void OnTeamMemberBuffChange(ulong memberID, List<UIBuffInfo> buff)
		{
			for (int i = 0; i < this.m_Members.Count; i++)
			{
				bool flag = this.m_Members[i].EntityID == memberID;
				if (flag)
				{
					this.m_Members[i].OnBuffChange(buff);
				}
			}
		}

		public void CheckToggleState()
		{
			for (int i = 0; i < this.m_Members.Count; i++)
			{
				this.m_Members[i].CheckToggleState();
			}
		}

		public void RefreshVoice(ulong[] roleids, int[] states)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				for (int i = 0; i < roleids.Length; i++)
				{
					this.Play(roleids[i], states[i]);
				}
			}
		}

		public void HideVoice()
		{
			for (int i = 0; i < this.m_Members.Count; i++)
			{
				this.m_Members[i].PlaySound(0);
			}
		}

		private void Play(ulong roleid, int state)
		{
			for (int i = 0; i < this.m_Members.Count; i++)
			{
				bool flag = this.m_Members[i].EntityID == roleid;
				if (flag)
				{
					this.m_Members[i].PlaySound(state);
					break;
				}
			}
		}

		private XTeamDocument _TeamDoc;

		private XUIPool m_TeamUIPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<XTeamMemberMonitor> m_Members = new List<XTeamMemberMonitor>();

		private XTeamMonitorStateMgr m_StateMgr = new XTeamMonitorStateMgr();

		private float m_LastStateQueryTime = 0f;

		private bool m_bShowMonitor = true;

		private bool m_bTempHide = false;

		public XSceneDamageRankHandler m_DamageRankHandler;

		private GameObject m_TeamGo;

		private IXUICheckBox m_RankCheckBox;

		private IXUICheckBox m_TeamCheckBox;

		private List<XTeamBloodUIData> _teamList = new List<XTeamBloodUIData>();
	}
}
