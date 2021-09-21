using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A50 RID: 2640
	internal class XDragonGuildMainHandler : DlgHandlerBase
	{
		// Token: 0x17002EED RID: 12013
		// (get) Token: 0x0600A018 RID: 40984 RVA: 0x001AA848 File Offset: 0x001A8A48
		protected override string FileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopMenberDlg";
			}
		}

		// Token: 0x0600A019 RID: 40985 RVA: 0x001AA860 File Offset: 0x001A8A60
		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_DragonGuildName = (base.transform.Find("Bg/Status/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_DragonGuildMemberCount = (base.transform.Find("Bg/Status/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_DragonGuildLevel = (base.transform.Find("Bg/Status/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_DragonGuildTotalPPT = (base.transform.Find("Bg/Status/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_DragonGuildTeamLeaderName = (base.transform.Find("Bg/Status/Leader").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform.gameObject, null, true);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			DlgHandlerBase.EnsureCreate<XDragonGuildMainBonusView>(ref this.m_BonusView, base.transform.Find("Bg/TroopBonusPop").gameObject, this, true);
			this.m_BonusButton = (base.transform.FindChild("Bg/MenuList/BtnTroopBonus").GetComponent("XUIButton") as IXUIButton);
			this.m_DismissButton = (base.transform.Find("Bg/MenuList/BtnDismiss").GetComponent("XUIButton") as IXUIButton);
			this.m_LeaveButton = (base.transform.Find("Bg/MenuList/BtnLeave").GetComponent("XUIButton") as IXUIButton);
			this.m_StoreButton = (base.transform.Find("Bg/MenuList/BtnTroopStore").GetComponent("XUIButton") as IXUIButton);
			this.m_RecordButton = (base.transform.Find("Bg/MenuList/BtnTroopRecord").GetComponent("XUIButton") as IXUIButton);
			this.m_RankButton = (base.transform.Find("Bg/MenuList/BtnTroopRank").GetComponent("XUIButton") as IXUIButton);
			this.m_AuthoriseButton = (base.transform.Find("Bg/MenuList/BtnTroopAuthorise").GetComponent("XUIButton") as IXUIButton);
			this.m_LivenessRewardButton = (base.transform.Find("Bg/MenuList/BtnTroopReward").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnWXGroup = (base.transform.Find("Bg/MenuList/BtnTroopWeChat").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnWXGroupText = (base.transform.Find("Bg/MenuList/BtnTroopWeChat/T").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnQQGroup = (base.transform.Find("Bg/MenuList/BtnTroopQQ").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnQQGroupText = (base.transform.Find("Bg/MenuList/BtnTroopQQ/T").GetComponent("XUILabel") as IXUILabel);
			this.m_QQGroupName = (base.transform.Find("Bg/MenuList/BtnTroopQQ/QQGroupInfo").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600A01A RID: 40986 RVA: 0x001AABD4 File Offset: 0x001A8DD4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnHelpBtnClick));
			this.m_StoreButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopButtonClick));
			this.m_LivenessRewardButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLivenessButtonClick));
			this.m_RecordButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecordButtonClick));
			this.m_RankButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnRankBtnClick));
			this.m_AuthoriseButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnAuthoriseBtnClick));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			this.m_TitleBar.RegisterClickEventHandler(new TitleClickEventHandler(this._OnTitleClickEventHandler));
			this.m_LeaveButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnLeaveBtnClick));
			this.m_DismissButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDismissBtnClick));
			this.m_BtnWXGroup.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnWXGroupBtnClick));
			this.m_BtnQQGroup.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnQQGroupBtnClick));
			this.m_BonusButton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnBonusBtnClick));
		}

		// Token: 0x0600A01B RID: 40987 RVA: 0x001AAD3C File Offset: 0x001A8F3C
		private bool _OnHelpBtnClick(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildCollectSummon);
			return true;
		}

		// Token: 0x0600A01C RID: 40988 RVA: 0x001AAD5F File Offset: 0x001A8F5F
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref this.m_TitleBar);
			DlgHandlerBase.EnsureUnload<XDragonGuildMainBonusView>(ref this.m_BonusView);
			base.OnUnload();
		}

		// Token: 0x0600A01D RID: 40989 RVA: 0x001AAD84 File Offset: 0x001A8F84
		private bool _OnBonusBtnClick(IXUIButton button)
		{
			this.m_BonusView.SetVisible(true);
			return true;
		}

		// Token: 0x0600A01E RID: 40990 RVA: 0x001AADA4 File Offset: 0x001A8FA4
		private bool _OnAuthoriseBtnClick(IXUIButton button)
		{
			DlgBase<XDragonGuildApproveDlg, XDragonGuildApproveBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600A01F RID: 40991 RVA: 0x001AADC4 File Offset: 0x001A8FC4
		private bool _OnRankBtnClick(IXUIButton go)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_DragonGuild);
			return true;
		}

		// Token: 0x0600A020 RID: 40992 RVA: 0x001AADE8 File Offset: 0x001A8FE8
		private bool _OnDismissBtnClick(IXUIButton button)
		{
			string @string = XStringDefineProxy.GetString("DRAGON_GUILD_DISMISS_TIP");
			string string2 = XStringDefineProxy.GetString("COMMON_OK");
			string string3 = XStringDefineProxy.GetString("COMMON_CANCEL");
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this._OnLeaveBtnClick), null);
			return true;
		}

		// Token: 0x0600A021 RID: 40993 RVA: 0x001AAE5C File Offset: 0x001A905C
		private bool _OnLeaveBtnClick(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqLeaveDragonGuild();
			return true;
		}

		// Token: 0x0600A022 RID: 40994 RVA: 0x001AAE88 File Offset: 0x001A9088
		protected override void OnShow()
		{
			this.m_doc.ReqMemberList();
			this.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<DragonGuildMemberSortType>.ToInt(this.m_doc.SortType)));
			this.m_BonusView.SetVisible(false);
			this.m_doc.QueryWXGroup();
			this.m_doc.QueryQQGroup();
		}

		// Token: 0x0600A023 RID: 40995 RVA: 0x001AAEE4 File Offset: 0x001A90E4
		public bool OnRecordButtonClick(IXUIButton btn)
		{
			DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600A024 RID: 40996 RVA: 0x001AAF04 File Offset: 0x001A9104
		public bool OnShopButtonClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_DragonGuildShop, 0UL);
			return true;
		}

		// Token: 0x0600A025 RID: 40997 RVA: 0x001AAF2C File Offset: 0x001A912C
		public bool OnLivenessButtonClick(IXUIButton btn)
		{
			DlgBase<DragonGuildLivenessDlg, DragonGuildLivenessBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600A026 RID: 40998 RVA: 0x001AAF4C File Offset: 0x001A914C
		public void RefreshPage()
		{
			this.RefreshMemberList(true);
			this.RefreshButtonsState();
			this.RefreshLabelInfo();
			this.RefreshUIRedPoint();
			this.RefreshWXGroupBtn();
			this.RefreshQQGroupBtn();
		}

		// Token: 0x0600A027 RID: 40999 RVA: 0x001AAF7C File Offset: 0x001A917C
		public void RefreshLabelInfo()
		{
			this.m_DragonGuildName.SetText(this.m_doc.BaseData.dragonGuildName);
			this.m_DragonGuildLevel.SetText(this.m_doc.BaseData.level.ToString());
			this.m_DragonGuildMemberCount.SetText(string.Format("{0}/{1}", this.m_doc.BaseData.memberCount, this.m_doc.BaseData.maxMemberCount));
			this.m_DragonGuildTotalPPT.SetText(this.m_doc.BaseData.totalPPT.ToString());
			this.m_DragonGuildTeamLeaderName.SetText(this.m_doc.BaseData.leaderName);
		}

		// Token: 0x0600A028 RID: 41000 RVA: 0x001AB044 File Offset: 0x001A9244
		public void RefreshUIRedPoint()
		{
			this.m_RecordButton.gameObject.transform.FindChild("redpoint").gameObject.SetActive(this.m_doc.IsHadRecordRedPoint);
			this.m_LivenessRewardButton.gameObject.transform.FindChild("redpoint").gameObject.SetActive(this.m_doc.IsHadLivenessRedPoint);
		}

		// Token: 0x0600A029 RID: 41001 RVA: 0x001AB0B4 File Offset: 0x001A92B4
		public void RefreshMemberList(bool bResetPosition = true)
		{
			List<XDragonGuildMember> memberList = this.m_doc.MemberList;
			int count = memberList.Count;
			this.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				this.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x0600A02A RID: 41002 RVA: 0x001AB0F4 File Offset: 0x001A92F4
		public void RefreshButtonsState()
		{
			this.m_AuthoriseButton.SetVisible(this.m_doc.IHavePermission(DragonGuildPermission.DGEM_APPROVAL));
			bool flag = this.m_doc.IHavePermission(DragonGuildPermission.DGEM_DISMISS);
			if (flag)
			{
				this.m_LeaveButton.SetVisible(false);
				this.m_DismissButton.SetVisible(true);
			}
			else
			{
				this.m_LeaveButton.SetVisible(true);
				this.m_DismissButton.SetVisible(false);
			}
		}

		// Token: 0x0600A02B RID: 41003 RVA: 0x001AB164 File Offset: 0x001A9364
		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this.m_doc.SortType = (DragonGuildMemberSortType)ID;
			this.m_doc.SortAndShow();
			return this.m_doc.SortDirection > 0;
		}

		// Token: 0x0600A02C RID: 41004 RVA: 0x001AB1A0 File Offset: 0x001A93A0
		private void WrapContentItemInit(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
		}

		// Token: 0x0600A02D RID: 41005 RVA: 0x001AB1D4 File Offset: 0x001A93D4
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.m_doc.MemberList.Count;
			if (!flag)
			{
				XDragonGuildMember xdragonGuildMember = this.m_doc.MemberList[index];
				ulong entityID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject = t.FindChild("PlayerBg").gameObject;
				IXUILabel ixuilabel = t.FindChild("LastLoginTime").GetComponent("XUILabel") as IXUILabel;
				this._MemberInfoDisplay.Init(t, false);
				this._MemberInfoDisplay.Set(xdragonGuildMember);
				bool flag2 = this.m_doc.Position == DragonGuildPosition.DGPOS_LEADER || this.m_doc.Position == DragonGuildPosition.DGPOS_VICELEADER;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString(xdragonGuildMember.time));
				}
				else
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeOnOrOutFromString(xdragonGuildMember.time));
				}
				ixuisprite.ID = (ulong)((long)index);
				gameObject.SetActive(entityID == xdragonGuildMember.uid);
			}
		}

		// Token: 0x0600A02E RID: 41006 RVA: 0x001AB2FC File Offset: 0x001A94FC
		private void _OnMemberClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this.m_doc.MemberList.Count;
			if (!flag)
			{
				XDragonGuildMember xdragonGuildMember = this.m_doc.MemberList[num];
				bool flag2 = xdragonGuildMember.uid == XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				if (!flag2)
				{
					this.m_SelectMember = xdragonGuildMember;
					this.m_SelectedName = xdragonGuildMember.name;
					this.m_SelectedMemberID = xdragonGuildMember.uid;
					DragonGuildPosition position = xdragonGuildMember.position;
					this.m_SelectedHigherPosition = (DragonGuildPosition)XDragonGuildDocument.DragonGuildPP.GetHigherPosition(position);
					this.m_SelectedLowerPosition = (DragonGuildPosition)XDragonGuildDocument.DragonGuildPP.GetLowerPosition(position);
					DragonGuildPermission setPositionPermission = XDragonGuildDocument.DragonGuildPP.GetSetPositionPermission(this.m_SelectedHigherPosition, this.m_SelectedHigherPosition);
					DragonGuildPermission setPositionPermission2 = XDragonGuildDocument.DragonGuildPP.GetSetPositionPermission(position, this.m_SelectedLowerPosition);
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
					bool flag4 = this.m_doc.Position == DragonGuildPosition.DGPOS_LEADER;
					if (flag4)
					{
						DragonGuildPosition position2 = xdragonGuildMember.position;
						if (position2 != DragonGuildPosition.DGPOS_VICELEADER)
						{
							if (position2 == DragonGuildPosition.DGPOS_MEMBER)
							{
								list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_DRAGON_GUILD_INCREASEPOSITION"));
								list2.Add(new ButtonClickEventHandler(this._HigherPositionClick));
							}
						}
						else
						{
							list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_DRAGON_GUILD_DECREASEPOSITION"));
							list2.Add(new ButtonClickEventHandler(this._LowerPositionClick));
						}
					}
					bool flag5 = this.m_doc.IHavePermission(DragonGuildPermission.DGEM_FIREMEMBER);
					if (flag5)
					{
						list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_FIREFROMDRAGONGUILD"));
						list2.Add(new ButtonClickEventHandler(this._OnKickAssBtnClick));
					}
					list.Add(XStringDefineProxy.GetString("OTHERPLAYERINFO_MENU_PK"));
					list2.Add(new ButtonClickEventHandler(this._PKClick));
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowMenuUI(xdragonGuildMember.uid, xdragonGuildMember.name, list, list2, 0U, (uint)xdragonGuildMember.profession);
				}
			}
		}

		// Token: 0x0600A02F RID: 41007 RVA: 0x001AB5B0 File Offset: 0x001A97B0
		private bool _LowerPositionClick(IXUIButton button)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			this.m_doc.ReqChangePosition(this.m_SelectedMemberID, DragonGuildPosition.DGPOS_MEMBER);
			return true;
		}

		// Token: 0x0600A030 RID: 41008 RVA: 0x001AB5E4 File Offset: 0x001A97E4
		private bool _HigherPositionClick(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			this.m_doc.ReqChangePosition(this.m_SelectedMemberID, DragonGuildPosition.DGPOS_VICELEADER);
			return true;
		}

		// Token: 0x0600A031 RID: 41009 RVA: 0x001AB618 File Offset: 0x001A9818
		private bool _OnKickAssBtnClick(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			bool flag = !this.m_doc.CheckPermission(DragonGuildPermission.DGEM_FIREMEMBER);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("DRAGON_GUILD_FIREMEMBER_CONFIRM", new object[]
				{
					this.m_SelectedName
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._KickAss));
				result = true;
			}
			return result;
		}

		// Token: 0x0600A032 RID: 41010 RVA: 0x001AB694 File Offset: 0x001A9894
		private bool _KickAss(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = !this.m_doc.CheckPermission(DragonGuildPermission.DGEM_FIREMEMBER);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_doc.ReqKickAss(this.m_SelectedMemberID);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A033 RID: 41011 RVA: 0x001AB6DC File Offset: 0x001A98DC
		private bool _PKClick(IXUIButton btn)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.SendPKInvitation(this.m_SelectedMemberID);
			return true;
		}

		// Token: 0x0600A034 RID: 41012 RVA: 0x001AB708 File Offset: 0x001A9908
		private bool _OnWXGroupBtnClick(IXUIButton btn)
		{
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", "");
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_WX_NOT_INSTALL"), "fece00");
				result = false;
			}
			else
			{
				int num = (int)btn.ID;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["unionID"] = this.m_doc.BaseData.uid.ToString();
				dictionary["chatRoomNickName"] = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
				bool flag3 = num == 0;
				if (flag3)
				{
					XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.DragonGuild;
					dictionary["chatRoomName"] = this.m_doc.BaseData.dragonGuildName;
					string param = Json.Serialize(dictionary);
					XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CreateWXGroup(param);
					XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild CreateWXGroup] param:" + dictionary.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					bool flag4 = num == 1;
					if (flag4)
					{
						XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.DragonGuild;
						string param2 = Json.Serialize(dictionary);
						XSingleton<XUpdater.XUpdater>.singleton.XPlatform.JoinWXGroup(param2);
					}
					else
					{
						bool flag5 = num == 2;
						if (flag5)
						{
							return this._OnGuildWXGroupShare();
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A035 RID: 41013 RVA: 0x001AB86C File Offset: 0x001A9A6C
		private bool _OnGuildWXGroupShare()
		{
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("Weixin_Installed", "");
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_WX_NOT_INSTALL"), "fece00");
				result = false;
			}
			else
			{
				XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.DragonGuild;
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary["msgType"] = 1;
				dictionary["subType"] = 1;
				dictionary["unionid"] = this.m_doc.BaseData.uid.ToString();
				dictionary["title"] = XSingleton<XGlobalConfig>.singleton.GetValue("DragonGuildGroupShareTitle");
				dictionary["description"] = XSingleton<XGlobalConfig>.singleton.GetValue("DragonGuildGroupShareContent");
				dictionary["mediaTagName"] = "MSG_INVITE";
				dictionary["imgUrl"] = XSingleton<XGlobalConfig>.singleton.GetValue("DragonGuildGroupShareImgUrl");
				dictionary["messageExt"] = "messageExt";
				dictionary["msdkExtInfo"] = "msdkExtInfo";
				string param = Json.Serialize(dictionary);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ShareWithWXGroup(param);
				result = true;
			}
			return result;
		}

		// Token: 0x0600A036 RID: 41014 RVA: 0x001AB9C0 File Offset: 0x001A9BC0
		public void DragonGuildGroupResult(string apiId, string result, int error)
		{
			XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuildGroupResult]appiId:" + apiId + ",result:" + result, null, null, null, null, null, XDebugColor.XDebug_None);
			int num = 0;
			bool flag = !int.TryParse(apiId, out num);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuildGroupResult]appiId parse failed", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				bool flag2 = num == 6;
				if (flag2)
				{
					bool flag3 = result == "Success";
					if (flag3)
					{
						this.m_doc.QueryWXGroup();
					}
					else
					{
						this.HandleErrorCode(error);
					}
				}
				else
				{
					bool flag4 = num == 8;
					if (flag4)
					{
						bool flag5 = result == "Success";
						if (flag5)
						{
							this.m_doc.QueryWXGroup();
						}
						else
						{
							this.HandleErrorCode(error);
						}
					}
					else
					{
						bool flag6 = num == 9;
						if (flag6)
						{
							bool flag7 = result == "Success";
							if (flag7)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_GROUP_SHARE_SUC"), "fece00");
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_GROUP_SHARE_FAIL"), "fece00");
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A037 RID: 41015 RVA: 0x001ABAF0 File Offset: 0x001A9CF0
		private void HandleErrorCode(int errorCode)
		{
			string key = string.Format("DRAGON_GUILD_GROUP_ERROR_{0}", errorCode.ToString());
			string text;
			bool data = XSingleton<XStringTable>.singleton.GetData(key, out text);
			if (data)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip("DRAGON_GUILD_GROUP_ERROR_OTHER", "fece00");
			}
		}

		// Token: 0x0600A038 RID: 41016 RVA: 0x001ABB50 File Offset: 0x001A9D50
		public void RefreshWXGroupBtn()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
				if (flag2)
				{
					this.m_BtnWXGroup.SetVisible(false);
				}
				else
				{
					bool flag3 = XSingleton<PDatabase>.singleton.wxGroupInfo != null && XSingleton<PDatabase>.singleton.wxGroupInfo.data.flag == "Success" && XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode != -10007;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 1", null, null, null, null, null, XDebugColor.XDebug_None);
						bool flag4 = false;
						string[] array = XSingleton<PDatabase>.singleton.wxGroupInfo.data.openIdList.Split(new char[]
						{
							','
						});
						for (int i = 0; i < array.Length; i++)
						{
							bool flag5 = array[i] == XSingleton<XLoginDocument>.singleton.OpenID;
							if (flag5)
							{
								flag4 = true;
								break;
							}
						}
						bool flag6 = flag4;
						if (flag6)
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 2", null, null, null, null, null, XDebugColor.XDebug_None);
							this.m_BtnWXGroup.ID = 2UL;
							this.m_BtnWXGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_WX_SHARE"));
							this.m_BtnWXGroup.SetVisible(true);
						}
						else
						{
							bool flag7 = XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode == 0;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 3", null, null, null, null, null, XDebugColor.XDebug_None);
								this.m_BtnWXGroup.SetVisible(true);
								this.m_BtnWXGroup.ID = 1UL;
								this.m_BtnWXGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_JOIN_WX_GROUP"));
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 4", null, null, null, null, null, XDebugColor.XDebug_None);
								this.m_BtnWXGroup.SetVisible(false);
							}
						}
					}
					else
					{
						bool flag8 = XSingleton<PDatabase>.singleton.wxGroupInfo != null && XSingleton<PDatabase>.singleton.wxGroupInfo.data.flag == "Success" && XSingleton<PDatabase>.singleton.wxGroupInfo.data.errorCode == -10007;
						if (flag8)
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 5", null, null, null, null, null, XDebugColor.XDebug_None);
							bool flag9 = this.m_doc.Position == DragonGuildPosition.DGPOS_LEADER || this.m_doc.Position == DragonGuildPosition.DGPOS_VICELEADER;
							if (flag9)
							{
								this.m_BtnWXGroup.ID = 0UL;
								this.m_BtnWXGroup.SetVisible(true);
								this.m_BtnWXGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_CREATE_WX_GROUP"));
							}
							else
							{
								this.m_BtnWXGroup.SetVisible(false);
							}
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("[WXGroup DragonGuild RefreshWXGroupBtn] 6", null, null, null, null, null, XDebugColor.XDebug_None);
							this.m_BtnWXGroup.SetVisible(false);
						}
					}
				}
			}
		}

		// Token: 0x0600A039 RID: 41017 RVA: 0x001ABE68 File Offset: 0x001AA068
		private bool _OnQQGroupBtnClick(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num == 2;
			if (flag)
			{
				this.m_doc.BindQQGroup();
			}
			else
			{
				bool flag2 = num == 3;
				if (flag2)
				{
					this.m_doc.JoinQQGroup();
				}
				else
				{
					bool flag3 = num == 1;
					if (flag3)
					{
						this.m_doc.UnbindQQGroup();
					}
				}
			}
			return true;
		}

		// Token: 0x0600A03A RID: 41018 RVA: 0x001ABECC File Offset: 0x001AA0CC
		public void RefreshQQGroupBtn()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
				if (flag2)
				{
					this.m_BtnQQGroup.SetVisible(false);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 1", null, null, null, null, null, XDebugColor.XDebug_None);
					bool flag3 = this.m_doc.qqGroupBindStatus == GuildBindStatus.GBS_Owner || this.m_doc.qqGroupBindStatus == GuildBindStatus.GBS_Admin || this.m_doc.qqGroupBindStatus == GuildBindStatus.GBS_Member;
					if (flag3)
					{
						bool flag4 = this.m_doc.Position == DragonGuildPosition.DGPOS_LEADER;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 2", null, null, null, null, null, XDebugColor.XDebug_None);
							this.m_BtnQQGroup.SetVisible(true);
							this.m_BtnQQGroup.ID = 1UL;
							this.m_BtnQQGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_UNBIND_QQ_GROUP"));
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 3", null, null, null, null, null, XDebugColor.XDebug_None);
							this.m_BtnQQGroup.SetVisible(true);
							this.m_BtnQQGroupText.SetText(this.m_doc.qqGroupName);
						}
					}
					else
					{
						bool flag5 = this.m_doc.qqGroupBindStatus == GuildBindStatus.GBS_NotBind;
						if (flag5)
						{
							bool flag6 = this.m_doc.Position == DragonGuildPosition.DGPOS_LEADER;
							if (flag6)
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 4", null, null, null, null, null, XDebugColor.XDebug_None);
								this.m_BtnQQGroup.ID = 2UL;
								this.m_BtnQQGroup.SetVisible(true);
								this.m_BtnQQGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_BIND_QQ_GROUP"));
								this.m_QQGroupName.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_NOT_BIN_QQ_GROUP"));
							}
							else
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 5", null, null, null, null, null, XDebugColor.XDebug_None);
								this.m_BtnQQGroup.ID = 4UL;
								this.m_BtnQQGroup.SetVisible(true);
								this.m_BtnQQGroupText.SetText("");
								this.m_QQGroupName.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_NOT_BIN_QQ_GROUP"));
							}
						}
						else
						{
							bool flag7 = this.m_doc.qqGroupBindStatus == GuildBindStatus.GBS_NotMember;
							if (flag7)
							{
								XSingleton<XDebug>.singleton.AddLog("[QQGroup DragonGuild RefreshQQGroupBtn] 6", null, null, null, null, null, XDebugColor.XDebug_None);
								this.m_BtnQQGroup.SetVisible(true);
								this.m_BtnQQGroup.ID = 3UL;
								this.m_BtnQQGroupText.SetText(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_JOIN_QQ_GROUP"));
								this.m_QQGroupName.SetText(this.m_doc.qqGroupName);
							}
						}
					}
				}
			}
		}

		// Token: 0x04003952 RID: 14674
		private XDragonGuildDocument m_doc = XDragonGuildDocument.Doc;

		// Token: 0x04003953 RID: 14675
		private XDragonGuildMemberInfoDisplay _MemberInfoDisplay = new XDragonGuildMemberInfoDisplay();

		// Token: 0x04003954 RID: 14676
		private DragonGuildPosition m_SelectedHigherPosition;

		// Token: 0x04003955 RID: 14677
		private DragonGuildPosition m_SelectedLowerPosition;

		// Token: 0x04003956 RID: 14678
		private ulong m_SelectedMemberID;

		// Token: 0x04003957 RID: 14679
		private string m_SelectedName;

		// Token: 0x04003958 RID: 14680
		private XDragonGuildMember m_SelectMember;

		// Token: 0x04003959 RID: 14681
		private IXUIButton m_Help;

		// Token: 0x0400395A RID: 14682
		private IXUILabel m_DragonGuildName;

		// Token: 0x0400395B RID: 14683
		private IXUILabel m_DragonGuildMemberCount;

		// Token: 0x0400395C RID: 14684
		private IXUILabel m_DragonGuildLevel;

		// Token: 0x0400395D RID: 14685
		private IXUILabel m_DragonGuildTotalPPT;

		// Token: 0x0400395E RID: 14686
		private IXUILabel m_DragonGuildTeamLeaderName;

		// Token: 0x0400395F RID: 14687
		private XTitleBar m_TitleBar;

		// Token: 0x04003960 RID: 14688
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04003961 RID: 14689
		private IXUIScrollView m_ScrollView;

		// Token: 0x04003962 RID: 14690
		private XDragonGuildMainBonusView m_BonusView;

		// Token: 0x04003963 RID: 14691
		private IXUIButton m_BonusButton;

		// Token: 0x04003964 RID: 14692
		private IXUIButton m_DismissButton;

		// Token: 0x04003965 RID: 14693
		private IXUIButton m_LeaveButton;

		// Token: 0x04003966 RID: 14694
		private IXUIButton m_StoreButton;

		// Token: 0x04003967 RID: 14695
		private IXUIButton m_RecordButton;

		// Token: 0x04003968 RID: 14696
		private IXUIButton m_RankButton;

		// Token: 0x04003969 RID: 14697
		private IXUIButton m_AuthoriseButton;

		// Token: 0x0400396A RID: 14698
		private IXUIButton m_LivenessRewardButton;

		// Token: 0x0400396B RID: 14699
		private IXUIButton m_BtnQQGroup;

		// Token: 0x0400396C RID: 14700
		private IXUILabel m_BtnQQGroupText;

		// Token: 0x0400396D RID: 14701
		private IXUILabel m_QQGroupName;

		// Token: 0x0400396E RID: 14702
		private IXUIButton m_BtnWXGroup;

		// Token: 0x0400396F RID: 14703
		private IXUILabel m_BtnWXGroupText;
	}
}
