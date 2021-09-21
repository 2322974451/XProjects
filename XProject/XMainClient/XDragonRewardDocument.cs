using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200090B RID: 2315
	internal class XDragonRewardDocument : XDocComponent
	{
		// Token: 0x17002B68 RID: 11112
		// (get) Token: 0x06008BD7 RID: 35799 RVA: 0x0012C7FC File Offset: 0x0012A9FC
		public override uint ID
		{
			get
			{
				return XDragonRewardDocument.uuID;
			}
		}

		// Token: 0x06008BD8 RID: 35800 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008BD9 RID: 35801 RVA: 0x0012C814 File Offset: 0x0012AA14
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Reward_Dragon);
			if (flag)
			{
				this.FetchList();
			}
		}

		// Token: 0x06008BDA RID: 35802 RVA: 0x0012C85A File Offset: 0x0012AA5A
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonRewardDocument.AsyncLoader.AddTask("Table/DargonReward", XDragonRewardDocument._reader, false);
			XDragonRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008BDB RID: 35803 RVA: 0x0012C880 File Offset: 0x0012AA80
		public void FetchList()
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = DHRReqOp.DHR_OP_LIST;
			rpcC2G_DHRReqC2G.oArg.id = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

		// Token: 0x06008BDC RID: 35804 RVA: 0x0012C8BC File Offset: 0x0012AABC
		public void Claim(int id)
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = DHRReqOp.DHR_OP_FETCH_REWARD;
			rpcC2G_DHRReqC2G.oArg.id = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

		// Token: 0x06008BDD RID: 35805 RVA: 0x0012C8F8 File Offset: 0x0012AAF8
		public void AgreeHelp(bool agree)
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = (agree ? DHRReqOp.DHR_OP_WANT_BE_HELP : DHRReqOp.DHR_OP_WANT_NOT_HELP);
			rpcC2G_DHRReqC2G.oArg.id = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

		// Token: 0x06008BDE RID: 35806 RVA: 0x0012C938 File Offset: 0x0012AB38
		public void OnResAchieve(List<DHRewrad2State> dataList, uint helps, bool want)
		{
			this.isAgreeHelp = want;
			this.helpCnt = helps;
			this.rewds.Clear();
			int i = 0;
			int count = dataList.Count;
			while (i < count)
			{
				DragonRwdItem dragonRwdItem = new DragonRwdItem();
				dragonRwdItem.row = this.Find(dataList[i]);
				bool flag = dragonRwdItem.row == null;
				if (!flag)
				{
					bool flag2 = dataList[i].state == DHRState.DHR_CANNOT;
					if (flag2)
					{
						dragonRwdItem.state = AchieveState.Normal;
					}
					else
					{
						bool flag3 = dataList[i].state == DHRState.DHR_CAN_HAVEHOT;
						if (flag3)
						{
							dragonRwdItem.state = AchieveState.Claim;
						}
						else
						{
							dragonRwdItem.state = AchieveState.Claimed;
						}
					}
					this.rewds.Add(dragonRwdItem);
				}
				i++;
			}
			int j = 0;
			int num = XDragonRewardDocument._reader.Table.Length;
			while (j < num)
			{
				bool flag4 = !this.Find(XDragonRewardDocument._reader.Table[j]);
				if (flag4)
				{
					DragonRwdItem dragonRwdItem2 = new DragonRwdItem();
					dragonRwdItem2.row = XDragonRewardDocument._reader.Table[j];
					dragonRwdItem2.state = AchieveState.Normal;
					this.rewds.Add(dragonRwdItem2);
				}
				j++;
			}
			this.rewds.Sort(new Comparison<DragonRwdItem>(this.Sort));
			this.RefreshRedp();
			bool flag5 = this.rwdView != null && this.rwdView.IsVisible();
			if (flag5)
			{
				this.rwdView.Refresh();
			}
		}

		// Token: 0x06008BDF RID: 35807 RVA: 0x0012CAB5 File Offset: 0x0012ACB5
		private void RefreshRedp()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Dragon, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward, true);
		}

		// Token: 0x06008BE0 RID: 35808 RVA: 0x0012CAD8 File Offset: 0x0012ACD8
		public bool HasNewRed()
		{
			int i = 0;
			int count = this.rewds.Count;
			while (i < count)
			{
				bool flag = this.rewds[i].state == AchieveState.Claim;
				if (flag)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		// Token: 0x06008BE1 RID: 35809 RVA: 0x0012CB28 File Offset: 0x0012AD28
		private bool Find(DargonReward.RowData row)
		{
			int i = 0;
			int count = this.rewds.Count;
			while (i < count)
			{
				bool flag = this.rewds[i].row.ID == row.ID;
				if (flag)
				{
					return true;
				}
				i++;
			}
			return false;
		}

		// Token: 0x06008BE2 RID: 35810 RVA: 0x0012CB84 File Offset: 0x0012AD84
		private DargonReward.RowData Find(DHRewrad2State info)
		{
			int i = 0;
			int num = XDragonRewardDocument._reader.Table.Length;
			while (i < num)
			{
				bool flag = XDragonRewardDocument._reader.Table[i].ID == info.id;
				if (flag)
				{
					return XDragonRewardDocument._reader.Table[i];
				}
				i++;
			}
			return null;
		}

		// Token: 0x06008BE3 RID: 35811 RVA: 0x0012CBE4 File Offset: 0x0012ADE4
		private int Sort(DragonRwdItem x, DragonRwdItem y)
		{
			bool flag = x.state != y.state;
			int result;
			if (flag)
			{
				result = x.state - y.state;
			}
			else
			{
				bool flag2 = x.row == null || y.row == null;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					bool flag3 = x.row.SortID != y.row.SortID;
					if (flag3)
					{
						result = x.row.SortID - y.row.SortID;
					}
					else
					{
						result = x.row.ID - y.row.ID;
					}
				}
			}
			return result;
		}

		// Token: 0x04002CD9 RID: 11481
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonRewardDocument");

		// Token: 0x04002CDA RID: 11482
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002CDB RID: 11483
		private static DargonReward _reader = new DargonReward();

		// Token: 0x04002CDC RID: 11484
		public List<DragonRwdItem> rewds = new List<DragonRwdItem>();

		// Token: 0x04002CDD RID: 11485
		public XDragonRwdHandler rwdView;

		// Token: 0x04002CDE RID: 11486
		public bool isAgreeHelp = true;

		// Token: 0x04002CDF RID: 11487
		public uint helpCnt = 0U;
	}
}
