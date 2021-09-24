using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpriteDetailView : DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteDetailDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem_Detail);
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this.m_AvatarHandler, base.uiBehaviour.m_AvatarRoot, true, this);
			DlgHandlerBase.EnsureCreate<XSpriteAttributeHandler>(ref this.m_AttrHandler, base.uiBehaviour.m_AttrFrameRoot, true, this);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this.m_AvatarHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeHandler>(ref this.m_AttrHandler);
			base.OnUnload();
		}

		public void ShowDetail(SpriteInfo spriteData, XAttributes attributes)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.m_SpriteInfo = spriteData;
				this.m_Attributes = attributes;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_AvatarHandler.SetVisible(true);
			bool flag = this.m_SpriteInfo != null;
			if (flag)
			{
				this.m_AvatarHandler.SetSpriteInfo(this.m_SpriteInfo, this.m_Attributes, 6, false, true);
				this.m_AttrHandler.SetSpriteAttributeInfo(this.m_SpriteInfo, this.m_Attributes, null);
			}
			else
			{
				this.m_AvatarHandler.SetSpriteInfo(this.m_SpriteID, true, 0U);
				this.m_AttrHandler.SetSpriteAttributeInfo(this.m_SpriteID);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_AvatarHandler.SetVisible(false);
		}

		public void ShowDetail(uint spriteID)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.m_SpriteInfo = null;
				this.m_SpriteID = spriteID;
				this.m_Attributes = null;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private XSpriteAvatarHandler m_AvatarHandler;

		private XSpriteAttributeHandler m_AttrHandler;

		private SpriteInfo m_SpriteInfo = null;

		private uint m_SpriteID = 0U;

		private XAttributes m_Attributes = null;
	}
}
