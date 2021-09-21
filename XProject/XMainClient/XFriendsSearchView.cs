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
	// Token: 0x02000E36 RID: 3638
	internal class XFriendsSearchView : DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>
	{
		// Token: 0x17003442 RID: 13378
		// (get) Token: 0x0600C3AE RID: 50094 RVA: 0x002A8508 File Offset: 0x002A6708
		public override string fileName
		{
			get
			{
				return "GameSystem/FriendsSearchDlg";
			}
		}

		// Token: 0x17003443 RID: 13379
		// (get) Token: 0x0600C3AF RID: 50095 RVA: 0x002A8520 File Offset: 0x002A6720
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003444 RID: 13380
		// (get) Token: 0x0600C3B0 RID: 50096 RVA: 0x002A8534 File Offset: 0x002A6734
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C3B1 RID: 50097 RVA: 0x002A8547 File Offset: 0x002A6747
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			this.m_AddFriendListTempView = new XPlayerInfoChildView();
			this._onTimeCb = new XTimerMgr.AccurateElapsedEventHandler(this.OnTimer);
			this.mIsListInited = false;
		}

		// Token: 0x0600C3B2 RID: 50098 RVA: 0x002A8580 File Offset: 0x002A6780
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Refresh.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshFriends));
			base.uiBehaviour.m_AddFriend.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriendDirect));
		}

		// Token: 0x0600C3B3 RID: 50099 RVA: 0x002A85E8 File Offset: 0x002A67E8
		public void ShowBoard(RandomFriendWaitListRes waitList)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this._waitList = waitList;
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x0600C3B4 RID: 50100 RVA: 0x002A8618 File Offset: 0x002A6818
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

		// Token: 0x0600C3B5 RID: 50101 RVA: 0x002A8791 File Offset: 0x002A6991
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
			base.OnHide();
		}

		// Token: 0x0600C3B6 RID: 50102 RVA: 0x002A87B3 File Offset: 0x002A69B3
		protected override void OnUnload()
		{
			this.m_AddFriendListTempView = null;
			this._doc = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
			base.OnUnload();
		}

		// Token: 0x0600C3B7 RID: 50103 RVA: 0x002A87E4 File Offset: 0x002A69E4
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshUI();
			return true;
		}

		// Token: 0x0600C3B8 RID: 50104 RVA: 0x002A880C File Offset: 0x002A6A0C
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

		// Token: 0x0600C3B9 RID: 50105 RVA: 0x002A8870 File Offset: 0x002A6A70
		public void OnHeadClick(IXUISprite go)
		{
			ulong id = go.ID;
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
		}

		// Token: 0x0600C3BA RID: 50106 RVA: 0x002A8890 File Offset: 0x002A6A90
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

		// Token: 0x0600C3BB RID: 50107 RVA: 0x002A88FC File Offset: 0x002A6AFC
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

		// Token: 0x0600C3BC RID: 50108 RVA: 0x002A89C4 File Offset: 0x002A6BC4
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

		// Token: 0x0600C3BD RID: 50109 RVA: 0x002A8A54 File Offset: 0x002A6C54
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

		// Token: 0x0600C3BE RID: 50110 RVA: 0x002A8AEC File Offset: 0x002A6CEC
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

		// Token: 0x0600C3BF RID: 50111 RVA: 0x002A8B58 File Offset: 0x002A6D58
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

		// Token: 0x040054A8 RID: 21672
		private bool mIsListInited;

		// Token: 0x040054A9 RID: 21673
		private int m_RefreshCD;

		// Token: 0x040054AA RID: 21674
		private uint mTimerID;

		// Token: 0x040054AB RID: 21675
		private ulong m_AddFriendId = 0UL;

		// Token: 0x040054AC RID: 21676
		private XFriendsDocument _doc = null;

		// Token: 0x040054AD RID: 21677
		private List<GameObject> m_UIList = new List<GameObject>();

		// Token: 0x040054AE RID: 21678
		private XPlayerInfoChildView m_AddFriendListTempView;

		// Token: 0x040054AF RID: 21679
		private XTimerMgr.AccurateElapsedEventHandler _onTimeCb = null;

		// Token: 0x040054B0 RID: 21680
		private RandomFriendWaitListRes _waitList;

		// Token: 0x040054B1 RID: 21681
		private List<int> m_RandomFriendIndexSortList = new List<int>();
	}
}
