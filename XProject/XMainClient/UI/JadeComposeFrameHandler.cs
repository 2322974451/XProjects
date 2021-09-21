using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017C2 RID: 6082
	internal class JadeComposeFrameHandler : DlgHandlerBase
	{
		// Token: 0x1700388B RID: 14475
		// (get) Token: 0x0600FBD2 RID: 64466 RVA: 0x003A8BBC File Offset: 0x003A6DBC
		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeComposeFrame";
			}
		}

		// Token: 0x0600FBD3 RID: 64467 RVA: 0x003A8BD4 File Offset: 0x003A6DD4
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
			this.m_closedBtn = (base.PanelObject.transform.FindChild("ComposeMenu/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_composeBtn = (base.PanelObject.transform.FindChild("ComposeMenu/BtnCompose").GetComponent("XUIButton") as IXUIButton);
			this.m_reduceBtn = (base.PanelObject.transform.FindChild("ComposeMenu/minus1").GetComponent("XUIButton") as IXUIButton);
			this.m_addBtn = (base.PanelObject.transform.FindChild("ComposeMenu/add1").GetComponent("XUIButton") as IXUIButton);
			this.m_costLab = (base.PanelObject.transform.FindChild("ComposeMenu/Cost").GetComponent("XUILabel") as IXUILabel);
			this.m_costMallLab = (base.PanelObject.transform.FindChild("ComposeMenu/CostMall").GetComponent("XUILabel") as IXUILabel);
			this.m_lackJadTipsLab = (base.PanelObject.transform.FindChild("ComposeMenu/CostJade/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_sourceJade = base.PanelObject.transform.FindChild("ComposeMenu/SourceJade/JadeTpl").gameObject;
			this.m_targetJade = base.PanelObject.transform.FindChild("ComposeMenu/TargetJade/JadeTpl").gameObject;
			this.m_effectParentTra = base.PanelObject.transform.FindChild("ComposeMenu/Effect");
			Transform transform = base.PanelObject.transform.FindChild("ComposeMenu/CostJade");
			this.m_hadShopPos = transform.FindChild("Pos1/Panel").gameObject;
			this.m_noShopPos = transform.FindChild("Pos2/Panel").gameObject;
			this.m_shopPos = transform.FindChild("Shop").gameObject;
			this.m_jadeTplPool1.SetupPool(transform.gameObject, transform.FindChild("Pos1/Panel/JadeTpl1").gameObject, 1U, false);
			this.m_jadeTplPool2.SetupPool(transform.gameObject, transform.FindChild("Pos2/Panel/JadeTpl2").gameObject, 1U, false);
		}

		// Token: 0x0600FBD4 RID: 64468 RVA: 0x003A8E1C File Offset: 0x003A701C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			this.m_composeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickComposed));
			this.m_reduceBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickReduceBtn));
			this.m_addBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBtn));
		}

		// Token: 0x0600FBD5 RID: 64469 RVA: 0x003A8E91 File Offset: 0x003A7091
		protected override void OnShow()
		{
			base.OnShow();
			this.m_effectIsEnd = true;
			this.m_isNeedPlayEffect = false;
			this.FillContent();
		}

		// Token: 0x0600FBD6 RID: 64470 RVA: 0x003A8EB0 File Offset: 0x003A70B0
		protected override void OnHide()
		{
			this.m_jadeTplPool1.ReturnAll(true);
			this.m_jadeTplPool2.ReturnAll(true);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			this.m_effectIsEnd = true;
			base.OnHide();
		}

		// Token: 0x0600FBD7 RID: 64471 RVA: 0x003A8F20 File Offset: 0x003A7120
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_effectIsEnd = true;
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
		}

		// Token: 0x0600FBD8 RID: 64472 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x0600FBD9 RID: 64473 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FBDA RID: 64474 RVA: 0x003A8F64 File Offset: 0x003A7164
		public void ShowUi(int type, uint sourceItemId, uint curJadeLevel, ulong uid = 0UL)
		{
			this.m_type = type;
			this.m_itemId = sourceItemId;
			this.m_curLevel = curJadeLevel;
			this.m_jadeUid = uid;
			this.m_addLevel = 1U;
			this.m_isNeedPlayEffect = true;
			bool flag = base.IsVisible();
			if (flag)
			{
				this.FillContent();
			}
			else
			{
				base.SetVisible(true);
			}
		}

		// Token: 0x0600FBDB RID: 64475 RVA: 0x003A8FB8 File Offset: 0x003A71B8
		private void FillContent()
		{
			bool isNeedPlayEffect = this.m_isNeedPlayEffect;
			if (isNeedPlayEffect)
			{
				this.PlayEffect();
				this.m_isNeedPlayEffect = false;
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_sourceJade, (int)this.m_itemId, 1, false);
				IXUISprite ixuisprite = this.m_sourceJade.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this.m_itemId;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
				this.FillChangedItem();
			}
		}

		// Token: 0x0600FBDC RID: 64476 RVA: 0x003A9050 File Offset: 0x003A7250
		private void FillChangedItem()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				int num = this.m_doc.JadeLevelToMosaicLevel(this.m_curLevel + this.m_addLevel);
				bool flag2 = num == -1 || (long)num > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				if (flag2)
				{
					this.m_addLevel = 0U;
				}
				uint targetItemId = this.m_doc.GetTargetItemId(this.m_itemId, this.m_addLevel);
				this.m_doc.TargetItemId = targetItemId;
				bool flag3 = targetItemId == 0U;
				if (!flag3)
				{
					XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_targetJade, (int)targetItemId, 1, false);
					IXUISprite ixuisprite = this.m_targetJade.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)targetItemId;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
					List<XTuple<uint, uint>> list;
					XTuple<uint, uint> xtuple;
					bool needItems = this.m_doc.GetNeedItems(targetItemId, this.m_itemId, this.m_type, out list, out xtuple, out this.m_needGold, out this.m_needMall);
					ulong virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
					bool flag4 = this.m_needGold > virtualItemCount;
					if (flag4)
					{
						this.m_costLab.SetText(string.Format("[ff0000]{0}[-]", this.m_needGold));
					}
					else
					{
						this.m_costLab.SetText(this.m_needGold.ToString());
					}
					this.m_jadeTplPool1.ReturnAll(true);
					this.m_jadeTplPool2.ReturnAll(true);
					bool flag5 = needItems;
					GameObject gameObject2;
					if (flag5)
					{
						this.m_costMallLab.gameObject.SetActive(true);
						this.m_lackJadTipsLab.gameObject.SetActive(true);
						virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
						bool flag6 = (ulong)this.m_needMall > virtualItemCount;
						if (flag6)
						{
							this.m_costMallLab.SetText(string.Format("[ff0000]{0}[-]", this.m_needMall));
						}
						else
						{
							this.m_costMallLab.SetText(this.m_needMall.ToString());
						}
						this.m_lackJadTipsLab.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("NeedBuyOtherJade"), xtuple.Item2));
						this.m_shopPos.SetActive(true);
						GameObject gameObject = this.m_shopPos.transform.FindChild("JadeTpl").gameObject;
						XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(gameObject, (int)xtuple.Item1, (int)xtuple.Item2, false);
						ixuisprite = (gameObject.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.ID = (ulong)xtuple.Item1;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
						this.m_noShopPos.transform.parent.gameObject.SetActive(false);
						this.m_hadShopPos.transform.parent.gameObject.SetActive(true);
						gameObject2 = this.m_hadShopPos;
						for (int i = 0; i < list.Count; i++)
						{
							gameObject = this.m_jadeTplPool1.FetchGameObject(false);
							gameObject.transform.parent = gameObject2.transform;
							gameObject.transform.localScale = Vector3.one;
							gameObject.transform.localPosition = new Vector3((float)(i * this.m_jadeTplPool1.TplWidth), 0f, 0f);
							XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(gameObject, (int)list[i].Item1, (int)list[i].Item2, false);
							ixuisprite = (gameObject.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite);
							ixuisprite.ID = (ulong)list[i].Item1;
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
						}
					}
					else
					{
						this.m_shopPos.SetActive(false);
						this.m_costMallLab.gameObject.SetActive(false);
						this.m_lackJadTipsLab.gameObject.SetActive(false);
						this.m_hadShopPos.transform.parent.gameObject.SetActive(false);
						this.m_noShopPos.transform.parent.gameObject.SetActive(true);
						gameObject2 = this.m_noShopPos;
						for (int j = 0; j < list.Count; j++)
						{
							GameObject gameObject = this.m_jadeTplPool2.FetchGameObject(false);
							gameObject.transform.parent = gameObject2.transform;
							gameObject.transform.localScale = Vector3.one;
							gameObject.transform.localPosition = new Vector3((float)(j * this.m_jadeTplPool2.TplWidth), 0f, 0f);
							XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(gameObject, (int)list[j].Item1, (int)list[j].Item2, false);
							ixuisprite = (gameObject.transform.FindChild("Icon/Icon").GetComponent("XUISprite") as IXUISprite);
							ixuisprite.ID = (ulong)list[j].Item1;
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectedItemClicked));
						}
					}
					gameObject2.SetActive(false);
					gameObject2.SetActive(true);
				}
			}
		}

		// Token: 0x0600FBDD RID: 64477 RVA: 0x003A95E0 File Offset: 0x003A77E0
		private void PlayEffect()
		{
			this.m_effectIsEnd = false;
			bool flag = this.m_fx == null;
			if (flag)
			{
				this.m_fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_lyqh_02", this.m_effectParentTra, false);
			}
			else
			{
				this.m_fx.Play();
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_delayTime, new XTimerMgr.ElapsedEventHandler(this.DelayFill), null);
		}

		// Token: 0x0600FBDE RID: 64478 RVA: 0x003A9660 File Offset: 0x003A7860
		private void DelayFill(object o = null)
		{
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_sourceJade, (int)this.m_itemId, 1, false);
			this.FillChangedItem();
			this.m_effectIsEnd = true;
		}

		// Token: 0x0600FBDF RID: 64479 RVA: 0x003A9690 File Offset: 0x003A7890
		private bool OnClickClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600FBE0 RID: 64480 RVA: 0x003A96AC File Offset: 0x003A78AC
		private bool OnClickComposed(IXUIButton btn)
		{
			bool flag = !this.m_effectIsEnd;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.SetButtonCool(this.m_coolTime);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this.m_addLevel == 0U;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JadeHadCurMax"), "fece00");
						result = false;
					}
					else
					{
						ulong virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
						bool flag4 = virtualItemCount < this.m_needGold;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_LACKCOIN"), "fece00");
							result = false;
						}
						else
						{
							virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
							bool flag5 = virtualItemCount < (ulong)this.m_needMall;
							if (flag5)
							{
								DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.DRAGON_COIN);
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_AUCT_DRAGONCOINLESS"), "fece00");
								result = false;
							}
							else
							{
								bool flag6 = this.m_needMall > 0U;
								if (flag6)
								{
									string message = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("JadeComposeTips")), this.m_needMall);
									XSingleton<UiUtility>.singleton.ShowModalDialog(message, new ButtonClickEventHandler(this.DoOK));
								}
								else
								{
									bool flag7 = this.m_type == -1;
									if (flag7)
									{
										this.m_doc.ReqComposeJade(this.m_jadeUid, this.m_addLevel);
									}
									else
									{
										this.m_doc.ReqUpdateJade((uint)this.m_type, this.m_addLevel);
									}
								}
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600FBE1 RID: 64481 RVA: 0x003A984C File Offset: 0x003A7A4C
		private bool DoOK(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = this.m_type == -1;
			if (flag)
			{
				this.m_doc.ReqComposeJade(this.m_jadeUid, this.m_addLevel);
			}
			else
			{
				this.m_doc.ReqUpdateJade((uint)this.m_type, this.m_addLevel);
			}
			return true;
		}

		// Token: 0x0600FBE2 RID: 64482 RVA: 0x003A98AC File Offset: 0x003A7AAC
		private bool OnClickReduceBtn(IXUIButton btn)
		{
			bool flag = this.m_addLevel <= 1U;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JadeHadLeast"), "fece00");
				result = false;
			}
			else
			{
				this.m_addLevel -= 1U;
				this.FillChangedItem();
				result = true;
			}
			return result;
		}

		// Token: 0x0600FBE3 RID: 64483 RVA: 0x003A9908 File Offset: 0x003A7B08
		private bool OnClickAddBtn(IXUIButton btn)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int num = this.m_doc.JadeLevelToMosaicLevel(this.m_curLevel + this.m_addLevel + 1U);
				bool flag2 = num == -1 || (long)num > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("JadeHadCurMax"), "fece00");
					result = false;
				}
				else
				{
					this.m_addLevel += 1U;
					this.FillChangedItem();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FBE4 RID: 64484 RVA: 0x003A99A4 File Offset: 0x003A7BA4
		private void OnSelectedItemClicked(IXUISprite iSp)
		{
			ulong id = iSp.ID;
			XItem xitem = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(id);
			bool flag = xitem == null;
			if (flag)
			{
				xitem = XBagDocument.MakeXItem((int)id, false);
			}
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, iSp, false, 0U);
		}

		// Token: 0x0600FBE5 RID: 64485 RVA: 0x003A99F4 File Offset: 0x003A7BF4
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

		// Token: 0x04006E91 RID: 28305
		private XJadeDocument m_doc = null;

		// Token: 0x04006E92 RID: 28306
		private IXUIButton m_closedBtn;

		// Token: 0x04006E93 RID: 28307
		private IXUIButton m_composeBtn;

		// Token: 0x04006E94 RID: 28308
		private IXUIButton m_reduceBtn;

		// Token: 0x04006E95 RID: 28309
		private IXUIButton m_addBtn;

		// Token: 0x04006E96 RID: 28310
		private IXUILabel m_costLab;

		// Token: 0x04006E97 RID: 28311
		private IXUILabel m_costMallLab;

		// Token: 0x04006E98 RID: 28312
		private IXUILabel m_lackJadTipsLab;

		// Token: 0x04006E99 RID: 28313
		private GameObject m_sourceJade;

		// Token: 0x04006E9A RID: 28314
		private GameObject m_targetJade;

		// Token: 0x04006E9B RID: 28315
		private GameObject m_hadShopPos;

		// Token: 0x04006E9C RID: 28316
		private GameObject m_noShopPos;

		// Token: 0x04006E9D RID: 28317
		private GameObject m_shopPos;

		// Token: 0x04006E9E RID: 28318
		private Transform m_effectParentTra;

		// Token: 0x04006E9F RID: 28319
		private XUIPool m_jadeTplPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006EA0 RID: 28320
		private XUIPool m_jadeTplPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006EA1 RID: 28321
		private XFx m_fx = null;

		// Token: 0x04006EA2 RID: 28322
		private int m_type = 0;

		// Token: 0x04006EA3 RID: 28323
		private ulong m_jadeUid = 0UL;

		// Token: 0x04006EA4 RID: 28324
		private uint m_itemId = 0U;

		// Token: 0x04006EA5 RID: 28325
		private uint m_curLevel = 0U;

		// Token: 0x04006EA6 RID: 28326
		private uint m_addLevel = 0U;

		// Token: 0x04006EA7 RID: 28327
		private ulong m_needGold = 0UL;

		// Token: 0x04006EA8 RID: 28328
		private uint m_needMall = 0U;

		// Token: 0x04006EA9 RID: 28329
		private float m_delayTime = 0.3f;

		// Token: 0x04006EAA RID: 28330
		private uint m_token = 0U;

		// Token: 0x04006EAB RID: 28331
		private bool m_isNeedPlayEffect = false;

		// Token: 0x04006EAC RID: 28332
		private bool m_effectIsEnd = true;

		// Token: 0x04006EAD RID: 28333
		private float m_coolTime = 0.5f;

		// Token: 0x04006EAE RID: 28334
		private float m_fLastClickBtnTime = 0f;
	}
}
