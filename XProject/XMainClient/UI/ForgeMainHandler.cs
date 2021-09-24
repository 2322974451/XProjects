using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ForgeMainHandler : DlgHandlerBase
	{

		public ForgeSuccessHandler ForgeSuccessHandler
		{
			get
			{
				return this.m_forgeSuccessHandler;
			}
		}

		public ForgeReplaceHandler ForgeReplaceHandler
		{
			get
			{
				return this.m_forgeReplaceHandler;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/ForgeMainHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XForgeDocument.Doc;
			this.m_doc.View = this;
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_detailBtn = (base.PanelObject.transform.FindChild("DetailBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_forgeBtn = (base.PanelObject.transform.FindChild("ForgeBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_helpBtn = (base.PanelObject.transform.FindChild("Tittle/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_attrGo = base.PanelObject.transform.FindChild("Attr").gameObject;
			this.m_popGo = base.PanelObject.transform.FindChild("Pop").gameObject;
			this.m_resultNewGo = base.PanelObject.transform.FindChild("ResultNew").gameObject;
			this.m_topItemGo = base.PanelObject.transform.FindChild("Top").gameObject;
			this.m_effectsTra = base.PanelObject.transform.FindChild("Effect");
			Transform transform = base.PanelObject.transform.FindChild("Special");
			this.m_checkBoxSpr = (transform.FindChild("Toggle").GetComponent("XUISprite") as IXUISprite);
			this.m_tipsLab = (transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel);
			this.m_redefinStoneGo = transform.FindChild("DaZaoShi").gameObject;
			transform = base.PanelObject.transform.FindChild("Result");
			this.m_refreshLab = (transform.FindChild("RefreshLab").GetComponent("XUILabel") as IXUILabel);
			this.m_rateLab = (transform.FindChild("RateLab").GetComponent("XUILabel") as IXUILabel);
			transform = transform.FindChild("AttrItem");
			this.m_attrValueLab = (transform.FindChild("NowValue").GetComponent("XUILabel") as IXUILabel);
			this.m_emptyLab = (transform.FindChild("Empty").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Bottom");
			this.m_tipsLab1 = (transform.FindChild("Tips1").GetComponent("XUILabel") as IXUILabel);
			transform = transform.FindChild("Items");
			this.m_needItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 2U, true);
			DlgHandlerBase.EnsureCreate<ForgeAttrPreViewHandler>(ref this.m_forgeAttrPreviewHandler, this.m_attrGo, null, false);
			DlgHandlerBase.EnsureCreate<ForgeSuccessHandler>(ref this.m_forgeSuccessHandler, this.m_popGo, null, false);
			DlgHandlerBase.EnsureCreate<ForgeReplaceHandler>(ref this.m_forgeReplaceHandler, this.m_resultNewGo, null, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_forgeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickForge));
			this.m_detailBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDetail));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_checkBoxSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickToggle));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			this.m_doc.Clear();
			this.DeActiveEffect();
			this.m_bIsPlayingEffect = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
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
			this.m_doc.View = null;
			bool flag = this.m_forgeAttrPreviewHandler != null;
			if (flag)
			{
				DlgHandlerBase.EnsureUnload<ForgeAttrPreViewHandler>(ref this.m_forgeAttrPreviewHandler);
				this.m_forgeAttrPreviewHandler = null;
			}
			bool flag2 = this.m_forgeSuccessHandler != null;
			if (flag2)
			{
				DlgHandlerBase.EnsureUnload<ForgeSuccessHandler>(ref this.m_forgeSuccessHandler);
				this.m_forgeSuccessHandler = null;
			}
			bool flag3 = this.m_forgeReplaceHandler != null;
			if (flag3)
			{
				DlgHandlerBase.EnsureUnload<ForgeReplaceHandler>(ref this.m_forgeReplaceHandler);
				this.m_forgeReplaceHandler = null;
			}
			bool flag4 = this.m_ForgeSucceedEffect != null;
			if (flag4)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ForgeSucceedEffect, true);
				this.m_ForgeSucceedEffect = null;
			}
			bool flag5 = this.m_ForgeLostEffect != null;
			if (flag5)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_ForgeLostEffect, true);
				this.m_ForgeLostEffect = null;
			}
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.DeActiveEffect();
			GameObject gameObject = this.m_checkBoxSpr.transform.FindChild("selected").gameObject;
			bool flag = !this.m_doc.IsUsedStone;
			if (flag)
			{
				this.m_checkBoxSpr.ID = 0UL;
				gameObject.SetActive(false);
			}
			else
			{
				this.m_checkBoxSpr.ID = 1UL;
				gameObject.SetActive(true);
			}
			bool flag2 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
			if (flag2)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.RegisterItemClickEvents(new SpriteClickEventHandler(this.OnEquipClicked));
			}
			this.FillContent();
		}

		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		public void ShowUI()
		{
			this.FillContent();
		}

		public void ShowEffect(bool isSucceed)
		{
			this.DeActiveEffect();
			if (isSucceed)
			{
				this.PlayForgeSucceedEffect();
			}
			else
			{
				this.PlayForgeLostEffect();
			}
		}

		public void ShowReplaceHandler()
		{
			bool flag = this.m_forgeReplaceHandler != null && !this.m_forgeReplaceHandler.IsVisible();
			if (flag)
			{
				this.m_forgeReplaceHandler.SetVisible(true);
			}
		}

		private void FillContent()
		{
			this.m_tipsLab1.SetText(XSingleton<XStringTable>.singleton.GetString("ForgeTips1"));
			this.m_emptyLab.SetText(XSingleton<XStringTable>.singleton.GetString("NoForgeAttr"));
			bool flag = this.m_doc.EquipRow == null;
			if (flag)
			{
				this.m_tipsLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ForgeTips"), this.m_doc.EquipRow.ForgeHighRate));
			}
			else
			{
				this.m_tipsLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ForgeTips"), 100));
			}
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
			bool flag2 = itemByUID == null;
			if (!flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_topItemGo, itemByUID);
				IXUISprite ixuisprite = this.m_topItemGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = this.m_doc.CurUid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedHadItemClicked));
				XEquipItem xequipItem = itemByUID as XEquipItem;
				this.FillAttribute(xequipItem);
				this.SetSelectStatus();
				this.RefreshOnSelectRedfinStone();
				this.FillNeedItem();
				bool flag3 = xequipItem.forgeAttrInfo.UnSavedAttrid != 0U && xequipItem.forgeAttrInfo.ForgeAttr.Count > 0;
				if (flag3)
				{
					this.ShowReplaceHandler();
				}
			}
		}

		private void FillAttribute(XEquipItem item)
		{
			bool flag = item.forgeAttrInfo.ForgeAttr.Count == 0;
			if (flag)
			{
				this.m_emptyLab.gameObject.SetActive(true);
				this.m_attrValueLab.gameObject.SetActive(false);
			}
			else
			{
				this.m_emptyLab.gameObject.SetActive(false);
				this.m_attrValueLab.gameObject.SetActive(true);
				EquipSlotAttrDatas attrData = XForgeDocument.ForgeAttrMgr.GetAttrData((uint)item.itemID);
				bool flag2 = attrData == null;
				if (!flag2)
				{
					string color = attrData.GetColor(1, item.forgeAttrInfo.ForgeAttr[0]);
					string arg = string.Format("[{0}]{1}[-]", color, XAttributeCommon.GetAttrStr((int)item.forgeAttrInfo.ForgeAttr[0].AttrID));
					string arg2 = string.Format("[{0}]{1}[-]", color, item.forgeAttrInfo.ForgeAttr[0].AttrValue);
					this.m_attrValueLab.SetText(string.Format("{0}  {1}", arg, arg2));
				}
			}
		}

		private void FillNeedItem()
		{
			bool flag = this.m_doc.EquipRow == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("m_doc.EquipRow is null", null, null, null, null, null);
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
				bool flag2 = itemByUID == null;
				if (!flag2)
				{
					this.m_needItemPool.ReturnAll(false);
					this.m_bMetailIsEnough = true;
					bool flag3 = (itemByUID as XEquipItem).forgeAttrInfo.ForgeAttr.Count == 0;
					SeqListRef<uint> seqListRef;
					if (flag3)
					{
						seqListRef = this.m_doc.EquipRow.ForgeNeedItem;
					}
					else
					{
						seqListRef = this.m_doc.EquipRow.ForgeNeedItemAfter;
					}
					for (int i = 0; i < (int)seqListRef.count; i++)
					{
						GameObject gameObject = this.m_needItemPool.FetchGameObject(false);
						gameObject.transform.localPosition = this.m_needItemPool.TplPos + new Vector3((float)(i * this.m_needItemPool.TplWidth), 0f, 0f);
						int num = (int)seqListRef[i, 0];
						int num2 = (int)seqListRef[i, 1];
						int num3 = (int)XBagDocument.BagDoc.GetItemCount(num);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num, num2, true);
						IXUILabel ixuilabel = gameObject.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.gameObject.SetActive(true);
						bool flag4 = num3 >= num2;
						if (flag4)
						{
							ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_ENOUGH_FMT"), num3, num2));
						}
						else
						{
							ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT"), num3, num2));
						}
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)num);
						bool flag5 = num2 > num3;
						if (flag5)
						{
							bool bMetailIsEnough = this.m_bMetailIsEnough;
							if (bMetailIsEnough)
							{
								this.m_lessItemId = num;
							}
							this.m_bMetailIsEnough = false;
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetItemAccess));
						}
						else
						{
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
						}
					}
				}
			}
		}

		private void SetSelectStatus()
		{
			bool isSelect = this.m_doc.IsSelect;
			if (!isSelect)
			{
				bool flag = this.m_doc.EquipRow == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("m_doc.EquipRow is null", null, null, null, null, null);
				}
				else
				{
					XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
					bool flag2 = itemByUID == null;
					if (!flag2)
					{
						int count = (itemByUID as XEquipItem).forgeAttrInfo.ForgeAttr.Count;
						bool flag3 = count == 0;
						SeqRef<uint> seqRef;
						if (flag3)
						{
							seqRef = this.m_doc.EquipRow.ForgeSpecialItem;
						}
						else
						{
							seqRef = this.m_doc.EquipRow.ForgeSpecialItemAfter;
						}
						int itemid = (int)seqRef[0];
						int num = (int)seqRef[1];
						int num2 = (int)XBagDocument.BagDoc.GetItemCount(itemid);
						bool flag4 = num2 < num;
						if (flag4)
						{
							this.m_doc.IsUsedStone = false;
							this.m_checkBoxSpr.ID = 0UL;
						}
						else
						{
							this.m_doc.IsUsedStone = true;
							this.m_checkBoxSpr.ID = 1UL;
							this.m_doc.IsSelect = true;
						}
					}
				}
			}
		}

		private void RefreshOnSelectRedfinStone()
		{
			bool flag = this.m_doc.EquipRow == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("m_doc.EquipRow is null", null, null, null, null, null);
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.CurUid);
				bool flag2 = itemByUID == null;
				if (!flag2)
				{
					int count = (itemByUID as XEquipItem).forgeAttrInfo.ForgeAttr.Count;
					bool flag3 = count == 0;
					SeqRef<uint> seqRef;
					uint num;
					uint num2;
					if (flag3)
					{
						seqRef = this.m_doc.EquipRow.ForgeSpecialItem;
						num = (uint)this.m_doc.EquipRow.ForgeLowRate;
						num2 = (uint)this.m_doc.EquipRow.ForgeHighRate;
					}
					else
					{
						seqRef = this.m_doc.EquipRow.ForgeSpecialItemAfter;
						num = (uint)this.m_doc.EquipRow.ForgeLowRateAfter;
						num2 = (uint)this.m_doc.EquipRow.ForgeHighRateAfter;
					}
					int num3 = (int)seqRef[0];
					int num4 = (int)seqRef[1];
					int num5 = (int)XBagDocument.BagDoc.GetItemCount(num3);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_redefinStoneGo, num3, num4, true);
					IXUILabel ixuilabel = this.m_redefinStoneGo.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.gameObject.SetActive(true);
					bool flag4 = num5 >= num4;
					if (flag4)
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_ENOUGH_FMT"), num5, num4));
					}
					else
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT"), num5, num4));
					}
					IXUISprite ixuisprite = this.m_redefinStoneGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetGrey(this.m_doc.IsUsedStone);
					IXUISprite ixuisprite2 = this.m_redefinStoneGo.transform.FindChild("Quality").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.SetGrey(this.m_doc.IsUsedStone);
					GameObject gameObject = this.m_checkBoxSpr.transform.FindChild("selected").gameObject;
					gameObject.SetActive(this.m_doc.IsUsedStone);
					ixuisprite.ID = (ulong)((long)num3);
					bool flag5 = num5 < num4;
					if (flag5)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetItemAccess));
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.SelectReDefineStone));
					}
					this.m_lessStoneId = num3;
					this.m_bStoneIsEnough = (num5 >= num4);
					bool flag6 = !this.m_doc.IsUsedStone;
					int num6;
					if (flag6)
					{
						this.m_bStoneIsEnough = true;
						num6 = (int)(100U - num);
						bool flag7 = count != 0;
						if (flag7)
						{
							this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("RefreshForgeOriAttr"), XSingleton<XCommon>.singleton.StringCombine(num.ToString(), "%")));
						}
						else
						{
							this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ActivityForgeOriAttr"), XSingleton<XCommon>.singleton.StringCombine(num.ToString(), "%")));
						}
					}
					else
					{
						num6 = (int)(100U - num2);
						bool flag8 = count != 0;
						if (flag8)
						{
							this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("RefreshForgeOriAttrFull"), XSingleton<XCommon>.singleton.StringCombine(num2.ToString(), "%")));
						}
						else
						{
							this.m_rateLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ActivityForgeOriAttrFull"), XSingleton<XCommon>.singleton.StringCombine(num2.ToString(), "%")));
						}
					}
					bool flag9 = num6 > 0 && count != 0;
					if (flag9)
					{
						this.m_refreshLab.gameObject.SetActive(true);
						this.m_refreshLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("SaveForgeOriAttr"), num6));
					}
					else
					{
						this.m_refreshLab.gameObject.SetActive(false);
					}
				}
			}
		}

		public string ForgeSucPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_forgeSucPath);
				if (flag)
				{
					this.m_forgeSucPath = XSingleton<XGlobalConfig>.singleton.GetValue("ForgeSucEffectPath");
				}
				return this.m_forgeSucPath;
			}
		}

		private void PlayForgeSucceedEffect()
		{
			bool flag = this.m_ForgeSucceedEffect == null;
			if (flag)
			{
				this.m_ForgeSucceedEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.ForgeSucPath, null, true);
			}
			else
			{
				this.m_ForgeSucceedEffect.SetActive(true);
			}
			this.m_ForgeSucceedEffect.Play(this.m_effectsTra, Vector3.zero, Vector3.one, 1f, true, false);
			this.m_bIsPlayingEffect = true;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_effectToken);
			this.m_effectToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.DelayShowTipsUI), null);
		}

		private void DelayShowTipsUI(object o = null)
		{
			this.m_bIsPlayingEffect = false;
		}

		public string ForgeLostPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_forgeLostPath);
				if (flag)
				{
					this.m_forgeLostPath = XSingleton<XGlobalConfig>.singleton.GetValue("ForgeLostEffectPath");
				}
				return this.m_forgeLostPath;
			}
		}

		private void PlayForgeLostEffect()
		{
			bool flag = this.m_ForgeLostEffect == null;
			if (flag)
			{
				this.m_ForgeLostEffect = XSingleton<XFxMgr>.singleton.CreateFx(this.ForgeLostPath, null, true);
			}
			else
			{
				this.m_ForgeLostEffect.SetActive(true);
			}
			this.m_ForgeLostEffect.Play(this.m_effectsTra, Vector3.zero, Vector3.one, 1f, true, false);
		}

		private void DeActiveEffect()
		{
			bool flag = this.m_ForgeSucceedEffect != null;
			if (flag)
			{
				this.m_ForgeSucceedEffect.SetActive(false);
			}
			bool flag2 = this.m_ForgeLostEffect != null;
			if (flag2)
			{
				this.m_ForgeLostEffect.SetActive(false);
			}
		}

		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		private bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Forge);
			return true;
		}

		private bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private bool OnClickForge(IXUIButton btn)
		{
			bool bIsPlayingEffect = this.m_bIsPlayingEffect;
			bool result;
			if (bIsPlayingEffect)
			{
				result = true;
			}
			else
			{
				bool flag = this.SetButtonCool(this.m_delayTime);
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = !this.m_bStoneIsEnough;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("RedefineStoneNotEnough"), "fece00");
						XSingleton<UiUtility>.singleton.ShowItemAccess(this.m_lessStoneId, null);
						result = true;
					}
					else
					{
						bool flag3 = !this.m_bMetailIsEnough;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FoodNotEnough"), "fece00");
							XSingleton<UiUtility>.singleton.ShowItemAccess(this.m_lessItemId, null);
							result = true;
						}
						else
						{
							this.m_doc.ReqForgeEquip(ForgeOpType.Forge_Equip);
							result = true;
						}
					}
				}
			}
			return result;
		}

		private bool OnClickDetail(IXUIButton btn)
		{
			bool bIsPlayingEffect = this.m_bIsPlayingEffect;
			bool result;
			if (bIsPlayingEffect)
			{
				result = true;
			}
			else
			{
				bool flag = this.SetButtonCool(this.m_delayTime);
				if (flag)
				{
					result = true;
				}
				else
				{
					bool flag2 = this.m_forgeAttrPreviewHandler != null;
					if (flag2)
					{
						this.m_forgeAttrPreviewHandler.SetVisible(true);
					}
					result = true;
				}
			}
			return result;
		}

		private void OnClickToggle(IXUISprite spr)
		{
			GameObject gameObject = spr.transform.FindChild("selected").gameObject;
			bool flag = spr.ID == 0UL;
			if (flag)
			{
				spr.ID = 1UL;
				gameObject.SetActive(true);
				this.m_doc.IsUsedStone = true;
			}
			else
			{
				spr.ID = 0UL;
				gameObject.SetActive(false);
				this.m_doc.IsUsedStone = false;
			}
			this.RefreshOnSelectRedfinStone();
		}

		private void OnGetItemAccess(IXUISprite iSp)
		{
			this.DeActiveEffect();
			int itemid = (int)iSp.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
		}

		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)iSp.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, iSp, false, 0U);
		}

		private void SelectReDefineStone(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.OnItemClick(iSp);
			DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ItemSelector.Hide();
		}

		private void OnSelectedHadItemClicked(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id), null, iSp, false, 0U);
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

		private XForgeDocument m_doc;

		private bool m_bIsPlayingEffect = false;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private uint m_effectToken = 0U;

		private bool m_bStoneIsEnough = false;

		private bool m_bMetailIsEnough = false;

		private XFx m_ForgeSucceedEffect;

		private XFx m_ForgeLostEffect;

		private IXUIButton m_closeBtn;

		private IXUIButton m_detailBtn;

		private IXUIButton m_forgeBtn;

		private IXUIButton m_helpBtn;

		private IXUISprite m_checkBoxSpr;

		private IXUILabel m_rateLab;

		private IXUILabel m_attrValueLab;

		private IXUILabel m_tipsLab;

		private IXUILabel m_tipsLab1;

		private IXUILabel m_emptyLab;

		private IXUILabel m_refreshLab;

		private GameObject m_attrGo;

		private GameObject m_popGo;

		private GameObject m_resultNewGo;

		private GameObject m_topItemGo;

		private GameObject m_redefinStoneGo;

		private Transform m_effectsTra;

		private XUIPool m_needItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private ForgeAttrPreViewHandler m_forgeAttrPreviewHandler;

		private ForgeSuccessHandler m_forgeSuccessHandler;

		private ForgeReplaceHandler m_forgeReplaceHandler;

		private int m_lessItemId = 0;

		private int m_lessStoneId = 0;

		private string m_forgeSucPath = string.Empty;

		private string m_forgeLostPath = string.Empty;
	}
}
