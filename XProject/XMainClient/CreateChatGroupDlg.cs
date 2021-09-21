using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BD5 RID: 3029
	public class CreateChatGroupDlg : DlgBase<CreateChatGroupDlg, CreateChatGroupBehaviour>
	{
		// Token: 0x1700308C RID: 12428
		// (get) Token: 0x0600AD00 RID: 44288 RVA: 0x00200888 File Offset: 0x001FEA88
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatCreateDlg";
			}
		}

		// Token: 0x1700308D RID: 12429
		// (get) Token: 0x0600AD01 RID: 44289 RVA: 0x002008A0 File Offset: 0x001FEAA0
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x1700308E RID: 12430
		// (get) Token: 0x0600AD02 RID: 44290 RVA: 0x002008B4 File Offset: 0x001FEAB4
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700308F RID: 12431
		// (get) Token: 0x0600AD03 RID: 44291 RVA: 0x002008C8 File Offset: 0x001FEAC8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AD04 RID: 44292 RVA: 0x002008DB File Offset: 0x001FEADB
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600AD05 RID: 44293 RVA: 0x002008E5 File Offset: 0x001FEAE5
		public void SetCallBack(CreatechatGroupCall handle)
		{
			this.callback = handle;
		}

		// Token: 0x0600AD06 RID: 44294 RVA: 0x002008EF File Offset: 0x001FEAEF
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoOK));
			base.uiBehaviour.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoCancel));
		}

		// Token: 0x0600AD07 RID: 44295 RVA: 0x0020092C File Offset: 0x001FEB2C
		private bool DoOK(IXUIButton go)
		{
			string text = base.uiBehaviour.m_Label.GetText();
			bool flag = this.callback != null && this.callback(text);
			if (flag)
			{
				this.SetVisible(false, true);
			}
			return true;
		}

		// Token: 0x0600AD08 RID: 44296 RVA: 0x00200976 File Offset: 0x001FEB76
		private void DoCancel(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x04004113 RID: 16659
		private CreatechatGroupCall callback;
	}
}
