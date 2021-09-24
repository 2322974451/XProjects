using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterCommonMenuDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCharacterCommonMenuDocument.uuID;
			}
		}

		public static CharacterCommonInfo CharacterCommonInfoTable
		{
			get
			{
				return XCharacterCommonMenuDocument.m_characterCommonInfo;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XCharacterCommonMenuDocument.AsyncLoader.AddTask("Table/CharacterCommonInfo", XCharacterCommonMenuDocument.m_characterCommonInfo, false);
			XCharacterCommonMenuDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public static void ReqCharacterMenuInfo(ulong roleID, bool isHasRole = false)
		{
			XCharacterCommonMenuDocument.IsHasRole = isHasRole;
			bool flag = roleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_READY;
				if (!flag2)
				{
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mentorship);
					if (flag3)
					{
						XMentorshipDocument.Doc.ClickedMainSceneRoleID = roleID;
						XMentorshipDocument.Doc.SendGetOtherMentorStatus(roleID);
					}
					XCharacterCommonMenuDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterCommonMenuDocument>(XCharacterCommonMenuDocument.uuID);
					specificDocument.ReqCharacterInfo(roleID);
				}
			}
		}

		private void ReqCharacterInfo(ulong roleID)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = roleID;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 4U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 609295;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		public void OnGetUnitAppearance(GetUnitAppearanceRes oRes)
		{
			bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
			if (!inTutorial)
			{
				DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.ShowMenu(oRes.UnitAppearance);
			}
		}

		public void TryJoinTeam(XUnitAppearanceTeam teamInfo)
		{
			bool flag = !teamInfo.bHasTeam;
			if (!flag)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool bInTeam = specificDocument.bInTeam;
				if (bInTeam)
				{
					this.m_CurrentTeam = teamInfo;
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TeamLeaveAndJoinConfirm"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._DoLeaveTeam));
				}
				else
				{
					XTeamView.TryJoinTeam((int)teamInfo.teamID, teamInfo.bPwd);
				}
			}
		}

		private bool _DoLeaveTeam(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			ulong num = (ulong)this.m_CurrentTeam.teamID;
			bool bPwd = this.m_CurrentTeam.bPwd;
			if (bPwd)
			{
				num |= 4294967296UL;
			}
			specificDocument.ReqTeamOp(TeamOperate.TEAM_LEAVE, num, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		public void TryInviteTeam(ulong roleID)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			if (bInTeam)
			{
				bool flag = specificDocument.MyTeam.members.Count >= specificDocument.currentExpInfo.PlayerNumber;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_FULL, "fece00");
				}
				else
				{
					specificDocument.ReqTeamOp(TeamOperate.TEAM_INVITE, roleID, null, TeamMemberType.TMT_NORMAL, null);
				}
			}
			else
			{
				specificDocument.TryAutoSelectExp();
				specificDocument.ReqTeamOp(TeamOperate.TEAM_CREATE, roleID, null, TeamMemberType.TMT_NORMAL, null);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterCommonMenuDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static CharacterCommonInfo m_characterCommonInfo = new CharacterCommonInfo();

		public static bool IsHasRole = false;

		private XUnitAppearanceTeam m_CurrentTeam = default(XUnitAppearanceTeam);
	}
}
