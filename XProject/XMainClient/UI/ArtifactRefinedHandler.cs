using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactRefinedHandler : DlgHandlerBase
	{

		public RefinedReplaceHandler Handler
		{
			get
			{
				return this.m_handler;
			}
		}

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactCzHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSprMain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_refinedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRefinedBtn));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.Handler = null;
		}

		public void RefreshUi()
		{
			this.FillContent();
		}

		public void ShowReplaceHandler()
		{
			bool flag = this.m_handler != null && !this.m_handler.IsVisible();
			if (flag)
			{
				this.m_handler.SetVisible(true);
			}
		}

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

		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_REFINED_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void OnClickBox(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRefinedTips1"), "fece00");
		}

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

		private ArtifactRefinedDocument m_doc;

		private GameObject m_itemGoMain;

		private GameObject m_itemGoMet;

		private GameObject m_resultNewGo;

		private IXUISprite m_boxSprMain;

		private IXUIButton m_refinedBtn;

		private bool m_bIsEnough = true;

		private int m_needItemId = 0;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private uint m_needNum = 0U;

		private RefinedReplaceHandler m_handler;
	}
}
