using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamInputPasswordView : DlgBase<XTeamInputPasswordView, XTeamInputPasswordBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/TeamInputPasswordDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BtnOK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClicked));
			base.uiBehaviour.m_BtnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_Input.SetText(string.Empty);
		}

		private bool _OnOKBtnClicked(IXUIButton btn)
		{
			string text = base.uiBehaviour.m_Input.GetText();
			this._doc.password = text;
			this._doc.ReqTeamOp(TeamOperate.TEAM_JOIN, (ulong)((long)this.TeamID), null, TeamMemberType.TMT_NORMAL, null);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnCloseBtnClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private XTeamDocument _doc;

		public int TeamID;
	}
}
