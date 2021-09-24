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

	internal class XDragonGuildMainHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "DungeonTroop/DungeonTroopMenberDlg";
			}
		}

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

		private bool _OnHelpBtnClick(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildCollectSummon);
			return true;
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XTitleBar>(ref this.m_TitleBar);
			DlgHandlerBase.EnsureUnload<XDragonGuildMainBonusView>(ref this.m_BonusView);
			base.OnUnload();
		}

		private bool _OnBonusBtnClick(IXUIButton button)
		{
			this.m_BonusView.SetVisible(true);
			return true;
		}

		private bool _OnAuthoriseBtnClick(IXUIButton button)
		{
			DlgBase<XDragonGuildApproveDlg, XDragonGuildApproveBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool _OnRankBtnClick(IXUIButton go)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_DragonGuild);
			return true;
		}

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

		private bool _OnLeaveBtnClick(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.m_doc.ReqLeaveDragonGuild();
			return true;
		}

		protected override void OnShow()
		{
			this.m_doc.ReqMemberList();
			this.m_TitleBar.Refresh((ulong)((long)XFastEnumIntEqualityComparer<DragonGuildMemberSortType>.ToInt(this.m_doc.SortType)));
			this.m_BonusView.SetVisible(false);
			this.m_doc.QueryWXGroup();
			this.m_doc.QueryQQGroup();
		}

		public bool OnRecordButtonClick(IXUIButton btn)
		{
			DlgBase<XDragonGuildTaskView, XDragonGuildTaskBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		public bool OnShopButtonClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_DragonGuildShop, 0UL);
			return true;
		}

		public bool OnLivenessButtonClick(IXUIButton btn)
		{
			DlgBase<DragonGuildLivenessDlg, DragonGuildLivenessBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		public void RefreshPage()
		{
			this.RefreshMemberList(true);
			this.RefreshButtonsState();
			this.RefreshLabelInfo();
			this.RefreshUIRedPoint();
			this.RefreshWXGroupBtn();
			this.RefreshQQGroupBtn();
		}

		public void RefreshLabelInfo()
		{
			this.m_DragonGuildName.SetText(this.m_doc.BaseData.dragonGuildName);
			this.m_DragonGuildLevel.SetText(this.m_doc.BaseData.level.ToString());
			this.m_DragonGuildMemberCount.SetText(string.Format("{0}/{1}", this.m_doc.BaseData.memberCount, this.m_doc.BaseData.maxMemberCount));
			this.m_DragonGuildTotalPPT.SetText(this.m_doc.BaseData.totalPPT.ToString());
			this.m_DragonGuildTeamLeaderName.SetText(this.m_doc.BaseData.leaderName);
		}

		public void RefreshUIRedPoint()
		{
			this.m_RecordButton.gameObject.transform.FindChild("redpoint").gameObject.SetActive(this.m_doc.IsHadRecordRedPoint);
			this.m_LivenessRewardButton.gameObject.transform.FindChild("redpoint").gameObject.SetActive(this.m_doc.IsHadLivenessRedPoint);
		}

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

		private bool _OnTitleClickEventHandler(ulong ID)
		{
			this.m_doc.SortType = (DragonGuildMemberSortType)ID;
			this.m_doc.SortAndShow();
			return this.m_doc.SortDirection > 0;
		}

		private void WrapContentItemInit(Transform itemTransform, int index)
		{
			IXUISprite ixuisprite = itemTransform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
		}

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

		private bool _LowerPositionClick(IXUIButton button)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			this.m_doc.ReqChangePosition(this.m_SelectedMemberID, DragonGuildPosition.DGPOS_MEMBER);
			return true;
		}

		private bool _HigherPositionClick(IXUIButton btn)
		{
			DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			this.m_doc.ReqChangePosition(this.m_SelectedMemberID, DragonGuildPosition.DGPOS_VICELEADER);
			return true;
		}

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

		private bool _PKClick(IXUIButton btn)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.SendPKInvitation(this.m_SelectedMemberID);
			return true;
		}

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

		private XDragonGuildDocument m_doc = XDragonGuildDocument.Doc;

		private XDragonGuildMemberInfoDisplay _MemberInfoDisplay = new XDragonGuildMemberInfoDisplay();

		private DragonGuildPosition m_SelectedHigherPosition;

		private DragonGuildPosition m_SelectedLowerPosition;

		private ulong m_SelectedMemberID;

		private string m_SelectedName;

		private XDragonGuildMember m_SelectMember;

		private IXUIButton m_Help;

		private IXUILabel m_DragonGuildName;

		private IXUILabel m_DragonGuildMemberCount;

		private IXUILabel m_DragonGuildLevel;

		private IXUILabel m_DragonGuildTotalPPT;

		private IXUILabel m_DragonGuildTeamLeaderName;

		private XTitleBar m_TitleBar;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ScrollView;

		private XDragonGuildMainBonusView m_BonusView;

		private IXUIButton m_BonusButton;

		private IXUIButton m_DismissButton;

		private IXUIButton m_LeaveButton;

		private IXUIButton m_StoreButton;

		private IXUIButton m_RecordButton;

		private IXUIButton m_RankButton;

		private IXUIButton m_AuthoriseButton;

		private IXUIButton m_LivenessRewardButton;

		private IXUIButton m_BtnQQGroup;

		private IXUILabel m_BtnQQGroupText;

		private IXUILabel m_QQGroupName;

		private IXUIButton m_BtnWXGroup;

		private IXUILabel m_BtnWXGroupText;
	}
}
