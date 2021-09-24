using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EnhanceView : DlgHandlerBase
	{

		private XEnhanceDocument m_doc
		{
			get
			{
				return XEnhanceDocument.Doc;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/EnhanceFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_CloseBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.PanelObject.transform.FindChild("Bg/Top");
			this.m_topItemGo = transform.FindChild("EnhanceItem").gameObject;
			this.m_SuccessRateLab = (transform.FindChild("SuccessRate").GetComponent("XUILabel") as IXUILabel);
			this.m_AddRateLab = (transform.FindChild("AddRate").GetComponent("XUILabel") as IXUILabel);
			this.m_BreakRateLab = (transform.FindChild("BreakRate").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Bg/EnhanceMax");
			this.m_EnhanceMaxGo = transform.gameObject;
			this.m_MaxAttrListGo = transform.FindChild("MaxAttrList").gameObject;
			this.m_MaxTipsLab = (transform.FindChild("Bottom/MaxTips").GetComponent("XUILabel") as IXUILabel);
			this.m_EnhanceGo = base.PanelObject.transform.FindChild("Bg/Enhance").gameObject;
			transform = this.m_EnhanceGo.transform.FindChild("EnhanceAttr");
			this.m_BeforeEnhanceGo = transform.FindChild("BeforeEnhance").gameObject;
			this.m_AfterEnhanceGo = transform.FindChild("AfterEnhance").gameObject;
			this.m_TipsLab = (transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_effectsTra = base.PanelObject.transform.FindChild("Bg/Effects");
			transform = this.m_EnhanceGo.transform.FindChild("Bottom");
			this.m_TittleLab = (transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel);
			this.m_EnhanceBtn = (transform.FindChild("EnhanceBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_EnhanceBtnLab = (transform.FindChild("EnhanceBtn/T").GetComponent("XUILabel") as IXUILabel);
			bool flag = this.m_costItemTras == null;
			if (flag)
			{
				this.m_costItemTras = new List<Transform>();
			}
			else
			{
				this.m_costItemTras.Clear();
			}
			this.m_costItemTras.Add(transform.FindChild("CostItem2"));
			this.m_costItemTras.Add(transform.FindChild("CostItem1"));
			transform = base.PanelObject.transform.FindChild("Bg/BeforeAttrTpl");
			this.m_BeforeAttrPool.SetupPool(this.m_BeforeEnhanceGo, transform.gameObject, 3U, false);
			transform = base.PanelObject.transform.FindChild("Bg/AfterAttrTpl");
			this.m_AfterAttrPool.SetupPool(this.m_AfterEnhanceGo, transform.gameObject, 3U, false);
			this.m_doc.enhanceView = this;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			this.m_EnhanceBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnhanceClicked));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Enhance);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		protected override void OnHide()
		{
			this.m_BeforeAttrPool.ReturnAll(false);
			this.m_AfterAttrPool.ReturnAll(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
			this.DeActiveEffect();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnPopHandlerSetVisible(false, null);
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.StackRefresh();
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(0UL);
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(null);
			}
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.m_doc.enhanceView = null;
			bool flag = this.m_EnhanceSucceedEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_EnhanceSucceedEffect, true);
				this.m_EnhanceSucceedEffect = null;
			}
			bool flag2 = this.m_BreakSucceedEffect != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_BreakSucceedEffect, true);
				this.m_BreakSucceedEffect = null;
			}
			bool flag3 = this.m_EnhanceLostEffect != null;
			if (flag3)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_EnhanceLostEffect, true);
				this.m_EnhanceLostEffect = null;
			}
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
			XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.EquipBag.GetItemByUID(this.m_doc.selectedEquip);
			bool flag = itemByUID == null;
			if (flag)
			{
				this.m_doc.SelectEquip(0UL);
			}
			else
			{
				this.m_doc.SelectEquip(this.m_doc.selectedEquip);
			}
			this.ChangeEquip();
		}

		public void ChangeEquip()
		{
			this.DeActiveEffect();
			this.FillContent();
			this.m_doc.ReqEnhanceAttr();
		}

		public void RefreshPage()
		{
			this.DeActiveEffect();
			this.FillContent();
			this.m_doc.ReqEnhanceAttr();
		}

		public void PlayEffect()
		{
			this.m_bIsCanClick = false;
			this.DeActiveEffect();
			bool flag = this.m_doc.CombainItems != null && this.m_doc.CombainItems.Count != 0;
			if (flag)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < this.m_doc.CombainItems.Count; i++)
				{
					bool flag2 = this.m_doc.CombainItems[i].itemId <= 0U;
					if (!flag2)
					{
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_doc.CombainItems[i].itemId);
						bool flag3 = itemConf == null;
						if (!flag3)
						{
							stringBuilder.Append(this.m_doc.CombainItems[i].comNum).Append(XStringDefineProxy.GetString("Ge")).Append(itemConf.ItemName[0]).Append(",");
						}
					}
				}
				float interval = 0f;
				bool flag4 = stringBuilder.Length > 1;
				if (flag4)
				{
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					string text = string.Format(XStringDefineProxy.GetString("CombainSucceed"), stringBuilder.ToString());
					XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
					interval = 1f;
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
				this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.DelayPlayEffect), null);
			}
			else
			{
				this.DelayPlayEffect(null);
			}
		}

		public void FillAttrUi()
		{
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				this.m_EnhanceGo.SetActive(false);
				this.m_EnhanceMaxGo.SetActive(false);
				bool flag2 = xequipItem.enhanceInfo.EnhanceLevel >= this.m_doc.GetMaxEnhanceLevel();
				if (flag2)
				{
					this.FillMaxEnhanceInfo();
				}
				else
				{
					this.FillEnhanceInfo();
				}
			}
		}

		public string EnhanceSucPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_enhanceSucPath);
				if (flag)
				{
					this.m_enhanceSucPath = XSingleton<XGlobalConfig>.singleton.GetValue("EnhanceSucEffectPath");
				}
				return this.m_enhanceSucPath;
			}
		}

		public string BreakSucPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_breakSucPath);
				if (flag)
				{
					this.m_breakSucPath = XSingleton<XGlobalConfig>.singleton.GetValue("BreakSucEffectPath");
				}
				return this.m_breakSucPath;
			}
		}

		public string EnhanceLostPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_enhanceLostPath);
				if (flag)
				{
					this.m_enhanceLostPath = XSingleton<XGlobalConfig>.singleton.GetValue("EnhanceLostEffectPath");
				}
				return this.m_enhanceLostPath;
			}
		}

		private void PlayEnhanceSucceedEffect()
		{
			bool flag = this.m_EnhanceSucceedEffect == null;
			if (flag)
			{
				this.m_EnhanceSucceedEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.EnhanceSucPath, null, true);
			}
			else
			{
				this.m_EnhanceSucceedEffect.SetActive(true);
			}
			this.m_EnhanceSucceedEffect.Play(this.m_effectsTra, Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
			this.m_effectToken = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_delayTime, new XTimerMgr.ElapsedEventHandler(this.DelayRefresh), null);
		}

		private void PlayBreakSucceedEffect()
		{
			bool flag = this.m_BreakSucceedEffect == null;
			if (flag)
			{
				this.m_BreakSucceedEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.BreakSucPath, null, true);
			}
			else
			{
				this.m_BreakSucceedEffect.SetActive(true);
			}
			this.m_BreakSucceedEffect.Play(this.m_effectsTra, Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
			this.m_effectToken = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_delayTime, new XTimerMgr.ElapsedEventHandler(this.DelayRefresh), null);
		}

		private void PlayEnhanceLostEffect()
		{
			bool flag = this.m_EnhanceLostEffect == null;
			if (flag)
			{
				this.m_EnhanceLostEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.EnhanceLostPath, null, true);
			}
			else
			{
				this.m_EnhanceLostEffect.SetActive(true);
			}
			this.m_EnhanceLostEffect.Play(this.m_effectsTra, Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
			this.m_effectToken = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_delayTime, new XTimerMgr.ElapsedEventHandler(this.DelayRefresh), null);
		}

		private void DeActiveEffect()
		{
			bool flag = this.m_EnhanceSucceedEffect != null;
			if (flag)
			{
				this.m_EnhanceSucceedEffect.SetActive(false);
			}
			bool flag2 = this.m_BreakSucceedEffect != null;
			if (flag2)
			{
				this.m_BreakSucceedEffect.SetActive(false);
			}
			bool flag3 = this.m_EnhanceLostEffect != null;
			if (flag3)
			{
				this.m_EnhanceLostEffect.SetActive(false);
			}
		}

		private void FillContent()
		{
			bool flag = this.m_doc.rpcState == XEnhanceRpcState.ERS_RECEIVING;
			if (!flag)
			{
				this.m_bIsCanClick = true;
				XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
				bool flag2 = xequipItem == null;
				if (!flag2)
				{
					EnhanceTable.RowData enhanceRowData = this.m_doc.GetEnhanceRowData(xequipItem);
					bool flag3 = enhanceRowData != null;
					if (flag3)
					{
						this.m_doc.IsNeedBreak = (enhanceRowData.IsNeedBreak > 0U);
					}
					this.FillTopInfo();
				}
			}
		}

		private void FillTopInfo()
		{
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_topItemGo, xequipItem);
				IXUISprite ixuisprite = this.m_topItemGo.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = ((xequipItem != null) ? xequipItem.uid : 0UL);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
				bool flag2 = xequipItem.enhanceInfo.EnhanceLevel >= this.m_doc.GetMaxEnhanceLevel();
				if (flag2)
				{
					this.m_SuccessRateLab.gameObject.SetActive(false);
					this.m_AddRateLab.gameObject.SetActive(false);
					this.m_BreakRateLab.gameObject.SetActive(false);
				}
				else
				{
					EnhanceTable.RowData enhanceRowData = this.m_doc.GetEnhanceRowData(xequipItem);
					bool flag3 = !this.m_doc.IsNeedBreak;
					if (flag3)
					{
						this.m_SuccessRateLab.gameObject.SetActive(true);
						this.m_AddRateLab.gameObject.SetActive(true);
						this.m_BreakRateLab.gameObject.SetActive(false);
						uint num = 0U;
						uint num2 = 0U;
						this.m_doc.GetSuccessRate(xequipItem, ref num, ref num2);
						bool flag4 = num2 == 0U;
						if (flag4)
						{
							this.m_SuccessRateLab.SetText(string.Format("[efd156]{0}{1}%[-]", XStringDefineProxy.GetString("EnhanceRate"), num));
						}
						else
						{
							this.m_SuccessRateLab.SetText(string.Format("[efd156]{0}{1}%[-] [63ff85]+ {2}%[-]", XStringDefineProxy.GetString("EnhanceRate"), num, num2));
						}
						this.m_AddRateLab.SetText(string.Format("{0}+{1}%", XStringDefineProxy.GetString("EnhanceAddRate"), enhanceRowData.UpRate));
					}
					else
					{
						this.m_SuccessRateLab.gameObject.SetActive(false);
						this.m_AddRateLab.gameObject.SetActive(false);
						this.m_BreakRateLab.gameObject.SetActive(true);
						this.m_BreakRateLab.SetText(XStringDefineProxy.GetString("FullBreakRate"));
					}
				}
			}
		}

		private void FillEnhanceInfo()
		{
			this.m_BeforeAttrPool.ReturnAll(false);
			this.m_AfterAttrPool.ReturnAll(false);
			this.m_EnhanceGo.SetActive(true);
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				EnhanceTable.RowData enhanceRowData = this.m_doc.GetEnhanceRowData(xequipItem);
				List<EnhanceAttr> list = new List<EnhanceAttr>();
				bool isNeedBreak = this.m_doc.IsNeedBreak;
				if (isNeedBreak)
				{
					this.m_TittleLab.SetText(XStringDefineProxy.GetString("BreakCons"));
					this.m_EnhanceBtnLab.SetText(XStringDefineProxy.GetString("Break"));
					this.m_TipsLab.SetText(XStringDefineProxy.GetString("AfterBreakCanEnhance"));
					string @string = XStringDefineProxy.GetString("EnhanceLevel");
					list.Add(new EnhanceAttr(@string, xequipItem.enhanceInfo.EnhanceLevel, xequipItem.enhanceInfo.EnhanceLevel + 1U));
					list.AddRange(this.m_doc.EnhanceAttrLst);
				}
				else
				{
					this.m_TittleLab.SetText(XStringDefineProxy.GetString("EnhanceConsume"));
					this.m_EnhanceBtnLab.SetText(XStringDefineProxy.GetString("XSys_Item_Enhance"));
					this.m_TipsLab.SetText(XStringDefineProxy.GetString("EnhanceCanFullTrans"));
					list = this.m_doc.EnhanceAttrLst;
				}
				float num = (float)((list.Count - 1) * this.m_gap / 2);
				for (int i = 0; i < list.Count; i++)
				{
					GameObject gameObject = this.m_BeforeAttrPool.FetchGameObject(false);
					gameObject.name = i.ToString();
					gameObject.transform.parent = this.m_BeforeEnhanceGo.transform;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, num - (float)(this.m_gap * i), 0f);
					this.FillAttrWithName(gameObject, list[i]);
					gameObject = this.m_AfterAttrPool.FetchGameObject(false);
					gameObject.name = i.ToString();
					gameObject.transform.parent = this.m_AfterEnhanceGo.transform;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3(0f, num - (float)(this.m_gap * i), 0f);
					this.FillAttrNoName(gameObject, list[i]);
				}
				this.FillCostItem(enhanceRowData);
			}
		}

		private void FillMaxEnhanceInfo()
		{
			this.m_BeforeAttrPool.ReturnAll(false);
			this.m_EnhanceMaxGo.SetActive(true);
			float num = (float)((this.m_doc.EnhanceAttrLst.Count - 1) * this.m_gap / 2);
			for (int i = 0; i < this.m_doc.EnhanceAttrLst.Count; i++)
			{
				GameObject gameObject = this.m_BeforeAttrPool.FetchGameObject(false);
				gameObject.name = i.ToString();
				gameObject.transform.parent = this.m_MaxAttrListGo.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(0f, num - (float)(this.m_gap * i), 0f);
				this.FillAttrWithName(gameObject, this.m_doc.EnhanceAttrLst[i]);
			}
			this.m_TipsLab.SetText(XStringDefineProxy.GetString("EnhanceCanFullTrans"));
			XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
			bool flag = xequipItem == null;
			if (!flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(xequipItem.itemID);
				this.m_MaxTipsLab.SetText(XStringDefineProxy.GetString("CanEnhanceMaxLevel", new object[]
				{
					itemConf.ReqLevel,
					this.m_doc.GetMaxEnhanceLevel()
				}));
			}
		}

		private void FillAttrWithName(GameObject go, EnhanceAttr attr)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(attr.Name);
			ixuilabel = (go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(attr.BeforeAttrNum.ToString());
		}

		private void FillAttrNoName(GameObject go, EnhanceAttr attr)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(attr.AfterAttrNum.ToString());
			bool flag = attr.D_value == 0;
			if (flag)
			{
				go.transform.FindChild("Up").gameObject.SetActive(false);
				go.transform.FindChild("Down").gameObject.SetActive(false);
			}
			else
			{
				bool flag2 = attr.D_value > 0;
				if (flag2)
				{
					go.transform.FindChild("Down").gameObject.SetActive(false);
					ixuilabel = (go.transform.FindChild("Up").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format("[63ff85]{0}[-]", attr.D_value));
					ixuilabel.gameObject.SetActive(true);
				}
				else
				{
					go.transform.FindChild("Up").gameObject.SetActive(false);
					ixuilabel = (go.transform.FindChild("Down").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(string.Format("[ff3e3e]{0}[-]", -attr.D_value));
					ixuilabel.gameObject.SetActive(true);
				}
			}
		}

		private void FillCostItem(EnhanceTable.RowData rowData)
		{
			for (int i = 0; i < this.m_costItemTras.Count; i++)
			{
				bool flag = rowData.NeedItem.Count <= i;
				if (flag)
				{
					this.m_costItemTras[i].gameObject.SetActive(false);
				}
				else
				{
					this.m_costItemTras[i].gameObject.SetActive(true);
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)rowData.NeedItem[i, 0]);
					bool flag2 = itemConf != null;
					if (flag2)
					{
						IXUISprite ixuisprite = this.m_costItemTras[i].FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(itemConf.ItemIcon1[0]);
					}
					ulong itemCountByID = this.m_doc.GetItemCountByID(rowData.NeedItem[i, 0]);
					IXUILabel ixuilabel = this.m_costItemTras[i].GetComponent("XUILabel") as IXUILabel;
					bool flag3 = itemCountByID >= (ulong)rowData.NeedItem[i, 1];
					if (flag3)
					{
						ixuilabel.SetText(string.Format("{0}/{1}", XSingleton<UiUtility>.singleton.NumberFormat(itemCountByID), rowData.NeedItem[i, 1]));
					}
					else
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT"), XSingleton<UiUtility>.singleton.NumberFormat(itemCountByID), rowData.NeedItem[i, 1]));
					}
					IXUIButton ixuibutton = this.m_costItemTras[i].FindChild("LabBtn").GetComponent("XUIButton") as IXUIButton;
					bool flag4 = itemCountByID < (ulong)rowData.NeedItem[i, 1];
					if (flag4)
					{
						ixuibutton.gameObject.SetActive(true);
						ixuibutton.ID = (ulong)rowData.NeedItem[i, 0];
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetItemAccess));
					}
					else
					{
						ixuibutton.gameObject.SetActive(false);
					}
				}
			}
		}

		private void DelayPlayEffect(object o = null)
		{
			bool flag = this.m_doc.rpcState == XEnhanceRpcState.ERS_ENHANCESUCCEED;
			if (flag)
			{
				this.PlayEnhanceSucceedEffect();
			}
			else
			{
				bool flag2 = this.m_doc.rpcState == XEnhanceRpcState.ERS_BREAKSUCCEED;
				if (flag2)
				{
					this.PlayBreakSucceedEffect();
				}
				else
				{
					bool flag3 = this.m_doc.rpcState == XEnhanceRpcState.ERS_ENHANCEFAIED;
					if (flag3)
					{
						this.PlayEnhanceLostEffect();
					}
					else
					{
						this.FillContent();
						this.FillAttrUi();
					}
				}
			}
		}

		private void DelayRefresh(object o = null)
		{
			this.FillContent();
			this.FillAttrUi();
		}

		private bool _OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private bool OnGetItemAccess(IXUIButton btn)
		{
			int itemid = (int)btn.ID;
			this.DeActiveEffect();
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
			return true;
		}

		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id), null, iSp, false, 0U);
		}

		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		private bool OnEnhanceClicked(IXUIButton btn)
		{
			bool flag = !this.m_bIsCanClick;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.SetButtonCool(this.m_delayTime);
				if (flag2)
				{
					result = true;
				}
				else
				{
					XEquipItem xequipItem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.selectedEquip) as XEquipItem;
					bool flag3 = xequipItem == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = xequipItem.enhanceInfo.EnhanceLevel >= this.m_doc.GetMaxEnhanceLevel();
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnhanceMoreThanMax"), "fece00");
							result = true;
						}
						else
						{
							EnhanceTable.RowData enhanceRowData = this.m_doc.GetEnhanceRowData(xequipItem);
							bool flag5 = enhanceRowData != null;
							if (flag5)
							{
								for (int i = 0; i < enhanceRowData.NeedItem.Count; i++)
								{
									ulong itemCountByID = this.m_doc.GetItemCountByID(enhanceRowData.NeedItem[i, 0]);
									bool flag6 = itemCountByID < (ulong)enhanceRowData.NeedItem[i, 1];
									if (flag6)
									{
										XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_REINFORCE_LACKMONEY"), "fece00");
										return true;
									}
								}
							}
							else
							{
								XSingleton<XDebug>.singleton.AddErrorLog(xequipItem.itemID.ToString(), "is not find in enhanceTab", null, null, null, null);
							}
							this.m_doc.ReqEnhance();
							result = true;
						}
					}
				}
			}
			return result;
		}

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

		private XUIPool m_BeforeAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_AfterAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_Help;

		private IXUIButton m_CloseBtn;

		private IXUIButton m_EnhanceBtn;

		private IXUILabel m_SuccessRateLab;

		private IXUILabel m_AddRateLab;

		private IXUILabel m_TipsLab;

		private IXUILabel m_TittleLab;

		private IXUILabel m_EnhanceBtnLab;

		private IXUILabel m_MaxTipsLab;

		private IXUILabel m_BreakRateLab;

		private GameObject m_topItemGo;

		private GameObject m_EnhanceGo;

		private GameObject m_EnhanceMaxGo;

		private GameObject m_BeforeEnhanceGo;

		private GameObject m_AfterEnhanceGo;

		private GameObject m_MaxAttrListGo;

		private List<GameObject> m_effectGoList = new List<GameObject>();

		private Transform m_effectsTra;

		private XFx m_EnhanceSucceedEffect;

		private XFx m_BreakSucceedEffect;

		private XFx m_EnhanceLostEffect;

		private List<Transform> m_costItemTras;

		private uint m_token = 0U;

		private uint m_effectToken;

		private readonly int m_gap = 30;

		private bool m_bIsCanClick = true;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private string m_enhanceSucPath = string.Empty;

		private string m_breakSucPath = string.Empty;

		private string m_enhanceLostPath = string.Empty;
	}
}
