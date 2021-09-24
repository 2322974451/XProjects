using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMainInterfaceTeamHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_InTeamFrame = base.PanelObject.transform.Find("InTeamFrame").gameObject;
			this.m_OutTeamFrame = base.PanelObject.transform.Find("OutTeamFrame").gameObject;
			this.m_BtnCreate = (this.m_OutTeamFrame.transform.Find("BtnCreate").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnJoin = (this.m_OutTeamFrame.transform.Find("BtnJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnGroupChat = (this.m_OutTeamFrame.transform.Find("BtnGroupChat").GetComponent("XUIButton") as IXUIButton);
			this.m_MatchingGo = this.m_InTeamFrame.transform.Find("Matching").gameObject;
			this.m_RecruitRedPoint = this.m_OutTeamFrame.transform.Find("BtnGroupChat/RedPoint").gameObject;
			this.m_InTeamBg = (this.m_InTeamFrame.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_InTeamOriginHeight = this.m_InTeamBg.spriteHeight;
			Transform transform = this.m_InTeamFrame.transform.FindChild("Panel/TeammateTpl");
			this.m_TeamUIPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this._TeamDoc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
		}

		public void SetupRedPoint()
		{
			this.m_BtnGroupChat.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GroupRecruit));
			GroupChatDocument specificDocument = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this.m_RecruitRedPoint.SetActive(specificDocument.bShowMotion);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnCreate.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCreateClicked));
			this.m_BtnJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinClicked));
			this.m_BtnGroupChat.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnGroupChatClicked));
			this.m_InTeamBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnBgClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.TeamInfoChange(this._TeamDoc.MyTeam);
		}

		public void TeamInfoChange(XTeam team)
		{
			this.SetupRedPoint();
			bool flag = team == null;
			if (flag)
			{
				this._teamList.Clear();
				this.m_MaxTeamCount = 0;
				this.OnTeamInfoChanged();
			}
			else
			{
				this.m_MaxTeamCount = team.teamBrief.totalMemberCount;
				bool flag2 = team.members.Count != this._teamList.Count;
				if (flag2)
				{
					int count = this._teamList.Count;
					bool flag3 = team.members.Count < count;
					if (flag3)
					{
						for (int i = count - 1; i >= team.members.Count; i--)
						{
							this._teamList.RemoveAt(i);
						}
					}
					else
					{
						for (int j = count; j < team.members.Count; j++)
						{
							XTeamBloodUIData item = new XTeamBloodUIData();
							this._teamList.Add(item);
						}
					}
				}
				for (int k = 0; k < this._teamList.Count; k++)
				{
					this._teamList[k].uid = team.members[k].uid;
					this._teamList[k].level = (uint)team.members[k].level;
					this._teamList[k].name = team.members[k].name;
					this._teamList[k].profession = team.members[k].profession;
					this._teamList[k].bIsLeader = team.members[k].bIsLeader;
				}
				this.OnTeamInfoChanged();
			}
		}

		public void OnTeamInfoChanged()
		{
			bool flag = this._teamList.Count == 0;
			if (flag)
			{
				this.m_InTeamFrame.SetActive(false);
				this.m_OutTeamFrame.SetActive(true);
			}
			else
			{
				this.m_InTeamFrame.SetActive(true);
				this.m_OutTeamFrame.SetActive(false);
				int num = 1;
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
				if (flag2)
				{
					num = 0;
				}
				int num2 = Math.Min(this.m_MaxTeamCount - 1, this._teamList.Count - 1 + num);
				bool flag3 = this.m_Members.Count < num2;
				if (flag3)
				{
					for (int i = this.m_Members.Count; i < num2; i++)
					{
						XMainInterfaceMemberMonitor xmainInterfaceMemberMonitor = new XMainInterfaceMemberMonitor();
						GameObject gameObject = this.m_TeamUIPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(this.m_TeamUIPool.TplPos.x, this.m_TeamUIPool.TplPos.y - (float)(this.m_TeamUIPool.TplHeight * i));
						xmainInterfaceMemberMonitor.SetGo(gameObject);
						this.m_Members.Add(xmainInterfaceMemberMonitor);
					}
				}
				int j = 0;
				int num3 = 0;
				while (num3 < this._teamList.Count && j < this.m_Members.Count)
				{
					bool flag4 = this._teamList[num3].uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (!flag4)
					{
						this.m_Members[j].SetMemberData(this._teamList[num3]);
						this.m_Members[j].SetActive(true);
						j++;
					}
					num3++;
				}
				while (j < num2)
				{
					this.m_Members[j].SetMemberData(null);
					this.m_Members[j].SetActive(true);
					j++;
				}
				this.m_PreActiveCount = j;
				while (j < this.m_Members.Count)
				{
					this.m_Members[j].SetActive(false);
					j++;
				}
				this.m_InTeamBg.spriteHeight = this.m_InTeamOriginHeight + (num2 - 1) * this.m_TeamUIPool.TplHeight;
				bool flag5 = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
				if (flag5)
				{
					this.m_MatchingGo.SetActive(false);
				}
				else
				{
					this.m_MatchingGo.SetActive(this._teamList.Count < this.m_MaxTeamCount);
				}
			}
		}

		private bool _OnGroupChatClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruit, 0UL);
			return true;
		}

		private bool _OnCreateClicked(IXUIButton btn)
		{
			DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
			return true;
		}

		private void _OnBgClicked(IXUISprite iSp)
		{
			DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
		}

		private bool _OnJoinClicked(IXUIButton btn)
		{
			DlgBase<XTeamListView, XTeamListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private GameObject m_InTeamFrame;

		private GameObject m_OutTeamFrame;

		private GameObject m_MatchingGo;

		private GameObject m_RecruitRedPoint;

		private IXUIButton m_BtnCreate;

		private IXUIButton m_BtnJoin;

		private IXUIButton m_BtnGroupChat;

		private IXUISprite m_InTeamBg;

		private int m_InTeamOriginHeight;

		private XTeamDocument _TeamDoc;

		private XUIPool m_TeamUIPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<XMainInterfaceMemberMonitor> m_Members = new List<XMainInterfaceMemberMonitor>();

		private List<XTeamBloodUIData> _teamList = new List<XTeamBloodUIData>();

		private int m_MaxTeamCount;

		private int m_PreActiveCount = 0;
	}
}
