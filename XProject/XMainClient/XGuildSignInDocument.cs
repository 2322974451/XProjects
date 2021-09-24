using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSignInDocument : XDocComponent, ILogSource
	{

		public override uint ID
		{
			get
			{
				return XGuildSignInDocument.uuID;
			}
		}

		public XGuildSignInView GuildSignInView { get; set; }

		public List<ILogData> GetLogList()
		{
			return this.m_LogList;
		}

		public uint TotalCount { get; set; }

		public uint CurrentCount { get; set; }

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

		public uint Progress
		{
			get
			{
				return this._Progress;
			}
		}

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

		public int CanSignInSelection
		{
			get
			{
				return this._CanSignInSelection;
			}
		}

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

		public bool bHasAvailableChest
		{
			get
			{
				return this._bHasAvailableChest;
			}
		}

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

		public bool IsBoxOpen(int index)
		{
			return ((ulong)this._BoxState & (ulong)(1L << (index & 31))) > 0UL;
		}

		public void SetBoxOpen(int index)
		{
			this._BoxState |= 1U << index;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSignInDocument.AsyncLoader.AddTask("Table/GuildCheckin", XGuildSignInDocument.m_SignInTable, false);
			XGuildSignInDocument.AsyncLoader.AddTask("Table/GuildCheckinBox", XGuildSignInDocument.m_BoxTable, false);
			XGuildSignInDocument.AsyncLoader.Execute(callback);
		}

		public static GuildCheckinTable.RowData[] GetSignInTableData()
		{
			return XGuildSignInDocument.m_SignInTable.Table;
		}

		public static GuildCheckinBoxTable.RowData[] GetBoxTableData()
		{
			return XGuildSignInDocument.m_BoxTable.Table;
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._Progress = 0U;
			this._BoxState = 0U;
			this._bHasAvailableChest = false;
			this.SignInSelection = 100U;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildSignInView != null && this.GuildSignInView.IsVisible();
			if (flag)
			{
				this.ReqAllInfo();
			}
		}

		public void ReqAllInfo()
		{
			RpcC2M_QueryGuildCheckinNew rpc = new RpcC2M_QueryGuildCheckinNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ReqFetchBox(uint index)
		{
			RpcC2G_GetGuildCheckinBox rpcC2G_GetGuildCheckinBox = new RpcC2G_GetGuildCheckinBox();
			rpcC2G_GetGuildCheckinBox.oArg.index = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetGuildCheckinBox);
		}

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

		public void ReqSignIn(uint index)
		{
			RpcC2M_GuildCheckinNew rpcC2M_GuildCheckinNew = new RpcC2M_GuildCheckinNew();
			rpcC2M_GuildCheckinNew.oArg.type = index;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildCheckinNew);
		}

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

		public void ReqLogList()
		{
			RpcC2M_GetGuildCheckinRecordsNew rpc = new RpcC2M_GetGuildCheckinRecordsNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSignInDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GuildCheckinTable m_SignInTable = new GuildCheckinTable();

		private static GuildCheckinBoxTable m_BoxTable = new GuildCheckinBoxTable();

		private List<ILogData> m_LogList = new List<ILogData>();

		private uint _SignInSelection;

		private uint _Progress;

		private int _CanSignInSelection;

		private bool _bHasAvailableChest;

		private uint _BoxState;
	}
}
