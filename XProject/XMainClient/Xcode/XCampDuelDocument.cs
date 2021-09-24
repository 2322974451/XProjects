using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCampDuelDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCampDuelDocument.uuID;
			}
		}

		public static XCampDuelDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XCampDuelDocument.uuID) as XCampDuelDocument;
			}
		}

		public uint TaskID
		{
			get
			{
				return uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelTaskID"));
			}
		}

		public int ConfirmItemID
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelItemId"));
			}
		}

		public SuperActivityTime.RowData ActInfo
		{
			get
			{
				bool flag = this._actInfo != null;
				SuperActivityTime.RowData actInfo;
				if (flag)
				{
					actInfo = this._actInfo;
				}
				else
				{
					this._actInfo = XTempActivityDocument.Doc.GetDataBySystemID((uint)this.systemID);
					bool flag2 = this._actInfo == null;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("SuperActivityTime SystemID:" + this.systemID + "No Find", null, null, null, null, null);
					}
					actInfo = this._actInfo;
				}
				return actInfo;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCampDuelDocument.AsyncLoader.AddTask("Table/CampDuelPointReward", XCampDuelDocument._PointRewardTable, false);
			XCampDuelDocument.AsyncLoader.AddTask("Table/CampDuelRankReward", XCampDuelDocument._RankRewardTable, false);
			XCampDuelDocument.AsyncLoader.Execute(callback);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL && !this.hasData && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_CampDuel);
			if (flag)
			{
				this.ReqCampDuel(1U, 0U);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChanged));
		}

		private bool OnTaskStateChanged(XEventArgs e)
		{
			XTaskStatusChangeArgs xtaskStatusChangeArgs = e as XTaskStatusChangeArgs;
			bool flag = xtaskStatusChangeArgs.status == TaskStatus.TaskStatus_Taked;
			if (flag)
			{
				uint id = xtaskStatusChangeArgs.id;
				TaskTableNew.RowData taskData = XTaskDocument.GetTaskData(id);
				bool flag2 = taskData != null;
				if (flag2)
				{
					bool flag3 = taskData.TaskID == this.TaskID;
					if (flag3)
					{
						DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_CampDuel, false);
					}
				}
			}
			return true;
		}

		public List<CampDuelPointReward.RowData> GetPointRewardList(int campID)
		{
			this._PointRewardList.Clear();
			for (int i = 0; i < XCampDuelDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = campID == XCampDuelDocument._PointRewardTable.Table[i].CampID;
				if (flag)
				{
					this._PointRewardList.Add(XCampDuelDocument._PointRewardTable.Table[i]);
				}
			}
			return this._PointRewardList;
		}

		public CampDuelPointReward.RowData GetPointReward(int point)
		{
			CampDuelPointReward.RowData result = null;
			for (int i = 0; i < XCampDuelDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = this.campID == XCampDuelDocument._PointRewardTable.Table[i].CampID && point >= XCampDuelDocument._PointRewardTable.Table[i].Point;
				if (flag)
				{
					result = XCampDuelDocument._PointRewardTable.Table[i];
				}
			}
			return result;
		}

		public CampDuelPointReward.RowData GetNextPointReward(int point)
		{
			for (int i = 0; i < XCampDuelDocument._PointRewardTable.Table.Length; i++)
			{
				bool flag = this.campID == XCampDuelDocument._PointRewardTable.Table[i].CampID && point < XCampDuelDocument._PointRewardTable.Table[i].Point;
				if (flag)
				{
					return XCampDuelDocument._PointRewardTable.Table[i];
				}
			}
			return null;
		}

		public List<CampDuelRankReward.RowData> GetRankRewardList()
		{
			this._RankRewardList.Clear();
			for (int i = 0; i < XCampDuelDocument._RankRewardTable.Table.Length; i++)
			{
				this._RankRewardList.Add(XCampDuelDocument._RankRewardTable.Table[i]);
			}
			return this._RankRewardList;
		}

		public void ReqCampDuel(uint type, uint arg = 0U)
		{
			RpcC2G_CampDuelActivityOperation rpcC2G_CampDuelActivityOperation = new RpcC2G_CampDuelActivityOperation();
			rpcC2G_CampDuelActivityOperation.oArg.type = type;
			rpcC2G_CampDuelActivityOperation.oArg.arg = arg;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_CampDuelActivityOperation);
		}

		public void SetCampDuelData(CampDuelActivityOperationArg oArg, CampDuelActivityOperationRes oRes)
		{
			bool flag = oRes.data == null;
			if (!flag)
			{
				bool flag2 = oArg.type == 1U;
				if (flag2)
				{
					this.aheadCampID = (int)oRes.precedeCampID;
					this.hasData = true;
				}
				bool flag3 = oArg.type == 3U || oArg.type == 4U || oArg.type == 5U;
				if (flag3)
				{
					CampDuelPointReward.RowData pointReward = this.GetPointReward(this.point);
					CampDuelPointReward.RowData pointReward2 = this.GetPointReward((int)oRes.data.point);
					bool flag4 = (pointReward != null && pointReward2 != null && pointReward.Point != pointReward2.Point) || (pointReward == null && pointReward2 != null);
					if (flag4)
					{
						bool flag5 = this.handler != null;
						if (flag5)
						{
							XSingleton<XDebug>.singleton.AddGreenLog("PlayBoxUpFx", null, null, null, null, null);
							this.handler.PlayBoxUpFx();
						}
					}
				}
				bool flag6 = oArg.type == 3U;
				if (flag6)
				{
					bool flag7 = this.handler != null;
					if (flag7)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("PlayNPCFx", null, null, null, null, null);
						this.handler.PlayNPCFx();
						this.handler.ShowBlah();
					}
				}
				bool flag8 = (long)this.point != (long)((ulong)oRes.data.point);
				if (flag8)
				{
					bool flag9 = this.handler != null;
					if (flag9)
					{
						this.handler.AddNumPlayTween((int)(oRes.data.point - (uint)this.point));
					}
				}
				this.campID = (int)oRes.data.campid;
				this.point = (int)oRes.data.point;
				this.FreeCourageCount = (int)oRes.data.freeInspireCount;
				this.DragonCoinCourageCount = (int)oRes.data.dragonCoinInspireCount;
				bool flag10 = this.handler != null;
				if (flag10)
				{
					this.handler.ShowUI();
				}
			}
		}

		public bool IsRedPoint()
		{
			return this.FreeCourageCount != 0 && this.curStage == 1;
		}

		public void RecordActivityPastTime(uint time, SeqListRef<uint> timestage)
		{
			int num = (int)(time / 3600U);
			this.curStage = (((long)num < (long)((ulong)timestage[0, 0])) ? 1 : 2);
			XSingleton<XDebug>.singleton.AddGreenLog("time:" + num, null, null, null, null, null);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCampDuelDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static CampDuelPointReward _PointRewardTable = new CampDuelPointReward();

		private static CampDuelRankReward _RankRewardTable = new CampDuelRankReward();

		public int systemID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CampDuel);

		public XCampDuelMainHandler handler;

		private bool hasData = false;

		public int campID;

		public int aheadCampID;

		public int point;

		public int curStage;

		public int FreeCourageCount;

		public int DragonCoinCourageCount;

		public int FreeCourageMAX = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelFreeInspireCount"));

		public string[] DragonCoinCourageCost = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelMoneyInspireCount").Split(new char[]
		{
			'|'
		});

		private SuperActivityTime.RowData _actInfo = null;

		private List<CampDuelPointReward.RowData> _PointRewardList = new List<CampDuelPointReward.RowData>();

		private List<CampDuelRankReward.RowData> _RankRewardList = new List<CampDuelRankReward.RowData>();
	}
}
