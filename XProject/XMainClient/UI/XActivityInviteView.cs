using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XActivityInviteView : DlgBase<XActivityInviteView, XActivityInviteBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Home/ActivityInviteDlg";
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

		protected override void Init()
		{
			this.InitTabs();
			this.InitProperties();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		private void OnCloseClicked(IXUISprite iSp)
		{
			this.SetVisible(false, true);
			this.ResetSendFlag();
		}

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

		private bool OnAddFriendClicked(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			this.SetVisible(false, true);
			return true;
		}

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

		private void InitProperties()
		{
			base.uiBehaviour.AddFriendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriendClicked));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.WrapContentItemInit));
			base.uiBehaviour.JoinGuildBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinGuildClicked));
			base.uiBehaviour.Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		public void Refresh(ActivityInviteTarget target)
		{
			this.RefreshCurTabItem(target);
			base.uiBehaviour.FriendText.SetVisible(XActivityInviteDocument.Doc.CurOpType == XActivityInviteDocument.OpType.Send);
		}

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

		private void WrapContentItemInit(Transform t, int index)
		{
			IXUIButton ixuibutton = t.FindChild("BtnInvite").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnInviteClick));
		}

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

		private void PerformInvite(ulong roleID)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			this.PreHandlerInviteType((ActivityInviteTarget)this._curTab, roleID);
			specificDocument.SendActivityInvitation(XSysDefine.XSys_Home_Feast, XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, true);
		}

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

		private bool OnJoinGuildClicked(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private bool GetChecked(InviteMemberInfo info, ulong id)
		{
			XActivityInviteDocument.OpType curOpType = XActivityInviteDocument.Doc.CurOpType;
			XActivityInviteDocument.OpType opType = curOpType;
			return opType == XActivityInviteDocument.OpType.Invite && info.uid == id;
		}

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

		protected List<Transform> _tabs = new List<Transform>();

		protected int _curTab = 2;

		protected List<InviteMemberInfo> curList = new List<InviteMemberInfo>();

		protected List<Vector3> _tabPos = new List<Vector3>();
	}
}
