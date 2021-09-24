using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildMembersView : DlgBase<XGuildMembersView, XGuildMembersBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildMembersDlg";
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._MemberDoc = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
			this._MemberDoc.GuildMembersView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		protected override void OnUnload()
		{
			this._MemberDoc.GuildMembersView = null;
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref base.uiBehaviour.m_TitleBar);
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentItemInit));
			base.uiBehaviour.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
		}

		protected override void OnShow()
		{
			this._MemberDoc.ReqMemberList();
			base.uiBehaviour.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<GuildMemberSortType>.ToInt(this._MemberDoc.SortType)));
		}

		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this._MemberDoc.SortType = (GuildMemberSortType)ID;
			this._MemberDoc.SortAndShow();
			return this._MemberDoc.SortDirection > 0;
		}

		public void RefreshAll(bool bResetPosition = true)
		{
			List<XGuildMember> memberList = this._MemberDoc.MemberList;
			int count = memberList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				base.uiBehaviour.m_ScrollView.ResetPosition();
			}
		}

		public void Refresh()
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		public void RefreshFatigue()
		{
		}

		public void OnRefreshDailyTaskReply()
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
			IXUIButton ixuibutton = t.FindChild("Inherit").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnInheritClick));
			IXUIButton ixuibutton2 = t.FindChild("BtnTask").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRefreshClick));
		}

		private bool _OnRefreshClick(IXUIButton button)
		{
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refresh, button.ID);
			return true;
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._MemberDoc.MemberList.Count;
			if (!flag)
			{
				XGuildMember xguildMember = this._MemberDoc.MemberList[index];
				ulong entityID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject = t.FindChild("PlayerBg").gameObject;
				IXUILabel ixuilabel = t.FindChild("Contribution").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("LastLoginTime").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("LuckLevel").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = t.FindChild("Inherit").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)index);
				this._MemberInfoDisplay.Init(t, false);
				this._MemberInfoDisplay.Set(xguildMember);
				ixuibutton.SetVisible(xguildMember.isInherit);
				List<string> stringList = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevel");
				int index2 = Mathf.Min((int)(xguildMember.taskLuck - 1U), stringList.Count - 1);
				ixuilabel3.SetText(stringList[index2]);
				List<string> stringList2 = XSingleton<XGlobalConfig>.singleton.GetStringList("LuckyLevelColor");
				Color color = XSingleton<UiUtility>.singleton.ConvertRGBStringToColor(stringList2[index2]);
				ixuilabel3.SetColor(color);
				IXUIButton ixuibutton2 = t.FindChild("BtnTask").GetComponent("XUIButton") as IXUIButton;
				ixuibutton2.SetEnable(xguildMember.canRefresh && xguildMember.taskScore < 4U, false);
				ixuibutton2.ID = xguildMember.uid;
				IXUISprite ixuisprite2 = t.Find("BtnTask/TaskLevel").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(ixuisprite2.spriteName.Substring(0, ixuisprite2.spriteName.Length - 1) + xguildMember.taskScore);
				ixuilabel.SetText(xguildMember.contribution.ToString());
				bool flag2 = this._GuildDoc.Position == GuildPosition.GPOS_LEADER || this._GuildDoc.Position == GuildPosition.GPOS_VICELEADER;
				if (flag2)
				{
					ixuilabel2.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString(xguildMember.time));
				}
				else
				{
					ixuilabel2.SetText(XSingleton<UiUtility>.singleton.TimeOnOrOutFromString(xguildMember.time));
				}
				ixuisprite.ID = (ulong)((long)index);
				gameObject.SetActive(entityID == xguildMember.uid);
			}
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnOneKeyReceiveBtnClick(IXUIButton go)
		{
			bool flag = !this._GuildDoc.bInGuild;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_ONEKEY_RECEIVE_FATIGUE_CONFIRM"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._OnOneKeyReceive));
				result = true;
			}
			return result;
		}

		private bool _OnOneKeyReceive(IXUIButton go)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._MemberDoc.ReqOneKeyReceiveFatigue();
			return true;
		}

		private bool _OnOneKeySendBtnClick(IXUIButton go)
		{
			this._MemberDoc.ReqOneKeySendFatigue();
			return true;
		}

		private bool _OnReceiveBtnClick(IXUIButton btn)
		{
			this._MemberDoc.ReqReceiveFatigue((int)btn.ID);
			return true;
		}

		private bool _OnSendBtnClick(IXUIButton btn)
		{
			this._MemberDoc.ReqSendFatigue((int)btn.ID);
			return true;
		}

		private void _OnMemberClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this._MemberDoc.MemberList.Count;
			if (!flag)
			{
				XGuildMember xguildMember = this._MemberDoc.MemberList[num];
				bool flag2 = xguildMember.uid == XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				if (!flag2)
				{
					this.m_SelectMember = xguildMember;
					this.m_SelectedName = xguildMember.name;
					this.m_SelectedMemberID = xguildMember.uid;
					GuildPosition position = xguildMember.position;
					this.m_SelectedHigherPosition = (GuildPosition)XGuildDocument.GuildPP.GetHigherPosition(position);
					this.m_SelectedLowerPosition = (GuildPosition)XGuildDocument.GuildPP.GetLowerPosition(position);
					GuildPermission setPositionPermission = XGuildDocument.GuildPP.GetSetPositionPermission(this.m_SelectedHigherPosition, this.m_SelectedHigherPosition);
					GuildPermission setPositionPermission2 = XGuildDocument.GuildPP.GetSetPositionPermission(position, this.m_SelectedLowerPosition);
					List<string> list = new List<string>();
					List<ButtonClickEventHandler> list2 = new List<ButtonClickEventHandler>();
					list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_VIEW"));
					list2.Add(new ButtonClickEventHandler(DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowDetailInfo));
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends);
					if (flag3)
					{
						list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_ADDFRIEND"));
						list2.Add(new ButtonClickEventHandler(DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.AddFriend));
					}
					list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_SENDFLOWER"));
					list2.Add(new ButtonClickEventHandler(DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SendFlower));
					list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_PRIVATECHAT"));
					list2.Add(new ButtonClickEventHandler(DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.PrivateChat));
					bool flag4 = this._GuildDoc.IHavePermission(setPositionPermission) || this._GuildDoc.IHavePermission(setPositionPermission2);
					if (flag4)
					{
						list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_INCREASEPOSITION"));
						list2.Add(new ButtonClickEventHandler(this._HigherPositionClick));
					}
					bool flag5 = this._GuildDoc.IHavePermission(GuildPermission.GPEM_FIREMEMBER);
					if (flag5)
					{
						list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_FIREFROMGUILD"));
						list2.Add(new ButtonClickEventHandler(this._OnKickAssBtnClick));
					}
					bool isInherit = xguildMember.isInherit;
					if (isInherit)
					{
						list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_INHERIT"));
						list2.Add(new ButtonClickEventHandler(this._OnInheritDialog));
					}
					list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_PK"));
					list2.Add(new ButtonClickEventHandler(this._PKClick));
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowMenuUI(xguildMember.uid, xguildMember.name, list, list2, 0U, (uint)xguildMember.profession);
				}
			}
		}

		private bool _PKClick(IXUIButton btn)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.SendPKInvitation(this.m_SelectedMemberID);
			return true;
		}

		private bool _HigherPositionClick(IXUIButton btn)
		{
			DlgBase<GuildPositionMenu, GuildPositionBehaviour>.singleton.ShowMenu(this.m_SelectedMemberID);
			return true;
		}

		private bool _HigherPosition(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._MemberDoc.ReqChangePosition(this.m_SelectedMemberID, true);
			return true;
		}

		private bool _LowerPositionClick(IXUIButton btn)
		{
			this._MemberDoc.ReqChangePosition(this.m_SelectedMemberID, false);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnInheritDialog(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			bool flag = this.m_SelectMember == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.RequestInherit(this.m_SelectMember);
				result = false;
			}
			return result;
		}

		private bool _OnInheritClick(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num < 0 || num >= this._MemberDoc.MemberList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.RequestInherit(this._MemberDoc.MemberList[num]);
				result = true;
			}
			return result;
		}

		private void RequestInherit(XGuildMember member)
		{
			bool flag = member == null;
			if (!flag)
			{
				bool flag2 = member.uid == XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				if (!flag2)
				{
					bool flag3 = member.time >= 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TEAM_INV_LOGOUT"), "fece00");
					}
					else
					{
						bool flag4 = !member.isInherit;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_GUILD_INHERIT_LVL"), "fece00");
						}
						else
						{
							XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
							specificDocument.SendReqInherit(member.uid);
						}
					}
				}
			}
		}

		private bool _OnKickAssBtnClick(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			bool flag = !this._GuildDoc.CheckPermission(GuildPermission.GPEM_FIREMEMBER);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_FIREMEMBER_CONFIRM", new object[]
				{
					this.m_SelectedName
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._KickAss));
				result = true;
			}
			return result;
		}

		private bool _KickAss(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = !this._GuildDoc.CheckPermission(GuildPermission.GPEM_FIREMEMBER);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._MemberDoc.ReqKickAss(this.m_SelectedMemberID);
				result = true;
			}
			return result;
		}

		public static readonly Color TitleUnSelectedColor = new Color(0.60784316f, 0.60784316f, 0.60784316f);

		public static readonly Color TitleSelectedColor = Color.white;

		private XGuildMemberDocument _MemberDoc;

		private XGuildDocument _GuildDoc;

		private XGuildMemberInfoDisplay _MemberInfoDisplay = new XGuildMemberInfoDisplay();

		private GuildPosition m_SelectedHigherPosition;

		private GuildPosition m_SelectedLowerPosition;

		private ulong m_SelectedMemberID;

		private string m_SelectedName;

		private XGuildMember m_SelectMember;
	}
}
