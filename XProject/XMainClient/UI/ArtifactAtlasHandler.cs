using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactAtlasHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactAtlasDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactAtlasDocument.Doc;
			this.m_closedBtn = (base.PanelObject.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.InitTypeList();
			this.InitSuit();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowItemType();
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_itemType1stPool != null;
			if (flag)
			{
				this.m_itemType1stPool.ReturnAll(false);
			}
			bool flag2 = this.m_itemType2ndPool != null;
			if (flag2)
			{
				this.m_itemType2ndPool.ReturnAll(false);
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void InitTypeList()
		{
			Transform transform = base.PanelObject.transform.Find("Bg/TypeList");
			this.m_itemTypeScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = transform.Find("Table");
			this.m_itemTypeTable = (transform.GetComponent("XUITable") as IXUITable);
			transform = base.PanelObject.transform.Find("Bg/TypeList/Table/LevelOneTpl");
			this.m_itemType1stPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			transform = base.PanelObject.transform.Find("Bg/TypeList/Table/LevelTwoTpl");
			this.m_itemType2ndPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
		}

		private void InitSuit()
		{
			Transform transform = base.PanelObject.transform.Find("Bg/Bg/p");
			this.m_suitItemsGo = new GameObject[this.m_itemCount];
			Transform transform2;
			for (int i = 0; i < this.m_itemCount; i++)
			{
				transform2 = transform.FindChild("item" + i.ToString());
				bool flag = transform2 == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("item" + i.ToString() + "is null", null, null, null, null, null);
				}
				else
				{
					this.m_suitItemsGo[i] = transform2.gameObject;
					IXUISprite ixuisprite = transform2.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectItem));
				}
			}
			transform = base.PanelObject.transform.Find("Bg/Bg/EffectFrame");
			this.m_effectTittleLab = (transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_effectDesLab = (transform.Find("Panel/Text").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.Find("Bg/Bg/SuitFrame");
			this.m_suitNameLab = (transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_suitPanelTra = transform.FindChild("Panel");
			transform2 = transform.Find("Attr");
			this.m_suitAttrPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, true);
			this.m_suitNameLab = (base.PanelObject.transform.Find("Bg/Bg/SuitName").GetComponent("XUILabel") as IXUILabel);
		}

		private void ShowItemType()
		{
			List<ArtifactSuitLevel> levelSuitList = this.m_doc.GetLevelSuitList();
			this.m_itemType1stPool.ReturnAll(true);
			this.m_itemType2ndPool.ReturnAll(true);
			for (int i = 0; i < levelSuitList.Count; i++)
			{
				ArtifactSuitLevel artifactSuitLevel = levelSuitList[i];
				bool flag = artifactSuitLevel == null;
				if (!flag)
				{
					GameObject gameObject = this.m_itemType1stPool.FetchGameObject(false);
					gameObject.name = artifactSuitLevel.SuitLevel.ToString();
					IXUISprite ixuisprite = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemType1st));
					Transform transform = gameObject.transform.Find("ChildList");
					bool flag2 = (artifactSuitLevel.IsDefultSelect && transform.localScale.y == 0f) || (!artifactSuitLevel.IsDefultSelect && transform.localScale.y != 0f);
					if (flag2)
					{
						ixuisprite.SetSprite("l_add_01");
						IXUITweenTool ixuitweenTool = ixuisprite.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool;
						ixuitweenTool.PlayTween(true, -1f);
					}
					IXUILabel ixuilabel = gameObject.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactLevel"), artifactSuitLevel.SuitLevel));
					ixuilabel.gameObject.SetActive(artifactSuitLevel.IsDefultSelect);
					ixuilabel = (gameObject.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactLevel"), artifactSuitLevel.SuitLevel));
					ixuilabel.gameObject.SetActive(!artifactSuitLevel.IsDefultSelect);
					int num = 0;
					foreach (uint num2 in artifactSuitLevel.SuitIdList)
					{
						ArtifactSuit suitBySuitId = ArtifactDocument.SuitMgr.GetSuitBySuitId(num2);
						bool flag3 = suitBySuitId == null || suitBySuitId.EffectsNum == 0;
						if (!flag3)
						{
							GameObject gameObject2 = this.m_itemType2ndPool.FetchGameObject(false);
							gameObject2.name = num2.ToString();
							IXUICheckBox ixuicheckBox = gameObject2.GetComponent("XUICheckBox") as IXUICheckBox;
							ixuicheckBox.ID = (ulong)num2;
							ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickItemType2nd));
							gameObject2.transform.parent = transform;
							gameObject2.transform.localScale = Vector3.one;
							gameObject2.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuicheckBox.spriteHeight, 0f);
							IXUILabel ixuilabel2 = gameObject2.transform.Find("SelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel2.SetText(suitBySuitId.Name);
							IXUILabel ixuilabel3 = gameObject2.transform.Find("UnSelectLab").GetComponent("XUILabel") as IXUILabel;
							ixuilabel3.SetText(suitBySuitId.Name);
							bool flag4 = num == artifactSuitLevel.DefultNum && artifactSuitLevel.IsDefultSelect;
							if (flag4)
							{
								this.m_curItemType2nd = ixuicheckBox;
								ixuicheckBox.ForceSetFlag(true);
								this.RefreshItemList();
								ixuilabel2.gameObject.SetActive(true);
								ixuilabel3.gameObject.SetActive(false);
								Transform parent = ixuicheckBox.gameObject.transform.parent.parent;
								parent.FindChild("UnSelectLab").gameObject.SetActive(false);
								parent.FindChild("SelectLab").gameObject.SetActive(true);
								IXUISprite ixuisprite2 = parent.GetComponent("XUISprite") as IXUISprite;
								ixuisprite2.SetSprite("l_button_06");
							}
							else
							{
								ixuicheckBox.ForceSetFlag(false);
								ixuilabel2.gameObject.SetActive(false);
								ixuilabel3.gameObject.SetActive(true);
							}
							num++;
						}
					}
				}
			}
			this.m_itemTypeTable.RePositionNow();
			this.m_itemTypeTable.Reposition();
		}

		private void FillSuitContent(uint suitId)
		{
			ArtifactSuit suitBySuitId = ArtifactDocument.SuitMgr.GetSuitBySuitId(suitId);
			bool flag = suitBySuitId == null;
			if (!flag)
			{
				this.m_suitNameLab.SetText(suitBySuitId.Name);
				int num = 0;
				foreach (uint num2 in suitBySuitId.Artifacts)
				{
					bool flag2 = num >= suitBySuitId.Artifacts.Count;
					if (flag2)
					{
						break;
					}
					GameObject gameObject = this.m_suitItemsGo[num];
					bool flag3 = gameObject == null;
					if (!flag3)
					{
						gameObject.SetActive(true);
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)num2);
						bool flag4 = itemConf == null;
						if (flag4)
						{
							return;
						}
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, itemConf.ItemID, 0, false);
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)num2;
						bool flag5 = num == 0;
						if (flag5)
						{
							this.OnSelectItem(ixuisprite);
						}
						num++;
					}
				}
				for (int i = 0; i < this.m_itemCount; i++)
				{
					bool flag6 = i >= suitBySuitId.Artifacts.Count;
					if (flag6)
					{
						GameObject gameObject = this.m_suitItemsGo[i];
						bool flag7 = gameObject != null;
						if (flag7)
						{
							gameObject.SetActive(false);
						}
					}
				}
				this.FillSuitDes(suitId);
			}
		}

		private void FillEffectDes(uint artifactId)
		{
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData(artifactId);
			bool flag = artifactListRowData == null;
			if (!flag)
			{
				this.m_effectTittleLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactSkillEffect"), artifactListRowData.EffectNum));
				this.m_effectDesLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(artifactListRowData.EffectDes));
			}
		}

		private void FillSuitDes(uint suitId)
		{
			this.m_suitAttrPool.ReturnAll(true);
			ArtifactSuit suitBySuitId = ArtifactDocument.SuitMgr.GetSuitBySuitId(suitId);
			bool flag = suitBySuitId == null;
			if (!flag)
			{
				int num = 0;
				for (int i = 0; i < suitBySuitId.effects.Length; i++)
				{
					SeqListRef<uint> seqListRef = suitBySuitId.effects[i];
					bool flag2 = seqListRef.Count == 0;
					if (!flag2)
					{
						for (int j = 0; j < seqListRef.Count; j++)
						{
							bool flag3 = seqListRef[j, 0] == 0U;
							if (!flag3)
							{
								GameObject gameObject = this.m_suitAttrPool.FetchGameObject(false);
								gameObject.transform.parent = this.m_suitPanelTra;
								gameObject.transform.localScale = Vector3.one;
								gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_suitAttrPool.TplHeight * num), 0f);
								IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.SetText(string.Format("[FFFFFF]{0}[-]", XStringDefineProxy.GetString("EQUIP_SUIT_EFFECT", new object[]
								{
									i
								})));
								ixuilabel = (gameObject.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
								string text = string.Format("{0}{1}", XStringDefineProxy.GetString((XAttributeDefine)seqListRef[j, 0]), XAttributeCommon.GetAttrValueStr((int)seqListRef[j, 0], (float)seqListRef[j, 1]));
								ixuilabel.SetText(text);
								num++;
							}
						}
					}
				}
			}
		}

		private void RefreshItemList()
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

		private void OnClickItemType1st(IXUISprite spr)
		{
			bool flag = spr.spriteName == "l_add_00";
			if (flag)
			{
				spr.SetSprite("l_add_01");
			}
			else
			{
				spr.SetSprite("l_add_00");
			}
		}

		private void OnSelectItem(IXUISprite spr)
		{
			uint num = (uint)spr.ID;
			bool flag = this.m_selectArtifactId == num;
			if (!flag)
			{
				this.m_selectArtifactId = num;
				this.FillEffectDes(num);
			}
		}

		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
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
				this.FillSuitContent((uint)cb.ID);
				result = true;
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
			IXUISprite ixuisprite = parent.GetComponent("XUISprite") as IXUISprite;
			if (isSelected)
			{
				ixuisprite.SetSprite("l_button_06");
			}
			else
			{
				ixuisprite.SetSprite("l_button_07");
			}
		}

		private readonly int m_itemCount = 4;

		private uint m_selectArtifactId = 0U;

		private IXUIButton m_closedBtn;

		private ArtifactAtlasDocument m_doc;

		private IXUITable m_itemTypeTable;

		private IXUICheckBox m_curItemType2nd;

		private IXUIScrollView m_itemTypeScrollView;

		private XUIPool m_itemType1stPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_itemType2ndPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel m_suitNameLab;

		private IXUILabel m_effectTittleLab;

		private IXUILabel m_effectDesLab;

		private GameObject[] m_suitItemsGo;

		private Transform m_suitPanelTra;

		private XUIPool m_suitAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
