using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpriteAwakeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAwakeWindow";
			}
		}

		protected override void Init()
		{
			Transform parent = base.PanelObject.transform.Find("Bg/AvatarRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._AvatarHandler, parent, true, this);
			Transform parent2 = base.PanelObject.transform.Find("Bg/CurrFrameRoot/AptitudeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler1, parent2, true, this);
			Transform parent3 = base.PanelObject.transform.Find("Bg/AfterFrameRoot/AptitudeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler2, parent3, true, this);
			this.m_CurrPower = (base.PanelObject.transform.Find("Bg/CurrPower").GetComponent("XUILabel") as IXUILabel);
			this.m_AfterPower = (base.PanelObject.transform.Find("Bg/AfterPower").GetComponent("XUILabel") as IXUILabel);
			this.m_ArrowUp = base.PanelObject.transform.Find("Bg/ArrowUp");
			this.m_ArrowDown = base.PanelObject.transform.Find("Bg/ArrowDown");
			this.m_btnKeepOrigHighlight = base.PanelObject.transform.Find("Bg/KeepOrig/Recommend").gameObject;
			this.m_btnEnsureAwakeHighlight = base.PanelObject.transform.Find("Bg/EnsureAwake/Recommend").gameObject;
			this.m_Tip = (base.PanelObject.transform.FindChild("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this._AvatarHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler1);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler2);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			IXUIButton ixuibutton = base.PanelObject.transform.Find("Bg/KeepOrig").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnKeepOrgClicked));
			IXUIButton ixuibutton2 = base.PanelObject.transform.Find("Bg/EnsureAwake").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnsureAwakeClicked));
		}

		private bool OnKeepOrgClicked(IXUIButton btn)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.SetVisible(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._AvatarHandler.SetVisible(true);
			this.m_Tip.SetText(XSingleton<XStringTable>.singleton.GetString("SpriteAwake_Tip2"));
		}

		protected override void OnHide()
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.SetAvatar();
			this._AvatarHandler.SetVisible(false);
			base.OnHide();
		}

		private bool OnEnsureAwakeClicked(IXUIButton btn)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.OnAwakeBtnClick(null);
			return true;
		}

		private bool OnKeepNew(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			specificDocument.ReqSpriteOperation(SpriteType.Sprite_Awake_Replace);
			return true;
		}

		public void SetSpritesInfo(SpriteInfo currSprite, SpriteInfo newSprite)
		{
			this.m_OrgInfo = currSprite;
			this.m_NewInfo = newSprite;
			this._AvatarHandler.SetSpriteInfo(currSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, 6, false, true);
			this.m_CurrPower.SetText(currSprite.PowerPoint.ToString());
			this.m_AptitudeHandler1.SetSpriteAttributeInfo(currSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, null);
			this.m_AptitudeHandler2.SetSpriteAttributeInfo(newSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, currSprite);
			this.m_ArrowUp.gameObject.SetActive(newSprite.PowerPoint > currSprite.PowerPoint);
			this.m_ArrowDown.gameObject.SetActive(newSprite.PowerPoint < currSprite.PowerPoint);
			bool flag = newSprite.PowerPoint > currSprite.PowerPoint;
			if (flag)
			{
				this.m_AfterPower.SetText(XStringDefineProxy.GetString("SpriteAttributeUpColor", new object[]
				{
					newSprite.PowerPoint
				}));
			}
			else
			{
				bool flag2 = newSprite.PowerPoint < currSprite.PowerPoint;
				if (flag2)
				{
					this.m_AfterPower.SetText(XStringDefineProxy.GetString("SpriteAttributeDownColor", new object[]
					{
						newSprite.PowerPoint
					}));
				}
				else
				{
					this.m_AfterPower.SetText(newSprite.PowerPoint.ToString());
				}
			}
		}

		private XSpriteAvatarHandler _AvatarHandler;

		private XSpriteAttributeAHandler m_AptitudeHandler1;

		private XSpriteAttributeAHandler m_AptitudeHandler2;

		private IXUILabel m_CurrPower;

		private IXUILabel m_AfterPower;

		private Transform m_ArrowUp;

		private Transform m_ArrowDown;

		private GameObject m_btnKeepOrigHighlight;

		private GameObject m_btnEnsureAwakeHighlight;

		private SpriteInfo m_OrgInfo;

		private SpriteInfo m_NewInfo;

		private IXUILabel m_Tip;
	}
}
