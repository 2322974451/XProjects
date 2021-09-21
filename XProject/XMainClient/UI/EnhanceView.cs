using System;
using System.Collections.Generic;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200190F RID: 6415
	internal class EnhanceView : DlgHandlerBase
	{
		// Token: 0x17003AD3 RID: 15059
		// (get) Token: 0x06010C40 RID: 68672 RVA: 0x004340FC File Offset: 0x004322FC
		private XEnhanceDocument m_doc
		{
			get
			{
				return XEnhanceDocument.Doc;
			}
		}

		// Token: 0x17003AD4 RID: 15060
		// (get) Token: 0x06010C41 RID: 68673 RVA: 0x00434114 File Offset: 0x00432314
		protected override string FileName
		{
			get
			{
				return "ItemNew/EnhanceFrame";
			}
		}

		// Token: 0x06010C42 RID: 68674 RVA: 0x0043412C File Offset: 0x0043232C
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

		// Token: 0x06010C43 RID: 68675 RVA: 0x00434448 File Offset: 0x00432648
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseClicked));
			this.m_EnhanceBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnhanceClicked));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x06010C44 RID: 68676 RVA: 0x004344A8 File Offset: 0x004326A8
		public bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Enhance);
			return true;
		}

		// Token: 0x06010C45 RID: 68677 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x06010C46 RID: 68678 RVA: 0x00358051 File Offset: 0x00356251
		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		// Token: 0x06010C47 RID: 68679 RVA: 0x004344C8 File Offset: 0x004326C8
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

		// Token: 0x06010C48 RID: 68680 RVA: 0x00434570 File Offset: 0x00432770
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

		// Token: 0x06010C49 RID: 68681 RVA: 0x0043460C File Offset: 0x0043280C
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

		// Token: 0x06010C4A RID: 68682 RVA: 0x00434698 File Offset: 0x00432898
		public void ChangeEquip()
		{
			this.DeActiveEffect();
			this.FillContent();
			this.m_doc.ReqEnhanceAttr();
		}

		// Token: 0x06010C4B RID: 68683 RVA: 0x00434698 File Offset: 0x00432898
		public void RefreshPage()
		{
			this.DeActiveEffect();
			this.FillContent();
			this.m_doc.ReqEnhanceAttr();
		}

		// Token: 0x06010C4C RID: 68684 RVA: 0x004346B8 File Offset: 0x004328B8
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

		// Token: 0x06010C4D RID: 68685 RVA: 0x00434858 File Offset: 0x00432A58
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

		// Token: 0x17003AD5 RID: 15061
		// (get) Token: 0x06010C4E RID: 68686 RVA: 0x004348D4 File Offset: 0x00432AD4
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

		// Token: 0x17003AD6 RID: 15062
		// (get) Token: 0x06010C4F RID: 68687 RVA: 0x00434910 File Offset: 0x00432B10
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

		// Token: 0x17003AD7 RID: 15063
		// (get) Token: 0x06010C50 RID: 68688 RVA: 0x0043494C File Offset: 0x00432B4C
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

		// Token: 0x06010C51 RID: 68689 RVA: 0x00434988 File Offset: 0x00432B88
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

		// Token: 0x06010C52 RID: 68690 RVA: 0x00434A24 File Offset: 0x00432C24
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

		// Token: 0x06010C53 RID: 68691 RVA: 0x00434AC0 File Offset: 0x00432CC0
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

		// Token: 0x06010C54 RID: 68692 RVA: 0x00434B5C File Offset: 0x00432D5C
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

		// Token: 0x06010C55 RID: 68693 RVA: 0x00434BC0 File Offset: 0x00432DC0
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

		// Token: 0x06010C56 RID: 68694 RVA: 0x00434C40 File Offset: 0x00432E40
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

		// Token: 0x06010C57 RID: 68695 RVA: 0x00434E84 File Offset: 0x00433084
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

		// Token: 0x06010C58 RID: 68696 RVA: 0x0043511C File Offset: 0x0043331C
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

		// Token: 0x06010C59 RID: 68697 RVA: 0x00435298 File Offset: 0x00433498
		private void FillAttrWithName(GameObject go, EnhanceAttr attr)
		{
			IXUILabel ixuilabel = go.transform.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(attr.Name);
			ixuilabel = (go.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(attr.BeforeAttrNum.ToString());
		}

		// Token: 0x06010C5A RID: 68698 RVA: 0x00435300 File Offset: 0x00433500
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

		// Token: 0x06010C5B RID: 68699 RVA: 0x00435464 File Offset: 0x00433664
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

		// Token: 0x06010C5C RID: 68700 RVA: 0x00435684 File Offset: 0x00433884
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

		// Token: 0x06010C5D RID: 68701 RVA: 0x004356F9 File Offset: 0x004338F9
		private void DelayRefresh(object o = null)
		{
			this.FillContent();
			this.FillAttrUi();
		}

		// Token: 0x06010C5E RID: 68702 RVA: 0x0043570C File Offset: 0x0043390C
		private bool _OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x06010C5F RID: 68703 RVA: 0x00435728 File Offset: 0x00433928
		private bool OnGetItemAccess(IXUIButton btn)
		{
			int itemid = (int)btn.ID;
			this.DeActiveEffect();
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
			return true;
		}

		// Token: 0x06010C60 RID: 68704 RVA: 0x00435758 File Offset: 0x00433958
		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id), null, iSp, false, 0U);
		}

		// Token: 0x06010C61 RID: 68705 RVA: 0x00435791 File Offset: 0x00433991
		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		// Token: 0x06010C62 RID: 68706 RVA: 0x004357A8 File Offset: 0x004339A8
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

		// Token: 0x06010C63 RID: 68707 RVA: 0x0043591C File Offset: 0x00433B1C
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

		// Token: 0x04007AD0 RID: 31440
		private XUIPool m_BeforeAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007AD1 RID: 31441
		private XUIPool m_AfterAttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007AD2 RID: 31442
		private IXUIButton m_Help;

		// Token: 0x04007AD3 RID: 31443
		private IXUIButton m_CloseBtn;

		// Token: 0x04007AD4 RID: 31444
		private IXUIButton m_EnhanceBtn;

		// Token: 0x04007AD5 RID: 31445
		private IXUILabel m_SuccessRateLab;

		// Token: 0x04007AD6 RID: 31446
		private IXUILabel m_AddRateLab;

		// Token: 0x04007AD7 RID: 31447
		private IXUILabel m_TipsLab;

		// Token: 0x04007AD8 RID: 31448
		private IXUILabel m_TittleLab;

		// Token: 0x04007AD9 RID: 31449
		private IXUILabel m_EnhanceBtnLab;

		// Token: 0x04007ADA RID: 31450
		private IXUILabel m_MaxTipsLab;

		// Token: 0x04007ADB RID: 31451
		private IXUILabel m_BreakRateLab;

		// Token: 0x04007ADC RID: 31452
		private GameObject m_topItemGo;

		// Token: 0x04007ADD RID: 31453
		private GameObject m_EnhanceGo;

		// Token: 0x04007ADE RID: 31454
		private GameObject m_EnhanceMaxGo;

		// Token: 0x04007ADF RID: 31455
		private GameObject m_BeforeEnhanceGo;

		// Token: 0x04007AE0 RID: 31456
		private GameObject m_AfterEnhanceGo;

		// Token: 0x04007AE1 RID: 31457
		private GameObject m_MaxAttrListGo;

		// Token: 0x04007AE2 RID: 31458
		private List<GameObject> m_effectGoList = new List<GameObject>();

		// Token: 0x04007AE3 RID: 31459
		private Transform m_effectsTra;

		// Token: 0x04007AE4 RID: 31460
		private XFx m_EnhanceSucceedEffect;

		// Token: 0x04007AE5 RID: 31461
		private XFx m_BreakSucceedEffect;

		// Token: 0x04007AE6 RID: 31462
		private XFx m_EnhanceLostEffect;

		// Token: 0x04007AE7 RID: 31463
		private List<Transform> m_costItemTras;

		// Token: 0x04007AE8 RID: 31464
		private uint m_token = 0U;

		// Token: 0x04007AE9 RID: 31465
		private uint m_effectToken;

		// Token: 0x04007AEA RID: 31466
		private readonly int m_gap = 30;

		// Token: 0x04007AEB RID: 31467
		private bool m_bIsCanClick = true;

		// Token: 0x04007AEC RID: 31468
		private float m_delayTime = 0.5f;

		// Token: 0x04007AED RID: 31469
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04007AEE RID: 31470
		private string m_enhanceSucPath = string.Empty;

		// Token: 0x04007AEF RID: 31471
		private string m_breakSucPath = string.Empty;

		// Token: 0x04007AF0 RID: 31472
		private string m_enhanceLostPath = string.Empty;
	}
}
