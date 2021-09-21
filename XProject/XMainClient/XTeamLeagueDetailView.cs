using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BF1 RID: 3057
	internal class XTeamLeagueDetailView : DlgBase<XTeamLeagueDetailView, XTeamLeagueDetailBehaviour>
	{
		// Token: 0x170030AA RID: 12458
		// (get) Token: 0x0600AE03 RID: 44547 RVA: 0x00208670 File Offset: 0x00206870
		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueDetailDlg";
			}
		}

		// Token: 0x170030AB RID: 12459
		// (get) Token: 0x0600AE04 RID: 44548 RVA: 0x00208688 File Offset: 0x00206888
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AE05 RID: 44549 RVA: 0x0020869B File Offset: 0x0020689B
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600AE06 RID: 44550 RVA: 0x002086C4 File Offset: 0x002068C4
		public void ShowDetail(string teamName, List<LeagueTeamMemberDetail> members)
		{
			this.m_TeamName = teamName;
			this.m_listMember = members;
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600AE07 RID: 44551 RVA: 0x002086F8 File Offset: 0x002068F8
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_TeamName.SetText(this.m_TeamName);
			base.uiBehaviour.m_MemberPool.FakeReturnAll();
			for (int i = 0; i < this.m_listMember.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_MemberPool.FetchGameObject(false);
				gameObject.transform.parent = base.uiBehaviour.m_MemberList.gameObject.transform;
				this.SetMemberInfo(gameObject, this.m_listMember[i]);
			}
			base.uiBehaviour.m_MemberPool.ActualReturnAll(false);
			base.uiBehaviour.m_MemberList.Refresh();
		}

		// Token: 0x0600AE08 RID: 44552 RVA: 0x002087BC File Offset: 0x002069BC
		private void SetMemberInfo(GameObject tpl, LeagueTeamMemberDetail member)
		{
			IXUILabel ixuilabel = tpl.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(member.brief.name);
			IXUILabel ixuilabel2 = tpl.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(string.Format("Lv.{0}", member.brief.level));
			IXUILabel ixuilabel3 = tpl.transform.FindChild("Score").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(member.pkpoint.ToString());
			IXUISprite ixuisprite = tpl.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)member.brief.profession));
			IXUISprite ixuisprite2 = tpl.transform.FindChild("Profession").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)member.brief.profession));
		}

		// Token: 0x0600AE09 RID: 44553 RVA: 0x002088F0 File Offset: 0x00206AF0
		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x040041E0 RID: 16864
		private string m_TeamName;

		// Token: 0x040041E1 RID: 16865
		private List<LeagueTeamMemberDetail> m_listMember = new List<LeagueTeamMemberDetail>();
	}
}
