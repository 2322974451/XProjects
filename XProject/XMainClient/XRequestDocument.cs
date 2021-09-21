using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000969 RID: 2409
	internal class XRequestDocument : XDocComponent
	{
		// Token: 0x17002C5A RID: 11354
		// (get) Token: 0x06009123 RID: 37155 RVA: 0x0014BEC0 File Offset: 0x0014A0C0
		public List<PartyExchangeItemInfo> List
		{
			get
			{
				return this._list;
			}
		}

		// Token: 0x17002C5B RID: 11355
		// (get) Token: 0x06009124 RID: 37156 RVA: 0x0014BED8 File Offset: 0x0014A0D8
		public override uint ID
		{
			get
			{
				return XRequestDocument.uuID;
			}
		}

		// Token: 0x06009125 RID: 37157 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009126 RID: 37158 RVA: 0x0014BEF0 File Offset: 0x0014A0F0
		public void QueryRequestList()
		{
			RpcC2G_GetGuildCampPartyExchangeInfo rpc = new RpcC2G_GetGuildCampPartyExchangeInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009127 RID: 37159 RVA: 0x0014BF10 File Offset: 0x0014A110
		public void OnRequestListGet(List<PartyExchangeItemInfo> list)
		{
			this._list.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				this._list.Add(this.Copy(list[i]));
			}
			bool flag = DlgBase<RequestDlg, RequestBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<RequestDlg, RequestBehaviour>.singleton.Refresh(true);
			}
		}

		// Token: 0x06009128 RID: 37160 RVA: 0x0014BF74 File Offset: 0x0014A174
		public void RemoveList(bool isAll, ulong uid)
		{
			if (isAll)
			{
				this._list.Clear();
			}
			else
			{
				for (int i = 0; i < this._list.Count; i++)
				{
					bool flag = this._list[i].role_id == uid;
					if (flag)
					{
						this._list.RemoveAt(i);
						break;
					}
				}
			}
			bool flag2 = DlgBase<RequestDlg, RequestBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<RequestDlg, RequestBehaviour>.singleton.Refresh(true);
			}
		}

		// Token: 0x06009129 RID: 37161 RVA: 0x0014BFF8 File Offset: 0x0014A1F8
		public PartyExchangeItemInfo Copy(PartyExchangeItemInfo info)
		{
			return new PartyExchangeItemInfo
			{
				level = info.level,
				name = info.name,
				profession_id = info.profession_id,
				time = info.time,
				role_id = info.role_id
			};
		}

		// Token: 0x0600912A RID: 37162 RVA: 0x0014C054 File Offset: 0x0014A254
		public void ClearList()
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		// Token: 0x0600912B RID: 37163 RVA: 0x0014C084 File Offset: 0x0014A284
		public void QueryAcceptExchange(ulong uid)
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.lauch_role_id = uid;
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 3U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		// Token: 0x0600912C RID: 37164 RVA: 0x0014C0C0 File Offset: 0x0014A2C0
		public void QueryRefuseExchange(ulong uid)
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.lauch_role_id = uid;
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		// Token: 0x0600912D RID: 37165 RVA: 0x0014C0FA File Offset: 0x0014A2FA
		public void SetMainInterfaceNum(int num)
		{
			this.MainInterfaceNum = num;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Exchange, true);
		}

		// Token: 0x0400301F RID: 12319
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RequestDocument");

		// Token: 0x04003020 RID: 12320
		private List<PartyExchangeItemInfo> _list = new List<PartyExchangeItemInfo>();

		// Token: 0x04003021 RID: 12321
		public int MainInterfaceNum = 0;
	}
}
