using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000970 RID: 2416
	internal class XCharacterCommonMenuDocument : XDocComponent
	{
		// Token: 0x17002C6E RID: 11374
		// (get) Token: 0x06009196 RID: 37270 RVA: 0x0014E01C File Offset: 0x0014C21C
		public override uint ID
		{
			get
			{
				return XCharacterCommonMenuDocument.uuID;
			}
		}

		// Token: 0x17002C6F RID: 11375
		// (get) Token: 0x06009197 RID: 37271 RVA: 0x0014E034 File Offset: 0x0014C234
		public static CharacterCommonInfo CharacterCommonInfoTable
		{
			get
			{
				return XCharacterCommonMenuDocument.m_characterCommonInfo;
			}
		}

		// Token: 0x06009198 RID: 37272 RVA: 0x0014E04B File Offset: 0x0014C24B
		public static void Execute(OnLoadedCallback callback = null)
		{
			XCharacterCommonMenuDocument.AsyncLoader.AddTask("Table/CharacterCommonInfo", XCharacterCommonMenuDocument.m_characterCommonInfo, false);
			XCharacterCommonMenuDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009199 RID: 37273 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600919A RID: 37274 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600919B RID: 37275 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600919C RID: 37276 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600919D RID: 37277 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600919E RID: 37278 RVA: 0x0014E070 File Offset: 0x0014C270
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

		// Token: 0x0600919F RID: 37279 RVA: 0x0014E0F0 File Offset: 0x0014C2F0
		private void ReqCharacterInfo(ulong roleID)
		{
			RpcC2M_GetUnitAppearanceNew rpcC2M_GetUnitAppearanceNew = new RpcC2M_GetUnitAppearanceNew();
			rpcC2M_GetUnitAppearanceNew.oArg.roleid = roleID;
			rpcC2M_GetUnitAppearanceNew.oArg.type = 4U;
			rpcC2M_GetUnitAppearanceNew.oArg.mask = 609295;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetUnitAppearanceNew);
		}

		// Token: 0x060091A0 RID: 37280 RVA: 0x0014E13C File Offset: 0x0014C33C
		public void OnGetUnitAppearance(GetUnitAppearanceRes oRes)
		{
			bool inTutorial = XSingleton<XTutorialMgr>.singleton.InTutorial;
			if (!inTutorial)
			{
				DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.ShowMenu(oRes.UnitAppearance);
			}
		}

		// Token: 0x060091A1 RID: 37281 RVA: 0x0014E16C File Offset: 0x0014C36C
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

		// Token: 0x060091A2 RID: 37282 RVA: 0x0014E1EC File Offset: 0x0014C3EC
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

		// Token: 0x060091A3 RID: 37283 RVA: 0x0014E24C File Offset: 0x0014C44C
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

		// Token: 0x0400306C RID: 12396
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterCommonMenuDocument");

		// Token: 0x0400306D RID: 12397
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400306E RID: 12398
		private static CharacterCommonInfo m_characterCommonInfo = new CharacterCommonInfo();

		// Token: 0x0400306F RID: 12399
		public static bool IsHasRole = false;

		// Token: 0x04003070 RID: 12400
		private XUnitAppearanceTeam m_CurrentTeam = default(XUnitAppearanceTeam);
	}
}
