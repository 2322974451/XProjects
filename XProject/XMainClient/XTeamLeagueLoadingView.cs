using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BF4 RID: 3060
	internal class XTeamLeagueLoadingView : DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>
	{
		// Token: 0x170030AC RID: 12460
		// (get) Token: 0x0600AE0F RID: 44559 RVA: 0x00208BFC File Offset: 0x00206DFC
		public override string fileName
		{
			get
			{
				return "Battle/TeamLeagueLoading";
			}
		}

		// Token: 0x170030AD RID: 12461
		// (get) Token: 0x0600AE10 RID: 44560 RVA: 0x00208C14 File Offset: 0x00206E14
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030AE RID: 12462
		// (get) Token: 0x0600AE11 RID: 44561 RVA: 0x00208C28 File Offset: 0x00206E28
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030AF RID: 12463
		// (get) Token: 0x0600AE12 RID: 44562 RVA: 0x00208C3C File Offset: 0x00206E3C
		public bool IsLoadingOver
		{
			get
			{
				return this._isLoadingOver;
			}
		}

		// Token: 0x170030B0 RID: 12464
		// (get) Token: 0x0600AE13 RID: 44563 RVA: 0x00208C54 File Offset: 0x00206E54
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AE14 RID: 44564 RVA: 0x00208C67 File Offset: 0x00206E67
		protected override void Init()
		{
			base.Init();
			this._isLoadingOver = false;
			this._doc = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
		}

		// Token: 0x0600AE15 RID: 44565 RVA: 0x00208C88 File Offset: 0x00206E88
		public void ShowPkLoading()
		{
			this.SetVisible(true, true);
		}

		// Token: 0x0600AE16 RID: 44566 RVA: 0x00208C94 File Offset: 0x00206E94
		protected override void OnShow()
		{
			base.OnShow();
			this.LoadingOver(null);
			this.SetBattleInfo();
		}

		// Token: 0x0600AE17 RID: 44567 RVA: 0x00208CAD File Offset: 0x00206EAD
		private void LoadingOver(object o)
		{
			this._isLoadingOver = true;
		}

		// Token: 0x0600AE18 RID: 44568 RVA: 0x00208CB8 File Offset: 0x00206EB8
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

		// Token: 0x0600AE19 RID: 44569 RVA: 0x00208DE0 File Offset: 0x00206FE0
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

		// Token: 0x0600AE1A RID: 44570 RVA: 0x00208EFB File Offset: 0x002070FB
		private void SetBattleInfo()
		{
			this.SetTeamInfo(0, this._doc.LoadingInfoBlue);
			this.SetTeamInfo(1, this._doc.LoadingInfoRed);
		}

		// Token: 0x0600AE1B RID: 44571 RVA: 0x00208F24 File Offset: 0x00207124
		public void HidePkLoading()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.SetVisible(false, true);
			}
		}

		// Token: 0x0600AE1C RID: 44572 RVA: 0x00208F4A File Offset: 0x0020714A
		private void OnPkLoadingTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x040041EE RID: 16878
		private XTeamLeagueBattleDocument _doc;

		// Token: 0x040041EF RID: 16879
		private bool _isLoadingOver = false;
	}
}
