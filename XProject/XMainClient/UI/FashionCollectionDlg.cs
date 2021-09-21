using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001825 RID: 6181
	internal class FashionCollectionDlg : DlgBase<FashionCollectionDlg, FashionCollectionDlgBehaviour>
	{
		// Token: 0x1700391D RID: 14621
		// (get) Token: 0x060100C1 RID: 65729 RVA: 0x003D3108 File Offset: 0x003D1308
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700391E RID: 14622
		// (get) Token: 0x060100C2 RID: 65730 RVA: 0x003D311C File Offset: 0x003D131C
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionColletionDlg";
			}
		}

		// Token: 0x1700391F RID: 14623
		// (get) Token: 0x060100C3 RID: 65731 RVA: 0x003D3134 File Offset: 0x003D1334
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003920 RID: 14624
		// (get) Token: 0x060100C4 RID: 65732 RVA: 0x003D3148 File Offset: 0x003D1348
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003921 RID: 14625
		// (get) Token: 0x060100C5 RID: 65733 RVA: 0x003D315C File Offset: 0x003D135C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060100C6 RID: 65734 RVA: 0x003D3170 File Offset: 0x003D1370
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XFashionDocument.uuID) as XFashionDocument);
			DlgHandlerBase.EnsureCreate<XCharacterInfoView>(ref this._InfoView, base.uiBehaviour.m_CharacterInfoFrame, null, true);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x060100C7 RID: 65735 RVA: 0x003D31DC File Offset: 0x003D13DC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClick));
		}

		// Token: 0x060100C8 RID: 65736 RVA: 0x003D322C File Offset: 0x003D142C
		protected bool OnCloseClick(IXUIButton button)
		{
			XSingleton<X3DAvatarMgr>.singleton.OnFashionChanged(XSingleton<XEntityMgr>.singleton.Player);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x060100C9 RID: 65737 RVA: 0x003D326A File Offset: 0x003D146A
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x060100CA RID: 65738 RVA: 0x003D327B File Offset: 0x003D147B
		public override void StackRefresh()
		{
			this._InfoView.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x060100CB RID: 65739 RVA: 0x003D3294 File Offset: 0x003D1494
		private void RefreshData()
		{
			bool flag = this.m_uiBehaviour.m_SnapShot != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_uiBehaviour.m_SnapShot);
			}
			this.ShowSuitList();
		}

		// Token: 0x060100CC RID: 65740 RVA: 0x003D32D2 File Offset: 0x003D14D2
		protected override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_uiBehaviour.m_SnapShot);
			this._selectedSuit = 0;
			this.allSuit.Clear();
			DlgHandlerBase.EnsureUnload<XCharacterInfoView>(ref this._InfoView);
		}

		// Token: 0x060100CD RID: 65741 RVA: 0x003D330C File Offset: 0x003D150C
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < this.allSuit.Count && index >= 0;
			if (flag)
			{
				FashionSuitTable.RowData suitData = this._doc.GetSuitData(this.allSuit[index]);
				IXUILabel ixuilabel = t.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(suitData.SuitName);
				IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				string strAtlas = "";
				string strSprite = "";
				this._doc.GetSuitIcon(suitData, ref strAtlas, ref strSprite);
				ixuisprite.SetSprite(strSprite, strAtlas, false);
				IXUISprite ixuisprite2 = t.FindChild("Quality").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(XSingleton<UiUtility>.singleton.GetItemQualityFrame(suitData.SuitQuality, 1));
				IXUILabel ixuilabel2 = t.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = t.FindChild("GetAll").gameObject;
				GameObject gameObject2 = t.FindChild("NoSale").gameObject;
				int suitCollectCount = this._doc.GetSuitCollectCount(this.allSuit[index]);
				int suitTotalCount = this._doc.GetSuitTotalCount(this.allSuit[index]);
				bool flag2 = suitCollectCount == suitTotalCount;
				if (flag2)
				{
					ixuilabel2.gameObject.SetActive(false);
					gameObject.SetActive(true);
				}
				else
				{
					ixuilabel2.gameObject.SetActive(true);
					gameObject.SetActive(false);
					ixuilabel2.SetText(suitCollectCount + "/" + suitTotalCount);
				}
				gameObject2.SetActive(this._doc.IsSuitNoSale(this.allSuit[index]));
				IXUICheckBox ixuicheckBox = t.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)this.allSuit[index]);
				bool flag3 = this._selectedSuit == this.allSuit[index];
				if (flag3)
				{
					ixuicheckBox.bChecked = true;
				}
				else
				{
					ixuicheckBox.ForceSetFlag(false);
				}
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSuitClick));
				bool flag4 = this._selectedSuit == 0 && index == 0;
				if (flag4)
				{
					ixuicheckBox.bChecked = true;
				}
			}
		}

		// Token: 0x060100CE RID: 65742 RVA: 0x003D3570 File Offset: 0x003D1770
		protected void ShowSuitList()
		{
			bool flag = this.allSuit.Count == 0;
			if (flag)
			{
				this.allSuit = this._doc.GetSuitCollectionList();
				base.uiBehaviour.m_WrapContent.SetContentCount(this.allSuit.Count, false);
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
			base.uiBehaviour.m_TotalCollection.SetText(this._doc.GetFullCollectionSuitCount() + "/" + this.allSuit.Count);
		}

		// Token: 0x060100CF RID: 65743 RVA: 0x003D360C File Offset: 0x003D180C
		protected bool OnSuitClick(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._selectedSuit = (int)box.ID;
				FashionSuitTable.RowData suitData = this._doc.GetSuitData(this._selectedSuit);
				this.EquipSuit(suitData);
				this.SetSuitInfo(suitData);
				result = true;
			}
			return result;
		}

		// Token: 0x060100D0 RID: 65744 RVA: 0x003D365F File Offset: 0x003D185F
		protected void EquipSuit(FashionSuitTable.RowData suitData)
		{
			XSingleton<X3DAvatarMgr>.singleton.OnFashionSuitChanged(XSingleton<XEntityMgr>.singleton.Player, suitData);
		}

		// Token: 0x060100D1 RID: 65745 RVA: 0x003D3678 File Offset: 0x003D1878
		protected void SetSuitInfo(FashionSuitTable.RowData suitData)
		{
			base.uiBehaviour.m_SuitName.SetText(suitData.SuitName);
			base.uiBehaviour.FashionPool.ReturnAll(false);
			bool flag = suitData.FashionID != null;
			if (flag)
			{
				for (int i = 0; i < suitData.FashionID.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.FashionPool.FetchGameObject(false);
					gameObject.transform.localPosition = base.uiBehaviour.ShowPos[i];
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					XSingleton<XItemDrawerMgr>.singleton.fashionDrawer.DrawItem(gameObject.gameObject, (int)suitData.FashionID[i]);
					ixuisprite.SetGrey(this._doc.HasCollected(suitData.FashionID[i]));
					ixuisprite.ID = (ulong)suitData.FashionID[i];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClicked));
				}
			}
			base.uiBehaviour.AttrPool.ReturnAll(false);
			int num = 0;
			for (int j = 2; j <= 7; j++)
			{
				SeqListRef<uint> suitPartCountEffect = this._doc.GetSuitPartCountEffect(suitData.SuitID, j);
				bool flag2 = suitPartCountEffect.Count == 0;
				if (!flag2)
				{
					for (int k = 0; k < suitPartCountEffect.Count; k++)
					{
						bool flag3 = suitPartCountEffect[k, 0] == 0U;
						if (!flag3)
						{
							GameObject gameObject2 = base.uiBehaviour.AttrPool.FetchGameObject(false);
							gameObject2.transform.localPosition = base.uiBehaviour.AttrPool.TplPos + new Vector3(0f, (float)(-(float)num * base.uiBehaviour.AttrPool.TplHeight));
							IXUILabel ixuilabel = gameObject2.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
							IXUILabel ixuilabel2 = gameObject2.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(XStringDefineProxy.GetString("EQUIP_SUIT_EFFECT", new object[]
							{
								j
							}));
							ixuilabel2.SetText(XStringDefineProxy.GetString((XAttributeDefine)suitPartCountEffect[k, 0]) + XAttributeCommon.GetAttrValueStr((int)suitPartCountEffect[k, 0], (float)suitPartCountEffect[k, 1]));
							num++;
						}
					}
				}
			}
		}

		// Token: 0x060100D2 RID: 65746 RVA: 0x003D3920 File Offset: 0x003D1B20
		private void _OnItemClicked(IXUISprite sp)
		{
			int itemID = (int)sp.ID;
			XItem mainItem = XBagDocument.MakeXItem(itemID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(mainItem, null, sp, false, 0U);
		}

		// Token: 0x060100D3 RID: 65747 RVA: 0x003D3950 File Offset: 0x003D1B50
		private bool OnShopClick(IXUIButton go)
		{
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.FASHION, 0UL);
			return true;
		}

		// Token: 0x04007251 RID: 29265
		public XCharacterInfoView _InfoView;

		// Token: 0x04007252 RID: 29266
		private XFashionDocument _doc;

		// Token: 0x04007253 RID: 29267
		private int _selectedSuit = 0;

		// Token: 0x04007254 RID: 29268
		private List<int> allSuit = new List<int>();
	}
}
