using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class JadeComposeFrameHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/JadeComposeFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			this.m_composeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickComposed));
			this.m_reduceBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickReduceBtn));
			this.m_addBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddBtn));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_effectIsEnd = true;
			this.m_isNeedPlayEffect = false;
			this.FillContent();
		}

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

		public override void RefreshData()
		{
			base.RefreshData();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private void DelayFill(object o = null)
		{
			XSingleton<XItemDrawerMgr>.singleton.jadeItemDrawer.DrawItem(this.m_sourceJade, (int)this.m_itemId, 1, false);
			this.FillChangedItem();
			this.m_effectIsEnd = true;
		}

		private bool OnClickClosed(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

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

		private XJadeDocument m_doc = null;

		private IXUIButton m_closedBtn;

		private IXUIButton m_composeBtn;

		private IXUIButton m_reduceBtn;

		private IXUIButton m_addBtn;

		private IXUILabel m_costLab;

		private IXUILabel m_costMallLab;

		private IXUILabel m_lackJadTipsLab;

		private GameObject m_sourceJade;

		private GameObject m_targetJade;

		private GameObject m_hadShopPos;

		private GameObject m_noShopPos;

		private GameObject m_shopPos;

		private Transform m_effectParentTra;

		private XUIPool m_jadeTplPool1 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_jadeTplPool2 = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XFx m_fx = null;

		private int m_type = 0;

		private ulong m_jadeUid = 0UL;

		private uint m_itemId = 0U;

		private uint m_curLevel = 0U;

		private uint m_addLevel = 0U;

		private ulong m_needGold = 0UL;

		private uint m_needMall = 0U;

		private float m_delayTime = 0.3f;

		private uint m_token = 0U;

		private bool m_isNeedPlayEffect = false;

		private bool m_effectIsEnd = true;

		private float m_coolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;
	}
}
