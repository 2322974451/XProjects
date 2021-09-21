using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BEF RID: 3055
	internal class XTeamLeagueCreateView : DlgBase<XTeamLeagueCreateView, XTeamLeagueCreateBehaviour>
	{
		// Token: 0x170030A8 RID: 12456
		// (get) Token: 0x0600ADFA RID: 44538 RVA: 0x00208484 File Offset: 0x00206684
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueCreateDlg";
			}
		}

		// Token: 0x170030A9 RID: 12457
		// (get) Token: 0x0600ADFB RID: 44539 RVA: 0x0020849C File Offset: 0x0020669C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600ADFC RID: 44540 RVA: 0x002084AF File Offset: 0x002066AF
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
		}

		// Token: 0x0600ADFD RID: 44541 RVA: 0x002084CC File Offset: 0x002066CC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateBtnClicked));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600ADFE RID: 44542 RVA: 0x00208538 File Offset: 0x00206738
		private bool OnCreateBtnClicked(IXUIButton button)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.ReqTeamOp(TeamOperate.TEAM_START_BATTLE, 0UL, base.uiBehaviour.m_NameInput.GetText(), TeamMemberType.TMT_NORMAL, null);
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600ADFF RID: 44543 RVA: 0x0020857C File Offset: 0x0020677C
		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040041DB RID: 16859
		private XFreeTeamVersusLeagueDocument _doc;
	}
}
