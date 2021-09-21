using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200097F RID: 2431
	internal class XPushSubscribeDocument : XDocComponent
	{
		// Token: 0x17002C9A RID: 11418
		// (get) Token: 0x06009258 RID: 37464 RVA: 0x00151D70 File Offset: 0x0014FF70
		public override uint ID
		{
			get
			{
				return XPushSubscribeDocument.uuID;
			}
		}

		// Token: 0x06009259 RID: 37465 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600925A RID: 37466 RVA: 0x00151D88 File Offset: 0x0014FF88
		public override void OnEnterSceneFinally()
		{
			bool flag = this.OptionsDefault.Count == 0 && XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF;
			if (flag)
			{
				this.ReqListSubscribe();
			}
		}

		// Token: 0x0600925B RID: 37467 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600925C RID: 37468 RVA: 0x00151DC0 File Offset: 0x0014FFC0
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.OptionsDefault.Count == 0 && XSingleton<XClientNetwork>.singleton.AccountType == LoginType.LGOIN_WECHAT_PF;
			if (flag)
			{
				this.ReqListSubscribe();
			}
		}

		// Token: 0x0600925D RID: 37469 RVA: 0x00151DF8 File Offset: 0x0014FFF8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPushSubscribeDocument.AsyncLoader.AddTask("Table/PushSubscribe", XPushSubscribeDocument._PushSubscribeTable, false);
			XPushSubscribeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600925E RID: 37470 RVA: 0x00151E20 File Offset: 0x00150020
		public static PushSubscribeTable.RowData GetPushSubscribe(PushSubscribeOptions type)
		{
			return XPushSubscribeDocument.GetPushSubscribe((uint)XFastEnumIntEqualityComparer<PushSubscribeOptions>.ToInt(type));
		}

		// Token: 0x0600925F RID: 37471 RVA: 0x00151E40 File Offset: 0x00150040
		public static PushSubscribeTable.RowData GetPushSubscribe(uint id)
		{
			return XPushSubscribeDocument._PushSubscribeTable.GetByMsgId(id);
		}

		// Token: 0x06009260 RID: 37472 RVA: 0x00151E60 File Offset: 0x00150060
		private void ReqListSubscribe()
		{
			XSingleton<XDebug>.singleton.AddLog("ReqListSubscribe", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_GetListSubscribe rpcC2M_GetListSubscribe = new RpcC2M_GetListSubscribe();
			rpcC2M_GetListSubscribe.oArg.token = XSingleton<XClientNetwork>.singleton.OpenKey;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetListSubscribe);
		}

		// Token: 0x06009261 RID: 37473 RVA: 0x00151EAC File Offset: 0x001500AC
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

		// Token: 0x06009262 RID: 37474 RVA: 0x00151FC0 File Offset: 0x001501C0
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

		// Token: 0x06009263 RID: 37475 RVA: 0x00152060 File Offset: 0x00150260
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

		// Token: 0x06009264 RID: 37476 RVA: 0x001521A8 File Offset: 0x001503A8
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

		// Token: 0x040030F4 RID: 12532
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PushSubscribeDocument");

		// Token: 0x040030F5 RID: 12533
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040030F6 RID: 12534
		private static PushSubscribeTable _PushSubscribeTable = new PushSubscribeTable();

		// Token: 0x040030F7 RID: 12535
		public List<bool> OptionsDefault = new List<bool>();
	}
}
