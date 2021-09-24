using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRequestDocument : XDocComponent
	{

		public List<PartyExchangeItemInfo> List
		{
			get
			{
				return this._list;
			}
		}

		public override uint ID
		{
			get
			{
				return XRequestDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void QueryRequestList()
		{
			RpcC2G_GetGuildCampPartyExchangeInfo rpc = new RpcC2G_GetGuildCampPartyExchangeInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void ClearList()
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 2U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		public void QueryAcceptExchange(ulong uid)
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.lauch_role_id = uid;
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 3U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		public void QueryRefuseExchange(ulong uid)
		{
			RpcC2G_ReplyPartyExchangeItemOpt rpcC2G_ReplyPartyExchangeItemOpt = new RpcC2G_ReplyPartyExchangeItemOpt();
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.lauch_role_id = uid;
			rpcC2G_ReplyPartyExchangeItemOpt.oArg.operate_type = 1U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReplyPartyExchangeItemOpt);
		}

		public void SetMainInterfaceNum(int num)
		{
			this.MainInterfaceNum = num;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Exchange, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RequestDocument");

		private List<PartyExchangeItemInfo> _list = new List<PartyExchangeItemInfo>();

		public int MainInterfaceNum = 0;
	}
}
