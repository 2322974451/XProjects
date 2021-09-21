using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017AD RID: 6061
	internal class ArtifactComposeHandler : DlgHandlerBase
	{
		// Token: 0x17003872 RID: 14450
		// (get) Token: 0x0600FAA2 RID: 64162 RVA: 0x0039FCDC File Offset: 0x0039DEDC
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactComposeHandler";
			}
		}

		// Token: 0x0600FAA3 RID: 64163 RVA: 0x0039FCF4 File Offset: 0x0039DEF4
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactComposeDocument.Doc;
			this.m_doc.ComposeHandler = this;
			Transform transform = base.PanelObject.transform.Find("Bg1");
			this.m_itemArray = new Transform[ArtifactComposeDocument.MAX_RECYCLE_COUNT];
			this.m_itemArray[0] = transform.FindChild("item0");
			this.m_itemArray[1] = transform.FindChild("item1");
			this.m_boxArray = new IXUISprite[ArtifactComposeDocument.MAX_RECYCLE_COUNT];
			this.m_boxArray[0] = (transform.FindChild("BgBox1").GetComponent("XUISprite") as IXUISprite);
			this.m_boxArray[1] = (transform.FindChild("BgBox2").GetComponent("XUISprite") as IXUISprite);
			this.m_tipsLab1 = (transform.FindChild("Label1").GetComponent("XUILabel") as IXUILabel);
			this.m_tipsLab2 = (transform.FindChild("Label2").GetComponent("XUILabel") as IXUILabel);
			this.m_composeBtn = (transform.FindChild("Get").GetComponent("XUIButton") as IXUIButton);
			this.m_oneKeyComposeBtn = (base.PanelObject.transform.FindChild("BtnCompose").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600FAA4 RID: 64164 RVA: 0x0039FE4C File Offset: 0x0039E04C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < this.m_itemArray.Length; i++)
			{
				IXUISprite ixuisprite = this.m_itemArray[i].FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUnselectSprClicked));
			}
			for (int j = 0; j < this.m_boxArray.Length; j++)
			{
				bool flag = this.m_boxArray[j] != null;
				if (flag)
				{
					this.m_boxArray[j].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBgBox));
				}
			}
			this.m_composeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickComposed));
			this.m_oneKeyComposeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickOneKeyComposeBtn));
		}

		// Token: 0x0600FAA5 RID: 64165 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FAA6 RID: 64166 RVA: 0x0039FF25 File Offset: 0x0039E125
		protected override void OnHide()
		{
			base.OnHide();
			this.m_doc.ResetSelection(false);
		}

		// Token: 0x0600FAA7 RID: 64167 RVA: 0x0039FF3C File Offset: 0x0039E13C
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillFrame();
		}

		// Token: 0x0600FAA8 RID: 64168 RVA: 0x0039FF4D File Offset: 0x0039E14D
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.ComposeHandler = null;
		}

		// Token: 0x0600FAA9 RID: 64169 RVA: 0x0039FF63 File Offset: 0x0039E163
		public void RefreshUi()
		{
			this.FillFrame();
		}

		// Token: 0x0600FAAA RID: 64170 RVA: 0x0039FF70 File Offset: 0x0039E170
		private void FillFrame()
		{
			this.m_tipsLab1.SetText(XSingleton<XStringTable>.singleton.GetString("ArtifactComposeTips4"));
			this.m_tipsLab1.gameObject.SetActive((long)this.m_doc.SelectedItems.Count < (long)((ulong)ArtifactComposeDocument.MAX_RECYCLE_COUNT));
			bool flag = this.m_doc.CurSelectTabLevel > XSingleton<XGlobalConfig>.singleton.GetInt("ArtifactShowTipsLevel");
			if (flag)
			{
				this.m_tipsLab2.SetText(XSingleton<XStringTable>.singleton.GetString("ArtifactComposeTips3"));
			}
			else
			{
				this.m_tipsLab2.SetText(XSingleton<XStringTable>.singleton.GetString("ArtifactComposeTips3"));
			}
			int num = 0;
			while (num < this.m_doc.SelectedItems.Count && num < this.m_itemArray.Length)
			{
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.m_doc.SelectedItems[num]);
				bool flag2 = this.m_itemArray[num] != null;
				if (flag2)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemArray[num].gameObject, bagItemByUID);
					IXUISprite ixuisprite = this.m_itemArray[num].FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = this.m_doc.SelectedItems[num];
				}
				num++;
			}
			while ((long)num < (long)((ulong)ArtifactComposeDocument.MAX_RECYCLE_COUNT))
			{
				bool flag3 = this.m_itemArray[num] != null;
				if (flag3)
				{
					XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemArray[num].gameObject, null);
					IXUISprite ixuisprite2 = this.m_itemArray[num].FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = 0UL;
				}
				num++;
			}
		}

		// Token: 0x0600FAAB RID: 64171 RVA: 0x003A014C File Offset: 0x0039E34C
		private void OnUnselectSprClicked(IXUISprite iSp)
		{
			bool flag = iSp.ID == 0UL;
			if (!flag)
			{
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(iSp.ID);
				bool flag2 = bagItemByUID == null;
				if (!flag2)
				{
					bool flag3 = bagItemByUID.Type == ItemType.ARTIFACT;
					if (flag3)
					{
						XSingleton<TooltipParam>.singleton.bShowTakeOutBtn = true;
					}
					XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(bagItemByUID, iSp, true, 0U);
				}
			}
		}

		// Token: 0x0600FAAC RID: 64172 RVA: 0x003A01AD File Offset: 0x0039E3AD
		private void OnClickBgBox(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PutTwoArtifact"), "fece00");
		}

		// Token: 0x0600FAAD RID: 64173 RVA: 0x003A01D0 File Offset: 0x0039E3D0
		private bool OnClickComposed(IXUIButton btn)
		{
			bool flag = !this.m_doc.IsNumFit;
			if (flag)
			{
				bool flag2 = this.m_doc.SelectedItems.Count == 0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactComposeTips4"), "fece00");
					return false;
				}
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.m_doc.SelectedItems[0]);
				bool flag3 = bagItemByUID != null && bagItemByUID.itemConf != null;
				if (flag3)
				{
					ArtifactComposeTable.RowData composeRowData = this.m_doc.GetComposeRowData(this.m_doc.CurSelectTabLevel, (int)bagItemByUID.itemConf.ItemQuality);
					bool flag4 = composeRowData != null;
					if (flag4)
					{
						bool flag5 = composeRowData.ArtifactNum2DropID.count > 0;
						if (flag5)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactComposeTips1"), "fece00");
						}
					}
					return false;
				}
			}
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag6 = specificDocument.GetValue(XOptionsDefine.OD_NO_ARTIFACTCOMPOSE_REPLACE_CONFIRM) == 0;
			bool result;
			if (flag6)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("ArtifactComposeEnsureTips"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_ARTIFACT_COMPOSE_TRAVELSET, 50);
				result = true;
			}
			else
			{
				this.DoOK(null);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FAAE RID: 64174 RVA: 0x003A0338 File Offset: 0x0039E538
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_ARTIFACTCOMPOSE_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ARTIFACT_COMPOSE_TRAVELSET) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FAAF RID: 64175 RVA: 0x003A0380 File Offset: 0x0039E580
		private bool DoOK(IXUIButton btn)
		{
			this.m_doc.ReqCoposeArtifact();
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_ARTIFACTCOMPOSE_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ARTIFACT_COMPOSE_TRAVELSET) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FAB0 RID: 64176 RVA: 0x003A03E4 File Offset: 0x0039E5E4
		private bool OnClickOneKeyComposeBtn(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ArtifactOneKeyHandler>(ref this.m_oneKeyHandler, base.PanelObject.transform, true, this);
			return true;
		}

		// Token: 0x04006DDF RID: 28127
		private ArtifactComposeDocument m_doc;

		// Token: 0x04006DE0 RID: 28128
		private ArtifactOneKeyHandler m_oneKeyHandler;

		// Token: 0x04006DE1 RID: 28129
		private IXUISprite[] m_boxArray;

		// Token: 0x04006DE2 RID: 28130
		private Transform[] m_itemArray;

		// Token: 0x04006DE3 RID: 28131
		private IXUILabel m_tipsLab1;

		// Token: 0x04006DE4 RID: 28132
		private IXUILabel m_tipsLab2;

		// Token: 0x04006DE5 RID: 28133
		private IXUIButton m_composeBtn;

		// Token: 0x04006DE6 RID: 28134
		private IXUIButton m_oneKeyComposeBtn;
	}
}
