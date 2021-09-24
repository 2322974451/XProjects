using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonRewardDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Reward_Dragon);
			if (flag)
			{
				this.FetchList();
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonRewardDocument.AsyncLoader.AddTask("Table/DargonReward", XDragonRewardDocument._reader, false);
			XDragonRewardDocument.AsyncLoader.Execute(callback);
		}

		public void FetchList()
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = DHRReqOp.DHR_OP_LIST;
			rpcC2G_DHRReqC2G.oArg.id = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

		public void Claim(int id)
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = DHRReqOp.DHR_OP_FETCH_REWARD;
			rpcC2G_DHRReqC2G.oArg.id = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

		public void AgreeHelp(bool agree)
		{
			RpcC2G_DHRReqC2G rpcC2G_DHRReqC2G = new RpcC2G_DHRReqC2G();
			rpcC2G_DHRReqC2G.oArg.op = (agree ? DHRReqOp.DHR_OP_WANT_BE_HELP : DHRReqOp.DHR_OP_WANT_NOT_HELP);
			rpcC2G_DHRReqC2G.oArg.id = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DHRReqC2G);
		}

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

		private void RefreshRedp()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Dragon, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward, true);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonRewardDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DargonReward _reader = new DargonReward();

		public List<DragonRwdItem> rewds = new List<DragonRwdItem>();

		public XDragonRwdHandler rwdView;

		public bool isAgreeHelp = true;

		public uint helpCnt = 0U;
	}
}
