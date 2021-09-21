using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017C4 RID: 6084
	internal class SmeltMainHandler : DlgHandlerBase
	{
		// Token: 0x1700388D RID: 14477
		// (get) Token: 0x0600FBFA RID: 64506 RVA: 0x003AA41C File Offset: 0x003A861C
		private XSmeltDocument m_doc
		{
			get
			{
				return XSmeltDocument.Doc;
			}
		}

		// Token: 0x1700388E RID: 14478
		// (get) Token: 0x0600FBFB RID: 64507 RVA: 0x003AA434 File Offset: 0x003A8634
		public string EffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_effectPath);
				if (flag)
				{
					this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("SmeltEffectPath");
				}
				return this.m_effectPath;
			}
		}

		// Token: 0x1700388F RID: 14479
		// (get) Token: 0x0600FBFC RID: 64508 RVA: 0x003AA470 File Offset: 0x003A8670
		protected override string FileName
		{
			get
			{
				return "ItemNew/SmeltMainHandler";
			}
		}

		// Token: 0x0600FBFD RID: 64509 RVA: 0x003AA488 File Offset: 0x003A8688
		protected override void Init()
		{
			base.Init();
			this.m_AttrParentGo = base.PanelObject.transform.FindChild("AttrParentGo").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("AttrTpl");
			this.m_AttrTplPool.SetupPool(this.m_AttrParentGo, transform.gameObject, 3U, false);
			transform = base.PanelObject.transform.FindChild("Top");
			this.m_SmeltItemGo = transform.FindChild("SmeltItem").gameObject;
			this.m_tips1Lab = (transform.FindChild("Tips1").GetComponent("XUILabel") as IXUILabel);
			this.m_tips2Lab = (transform.FindChild("Tips2").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ClosedBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TittleLab = (base.PanelObject.transform.FindChild("TittleLab").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Bottom");
			this.m_SmeltBtn = (transform.FindChild("SmeltBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_NeedGoldLab = (transform.FindChild("NeedGoldLab").GetComponent("XUILabel") as IXUILabel);
			this.m_btnRedDot = this.m_SmeltBtn.gameObject.transform.FindChild("RedPoint").gameObject;
			this.m_resultGo = base.PanelObject.transform.FindChild("Result").gameObject;
			bool flag = this.m_itemGoList == null;
			if (flag)
			{
				transform = transform.FindChild("Items");
				this.m_itemGoList = new List<GameObject>();
				for (int i = 0; i < transform.childCount; i++)
				{
					this.m_itemGoList.Add(transform.GetChild(i).gameObject);
				}
			}
			this.m_doc.View = this;
			this.m_tips1Lab.SetText(XSingleton<XStringTable>.singleton.GetString("SmeltNewTips1"));
			this.m_tips2Lab.SetText(XSingleton<XStringTable>.singleton.GetString("SmeltNewTips2"));
		}

		// Token: 0x0600FBFE RID: 64510 RVA: 0x003AA704 File Offset: 0x003A8904
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ClosedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_SmeltBtn.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnIconPress));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600FBFF RID: 64511 RVA: 0x003AA764 File Offset: 0x003A8964
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Smelting);
			return true;
		}

		// Token: 0x0600FC00 RID: 64512 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600FC01 RID: 64513 RVA: 0x003AA784 File Offset: 0x003A8984
		protected override void OnHide()
		{
			this.m_doc.Clear();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler.RegisterItemClickEvents(null);
			}
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
			bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag2)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(0UL);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			}
			bool flag3 = this.m_fx != null;
			if (flag3)
			{
				this.m_fx.Stop();
				this.m_fx.SetActive(false);
			}
			this.m_bStatus = false;
			base.OnHide();
		}

		// Token: 0x0600FC02 RID: 64514 RVA: 0x003AA844 File Offset: 0x003A8A44
		public override void OnUnload()
		{
			this.m_doc.View = null;
			this.m_doc.MesIsBack = true;
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600FC03 RID: 64515 RVA: 0x003AA89C File Offset: 0x003A8A9C
		public override void RefreshData()
		{
			base.RefreshData();
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag = itemByUID != null;
			if (flag)
			{
				bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.IsVisible() && itemByUID.Type == ItemType.EQUIP;
				if (flag2)
				{
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.EMBLEM && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler.IsVisible();
					if (flag3)
					{
						DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._EmblemEquipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
					}
				}
			}
			this.ShowUi();
		}

		// Token: 0x0600FC04 RID: 64516 RVA: 0x00358051 File Offset: 0x00356251
		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		// Token: 0x0600FC05 RID: 64517 RVA: 0x003AA96D File Offset: 0x003A8B6D
		public void RefreshUi(bool randTips)
		{
			this.m_bIsInit = false;
			this.m_bIsNeedRandTips = randTips;
			this.FillContent();
		}

		// Token: 0x0600FC06 RID: 64518 RVA: 0x003AA985 File Offset: 0x003A8B85
		public void ShowUi()
		{
			this.m_bIsInit = true;
			this.GetShowIndex();
			this.FillContent();
		}

		// Token: 0x0600FC07 RID: 64519 RVA: 0x003AA99D File Offset: 0x003A8B9D
		public void UpdateUi(bool randTips)
		{
			this.m_bIsInit = true;
			this.m_bIsNeedRandTips = randTips;
			this.FillContent();
		}

		// Token: 0x0600FC08 RID: 64520 RVA: 0x003AA9B5 File Offset: 0x003A8BB5
		private void FillContent()
		{
			this.FillTop();
			this.FillAttrList();
			this.FillResultPanel();
			this.FillBottom();
		}

		// Token: 0x0600FC09 RID: 64521 RVA: 0x003AA9D4 File Offset: 0x003A8BD4
		private void FillTop()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag = itemByUID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find uid : ", this.m_doc.CurUid.ToString(), null, null, null, null);
			}
			else
			{
				bool flag2 = itemByUID.Type == ItemType.EQUIP;
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_SmeltItemGo, itemByUID as XEquipItem);
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.EMBLEM;
					if (flag3)
					{
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_SmeltItemGo, itemByUID as XEmblemItem);
					}
					else
					{
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_SmeltItemGo, itemByUID);
					}
				}
				IXUISprite ixuisprite = this.m_SmeltItemGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = this.m_doc.CurUid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
				bool flag4 = itemByUID.Type == ItemType.EQUIP;
				if (flag4)
				{
					this.m_TittleLab.SetText(XStringDefineProxy.GetString("EquipSmelt"));
				}
				else
				{
					this.m_TittleLab.SetText(XStringDefineProxy.GetString("EmbleSmelt"));
				}
			}
		}

		// Token: 0x0600FC0A RID: 64522 RVA: 0x003AAB18 File Offset: 0x003A8D18
		private void FillAttrList()
		{
			this.m_AttrTplPool.ReturnAll(false);
			bool flag = this.m_fx != null;
			if (flag)
			{
				this.m_fx.Stop();
				this.m_fx.SetActive(false);
			}
			bool flag2 = this.m_doc.SmeltAttrList == null || this.m_doc.SmeltAttrList.Count == 0;
			if (!flag2)
			{
				for (int i = 0; i < this.m_doc.SmeltAttrList.Count; i++)
				{
					GameObject gameObject = this.m_AttrTplPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-57 * i), 0f);
					this.FillAttrItem(gameObject, this.m_doc.GetSmeltAttr(i), i);
				}
			}
		}

		// Token: 0x0600FC0B RID: 64523 RVA: 0x003AABEC File Offset: 0x003A8DEC
		private void FillAttrItem(GameObject go, SmeltAttr attr, int index)
		{
			bool flag = attr == null;
			if (!flag)
			{
				IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				string text = string.Format("[{0}]{1}[-]", attr.ColorStr, XAttributeCommon.GetAttrStr((int)attr.AttrID));
				ixuilabel.SetText(text);
				text = string.Format("[{0}]{1}[-]", attr.ColorStr, attr.RealValue);
				ixuilabel = (go.transform.FindChild("Name/Value").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(text);
				text = string.Format("[{0}]{1}[{2}-{3}][-]", new object[]
				{
					attr.ColorStr,
					XStringDefineProxy.GetString("SmeltRange"),
					attr.Min,
					attr.Max
				});
				ixuilabel = (go.transform.FindChild("RangeVlue").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(text);
				go.transform.FindChild("Select").gameObject.SetActive(false);
				go.transform.FindChild("Select1").gameObject.SetActive(false);
				IXUISprite ixuisprite = go.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickCheckBox));
				go.transform.FindChild("RedPoint").gameObject.SetActive(false);
				bool flag2 = index == this.m_doc.SelectIndex;
				if (flag2)
				{
					this.m_curTra = go.transform;
					this.m_curTra.FindChild("Select").gameObject.SetActive(true);
					this.m_curTra.FindChild("Select1").gameObject.SetActive(true);
					bool flag3 = !this.m_bIsInit;
					if (flag3)
					{
						bool flag4 = this.m_fx == null;
						if (flag4)
						{
							this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.EffectPath, null, true);
						}
						else
						{
							this.m_fx.SetActive(true);
						}
						this.m_fx.Play(go.transform.FindChild("effect"), Vector3.zero, Vector3.one, 1f, true, false);
					}
					this.FillResultPanel();
				}
			}
		}

		// Token: 0x0600FC0C RID: 64524 RVA: 0x003AAE64 File Offset: 0x003A9064
		private void FillResultPanel()
		{
			SmeltAttr smeltAttr = this.m_doc.GetSmeltAttr(this.m_doc.SelectIndex);
			bool flag = smeltAttr == null;
			if (flag)
			{
				this.m_resultGo.SetActive(false);
			}
			else
			{
				this.m_resultGo.SetActive(true);
				IXUILabel ixuilabel = this.m_resultGo.transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel;
				bool bIsNeedRandTips = this.m_bIsNeedRandTips;
				if (bIsNeedRandTips)
				{
					ixuilabel.SetText(this.GetTips());
				}
				else
				{
					this.m_bIsNeedRandTips = true;
				}
				this.m_btnRedDot.SetActive(false);
				ixuilabel = (this.m_resultGo.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
				string text = string.Format("[{0}]{1}[-]", smeltAttr.ColorStr, XAttributeCommon.GetAttrStr((int)smeltAttr.AttrID));
				ixuilabel.SetText(text);
				bool flag2 = smeltAttr.LastValue == -1;
				if (flag2)
				{
					ixuilabel = (this.m_resultGo.transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format("[{0}]{1}[-]", smeltAttr.ColorStr, this.GetAttrValue()));
					ixuilabel = (this.m_resultGo.transform.FindChild("AfterValue").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format("[{0}]{1}[-]", smeltAttr.ColorStr, "???"));
					ixuilabel.gameObject.transform.FindChild("Up").gameObject.SetActive(false);
					ixuilabel.gameObject.transform.FindChild("Down").gameObject.SetActive(false);
				}
				else
				{
					ixuilabel = (this.m_resultGo.transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format("[{0}]{1}[-]", smeltAttr.ColorStr, smeltAttr.LastValue));
					ixuilabel = (this.m_resultGo.transform.FindChild("AfterValue").GetComponent("XUILabel") as IXUILabel);
					bool isReplace = smeltAttr.IsReplace;
					if (isReplace)
					{
						ixuilabel.SetText(string.Format("[63ff85]{0}[-]", smeltAttr.SmeltResult));
						ixuilabel.gameObject.transform.FindChild("Down").gameObject.SetActive(false);
						ixuilabel = (ixuilabel.gameObject.transform.FindChild("Up").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText(string.Format("[63ff85]{0}[-]", (long)((ulong)smeltAttr.SmeltResult - (ulong)((long)smeltAttr.LastValue))));
						ixuilabel.gameObject.SetActive(true);
					}
					else
					{
						ixuilabel.SetText(string.Format("[ff3e3e]{0}[-]", smeltAttr.SmeltResult));
						ixuilabel.gameObject.transform.FindChild("Up").gameObject.SetActive(false);
						ixuilabel = (ixuilabel.gameObject.transform.FindChild("Down").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText(string.Format("[ff3e3e]{0}[-]", (long)smeltAttr.LastValue - (long)((ulong)smeltAttr.SmeltResult)));
						ixuilabel.gameObject.SetActive(true);
					}
				}
			}
		}

		// Token: 0x0600FC0D RID: 64525 RVA: 0x003AB1E0 File Offset: 0x003A93E0
		private string GetTips()
		{
			SmeltAttr smeltAttr = this.m_doc.GetSmeltAttr(this.m_doc.SelectIndex);
			bool flag = smeltAttr == null || smeltAttr.LastValue == -1;
			string @string;
			if (flag)
			{
				@string = XStringDefineProxy.GetString("SmeltBadNotReplace");
			}
			else
			{
				int num = UnityEngine.Random.Range(0, 10);
				bool isReplace = smeltAttr.IsReplace;
				if (isReplace)
				{
					@string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("SmeltSucceed", num.ToString()));
				}
				else
				{
					@string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("SmeltLost", num.ToString()));
				}
			}
			return @string;
		}

		// Token: 0x0600FC0E RID: 64526 RVA: 0x003AB27C File Offset: 0x003A947C
		private uint GetAttrValue()
		{
			SmeltAttr smeltAttr = this.m_doc.GetSmeltAttr(this.m_doc.SelectIndex);
			bool flag = smeltAttr == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = smeltAttr.RealValue;
			}
			return result;
		}

		// Token: 0x0600FC0F RID: 64527 RVA: 0x003AB2B7 File Offset: 0x003A94B7
		public void UpdateNeedItem()
		{
			this.FillBottom();
		}

		// Token: 0x0600FC10 RID: 64528 RVA: 0x003AB2C4 File Offset: 0x003A94C4
		private void FillBottom()
		{
			this.m_NeedGoldLab.SetText(this.m_doc.GetNeedGold().ToString());
			SeqListRef<uint> needItem = this.m_doc.GetNeedItem();
			this.m_needItemIsEnough = true;
			for (int i = 0; i < this.m_itemGoList.Count; i++)
			{
				GameObject gameObject = this.m_itemGoList[i];
				bool flag = gameObject == null;
				if (!flag)
				{
					bool flag2 = i >= needItem.Count;
					if (flag2)
					{
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, null, 0, false);
					}
					else
					{
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)needItem[i, 0], (int)needItem[i, 1], false);
						ulong itemCount = XBagDocument.BagDoc.GetItemCount((int)needItem[i, 0]);
						bool flag3 = itemCount >= (ulong)needItem[i, 1];
						bool flag4 = i == 0;
						if (flag4)
						{
							int num = 0;
							this.m_NeedSmeltStoneLst = this.m_doc.GetShouldShowItems((int)needItem[i, 0], (int)needItem[i, 1], ref num);
							flag3 = ((long)num >= (long)((ulong)needItem[i, 1]));
							this.m_smeltItemId = (int)needItem[i, 0];
						}
						bool flag5 = !flag3;
						if (flag5)
						{
							this.m_needItemIsEnough = false;
						}
						IXUILabel ixuilabel = gameObject.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.gameObject.SetActive(true);
						bool flag6 = flag3;
						if (flag6)
						{
							ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_ENOUGH_FMT"), itemCount, needItem[i, 1]));
						}
						else
						{
							ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT"), itemCount, needItem[i, 1]));
						}
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)needItem[i, 0];
						bool flag7 = flag3;
						if (flag7)
						{
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						}
						else
						{
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetItemAccess));
						}
					}
				}
			}
		}

		// Token: 0x0600FC11 RID: 64529 RVA: 0x003AB534 File Offset: 0x003A9734
		private void GetShowIndex()
		{
			this.m_doc.SelectIndex = 0;
			bool flag = this.m_doc.SmeltAttrList == null || this.m_doc.SmeltAttrList.Count == 0;
			if (!flag)
			{
				for (int i = 0; i < this.m_doc.SmeltAttrList.Count; i++)
				{
					bool flag2 = !this.m_doc.SmeltAttrList[i].IsFull;
					if (flag2)
					{
						this.m_doc.SelectIndex = i;
						break;
					}
				}
			}
		}

		// Token: 0x0600FC12 RID: 64530 RVA: 0x003AB5C4 File Offset: 0x003A97C4
		private string GetTipsStr()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ItemList.RowData itemConf;
			for (int i = 0; i < this.m_NeedSmeltStoneLst.Count; i++)
			{
				itemConf = XBagDocument.GetItemConf(this.m_NeedSmeltStoneLst[i].Item1);
				bool flag = itemConf != null;
				if (flag)
				{
					stringBuilder.Append(this.m_NeedSmeltStoneLst[i].Item2).Append(XSingleton<XStringTable>.singleton.GetString("Ge")).Append("[00ff00]").Append(itemConf.ItemName[0]).Append("[-]");
					bool flag2 = i != this.m_NeedSmeltStoneLst.Count;
					if (flag2)
					{
						stringBuilder.Append(",");
					}
				}
			}
			itemConf = XBagDocument.GetItemConf(this.m_smeltItemId);
			bool flag3 = itemConf != null;
			string result;
			if (flag3)
			{
				result = string.Format(XSingleton<XStringTable>.singleton.GetString("SmeltStoneExchangedTips"), itemConf.ItemName[0], stringBuilder);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600FC13 RID: 64531 RVA: 0x003AB6D0 File Offset: 0x003A98D0
		private bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FC14 RID: 64532 RVA: 0x003AB6EC File Offset: 0x003A98EC
		private bool Smelt()
		{
			uint needGold = this.m_doc.GetNeedGold();
			bool flag = (ulong)needGold >= XBagDocument.BagDoc.GetItemCount(1);
			bool result;
			if (flag)
			{
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				int vipLevel = (int)specificDocument.VipLevel;
				XPurchaseDocument xpurchaseDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XPurchaseDocument.uuID) as XPurchaseDocument;
				XPurchaseInfo purchaseInfo = xpurchaseDocument.GetPurchaseInfo(level, vipLevel, ItemEnum.GOLD);
				bool flag2 = purchaseInfo.totalBuyNum > purchaseInfo.curBuyNum;
				if (flag2)
				{
					DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_LACKCOIN"), "fece00");
				}
				this.m_bStatus = false;
				result = true;
			}
			else
			{
				bool flag3 = !this.m_needItemIsEnough;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SMELTING_LACKMONEY"), "fece00");
					this.m_bStatus = false;
					result = true;
				}
				else
				{
					SmeltAttr smeltAttr = this.m_doc.GetSmeltAttr(this.m_doc.SelectIndex);
					bool flag4 = smeltAttr == null;
					if (flag4)
					{
						this.m_bStatus = false;
						result = true;
					}
					else
					{
						bool isFull = smeltAttr.IsFull;
						if (isFull)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SmeltAttrFull"), "fece00");
							this.m_bStatus = false;
							result = true;
						}
						else
						{
							bool flag5 = !smeltAttr.IsCanSmelt;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ThisAttrCannotSmelt"), "fece00");
								this.m_bStatus = false;
								result = true;
							}
							else
							{
								XOptionsDocument specificDocument2 = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
								bool flag6 = (this.m_NeedSmeltStoneLst.Count == 1 && this.m_NeedSmeltStoneLst[0].Item1 == this.m_smeltItemId) || specificDocument2.GetValue(XOptionsDefine.OD_NO_SMELTSTONE_EXCHANGED_CONFIRM) == 1;
								if (flag6)
								{
									this.m_doc.ReqSmelt();
								}
								else
								{
									XSingleton<UiUtility>.singleton.ShowModalDialog(this.GetTipsStr(), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_SMELTSTONE_EXCHANGED, 50);
									this.m_bStatus = false;
								}
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600FC15 RID: 64533 RVA: 0x003AB938 File Offset: 0x003A9B38
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_SMELTSTONE_EXCHANGED_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_SMELTSTONE_EXCHANGED) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FC16 RID: 64534 RVA: 0x003AB980 File Offset: 0x003A9B80
		private bool DoOK(IXUIButton btn)
		{
			this.m_doc.ReqSmelt();
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_SMELTSTONE_EXCHANGED_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_SMELTSTONE_EXCHANGED) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FC17 RID: 64535 RVA: 0x003AB9E4 File Offset: 0x003A9BE4
		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			this.m_bStatus = false;
			ulong id = iSp.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id), null, iSp, false, 0U);
		}

		// Token: 0x0600FC18 RID: 64536 RVA: 0x003ABA24 File Offset: 0x003A9C24
		private void OnGetItemAccess(IXUISprite iSp)
		{
			this.m_bStatus = false;
			int itemid = (int)iSp.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
		}

		// Token: 0x0600FC19 RID: 64537 RVA: 0x003ABA50 File Offset: 0x003A9C50
		public void OnEquipClicked(IXUISprite iSp)
		{
			bool flag = !this.m_doc.MesIsBack;
			if (!flag)
			{
				this.m_bStatus = false;
				this.m_doc.SelectEquip(iSp.ID);
			}
		}

		// Token: 0x0600FC1A RID: 64538 RVA: 0x003ABA8C File Offset: 0x003A9C8C
		private void OnClickCheckBox(IXUISprite iSp)
		{
			bool flag = !this.m_doc.MesIsBack;
			if (!flag)
			{
				this.m_bStatus = false;
				this.m_doc.SelectIndex = (int)iSp.ID;
				bool flag2 = this.m_curTra != null;
				if (flag2)
				{
					this.m_curTra.FindChild("Select").gameObject.SetActive(false);
					this.m_curTra.FindChild("Select1").gameObject.SetActive(false);
				}
				this.m_curTra = iSp.gameObject.transform.parent;
				this.m_curTra.FindChild("Select").gameObject.SetActive(true);
				this.m_curTra.FindChild("Select1").gameObject.SetActive(true);
				this.FillResultPanel();
			}
		}

		// Token: 0x0600FC1B RID: 64539 RVA: 0x003ABB69 File Offset: 0x003A9D69
		private void OnIconPress(IXUIButton btn, bool state)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("icon press", null, null, null, null, null);
			this.m_bStatus = state;
		}

		// Token: 0x0600FC1C RID: 64540 RVA: 0x003ABB88 File Offset: 0x003A9D88
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_bStatus && this.m_doc.MesIsBack;
			if (flag)
			{
				bool flag2 = Time.realtimeSinceStartup - this.m_lastClickTime >= this.m_cdTime;
				if (flag2)
				{
					this.m_lastClickTime = Time.realtimeSinceStartup;
					this.Smelt();
				}
			}
		}

		// Token: 0x04006EC0 RID: 28352
		private XUIPool m_AttrTplPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006EC1 RID: 28353
		private IXUIButton m_ClosedBtn;

		// Token: 0x04006EC2 RID: 28354
		private IXUIButton m_SmeltBtn;

		// Token: 0x04006EC3 RID: 28355
		private IXUIButton m_Help;

		// Token: 0x04006EC4 RID: 28356
		private IXUILabel m_TittleLab;

		// Token: 0x04006EC5 RID: 28357
		private IXUILabel m_NeedGoldLab;

		// Token: 0x04006EC6 RID: 28358
		private IXUILabel m_tips1Lab;

		// Token: 0x04006EC7 RID: 28359
		private IXUILabel m_tips2Lab;

		// Token: 0x04006EC8 RID: 28360
		public GameObject m_btnRedDot;

		// Token: 0x04006EC9 RID: 28361
		public GameObject m_resultGo;

		// Token: 0x04006ECA RID: 28362
		private GameObject m_SmeltItemGo;

		// Token: 0x04006ECB RID: 28363
		private GameObject m_AttrParentGo;

		// Token: 0x04006ECC RID: 28364
		private List<GameObject> m_itemGoList;

		// Token: 0x04006ECD RID: 28365
		private Transform m_curTra = null;

		// Token: 0x04006ECE RID: 28366
		private bool m_needItemIsEnough = true;

		// Token: 0x04006ECF RID: 28367
		private bool m_bIsInit = true;

		// Token: 0x04006ED0 RID: 28368
		private bool m_bIsNeedRandTips = true;

		// Token: 0x04006ED1 RID: 28369
		private List<XTuple<int, int>> m_NeedSmeltStoneLst = new List<XTuple<int, int>>();

		// Token: 0x04006ED2 RID: 28370
		private int m_smeltItemId = 0;

		// Token: 0x04006ED3 RID: 28371
		private XFx m_fx;

		// Token: 0x04006ED4 RID: 28372
		private string m_effectPath = string.Empty;

		// Token: 0x04006ED5 RID: 28373
		private bool m_bStatus = false;

		// Token: 0x04006ED6 RID: 28374
		private float m_cdTime = 0.2f;

		// Token: 0x04006ED7 RID: 28375
		private float m_lastClickTime = 0f;
	}
}
