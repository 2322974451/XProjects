using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB5 RID: 3253
	internal class XSpriteDetailView : DlgBase<XSpriteDetailView, XSpriteDetailBehaviour>
	{
		// Token: 0x1700325B RID: 12891
		// (get) Token: 0x0600B70B RID: 46859 RVA: 0x00246120 File Offset: 0x00244320
		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteDetailDlg";
			}
		}

		// Token: 0x1700325C RID: 12892
		// (get) Token: 0x0600B70C RID: 46860 RVA: 0x00246138 File Offset: 0x00244338
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem_Detail);
			}
		}

		// Token: 0x1700325D RID: 12893
		// (get) Token: 0x0600B70D RID: 46861 RVA: 0x00246154 File Offset: 0x00244354
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700325E RID: 12894
		// (get) Token: 0x0600B70E RID: 46862 RVA: 0x00246168 File Offset: 0x00244368
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B70F RID: 46863 RVA: 0x0024617B File Offset: 0x0024437B
		protected override void Init()
		{
			base.Init();
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this.m_AvatarHandler, base.uiBehaviour.m_AvatarRoot, true, this);
			DlgHandlerBase.EnsureCreate<XSpriteAttributeHandler>(ref this.m_AttrHandler, base.uiBehaviour.m_AttrFrameRoot, true, this);
		}

		// Token: 0x0600B710 RID: 46864 RVA: 0x002461B7 File Offset: 0x002443B7
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B711 RID: 46865 RVA: 0x002461DE File Offset: 0x002443DE
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this.m_AvatarHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeHandler>(ref this.m_AttrHandler);
			base.OnUnload();
		}

		// Token: 0x0600B712 RID: 46866 RVA: 0x00246200 File Offset: 0x00244400
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

		// Token: 0x0600B713 RID: 46867 RVA: 0x00246234 File Offset: 0x00244434
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

		// Token: 0x0600B714 RID: 46868 RVA: 0x002462C3 File Offset: 0x002444C3
		protected override void OnHide()
		{
			base.OnHide();
			this.m_AvatarHandler.SetVisible(false);
		}

		// Token: 0x0600B715 RID: 46869 RVA: 0x002462DC File Offset: 0x002444DC
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

		// Token: 0x0600B716 RID: 46870 RVA: 0x00246318 File Offset: 0x00244518
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040047C0 RID: 18368
		private XSpriteAvatarHandler m_AvatarHandler;

		// Token: 0x040047C1 RID: 18369
		private XSpriteAttributeHandler m_AttrHandler;

		// Token: 0x040047C2 RID: 18370
		private SpriteInfo m_SpriteInfo = null;

		// Token: 0x040047C3 RID: 18371
		private uint m_SpriteID = 0U;

		// Token: 0x040047C4 RID: 18372
		private XAttributes m_Attributes = null;
	}
}
