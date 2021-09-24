using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueCreateView : DlgBase<XTeamLeagueCreateView, XTeamLeagueCreateBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueCreateDlg";
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
			this._doc = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateBtnClicked));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		private bool OnCreateBtnClicked(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_START_BATTLE, 0UL, base.uiBehaviour.m_NameInput.GetText(), TeamMemberType.TMT_NORMAL, null);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private XFreeTeamVersusLeagueDocument _doc;
	}
}
