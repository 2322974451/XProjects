using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B2 RID: 6066
	internal class ArtifactInscriptionHandler : DlgHandlerBase
	{
		// Token: 0x1700387B RID: 14459
		// (get) Token: 0x0600FAF5 RID: 64245 RVA: 0x003A2604 File Offset: 0x003A0804
		private string EffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_effectPath);
				if (flag)
				{
					this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("InscriptionEffectPath");
				}
				return this.m_effectPath;
			}
		}

		// Token: 0x1700387C RID: 14460
		// (get) Token: 0x0600FAF6 RID: 64246 RVA: 0x003A2640 File Offset: 0x003A0840
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactInscriptionHandler";
			}
		}

		// Token: 0x0600FAF7 RID: 64247 RVA: 0x003A2658 File Offset: 0x003A0858
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactInscriptionDocument.Doc;
			this.m_doc.Handler = this;
			Transform transform = base.PanelObject.transform.FindChild("Bg1");
			this.m_itemGo1 = transform.FindChild("item0").gameObject;
			this.m_itemGo2 = transform.FindChild("item1").gameObject;
			this.m_boxSpr1 = (transform.FindChild("BgBox1").GetComponent("XUISprite") as IXUISprite);
			this.m_boxSpr2 = (transform.FindChild("BgBox2").GetComponent("XUISprite") as IXUISprite);
			this.m_inscriptionBtn = (transform.FindChild("Get").GetComponent("XUIButton") as IXUIButton);
			this.m_effectTra = transform.FindChild("Effect");
		}

		// Token: 0x0600FAF8 RID: 64248 RVA: 0x003A2738 File Offset: 0x003A0938
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSpr1.ID = 1UL;
			this.m_boxSpr1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_boxSpr2.ID = 2UL;
			this.m_boxSpr2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_inscriptionBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickInscriptionBtn));
		}

		// Token: 0x0600FAF9 RID: 64249 RVA: 0x003A27B1 File Offset: 0x003A09B1
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FAFA RID: 64250 RVA: 0x003A27C4 File Offset: 0x003A09C4
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_fx != null;
			if (flag)
			{
				this.m_fx.Stop();
			}
		}

		// Token: 0x0600FAFB RID: 64251 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FAFC RID: 64252 RVA: 0x003A27F4 File Offset: 0x003A09F4
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc.Handler = null;
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
		}

		// Token: 0x0600FAFD RID: 64253 RVA: 0x003A283D File Offset: 0x003A0A3D
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FAFE RID: 64254 RVA: 0x003A2848 File Offset: 0x003A0A48
		private void FillContent()
		{
			XItem xitem = XBagDocument.BagDoc.GetItemByUID(this.m_doc.ArtifactUid);
			bool flag = xitem == null;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo1, null);
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo1, xitem);
				IXUISprite ixuisprite = this.m_itemGo1.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = this.m_doc.ArtifactUid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			}
			xitem = XBagDocument.BagDoc.GetBagItemByUID(this.m_doc.InscriptionUid);
			bool flag2 = xitem == null;
			if (flag2)
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo2, null);
			}
			else
			{
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(this.m_itemGo2, xitem);
				IXUISprite ixuisprite2 = this.m_itemGo2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = this.m_doc.InscriptionUid;
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickTips));
			}
			bool flag3 = this.m_doc.ArtifactUid != 0UL && this.m_doc.InscriptionUid > 0UL;
			if (flag3)
			{
				bool flag4 = this.m_fx == null;
				if (flag4)
				{
					this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.EffectPath, null, true);
				}
				else
				{
					this.m_fx.SetActive(true);
				}
				this.m_fx.Play(this.m_effectTra, Vector3.zero, Vector3.one, 1f, true, false);
			}
			else
			{
				bool flag5 = this.m_fx != null;
				if (flag5)
				{
					this.m_fx.SetActive(false);
				}
			}
		}

		// Token: 0x0600FAFF RID: 64255 RVA: 0x003A2A1C File Offset: 0x003A0C1C
		private bool OnClickInscriptionBtn(IXUIButton btn)
		{
			bool flag = this.m_doc.ArtifactUid == 0UL || this.m_doc.InscriptionUid == 0UL;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("InscriptionTips1"), "fece00");
				result = false;
			}
			else
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag2 = specificDocument.GetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM) == 1;
				if (flag2)
				{
					this.m_doc.ReqInscription();
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<XStringTable>.singleton.GetString("InscriptionTips2"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.DoOK), new ButtonClickEventHandler(this.DoCancel), false, XTempTipDefine.OD_INSCRIPTION_CONFIRM, 50);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FB00 RID: 64256 RVA: 0x003A2AE4 File Offset: 0x003A0CE4
		private bool DoOK(IXUIButton btn)
		{
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				specificDocument.SetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_INSCRIPTION_CONFIRM) ? 1 : 0, false);
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqInscription();
			return true;
		}

		// Token: 0x0600FB01 RID: 64257 RVA: 0x003A2B48 File Offset: 0x003A0D48
		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_INSCRIPTION_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FB02 RID: 64258 RVA: 0x003A2B90 File Offset: 0x003A0D90
		private void OnClickBox(IXUISprite spr)
		{
			bool flag = spr.ID == 1UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("InscriptionPutInTips1"), "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("InscriptionPutInTips2"), "fece00");
			}
		}

		// Token: 0x0600FB03 RID: 64259 RVA: 0x003A2BE4 File Offset: 0x003A0DE4
		private void OnClickTips(IXUISprite spr)
		{
			bool flag = spr.ID == 0UL;
			if (!flag)
			{
				XItem xitem = XBagDocument.BagDoc.GetItemByUID(spr.ID);
				bool flag2 = xitem == null;
				if (flag2)
				{
					xitem = XBagDocument.MakeXItem((int)spr.ID, false);
				}
				XSingleton<UiUtility>.singleton.ShowTooltipDialog(xitem, null, spr, false, 0U);
			}
		}

		// Token: 0x04006E1D RID: 28189
		private ArtifactInscriptionDocument m_doc;

		// Token: 0x04006E1E RID: 28190
		private GameObject m_itemGo1;

		// Token: 0x04006E1F RID: 28191
		private GameObject m_itemGo2;

		// Token: 0x04006E20 RID: 28192
		private Transform m_effectTra;

		// Token: 0x04006E21 RID: 28193
		private IXUISprite m_boxSpr1;

		// Token: 0x04006E22 RID: 28194
		private IXUISprite m_boxSpr2;

		// Token: 0x04006E23 RID: 28195
		private IXUIButton m_inscriptionBtn;

		// Token: 0x04006E24 RID: 28196
		private XFx m_fx;

		// Token: 0x04006E25 RID: 28197
		private string m_effectPath = string.Empty;
	}
}
