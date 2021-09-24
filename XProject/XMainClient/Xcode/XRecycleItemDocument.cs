using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XRecycleItemDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XRecycleItemDocument.uuID;
			}
		}

		public RecycleItemOperateView OperateView { get; set; }

		public RecycleItemBagView BagView { get; set; }

		public XSysDefine CurrentSys { get; set; }

		public Dictionary<ulong, ulong> SelectedItems
		{
			get
			{
				return this.m_SelectedItems;
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnItemChangeFinished));
		}

		protected bool OnItemChangeFinished(XEventArgs args)
		{
			bool flag = this.BagView != null && this.BagView.active;
			if (flag)
			{
				this.BagView.UpdateView();
			}
			return true;
		}

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

		public void ResetSelection(bool bRefreshUI)
		{
			this.m_SelectedItems.Clear();
			if (bRefreshUI)
			{
				this.RefreshUI();
			}
		}

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

		public int GetSelectUidCount(ulong uid)
		{
			ulong num = 0UL;
			this.m_SelectedItems.TryGetValue(uid, out num);
			return (int)num;
		}

		public bool IsSelectionFull
		{
			get
			{
				return (long)this.m_SelectedItems.Count >= (long)((ulong)XRecycleItemDocument.MAX_RECYCLE_COUNT);
			}
		}

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

		public void ToggleItemUnSelect(ulong uid)
		{
			bool flag = this.m_SelectedItems.ContainsKey(uid);
			if (flag)
			{
				this._ToggleItemSelect(false, uid, this.m_SelectedItems[uid], true);
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("RecycleItemDocument");

		public static readonly uint MAX_RECYCLE_COUNT = 5U;

		private Dictionary<ulong, ulong> m_SelectedItems = new Dictionary<ulong, ulong>();

		private List<XItem> m_ItemList = new List<XItem>();
	}
}
