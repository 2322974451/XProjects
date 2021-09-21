using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200191D RID: 6429
	internal class JadeBagHandler : DlgHandlerBase
	{
		// Token: 0x17003AEF RID: 15087
		// (get) Token: 0x06010D18 RID: 68888 RVA: 0x0043B4E8 File Offset: 0x004396E8
		private XItemMorePowerfulTipMgr powerfullMgr
		{
			get
			{
				return DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.RedPointMgr;
			}
		}

		// Token: 0x17003AF0 RID: 15088
		// (get) Token: 0x06010D19 RID: 68889 RVA: 0x0043B504 File Offset: 0x00439704
		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeListPanel";
			}
		}

		// Token: 0x06010D1A RID: 68890 RVA: 0x0043B51C File Offset: 0x0043971C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			this.m_WrapContent = (base.PanelObject.transform.Find("BagPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.PanelObject.transform.Find("BagPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Close = (base.PanelObject.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			this.m_Limit = (base.PanelObject.transform.Find("Limit").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06010D1B RID: 68891 RVA: 0x0043B5E9 File Offset: 0x004397E9
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnBagWrapContentUpdated));
			this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
		}

		// Token: 0x06010D1C RID: 68892 RVA: 0x0043B623 File Offset: 0x00439823
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this._doc.NewItems.bCanClear = true;
		}

		// Token: 0x06010D1D RID: 68893 RVA: 0x0043B646 File Offset: 0x00439846
		protected override void OnHide()
		{
			this.powerfullMgr.ReturnAll();
			this._doc.NewItems.TryClear();
			base.OnHide();
		}

		// Token: 0x06010D1E RID: 68894 RVA: 0x0043B66D File Offset: 0x0043986D
		public override void OnUnload()
		{
			this.powerfullMgr.Unload();
			base.OnUnload();
		}

		// Token: 0x06010D1F RID: 68895 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x06010D20 RID: 68896 RVA: 0x0043B684 File Offset: 0x00439884
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

		// Token: 0x06010D21 RID: 68897 RVA: 0x0043B738 File Offset: 0x00439938
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

		// Token: 0x06010D22 RID: 68898 RVA: 0x0043B8A4 File Offset: 0x00439AA4
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

		// Token: 0x06010D23 RID: 68899 RVA: 0x0043B95C File Offset: 0x00439B5C
		private bool _Equip(IXUIButton btn)
		{
			this._doc.ReqPutOnJade(this.m_TargetJadeUID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06010D24 RID: 68900 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		// Token: 0x04007B6F RID: 31599
		private XJadeDocument _doc = null;

		// Token: 0x04007B70 RID: 31600
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04007B71 RID: 31601
		private IXUIScrollView m_ScrollView;

		// Token: 0x04007B72 RID: 31602
		private IXUISprite m_Close;

		// Token: 0x04007B73 RID: 31603
		private IXUILabel m_Limit;

		// Token: 0x04007B74 RID: 31604
		private ulong m_TargetJadeUID = 0UL;
	}
}
