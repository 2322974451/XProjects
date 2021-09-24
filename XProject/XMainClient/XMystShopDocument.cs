using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMystShopDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMystShopDocument.uuID;
			}
		}

		public List<XMystShopGoods> GoodsList
		{
			get
			{
				return this.m_goodsList;
			}
		}

		public XMystShopView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public uint refreshCost
		{
			get
			{
				return this._refreshCost;
			}
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTimer);
			this.refreshTimer = 0U;
		}

		public void ReqOperateMystShop(MythShopOP operation, int index = 0)
		{
		}

		private void _QueryMythShop(object o = null)
		{
			this.ReqOperateMystShop(MythShopOP.MythShopQuery, 0);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MystShopDocument");

		private List<XMystShopGoods> m_goodsList = new List<XMystShopGoods>();

		private XMystShopView _view = null;

		private uint refreshTimer = 0U;

		private uint _refreshCost = 0U;
	}
}
