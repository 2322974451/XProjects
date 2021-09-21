using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018A9 RID: 6313
	internal class XGuildMembersView : DlgBase<XGuildMembersView, XGuildMembersBehaviour>
	{
		// Token: 0x17003A13 RID: 14867
		// (get) Token: 0x06010720 RID: 67360 RVA: 0x00405C94 File Offset: 0x00403E94
		public override string fileName
		{
			get
			{
				return "Guild/GuildMembersDlg";
			}
		}

		// Token: 0x17003A14 RID: 14868
		// (get) Token: 0x06010721 RID: 67361 RVA: 0x00405CAC File Offset: 0x00403EAC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A15 RID: 14869
		// (get) Token: 0x06010722 RID: 67362 RVA: 0x00405CC0 File Offset: 0x00403EC0
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A16 RID: 14870
		// (get) Token: 0x06010723 RID: 67363 RVA: 0x00405CD4 File Offset: 0x00403ED4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A17 RID: 14871
		// (get) Token: 0x06010724 RID: 67364 RVA: 0x00405CE8 File Offset: 0x00403EE8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A18 RID: 14872
		// (get) Token: 0x06010725 RID: 67365 RVA: 0x00405CFC File Offset: 0x00403EFC
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010726 RID: 67366 RVA: 0x00405D0F File Offset: 0x00403F0F
		protected override void Init()
		{
			this._MemberDoc = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
			this._MemberDoc.GuildMembersView = this;
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		// Token: 0x06010727 RID: 67367 RVA: 0x00405D3F File Offset: 0x00403F3F
		protected override void OnUnload()
		{
			this._MemberDoc.GuildMembersView = null;
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref base.uiBehaviour.m_TitleBar);
			base.OnUnload();
		}

		// Token: 0x06010728 RID: 67368 RVA: 0x00405D68 File Offset: 0x00403F68
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentItemInit));
			base.uiBehaviour.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
		}

		// Token: 0x06010729 RID: 67369 RVA: 0x00405DEA File Offset: 0x00403FEA
		protected override void OnShow()
		{
			this._MemberDoc.ReqMemberList();
			base.uiBehaviour.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<GuildMemberSortType>.ToInt(this._MemberDoc.SortType)));
		}

		// Token: 0x0601072A RID: 67370 RVA: 0x00405E1C File Offset: 0x0040401C
		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this._MemberDoc.SortType = (GuildMemberSortType)ID;
			this._MemberDoc.SortAndShow();
			return this._MemberDoc.SortDirection > 0;
		}

		// Token: 0x0601072B RID: 67371 RVA: 0x00405E58 File Offset: 0x00404058
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

		// Token: 0x0601072C RID: 67372 RVA: 0x00405EA2 File Offset: 0x004040A2
		public void Refresh()
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0601072D RID: 67373 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshFatigue()
		{
		}

		// Token: 0x0601072E RID: 67374 RVA: 0x00405EA2 File Offset: 0x004040A2
		public void OnRefreshDailyTaskReply()
		{
			base.uiBehaviour.m_WrapContent.RefreshAllVisibleContents();
		}

		// Token: 0x0601072F RID: 67375 RVA: 0x00405EB8 File Offset: 0x004040B8
		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
			IXUIButton ixuibutton = t.FindChild("Inherit").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnInheritClick));
			IXUIButton ixuibutton2 = t.FindChild("BtnTask").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRefreshClick));
		}

		// Token: 0x06010730 RID: 67376 RVA: 0x00405F48 File Offset: 0x00404148
		private bool _OnRefreshClick(IXUIButton button)
		{
			XGuildDailyTaskDocument.Doc.SendToRefreshTaskOp(DailyRefreshOperType.DROT_Refresh, button.ID);
			return true;
		}

		// Token: 0x06010731 RID: 67377 RVA: 0x00405F70 File Offset: 0x00404170
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

		// Token: 0x06010732 RID: 67378 RVA: 0x00406214 File Offset: 0x00404414
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010733 RID: 67379 RVA: 0x00406230 File Offset: 0x00404430
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

		// Token: 0x06010734 RID: 67380 RVA: 0x00406290 File Offset: 0x00404490
		private bool _OnOneKeyReceive(IXUIButton go)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._MemberDoc.ReqOneKeyReceiveFatigue();
			return true;
		}

		// Token: 0x06010735 RID: 67381 RVA: 0x004062BC File Offset: 0x004044BC
		private bool _OnOneKeySendBtnClick(IXUIButton go)
		{
			this._MemberDoc.ReqOneKeySendFatigue();
			return true;
		}

		// Token: 0x06010736 RID: 67382 RVA: 0x004062DC File Offset: 0x004044DC
		private bool _OnReceiveBtnClick(IXUIButton btn)
		{
			this._MemberDoc.ReqReceiveFatigue((int)btn.ID);
			return true;
		}

		// Token: 0x06010737 RID: 67383 RVA: 0x00406304 File Offset: 0x00404504
		private bool _OnSendBtnClick(IXUIButton btn)
		{
			this._MemberDoc.ReqSendFatigue((int)btn.ID);
			return true;
		}

		// Token: 0x06010738 RID: 67384 RVA: 0x0040632C File Offset: 0x0040452C
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

		// Token: 0x06010739 RID: 67385 RVA: 0x004065E4 File Offset: 0x004047E4
		private bool _PKClick(IXUIButton btn)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.SendPKInvitation(this.m_SelectedMemberID);
			return true;
		}

		// Token: 0x0601073A RID: 67386 RVA: 0x00406610 File Offset: 0x00404810
		private bool _HigherPositionClick(IXUIButton btn)
		{
			DlgBase<GuildPositionMenu, GuildPositionBehaviour>.singleton.ShowMenu(this.m_SelectedMemberID);
			return true;
		}

		// Token: 0x0601073B RID: 67387 RVA: 0x00406634 File Offset: 0x00404834
		private bool _HigherPosition(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._MemberDoc.ReqChangePosition(this.m_SelectedMemberID, true);
			return true;
		}

		// Token: 0x0601073C RID: 67388 RVA: 0x00406668 File Offset: 0x00404868
		private bool _LowerPositionClick(IXUIButton btn)
		{
			this._MemberDoc.ReqChangePosition(this.m_SelectedMemberID, false);
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0601073D RID: 67389 RVA: 0x0040669C File Offset: 0x0040489C
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

		// Token: 0x0601073E RID: 67390 RVA: 0x004066DC File Offset: 0x004048DC
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

		// Token: 0x0601073F RID: 67391 RVA: 0x00406734 File Offset: 0x00404934
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

		// Token: 0x06010740 RID: 67392 RVA: 0x004067E4 File Offset: 0x004049E4
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

		// Token: 0x06010741 RID: 67393 RVA: 0x00406860 File Offset: 0x00404A60
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

		// Token: 0x040076D1 RID: 30417
		public static readonly Color TitleUnSelectedColor = new Color(0.60784316f, 0.60784316f, 0.60784316f);

		// Token: 0x040076D2 RID: 30418
		public static readonly Color TitleSelectedColor = Color.white;

		// Token: 0x040076D3 RID: 30419
		private XGuildMemberDocument _MemberDoc;

		// Token: 0x040076D4 RID: 30420
		private XGuildDocument _GuildDoc;

		// Token: 0x040076D5 RID: 30421
		private XGuildMemberInfoDisplay _MemberInfoDisplay = new XGuildMemberInfoDisplay();

		// Token: 0x040076D6 RID: 30422
		private GuildPosition m_SelectedHigherPosition;

		// Token: 0x040076D7 RID: 30423
		private GuildPosition m_SelectedLowerPosition;

		// Token: 0x040076D8 RID: 30424
		private ulong m_SelectedMemberID;

		// Token: 0x040076D9 RID: 30425
		private string m_SelectedName;

		// Token: 0x040076DA RID: 30426
		private XGuildMember m_SelectMember;
	}
}
