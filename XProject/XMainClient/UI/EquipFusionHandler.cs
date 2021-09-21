using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016E0 RID: 5856
	internal class EquipFusionHandler : DlgHandlerBase
	{
		// Token: 0x17003752 RID: 14162
		// (get) Token: 0x0600F194 RID: 61844 RVA: 0x00355FE0 File Offset: 0x003541E0
		public string FxPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_fxPath);
				if (flag)
				{
					this.m_fxPath = XSingleton<XGlobalConfig>.singleton.GetValue("EquipfuseEffectPath");
				}
				return this.m_fxPath;
			}
		}

		// Token: 0x17003753 RID: 14163
		// (get) Token: 0x0600F195 RID: 61845 RVA: 0x0035601C File Offset: 0x0035421C
		protected override string FileName
		{
			get
			{
				return "ItemNew/EquipFusionFrame";
			}
		}

		// Token: 0x0600F196 RID: 61846 RVA: 0x00356034 File Offset: 0x00354234
		protected override void Init()
		{
			base.Init();
			this.m_doc = EquipFusionDocument.Doc;
			this.m_doc.Handler = this;
			this.m_closedBtn = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (base.PanelObject.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.Find("Top");
			this.m_equipItemGo = transform.Find("FuseItem").gameObject;
			this.m_symbolLab = (transform.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_breakLevelLab = (transform.Find("RzLabel").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.Find("Process");
			this.m_contentGo = transform.Find("Panel/Content").gameObject;
			this.m_contentLab = (this.m_contentGo.transform.GetComponent("XUILabel") as IXUILabel);
			this.m_contentGo.SetActive(false);
			this.m_processValueLab = (transform.Find("ProcessValue").GetComponent("XUILabel") as IXUILabel);
			this.m_process = (transform.Find("Slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_fuseHelpBtn = (transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_previewValueLab = (transform.Find("PreviewValue").GetComponent("XUILabel") as IXUILabel);
			this.m_previewSpr = (transform.Find("Slider/preview").GetComponent("XUISprite") as IXUISprite);
			transform = base.PanelObject.transform.Find("ResultPanel");
			this.m_tplPool.SetupPool(transform.gameObject, transform.Find("Tpl").gameObject, 2U, false);
			transform = base.PanelObject.transform.Find("Bottom");
			this.m_itemGo = transform.Find("Item").gameObject;
			this.m_addSpr = (transform.Find("BoxAdd").GetComponent("XUISprite") as IXUISprite);
			this.m_fuseBtn = (transform.Find("FuseBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_tipsLab = (transform.Find("BoxAdd/T").GetComponent("XUILabel") as IXUILabel);
			this.m_itemsGoList = new List<GameObject>();
			transform = transform.Find("Items");
			for (int i = 0; i < transform.childCount; i++)
			{
				this.m_itemsGoList.Add(transform.GetChild(i).gameObject);
			}
		}

		// Token: 0x0600F197 RID: 61847 RVA: 0x00356328 File Offset: 0x00354528
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClosed));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelp));
			this.m_fuseHelpBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnFuseHelpPress));
			this.m_fuseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFuse));
			this.m_addSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectItem));
		}

		// Token: 0x0600F198 RID: 61848 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F199 RID: 61849 RVA: 0x003563B8 File Offset: 0x003545B8
		protected override void OnHide()
		{
			base.OnHide();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
			this.DeActiveEffect();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(0UL);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			}
			bool flag2 = this.m_selectHandler != null;
			if (flag2)
			{
				this.m_selectHandler.SetVisible(false);
			}
		}

		// Token: 0x0600F19A RID: 61850 RVA: 0x0035643C File Offset: 0x0035463C
		public override void OnUnload()
		{
			base.OnUnload();
			DlgHandlerBase.EnsureUnload<EquipFusionSelectHandler>(ref this.m_selectHandler);
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			bool flag2 = this.m_fuseBreakFx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fuseBreakFx, true);
				this.m_fuseBreakFx = null;
			}
		}

		// Token: 0x0600F19B RID: 61851 RVA: 0x003564B0 File Offset: 0x003546B0
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
			}
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.GetItemByUID(this.m_doc.SelectUid);
			bool flag2 = itemByUID == null;
			if (flag2)
			{
				this.m_doc.SelectEquip(0UL);
			}
			else
			{
				this.m_doc.SelectEquip(this.m_doc.SelectUid);
			}
			this.FillContent();
		}

		// Token: 0x0600F19C RID: 61852 RVA: 0x0035654D File Offset: 0x0035474D
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
		}

		// Token: 0x0600F19D RID: 61853 RVA: 0x00356560 File Offset: 0x00354760
		public void ShowUI(bool playEffect = false)
		{
			if (playEffect)
			{
				this.PlayBreakEffect();
			}
			this.FillContent();
		}

		// Token: 0x0600F19E RID: 61854 RVA: 0x00356584 File Offset: 0x00354784
		private void PlayBreakEffect()
		{
			bool flag = this.m_fx == null;
			if (flag)
			{
				this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.FxPath, null, true);
			}
			else
			{
				this.m_fx.SetActive(true);
			}
			this.m_fx.Play(base.PanelObject.transform.Find("Effect"), Vector3.zero, Vector3.one, 1f, true, false);
		}

		// Token: 0x0600F19F RID: 61855 RVA: 0x003565FC File Offset: 0x003547FC
		private void FillContent()
		{
			this.m_contentGo.SetActive(false);
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null || itemByUID.Type != ItemType.EQUIP;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_equipItemGo, itemByUID);
					IXUISprite ixuisprite = this.m_equipItemGo.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = itemByUID.uid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
					this.SetEffect(this.m_equipItemGo, (itemByUID as XEquipItem).fuseInfo.BreakNum);
					XEquipItem xequipItem = itemByUID as XEquipItem;
					bool flag3 = equipConf.FuseCanBreakNum > 0;
					if (flag3)
					{
						this.m_breakLevelLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("FuseBreakNum"), xequipItem.fuseInfo.BreakNum, equipConf.FuseCanBreakNum));
					}
					else
					{
						this.m_breakLevelLab.SetText("");
					}
					bool flag4 = itemByUID.itemConf != null;
					if (flag4)
					{
						bool flag5 = xequipItem.fuseInfo.BreakNum > 0U;
						string text;
						if (flag5)
						{
							text = this.m_doc.GetFuseIconName(xequipItem.fuseInfo.BreakNum);
							bool flag6 = text != "";
							if (flag6)
							{
								text = XLabelSymbolHelper.FormatAnimation("Item/Item", text, 10);
							}
							text = string.Format("{0}[{1}]{2}", text, XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)itemByUID.itemConf.ItemQuality), itemByUID.itemConf.ItemName[0]);
							bool flag7 = xequipItem.enhanceInfo.EnhanceLevel > 0U;
							if (flag7)
							{
								text = XSingleton<XCommon>.singleton.StringCombine(text, "+", xequipItem.enhanceInfo.EnhanceLevel.ToString());
							}
						}
						else
						{
							text = string.Format("[{0}]{1}", XSingleton<UiUtility>.singleton.GetItemQualityColorStr((int)itemByUID.itemConf.ItemQuality), itemByUID.itemConf.ItemName[0]);
							bool flag8 = xequipItem.enhanceInfo.EnhanceLevel > 0U;
							if (flag8)
							{
								text = string.Format("{0}+{1}", text, xequipItem.enhanceInfo.EnhanceLevel);
							}
						}
						this.m_symbolLab.InputText = text;
					}
					this.m_contentLab.SetText(XSingleton<XStringTable>.singleton.GetString("EquipFuseTips"));
					this.FillAttribute();
					this.FillButtom(xequipItem.fuseInfo, equipConf);
				}
			}
		}

		// Token: 0x0600F1A0 RID: 61856 RVA: 0x003568B4 File Offset: 0x00354AB4
		private void FillAttribute()
		{
			this.m_tplPool.ReturnAll(false);
			float num = (float)((this.m_doc.FuseDataList.Count - 1) * this.m_tplPool.TplHeight / 2);
			for (int i = 0; i < this.m_doc.FuseDataList.Count; i++)
			{
				GameObject gameObject = this.m_tplPool.FetchGameObject(false);
				gameObject.name = i.ToString();
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(0f, num - (float)(i * this.m_tplPool.TplHeight), 0f);
				EquipFuseData equipFuseData = this.m_doc.FuseDataList[i];
				IXUILabel ixuilabel = gameObject.transform.Find("Now").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format("{0}", XStringDefineProxy.GetString((XAttributeDefine)equipFuseData.AttrId)));
				ixuilabel = (gameObject.transform.Find("Now/NowValue").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(equipFuseData.BeforeAddNum.ToString());
				ixuilabel = (gameObject.transform.Find("AfterValue").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(equipFuseData.AfterAddNum.ToString());
				uint upNum = equipFuseData.UpNum;
				ixuilabel = (gameObject.transform.Find("Up").GetComponent("XUILabel") as IXUILabel);
				bool flag = upNum == 0U;
				if (flag)
				{
					ixuilabel.gameObject.SetActive(false);
				}
				else
				{
					ixuilabel.gameObject.SetActive(true);
					ixuilabel.SetText(string.Format("+{0}", upNum));
				}
			}
		}

		// Token: 0x0600F1A1 RID: 61857 RVA: 0x00356A9C File Offset: 0x00354C9C
		private void SetItemActive(bool flag)
		{
			bool flag2 = this.m_itemsGoList == null;
			if (!flag2)
			{
				for (int i = 0; i < this.m_itemsGoList.Count; i++)
				{
					this.m_itemsGoList[i].SetActive(false);
				}
			}
		}

		// Token: 0x0600F1A2 RID: 61858 RVA: 0x00356AE8 File Offset: 0x00354CE8
		private void FillButtom(XequipFuseInfo info, EquipList.RowData row)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				EquipFusionTable.RowData fuseData = this.m_doc.GetFuseData(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, row, info.BreakNum);
				bool flag2 = fuseData == null;
				if (!flag2)
				{
					this.FillNeedItem(row.ItemID, fuseData);
					IXUILabel ixuilabel = this.m_fuseBtn.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
					bool isBreak = this.m_doc.IsBreak;
					if (isBreak)
					{
						this.m_tipsLab.SetText(XSingleton<XStringTable>.singleton.GetString("EquipFuseNoCoreItem"));
						ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("CATD_ATTRIBUTE_ACTIVE2"));
					}
					else
					{
						this.m_tipsLab.SetText(XSingleton<XStringTable>.singleton.GetString("EquipFuseNoCoreItem1"));
						ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("EquipFusion"));
					}
					IXUISprite ixuisprite = this.m_fuseBtn.gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetGrey(!this.m_doc.IsMax);
				}
			}
		}

		// Token: 0x0600F1A3 RID: 61859 RVA: 0x00356C20 File Offset: 0x00354E20
		private void FillNeedItem(int itemId, EquipFusionTable.RowData fuseRow)
		{
			bool isBreak = this.m_doc.IsBreak;
			if (isBreak)
			{
				this.m_itemGo.SetActive(false);
				this.SetItemActive(false);
				this.m_addSpr.gameObject.SetActive(false);
				this.m_materialIsEnough = true;
				this.UpdateProcessBar();
				int num = 0;
				while (num < (int)fuseRow.BreakNeedMaterial.count && num < this.m_itemsGoList.Count)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)fuseRow.BreakNeedMaterial[num, 0]);
					bool flag = itemConf == null;
					if (!flag)
					{
						GameObject gameObject = this.m_itemsGoList[num];
						gameObject.SetActive(true);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)fuseRow.BreakNeedMaterial[num, 0], 0, false);
						IXUILabel ixuilabel = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.gameObject.SetActive(true);
						ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)fuseRow.BreakNeedMaterial[num, 0]);
						IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.RegisterSpriteClickEventHandler(null);
						bool flag2 = itemConf.ItemType == 3;
						if (flag2)
						{
							ixuilabel.SetText(fuseRow.BreakNeedMaterial[num, 1].ToString());
							bool flag3 = (ulong)fuseRow.BreakNeedMaterial[num, 1] > itemCount;
							if (flag3)
							{
								ixuilabel.SetText(string.Format("[ff0000]{0}[-]", fuseRow.BreakNeedMaterial[num, 1]));
								this.m_materialIsEnough = false;
							}
							else
							{
								ixuilabel.SetText(fuseRow.BreakNeedMaterial[num, 1].ToString());
							}
						}
						else
						{
							bool flag4 = (ulong)fuseRow.BreakNeedMaterial[num, 1] > itemCount;
							if (flag4)
							{
								ixuilabel.SetText(string.Format("{0} [ff0000]{1}[-]/{2}", itemConf.ItemName[0], itemCount, fuseRow.BreakNeedMaterial[num, 1]));
								this.m_materialIsEnough = false;
								ixuisprite.ID = (ulong)fuseRow.BreakNeedMaterial[num, 0];
								ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
							}
							else
							{
								ixuilabel.SetText(string.Format("{0} [00ff00]{1}[-]/{2}", itemConf.ItemName[0], itemCount, fuseRow.BreakNeedMaterial[num, 1]));
							}
						}
					}
					num++;
				}
			}
			else
			{
				this.UpdateItem();
			}
		}

		// Token: 0x0600F1A4 RID: 61860 RVA: 0x00356EE0 File Offset: 0x003550E0
		public void UpdateItem()
		{
			this.SetItemActive(false);
			this.m_addSpr.gameObject.SetActive(true);
			this.m_materialIsEnough = true;
			this.UpdateProcessBar();
			bool flag = this.m_doc.MaterialId == 0;
			if (flag)
			{
				this.m_materialIsEnough = false;
				this.m_itemGo.SetActive(false);
			}
			else
			{
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (!flag2)
				{
					XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
					bool flag3 = itemByUID == null || itemByUID.Type != ItemType.EQUIP;
					if (!flag3)
					{
						EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
						bool flag4 = equipConf == null;
						if (!flag4)
						{
							XEquipItem xequipItem = itemByUID as XEquipItem;
							EquipFusionTable.RowData fuseData = this.m_doc.GetFuseData(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, equipConf, xequipItem.fuseInfo.BreakNum);
							bool flag5 = fuseData == null;
							if (!flag5)
							{
								uint addExp = this.m_doc.GetAddExp((uint)this.m_doc.MaterialId);
								uint num = (fuseData.NeedExpPerLevel % addExp == 0U) ? (fuseData.NeedExpPerLevel / addExp) : (fuseData.NeedExpPerLevel / addExp + 1U);
								ulong itemCount = XBagDocument.BagDoc.GetItemCount(this.m_doc.MaterialId);
								this.m_itemGo.SetActive(true);
								XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGo, this.m_doc.MaterialId, 0, false);
								IXUILabel ixuilabel = this.m_itemGo.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
								ixuilabel.gameObject.SetActive(true);
								bool flag6 = itemCount >= (ulong)num;
								if (flag6)
								{
									ixuilabel.SetText(string.Format("[00ff00]{0}[-]/{1}", itemCount, num));
								}
								else
								{
									this.m_materialIsEnough = false;
									ixuilabel.SetText(string.Format("[ff0000]{0}[-]/{1}", itemCount, num));
								}
								SeqListRef<uint> assistItems = this.m_doc.GetAssistItems((uint)this.m_doc.MaterialId);
								int num2 = 0;
								while (num2 < (int)assistItems.count && num2 < this.m_itemsGoList.Count)
								{
									ItemList.RowData itemConf = XBagDocument.GetItemConf((int)assistItems[num2, 0]);
									bool flag7 = itemConf == null;
									if (!flag7)
									{
										GameObject gameObject = this.m_itemsGoList[num2];
										gameObject.SetActive(true);
										XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)assistItems[num2, 0], 0, false);
										ixuilabel = (gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel);
										ixuilabel.gameObject.SetActive(true);
										itemCount = XBagDocument.BagDoc.GetItemCount((int)assistItems[num2, 0]);
										IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
										ixuisprite.RegisterSpriteClickEventHandler(null);
										bool flag8 = itemConf.ItemType == 3;
										if (flag8)
										{
											bool flag9 = (ulong)(assistItems[num2, 1] * num) > itemCount;
											if (flag9)
											{
												ixuilabel.SetText(string.Format("[ff0000]{0}[-]", assistItems[num2, 1] * num));
												this.m_materialIsEnough = false;
											}
											else
											{
												ixuilabel.SetText((assistItems[num2, 1] * num).ToString());
											}
										}
										else
										{
											bool flag10 = (ulong)(assistItems[num2, 1] * num) > itemCount;
											if (flag10)
											{
												ixuilabel.SetText(string.Format("{0} [ff0000]{1}[-]/{2}", itemConf.ItemName[0], itemCount, assistItems[num2, 1] * num));
												this.m_materialIsEnough = false;
												ixuisprite.ID = (ulong)assistItems[num2, 0];
												ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
											}
											else
											{
												ixuilabel.SetText(string.Format("{0} [00ff00]{1}[-]/{2}", itemConf.ItemName[0], itemCount, assistItems[num2, 1] * num));
											}
										}
									}
									num2++;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F1A5 RID: 61861 RVA: 0x00357344 File Offset: 0x00355544
		private void UpdateProcessBar()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null || itemByUID.Type != ItemType.EQUIP;
			if (!flag)
			{
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (!flag2)
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
					bool flag3 = equipConf == null;
					if (!flag3)
					{
						XEquipItem xequipItem = itemByUID as XEquipItem;
						EquipFusionTable.RowData fuseData = this.m_doc.GetFuseData(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, equipConf, xequipItem.fuseInfo.BreakNum);
						bool flag4 = fuseData == null;
						if (!flag4)
						{
							uint num = fuseData.NeedExpPerLevel * fuseData.LevelNum;
							this.m_processValueLab.SetText(string.Format("{0}/{1}", xequipItem.fuseInfo.FuseExp, num));
							float num2 = xequipItem.fuseInfo.FuseExp / num;
							this.m_process.value = ((num2 > 1f) ? 1f : num2);
							bool flag5 = this.m_doc.MaterialId == 0 || this.m_doc.IsBreak;
							if (flag5)
							{
								this.m_previewValueLab.SetText("");
								this.m_previewSpr.SetFillAmount((num2 > 1f) ? 1f : num2);
							}
							else
							{
								uint num3 = this.m_doc.GetAddExp((uint)this.m_doc.MaterialId);
								num3 = Math.Max(num3, fuseData.NeedExpPerLevel);
								this.m_previewValueLab.SetText(string.Format("+{0}", num3));
								num2 = (xequipItem.fuseInfo.FuseExp + num3) / num;
								this.m_previewSpr.SetFillAmount((num2 > 1f) ? 1f : num2);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F1A6 RID: 61862 RVA: 0x00357534 File Offset: 0x00355734
		public void UpdateButtom()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
			bool flag = itemByUID == null || itemByUID.Type != ItemType.EQUIP;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					XEquipItem xequipItem = itemByUID as XEquipItem;
					this.FillButtom(xequipItem.fuseInfo, equipConf);
				}
			}
		}

		// Token: 0x0600F1A7 RID: 61863 RVA: 0x003575A0 File Offset: 0x003557A0
		private void DeActiveEffect()
		{
			bool flag = this.m_fx != null;
			if (flag)
			{
				this.m_fx.SetActive(false);
			}
			bool flag2 = this.m_fuseBreakFx != null;
			if (flag2)
			{
				this.m_fuseBreakFx.SetActive(false);
			}
		}

		// Token: 0x0600F1A8 RID: 61864 RVA: 0x003575E4 File Offset: 0x003557E4
		private void SetEffect(GameObject go, uint breakLevel)
		{
			bool flag = go == null;
			if (!flag)
			{
				bool flag2 = this.m_fuseBreakFx != null;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fuseBreakFx, true);
					this.m_fuseBreakFx = null;
				}
				string location;
				bool flag3 = !this.m_doc.GetEffectPath(breakLevel, out location);
				if (!flag3)
				{
					this.m_fuseBreakFx = XSingleton<XFxMgr>.singleton.CreateUIFx(location, go.transform.FindChild("Icon/Icon/Effects"), false);
					XFx.SyncRefreshUIRenderQueue(this.m_fuseBreakFx);
				}
			}
		}

		// Token: 0x0600F1A9 RID: 61865 RVA: 0x00357670 File Offset: 0x00355870
		private bool OnClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F1AA RID: 61866 RVA: 0x0035768C File Offset: 0x0035588C
		private bool OnHelp(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_EquipFusion);
			return true;
		}

		// Token: 0x0600F1AB RID: 61867 RVA: 0x003576B0 File Offset: 0x003558B0
		private bool OnFuse(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_delayTime);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool isMax = this.m_doc.IsMax;
				if (isMax)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("EquipFuseBreakMax"), "fece00");
					result = false;
				}
				else
				{
					bool flag2 = !this.m_doc.IsBreak && this.m_doc.MaterialId == 0;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("EquipFuseNoCoreItem1"), "fece00");
						result = false;
					}
					else
					{
						bool flag3 = !this.m_materialIsEnough;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("EquipFuseMaterialNotEnough"), "fece00");
							result = false;
						}
						else
						{
							this.m_doc.ReqEquipFuseMes();
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600F1AC RID: 61868 RVA: 0x00357798 File Offset: 0x00355998
		private void OnSelectItem(IXUISprite spr)
		{
			bool flag = this.m_doc.IsBreak || this.m_doc.IsMax;
			if (!flag)
			{
				DlgHandlerBase.EnsureCreate<EquipFusionSelectHandler>(ref this.m_selectHandler, base.PanelObject.transform, true, this);
			}
		}

		// Token: 0x0600F1AD RID: 61869 RVA: 0x003577E0 File Offset: 0x003559E0
		private void OnClickItem(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XItem xitem = XBagDocument.BagDoc.GetItemByUID(id);
			bool flag = xitem == null;
			if (flag)
			{
				xitem = XBagDocument.MakeXItem((int)id, false);
			}
			bool flag2 = xitem == null;
			if (!flag2)
			{
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, iSp, false, 0U);
			}
		}

		// Token: 0x0600F1AE RID: 61870 RVA: 0x0035782E File Offset: 0x00355A2E
		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		// Token: 0x0600F1AF RID: 61871 RVA: 0x00357844 File Offset: 0x00355A44
		private void OnClickItemIcon(IXUISprite spr)
		{
			int itemid = (int)spr.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
		}

		// Token: 0x0600F1B0 RID: 61872 RVA: 0x00357867 File Offset: 0x00355A67
		private void OnFuseHelpPress(IXUIButton btn, bool isPressed)
		{
			this.m_contentGo.SetActive(isPressed);
		}

		// Token: 0x0600F1B1 RID: 61873 RVA: 0x00357878 File Offset: 0x00355A78
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04006742 RID: 26434
		private EquipFusionDocument m_doc;

		// Token: 0x04006743 RID: 26435
		private EquipFusionSelectHandler m_selectHandler;

		// Token: 0x04006744 RID: 26436
		private IXUIButton m_closedBtn;

		// Token: 0x04006745 RID: 26437
		private IXUIButton m_helpBtn;

		// Token: 0x04006746 RID: 26438
		private IXUIButton m_fuseHelpBtn;

		// Token: 0x04006747 RID: 26439
		private IXUIButton m_fuseBtn;

		// Token: 0x04006748 RID: 26440
		private IXUILabel m_breakLevelLab;

		// Token: 0x04006749 RID: 26441
		private IXUILabel m_processValueLab;

		// Token: 0x0400674A RID: 26442
		private IXUILabel m_previewValueLab;

		// Token: 0x0400674B RID: 26443
		private IXUILabel m_contentLab;

		// Token: 0x0400674C RID: 26444
		private IXUILabelSymbol m_symbolLab;

		// Token: 0x0400674D RID: 26445
		private IXUILabel m_tipsLab;

		// Token: 0x0400674E RID: 26446
		private IXUIProgress m_process;

		// Token: 0x0400674F RID: 26447
		private IXUISprite m_addSpr;

		// Token: 0x04006750 RID: 26448
		private IXUISprite m_previewSpr;

		// Token: 0x04006751 RID: 26449
		private GameObject m_equipItemGo;

		// Token: 0x04006752 RID: 26450
		private GameObject m_itemGo;

		// Token: 0x04006753 RID: 26451
		private GameObject m_contentGo;

		// Token: 0x04006754 RID: 26452
		private XUIPool m_tplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006755 RID: 26453
		private List<GameObject> m_itemsGoList;

		// Token: 0x04006756 RID: 26454
		private bool m_materialIsEnough = true;

		// Token: 0x04006757 RID: 26455
		private float m_delayTime = 0.5f;

		// Token: 0x04006758 RID: 26456
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04006759 RID: 26457
		private XFx m_fuseBreakFx;

		// Token: 0x0400675A RID: 26458
		private XFx m_fx;

		// Token: 0x0400675B RID: 26459
		private string m_fxPath = string.Empty;
	}
}
