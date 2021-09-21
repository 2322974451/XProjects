using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A6F RID: 2671
	internal class XRecycleItemDocument : XDocComponent
	{
		// Token: 0x17002F5C RID: 12124
		// (get) Token: 0x0600A25A RID: 41562 RVA: 0x001BA40C File Offset: 0x001B860C
		public override uint ID
		{
			get
			{
				return XRecycleItemDocument.uuID;
			}
		}

		// Token: 0x17002F5D RID: 12125
		// (get) Token: 0x0600A25B RID: 41563 RVA: 0x001BA423 File Offset: 0x001B8623
		// (set) Token: 0x0600A25C RID: 41564 RVA: 0x001BA42B File Offset: 0x001B862B
		public RecycleItemOperateView OperateView { get; set; }

		// Token: 0x17002F5E RID: 12126
		// (get) Token: 0x0600A25D RID: 41565 RVA: 0x001BA434 File Offset: 0x001B8634
		// (set) Token: 0x0600A25E RID: 41566 RVA: 0x001BA43C File Offset: 0x001B863C
		public RecycleItemBagView BagView { get; set; }

		// Token: 0x17002F5F RID: 12127
		// (get) Token: 0x0600A25F RID: 41567 RVA: 0x001BA445 File Offset: 0x001B8645
		// (set) Token: 0x0600A260 RID: 41568 RVA: 0x001BA44D File Offset: 0x001B864D
		public XSysDefine CurrentSys { get; set; }

		// Token: 0x17002F60 RID: 12128
		// (get) Token: 0x0600A261 RID: 41569 RVA: 0x001BA458 File Offset: 0x001B8658
		public Dictionary<ulong, ulong> SelectedItems
		{
			get
			{
				return this.m_SelectedItems;
			}
		}

		// Token: 0x0600A263 RID: 41571 RVA: 0x001BA48D File Offset: 0x001B868D
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangeFinished));
		}

		// Token: 0x0600A264 RID: 41572 RVA: 0x001BA4AC File Offset: 0x001B86AC
		protected bool OnItemChangeFinished(XEventArgs args)
		{
			bool flag = this.BagView != null && this.BagView.active;
			if (flag)
			{
				this.BagView.UpdateView();
			}
			return true;
		}

		// Token: 0x0600A265 RID: 41573 RVA: 0x001BA4E8 File Offset: 0x001B86E8
		public void RefreshUI()
		{
			bool flag = this.BagView != null && this.BagView.active;
			if (flag)
			{
				this.BagView.Refresh();
			}
			bool flag2 = this.OperateView != null && this.OperateView.active;
			if (flag2)
			{
				this.OperateView.Refresh();
			}
		}

		// Token: 0x0600A266 RID: 41574 RVA: 0x001BA544 File Offset: 0x001B8744
		public List<XItem> GetItems()
		{
			this.m_ItemList.Clear();
			for (int i = 0; i < XBagDocument.BagDoc.ItemBag.Count; i++)
			{
				bool flag = XBagDocument.BagDoc.ItemBag[i].itemConf.IsCanRecycle == 1;
				if (flag)
				{
					this.m_ItemList.Add(XBagDocument.BagDoc.ItemBag[i]);
				}
			}
			return this.m_ItemList;
		}

		// Token: 0x0600A267 RID: 41575 RVA: 0x001BA5C8 File Offset: 0x001B87C8
		public void GetQuickSelectItems(int mask)
		{
			List<XItem> items = this.GetItems();
			this.ResetSelection(false);
			foreach (XItem xitem in items)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(xitem.itemID);
				int num = 1 << (int)itemConf.ItemQuality;
				bool flag = (num & mask) == 0;
				if (!flag)
				{
					bool flag2 = xitem.itemCount > 1;
					if (!flag2)
					{
						this._ToggleItemSelect(true, xitem.uid, 1UL, false);
						bool isSelectionFull = this.IsSelectionFull;
						if (isSelectionFull)
						{
							break;
						}
					}
				}
			}
			this.RefreshUI();
		}

		// Token: 0x0600A268 RID: 41576 RVA: 0x001BA684 File Offset: 0x001B8884
		public void ResetSelection(bool bRefreshUI)
		{
			this.m_SelectedItems.Clear();
			if (bRefreshUI)
			{
				this.RefreshUI();
			}
		}

		// Token: 0x0600A269 RID: 41577 RVA: 0x001BA6AC File Offset: 0x001B88AC
		public bool IsSelected(ulong uid, out int leftCount)
		{
			leftCount = 0;
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
			bool flag = this.m_SelectedItems.ContainsKey(uid);
			bool result;
			if (flag)
			{
				bool flag2 = itemByUID != null;
				if (flag2)
				{
					leftCount = itemByUID.itemCount - (int)this.m_SelectedItems[uid];
					leftCount = ((leftCount < 0) ? 0 : leftCount);
				}
				result = true;
			}
			else
			{
				bool flag3 = itemByUID != null;
				if (flag3)
				{
					leftCount = itemByUID.itemCount;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600A26A RID: 41578 RVA: 0x001BA724 File Offset: 0x001B8924
		private bool IsSelectFull(ulong uid)
		{
			bool flag = this.m_SelectedItems.ContainsKey(uid);
			bool result;
			if (flag)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
				bool flag2 = itemByUID != null;
				if (flag2)
				{
					result = (itemByUID.itemCount > 999);
				}
				else
				{
					this.m_SelectedItems.Remove(uid);
					result = false;
				}
			}
			else
			{
				result = this.IsSelectionFull;
			}
			return result;
		}

		// Token: 0x0600A26B RID: 41579 RVA: 0x001BA784 File Offset: 0x001B8984
		public int GetSelectUidCount(ulong uid)
		{
			ulong num = 0UL;
			this.m_SelectedItems.TryGetValue(uid, out num);
			return (int)num;
		}

		// Token: 0x17002F61 RID: 12129
		// (get) Token: 0x0600A26C RID: 41580 RVA: 0x001BA7AC File Offset: 0x001B89AC
		public bool IsSelectionFull
		{
			get
			{
				return (long)this.m_SelectedItems.Count >= (long)((ulong)XRecycleItemDocument.MAX_RECYCLE_COUNT);
			}
		}

		// Token: 0x0600A26D RID: 41581 RVA: 0x001BA7D8 File Offset: 0x001B89D8
		public void ToggleItemSelect(ulong uid)
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
			bool flag = itemByUID != null;
			if (flag)
			{
				bool flag2 = itemByUID.itemCount == 1;
				if (flag2)
				{
					this._ToggleItemSelect(true, uid, 1UL, true);
				}
				else
				{
					bool flag3 = !this.IsSelectFull(uid);
					if (flag3)
					{
						DlgBase<SelectNumFrameDlg, SelectNumFrameBehaviour>.singleton.Show(uid);
					}
				}
			}
		}

		// Token: 0x0600A26E RID: 41582 RVA: 0x001BA834 File Offset: 0x001B8A34
		public void ToggleItemUnSelect(ulong uid)
		{
			bool flag = this.m_SelectedItems.ContainsKey(uid);
			if (flag)
			{
				this._ToggleItemSelect(false, uid, this.m_SelectedItems[uid], true);
			}
		}

		// Token: 0x0600A26F RID: 41583 RVA: 0x001BA868 File Offset: 0x001B8A68
		public void _ToggleItemSelect(bool select, ulong uid, ulong count, bool bRefreshUI)
		{
			bool flag = false;
			if (select)
			{
				bool isSelectionFull = this.IsSelectionFull;
				if (isSelectionFull)
				{
					bool flag2 = this.m_SelectedItems.ContainsKey(uid);
					if (flag2)
					{
						Dictionary<ulong, ulong> selectedItems = this.m_SelectedItems;
						selectedItems[uid] += count;
						this.m_SelectedItems[uid] = ((this.m_SelectedItems[uid] >= 999UL) ? 999UL : this.m_SelectedItems[uid]);
						flag = true;
					}
				}
				else
				{
					bool flag3 = this.m_SelectedItems.ContainsKey(uid);
					if (flag3)
					{
						Dictionary<ulong, ulong> selectedItems = this.m_SelectedItems;
						selectedItems[uid] += count;
						this.m_SelectedItems[uid] = ((this.m_SelectedItems[uid] >= 999UL) ? 999UL : this.m_SelectedItems[uid]);
					}
					else
					{
						this.m_SelectedItems.Add(uid, count);
					}
					flag = true;
				}
			}
			else
			{
				flag = this.m_SelectedItems.Remove(uid);
			}
			bool flag4 = flag && bRefreshUI;
			if (flag4)
			{
				bool flag5 = this.BagView != null && this.BagView.active;
				if (flag5)
				{
					this.BagView.Refresh();
				}
				bool flag6 = this.OperateView != null && this.OperateView.active;
				if (flag6)
				{
					bool flag7 = this.m_SelectedItems.ContainsKey(uid);
					if (flag7)
					{
						this.OperateView.ToggleItem(uid, this.m_SelectedItems[uid], select);
					}
					else
					{
						this.OperateView.ToggleItem(uid, 1UL, select);
					}
				}
			}
		}

		// Token: 0x0600A270 RID: 41584 RVA: 0x001BAA1C File Offset: 0x001B8C1C
		public void Recycle()
		{
			bool flag = this.m_SelectedItems.Count == 0;
			if (!flag)
			{
				RpcC2G_DecomposeEquipment rpcC2G_DecomposeEquipment = new RpcC2G_DecomposeEquipment();
				foreach (KeyValuePair<ulong, ulong> keyValuePair in this.m_SelectedItems)
				{
					rpcC2G_DecomposeEquipment.oArg.equipuniqueid.Add(keyValuePair.Key);
					rpcC2G_DecomposeEquipment.oArg.count.Add((uint)keyValuePair.Value);
				}
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_DecomposeEquipment);
				this.ResetSelection(false);
				bool flag2 = this.OperateView != null && this.OperateView.active;
				if (flag2)
				{
					this.OperateView.Refresh();
				}
			}
		}

		// Token: 0x0600A271 RID: 41585 RVA: 0x001BAAF8 File Offset: 0x001B8CF8
		public void OnRecycle(DecomposeEquipmentRes oRes)
		{
			bool flag = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
			}
			else
			{
				bool flag2 = oRes.param.Count > 0 && oRes.param[0] > 1f;
				if (flag2)
				{
					bool flag3 = this.OperateView != null && this.OperateView.active;
					if (flag3)
					{
						this.OperateView.PlayCritical();
					}
				}
			}
		}

		// Token: 0x0600A272 RID: 41586 RVA: 0x001BAB7C File Offset: 0x001B8D7C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.BagView != null && this.BagView.active;
			if (flag)
			{
				this.BagView.Refresh();
			}
			bool flag2 = this.OperateView != null && this.OperateView.active;
			if (flag2)
			{
				this.OperateView.Refresh();
			}
		}

		// Token: 0x04003A9F RID: 15007
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RecycleItemDocument");

		// Token: 0x04003AA0 RID: 15008
		public static readonly uint MAX_RECYCLE_COUNT = 5U;

		// Token: 0x04003AA4 RID: 15012
		private Dictionary<ulong, ulong> m_SelectedItems = new Dictionary<ulong, ulong>();

		// Token: 0x04003AA5 RID: 15013
		private List<XItem> m_ItemList = new List<XItem>();
	}
}
