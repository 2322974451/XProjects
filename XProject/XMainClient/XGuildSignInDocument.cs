using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A79 RID: 2681
	internal class XGuildSignInDocument : XDocComponent, ILogSource
	{
		// Token: 0x17002F87 RID: 12167
		// (get) Token: 0x0600A314 RID: 41748 RVA: 0x001BDDB0 File Offset: 0x001BBFB0
		public override uint ID
		{
			get
			{
				return XGuildSignInDocument.uuID;
			}
		}

		// Token: 0x17002F88 RID: 12168
		// (get) Token: 0x0600A315 RID: 41749 RVA: 0x001BDDC7 File Offset: 0x001BBFC7
		// (set) Token: 0x0600A316 RID: 41750 RVA: 0x001BDDCF File Offset: 0x001BBFCF
		public XGuildSignInView GuildSignInView { get; set; }

		// Token: 0x0600A317 RID: 41751 RVA: 0x001BDDD8 File Offset: 0x001BBFD8
		public List<ILogData> GetLogList()
		{
			return this.m_LogList;
		}

		// Token: 0x17002F89 RID: 12169
		// (get) Token: 0x0600A318 RID: 41752 RVA: 0x001BDDF0 File Offset: 0x001BBFF0
		// (set) Token: 0x0600A319 RID: 41753 RVA: 0x001BDDF8 File Offset: 0x001BBFF8
		public uint TotalCount { get; set; }

		// Token: 0x17002F8A RID: 12170
		// (get) Token: 0x0600A31A RID: 41754 RVA: 0x001BDE01 File Offset: 0x001BC001
		// (set) Token: 0x0600A31B RID: 41755 RVA: 0x001BDE09 File Offset: 0x001BC009
		public uint CurrentCount { get; set; }

		// Token: 0x17002F8B RID: 12171
		// (get) Token: 0x0600A31C RID: 41756 RVA: 0x001BDE14 File Offset: 0x001BC014
		// (set) Token: 0x0600A31D RID: 41757 RVA: 0x001BDE2C File Offset: 0x001BC02C
		public uint SignInSelection
		{
			get
			{
				return this._SignInSelection;
			}
			set
			{
				this._SignInSelection = value;
				this._CheckCanSignIn();
			}
		}

		// Token: 0x17002F8C RID: 12172
		// (get) Token: 0x0600A31E RID: 41758 RVA: 0x001BDE40 File Offset: 0x001BC040
		public uint Progress
		{
			get
			{
				return this._Progress;
			}
		}

		// Token: 0x0600A31F RID: 41759 RVA: 0x001BDE58 File Offset: 0x001BC058
		public void SetChestStateAndProgress(uint progress, uint chest)
		{
			this._BoxState = chest;
			this._Progress = progress;
			bool flag = this.CheckAvailableChest();
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
			}
			bool flag2 = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
			if (flag2)
			{
				this.GuildSignInView.RefreshProgress();
			}
		}

		// Token: 0x17002F8D RID: 12173
		// (get) Token: 0x0600A320 RID: 41760 RVA: 0x001BDEBC File Offset: 0x001BC0BC
		public int CanSignInSelection
		{
			get
			{
				return this._CanSignInSelection;
			}
		}

		// Token: 0x0600A321 RID: 41761 RVA: 0x001BDED4 File Offset: 0x001BC0D4
		public int _CheckCanSignIn()
		{
			this._CanSignInSelection = 0;
			bool flag = this.SignInSelection == 0U;
			if (flag)
			{
				for (int i = XGuildSignInDocument.m_SignInTable.Table.Length - 1; i >= 0; i--)
				{
					GuildCheckinTable.RowData rowData = XGuildSignInDocument.m_SignInTable.Table[i];
					ulong virtualItemCount = XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount((ItemEnum)rowData.consume[0]);
					bool flag2 = virtualItemCount >= (ulong)rowData.consume[1];
					if (flag2)
					{
						this._CanSignInSelection = i + 1;
						break;
					}
				}
			}
			return this._CanSignInSelection;
		}

		// Token: 0x17002F8E RID: 12174
		// (get) Token: 0x0600A322 RID: 41762 RVA: 0x001BDF7C File Offset: 0x001BC17C
		public bool bHasAvailableChest
		{
			get
			{
				return this._bHasAvailableChest;
			}
		}

		// Token: 0x0600A323 RID: 41763 RVA: 0x001BDF94 File Offset: 0x001BC194
		private bool CheckAvailableChest()
		{
			this._bHasAvailableChest = false;
			for (int i = 0; i < XGuildSignInDocument.m_BoxTable.Table.Length; i++)
			{
				bool flag = XGuildSignInDocument.m_BoxTable.Table[i].process <= this._Progress && !this.IsBoxOpen(i);
				if (flag)
				{
					this._bHasAvailableChest = true;
					break;
				}
			}
			return this._bHasAvailableChest;
		}

		// Token: 0x0600A324 RID: 41764 RVA: 0x001BE004 File Offset: 0x001BC204
		public bool IsBoxOpen(int index)
		{
			return ((ulong)this._BoxState & (ulong)(1L << (index & 31))) > 0UL;
		}

		// Token: 0x0600A325 RID: 41765 RVA: 0x001BE029 File Offset: 0x001BC229
		public void SetBoxOpen(int index)
		{
			this._BoxState |= 1U << index;
		}

		// Token: 0x0600A326 RID: 41766 RVA: 0x001BE03F File Offset: 0x001BC23F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSignInDocument.AsyncLoader.AddTask("Table/GuildCheckin", XGuildSignInDocument.m_SignInTable, false);
			XGuildSignInDocument.AsyncLoader.AddTask("Table/GuildCheckinBox", XGuildSignInDocument.m_BoxTable, false);
			XGuildSignInDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A327 RID: 41767 RVA: 0x001BE07C File Offset: 0x001BC27C
		public static GuildCheckinTable.RowData[] GetSignInTableData()
		{
			return XGuildSignInDocument.m_SignInTable.Table;
		}

		// Token: 0x0600A328 RID: 41768 RVA: 0x001BE098 File Offset: 0x001BC298
		public static GuildCheckinBoxTable.RowData[] GetBoxTableData()
		{
			return XGuildSignInDocument.m_BoxTable.Table;
		}

		// Token: 0x0600A329 RID: 41769 RVA: 0x001BE0B4 File Offset: 0x001BC2B4
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._Progress = 0U;
			this._BoxState = 0U;
			this._bHasAvailableChest = false;
			this.SignInSelection = 100U;
		}

		// Token: 0x0600A32A RID: 41770 RVA: 0x001BE0DD File Offset: 0x001BC2DD
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
		}

		// Token: 0x0600A32B RID: 41771 RVA: 0x001BE114 File Offset: 0x001BC314
		protected bool OnVirtualItemChanged(XEventArgs args)
		{
			bool flag = this.SignInSelection > 0U;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._CheckCanSignIn();
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A32C RID: 41772 RVA: 0x001BE150 File Offset: 0x001BC350
		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
			if (flag)
			{
				this.SignInSelection = 100U;
				this._bHasAvailableChest = false;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
			}
			return true;
		}

		// Token: 0x0600A32D RID: 41773 RVA: 0x001BE19C File Offset: 0x001BC39C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
			if (flag)
			{
				this.ReqAllInfo();
			}
		}

		// Token: 0x0600A32E RID: 41774 RVA: 0x001BE1CC File Offset: 0x001BC3CC
		public void ReqAllInfo()
		{
			RpcC2M_QueryGuildCheckinNew rpc = new RpcC2M_QueryGuildCheckinNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A32F RID: 41775 RVA: 0x001BE1EC File Offset: 0x001BC3EC
		public void OnGetAllInfo(QueryGuildCheckinRes oRes)
		{
			this.SignInSelection = oRes.checkin;
			this.CurrentCount = oRes.checkincount;
			this.TotalCount = oRes.allcount;
			this._BoxState = oRes.boxmask;
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
			bool flag = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
			if (flag)
			{
				this.GuildSignInView.Refresh();
			}
		}

		// Token: 0x0600A330 RID: 41776 RVA: 0x001BE268 File Offset: 0x001BC468
		public void ReqFetchBox(uint index)
		{
			RpcC2G_GetGuildCheckinBox rpcC2G_GetGuildCheckinBox = new RpcC2G_GetGuildCheckinBox();
			rpcC2G_GetGuildCheckinBox.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetGuildCheckinBox);
		}

		// Token: 0x0600A331 RID: 41777 RVA: 0x001BE298 File Offset: 0x001BC498
		public void OnFetchBox(GetGuildCheckinBoxArg oArg, GetGuildCheckinBoxRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this.SetBoxOpen((int)oArg.index);
				bool flag2 = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
				if (flag2)
				{
					this.GuildSignInView.OpenBox((int)oArg.index);
				}
				bool flag3 = !this.CheckAvailableChest();
				if (flag3)
				{
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
				}
			}
		}

		// Token: 0x0600A332 RID: 41778 RVA: 0x001BE328 File Offset: 0x001BC528
		public void ReqSignIn(uint index)
		{
			RpcC2M_GuildCheckinNew rpcC2M_GuildCheckinNew = new RpcC2M_GuildCheckinNew();
			rpcC2M_GuildCheckinNew.oArg.type = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildCheckinNew);
		}

		// Token: 0x0600A333 RID: 41779 RVA: 0x001BE358 File Offset: 0x001BC558
		public void OnSignIn(GuildCheckinArg oArg, GuildCheckinRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_SIGNIN_SUCCESS"), "fece00");
				this.SignInSelection = oArg.type;
				uint currentCount = this.CurrentCount + 1U;
				this.CurrentCount = currentCount;
				bool flag2 = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
				if (flag2)
				{
					this.GuildSignInView.Refresh();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_SignIn, true);
			}
		}

		// Token: 0x0600A334 RID: 41780 RVA: 0x001BE400 File Offset: 0x001BC600
		public void ReqLogList()
		{
			RpcC2M_GetGuildCheckinRecordsNew rpc = new RpcC2M_GetGuildCheckinRecordsNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A335 RID: 41781 RVA: 0x001BE420 File Offset: 0x001BC620
		public void onGetLogList(GetGuildCheckinRecordsRes oRes)
		{
			int num = oRes.name.Count - this.m_LogList.Count;
			for (int i = 0; i < num; i++)
			{
				this.m_LogList.Add(new XGuildSignInLog());
			}
			bool flag = num < 0;
			if (flag)
			{
				this.m_LogList.RemoveRange(this.m_LogList.Count + num, -num);
			}
			for (int j = 0; j < this.m_LogList.Count; j++)
			{
				XGuildSignInLog xguildSignInLog = this.m_LogList[this.m_LogList.Count - j - 1] as XGuildSignInLog;
				xguildSignInLog.name = oRes.name[j];
				xguildSignInLog.uid = oRes.roleid[j];
				xguildSignInLog.type = oRes.type[j];
				xguildSignInLog.time = (int)oRes.timestamp[j];
			}
			bool flag2 = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
			if (flag2)
			{
				this.GuildSignInView.LogView.Refresh();
			}
		}

		// Token: 0x04003AE7 RID: 15079
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSignInDocument");

		// Token: 0x04003AE8 RID: 15080
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003AE9 RID: 15081
		private static GuildCheckinTable m_SignInTable = new GuildCheckinTable();

		// Token: 0x04003AEA RID: 15082
		private static GuildCheckinBoxTable m_BoxTable = new GuildCheckinBoxTable();

		// Token: 0x04003AEC RID: 15084
		private List<ILogData> m_LogList = new List<ILogData>();

		// Token: 0x04003AEF RID: 15087
		private uint _SignInSelection;

		// Token: 0x04003AF0 RID: 15088
		private uint _Progress;

		// Token: 0x04003AF1 RID: 15089
		private int _CanSignInSelection;

		// Token: 0x04003AF2 RID: 15090
		private bool _bHasAvailableChest;

		// Token: 0x04003AF3 RID: 15091
		private uint _BoxState;
	}
}
