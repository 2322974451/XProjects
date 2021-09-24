using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactInscriptionHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactInscriptionHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_boxSpr1.ID = 1UL;
			this.m_boxSpr1.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_boxSpr2.ID = 2UL;
			this.m_boxSpr2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickBox));
			this.m_inscriptionBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickInscriptionBtn));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_fx != null;
			if (flag)
			{
				this.m_fx.Stop();
			}
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		public void RefreshUi()
		{
			this.FillContent();
		}

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

		private bool DoCancel(IXUIButton btn)
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM, DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.GetTempTip(XTempTipDefine.OD_INSCRIPTION_CONFIRM) ? 1 : 0, false);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

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

		private ArtifactInscriptionDocument m_doc;

		private GameObject m_itemGo1;

		private GameObject m_itemGo2;

		private Transform m_effectTra;

		private IXUISprite m_boxSpr1;

		private IXUISprite m_boxSpr2;

		private IXUIButton m_inscriptionBtn;

		private XFx m_fx;

		private string m_effectPath = string.Empty;
	}
}
