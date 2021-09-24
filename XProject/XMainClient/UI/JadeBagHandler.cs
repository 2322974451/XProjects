using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JadeBagHandler : DlgHandlerBase
	{

		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeListPanel";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			this.m_WrapContent = (base.PanelObject.transform.Find("BagPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.PanelObject.transform.Find("BagPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_Limit = (base.PanelObject.transform.Find("Limit").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnBagWrapContentUpdated));
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this._doc.NewItems.bCanClear = true;
		}

		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this._doc.NewItems.TryClear();
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.powerfullMgr.Unload();
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.m_WrapContent.SetContentCount(this._doc.SelectedSlotItemList.Count, false);
			this.m_ScrollView.ResetPosition();
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				int num = this._doc.EquipLevel2JadeLevel(level);
				this.m_Limit.SetText(XStringDefineProxy.GetString("JADE_LEVEL_REQUIREMENT", new object[]
				{
					level.ToString(),
					num.ToString()
				}));
			}
			else
			{
				this.m_Limit.SetText(string.Empty);
			}
		}

		private void _OnBagWrapContentUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.SelectedSlotItemList.Count;
			if (!flag)
			{
				XEquipItem xequipItem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(this._doc.selectedEquip) as XEquipItem;
				bool flag2 = xequipItem == null;
				if (!flag2)
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(xequipItem.itemID);
					bool flag3 = equipConf == null;
					if (!flag3)
					{
						XJadeItem xjadeItem = this._doc.SelectedSlotItemList[index] as XJadeItem;
						JadeEquipHandler.DrawJadeWithAttr(t.gameObject, this._doc.GetSlot(equipConf.EquipPos, this._doc.selectedSlotIndex), xjadeItem, 0U);
						IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)index);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBagJadeClicked));
						IXUISprite ixuisprite2 = t.Find("JadeTpl/Icon").GetComponent("XUISprite") as IXUISprite;
						bool flag4 = this._doc.CanBeMorePowerful(xequipItem, this._doc.selectedSlotIndex, xjadeItem);
						if (flag4)
						{
							this.powerfullMgr.SetTip(ixuisprite2);
						}
						else
						{
							this.powerfullMgr.ReturnInstance(ixuisprite2);
						}
						t.name = XSingleton<XCommon>.singleton.StringCombine("jade", xjadeItem.itemID.ToString());
					}
				}
			}
		}

		private void _OnBagJadeClicked(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this._doc.SelectedSlotItemList.Count;
			if (!flag)
			{
				XItem xitem = this._doc.SelectedSlotItemList[num];
				this.m_TargetJadeUID = xitem.uid;
				bool bBinding = xitem.bBinding;
				if (bBinding)
				{
					this._doc.ReqPutOnJade(this.m_TargetJadeUID);
					base.SetVisible(false);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("BINDING_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Equip));
				}
			}
		}

		private bool _Equip(IXUIButton btn)
		{
			this._doc.ReqPutOnJade(this.m_TargetJadeUID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			base.SetVisible(false);
			return true;
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		private XJadeDocument _doc = null;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;

		private IXUISprite m_Close;

		private IXUILabel m_Limit;

		private ulong m_TargetJadeUID = 0UL;
	}
}
