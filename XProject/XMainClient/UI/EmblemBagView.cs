using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EmblemBagView : DlgHandlerBase
	{

		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		private XItemMorePowerfulTipMgr newItemMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.NewItemMgr;
			}
		}

		private XBagWindow bagWindow
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.BagWindow;
			}
		}

		public string IdentifyEffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_identifyEffectPath);
				if (flag)
				{
					this.m_identifyEffectPath = XSingleton<XGlobalConfig>.singleton.GetValue("EmblemIdentifyEffectPath");
				}
				return this.m_identifyEffectPath;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EmblemListPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			this._doc._BagHandler = this;
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_bagNumLab = (base.PanelObject.transform.FindChild("Panel/BagNum").GetComponent("XUILabel") as IXUILabel);
			this.m_expandBagBtn = (base.PanelObject.transform.FindChild("add").GetComponent("XUIButton") as IXUIButton);
			BagExpandItemListTable.RowData expandItemConfByType = XBagDocument.GetExpandItemConfByType((uint)XFastEnumIntEqualityComparer<BagType>.ToInt(BagType.EmblemBag));
			this.m_expandBagBtn.gameObject.SetActive(expandItemConfByType != null);
			this.EffectTra = base.PanelObject.transform.FindChild("Effect");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_expandBagBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBagExpandClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Char_Emblem);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Show();
		}

		private void Show()
		{
			this.bagWindow.ChangeData(new ItemUpdateHandler(this.WrapContentItemUpdated), new GetItemHandler(this._doc.GetEmblemItems));
			this.bagWindow.OnShow();
			this.SetBagNum();
			this._doc.NewItems.bCanClear = true;
		}

		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this.newItemMgr.ReturnAll();
			this.bagWindow.OnHide();
			this._doc.NewItems.TryClear();
			this.itemBtnDic.Clear();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.HideEffect(this.m_identifyFx);
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Show();
		}

		public override void OnUnload()
		{
			this._doc._BagHandler = null;
			bool flag = this.m_identifyFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_identifyFx, true);
				this.m_identifyFx = null;
			}
			base.OnUnload();
		}

		public void Refresh()
		{
			this.bagWindow.RefreshWindow();
			this.SetBagNum();
		}

		public void RefreshTips(ulong uid)
		{
			IXUISprite ixuisprite;
			bool flag = this.itemBtnDic.TryGetValue(uid, out ixuisprite);
			if (flag)
			{
				bool flag2 = ixuisprite != null;
				if (flag2)
				{
					this.OnItemClicked(ixuisprite);
				}
			}
		}

		private void SetBagNum()
		{
			int count = this._doc.GetEmblemItems().Count;
			XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
			VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP((int)specificDocument.VipLevel);
			bool flag = byVIP != null;
			if (flag)
			{
				uint num = byVIP.EmblemMax;
				BagExpandData bagExpandData = XBagDocument.BagDoc.GetBagExpandData(BagType.EmblemBag);
				bool flag2 = bagExpandData != null;
				if (flag2)
				{
					num += bagExpandData.ExpandNum;
				}
				bool flag3 = (long)count >= (long)((ulong)num);
				if (flag3)
				{
					this.m_bagNumLab.SetText(string.Format("[ff4366]{0}[-]/{1}", count, num));
				}
				else
				{
					this.m_bagNumLab.SetText(string.Format("{0}[-]/{1}", count, num));
				}
			}
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			Transform transform = t.FindChild("Icon/SupplementBrought");
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(false);
			}
			IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			bool flag2 = this.bagWindow.m_XItemList == null || index >= this.bagWindow.m_XItemList.Count || index < 0;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, null);
				this.powerfullMgr.ReturnInstance(ixuisprite);
				this.newItemMgr.ReturnInstance(ixuisprite);
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("empty", index.ToString());
			}
			else
			{
				t.gameObject.name = XSingleton<XCommon>.singleton.StringCombine("emblem", this.bagWindow.m_XItemList[index].itemID.ToString());
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(t.gameObject, this.bagWindow.m_XItemList[index]);
				ixuisprite.ID = this.bagWindow.m_XItemList[index].uid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
				bool flag3 = this.itemBtnDic.ContainsKey(ixuisprite.ID);
				if (flag3)
				{
					this.itemBtnDic[ixuisprite.ID] = ixuisprite;
				}
				else
				{
					this.itemBtnDic.Add(ixuisprite.ID, ixuisprite);
				}
				XEmblemItem xemblemItem = this.bagWindow.m_XItemList[index] as XEmblemItem;
				bool flag4 = this._doc.IsEmblemMorePowerful(ixuisprite.ID);
				if (flag4)
				{
					this.powerfullMgr.SetTip(ixuisprite);
				}
				else
				{
					this.powerfullMgr.ReturnInstance(ixuisprite);
				}
				bool flag5 = this._doc.NewItems.IsNew(ixuisprite.ID);
				if (flag5)
				{
					this.newItemMgr.SetTip(ixuisprite);
				}
				else
				{
					this.newItemMgr.ReturnInstance(ixuisprite);
				}
			}
		}

		public void ShowEmblemIdentifyEffect()
		{
			bool flag = this.m_identifyFx == null;
			if (flag)
			{
				this.m_identifyFx = XSingleton<XFxMgr>.singleton.CreateFx(this.IdentifyEffectPath, null, true);
			}
			else
			{
				this.m_identifyFx.SetActive(true);
			}
			this.m_identifyFx.Play(this.EffectTra, Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.m_emblemIdentifyToken = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(5f, new XTimerMgr.AccurateElapsedEventHandler(this.OnEmblemIdentifyTimer), null);
		}

		private void OnEmblemIdentifyTimer(object param, float delay)
		{
			this.HideEffect(this.m_identifyFx);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_emblemIdentifyToken);
			this.m_emblemIdentifyToken = 0U;
		}

		private void HideEffect(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				fx.Stop();
				fx.SetActive(false);
			}
		}

		public void OnItemClicked(IXUISprite iSp)
		{
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(iSp.ID);
			bool flag = itemByUID == null;
			if (!flag)
			{
				bool flag2 = this._doc.NewItems.RemoveItem(iSp.ID, itemByUID.Type, false);
				if (flag2)
				{
					this.Refresh();
				}
				CharacterEquipHandler.OnItemClicked(iSp);
			}
		}

		public void OnAddItem()
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		public void OnRemoveItem()
		{
			this.bagWindow.UpdateBag();
			this.SetBagNum();
		}

		public void OnItemCountChanged(XItem item)
		{
			this.bagWindow.UpdateItem(item);
		}

		public void OnSwapItem(XItem item1, XItem item2, int slot)
		{
			this.bagWindow.ReplaceItem(item1, item2);
		}

		public void OnUpdateItem(XItem item)
		{
			this.bagWindow.UpdateItem(item);
		}

		public bool OnBagExpandClicked(IXUIButton button)
		{
			XBagDocument.BagDoc.UseBagExpandTicket(BagType.EmblemBag);
			return true;
		}

		public IXUIButton m_Help;

		private XEmblemDocument _doc;

		private IXUILabel m_bagNumLab;

		private Dictionary<ulong, IXUISprite> itemBtnDic = new Dictionary<ulong, IXUISprite>();

		public IXUIButton m_expandBagBtn;

		private Transform EffectTra;

		private XFx m_identifyFx;

		private uint m_emblemIdentifyToken = 0U;

		private string m_identifyEffectPath = string.Empty;
	}
}
