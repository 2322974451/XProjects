using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowSameQualityItemsView : DlgBase<XShowSameQualityItemsView, XShowSameQualityItemsBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/ShowSameQualityDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnUnload()
		{
			this._handler = null;
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOkBtnClicked));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnWrapContentInit));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContentItem));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseView));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshUI();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		private void OnWrapContentInit(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.Find("Item1/Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddItem));
			IXUISprite ixuisprite2 = itemTransform.Find("Item1/Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubItem));
			IXUISprite ixuisprite3 = itemTransform.Find("Item2/Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddItem));
			IXUISprite ixuisprite4 = itemTransform.Find("Item2/Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubItem));
		}

		private void OnSubItem(IXUISprite uiSprite)
		{
			int num = (int)uiSprite.ID;
			bool flag = num < this._itemList.Count;
			if (flag)
			{
				Transform transform = uiSprite.gameObject.transform.parent.FindChild("selNum");
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				int itemID = this._itemList[num].itemID;
				int itemCount = this._itemList[num].itemCount;
				bool flag2 = this._itemIDAndNumber.ContainsKey(num);
				if (flag2)
				{
					bool flag3 = this._itemIDAndNumber[num].Count > 1;
					if (flag3)
					{
						this._itemIDAndNumber[num].RemoveAt(this._itemIDAndNumber[num].Count - 1);
					}
					else
					{
						this._itemIDAndNumber.Remove(num);
					}
					this._totalNumber--;
					this._curProgress--;
					ixuilabel.SetText((this._itemIDAndNumber.ContainsKey(num) ? this._itemIDAndNumber[num].Count : 0).ToString());
					base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
				}
			}
		}

		private void OnAddItem(IXUISprite uiSprite)
		{
			int num = (int)uiSprite.ID;
			bool flag = num < this._itemList.Count;
			if (flag)
			{
				Transform transform = uiSprite.gameObject.transform.parent.FindChild("selNum");
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				int itemCount = this._itemList[num].itemCount;
				bool flag2 = this._itemIDAndNumber.ContainsKey(num);
				if (flag2)
				{
					bool flag3 = this._curProgress < this._maxNeeded;
					if (flag3)
					{
						bool flag4 = this._itemIDAndNumber[num].Count < this._itemList[num].itemCount;
						if (flag4)
						{
							this._itemIDAndNumber[num].Add(this._itemList[num].uid);
							this._curProgress++;
							this._totalNumber++;
							ixuilabel.SetText(this._itemIDAndNumber[num].Count.ToString());
							base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ItemNumberUpToMost"), "fece00");
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DoNotNeedMore"), "fece00");
					}
				}
				else
				{
					bool flag5 = this._curProgress < this._maxNeeded;
					if (flag5)
					{
						this._itemIDAndNumber.Add(num, new List<ulong>());
						this._itemIDAndNumber[num].Add(this._itemList[num].uid);
						this._curProgress++;
						this._totalNumber++;
						ixuilabel.SetText(this._itemIDAndNumber[num].Count.ToString());
						base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DoNotNeedMore"), "fece00");
					}
				}
			}
		}

		private void OnUpdateWrapContentItem(Transform itemTransform, int index)
		{
			bool flag = index * 2 >= this._itemList.Count;
			if (!flag)
			{
				Transform transform = itemTransform.Find("Item1");
				transform.gameObject.SetActive(true);
				int num = 2 * index;
				XItem info = this._itemList[num];
				this.UpdateSubItem(transform, info, num);
				Transform transform2 = itemTransform.Find("Item2");
				int num2 = num + 1;
				bool flag2 = num2 >= this._itemList.Count;
				if (flag2)
				{
					transform2.gameObject.SetActive(false);
				}
				else
				{
					transform2.gameObject.SetActive(true);
					XItem info2 = this._itemList[num2];
					this.UpdateSubItem(transform2, info2, num2);
				}
			}
		}

		private void UpdateSubItem(Transform item, XItem info, int index)
		{
			IXUISprite ixuisprite = item.Find("Count/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)index);
			IXUISprite ixuisprite2 = item.Find("Count/Sub").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.ID = (ulong)((long)index);
			int num = this._itemIDAndNumber.ContainsKey(index) ? this._itemIDAndNumber[index].Count : 0;
			IXUILabel ixuilabel = item.Find("Count/selNum").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(num.ToString());
			GameObject gameObject = item.Find("Item").gameObject;
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject, info);
			IXUISprite ixuisprite3 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite3.ID = info.uid;
			ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
		}

		private void OnClickItemIcon(IXUISprite spr)
		{
			XItem xitem = null;
			for (int i = 0; i < this._itemList.Count; i++)
			{
				bool flag = this._itemList[i].uid == spr.ID;
				if (flag)
				{
					xitem = this._itemList[i];
					break;
				}
			}
			bool flag2 = xitem != null;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(xitem, spr, false, 0U);
			}
		}

		protected override void OnHide()
		{
			this.ClearData();
			base.OnHide();
		}

		private void ClearData()
		{
			this._handler = null;
			this._totalNumber = 0;
			this._curProgress = 0;
			this._itemIDAndNumber.Clear();
			this._itemList.Clear();
			this._maxNeeded = 0;
		}

		public void ShowView(XShowSameQualityItemsView.SelectItemsHandler handler, ItemType type, ItemQuality quality, string tip, int maxNeeded, int current = 0)
		{
			this._handler = handler;
			this._itemType = type;
			this._itemQuality = quality;
			this._tip = tip;
			this._maxNeeded = maxNeeded;
			this._curProgress = current;
			this._itemList = XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)this._itemType, this._itemQuality);
			this.SetVisibleWithAnimation(true, null);
		}

		public void ShowView(XShowSameQualityItemsView.SelectItemsHandler handler, List<XItem> itemList, string tip, int maxNeeded, int current = 0)
		{
			this._handler = handler;
			this._tip = tip;
			this._maxNeeded = maxNeeded;
			this._curProgress = current;
			this._itemList = itemList;
			this.SetVisibleWithAnimation(true, null);
		}

		private void RefreshUI()
		{
			this._itemIDAndNumber.Clear();
			this._totalNumber = 0;
			base.uiBehaviour.progressLabel.SetText(this._curProgress + "/" + this._maxNeeded);
			this._itemList.Sort(new Comparison<XItem>(this.SortItemList));
			base.uiBehaviour.WrapContent.SetContentCount((this._itemList.Count + 1) / 2, false);
			base.uiBehaviour.ScrollView.ResetPosition();
			base.uiBehaviour.TipStr.SetText(this._tip);
		}

		private int SortItemList(XItem x, XItem y)
		{
			bool flag = x.itemConf.ReqLevel != y.itemConf.ReqLevel;
			int result;
			if (flag)
			{
				result = (int)(x.itemConf.ReqLevel - y.itemConf.ReqLevel);
			}
			else
			{
				result = x.itemID - y.itemID;
			}
			return result;
		}

		private bool OnOkBtnClicked(IXUIButton button)
		{
			List<ulong> list = new List<ulong>();
			foreach (List<ulong> collection in this._itemIDAndNumber.Values)
			{
				list.AddRange(collection);
			}
			bool flag = list.Count == 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ItemNoSelected"), "fece00");
			}
			else
			{
				bool flag2 = this._handler != null;
				if (flag2)
				{
					this._handler(list);
				}
				this.Close();
			}
			return true;
		}

		private void Close()
		{
			this._itemList.Clear();
			this._handler = null;
			this._tip = "";
			this.SetVisible(false, true);
		}

		private bool OnCloseView(IXUIButton button)
		{
			this.Close();
			return true;
		}

		private XShowSameQualityItemsView.SelectItemsHandler _handler = null;

		private List<XItem> _itemList = new List<XItem>();

		private ItemType _itemType;

		private ItemQuality _itemQuality;

		private string _tip;

		private Dictionary<int, List<ulong>> _itemIDAndNumber = new Dictionary<int, List<ulong>>();

		private int _totalNumber = 0;

		private int _maxNeeded;

		private int _curProgress = 0;

		public delegate void SelectItemsHandler(List<ulong> itemList);
	}
}
