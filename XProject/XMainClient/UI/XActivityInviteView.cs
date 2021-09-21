using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A0 RID: 6048
	internal class XActivityInviteView : DlgBase<XActivityInviteView, XActivityInviteBehavior>
	{
		// Token: 0x17003856 RID: 14422
		// (get) Token: 0x0600F9D4 RID: 63956 RVA: 0x003993C0 File Offset: 0x003975C0
		public override string fileName
		{
			get
			{
				return "Home/ActivityInviteDlg";
			}
		}

		// Token: 0x17003857 RID: 14423
		// (get) Token: 0x0600F9D5 RID: 63957 RVA: 0x003993D8 File Offset: 0x003975D8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003858 RID: 14424
		// (get) Token: 0x0600F9D6 RID: 63958 RVA: 0x003993EC File Offset: 0x003975EC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003859 RID: 14425
		// (get) Token: 0x0600F9D7 RID: 63959 RVA: 0x00399400 File Offset: 0x00397600
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F9D8 RID: 63960 RVA: 0x00399413 File Offset: 0x00397613
		protected override void Init()
		{
			this.InitTabs();
			this.InitProperties();
		}

		// Token: 0x0600F9D9 RID: 63961 RVA: 0x00399424 File Offset: 0x00397624
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600F9DA RID: 63962 RVA: 0x0039942E File Offset: 0x0039762E
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F9DB RID: 63963 RVA: 0x00399438 File Offset: 0x00397638
		protected override void OnShow()
		{
			base.OnShow();
			this._curTab = 2;
			this.RefreshTabs();
			bool flag = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.friendData.Count == 0;
			if (flag)
			{
				this.Refresh(ActivityInviteTarget.Friend);
			}
			else
			{
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.QueryRoleState();
			}
			bool flag2 = (4 & XActivityInviteDocument.Doc.ShowType) > 0;
			if (flag2)
			{
				XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
				specificDocument.ReqMemberList();
			}
			base.uiBehaviour.FriendText.SetText(XStringDefineProxy.GetString("PresentDegree", new object[]
			{
				XSingleton<XGlobalConfig>.singleton.GetInt("IBShopDegree")
			}));
		}

		// Token: 0x0600F9DC RID: 63964 RVA: 0x003994E5 File Offset: 0x003976E5
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x0600F9DD RID: 63965 RVA: 0x003994F1 File Offset: 0x003976F1
		private void OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
			this.ResetSendFlag();
		}

		// Token: 0x0600F9DE RID: 63966 RVA: 0x00399504 File Offset: 0x00397704
		private void ResetSendFlag()
		{
			foreach (List<InviteMemberInfo> list in XActivityInviteDocument.Doc.MemberInfos.Values)
			{
				foreach (InviteMemberInfo inviteMemberInfo in list)
				{
					inviteMemberInfo.bSent = false;
				}
			}
		}

		// Token: 0x0600F9DF RID: 63967 RVA: 0x003995A0 File Offset: 0x003977A0
		private bool OnAddFriendClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F9E0 RID: 63968 RVA: 0x003995C8 File Offset: 0x003977C8
		private void InitTabs()
		{
			this._tabs.Clear();
			this._tabPos.Clear();
			int num = 0;
			foreach (object obj in base.uiBehaviour.Tabs)
			{
				Transform transform = (Transform)obj;
				num++;
				this._tabs.Add(transform);
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = 1UL << num;
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.RefreshItems));
				this._tabPos.Add(transform.localPosition);
			}
		}

		// Token: 0x0600F9E1 RID: 63969 RVA: 0x00399698 File Offset: 0x00397898
		private void InitProperties()
		{
			base.uiBehaviour.AddFriendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriendClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			base.uiBehaviour.JoinGuildBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinGuildClicked));
			base.uiBehaviour.Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600F9E2 RID: 63970 RVA: 0x00399737 File Offset: 0x00397937
		public void Refresh(ActivityInviteTarget target)
		{
			this.RefreshCurTabItem(target);
			base.uiBehaviour.FriendText.SetVisible(XActivityInviteDocument.Doc.CurOpType == XActivityInviteDocument.OpType.Send);
		}

		// Token: 0x0600F9E3 RID: 63971 RVA: 0x00399760 File Offset: 0x00397960
		public void RefreshTabs()
		{
			base.uiBehaviour.JoinGuildBtn.gameObject.SetActive(false);
			base.uiBehaviour.AddFriendBtn.gameObject.SetActive(false);
			int[] array = Enum.GetValues(typeof(ActivityInviteTarget)) as int[];
			int num = -1;
			int num2 = Mathf.Min(array.Length, this._tabs.Count);
			for (int i = 0; i < num2; i++)
			{
				bool flag = (array[i] & XActivityInviteDocument.Doc.ShowType) > 0;
				if (flag)
				{
					this._tabs[i].gameObject.SetActive(true);
					this._tabs[i].transform.localPosition = this._tabPos[++num];
				}
				else
				{
					this._tabs[i].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600F9E4 RID: 63972 RVA: 0x00399854 File Offset: 0x00397A54
		public bool RefreshCurTabItem(ActivityInviteTarget target)
		{
			for (int i = 0; i < this._tabs.Count; i++)
			{
				GameObject gameObject = this._tabs[i].gameObject;
				bool activeSelf = gameObject.activeSelf;
				if (activeSelf)
				{
					int num = 1 << i + 1;
					bool flag = this._curTab == 0 || (target == (ActivityInviteTarget)this._curTab && num == this._curTab);
					if (flag)
					{
						IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
						bool bChecked = ixuicheckBox.bChecked;
						if (bChecked)
						{
							this.RefreshItems(ixuicheckBox);
						}
						else
						{
							ixuicheckBox.bChecked = true;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600F9E5 RID: 63973 RVA: 0x00399914 File Offset: 0x00397B14
		public bool RefreshItems(IXUICheckBox go)
		{
			bool flag = !go.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._curTab = (int)go.ID;
				List<InviteMemberInfo> list = null;
				ActivityInviteTarget curTab = (ActivityInviteTarget)this._curTab;
				bool flag2 = XActivityInviteDocument.Doc.MemberInfos.ContainsKey(curTab);
				if (flag2)
				{
					list = XActivityInviteDocument.Doc.MemberInfos[curTab];
				}
				bool flag3 = list != null;
				if (flag3)
				{
					base.uiBehaviour.WrapContent.SetContentCount(list.Count, false);
					base.uiBehaviour.ScrollView.ResetPosition();
					bool flag4 = list.Count == 0;
					if (flag4)
					{
						bool flag5 = (long)this._curTab == 4L;
						if (flag5)
						{
							XGuildMemberDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMemberDocument>(XGuildMemberDocument.uuID);
							List<XGuildMember> memberList = specificDocument.MemberList;
							base.uiBehaviour.EmptyFlag.gameObject.SetActive(memberList.Count != 0);
							base.uiBehaviour.JoinGuildBtn.gameObject.SetActive(memberList.Count == 0);
						}
						else
						{
							bool flag6 = (long)this._curTab == 2L;
							if (flag6)
							{
								base.uiBehaviour.AddFriendBtn.gameObject.SetActive(true);
							}
						}
					}
					else
					{
						base.uiBehaviour.EmptyFlag.gameObject.SetActive(false);
						base.uiBehaviour.JoinGuildBtn.gameObject.SetActive(false);
						base.uiBehaviour.AddFriendBtn.gameObject.SetActive(false);
						this.curList = list;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600F9E6 RID: 63974 RVA: 0x00399AA8 File Offset: 0x00397CA8
		private void WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnInviteClick));
		}

		// Token: 0x0600F9E7 RID: 63975 RVA: 0x00399AE4 File Offset: 0x00397CE4
		private bool OnInviteClick(IXUIButton go)
		{
			go.SetEnable(false, false);
			this.SetSend(go.ID);
			base.uiBehaviour.WrapContent.RefreshAllVisibleContents();
			XActivityInviteDocument.OpType curOpType = XActivityInviteDocument.Doc.CurOpType;
			XActivityInviteDocument.OpType opType = curOpType;
			if (opType != XActivityInviteDocument.OpType.Send)
			{
				if (opType == XActivityInviteDocument.OpType.Invite)
				{
					this.PerformInvite(go.ID);
				}
			}
			else
			{
				IXUILabel ixuilabel = go.gameObject.transform.Find("Label").GetComponent("XUILabel") as IXUILabel;
				bool flag = ixuilabel.GetText() == XSingleton<XStringTable>.singleton.GetString("ActivityDegree");
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ActivityDegree"), "fece00");
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("send btn clicked", null, null, null, null, null, XDebugColor.XDebug_None);
					this.SetVisible(false, true);
					DlgBase<PresentDlg, PresentBehaviour>.singleton.Show(go.ID);
				}
			}
			return true;
		}

		// Token: 0x0600F9E8 RID: 63976 RVA: 0x00399BE8 File Offset: 0x00397DE8
		private void PerformInvite(ulong roleID)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			this.PreHandlerInviteType((ActivityInviteTarget)this._curTab, roleID);
			specificDocument.SendActivityInvitation(XSysDefine.XSys_Home_Feast, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, true);
		}

		// Token: 0x0600F9E9 RID: 63977 RVA: 0x00399C2C File Offset: 0x00397E2C
		private void PreHandlerInviteType(ActivityInviteTarget type, ulong roleID)
		{
			if (type != ActivityInviteTarget.Friend)
			{
				if (type != ActivityInviteTarget.Guild)
				{
				}
			}
			else
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = roleID;
				XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				ChatFriendData chatFriendData = specificDocument.FindFriendData(roleID);
				bool flag = chatFriendData == null;
				if (flag)
				{
					XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(roleID);
					ChatFriendData chatFriendData2 = new ChatFriendData();
					chatFriendData2.name = friendDataById.name;
					chatFriendData2.roleid = friendDataById.roleid;
					chatFriendData2.powerpoint = friendDataById.powerpoint;
					chatFriendData2.profession = friendDataById.profession;
					chatFriendData2.viplevel = friendDataById.viplevel;
					chatFriendData2.isfriend = true;
					chatFriendData2.msgtime = DateTime.Now;
					chatFriendData2.setid = friendDataById.setid;
					specificDocument.ChatFriendList.Add(chatFriendData2);
				}
				else
				{
					chatFriendData.msgtime = DateTime.Now;
				}
			}
		}

		// Token: 0x0600F9EA RID: 63978 RVA: 0x00399D18 File Offset: 0x00397F18
		private bool OnJoinGuildClicked(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F9EB RID: 63979 RVA: 0x00399D44 File Offset: 0x00397F44
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = !XActivityInviteDocument.Doc.MemberInfos.ContainsKey((ActivityInviteTarget)this._curTab);
			if (!flag)
			{
				List<InviteMemberInfo> list = XActivityInviteDocument.Doc.MemberInfos[(ActivityInviteTarget)this._curTab];
				bool flag2 = index >= list.Count;
				if (!flag2)
				{
					InviteMemberInfo inviteMemberInfo = list[index];
					IXUILabel ixuilabel = t.FindChild("Info/Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = t.FindChild("Info/Level").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = t.FindChild("Info/AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = t.FindChild("Info/Profession").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel3 = t.FindChild("Info/AvatarBG/BattlePointBG/Power").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel4 = t.FindChild("Info/GuildName").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel5 = t.Find("State").GetComponent("XUILabel") as IXUILabel;
					ixuilabel5.SetText("");
					Transform transform = t.Find("Info/AvatarBG/Relation");
					ixuilabel.SetText(inviteMemberInfo.name);
					ixuilabel2.SetText("Lv." + inviteMemberInfo.level.ToString());
					ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)inviteMemberInfo.profession);
					ixuisprite2.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)inviteMemberInfo.profession);
					ixuilabel3.SetText(inviteMemberInfo.ppt.ToString());
					bool flag3 = string.IsNullOrEmpty(inviteMemberInfo.guildname);
					if (flag3)
					{
						ixuilabel4.SetText(XSingleton<XStringTable>.singleton.GetString("NoGuild"));
					}
					else
					{
						ixuilabel4.SetText(inviteMemberInfo.guildname);
					}
					Transform transform2 = transform.Find("Guild");
					Transform transform3 = transform.Find("Friend");
					transform2.gameObject.SetActive(this._curTab == 4);
					transform3.gameObject.SetActive(this._curTab == 2);
					IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.SetEnable(true, false);
					ixuibutton.SetVisible(!inviteMemberInfo.bSent);
					this.SetOpBtnContent(t, inviteMemberInfo);
				}
			}
		}

		// Token: 0x0600F9EC RID: 63980 RVA: 0x00399FB8 File Offset: 0x003981B8
		private void SetSend(ulong id)
		{
			for (int i = 0; i < this.curList.Count; i++)
			{
				bool @checked = this.GetChecked(this.curList[i], id);
				if (@checked)
				{
					this.curList[i].bSent = true;
				}
			}
		}

		// Token: 0x0600F9ED RID: 63981 RVA: 0x0039A010 File Offset: 0x00398210
		private bool GetChecked(InviteMemberInfo info, ulong id)
		{
			XActivityInviteDocument.OpType curOpType = XActivityInviteDocument.Doc.CurOpType;
			XActivityInviteDocument.OpType opType = curOpType;
			return opType == XActivityInviteDocument.OpType.Invite && info.uid == id;
		}

		// Token: 0x0600F9EE RID: 63982 RVA: 0x0039A044 File Offset: 0x00398244
		private void SetOpBtnContent(Transform item, InviteMemberInfo info)
		{
			IXUIButton ixuibutton = item.Find("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel = item.Find("Invited").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = item.Find("BtnInvite/Label").GetComponent("XUILabel") as IXUILabel;
			XActivityInviteDocument.OpType curOpType = XActivityInviteDocument.Doc.CurOpType;
			XActivityInviteDocument.OpType opType = curOpType;
			if (opType != XActivityInviteDocument.OpType.Send)
			{
				if (opType == XActivityInviteDocument.OpType.Invite)
				{
					ixuibutton.ID = info.uid;
					string text = info.bSent ? XSingleton<XStringTable>.singleton.GetString("ActivityInvited") : "";
					ixuilabel.SetText(text);
					ixuilabel2.SetText(XSingleton<XStringTable>.singleton.GetString("ActivityInvite"));
				}
			}
			else
			{
				ixuibutton.ID = info.uid;
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("IBShopDegree");
				string @string = XSingleton<XStringTable>.singleton.GetString(((ulong)info.degree < (ulong)((long)@int)) ? "ActivityDegree" : "ActivitySend");
				ixuilabel.SetText(@string);
				ixuilabel2.SetText(@string);
			}
		}

		// Token: 0x04006D67 RID: 28007
		protected List<Transform> _tabs = new List<Transform>();

		// Token: 0x04006D68 RID: 28008
		protected int _curTab = 2;

		// Token: 0x04006D69 RID: 28009
		protected List<InviteMemberInfo> curList = new List<InviteMemberInfo>();

		// Token: 0x04006D6A RID: 28010
		protected List<Vector3> _tabPos = new List<Vector3>();
	}
}
