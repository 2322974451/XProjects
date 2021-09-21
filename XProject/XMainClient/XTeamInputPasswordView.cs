using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E66 RID: 3686
	internal class XTeamInputPasswordView : DlgBase<XTeamInputPasswordView, XTeamInputPasswordBehaviour>
	{
		// Token: 0x17003486 RID: 13446
		// (get) Token: 0x0600C58A RID: 50570 RVA: 0x002B9FDC File Offset: 0x002B81DC
		public override string fileName
		{
			get
			{
				return "Team/TeamInputPasswordDlg";
			}
		}

		// Token: 0x17003487 RID: 13447
		// (get) Token: 0x0600C58B RID: 50571 RVA: 0x002B9FF4 File Offset: 0x002B81F4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003488 RID: 13448
		// (get) Token: 0x0600C58C RID: 50572 RVA: 0x002BA008 File Offset: 0x002B8208
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003489 RID: 13449
		// (get) Token: 0x0600C58D RID: 50573 RVA: 0x002BA01C File Offset: 0x002B821C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C58E RID: 50574 RVA: 0x002BA02F File Offset: 0x002B822F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		// Token: 0x0600C58F RID: 50575 RVA: 0x002BA049 File Offset: 0x002B8249
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			base.uiBehaviour.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClicked));
		}

		// Token: 0x0600C590 RID: 50576 RVA: 0x002BA086 File Offset: 0x002B8286
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Input.SetText(string.Empty);
		}

		// Token: 0x0600C591 RID: 50577 RVA: 0x002BA0A8 File Offset: 0x002B82A8
		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = base.uiBehaviour.m_Input.GetText();
			this._doc.password = text;
			this._doc.ReqTeamOp(TeamOperate.TEAM_JOIN, (ulong)((long)this.TeamID), null, TeamMemberType.TMT_NORMAL, null);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600C592 RID: 50578 RVA: 0x002BA0F8 File Offset: 0x002B82F8
		private bool _OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0400567E RID: 22142
		private XTeamDocument _doc;

		// Token: 0x0400567F RID: 22143
		public int TeamID;
	}
}
