using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B5 RID: 6069
	internal class ArtifactRecastHandler : DlgHandlerBase
	{
		// Token: 0x1700387F RID: 14463
		// (get) Token: 0x0600FB20 RID: 64288 RVA: 0x003A3654 File Offset: 0x003A1854
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactRecastHandler";
			}
		}

		// Token: 0x0600FB21 RID: 64289 RVA: 0x003A366C File Offset: 0x003A186C
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

		// Token: 0x0600FB22 RID: 64290 RVA: 0x003A371A File Offset: 0x003A191A
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSprMain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_recastBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRecastBtn));
		}

		// Token: 0x0600FB23 RID: 64291 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FB24 RID: 64292 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FB25 RID: 64293 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FB26 RID: 64294 RVA: 0x003A3754 File Offset: 0x003A1954
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.Handler = null;
		}

		// Token: 0x0600FB27 RID: 64295 RVA: 0x003A376A File Offset: 0x003A196A
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FB28 RID: 64296 RVA: 0x003A3774 File Offset: 0x003A1974
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

		// Token: 0x0600FB29 RID: 64297 RVA: 0x003A399C File Offset: 0x003A1B9C
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

		// Token: 0x0600FB2A RID: 64298 RVA: 0x003A3A70 File Offset: 0x003A1C70
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

		// Token: 0x0600FB2B RID: 64299 RVA: 0x003A3B74 File Offset: 0x003A1D74
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

		// Token: 0x0600FB2C RID: 64300 RVA: 0x003A3BD8 File Offset: 0x003A1DD8
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_RECAST_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FB2D RID: 64301 RVA: 0x003A3C20 File Offset: 0x003A1E20
		private void OnClickBox(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactRecastTips1"), "fece00");
		}

		// Token: 0x0600FB2E RID: 64302 RVA: 0x003A3C40 File Offset: 0x003A1E40
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

		// Token: 0x0600FB2F RID: 64303 RVA: 0x003A3CA8 File Offset: 0x003A1EA8
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

		// Token: 0x04006E33 RID: 28211
		private ArtifactRecastDocument m_doc;

		// Token: 0x04006E34 RID: 28212
		private GameObject m_itemGoMain;

		// Token: 0x04006E35 RID: 28213
		private GameObject m_itemGoMet;

		// Token: 0x04006E36 RID: 28214
		private IXUISprite m_boxSprMain;

		// Token: 0x04006E37 RID: 28215
		private IXUIButton m_recastBtn;

		// Token: 0x04006E38 RID: 28216
		private bool m_bIsEnough = true;

		// Token: 0x04006E39 RID: 28217
		private int m_needItemId = 0;

		// Token: 0x04006E3A RID: 28218
		private float m_delayTime = 0.5f;

		// Token: 0x04006E3B RID: 28219
		private float m_fLastClickBtnTime = 0f;
	}
}
