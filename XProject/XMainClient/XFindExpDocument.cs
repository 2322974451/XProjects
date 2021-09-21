using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000998 RID: 2456
	internal class XFindExpDocument : XDocComponent
	{
		// Token: 0x17002CD2 RID: 11474
		// (get) Token: 0x060093F3 RID: 37875 RVA: 0x0015B928 File Offset: 0x00159B28
		public override uint ID
		{
			get
			{
				return XFindExpDocument.uuID;
			}
		}

		// Token: 0x17002CD3 RID: 11475
		// (get) Token: 0x060093F4 RID: 37876 RVA: 0x0015B940 File Offset: 0x00159B40
		public static XFindExpDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XFindExpDocument.uuID) as XFindExpDocument;
			}
		}

		// Token: 0x17002CD4 RID: 11476
		// (get) Token: 0x060093F5 RID: 37877 RVA: 0x0015B96C File Offset: 0x00159B6C
		public int TotalCostGetExp
		{
			get
			{
				return this.mTotalCostGetExp;
			}
		}

		// Token: 0x17002CD5 RID: 11477
		// (get) Token: 0x060093F6 RID: 37878 RVA: 0x0015B984 File Offset: 0x00159B84
		public int TotalFreeGetExp
		{
			get
			{
				return this.mTotalFreeGetExp;
			}
		}

		// Token: 0x17002CD6 RID: 11478
		// (get) Token: 0x060093F7 RID: 37879 RVA: 0x0015B99C File Offset: 0x00159B9C
		public int NeedDragonCoin
		{
			get
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ExpFindBackParam");
				return (this.mTotalCostGetExp - this.mTotalFreeGetExp + @int - 1) / @int;
			}
		}

		// Token: 0x17002CD7 RID: 11479
		// (get) Token: 0x060093F8 RID: 37880 RVA: 0x0015B9D4 File Offset: 0x00159BD4
		public bool IsAvailable
		{
			get
			{
				return !this.mFindExpSuccess && (this.mTotalCostGetExp > 0 || this.mTotalFreeGetExp > 0) && (long)this.OpenLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
		}

		// Token: 0x17002CD8 RID: 11480
		// (get) Token: 0x060093F9 RID: 37881 RVA: 0x0015BA20 File Offset: 0x00159C20
		public int OpenLevel
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("ExpFindBackNeedLevel");
			}
		}

		// Token: 0x060093FA RID: 37882 RVA: 0x0015BA41 File Offset: 0x00159C41
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFindExpDocument.AsyncLoader.AddTask("Table/ExpBack", XFindExpDocument.mReader, false);
			XFindExpDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060093FB RID: 37883 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTableLoaded()
		{
		}

		// Token: 0x060093FC RID: 37884 RVA: 0x0015BA66 File Offset: 0x00159C66
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._ResetData();
		}

		// Token: 0x060093FD RID: 37885 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x060093FE RID: 37886 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060093FF RID: 37887 RVA: 0x0015BA78 File Offset: 0x00159C78
		public void RequestExpFindBack(bool _isFree)
		{
			RpcC2G_ExpFindBack rpcC2G_ExpFindBack = new RpcC2G_ExpFindBack();
			rpcC2G_ExpFindBack.oArg.isFree = _isFree;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ExpFindBack);
		}

		// Token: 0x06009400 RID: 37888 RVA: 0x0015BAA8 File Offset: 0x00159CA8
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

		// Token: 0x06009401 RID: 37889 RVA: 0x0015BAE4 File Offset: 0x00159CE4
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

		// Token: 0x06009402 RID: 37890 RVA: 0x0015BBF0 File Offset: 0x00159DF0
		private void _ResetData()
		{
			this.mTotalFreeGetExp = 0;
			this.mTotalCostGetExp = 0;
			this.mFindExpSuccess = false;
		}

		// Token: 0x040031BE RID: 12734
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FindExpDocument");

		// Token: 0x040031BF RID: 12735
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040031C0 RID: 12736
		private static ExpBackTable mReader = new ExpBackTable();

		// Token: 0x040031C1 RID: 12737
		private int mTotalFreeGetExp = 0;

		// Token: 0x040031C2 RID: 12738
		private int mTotalCostGetExp = 0;

		// Token: 0x040031C3 RID: 12739
		private bool mFindExpSuccess = false;
	}
}
