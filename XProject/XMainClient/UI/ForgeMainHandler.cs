using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200173C RID: 5948
	internal class ForgeMainHandler : DlgHandlerBase
	{
		// Token: 0x170037D7 RID: 14295
		// (get) Token: 0x0600F5C4 RID: 62916 RVA: 0x00378E08 File Offset: 0x00377008
		public ForgeSuccessHandler ForgeSuccessHandler
		{
			get
			{
				return this.m_forgeSuccessHandler;
			}
		}

		// Token: 0x170037D8 RID: 14296
		// (get) Token: 0x0600F5C5 RID: 62917 RVA: 0x00378E20 File Offset: 0x00377020
		public ForgeReplaceHandler ForgeReplaceHandler
		{
			get
			{
				return this.m_forgeReplaceHandler;
			}
		}

		// Token: 0x170037D9 RID: 14297
		// (get) Token: 0x0600F5C6 RID: 62918 RVA: 0x00378E38 File Offset: 0x00377038
		protected override string FileName
		{
			get
			{
				return "ItemNew/ForgeMainHandler";
			}
		}

		// Token: 0x0600F5C7 RID: 62919 RVA: 0x00378E50 File Offset: 0x00377050
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

		// Token: 0x0600F5C8 RID: 62920 RVA: 0x00379170 File Offset: 0x00377370
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_forgeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickForge));
			this.m_detailBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDetail));
			this.m_helpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_checkBoxSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickToggle));
		}

		// Token: 0x0600F5C9 RID: 62921 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x0600F5CA RID: 62922 RVA: 0x00379200 File Offset: 0x00377400
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

		// Token: 0x0600F5CB RID: 62923 RVA: 0x00379290 File Offset: 0x00377490
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

		// Token: 0x0600F5CC RID: 62924 RVA: 0x0037936C File Offset: 0x0037756C
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

		// Token: 0x0600F5CD RID: 62925 RVA: 0x00358051 File Offset: 0x00356251
		public override void StackRefresh()
		{
			this.RefreshData();
			base.StackRefresh();
		}

		// Token: 0x0600F5CE RID: 62926 RVA: 0x0037941B File Offset: 0x0037761B
		public void ShowUI()
		{
			this.FillContent();
		}

		// Token: 0x0600F5CF RID: 62927 RVA: 0x00379428 File Offset: 0x00377628
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

		// Token: 0x0600F5D0 RID: 62928 RVA: 0x00379454 File Offset: 0x00377654
		public void ShowReplaceHandler()
		{
			bool flag = this.m_forgeReplaceHandler != null && !this.m_forgeReplaceHandler.IsVisible();
			if (flag)
			{
				this.m_forgeReplaceHandler.SetVisible(true);
			}
		}

		// Token: 0x0600F5D1 RID: 62929 RVA: 0x0037948C File Offset: 0x0037768C
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

		// Token: 0x0600F5D2 RID: 62930 RVA: 0x00379618 File Offset: 0x00377818
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

		// Token: 0x0600F5D3 RID: 62931 RVA: 0x0037972C File Offset: 0x0037792C
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

		// Token: 0x0600F5D4 RID: 62932 RVA: 0x00379998 File Offset: 0x00377B98
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

		// Token: 0x0600F5D5 RID: 62933 RVA: 0x00379AC8 File Offset: 0x00377CC8
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

		// Token: 0x170037DA RID: 14298
		// (get) Token: 0x0600F5D6 RID: 62934 RVA: 0x00379F10 File Offset: 0x00378110
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

		// Token: 0x0600F5D7 RID: 62935 RVA: 0x00379F4C File Offset: 0x0037814C
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

		// Token: 0x0600F5D8 RID: 62936 RVA: 0x00379FED File Offset: 0x003781ED
		private void DelayShowTipsUI(object o = null)
		{
			this.m_bIsPlayingEffect = false;
		}

		// Token: 0x170037DB RID: 14299
		// (get) Token: 0x0600F5D9 RID: 62937 RVA: 0x00379FF8 File Offset: 0x003781F8
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

		// Token: 0x0600F5DA RID: 62938 RVA: 0x0037A034 File Offset: 0x00378234
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

		// Token: 0x0600F5DB RID: 62939 RVA: 0x0037A09C File Offset: 0x0037829C
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

		// Token: 0x0600F5DC RID: 62940 RVA: 0x0037A0DE File Offset: 0x003782DE
		public void OnEquipClicked(IXUISprite iSp)
		{
			this.m_doc.SelectEquip(iSp.ID);
		}

		// Token: 0x0600F5DD RID: 62941 RVA: 0x0037A0F4 File Offset: 0x003782F4
		private bool OnHelpClicked(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Item_Forge);
			return true;
		}

		// Token: 0x0600F5DE RID: 62942 RVA: 0x0037A118 File Offset: 0x00378318
		private bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600F5DF RID: 62943 RVA: 0x0037A134 File Offset: 0x00378334
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

		// Token: 0x0600F5E0 RID: 62944 RVA: 0x0037A204 File Offset: 0x00378404
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

		// Token: 0x0600F5E1 RID: 62945 RVA: 0x0037A254 File Offset: 0x00378454
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

		// Token: 0x0600F5E2 RID: 62946 RVA: 0x0037A2D0 File Offset: 0x003784D0
		private void OnGetItemAccess(IXUISprite iSp)
		{
			this.DeActiveEffect();
			int itemid = (int)iSp.ID;
			XSingleton<UiUtility>.singleton.ShowItemAccess(itemid, null);
		}

		// Token: 0x0600F5E3 RID: 62947 RVA: 0x0037A2FC File Offset: 0x003784FC
		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)iSp.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, iSp, false, 0U);
		}

		// Token: 0x0600F5E4 RID: 62948 RVA: 0x0037A327 File Offset: 0x00378527
		private void SelectReDefineStone(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.OnItemClick(iSp);
			DlgBase<ItemTooltipDlg, ItemTooltipDlgBehaviour>.singleton.ItemSelector.Hide();
		}

		// Token: 0x0600F5E5 RID: 62949 RVA: 0x0037A348 File Offset: 0x00378548
		private void OnSelectedHadItemClicked(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id), null, iSp, false, 0U);
		}

		// Token: 0x0600F5E6 RID: 62950 RVA: 0x0037A384 File Offset: 0x00378584
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

		// Token: 0x04006A79 RID: 27257
		private XForgeDocument m_doc;

		// Token: 0x04006A7A RID: 27258
		private bool m_bIsPlayingEffect = false;

		// Token: 0x04006A7B RID: 27259
		private float m_delayTime = 0.5f;

		// Token: 0x04006A7C RID: 27260
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04006A7D RID: 27261
		private uint m_effectToken = 0U;

		// Token: 0x04006A7E RID: 27262
		private bool m_bStoneIsEnough = false;

		// Token: 0x04006A7F RID: 27263
		private bool m_bMetailIsEnough = false;

		// Token: 0x04006A80 RID: 27264
		private XFx m_ForgeSucceedEffect;

		// Token: 0x04006A81 RID: 27265
		private XFx m_ForgeLostEffect;

		// Token: 0x04006A82 RID: 27266
		private IXUIButton m_closeBtn;

		// Token: 0x04006A83 RID: 27267
		private IXUIButton m_detailBtn;

		// Token: 0x04006A84 RID: 27268
		private IXUIButton m_forgeBtn;

		// Token: 0x04006A85 RID: 27269
		private IXUIButton m_helpBtn;

		// Token: 0x04006A86 RID: 27270
		private IXUISprite m_checkBoxSpr;

		// Token: 0x04006A87 RID: 27271
		private IXUILabel m_rateLab;

		// Token: 0x04006A88 RID: 27272
		private IXUILabel m_attrValueLab;

		// Token: 0x04006A89 RID: 27273
		private IXUILabel m_tipsLab;

		// Token: 0x04006A8A RID: 27274
		private IXUILabel m_tipsLab1;

		// Token: 0x04006A8B RID: 27275
		private IXUILabel m_emptyLab;

		// Token: 0x04006A8C RID: 27276
		private IXUILabel m_refreshLab;

		// Token: 0x04006A8D RID: 27277
		private GameObject m_attrGo;

		// Token: 0x04006A8E RID: 27278
		private GameObject m_popGo;

		// Token: 0x04006A8F RID: 27279
		private GameObject m_resultNewGo;

		// Token: 0x04006A90 RID: 27280
		private GameObject m_topItemGo;

		// Token: 0x04006A91 RID: 27281
		private GameObject m_redefinStoneGo;

		// Token: 0x04006A92 RID: 27282
		private Transform m_effectsTra;

		// Token: 0x04006A93 RID: 27283
		private XUIPool m_needItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006A94 RID: 27284
		private ForgeAttrPreViewHandler m_forgeAttrPreviewHandler;

		// Token: 0x04006A95 RID: 27285
		private ForgeSuccessHandler m_forgeSuccessHandler;

		// Token: 0x04006A96 RID: 27286
		private ForgeReplaceHandler m_forgeReplaceHandler;

		// Token: 0x04006A97 RID: 27287
		private int m_lessItemId = 0;

		// Token: 0x04006A98 RID: 27288
		private int m_lessStoneId = 0;

		// Token: 0x04006A99 RID: 27289
		private string m_forgeSucPath = string.Empty;

		// Token: 0x04006A9A RID: 27290
		private string m_forgeLostPath = string.Empty;
	}
}
