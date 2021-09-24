using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildMineBattleDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildMineBattleDocument.uuID;
			}
		}

		public XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData> UserIdToRole
		{
			get
			{
				return this._UserIdToRole;
			}
		}

		public uint MyTeam
		{
			get
			{
				return this._MyTeam;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildMineBattleDocument.AsyncLoader.AddTask("Table/GuildMineralBattleReward", XGuildMineBattleDocument._GuildMineralBattleRewardTable, false);
			XGuildMineBattleDocument.AsyncLoader.Execute(callback);
		}

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

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_RESWAR_PVE;
			if (flag)
			{
				this.ReqGuildMinePVEAllInfo();
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

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

		public void ReqGuildMinePVPAllInfo()
		{
			RpcC2G_ResWarAllInfoReqOne rpc = new RpcC2G_ResWarAllInfoReqOne();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqGuildMinePVEAllInfo()
		{
			RpcC2G_ResWarBuff rpc = new RpcC2G_ResWarBuff();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SetBattleInfo(PtcG2C_ResWarBattleDataNtf roPtc)
		{
			this.SetBattleInfo(roPtc.Data);
		}

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

		public void SetBattleAllInfo(ResWarArg oArg, ResWarRes oRes)
		{
			this.SetBattleTeamInfo(oRes.baseinfo);
			this.SetBattleInfo(oRes.allinfo);
		}

		public void HideVSInfo()
		{
			bool flag = this.InfoHandler != null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("HideVSInfo", null, null, null, null, null);
				this.InfoHandler.CloseTween(null);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildMineBattleDocument");

		public GuildMinePVPBattleHandler BattleHandler = null;

		public GuildMinePVPInfoHandler InfoHandler = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData> _UserIdToRole = new XBetterDictionary<ulong, XGuildMineBattleDocument.RoleData>(0);

		private static GuildMineralBattleReward _GuildMineralBattleRewardTable = new GuildMineralBattleReward();

		private uint _MyTeam = 0U;

		private bool _CanPlayAnim = false;

		public struct RoleData
		{

			public ulong uid;

			public string name;

			public uint teamID;

			public uint lv;

			public uint job;

			public uint ppt;

			public ulong guildID;

			public string guildname;
		}
	}
}
