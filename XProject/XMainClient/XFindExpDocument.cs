using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFindExpDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFindExpDocument.uuID;
			}
		}

		public static XFindExpDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XFindExpDocument.uuID) as XFindExpDocument;
			}
		}

		public int TotalCostGetExp
		{
			get
			{
				return this.mTotalCostGetExp;
			}
		}

		public int TotalFreeGetExp
		{
			get
			{
				return this.mTotalFreeGetExp;
			}
		}

		public int NeedDragonCoin
		{
			get
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ExpFindBackParam");
				return (this.mTotalCostGetExp - this.mTotalFreeGetExp + @int - 1) / @int;
			}
		}

		public bool IsAvailable
		{
			get
			{
				return !this.mFindExpSuccess && (this.mTotalCostGetExp > 0 || this.mTotalFreeGetExp > 0) && (long)this.OpenLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

		public int OpenLevel
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("ExpFindBackNeedLevel");
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFindExpDocument.AsyncLoader.AddTask("Table/ExpBack", XFindExpDocument.mReader, false);
			XFindExpDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._ResetData();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void RequestExpFindBack(bool _isFree)
		{
			RpcC2G_ExpFindBack rpcC2G_ExpFindBack = new RpcC2G_ExpFindBack();
			rpcC2G_ExpFindBack.oArg.isFree = _isFree;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ExpFindBack);
		}

		public void OnReplyExpFindBack(ExpFindBackArg oArg, ExpFindBackRes oRes)
		{
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.error, "fece00");
			}
			else
			{
				this.mFindExpSuccess = true;
			}
		}

		public void OnGetExpInfo(PtcG2C_ExpFindBackNtf roPtc)
		{
			List<ExpFindBackInfo> expBackInfos = roPtc.Data.expBackInfos;
			this._ResetData();
			bool flag = expBackInfos != null && expBackInfos.Count > 0;
			if (flag)
			{
				for (int i = 0; i < expBackInfos.Count; i++)
				{
					ExpFindBackInfo expFindBackInfo = expBackInfos[i];
					bool flag2 = expFindBackInfo != null;
					if (flag2)
					{
						ExpBackTable.RowData bytype = XFindExpDocument.mReader.GetBytype(ExpBackTypeMgr.GetTypeInt(expFindBackInfo.type));
						bool flag3 = bytype != null;
						if (flag3)
						{
							int num = bytype.count - expFindBackInfo.usedCount;
							bool flag4 = num > 0;
							if (flag4)
							{
								this.mTotalFreeGetExp += bytype.exp * bytype.freeExpParam * num;
								this.mTotalCostGetExp += bytype.exp * bytype.moneyCostParam * num;
							}
						}
					}
				}
				this.mTotalFreeGetExp /= 100;
				this.mTotalCostGetExp /= 100;
			}
		}

		private void _ResetData()
		{
			this.mTotalFreeGetExp = 0;
			this.mTotalCostGetExp = 0;
			this.mFindExpSuccess = false;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FindExpDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ExpBackTable mReader = new ExpBackTable();

		private int mTotalFreeGetExp = 0;

		private int mTotalCostGetExp = 0;

		private bool mFindExpSuccess = false;
	}
}
