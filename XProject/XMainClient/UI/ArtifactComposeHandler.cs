using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactComposeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactComposeHandler";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_doc.ResetSelection(false);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.FillFrame();
		}

		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.ComposeHandler = null;
		}

		public void RefreshUi()
		{
			this.FillFrame();
		}

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

		private void OnClickBgBox(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PutTwoArtifact"), "fece00");
		}

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

		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_ARTIFACTCOMPOSE_REPLACE_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_ARTIFACT_COMPOSE_TRAVELSET) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

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

		private bool OnClickOneKeyComposeBtn(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<ArtifactOneKeyHandler>(ref this.m_oneKeyHandler, base.PanelObject.transform, true, this);
			return true;
		}

		private ArtifactComposeDocument m_doc;

		private ArtifactOneKeyHandler m_oneKeyHandler;

		private IXUISprite[] m_boxArray;

		private Transform[] m_itemArray;

		private IXUILabel m_tipsLab1;

		private IXUILabel m_tipsLab2;

		private IXUIButton m_composeBtn;

		private IXUIButton m_oneKeyComposeBtn;
	}
}
