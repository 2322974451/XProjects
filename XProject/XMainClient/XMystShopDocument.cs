using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009E7 RID: 2535
	internal class XMystShopDocument : XDocComponent
	{
		// Token: 0x17002E1B RID: 11803
		// (get) Token: 0x06009AF4 RID: 39668 RVA: 0x00189D14 File Offset: 0x00187F14
		public override uint ID
		{
			get
			{
				return XMystShopDocument.uuID;
			}
		}

		// Token: 0x17002E1C RID: 11804
		// (get) Token: 0x06009AF5 RID: 39669 RVA: 0x00189D2C File Offset: 0x00187F2C
		public List<XMystShopGoods> GoodsList
		{
			get
			{
				return this.m_goodsList;
			}
		}

		// Token: 0x17002E1D RID: 11805
		// (get) Token: 0x06009AF6 RID: 39670 RVA: 0x00189D44 File Offset: 0x00187F44
		// (set) Token: 0x06009AF7 RID: 39671 RVA: 0x00189D5C File Offset: 0x00187F5C
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

		// Token: 0x17002E1E RID: 11806
		// (get) Token: 0x06009AF8 RID: 39672 RVA: 0x00189D68 File Offset: 0x00187F68
		public uint refreshCost
		{
			get
			{
				return this._refreshCost;
			}
		}

		// Token: 0x06009AF9 RID: 39673 RVA: 0x00189D80 File Offset: 0x00187F80
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTimer);
			this.refreshTimer = 0U;
		}

		// Token: 0x06009AFA RID: 39674 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ReqOperateMystShop(MythShopOP operation, int index = 0)
		{
		}

		// Token: 0x06009AFB RID: 39675 RVA: 0x00189DA2 File Offset: 0x00187FA2
		private void _QueryMythShop(object o = null)
		{
			this.ReqOperateMystShop(MythShopOP.MythShopQuery, 0);
		}

		// Token: 0x06009AFC RID: 39676 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003578 RID: 13688
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MystShopDocument");

		// Token: 0x04003579 RID: 13689
		private List<XMystShopGoods> m_goodsList = new List<XMystShopGoods>();

		// Token: 0x0400357A RID: 13690
		private XMystShopView _view = null;

		// Token: 0x0400357B RID: 13691
		private uint refreshTimer = 0U;

		// Token: 0x0400357C RID: 13692
		private uint _refreshCost = 0U;
	}
}
