using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkyArenaBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSkyArenaBattleDocument.uuID;
			}
		}

		public ulong myId
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			}
		}

		public int MyTeam
		{
			get
			{
				return this._MyTeam;
			}
		}

		public uint Floor
		{
			get
			{
				return this._Floor;
			}
		}

		public uint Stage
		{
			get
			{
				return this._Stage;
			}
		}

		public XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData> UserIdToRole
		{
			get
			{
				return this._UserIdToRole;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_FIGHTING;
			if (flag)
			{
				bool flag2 = this.InfoHandler == null;
				if (!flag2)
				{
					bool canPlayAnim = this._CanPlayAnim;
					if (canPlayAnim)
					{
						this.InfoHandler.PlayStartTween();
						this._CanPlayAnim = false;
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("No Receive TeamData", null, null, null, null, null);
						this.ReqSkyArenaBattleAllInfo();
					}
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SkyAreanStage.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_STAGE"), this.Stage.ToString()));
				}
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_FIGHTING;
			if (flag)
			{
				this.ReqSkyArenaBattleAllInfo();
			}
		}

		public void ReqSkyArenaBattleAllInfo()
		{
			RpcC2G_SkyCityAllInfoReq rpc = new RpcC2G_SkyCityAllInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public void SetBattleTeamInfo(PtcG2C_SkyCityTeamRes roPtc)
		{
			bool flag = roPtc.Data == null;
			if (!flag)
			{
				this.SetBattleTeamInfo(roPtc.Data);
				this._CanPlayAnim = true;
			}
		}

		public void SetBattleTeamInfo(SkyCityAllTeamBaseInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._Stage = data.games;
				this._Floor = data.floor;
				this._UserIdToRole.Clear();
				for (int i = 0; i < data.info.Count; i++)
				{
					XSkyArenaBattleDocument.RoleData roleData;
					roleData.uid = data.info[i].uid;
					roleData.name = data.info[i].name;
					roleData.job = data.info[i].job;
					roleData.lv = data.info[i].lv;
					roleData.online = data.info[i].online;
					roleData.ppt = data.info[i].ppt;
					roleData.teamid = data.info[i].teamid;
					this._UserIdToRole.Add(roleData.uid, roleData);
					bool flag2 = this.myId == roleData.uid;
					if (flag2)
					{
						this._MyTeam = roleData.teamid;
					}
				}
				bool flag3 = this._MyTeam == 0;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("No Find My Team", null, null, null, null, null);
				}
			}
		}

		public void SetBattleInfo(PtcG2C_SkyCityBattleDataNtf roPtc)
		{
			this.SetBattleInfo(roPtc.Data);
		}

		public void SetBattleInfo(SkyCityAllInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				bool flag2 = this.BattleHandler == null;
				if (!flag2)
				{
					this.BattleHandler.RefreshStatusTime(data.timetype, data.lefttime);
					bool flag3 = data.timetype == SkyCityTimeType.SecondWaiting;
					if (!flag3)
					{
						List<SkyCityGroupData> groupdata = data.groupdata;
						for (int i = 0; i < groupdata.Count; i++)
						{
							this.BattleHandler.SetDamage((ulong)groupdata[i].totaldamage, (ulong)groupdata[i].teamid == (ulong)((long)this._MyTeam));
							this.BattleHandler.SetScore(groupdata[i].killcount, (ulong)groupdata[i].teamid == (ulong)((long)this._MyTeam));
						}
					}
				}
			}
		}

		public void SetBattleAllInfo(SkyCityArg oArg, SkyCityRes oRes)
		{
			this.SetBattleTeamInfo(oRes.baseinfo);
			this.SetBattleInfo(oRes.allinfo);
		}

		public void SetBattleEndInfo(PtcG2C_SkyCityEstimateRes roPtc)
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				this.InfoHandler.PlayEndTween(roPtc.Data);
			}
		}

		public void HideVSInfo()
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.InfoHandler.CloseTween();
			}
		}

		public void HideTime()
		{
			bool flag = this.BattleHandler != null;
			if (flag)
			{
				this.BattleHandler.HideTime();
			}
		}

		public void StageEnd()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour == null;
			if (!flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SkyAreanStage != null;
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SkyAreanStage.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SKY_ARENA_STAGE"), (this.Stage + 1U).ToString()));
				}
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID + this.ShowAddStage);
				bool flag3 = sceneData != null && DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SceneName != null;
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_SceneName.SetText(sceneData.Comment);
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSkyArenaBattleDocument");

		public SkyArenaBattleHandler BattleHandler = null;

		public SkyArenaInfoHandler InfoHandler = null;

		private int _MyTeam = 0;

		private uint _Floor = 0U;

		private uint _Stage = 0U;

		public uint ShowAddStage = 0U;

		private XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData> _UserIdToRole = new XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData>(0);

		private bool _CanPlayAnim = false;

		public struct RoleData
		{

			public ulong uid;

			public string name;

			public int teamid;

			public uint lv;

			public uint job;

			public uint ppt;

			public bool online;
		}
	}
}
