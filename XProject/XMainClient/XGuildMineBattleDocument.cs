using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000934 RID: 2356
	internal class XGuildMineBattleDocument : XDocComponent
	{
		// Token: 0x17002BE7 RID: 11239
		// (get) Token: 0x06008E49 RID: 36425 RVA: 0x0013A860 File Offset: 0x00138A60
		public override uint ID
		{
			get
			{
				return XGuildMineBattleDocument.uuID;
			}
		}

		// Token: 0x17002BE8 RID: 11240
		// (get) Token: 0x06008E4A RID: 36426 RVA: 0x0013A878 File Offset: 0x00138A78
		public XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData> UserIdToRole
		{
			get
			{
				return this._UserIdToRole;
			}
		}

		// Token: 0x17002BE9 RID: 11241
		// (get) Token: 0x06008E4B RID: 36427 RVA: 0x0013A890 File Offset: 0x00138A90
		public uint MyTeam
		{
			get
			{
				return this._MyTeam;
			}
		}

		// Token: 0x06008E4C RID: 36428 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008E4D RID: 36429 RVA: 0x0013A8A8 File Offset: 0x00138AA8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildMineBattleDocument.AsyncLoader.AddTask("Table/GuildMineralBattleReward", XGuildMineBattleDocument._GuildMineralBattleRewardTable, false);
			XGuildMineBattleDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008E4E RID: 36430 RVA: 0x0013A8D0 File Offset: 0x00138AD0
		public static GuildMineralBattleReward.RowData GetReward(uint rankId)
		{
			GuildMineralBattleReward.RowData rowData = null;
			for (int i = 0; i < XGuildMineBattleDocument._GuildMineralBattleRewardTable.Table.Length; i++)
			{
				bool flag = XGuildMineBattleDocument._GuildMineralBattleRewardTable.Table[i].LevelSeal <= XLevelSealDocument.Doc.SealType && XGuildMineBattleDocument._GuildMineralBattleRewardTable.Table[i].Rank == rankId;
				if (flag)
				{
					rowData = XGuildMineBattleDocument._GuildMineralBattleRewardTable.Table[i];
				}
			}
			bool flag2 = rowData == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"_GuildMineralBattleRewardTable No Find\nSealType",
					XLevelSealDocument.Doc.SealType,
					"  Rank:",
					rankId
				}), null, null, null, null, null);
			}
			return rowData;
		}

		// Token: 0x06008E4F RID: 36431 RVA: 0x0013A99C File Offset: 0x00138B9C
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVE;
			if (flag)
			{
				this.ReqGuildMinePVEAllInfo();
			}
		}

		// Token: 0x06008E50 RID: 36432 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008E51 RID: 36433 RVA: 0x0013A9C8 File Offset: 0x00138BC8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVP;
			if (flag)
			{
				this.ReqGuildMinePVPAllInfo();
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVE;
			if (flag2)
			{
				this.ReqGuildMinePVEAllInfo();
			}
		}

		// Token: 0x06008E52 RID: 36434 RVA: 0x0013AA0C File Offset: 0x00138C0C
		private void PlayStartTween()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVP;
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
				}
			}
		}

		// Token: 0x06008E53 RID: 36435 RVA: 0x0013AA5C File Offset: 0x00138C5C
		public void ReqGuildMinePVPAllInfo()
		{
			RpcC2G_ResWarAllInfoReqOne rpc = new RpcC2G_ResWarAllInfoReqOne();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008E54 RID: 36436 RVA: 0x0013AA7C File Offset: 0x00138C7C
		public void ReqGuildMinePVEAllInfo()
		{
			RpcC2G_ResWarBuff rpc = new RpcC2G_ResWarBuff();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008E55 RID: 36437 RVA: 0x0013AA9C File Offset: 0x00138C9C
		public void SetBattleTeamInfo(PtcG2C_ResWarTeamResOne roPtc)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("PlayVSTween", null, null, null, null, null);
			bool flag = roPtc.Data == null;
			if (!flag)
			{
				this.SetBattleTeamInfo(roPtc.Data);
				this._CanPlayAnim = true;
				this.PlayStartTween();
			}
		}

		// Token: 0x06008E56 RID: 36438 RVA: 0x0013AAEC File Offset: 0x00138CEC
		public void SetBattleTeamInfo(ResWarAllTeamBaseInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this._UserIdToRole.Clear();
				for (int i = 0; i < data.info.Count; i++)
				{
					XGuildMineBattleDocument.RoleData roleData;
					roleData.uid = data.info[i].uid;
					roleData.name = data.info[i].name;
					roleData.job = data.info[i].job;
					roleData.lv = data.info[i].lv;
					roleData.teamID = data.info[i].teamid;
					roleData.ppt = data.info[i].ppt;
					roleData.guildID = data.info[i].guildid;
					roleData.guildname = data.info[i].guildname;
					this._UserIdToRole.Add(roleData.uid, roleData);
					bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID == roleData.uid;
					if (flag2)
					{
						this._MyTeam = roleData.teamID;
					}
				}
				bool flag3 = this._MyTeam == 0U;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("No Find My Team", null, null, null, null, null);
				}
			}
		}

		// Token: 0x06008E57 RID: 36439 RVA: 0x0013AC57 File Offset: 0x00138E57
		public void SetBattleInfo(PtcG2C_ResWarBattleDataNtf roPtc)
		{
			this.SetBattleInfo(roPtc.Data);
		}

		// Token: 0x06008E58 RID: 36440 RVA: 0x0013AC68 File Offset: 0x00138E68
		public void SetBattleInfo(ResWarAllInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				bool flag2 = this.BattleHandler == null;
				if (!flag2)
				{
					this.BattleHandler.RefreshStatusTime(data.lefttime);
					XSingleton<XDebug>.singleton.AddGreenLog("lefttime" + data.lefttime, null, null, null, null, null);
					List<ResWarGroupData> groupdata = data.groupdata;
					for (int i = 0; i < groupdata.Count; i++)
					{
						this.BattleHandler.SetDamage((ulong)groupdata[i].totaldamage, groupdata[i].teamid == this._MyTeam);
						this.BattleHandler.SetScore(groupdata[i].killcount, groupdata[i].teamid == this._MyTeam);
					}
				}
			}
		}

		// Token: 0x06008E59 RID: 36441 RVA: 0x0013AD45 File Offset: 0x00138F45
		public void SetBattleAllInfo(ResWarArg oArg, ResWarRes oRes)
		{
			this.SetBattleTeamInfo(oRes.baseinfo);
			this.SetBattleInfo(oRes.allinfo);
		}

		// Token: 0x06008E5A RID: 36442 RVA: 0x0013AD64 File Offset: 0x00138F64
		public void HideVSInfo()
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.InfoHandler.CloseTween(null);
			}
		}

		// Token: 0x04002E5E RID: 11870
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineBattleDocument");

		// Token: 0x04002E5F RID: 11871
		public GuildMinePVPBattleHandler BattleHandler = null;

		// Token: 0x04002E60 RID: 11872
		public GuildMinePVPInfoHandler InfoHandler = null;

		// Token: 0x04002E61 RID: 11873
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002E62 RID: 11874
		private XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData> _UserIdToRole = new XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData>(0);

		// Token: 0x04002E63 RID: 11875
		private static GuildMineralBattleReward _GuildMineralBattleRewardTable = new GuildMineralBattleReward();

		// Token: 0x04002E64 RID: 11876
		private uint _MyTeam = 0U;

		// Token: 0x04002E65 RID: 11877
		private bool _CanPlayAnim = false;

		// Token: 0x02001960 RID: 6496
		public struct RoleData
		{
			// Token: 0x04007DF2 RID: 32242
			public ulong uid;

			// Token: 0x04007DF3 RID: 32243
			public string name;

			// Token: 0x04007DF4 RID: 32244
			public uint teamID;

			// Token: 0x04007DF5 RID: 32245
			public uint lv;

			// Token: 0x04007DF6 RID: 32246
			public uint job;

			// Token: 0x04007DF7 RID: 32247
			public uint ppt;

			// Token: 0x04007DF8 RID: 32248
			public ulong guildID;

			// Token: 0x04007DF9 RID: 32249
			public string guildname;
		}
	}
}
