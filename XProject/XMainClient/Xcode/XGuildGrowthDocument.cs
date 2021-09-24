using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildGrowthDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildGrowthDocument.uuID;
			}
		}

		public GuildZiCai GuildZiCaiTableReader
		{
			get
			{
				return XGuildGrowthDocument._guildZiCaiTable;
			}
		}

		public List<XGuildGrowthDocument.GuildGrowthBuffData> BuffList
		{
			get
			{
				return XGuildGrowthDocument._buffList;
			}
		}

		public List<XGuildGrowthDocument.GuildGrowthRankData> RankList
		{
			get
			{
				return this._rankList;
			}
		}

		public List<XGuildGrowthDocument.GuildCrowthRecordData> RecordList
		{
			get
			{
				return this._recordList;
			}
		}

		public XGuildGrowthDocument.GuildGrowthRankData MyData
		{
			get
			{
				return this._myData;
			}
		}

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

		public void CheckShowItemGet(uint resDelta, uint tecDelta)
		{
			this.ResDeltaPoint += resDelta;
			this.TecDeltaPoint += tecDelta;
			this.ShowDeltaPointGet();
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildGrowthDocument.AsyncLoader.AddTask("Table/GuildHall", XGuildGrowthDocument._guildHallTable, false);
			XGuildGrowthDocument.AsyncLoader.AddTask("Table/GuildZiCai", XGuildGrowthDocument._guildZiCaiTable, false);
			XGuildGrowthDocument.AsyncLoader.Execute(callback);
		}

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

		public void QueryBuffList()
		{
			RpcC2M_GuildHallGetBuffList rpc = new RpcC2M_GuildHallGetBuffList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void QueryGuildHallBuffLevelUp(uint buffid)
		{
			RpcC2M_GuildHallUpdateBuff rpcC2M_GuildHallUpdateBuff = new RpcC2M_GuildHallUpdateBuff();
			rpcC2M_GuildHallUpdateBuff.oArg.buffid = buffid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildHallUpdateBuff);
		}

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

		public void QueryBuildRank()
		{
			RpcC2M_GuildSchoolHallGetRankList rpc = new RpcC2M_GuildSchoolHallGetRankList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void QueryGuildGrowthDonate(uint itemid)
		{
			RpcC2M_GuildZiCaiDonate rpcC2M_GuildZiCaiDonate = new RpcC2M_GuildZiCaiDonate();
			rpcC2M_GuildZiCaiDonate.oArg.itemid = itemid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildZiCaiDonate);
		}

		public void QueryGrowthRecordList()
		{
			RpcC2M_GuildZiCaiDonateHistory rpc = new RpcC2M_GuildZiCaiDonateHistory();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XGuildGrowthDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GuildHall _guildHallTable = new GuildHall();

		private static GuildZiCai _guildZiCaiTable = new GuildZiCai();

		private static Dictionary<uint, GuildHall.RowData> _buffDict = new Dictionary<uint, GuildHall.RowData>();

		private static readonly uint INTERVALNUM = 10000U;

		public bool LevelUpEnable = false;

		public bool AutoFindNpc = false;

		private static List<XGuildGrowthDocument.GuildGrowthBuffData> _buffList = new List<XGuildGrowthDocument.GuildGrowthBuffData>();

		private List<XGuildGrowthDocument.GuildGrowthRankData> _rankList = new List<XGuildGrowthDocument.GuildGrowthRankData>();

		private List<XGuildGrowthDocument.GuildCrowthRecordData> _recordList = new List<XGuildGrowthDocument.GuildCrowthRecordData>();

		private XGuildGrowthDocument.GuildGrowthRankData _myData;

		public int MyRank;

		public uint WeekHallPoint;

		public uint WeekSchoolPoint;

		public uint WeekHuntTimes;

		public uint WeekDonateTimes;

		public uint ResourcesPoint;

		public uint TechnologyPoint;

		public uint ResDeltaPoint = 0U;

		public uint TecDeltaPoint = 0U;

		public class GuildGrowthBuffData
		{

			public GuildGrowthBuffData(uint id, uint level, uint maxLevel, bool enable)
			{
				this.BuffID = id;
				this.BuffLevel = level;
				this.BuffMaxLevel = maxLevel;
				this.Enable = enable;
			}

			public uint BuffID;

			public uint BuffLevel;

			public uint BuffMaxLevel;

			public bool Enable;
		}

		public class GuildGrowthRankData
		{

			public GuildGrowthRankData(string name, ulong uid, uint hallPoint, uint schoolPoint)
			{
				this.Name = name;
				this.Uid = uid;
				this.HallPoint = hallPoint;
				this.SchoolPoint = schoolPoint;
			}

			public string Name;

			public ulong Uid;

			public uint HallPoint;

			public uint SchoolPoint;
		}

		public class GuildCrowthRecordData
		{

			public GuildCrowthRecordData(string name, uint itemID, uint time)
			{
				this.Name = name;
				this.ItemID = itemID;
				this.Time = time;
			}

			public string Name;

			public uint ItemID;

			public uint Time;
		}
	}
}
