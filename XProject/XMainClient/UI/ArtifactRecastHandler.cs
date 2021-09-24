using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactRecastHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactRecastHandler";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactRecastDocument.Doc;
			this.m_doc.Handler = this;
			Transform transform = base.PanelObject.transform.FindChild("Bg1");
			this.m_itemGoMain = transform.FindChild("item0").gameObject;
			this.m_itemGoMet = transform.FindChild("item1").gameObject;
			this.m_boxSprMain = (transform.FindChild("BgBox1").GetComponent("XUISprite") as IXUISprite);
			this.m_recastBtn = (transform.FindChild("Get").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSprMain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_recastBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRecastBtn));
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
					bool flag3 = artifactListRowData == null || artifactListRowData.RecastMaterials[0, 0] == 0U;
					if (flag3)
					{
						XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGoMet, null);
					}
					else
					{
						this.m_needItemId = (int)artifactListRowData.RecastMaterials[0, 0];
						uint num = artifactListRowData.RecastMaterials[0, 1];
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
				}
			}
		}

		private void FillNull()
		{
			XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGoMain, null);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("RecastStoneItemId");
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGoMet, @int, 2, false);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(@int);
			IXUILabel ixuilabel = this.m_itemGoMet.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format("{0}/?", itemCount));
			IXUISprite ixuisprite = this.m_itemGoMet.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)@int);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
		}

		private bool OnClickRecastBtn(IXUIButton btn)
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRecastTips2"), "fece00");
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
						bool flag4 = specificDocument.GetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM) == 1;
						if (flag4)
						{
							this.m_doc.ReqRecast();
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<XStringTable>.singleton.GetString("RecastEnsureTips"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_RECAST_CONFIRM, 50);
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
				specificDocument.SetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_RECAST_CONFIRM) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqRecast();
			return true;
		}

		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_RECAST_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void OnClickBox(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRecastTips1"), "fece00");
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

		private ArtifactRecastDocument m_doc;

		private GameObject m_itemGoMain;

		private GameObject m_itemGoMet;

		private IXUISprite m_boxSprMain;

		private IXUIButton m_recastBtn;

		private bool m_bIsEnough = true;

		private int m_needItemId = 0;

		private float m_delayTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;
	}
}
