using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C6E RID: 3182
	internal class InGameADView : DlgBase<InGameADView, InGameADBehaviour>
	{
		// Token: 0x170031E0 RID: 12768
		// (get) Token: 0x0600B40B RID: 46091 RVA: 0x00231DE0 File Offset: 0x0022FFE0
		private uint npcID
		{
			get
			{
				return uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InGameADNPCID"));
			}
		}

		// Token: 0x170031E1 RID: 12769
		// (get) Token: 0x0600B40C RID: 46092 RVA: 0x00231E08 File Offset: 0x00230008
		private string tex
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetValue("InGameADTex");
			}
		}

		// Token: 0x170031E2 RID: 12770
		// (get) Token: 0x0600B40D RID: 46093 RVA: 0x00231E2C File Offset: 0x0023002C
		public override string fileName
		{
			get
			{
				return "GameSystem/InGameAD";
			}
		}

		// Token: 0x170031E3 RID: 12771
		// (get) Token: 0x0600B40E RID: 46094 RVA: 0x00231E44 File Offset: 0x00230044
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031E4 RID: 12772
		// (get) Token: 0x0600B40F RID: 46095 RVA: 0x00231E58 File Offset: 0x00230058
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031E5 RID: 12773
		// (get) Token: 0x0600B410 RID: 46096 RVA: 0x00231E6C File Offset: 0x0023006C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B411 RID: 46097 RVA: 0x00231E7F File Offset: 0x0023007F
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_BtnGo.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGoClick));
		}

		// Token: 0x0600B412 RID: 46098 RVA: 0x00231EBC File Offset: 0x002300BC
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B413 RID: 46099 RVA: 0x00231ED8 File Offset: 0x002300D8
		public void OnGoClick(IXUISprite btn)
		{
			XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(this.npcID);
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x0600B414 RID: 46100 RVA: 0x00231EFF File Offset: 0x002300FF
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Tex.SetTexturePath(this.tex);
		}

		// Token: 0x0600B415 RID: 46101 RVA: 0x00231F20 File Offset: 0x00230120
		protected override void OnHide()
		{
			base.uiBehaviour.m_Tex.SetTexturePath("");
			base.OnHide();
		}

		// Token: 0x0600B416 RID: 46102 RVA: 0x00231F40 File Offset: 0x00230140
		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}
