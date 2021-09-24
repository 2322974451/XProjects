using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactSetHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_doc = XArtifactCreateDocument.Doc;
			this.m_purchaseDoc = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
			this.m_doc.Handler = this;
			this.m_curItemType2nd = null;
			this.InitItemType();
			this.InitItemList();
			this.m_levelCheck = (base.PanelObject.transform.FindChild("BtnHighPress").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_levelCheck.ForceSetFlag(!this.m_doc.OnlyShowCurFit);
			this.m_noLevelLimitString = XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_NO_LEVEL_LIMIT");
			this.m_elementRedpointDic = new Dictionary<uint, GameObject>();
			this.m_artifactSuitIDRedpointDic = new Dictionary<uint, GameObject>();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_levelCheck.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnLevelCheckClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillContent();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitItemList()
		{
			Transform transform = base.PanelObject.transform.Find("ItemList");
			this.m_itemListScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.Find("WrapContent");
			this.m_itemListWrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_itemListWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.RankWrapItemListUpdated));
		}

		private void InitItemType()
		{
			Transform transform = base.PanelObject.transform.Find("TypeList");
			this.m_itemTypeScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.Find("Table");
			this.m_itemTypeTable = (transform.GetComponent("XUITable") as IXUITable);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelOneTpl");
			this.m_itemType1stPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			transform = base.PanelObject.transform.Find("TypeList/Table/LevelTwoTpl");
			this.m_itemType2ndPool.SetupPool(transform.parent.gameObject, transform.gameObject, 16U, false);
		}

		private void FillContent()
		{
			this.FillItemType();
		}

		public void FillItemType()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.m_doc.ArtifactElementDataList == null;
				if (!flag2)
				{
					List<ArtifactElementData> list = new List<ArtifactElementData>();
					for (int i = 0; i < this.m_doc.ArtifactElementDataList.Count; i++)
					{
						bool show = this.m_doc.ArtifactElementDataList[i].Show;
						if (show)
						{
							list.Add(this.m_doc.ArtifactElementDataList[i]);
						}
					}
					this.m_elementRedpointDic.Clear();
					this.m_artifactSuitIDRedpointDic.Clear();
					this.m_itemType1stPool.ReturnAll(false);
					this.m_itemType2ndPool.ReturnAll(true);
					this.m_curItemType2nd = null;
					List<ArtifactSuitData> list2 = new List<ArtifactSuitData>();
					for (int j = 0; j < list.Count; j++)
					{
						GameObject gameObject = this.m_itemType1stPool.FetchGameObject(false);
						gameObject.name = j.ToString();
						this.m_elementRedpointDic[list[j].ElementType] = gameObject.transform.Find("RedPoint").gameObject;
						IXUISprite ixuisprite = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemType1st));
						IXUILabel ixuilabel = gameObject.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel2 = ixuilabel;
						XStringTable singleton = XSingleton<XStringTable>.singleton;
						XAttributeDefine elementType = (XAttributeDefine)list[j].ElementType;
						ixuilabel2.SetText(singleton.GetString(elementType.ToString()));
						IXUILabel ixuilabel3 = gameObject.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel;
						IXUILabel ixuilabel4 = ixuilabel3;
						XStringTable singleton2 = XSingleton<XStringTable>.singleton;
						elementType = (XAttributeDefine)list[j].ElementType;
						ixuilabel4.SetText(singleton2.GetString(elementType.ToString()));
						Transform transform = gameObject.transform.Find("ChildList");
						bool flag3 = transform.localScale.y == 0f;
						if (flag3)
						{
							ixuisprite.SetSprite("l_add_01");
							IXUITweenTool ixuitweenTool = ixuisprite.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
							ixuitweenTool.PlayTween(true, -1f);
						}
						list2.Clear();
						for (int k = 0; k < list[j].List.Count; k++)
						{
							bool show2 = list[j].List[k].Show;
							if (show2)
							{
								list2.Add(list[j].List[k]);
							}
						}
						for (int l = 0; l < list2.Count; l++)
						{
							GameObject gameObject2 = this.m_itemType2ndPool.FetchGameObject(false);
							gameObject2.name = list2[l].SuitData.SuitId.ToString();
							this.m_artifactSuitIDRedpointDic[list2[l].SuitData.SuitId] = gameObject2.transform.Find("RedPoint").gameObject;
							IXUICheckBox ixuicheckBox = gameObject2.GetComponent("XUICheckBox") as IXUICheckBox;
							ixuicheckBox.ID = (ulong)list2[l].SuitData.SuitId;
							ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickItemType2nd));
							gameObject2.transform.parent = transform;
							gameObject2.transform.localScale = Vector3.one;
							gameObject2.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuicheckBox.spriteHeight, 0f);
							IXUILabel ixuilabel5 = gameObject2.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel5.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("LEVEL"), list2[l].Level));
							IXUILabel ixuilabel6 = gameObject2.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel6.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("LEVEL"), list2[l].Level));
							ixuicheckBox.ForceSetFlag(false);
							bool flag4 = j == 0 && l == 0;
							if (flag4)
							{
								this.m_curItemType2nd = ixuicheckBox;
								ixuicheckBox.ForceSetFlag(true);
								this.RefreshItemList();
								ixuilabel5.gameObject.SetActive(true);
								ixuilabel6.gameObject.SetActive(false);
								ixuilabel.gameObject.SetActive(true);
								ixuilabel3.gameObject.SetActive(false);
							}
							else
							{
								ixuicheckBox.ForceSetFlag(false);
								ixuilabel5.gameObject.SetActive(false);
								ixuilabel6.gameObject.SetActive(true);
								bool flag5 = j != 0;
								if (flag5)
								{
									ixuilabel.gameObject.SetActive(false);
									ixuilabel3.gameObject.SetActive(true);
								}
							}
						}
					}
					this.m_itemTypeTable.RePositionNow();
					this.RefreshRedPoint();
				}
			}
		}

		public void RefreshRedPoint()
		{
			bool flag = !base.IsVisible() || 0 >= this.m_itemType1stPool.ActiveCount;
			if (!flag)
			{
				foreach (KeyValuePair<uint, GameObject> keyValuePair in this.m_elementRedpointDic)
				{
					keyValuePair.Value.SetActive(false);
				}
				foreach (KeyValuePair<uint, GameObject> keyValuePair2 in this.m_artifactSuitIDRedpointDic)
				{
					keyValuePair2.Value.SetActive(false);
				}
				GameObject gameObject = null;
				GameObject gameObject2 = null;
				List<ArtifactElementData> artifactElementDataList = this.m_doc.ArtifactElementDataList;
				for (int i = 0; i < artifactElementDataList.Count; i++)
				{
					bool flag2 = this.m_elementRedpointDic.TryGetValue(artifactElementDataList[i].ElementType, out gameObject);
					if (flag2)
					{
						gameObject.SetActive(artifactElementDataList[i].Redpoint);
					}
					for (int j = 0; j < artifactElementDataList[i].List.Count; j++)
					{
						bool flag3 = this.m_artifactSuitIDRedpointDic.TryGetValue(artifactElementDataList[i].List[j].SuitData.SuitId, out gameObject2);
						if (flag3)
						{
							gameObject2.SetActive(artifactElementDataList[i].List[j].Redpoint);
						}
					}
				}
			}
		}

		private void RankWrapItemListUpdated(Transform t, int index)
		{
			ArtifactSingleData artifactSuitData = this.GetArtifactSuitData(index);
			t.name = index.ToString();
			EquipSetItemView equipSetItemView = new EquipSetItemView();
			equipSetItemView.FindFrom(t);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)artifactSuitData.ItemData.ArtifactID);
			bool isBind = artifactSuitData.ItemComposeData.IsBind;
			bool flag = !itemConf.CanTrade;
			if (flag)
			{
				isBind = true;
			}
			EquipSetItemBaseView.stEquipInfoParam param;
			param.isShowTooltip = true;
			param.playerProf = 0;
			equipSetItemView.SetItemInfo((int)artifactSuitData.ItemData.ArtifactID, param, isBind);
			equipSetItemView.lbLevel.SetText(this.GetLevelString(artifactSuitData.ItemComposeData.Level));
			bool flag2 = true;
			int num = -1;
			bool flag3 = artifactSuitData.ItemComposeData.SrcItem1[0] <= 0;
			if (flag3)
			{
				equipSetItemView.goItem1.SetActive(false);
			}
			else
			{
				bool flag4 = this.RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem1, equipSetItemView.lbItemCount1, artifactSuitData.ItemComposeData.SrcItem1[0], artifactSuitData.ItemComposeData.SrcItem1[1]);
				flag2 = (flag2 && flag4);
				bool flag5 = !flag4;
				if (flag5)
				{
					num = artifactSuitData.ItemComposeData.SrcItem1[0];
				}
			}
			bool flag6 = artifactSuitData.ItemComposeData.SrcItem2[1] <= 0;
			if (flag6)
			{
				equipSetItemView.goItem2.SetActive(false);
			}
			else
			{
				bool flag4 = this.RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem2, equipSetItemView.lbItemCount2, artifactSuitData.ItemComposeData.SrcItem2[0], artifactSuitData.ItemComposeData.SrcItem2[1]);
				flag2 = (flag2 && flag4);
				bool flag7 = !flag4;
				if (flag7)
				{
					num = artifactSuitData.ItemComposeData.SrcItem2[0];
				}
			}
			bool flag8 = artifactSuitData.ItemComposeData.SrcItem3[1] <= 0;
			if (flag8)
			{
				equipSetItemView.goItem3.SetActive(false);
			}
			else
			{
				bool flag4 = this.RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem3, equipSetItemView.lbItemCount3, artifactSuitData.ItemComposeData.SrcItem3[0], artifactSuitData.ItemComposeData.SrcItem3[1]);
				flag2 = (flag2 && flag4);
				bool flag9 = !flag4;
				if (flag9)
				{
					num = artifactSuitData.ItemComposeData.SrcItem3[0];
				}
			}
			bool flag10 = 0 >= artifactSuitData.ItemComposeData.SrcItem4[1];
			if (flag10)
			{
				equipSetItemView.goItem4.SetActive(false);
			}
			else
			{
				bool flag4 = this.RankWrapItemListUpdatedNeedItem(equipSetItemView.goItem4, equipSetItemView.lbItemCount4, artifactSuitData.ItemComposeData.SrcItem4[0], artifactSuitData.ItemComposeData.SrcItem4[1]);
				flag2 = (flag2 && flag4);
				bool flag11 = !flag4;
				if (flag11)
				{
					num = artifactSuitData.ItemComposeData.SrcItem4[0];
				}
			}
			bool flag12 = artifactSuitData.ItemComposeData.Coin > 0;
			if (flag12)
			{
				equipSetItemView.lbCost.SetText(artifactSuitData.ItemComposeData.Coin.ToString());
			}
			else
			{
				equipSetItemView.lbCost.SetText("0");
			}
			bool flag13 = flag2;
			if (flag13)
			{
				equipSetItemView.btnCreate.SetEnable(true, false);
				equipSetItemView.btnCreate.ID = (ulong)((long)artifactSuitData.ItemComposeData.ID);
				equipSetItemView.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickItemCreateButton));
			}
			else
			{
				equipSetItemView.btnCreate.SetEnable(true, false);
				equipSetItemView.btnCreate.ID = (ulong)((long)num);
				equipSetItemView.btnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGetNeedItemButton));
			}
			equipSetItemView.goRedpoint.SetActive(artifactSuitData.Redpoint);
		}

		private bool RankWrapItemListUpdatedNeedItem(GameObject goItem, IXUILabel lbCount, int needID, int needCount)
		{
			goItem.SetActive(true);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(needID);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(goItem, needID, 0, false);
			IXUISprite ixuisprite = goItem.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)needID);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNeedItemClick));
			bool flag = itemCount >= (ulong)((long)needCount);
			bool result;
			if (flag)
			{
				lbCount.SetText(string.Format("[{0}]{1}/{2}[-]", XStringDefineProxy.GetString("ZongColor"), itemCount, needCount));
				result = true;
			}
			else
			{
				lbCount.SetText(string.Format("[{0}]{1}[-][{2}]/{3}[-]", new object[]
				{
					XStringDefineProxy.GetString("NotEnoughColor"),
					itemCount,
					XStringDefineProxy.GetString("ZongColor"),
					needCount
				}));
				result = false;
			}
			return result;
		}

		public void RefreshItemList(List<ArtifactSingleData> uiList)
		{
			bool flag = !base.IsVisible() || uiList == null;
			if (!flag)
			{
				this.m_suitDataList = uiList;
				this.m_itemListWrapContent.SetContentCount(uiList.Count, false);
				this.m_itemListScrollView.ResetPosition();
			}
		}

		public void RefreshItemList()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.m_curItemType2nd != null;
				if (flag2)
				{
					this.OnClickItemType2nd(this.m_curItemType2nd);
				}
			}
		}

		private ArtifactSingleData GetArtifactSuitData(int index)
		{
			bool flag = this.m_suitDataList == null || index >= this.m_suitDataList.Count;
			ArtifactSingleData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.m_suitDataList[index];
			}
			return result;
		}

		private string GetLevelString(int _level)
		{
			bool flag = _level > 0;
			string result;
			if (flag)
			{
				result = _level.ToString();
			}
			else
			{
				result = this.m_noLevelLimitString;
			}
			return result;
		}

		private void SetSelectStatus(bool isSelected)
		{
			this.m_curItemType2nd.gameObject.transform.FindChild("UnSelectLab").gameObject.SetActive(!isSelected);
			this.m_curItemType2nd.gameObject.transform.FindChild("SelectLab").gameObject.SetActive(isSelected);
			Transform parent = this.m_curItemType2nd.gameObject.transform.parent.parent;
			parent.FindChild("UnSelectLab").gameObject.SetActive(!isSelected);
			parent.FindChild("SelectLab").gameObject.SetActive(isSelected);
		}

		private void OnClickItemType1st(IXUISprite sp)
		{
			bool flag = sp.spriteName == "l_add_00";
			if (flag)
			{
				sp.SetSprite("l_add_01");
			}
			else
			{
				sp.SetSprite("l_add_00");
			}
		}

		private bool OnClickItemType2nd(IXUICheckBox cb)
		{
			bool flag = !cb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_curItemType2nd != null;
				if (flag2)
				{
					this.SetSelectStatus(false);
				}
				this.m_curItemType2nd = cb;
				this.SetSelectStatus(true);
				List<ArtifactSingleData> equipSuitList = this.m_doc.GetEquipSuitList((uint)cb.ID);
				this.RefreshItemList(equipSuitList);
				result = true;
			}
			return result;
		}

		private bool OnClickItemCreateButton(IXUIButton btn)
		{
			int num = (int)btn.ID;
			ItemComposeTable.RowData itemConposeDataByID = XEquipCreateDocument.GetItemConposeDataByID(num);
			bool flag = itemConposeDataByID != null;
			if (flag)
			{
				XEquipCreateDocument.Doc.CurUid = 0UL;
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				int vipLevel = (int)specificDocument.VipLevel;
				bool flag2 = (long)itemConposeDataByID.Coin <= (long)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
				if (flag2)
				{
					VIPTable.RowData byVIP = specificDocument.VIPReader.GetByVIP(vipLevel);
					ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
					List<XItem> list = new List<XItem>();
					XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref list);
					bool flag3 = (long)list.Count >= (long)((ulong)byVIP.ArtifactMax);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactmBagFull"), "fece00");
						return true;
					}
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetVisible(true);
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateConfirmHandler.SetEquipInfo(num);
				}
				else
				{
					XPurchaseDocument specificDocument2 = XDocuments.GetSpecificDocument<XPurchaseDocument>(XPurchaseDocument.uuID);
					XPurchaseInfo purchaseInfo = specificDocument2.GetPurchaseInfo(level, vipLevel, ItemEnum.GOLD);
					bool flag4 = purchaseInfo.totalBuyNum > purchaseInfo.curBuyNum;
					if (flag4)
					{
						DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SpriteLotteryGoldNotEnough"), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EQUIPCREATE_COIN_CANNOT_EXCHANGE"), "fece00");
					}
				}
			}
			return true;
		}

		private bool OnClickGetNeedItemButton(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
			return true;
		}

		private void OnNeedItemClick(IXUISprite item)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)item.ID, null);
		}

		private bool OnLevelCheckClicked(IXUICheckBox box)
		{
			this.m_doc.OnlyShowCurFit = !this.m_doc.OnlyShowCurFit;
			this.FillItemType();
			return true;
		}

		private XArtifactCreateDocument m_doc;

		private XPurchaseDocument m_purchaseDoc;

		private IXUIWrapContent m_itemListWrapContent;

		private IXUIScrollView m_itemListScrollView;

		private IXUICheckBox m_curItemType2nd;

		private IXUITable m_itemTypeTable;

		private IXUIScrollView m_itemTypeScrollView;

		private IXUICheckBox m_levelCheck;

		private XUIPool m_itemType1stPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_itemType2ndPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<uint, GameObject> m_elementRedpointDic;

		private Dictionary<uint, GameObject> m_artifactSuitIDRedpointDic;

		private List<ArtifactSingleData> m_suitDataList = new List<ArtifactSingleData>();

		private string m_noLevelLimitString;
	}
}
