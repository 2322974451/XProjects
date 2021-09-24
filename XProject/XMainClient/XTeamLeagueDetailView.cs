using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamLeagueDetailView : DlgBase<XTeamLeagueDetailView, XTeamLeagueDetailBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/TeamLeague/TeamLeagueDetailDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

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

		private bool OnCloseClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private string m_TeamName;

		private List<LeagueTeamMemberDetail> m_listMember = new List<LeagueTeamMemberDetail>();
	}
}
