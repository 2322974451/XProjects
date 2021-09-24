using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamLeagueLoadingView : DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/TeamLeagueLoading";
			}
		}

		public override int layer
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

		public bool IsLoadingOver
		{
			get
			{
				return this._isLoadingOver;
			}
		}

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._isLoadingOver = false;
			this._doc = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
		}

		public void ShowPkLoading()
		{
			this.SetVisible(true, true);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.LoadingOver(null);
			this.SetBattleInfo();
		}

		private void LoadingOver(object o)
		{
			this._isLoadingOver = true;
		}

		private void SetMemberInfo(GameObject member, LeagueBattleRoleBrief info)
		{
			bool flag = info == null;
			if (!flag)
			{
				IXUILabel ixuilabel = member.transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = member.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = member.transform.Find("Profession").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = member.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = member.transform.Find("PPT").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(info.level.ToString());
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)info.profession));
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)info.profession));
				ixuilabel2.SetText(info.name);
				ixuilabel3.SetText(info.pkpoint.ToString());
			}
		}

		private void SetTeamInfo(int index, LeagueBattleTeamData BattleTeam)
		{
			bool flag = BattleTeam == null;
			if (!flag)
			{
				base.uiBehaviour.m_TeamName[index].SetText(BattleTeam.name);
				base.uiBehaviour.m_TeamRegion[index].SetText(BattleTeam.servername);
				base.uiBehaviour.m_MembersPool[index].FakeReturnAll();
				for (int i = 0; i < BattleTeam.members.Count; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_MembersPool[index].FetchGameObject(false);
					this.SetMemberInfo(gameObject, BattleTeam.members[i]);
					bool flag2 = i < base.uiBehaviour.m_RightMemberNode.Count;
					if (flag2)
					{
						gameObject.transform.parent = ((index == 0) ? base.uiBehaviour.m_LeftMemberNode[i] : base.uiBehaviour.m_RightMemberNode[i]);
					}
					gameObject.transform.localPosition = Vector3.zero;
				}
				base.uiBehaviour.m_MembersPool[index].ActualReturnAll(false);
			}
		}

		private void SetBattleInfo()
		{
			this.SetTeamInfo(0, this._doc.LoadingInfoBlue);
			this.SetTeamInfo(1, this._doc.LoadingInfoRed);
		}

		public void HidePkLoading()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.SetVisible(false, true);
			}
		}

		private void OnPkLoadingTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		private XTeamLeagueBattleDocument _doc;

		private bool _isLoadingOver = false;
	}
}
