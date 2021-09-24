using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionCollectionDlg : DlgBase<FashionCollectionDlg, FashionCollectionDlgBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionColletionDlg";
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XFashionDocument.uuID) as XFashionDocument);
			DlgHandlerBase.EnsureCreate<XCharacterInfoView>(ref this._InfoView, base.uiBehaviour.m_CharacterInfoFrame, null, true);
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClick));
		}

		protected bool OnCloseClick(IXUIButton button)
		{
			XSingleton<X3DAvatarMgr>.singleton.OnFashionChanged(XSingleton<XEntityMgr>.singleton.Player);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			this.SetVisible(false, true);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void StackRefresh()
		{
			this._InfoView.StackRefresh();
			this.RefreshData();
		}

		private void RefreshData()
		{
			bool flag = this.m_uiBehaviour.m_SnapShot != null;
			if (flag)
			{
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_uiBehaviour.m_SnapShot);
			}
			this.ShowSuitList();
		}

		protected override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_uiBehaviour.m_SnapShot);
			this._selectedSuit = 0;
			this.allSuit.Clear();
			DlgHandlerBase.EnsureUnload<XCharacterInfoView>(ref this._InfoView);
		}

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

		protected void EquipSuit(FashionSuitTable.RowData suitData)
		{
			XSingleton<X3DAvatarMgr>.singleton.OnFashionSuitChanged(XSingleton<XEntityMgr>.singleton.Player, suitData);
		}

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

		private void _OnItemClicked(IXUISprite sp)
		{
			int itemID = (int)sp.ID;
			XItem mainItem = XBagDocument.MakeXItem(itemID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(mainItem, null, sp, false, 0U);
		}

		private bool OnShopClick(IXUIButton go)
		{
			DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.FASHION, 0UL);
			return true;
		}

		public XCharacterInfoView _InfoView;

		private XFashionDocument _doc;

		private int _selectedSuit = 0;

		private List<int> allSuit = new List<int>();
	}
}
