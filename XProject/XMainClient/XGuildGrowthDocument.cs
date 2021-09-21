using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A14 RID: 2580
	internal class XGuildGrowthDocument : XDocComponent
	{
		// Token: 0x17002EAF RID: 11951
		// (get) Token: 0x06009DF3 RID: 40435 RVA: 0x0019D480 File Offset: 0x0019B680
		public override uint ID
		{
			get
			{
				return XGuildGrowthDocument.uuID;
			}
		}

		// Token: 0x17002EB0 RID: 11952
		// (get) Token: 0x06009DF4 RID: 40436 RVA: 0x0019D498 File Offset: 0x0019B698
		public GuildZiCai GuildZiCaiTableReader
		{
			get
			{
				return XGuildGrowthDocument._guildZiCaiTable;
			}
		}

		// Token: 0x17002EB1 RID: 11953
		// (get) Token: 0x06009DF5 RID: 40437 RVA: 0x0019D4B0 File Offset: 0x0019B6B0
		public List<XGuildGrowthDocument.GuildGrowthBuffData> BuffList
		{
			get
			{
				return XGuildGrowthDocument._buffList;
			}
		}

		// Token: 0x17002EB2 RID: 11954
		// (get) Token: 0x06009DF6 RID: 40438 RVA: 0x0019D4C8 File Offset: 0x0019B6C8
		public List<XGuildGrowthDocument.GuildGrowthRankData> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		// Token: 0x17002EB3 RID: 11955
		// (get) Token: 0x06009DF7 RID: 40439 RVA: 0x0019D4E0 File Offset: 0x0019B6E0
		public List<XGuildGrowthDocument.GuildCrowthRecordData> RecordList
		{
			get
			{
				return this._recordList;
			}
		}

		// Token: 0x17002EB4 RID: 11956
		// (get) Token: 0x06009DF8 RID: 40440 RVA: 0x0019D4F8 File Offset: 0x0019B6F8
		public XGuildGrowthDocument.GuildGrowthRankData MyData
		{
			get
			{
				return this._myData;
			}
		}

		// Token: 0x06009DF9 RID: 40441 RVA: 0x0019D510 File Offset: 0x0019B710
		public void SetPoint(uint resources, uint technology)
		{
			this.ResourcesPoint = resources;
			this.TechnologyPoint = technology;
			bool flag = DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.RefreshList(false);
			}
			bool flag2 = DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.RefreshList(false);
			}
		}

		// Token: 0x06009DFA RID: 40442 RVA: 0x0019D560 File Offset: 0x0019B760
		public void CheckShowItemGet(uint resDelta, uint tecDelta)
		{
			this.ResDeltaPoint += resDelta;
			this.TecDeltaPoint += tecDelta;
			this.ShowDeltaPointGet();
		}

		// Token: 0x06009DFB RID: 40443 RVA: 0x0019D588 File Offset: 0x0019B788
		public void ShowDeltaPointGet()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (!flag)
			{
				bool flag2 = this.ResDeltaPoint > 0U;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetReplaceString("GuildGrowthResDelta", new object[0]), this.ResDeltaPoint), "fece00");
					this.ResDeltaPoint = 0U;
				}
				bool flag3 = this.TecDeltaPoint > 0U;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetReplaceString("GuildGrowthTecDelta", new object[0]), this.TecDeltaPoint), "fece00");
					this.TecDeltaPoint = 0U;
				}
			}
		}

		// Token: 0x06009DFC RID: 40444 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009DFD RID: 40445 RVA: 0x0014E32B File Offset: 0x0014C52B
		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		// Token: 0x06009DFE RID: 40446 RVA: 0x0019D640 File Offset: 0x0019B840
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool autoFindNpc = this.AutoFindNpc;
			if (autoFindNpc)
			{
				this.AutoFindNpc = false;
				bool flag = XSingleton<XScene>.singleton.SceneID == 4U;
				if (flag)
				{
					this.FindNpc();
				}
			}
			this.ShowDeltaPointGet();
		}

		// Token: 0x06009DFF RID: 40447 RVA: 0x0019D68C File Offset: 0x0019B88C
		public void FindNpc()
		{
			XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(19U);
			bool flag = npc == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find guild build npc.", null, null, null, null, null);
			}
			else
			{
				XSingleton<XInput>.singleton.LastNpc = npc;
			}
		}

		// Token: 0x06009E00 RID: 40448 RVA: 0x0019D6D3 File Offset: 0x0019B8D3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildGrowthDocument.AsyncLoader.AddTask("Table/GuildHall", XGuildGrowthDocument._guildHallTable, false);
			XGuildGrowthDocument.AsyncLoader.AddTask("Table/GuildZiCai", XGuildGrowthDocument._guildZiCaiTable, false);
			XGuildGrowthDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009E01 RID: 40449 RVA: 0x0019D710 File Offset: 0x0019B910
		public static void OnTableLoaded()
		{
			uint num = 0U;
			for (int i = 0; i < XGuildGrowthDocument._guildHallTable.Table.Length; i++)
			{
				bool flag = XGuildGrowthDocument._guildHallTable.Table[i].skillid > num;
				if (flag)
				{
					num = XGuildGrowthDocument._guildHallTable.Table[i].skillid;
				}
			}
			XGuildGrowthDocument._buffList.Clear();
			for (uint num2 = 0U; num2 <= num; num2 += 1U)
			{
				XGuildGrowthDocument._buffList.Add(new XGuildGrowthDocument.GuildGrowthBuffData(num2, 0U, 0U, false));
			}
			XGuildGrowthDocument._buffDict.Clear();
			for (int j = 0; j < XGuildGrowthDocument._guildHallTable.Table.Length; j++)
			{
				GuildHall.RowData rowData = XGuildGrowthDocument._guildHallTable.Table[j];
				bool flag2 = rowData.level > XGuildGrowthDocument._buffList[(int)rowData.skillid].BuffMaxLevel;
				if (flag2)
				{
					XGuildGrowthDocument._buffList[(int)rowData.skillid].BuffMaxLevel = rowData.level;
				}
				XGuildGrowthDocument._buffDict.Add(rowData.skillid * XGuildGrowthDocument.INTERVALNUM + rowData.level, rowData);
			}
		}

		// Token: 0x06009E02 RID: 40450 RVA: 0x0019D848 File Offset: 0x0019BA48
		public GuildHall.RowData GetData(uint skillID, uint skillLevel)
		{
			uint key = skillID * XGuildGrowthDocument.INTERVALNUM + skillLevel;
			GuildHall.RowData result = null;
			bool flag = !XGuildGrowthDocument._buffDict.TryGetValue(key, out result);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find guild growth data for guildhall.txt, id = ", skillID.ToString() + "   level = ", skillLevel.ToString(), null, null, null);
			}
			return result;
		}

		// Token: 0x06009E03 RID: 40451 RVA: 0x0019D8A8 File Offset: 0x0019BAA8
		public void QueryBuffList()
		{
			RpcC2M_GuildHallGetBuffList rpc = new RpcC2M_GuildHallGetBuffList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009E04 RID: 40452 RVA: 0x0019D8C8 File Offset: 0x0019BAC8
		public void OnBuffListReply(GuildHallGetBuffList_M2C oRes)
		{
			this.LevelUpEnable = oRes.enableUpdate;
			for (int i = 0; i < XGuildGrowthDocument._buffList.Count; i++)
			{
				XGuildGrowthDocument._buffList[i].BuffLevel = 0U;
				XGuildGrowthDocument._buffList[i].Enable = false;
			}
			for (int j = 0; j < oRes.bufflist.Count; j++)
			{
				XGuildGrowthDocument._buffList[(int)oRes.bufflist[j].buffid].BuffLevel = oRes.bufflist[j].level;
				XGuildGrowthDocument._buffList[(int)oRes.bufflist[j].buffid].Enable = oRes.bufflist[j].isenable;
			}
			bool flag = DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.RefreshList(false);
			}
			bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshGrowthBuffList();
			}
		}

		// Token: 0x06009E05 RID: 40453 RVA: 0x0019D9D8 File Offset: 0x0019BBD8
		public void QueryGuildHallBuffLevelUp(uint buffid)
		{
			RpcC2M_GuildHallUpdateBuff rpcC2M_GuildHallUpdateBuff = new RpcC2M_GuildHallUpdateBuff();
			rpcC2M_GuildHallUpdateBuff.oArg.buffid = buffid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildHallUpdateBuff);
		}

		// Token: 0x06009E06 RID: 40454 RVA: 0x0019DA08 File Offset: 0x0019BC08
		public void OnBuffLevelUpSuccess(GuildHallBuffData data)
		{
			XGuildGrowthDocument._buffList[(int)data.buffid].BuffLevel = data.level;
			XGuildGrowthDocument._buffList[(int)data.buffid].Enable = data.isenable;
			bool flag = DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.ShowLevelUpFx = (int)data.buffid;
				DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.RefreshList(true);
			}
		}

		// Token: 0x06009E07 RID: 40455 RVA: 0x0019DA78 File Offset: 0x0019BC78
		public void QueryBuildRank()
		{
			RpcC2M_GuildSchoolHallGetRankList rpc = new RpcC2M_GuildSchoolHallGetRankList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009E08 RID: 40456 RVA: 0x0019DA98 File Offset: 0x0019BC98
		public void OnBuildRankGet(List<GuildSchoolHallRankData> list, uint hallPoint, uint schoolPoint, uint huntCount, uint donateCount)
		{
			this.WeekHallPoint = hallPoint;
			this.WeekSchoolPoint = schoolPoint;
			this.WeekHuntTimes = huntCount;
			this.WeekDonateTimes = donateCount;
			this._rankList.Clear();
			this._myData = null;
			for (int i = 0; i < list.Count; i++)
			{
				this._rankList.Add(new XGuildGrowthDocument.GuildGrowthRankData(list[i].rolename, list[i].roleid, list[i].weeklyhallpoint, list[i].weeklyschoolpoint));
				bool flag = list[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag)
				{
					this._myData = new XGuildGrowthDocument.GuildGrowthRankData(list[i].rolename, list[i].roleid, list[i].weeklyhallpoint, list[i].weeklyschoolpoint);
				}
			}
			bool flag2 = this._myData == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("guild growth rank haven't my data.", null, null, null, null, null);
			}
			else
			{
				this._rankList.Sort(new Comparison<XGuildGrowthDocument.GuildGrowthRankData>(this.Compare));
				for (int j = 0; j < this._rankList.Count; j++)
				{
					bool flag3 = this._rankList[j].Uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag3)
					{
						this.MyRank = j;
						break;
					}
				}
				bool flag4 = DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>.singleton.RefreshRank();
				}
				bool flag5 = DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.IsVisible();
				if (flag5)
				{
					DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.RefreshGrowthDonateTimes();
				}
			}
		}

		// Token: 0x06009E09 RID: 40457 RVA: 0x0019DC64 File Offset: 0x0019BE64
		private int Compare(XGuildGrowthDocument.GuildGrowthRankData x, XGuildGrowthDocument.GuildGrowthRankData y)
		{
			bool flag = x.Uid == y.Uid;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = (int)(y.HallPoint + y.SchoolPoint - x.HallPoint - x.SchoolPoint);
			}
			return result;
		}

		// Token: 0x06009E0A RID: 40458 RVA: 0x0019DCA8 File Offset: 0x0019BEA8
		public void QueryGuildGrowthDonate(uint itemid)
		{
			RpcC2M_GuildZiCaiDonate rpcC2M_GuildZiCaiDonate = new RpcC2M_GuildZiCaiDonate();
			rpcC2M_GuildZiCaiDonate.oArg.itemid = itemid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildZiCaiDonate);
		}

		// Token: 0x06009E0B RID: 40459 RVA: 0x0019DCD8 File Offset: 0x0019BED8
		public void QueryGrowthRecordList()
		{
			RpcC2M_GuildZiCaiDonateHistory rpc = new RpcC2M_GuildZiCaiDonateHistory();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009E0C RID: 40460 RVA: 0x0019DCF8 File Offset: 0x0019BEF8
		public void OnGrowthRecordListGet(List<GuildZiCaiDonateHistoryData> list)
		{
			this._recordList.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				this._recordList.Add(new XGuildGrowthDocument.GuildCrowthRecordData(list[i].rolename, list[i].itemid, list[i].time));
			}
			bool flag = DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.CheckRecordRefresh();
			}
		}

		// Token: 0x040037EA RID: 14314
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildGrowthDocument");

		// Token: 0x040037EB RID: 14315
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040037EC RID: 14316
		private static GuildHall _guildHallTable = new GuildHall();

		// Token: 0x040037ED RID: 14317
		private static GuildZiCai _guildZiCaiTable = new GuildZiCai();

		// Token: 0x040037EE RID: 14318
		private static Dictionary<uint, GuildHall.RowData> _buffDict = new Dictionary<uint, GuildHall.RowData>();

		// Token: 0x040037EF RID: 14319
		private static readonly uint INTERVALNUM = 10000U;

		// Token: 0x040037F0 RID: 14320
		public bool LevelUpEnable = false;

		// Token: 0x040037F1 RID: 14321
		public bool AutoFindNpc = false;

		// Token: 0x040037F2 RID: 14322
		private static List<XGuildGrowthDocument.GuildGrowthBuffData> _buffList = new List<XGuildGrowthDocument.GuildGrowthBuffData>();

		// Token: 0x040037F3 RID: 14323
		private List<XGuildGrowthDocument.GuildGrowthRankData> _rankList = new List<XGuildGrowthDocument.GuildGrowthRankData>();

		// Token: 0x040037F4 RID: 14324
		private List<XGuildGrowthDocument.GuildCrowthRecordData> _recordList = new List<XGuildGrowthDocument.GuildCrowthRecordData>();

		// Token: 0x040037F5 RID: 14325
		private XGuildGrowthDocument.GuildGrowthRankData _myData;

		// Token: 0x040037F6 RID: 14326
		public int MyRank;

		// Token: 0x040037F7 RID: 14327
		public uint WeekHallPoint;

		// Token: 0x040037F8 RID: 14328
		public uint WeekSchoolPoint;

		// Token: 0x040037F9 RID: 14329
		public uint WeekHuntTimes;

		// Token: 0x040037FA RID: 14330
		public uint WeekDonateTimes;

		// Token: 0x040037FB RID: 14331
		public uint ResourcesPoint;

		// Token: 0x040037FC RID: 14332
		public uint TechnologyPoint;

		// Token: 0x040037FD RID: 14333
		public uint ResDeltaPoint = 0U;

		// Token: 0x040037FE RID: 14334
		public uint TecDeltaPoint = 0U;

		// Token: 0x02001989 RID: 6537
		public class GuildGrowthBuffData
		{
			// Token: 0x06011017 RID: 69655 RVA: 0x004535E8 File Offset: 0x004517E8
			public GuildGrowthBuffData(uint id, uint level, uint maxLevel, bool enable)
			{
				this.BuffID = id;
				this.BuffLevel = level;
				this.BuffMaxLevel = maxLevel;
				this.Enable = enable;
			}

			// Token: 0x04007EDF RID: 32479
			public uint BuffID;

			// Token: 0x04007EE0 RID: 32480
			public uint BuffLevel;

			// Token: 0x04007EE1 RID: 32481
			public uint BuffMaxLevel;

			// Token: 0x04007EE2 RID: 32482
			public bool Enable;
		}

		// Token: 0x0200198A RID: 6538
		public class GuildGrowthRankData
		{
			// Token: 0x06011018 RID: 69656 RVA: 0x0045360F File Offset: 0x0045180F
			public GuildGrowthRankData(string name, ulong uid, uint hallPoint, uint schoolPoint)
			{
				this.Name = name;
				this.Uid = uid;
				this.HallPoint = hallPoint;
				this.SchoolPoint = schoolPoint;
			}

			// Token: 0x04007EE3 RID: 32483
			public string Name;

			// Token: 0x04007EE4 RID: 32484
			public ulong Uid;

			// Token: 0x04007EE5 RID: 32485
			public uint HallPoint;

			// Token: 0x04007EE6 RID: 32486
			public uint SchoolPoint;
		}

		// Token: 0x0200198B RID: 6539
		public class GuildCrowthRecordData
		{
			// Token: 0x06011019 RID: 69657 RVA: 0x00453636 File Offset: 0x00451836
			public GuildCrowthRecordData(string name, uint itemID, uint time)
			{
				this.Name = name;
				this.ItemID = itemID;
				this.Time = time;
			}

			// Token: 0x04007EE7 RID: 32487
			public string Name;

			// Token: 0x04007EE8 RID: 32488
			public uint ItemID;

			// Token: 0x04007EE9 RID: 32489
			public uint Time;
		}
	}
}
