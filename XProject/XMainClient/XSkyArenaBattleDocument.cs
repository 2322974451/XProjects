using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200096D RID: 2413
	internal class XSkyArenaBattleDocument : XDocComponent
	{
		// Token: 0x17002C63 RID: 11363
		// (get) Token: 0x0600915E RID: 37214 RVA: 0x0014D2B8 File Offset: 0x0014B4B8
		public override uint ID
		{
			get
			{
				return XSkyArenaBattleDocument.uuID;
			}
		}

		// Token: 0x17002C64 RID: 11364
		// (get) Token: 0x0600915F RID: 37215 RVA: 0x0014D2D0 File Offset: 0x0014B4D0
		public ulong myId
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			}
		}

		// Token: 0x17002C65 RID: 11365
		// (get) Token: 0x06009160 RID: 37216 RVA: 0x0014D2F4 File Offset: 0x0014B4F4
		public int MyTeam
		{
			get
			{
				return this._MyTeam;
			}
		}

		// Token: 0x17002C66 RID: 11366
		// (get) Token: 0x06009161 RID: 37217 RVA: 0x0014D30C File Offset: 0x0014B50C
		public uint Floor
		{
			get
			{
				return this._Floor;
			}
		}

		// Token: 0x17002C67 RID: 11367
		// (get) Token: 0x06009162 RID: 37218 RVA: 0x0014D324 File Offset: 0x0014B524
		public uint Stage
		{
			get
			{
				return this._Stage;
			}
		}

		// Token: 0x17002C68 RID: 11368
		// (get) Token: 0x06009163 RID: 37219 RVA: 0x0014D33C File Offset: 0x0014B53C
		public XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData> UserIdToRole
		{
			get
			{
				return this._UserIdToRole;
			}
		}

		// Token: 0x06009164 RID: 37220 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009165 RID: 37221 RVA: 0x0014D354 File Offset: 0x0014B554
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

		// Token: 0x06009166 RID: 37222 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x06009167 RID: 37223 RVA: 0x0014D400 File Offset: 0x0014B600
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_FIGHTING;
			if (flag)
			{
				this.ReqSkyArenaBattleAllInfo();
			}
		}

		// Token: 0x06009168 RID: 37224 RVA: 0x0014D42C File Offset: 0x0014B62C
		public void ReqSkyArenaBattleAllInfo()
		{
			RpcC2G_SkyCityAllInfoReq rpc = new RpcC2G_SkyCityAllInfoReq();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009169 RID: 37225 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600916A RID: 37226 RVA: 0x0014D44C File Offset: 0x0014B64C
		public void SetBattleTeamInfo(PtcG2C_SkyCityTeamRes roPtc)
		{
			bool flag = roPtc.Data == null;
			if (!flag)
			{
				this.SetBattleTeamInfo(roPtc.Data);
				this._CanPlayAnim = true;
			}
		}

		// Token: 0x0600916B RID: 37227 RVA: 0x0014D480 File Offset: 0x0014B680
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

		// Token: 0x0600916C RID: 37228 RVA: 0x0014D5E2 File Offset: 0x0014B7E2
		public void SetBattleInfo(PtcG2C_SkyCityBattleDataNtf roPtc)
		{
			this.SetBattleInfo(roPtc.Data);
		}

		// Token: 0x0600916D RID: 37229 RVA: 0x0014D5F4 File Offset: 0x0014B7F4
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

		// Token: 0x0600916E RID: 37230 RVA: 0x0014D6D0 File Offset: 0x0014B8D0
		public void SetBattleAllInfo(SkyCityArg oArg, SkyCityRes oRes)
		{
			this.SetBattleTeamInfo(oRes.baseinfo);
			this.SetBattleInfo(oRes.allinfo);
		}

		// Token: 0x0600916F RID: 37231 RVA: 0x0014D6F0 File Offset: 0x0014B8F0
		public void SetBattleEndInfo(PtcG2C_SkyCityEstimateRes roPtc)
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				this.InfoHandler.PlayEndTween(roPtc.Data);
			}
		}

		// Token: 0x06009170 RID: 37232 RVA: 0x0014D720 File Offset: 0x0014B920
		public void HideVSInfo()
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.InfoHandler.CloseTween();
			}
		}

		// Token: 0x06009171 RID: 37233 RVA: 0x0014D760 File Offset: 0x0014B960
		public void HideTime()
		{
			bool flag = this.BattleHandler != null;
			if (flag)
			{
				this.BattleHandler.HideTime();
			}
		}

		// Token: 0x06009172 RID: 37234 RVA: 0x0014D78C File Offset: 0x0014B98C
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

		// Token: 0x04003050 RID: 12368
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSkyArenaBattleDocument");

		// Token: 0x04003051 RID: 12369
		public SkyArenaBattleHandler BattleHandler = null;

		// Token: 0x04003052 RID: 12370
		public SkyArenaInfoHandler InfoHandler = null;

		// Token: 0x04003053 RID: 12371
		private int _MyTeam = 0;

		// Token: 0x04003054 RID: 12372
		private uint _Floor = 0U;

		// Token: 0x04003055 RID: 12373
		private uint _Stage = 0U;

		// Token: 0x04003056 RID: 12374
		public uint ShowAddStage = 0U;

		// Token: 0x04003057 RID: 12375
		private XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData> _UserIdToRole = new XBetterDictionary<ulong, XSkyArenaBattleDocument.RoleData>(0);

		// Token: 0x04003058 RID: 12376
		private bool _CanPlayAnim = false;

		// Token: 0x02001965 RID: 6501
		public struct RoleData
		{
			// Token: 0x04007E09 RID: 32265
			public ulong uid;

			// Token: 0x04007E0A RID: 32266
			public string name;

			// Token: 0x04007E0B RID: 32267
			public int teamid;

			// Token: 0x04007E0C RID: 32268
			public uint lv;

			// Token: 0x04007E0D RID: 32269
			public uint job;

			// Token: 0x04007E0E RID: 32270
			public uint ppt;

			// Token: 0x04007E0F RID: 32271
			public bool online;
		}
	}
}
