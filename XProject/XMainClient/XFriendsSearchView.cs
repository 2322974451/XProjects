using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsSearchView : DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FriendsSearchDlg";
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
			this._doc = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			this.m_AddFriendListTempView = new XPlayerInfoChildView();
			this._onTimeCb = new XTimerMgr.AccurateElapsedEventHandler(this.OnTimer);
			this.mIsListInited = false;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Refresh.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshFriends));
			base.uiBehaviour.m_AddFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriendDirect));
		}

		public void ShowBoard(RandomFriendWaitListRes waitList)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this._waitList = waitList;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			XPlatformAbilityDocument.Doc.QueryQQVipInfo();
			bool flag = !this.mIsListInited;
			if (flag)
			{
				base.uiBehaviour.m_FriendRandomListPool.FakeReturnAll();
				this.m_UIList.Clear();
				for (int i = 0; i < 4; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_FriendRandomListPool.FetchGameObject(false);
					gameObject.SetActive(false);
					this.m_UIList.Add(gameObject);
					gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_FriendRandomListPool.TplPos.x, base.uiBehaviour.m_FriendRandomListPool.TplPos.y - (float)(i * base.uiBehaviour.m_FriendRandomListPool.TplHeight), base.uiBehaviour.m_FriendRandomListPool.TplPos.z);
				}
				base.uiBehaviour.m_FriendRandomListPool.ActualReturnAll(false);
				this.mIsListInited = true;
			}
			base.uiBehaviour.m_ScrollView.ResetPosition();
			this.m_RefreshCD = 0;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
			base.uiBehaviour.m_SearchName.SetText("");
			base.uiBehaviour.m_CountdownText.SetText(XStringDefineProxy.GetString("FRIEND_ADDDLG_NO_COUNTDOWN"));
			this.OnRefreshRandomFriend(this._waitList);
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			this.m_AddFriendListTempView = null;
			this._doc = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
			base.OnUnload();
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshUI();
			return true;
		}

		public bool OnAddFriend(IXUIButton sp)
		{
			ulong id = sp.ID;
			bool flag = id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_NOT_ADD_SELF"), "fece00");
				result = true;
			}
			else
			{
				this.m_AddFriendId = id;
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(id);
				result = true;
			}
			return result;
		}

		public void OnHeadClick(IXUISprite go)
		{
			ulong id = go.ID;
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
		}

		public bool OnAddFriendDirect(IXUIButton sp)
		{
			string text = base.uiBehaviour.m_SearchName.GetText();
			bool flag = (text + string.Empty).Length <= 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_NAME_CANNOT_NULL"), "fece00");
				result = false;
			}
			else
			{
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendByName(text);
				result = true;
			}
			return result;
		}

		public bool OnRefreshFriends(IXUIButton sp)
		{
			bool flag = this.m_RefreshCD > 0;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_REFRESH_CD_HINT"), "fece00");
			}
			else
			{
				this.m_RefreshCD = XSingleton<XFriendsStaticData>.singleton.RefreshAddListCD;
				bool flag2 = this.m_RefreshCD > 0;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
					base.uiBehaviour.m_CountdownText.SetText(XStringDefineProxy.GetString("FRIEND_ADDDLG_COUNTDOWN_FMT", new object[]
					{
						this.m_RefreshCD
					}));
					this.mTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, this._onTimeCb, null);
				}
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			}
			return true;
		}

		protected void OnTimer(object param, float delay)
		{
			IXUILabel countdownText = base.uiBehaviour.m_CountdownText;
			string key = "FRIEND_ADDDLG_COUNTDOWN_FMT";
			object[] array = new object[1];
			int num = 0;
			int num2 = this.m_RefreshCD - 1;
			this.m_RefreshCD = num2;
			array[num] = num2;
			countdownText.SetText(XStringDefineProxy.GetString(key, array));
			bool flag = this.m_RefreshCD > 0;
			if (flag)
			{
				this.mTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, this._onTimeCb, null);
			}
			else
			{
				base.uiBehaviour.m_CountdownText.SetText(XStringDefineProxy.GetString("FRIEND_ADDDLG_NO_COUNTDOWN"));
			}
		}

		public void FriendAdded()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				List<GameObject> list = ListPool<GameObject>.Get();
				base.uiBehaviour.m_FriendRandomListPool.GetActiveList(list);
				for (int i = 0; i < list.Count; i++)
				{
					IXUIButton ixuibutton = list[i].transform.FindChild("add").GetComponent("XUIButton") as IXUIButton;
					bool flag2 = ixuibutton.ID == this.m_AddFriendId;
					if (flag2)
					{
						ixuibutton.SetEnable(false, false);
					}
				}
				ListPool<GameObject>.Release(list);
			}
		}

		private void SortRandomFriendByOnlineState(RandomFriendWaitListRes waitList)
		{
			this.m_RandomFriendIndexSortList.Clear();
			for (int i = 0; i < waitList.lastlogin.Count; i++)
			{
				bool flag = waitList.lastlogin[i] == 0U;
				if (flag)
				{
					this.m_RandomFriendIndexSortList.Insert(0, i);
				}
				else
				{
					this.m_RandomFriendIndexSortList.Add(i);
				}
			}
		}

		public void OnRefreshRandomFriend(RandomFriendWaitListRes waitList)
		{
			this.SortRandomFriendByOnlineState(waitList);
			for (int i = 0; i < this.m_RandomFriendIndexSortList.Count; i++)
			{
				bool flag = i >= this.m_UIList.Count;
				if (flag)
				{
					break;
				}
				int num = this.m_RandomFriendIndexSortList[i];
				GameObject gameObject = this.m_UIList[i];
				gameObject.SetActive(true);
				XPlayerInfoChildView addFriendListTempView = this.m_AddFriendListTempView;
				addFriendListTempView.FindFrom(gameObject.transform);
				IXUIButton ixuibutton = gameObject.transform.Find("add").GetComponent("XUIButton") as IXUIButton;
				bool flag2 = num < waitList.nickid.Count;
				if (flag2)
				{
					addFriendListTempView.uidLab.SetText(waitList.nickid[num].ToString());
				}
				addFriendListTempView.lbName.InputText = XSingleton<XCommon>.singleton.StringCombine(XTitleDocument.GetTitleWithFormat(waitList.titleid[num], waitList.name[num]), XRechargeDocument.GetVIPIconString(waitList.viplevel[num]));
				addFriendListTempView.lbLevel.SetText(waitList.level[num].ToString());
				addFriendListTempView.lbPPT.SetText(waitList.powerpoint[num].ToString());
				addFriendListTempView.sprHead.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)waitList.profession[num]));
				addFriendListTempView.SetGuildName(waitList.guildname[num]);
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateFriendOnlineState(gameObject.transform, (waitList.lastlogin[num] == 0U) ? 1U : 0U, waitList.lastlogin[num]);
				ixuibutton.SetEnable(true, false);
				ixuibutton.ID = waitList.roleid[num];
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriend));
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = waitList.roleid[num];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHeadClick));
			}
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		private bool mIsListInited;

		private int m_RefreshCD;

		private uint mTimerID;

		private ulong m_AddFriendId = 0UL;

		private XFriendsDocument _doc = null;

		private List<GameObject> m_UIList = new List<GameObject>();

		private XPlayerInfoChildView m_AddFriendListTempView;

		private XTimerMgr.AccurateElapsedEventHandler _onTimeCb = null;

		private RandomFriendWaitListRes _waitList;

		private List<int> m_RandomFriendIndexSortList = new List<int>();
	}
}
