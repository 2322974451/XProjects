using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C57 RID: 3159
	internal class XCampDuelDocument : XDocComponent
	{
		// Token: 0x170031A3 RID: 12707
		// (get) Token: 0x0600B30B RID: 45835 RVA: 0x0022BEC4 File Offset: 0x0022A0C4
		public override uint ID
		{
			get
			{
				return XCampDuelDocument.uuID;
			}
		}

		// Token: 0x170031A4 RID: 12708
		// (get) Token: 0x0600B30C RID: 45836 RVA: 0x0022BEDC File Offset: 0x0022A0DC
		public static XCampDuelDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XCampDuelDocument.uuID) as XCampDuelDocument;
			}
		}

		// Token: 0x170031A5 RID: 12709
		// (get) Token: 0x0600B30D RID: 45837 RVA: 0x0022BF08 File Offset: 0x0022A108
		public uint TaskID
		{
			get
			{
				return uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelTaskID"));
			}
		}

		// Token: 0x170031A6 RID: 12710
		// (get) Token: 0x0600B30E RID: 45838 RVA: 0x0022BF30 File Offset: 0x0022A130
		public int ConfirmItemID
		{
			get
			{
				return int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelItemId"));
			}
		}

		// Token: 0x170031A7 RID: 12711
		// (get) Token: 0x0600B30F RID: 45839 RVA: 0x0022BF58 File Offset: 0x0022A158
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

		// Token: 0x0600B310 RID: 45840 RVA: 0x0022BFD3 File Offset: 0x0022A1D3
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCampDuelDocument.AsyncLoader.AddTask("Table/CampDuelPointReward", XCampDuelDocument._PointRewardTable, false);
			XCampDuelDocument.AsyncLoader.AddTask("Table/CampDuelRankReward", XCampDuelDocument._RankRewardTable, false);
			XCampDuelDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B311 RID: 45841 RVA: 0x0022C010 File Offset: 0x0022A210
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL && !this.hasData && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_CampDuel);
			if (flag)
			{
				this.ReqCampDuel(1U, 0U);
			}
		}

		// Token: 0x0600B312 RID: 45842 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B313 RID: 45843 RVA: 0x0022C054 File Offset: 0x0022A254
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.OnTaskStateChanged));
		}

		// Token: 0x0600B314 RID: 45844 RVA: 0x0022C078 File Offset: 0x0022A278
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

		// Token: 0x0600B315 RID: 45845 RVA: 0x0022C0E4 File Offset: 0x0022A2E4
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

		// Token: 0x0600B316 RID: 45846 RVA: 0x0022C158 File Offset: 0x0022A358
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

		// Token: 0x0600B317 RID: 45847 RVA: 0x0022C1D4 File Offset: 0x0022A3D4
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

		// Token: 0x0600B318 RID: 45848 RVA: 0x0022C248 File Offset: 0x0022A448
		public List<CampDuelRankReward.RowData> GetRankRewardList()
		{
			this._RankRewardList.Clear();
			for (int i = 0; i < XCampDuelDocument._RankRewardTable.Table.Length; i++)
			{
				this._RankRewardList.Add(XCampDuelDocument._RankRewardTable.Table[i]);
			}
			return this._RankRewardList;
		}

		// Token: 0x0600B319 RID: 45849 RVA: 0x0022C2A4 File Offset: 0x0022A4A4
		public void ReqCampDuel(uint type, uint arg = 0U)
		{
			RpcC2G_CampDuelActivityOperation rpcC2G_CampDuelActivityOperation = new RpcC2G_CampDuelActivityOperation();
			rpcC2G_CampDuelActivityOperation.oArg.type = type;
			rpcC2G_CampDuelActivityOperation.oArg.arg = arg;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_CampDuelActivityOperation);
		}

		// Token: 0x0600B31A RID: 45850 RVA: 0x0022C2E0 File Offset: 0x0022A4E0
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

		// Token: 0x0600B31B RID: 45851 RVA: 0x0022C4C4 File Offset: 0x0022A6C4
		public bool IsRedPoint()
		{
			return this.FreeCourageCount != 0 && this.curStage == 1;
		}

		// Token: 0x0600B31C RID: 45852 RVA: 0x0022C4EC File Offset: 0x0022A6EC
		public void RecordActivityPastTime(uint time, SeqListRef<uint> timestage)
		{
			int num = (int)(time / 3600U);
			this.curStage = (((long)num < (long)((ulong)timestage[0, 0])) ? 1 : 2);
			XSingleton<XDebug>.singleton.AddGreenLog("time:" + num, null, null, null, null, null);
		}

		// Token: 0x04004530 RID: 17712
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XCampDuelDocument");

		// Token: 0x04004531 RID: 17713
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004532 RID: 17714
		private static CampDuelPointReward _PointRewardTable = new CampDuelPointReward();

		// Token: 0x04004533 RID: 17715
		private static CampDuelRankReward _RankRewardTable = new CampDuelRankReward();

		// Token: 0x04004534 RID: 17716
		public int systemID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CampDuel);

		// Token: 0x04004535 RID: 17717
		public XCampDuelMainHandler handler;

		// Token: 0x04004536 RID: 17718
		private bool hasData = false;

		// Token: 0x04004537 RID: 17719
		public int campID;

		// Token: 0x04004538 RID: 17720
		public int aheadCampID;

		// Token: 0x04004539 RID: 17721
		public int point;

		// Token: 0x0400453A RID: 17722
		public int curStage;

		// Token: 0x0400453B RID: 17723
		public int FreeCourageCount;

		// Token: 0x0400453C RID: 17724
		public int DragonCoinCourageCount;

		// Token: 0x0400453D RID: 17725
		public int FreeCourageMAX = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelFreeInspireCount"));

		// Token: 0x0400453E RID: 17726
		public string[] DragonCoinCourageCost = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelMoneyInspireCount").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400453F RID: 17727
		private SuperActivityTime.RowData _actInfo = null;

		// Token: 0x04004540 RID: 17728
		private List<CampDuelPointReward.RowData> _PointRewardList = new List<CampDuelPointReward.RowData>();

		// Token: 0x04004541 RID: 17729
		private List<CampDuelRankReward.RowData> _RankRewardList = new List<CampDuelRankReward.RowData>();
	}
}
