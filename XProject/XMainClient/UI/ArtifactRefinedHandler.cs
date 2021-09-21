using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B6 RID: 6070
	internal class ArtifactRefinedHandler : DlgHandlerBase
	{
		// Token: 0x17003880 RID: 14464
		// (get) Token: 0x0600FB31 RID: 64305 RVA: 0x003A3D0C File Offset: 0x003A1F0C
		public RefinedReplaceHandler Handler
		{
			get
			{
				return this.m_handler;
			}
		}

		// Token: 0x17003881 RID: 14465
		// (get) Token: 0x0600FB32 RID: 64306 RVA: 0x003A3D24 File Offset: 0x003A1F24
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactCzHandler";
			}
		}

		// Token: 0x0600FB33 RID: 64307 RVA: 0x003A3D3C File Offset: 0x003A1F3C
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactRefinedDocument.Doc;
			this.m_doc.Handler = this;
			Transform transform = base.PanelObject.transform.FindChild("Bg1");
			this.m_itemGoMain = transform.FindChild("item0").gameObject;
			this.m_itemGoMet = transform.FindChild("item1").gameObject;
			this.m_boxSprMain = (transform.FindChild("BgBox1").GetComponent("XUISprite") as IXUISprite);
			this.m_refinedBtn = (transform.FindChild("Get").GetComponent("XUIButton") as IXUIButton);
			this.m_resultNewGo = base.PanelObject.transform.Find("ResultNew").gameObject;
			DlgHandlerBase.EnsureCreate<RefinedReplaceHandler>(ref this.m_handler, this.m_resultNewGo, null, false);
		}

		// Token: 0x0600FB34 RID: 64308 RVA: 0x003A3E1E File Offset: 0x003A201E
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSprMain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_refinedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRefinedBtn));
		}

		// Token: 0x0600FB35 RID: 64309 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FB36 RID: 64310 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FB37 RID: 64311 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FB38 RID: 64312 RVA: 0x003A3E58 File Offset: 0x003A2058
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.Handler = null;
		}

		// Token: 0x0600FB39 RID: 64313 RVA: 0x003A3E6E File Offset: 0x003A206E
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FB3A RID: 64314 RVA: 0x003A3E78 File Offset: 0x003A2078
		public void ShowReplaceHandler()
		{
			bool flag = this.m_handler != null && !this.m_handler.IsVisible();
			if (flag)
			{
				this.m_handler.SetVisible(true);
			}
		}

		// Token: 0x0600FB3B RID: 64315 RVA: 0x003A3EB0 File Offset: 0x003A20B0
		private void FillContent()
		{
			bool flag = this.m_doc.SelectUid == 0UL;
			if (flag)
			{
				this.FillNull();
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_doc.SelectUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					this.FillNull();
				}
				else
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGoMain, itemByUID);
					IXUISprite ixuisprite = this.m_itemGoMain.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = this.m_doc.SelectUid;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemByUID.itemID);
					bool flag3 = artifactListRowData == null || artifactListRowData.RefinedMaterials[0, 0] == 0U;
					if (flag3)
					{
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGoMet, null);
					}
					else
					{
						this.m_needItemId = (int)artifactListRowData.RefinedMaterials[0, 0];
						uint num = artifactListRowData.RefinedMaterials[0, 1];
						this.m_needNum = num;
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGoMet, this.m_needItemId, (int)num, false);
						ixuisprite = (this.m_itemGoMet.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.ID = (ulong)((long)this.m_needItemId);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
						ulong itemCount = XBagDocument.BagDoc.GetItemCount(this.m_needItemId);
						IXUILabel ixuilabel = this.m_itemGoMet.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.gameObject.SetActive(true);
						this.m_bIsEnough = (itemCount >= (ulong)num);
						bool bIsEnough = this.m_bIsEnough;
						if (bIsEnough)
						{
							ixuilabel.SetText(string.Format("[00ff00]{0}/{1}[-]", itemCount, num));
						}
						else
						{
							ixuilabel.SetText(string.Format("[ff0000]{0}/{1}[-]", itemCount, num));
						}
					}
					XArtifactItem xartifactItem = itemByUID as XArtifactItem;
					bool flag4 = xartifactItem.UnSavedAttr != null && xartifactItem.UnSavedAttr.Count > 0;
					if (flag4)
					{
						this.ShowReplaceHandler();
					}
				}
			}
		}

		// Token: 0x0600FB3C RID: 64316 RVA: 0x003A4114 File Offset: 0x003A2314
		private void FillNull()
		{
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGoMain, null);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ReFinedStoneItemId");
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGoMet, @int, 2, false);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(@int);
			IXUILabel ixuilabel = this.m_itemGoMet.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format("{0}/?", itemCount));
			IXUISprite ixuisprite = this.m_itemGoMet.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)@int);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
		}

		// Token: 0x0600FB3D RID: 64317 RVA: 0x003A41E8 File Offset: 0x003A23E8
		private bool OnClickRefinedBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_delayTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_doc.SelectUid == 0UL;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRefinedTips2"), "fece00");
					result = false;
				}
				else
				{
					bool flag3 = !this.m_bIsEnough;
					if (flag3)
					{
						DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
						XSingleton<UiUtility>.singleton.ShowItemAccess(this.m_needItemId, null);
						result = false;
					}
					else
					{
						XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
						bool flag4 = specificDocument.GetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM) == 1;
						if (flag4)
						{
							this.m_doc.ReqRefined(ArtifactDeityStoveOpType.ArtifactDeityStove_Refine);
						}
						else
						{
							string text = "";
							ItemList.RowData itemConf = XBagDocument.GetItemConf(this.m_needItemId);
							bool flag5 = itemConf != null;
							if (flag5)
							{
								text = itemConf.ItemIcon[0];
							}
							bool flag6 = text != "";
							if (flag6)
							{
								text = XLabelSymbolHelper.FormatAnimation("Item/Item2", text, 10);
								text = string.Format("{0}X{1}", text, this.m_needNum);
							}
							text = string.Format(XSingleton<XStringTable>.singleton.GetString("RefinedEnsureTips"), text);
							XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<UiUtility>.singleton.ReplaceReturn(text), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_REFINED_CONFIRM, 50);
						}
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600FB3E RID: 64318 RVA: 0x003A4370 File Offset: 0x003A2570
		private bool DoOK(IXUIButton btn)
		{
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_REFINED_CONFIRM) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqRefined(ArtifactDeityStoveOpType.ArtifactDeityStove_Refine);
			return true;
		}

		// Token: 0x0600FB3F RID: 64319 RVA: 0x003A43D8 File Offset: 0x003A25D8
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_REFINED_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FB40 RID: 64320 RVA: 0x003A4420 File Offset: 0x003A2620
		private void OnClickBox(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRefinedTips1"), "fece00");
		}

		// Token: 0x0600FB41 RID: 64321 RVA: 0x003A4440 File Offset: 0x003A2640
		private void OnClickTips(IXUISprite spr)
		{
			XItem xitem = XBagDocument.BagDoc.GetItemByUID(spr.ID);
			bool flag = xitem == null;
			if (flag)
			{
				xitem = XBagDocument.MakeXItem((int)spr.ID, false);
			}
			bool flag2 = xitem == null;
			if (!flag2)
			{
				bool flag3 = xitem.Type == ItemType.ARTIFACT;
				if (flag3)
				{
					XSingleton<TooltipParam>.singleton.bShowTakeOutBtn = true;
				}
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, spr, true, 0U);
			}
		}

		// Token: 0x0600FB42 RID: 64322 RVA: 0x003A44A8 File Offset: 0x003A26A8
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

		// Token: 0x04006E3C RID: 28220
		private ArtifactRefinedDocument m_doc;

		// Token: 0x04006E3D RID: 28221
		private GameObject m_itemGoMain;

		// Token: 0x04006E3E RID: 28222
		private GameObject m_itemGoMet;

		// Token: 0x04006E3F RID: 28223
		private GameObject m_resultNewGo;

		// Token: 0x04006E40 RID: 28224
		private IXUISprite m_boxSprMain;

		// Token: 0x04006E41 RID: 28225
		private IXUIButton m_refinedBtn;

		// Token: 0x04006E42 RID: 28226
		private bool m_bIsEnough = true;

		// Token: 0x04006E43 RID: 28227
		private int m_needItemId = 0;

		// Token: 0x04006E44 RID: 28228
		private float m_delayTime = 0.5f;

		// Token: 0x04006E45 RID: 28229
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04006E46 RID: 28230
		private uint m_needNum = 0U;

		// Token: 0x04006E47 RID: 28231
		private RefinedReplaceHandler m_handler;
	}
}
