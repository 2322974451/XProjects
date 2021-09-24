using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XWeekendPartyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XWeekendPartyDocument.uuID;
			}
		}

		public List<WeekendPartyBattleRoleInfo> SelfWeekendPartyBattleList
		{
			get
			{
				return this._selfWeekendPartyBattleList;
			}
		}

		public uint CurrActID
		{
			get
			{
				return this._currActID;
			}
		}

		public uint SelfScore
		{
			get
			{
				return this._selfScore;
			}
		}

		public uint EnemyScore
		{
			get
			{
				return this._enemyScore;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XWeekendPartyDocument.AsyncLoader.AddTask("Table/WeekEnd4v4List", XWeekendPartyDocument._weekendPartyTable, false);
			XWeekendPartyDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnDeath));
		}

		private bool OnDeath(XEventArgs e)
		{
			XRealDeadEventArgs xrealDeadEventArgs = e as XRealDeadEventArgs;
			bool flag = !xrealDeadEventArgs.TheDead.IsPlayer;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_GHOSTACTION || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_DUCK;
				if (flag2)
				{
					bool flag3 = this.WeekendPartyBattleHandler != null && this.WeekendPartyBattleHandler.IsVisible();
					if (flag3)
					{
						WeekEnd4v4List.RowData activityInfo = this.GetActivityInfo(this.CurrActID);
						bool flag4 = activityInfo != null;
						if (flag4)
						{
							this.WeekendPartyBattleHandler.ShowReviveUI(activityInfo.ReviveSeconds);
						}
					}
				}
				result = true;
			}
			return result;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.ReqWeekendPartInfo();
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._selfCamp = 0U;
			this._selfScore = 0U;
			this._enemyScore = 0U;
			this._selfWeekendPartyBattleList.Clear();
			this._allWeekendPartyBattleList.Clear();
			this.TeamBlood.Clear();
		}

		public bool CheckIsOpen(uint sceneID)
		{
			for (int i = 0; i < XWeekendPartyDocument._weekendPartyTable.Table.Length; i++)
			{
				bool flag = XWeekendPartyDocument._weekendPartyTable.Table[i].SceneID == sceneID && XWeekendPartyDocument._weekendPartyTable.Table[i].ID == this.CurrActID;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_WeekendParty, true);
			}
		}

		public void ReqWeekendPartInfo()
		{
			RpcC2G_WeekEnd4v4GetInfo rpc = new RpcC2G_WeekEnd4v4GetInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnGetWeekendPartyInfo(WeekEnd4v4GetInfoRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this._currActID = oRes.thisActivityID;
				DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.singleton.RefreshActivityInfo(oRes);
			}
		}

		public WeekEnd4v4List.RowData GetActivityInfo(uint id)
		{
			for (int i = 0; i < XWeekendPartyDocument._weekendPartyTable.Table.Length; i++)
			{
				bool flag = XWeekendPartyDocument._weekendPartyTable.Table[i].ID == id;
				if (flag)
				{
					return XWeekendPartyDocument._weekendPartyTable.Table[i];
				}
			}
			return null;
		}

		public void OnWeekendPartyBattleInfoNtf(WeekEnd4v4BattleAllRoleData battleAllRoleInfo)
		{
			bool flag = battleAllRoleInfo == null || battleAllRoleInfo.roleData == null;
			if (!flag)
			{
				bool flag2 = this._selfCamp == 0U;
				if (flag2)
				{
					for (int i = 0; i < battleAllRoleInfo.roleData.Count; i++)
					{
						bool flag3 = battleAllRoleInfo.roleData[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag3)
						{
							this._selfCamp = battleAllRoleInfo.roleData[i].redblue;
							break;
						}
					}
				}
				for (int j = 0; j < battleAllRoleInfo.roleData.Count; j++)
				{
					bool flag4 = !this.UpdateBattleRoleInfo(battleAllRoleInfo.roleData[j]);
					if (flag4)
					{
						WeekendPartyBattleRoleInfo weekendPartyBattleRoleInfo = new WeekendPartyBattleRoleInfo();
						weekendPartyBattleRoleInfo.roleID = battleAllRoleInfo.roleData[j].roleid;
						weekendPartyBattleRoleInfo.redBlue = battleAllRoleInfo.roleData[j].redblue;
						weekendPartyBattleRoleInfo.score = battleAllRoleInfo.roleData[j].score;
						weekendPartyBattleRoleInfo.kill = battleAllRoleInfo.roleData[j].killCount;
						weekendPartyBattleRoleInfo.beKilled = battleAllRoleInfo.roleData[j].bekilledCount;
						bool flag5 = battleAllRoleInfo.roleData[j].profession > 0U;
						if (flag5)
						{
							weekendPartyBattleRoleInfo.RoleProf = (int)battleAllRoleInfo.roleData[j].profession;
						}
						bool flag6 = battleAllRoleInfo.roleData[j].rolelevel > 0U;
						if (flag6)
						{
							weekendPartyBattleRoleInfo.level = battleAllRoleInfo.roleData[j].rolelevel;
						}
						bool flag7 = battleAllRoleInfo.roleData[j].rolename != null && battleAllRoleInfo.roleData[j].rolename != "";
						if (flag7)
						{
							weekendPartyBattleRoleInfo.roleName = battleAllRoleInfo.roleData[j].rolename;
						}
						else
						{
							weekendPartyBattleRoleInfo.roleName = "";
						}
						this._allWeekendPartyBattleList.Add(weekendPartyBattleRoleInfo);
					}
					bool flag8 = battleAllRoleInfo.roleData[j].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag8)
					{
						bool flag9 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && battleAllRoleInfo.roleData[j].timeSeconds > 0U;
						if (flag9)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(battleAllRoleInfo.roleData[j].timeSeconds, -1);
						}
					}
				}
				this._allWeekendPartyBattleList.Sort(new Comparison<WeekendPartyBattleRoleInfo>(XWeekendPartyDocument.SortRoleRank));
				this.CalculateTeamScore();
				bool flag10 = this.WeekendPartyBattleHandler != null && this.WeekendPartyBattleHandler.IsVisible();
				if (flag10)
				{
					this.WeekendPartyBattleHandler.RefreshWeekendPartyBattleData();
				}
				bool flag11 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
				if (flag11)
				{
					bool flag12 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
					if (flag12)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.TeamInfoChangeOnSpectate(this.TeamBlood);
						bool flag13 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.m_DamageRankHandler != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.m_DamageRankHandler.IsVisible();
						if (flag13)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.m_DamageRankHandler.RefreshWeekendPartRank();
						}
					}
				}
			}
		}

		private bool UpdateBattleRoleInfo(WeekEnd4v4BattleRoleData battleRole)
		{
			for (int i = 0; i < this._allWeekendPartyBattleList.Count; i++)
			{
				bool flag = this._allWeekendPartyBattleList[i].roleID == battleRole.roleid;
				if (flag)
				{
					this._allWeekendPartyBattleList[i].redBlue = battleRole.redblue;
					this._allWeekendPartyBattleList[i].score = battleRole.score;
					this._allWeekendPartyBattleList[i].kill = battleRole.killCount;
					this._allWeekendPartyBattleList[i].beKilled = battleRole.bekilledCount;
					bool flag2 = battleRole.rolename != null && battleRole.rolename != "";
					if (flag2)
					{
						this._allWeekendPartyBattleList[i].roleName = battleRole.rolename;
					}
					bool flag3 = battleRole.profession > 0U;
					if (flag3)
					{
						this._allWeekendPartyBattleList[i].RoleProf = (int)battleRole.profession;
					}
					bool flag4 = battleRole.rolelevel > 0U;
					if (flag4)
					{
						this._allWeekendPartyBattleList[i].level = battleRole.rolelevel;
					}
					return true;
				}
			}
			return false;
		}

		private void CalculateTeamScore()
		{
			this.TeamBlood.Clear();
			this._selfScore = 0U;
			this._enemyScore = 0U;
			this._selfWeekendPartyBattleList.Clear();
			for (int i = 0; i < this._allWeekendPartyBattleList.Count; i++)
			{
				this._allWeekendPartyBattleList[i].Rank = i + 1;
				bool flag = this._allWeekendPartyBattleList[i].redBlue == this._selfCamp;
				if (flag)
				{
					this._selfScore += this._allWeekendPartyBattleList[i].score;
					this._selfWeekendPartyBattleList.Add(this._allWeekendPartyBattleList[i]);
					this.TeamBlood.Add(this.Turn2TeamBloodData(this._allWeekendPartyBattleList[i]));
				}
				else
				{
					this._enemyScore += this._allWeekendPartyBattleList[i].score;
				}
			}
		}

		private XTeamBloodUIData Turn2TeamBloodData(WeekendPartyBattleRoleInfo data)
		{
			return new XTeamBloodUIData
			{
				uid = data.roleID,
				entityID = data.roleID,
				level = data.level,
				name = data.roleName,
				bIsLeader = false,
				profession = (RoleType)data.RoleProf
			};
		}

		public static int SortRoleRank(WeekendPartyBattleRoleInfo info1, WeekendPartyBattleRoleInfo info2)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE;
			int result;
			if (flag)
			{
				bool flag2 = info1.beKilled == info2.beKilled;
				if (flag2)
				{
					result = info1.roleName.CompareTo(info2.roleName);
				}
				else
				{
					result = (int)(info1.beKilled - info2.beKilled);
				}
			}
			else
			{
				bool flag3 = info2.score == info1.score;
				if (flag3)
				{
					result = info2.roleName.CompareTo(info1.roleName);
				}
				else
				{
					result = (int)(info2.score - info1.score);
				}
			}
			return result;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("WeekendPartyDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static WeekEnd4v4List _weekendPartyTable = new WeekEnd4v4List();

		public bool MainInterfaceState = false;

		private List<WeekendPartyBattleRoleInfo> _selfWeekendPartyBattleList = new List<WeekendPartyBattleRoleInfo>();

		private List<WeekendPartyBattleRoleInfo> _allWeekendPartyBattleList = new List<WeekendPartyBattleRoleInfo>();

		public WeekendPartyHandler WeekendPartyBattleHandler;

		private uint _selfCamp = 0U;

		private uint _currActID = 0U;

		private uint _selfScore = 0U;

		private uint _enemyScore = 0U;

		public List<XTeamBloodUIData> TeamBlood = new List<XTeamBloodUIData>();
	}
}
