using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPushSubscribeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPushSubscribeDocument.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = this.OptionsDefault.Count == 0 && XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF;
			if (flag)
			{
				this.ReqListSubscribe();
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.OptionsDefault.Count == 0 && XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF;
			if (flag)
			{
				this.ReqListSubscribe();
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XPushSubscribeDocument.AsyncLoader.AddTask("Table/PushSubscribe", XPushSubscribeDocument._PushSubscribeTable, false);
			XPushSubscribeDocument.AsyncLoader.Execute(callback);
		}

		public static PushSubscribeTable.RowData GetPushSubscribe(PushSubscribeOptions type)
		{
			return XPushSubscribeDocument.GetPushSubscribe((uint)XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(type));
		}

		public static PushSubscribeTable.RowData GetPushSubscribe(uint id)
		{
			return XPushSubscribeDocument._PushSubscribeTable.GetByMsgId(id);
		}

		private void ReqListSubscribe()
		{
			XSingleton<XDebug>.singleton.AddLog("ReqListSubscribe", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_GetListSubscribe rpcC2M_GetListSubscribe = new RpcC2M_GetListSubscribe();
			rpcC2M_GetListSubscribe.oArg.token = XSingleton<XClientNetwork>.singleton.OpenKey;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetListSubscribe);
		}

		public void OnListSubscribe(List<SubScribe> data)
		{
			this.OptionsDefault.Clear();
			for (int i = 0; i < XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(PushSubscribeOptions.MAX); i++)
			{
				this.OptionsDefault.Add(false);
			}
			for (int j = 0; j < data.Count; j++)
			{
				int id = (int)data[j].id;
				this.OptionsDefault[id] = data[j].status;
			}
			XSingleton<XDebug>.singleton.AddLog("OptionsDefault.Count" + this.OptionsDefault.Count, null, null, null, null, null, XDebugColor.XDebug_None);
			for (int k = 0; k < XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(PushSubscribeOptions.MAX); k++)
			{
				XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
				{
					"OptionsDefaultID:",
					k,
					" value:",
					this.OptionsDefault[k].ToString()
				}), null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		public void ReqSetSubscribe(PushSubscribeOptions type, bool op)
		{
			XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
			{
				"ReqSetSubscribe   type:",
				type,
				" op:",
				op.ToString()
			}), null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_SetSubscribe rpcC2M_SetSubscribe = new RpcC2M_SetSubscribe();
			rpcC2M_SetSubscribe.oArg.msgid.Add((uint)XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(type));
			rpcC2M_SetSubscribe.oArg.msgtype = (op ? 0 : 1);
			rpcC2M_SetSubscribe.oArg.token = XSingleton<XClientNetwork>.singleton.OpenKey;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SetSubscribe);
		}

		public void OnSetSubscribe(SetSubscirbeArg data)
		{
			int num = (int)data.msgid[0];
			bool flag = data.msgtype == 0;
			this.OptionsDefault[num] = flag;
			XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
			{
				"OnSetSubscribe index:",
				num,
				" status:",
				flag.ToString()
			}), null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag2 = flag;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("SUBSCRIBE_OK"), "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("SUBSCRIBE_CANCEL"), "fece00");
			}
			switch (num)
			{
			case 1:
			{
				bool flag3 = DlgBase<XWorldBossView, XWorldBossBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XWorldBossView, XWorldBossBehaviour>.singleton.RefreshSubscribe();
				}
				break;
			}
			case 2:
			{
				bool flag4 = DlgBase<XGuildDragonView, XGuildDragonBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					DlgBase<XGuildDragonView, XGuildDragonBehaviour>.singleton.RefreshSubscribe();
				}
				break;
			}
			case 3:
			{
				bool flag5 = DlgBase<XWelfareView, XWelfareBehaviour>.singleton.IsVisible();
				if (flag5)
				{
					DlgHandlerBase dlgHandlerBase;
					DlgBase<XWelfareView, XWelfareBehaviour>.singleton.m_AllHandlers.TryGetValue(XSysDefine.XSys_ReceiveEnergy, out dlgHandlerBase);
					ReceiveEnergyDlg receiveEnergyDlg = dlgHandlerBase as ReceiveEnergyDlg;
					receiveEnergyDlg.RefreshSubscribe();
				}
				break;
			}
			}
		}

		public bool GetCurSubscribeStatus(PushSubscribeOptions type)
		{
			int num = XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(type);
			bool flag = num >= this.OptionsDefault.Count;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"msgId:",
					num,
					" Options:",
					this.OptionsDefault.Count
				}), null, null, null, null, null);
				result = false;
			}
			else
			{
				result = this.OptionsDefault[num];
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PushSubscribeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PushSubscribeTable _PushSubscribeTable = new PushSubscribeTable();

		public List<bool> OptionsDefault = new List<bool>();
	}
}
