using System;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020017CF RID: 6095
	internal class MobaEndDlg : DlgBase<MobaEndDlg, MobaBehaviour>
	{
		// Token: 0x170038A0 RID: 14496
		// (get) Token: 0x0600FC7E RID: 64638 RVA: 0x003AEAA0 File Offset: 0x003ACCA0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038A1 RID: 14497
		// (get) Token: 0x0600FC7F RID: 64639 RVA: 0x003AEAB4 File Offset: 0x003ACCB4
		public override string fileName
		{
			get
			{
				return "GameSystem/MobaEndDlg";
			}
		}

		// Token: 0x0600FC80 RID: 64640 RVA: 0x003AEACB File Offset: 0x003ACCCB
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600FC81 RID: 64641 RVA: 0x003AEAD5 File Offset: 0x003ACCD5
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FC82 RID: 64642 RVA: 0x003AEADF File Offset: 0x003ACCDF
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600FC83 RID: 64643 RVA: 0x003AEAEC File Offset: 0x003ACCEC
		public void SetPic(bool isWin)
		{
			if (isWin)
			{
				base.uiBehaviour.m_Texture.SetTexturePath("atlas/UI/Battle/victery");
			}
			else
			{
				base.uiBehaviour.m_Texture.SetTexturePath("atlas/UI/Battle/failure");
			}
		}

		// Token: 0x0600FC84 RID: 64644 RVA: 0x003AEB2D File Offset: 0x003ACD2D
		protected override void OnHide()
		{
			base.uiBehaviour.m_Texture.SetTexturePath("");
			base.OnHide();
		}

		// Token: 0x0600FC85 RID: 64645 RVA: 0x003AEB4D File Offset: 0x003ACD4D
		protected override void OnUnload()
		{
			base.OnUnload();
		}
	}
}
