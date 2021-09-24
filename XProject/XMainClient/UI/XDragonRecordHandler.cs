using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XDragonRecordHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
			this._expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._dnDoc = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			this.m_BtnDragonNest = (base.PanelObject.transform.Find("Btn_DragonNest").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnRecruit = (base.PanelObject.transform.Find("Btn_Recruit").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.PanelObject.transform.Find("detail/detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.Find("detail/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._EmptyDetail = base.PanelObject.transform.Find("detail/EmptyDetail");
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this._doc.ReqDragonGroupRoleInfo();
		}

		public override void RefreshData()
		{
			this.SetupPartnerInfo();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnDragonNest.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBtnDragonNest));
			this.m_BtnRecruit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBtnRecruit));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.PartnerWrapListUpdate));
		}

		public override void OnUnload()
		{
			this.m_dragonGroupRoleInfoList = null;
			base.OnUnload();
		}

		private void PartnerWrapListUpdate(Transform item, int index)
		{
			bool flag = this.m_dragonGroupRoleInfoList == null || index >= this.m_dragonGroupRoleInfoList.Count;
			if (!flag)
			{
				IXUISprite ixuisprite = item.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItem));
				IXUISprite ixuisprite2 = item.FindChild("Info/Profession").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = item.FindChild("Info/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = item.FindChild("Info/Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = item.FindChild("Info/AvatarBG/BattlePointBG/Power").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = item.FindChild("Info/GuildName").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite3 = item.FindChild("Info/AvatarBG/Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite4 = item.FindChild("Info/AvatarBG/AvatarFrame").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel5 = item.FindChild("Stage/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel6 = item.FindChild("Stage/date/Date").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel7 = item.FindChild("Stage/date/Time").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel8 = item.FindChild("Stage/Times/Num").GetComponent("XUILabel") as IXUILabel;
				Transform transform = item.FindChild("add");
				IXUIButton ixuibutton = item.FindChild("add").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddFriend));
				Transform transform2 = item.FindChild("hgd");
				IXUILabel ixuilabel9 = transform2.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite5 = transform2.FindChild("Level/Mark").GetComponent("XUISprite") as IXUISprite;
				ixuisprite5.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickDegreeHeart));
				IXUIButton ixuibutton2 = item.FindChild("chat/btn").GetComponent("XUIButton") as IXUIButton;
				ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickChatBtn));
				DragonGroupRoleInfo dragonGroupRoleInfo = this.m_dragonGroupRoleInfoList[index];
				ixuibutton.ID = dragonGroupRoleInfo.roleid;
				ixuibutton2.ID = (ulong)((long)index);
				ixuisprite.ID = dragonGroupRoleInfo.roleid;
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)dragonGroupRoleInfo.profession));
				ixuilabel.SetText(dragonGroupRoleInfo.rolename);
				ixuilabel2.SetText(dragonGroupRoleInfo.level.ToString());
				ixuilabel3.SetText(dragonGroupRoleInfo.fighting.ToString());
				ixuilabel4.SetText(string.IsNullOrEmpty(dragonGroupRoleInfo.guild) ? XStringDefineProxy.GetString("NONE") : dragonGroupRoleInfo.guild);
				ixuisprite3.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)dragonGroupRoleInfo.profession));
				bool flag2 = dragonGroupRoleInfo.pre != null;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ParseHeadIcon(dragonGroupRoleInfo.pre.setid, ixuisprite4);
				}
				else
				{
					ixuisprite4.SetVisible(false);
				}
				ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)dragonGroupRoleInfo.stageID);
				bool flag3 = expeditionDataByID != null;
				if (flag3)
				{
					ixuilabel5.SetText(XExpeditionDocument.GetFullName(expeditionDataByID));
					DateTime dateTime = XSingleton<UiUtility>.singleton.TimeNow(dragonGroupRoleInfo.stageTime, true);
					ixuilabel6.SetText(dateTime.ToString("yyyy.MM.dd"));
					ixuilabel7.SetText(dateTime.ToString("HH:mm"));
					ixuilabel8.SetText(dragonGroupRoleInfo.stageCount.ToString());
				}
				else
				{
					ixuilabel5.SetText("");
					ixuilabel6.SetText("");
					ixuilabel7.SetText("");
					ixuilabel8.SetText("");
				}
				XFriendData friendDataById = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.GetFriendDataById(dragonGroupRoleInfo.roleid);
				bool flag4 = friendDataById != null;
				if (flag4)
				{
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(true);
					bool flag5 = friendDataById.degreeAll < XSingleton<XFriendsStaticData>.singleton.MaxFriendlyEvaluation;
					if (flag5)
					{
						ixuilabel9.SetText(friendDataById.degreeAll.ToString());
					}
					else
					{
						ixuilabel9.SetText("MAX");
					}
					float num = friendDataById.degreeAll;
					num /= XSingleton<XFriendsStaticData>.singleton.MaxFriendlyEvaluation;
					ixuisprite5.SetFillAmount(1f - num);
					ixuisprite5.ID = (ulong)friendDataById.degreeAll;
				}
				else
				{
					transform.gameObject.SetActive(true);
					transform2.gameObject.SetActive(false);
				}
			}
		}

		private void OnClickDegreeHeart(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_DEGREE_HINT_TEXT_FMT", new object[]
			{
				spr.ID
			}), "fece00");
		}

		private void OnClickItem(IXUISprite sp)
		{
			ulong id = sp.ID;
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
		}

		private bool OnClickAddFriend(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(btn.ID);
			return true;
		}

		private bool OnClickBtnDragonNest(IXUIButton btn)
		{
			DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool OnClickBtnRecruit(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruit, 0UL);
			return true;
		}

		private bool OnClickChatBtn(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num < 0 || num >= this.m_dragonGroupRoleInfoList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DragonGroupRoleInfo dragonGroupRoleInfo = this.m_dragonGroupRoleInfoList[num];
				bool flag2 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsBlock(dragonGroupRoleInfo.roleid);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHAT_BLOCK_2"), "fece00");
				}
				else
				{
					ChatFriendData chatFriendData = new ChatFriendData();
					chatFriendData.name = dragonGroupRoleInfo.rolename;
					chatFriendData.roleid = dragonGroupRoleInfo.roleid;
					chatFriendData.powerpoint = dragonGroupRoleInfo.fighting;
					chatFriendData.profession = dragonGroupRoleInfo.profession;
					chatFriendData.setid = ((dragonGroupRoleInfo.pre != null) ? dragonGroupRoleInfo.pre.setid : new List<uint>());
					chatFriendData.isfriend = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsMyFriend(dragonGroupRoleInfo.roleid);
					chatFriendData.msgtime = DateTime.Now;
					chatFriendData.viplevel = 0U;
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(dragonGroupRoleInfo.roleid);
					bool flag3 = entity != null;
					if (flag3)
					{
						XRoleAttributes xroleAttributes = (XRoleAttributes)entity.Attributes;
						chatFriendData.profession = (uint)xroleAttributes.Profession;
					}
					DlgBase<XChatView, XChatBehaviour>.singleton.PrivateChatTo(chatFriendData);
				}
				result = true;
			}
			return result;
		}

		private void SetupPartnerInfo()
		{
			List<DragonGroupRoleInfo> dragonGroupRoleInfoLsit = this._doc.DragonGroupRoleInfoLsit;
			bool flag = this.m_dragonGroupRoleInfoList == null;
			if (flag)
			{
				this.m_dragonGroupRoleInfoList = new List<DragonGroupRoleInfo>();
			}
			this.m_dragonGroupRoleInfoList.Clear();
			bool flag2 = dragonGroupRoleInfoLsit != null;
			if (flag2)
			{
				for (int i = 0; i < dragonGroupRoleInfoLsit.Count; i++)
				{
					this.m_dragonGroupRoleInfoList.Add(dragonGroupRoleInfoLsit[i]);
				}
			}
			this._EmptyDetail.gameObject.SetActive(this.m_dragonGroupRoleInfoList.Count == 0);
			this.SortRoleInfoList();
			bool flag3 = this.m_dragonGroupRoleInfoList.Count == 0;
			if (flag3)
			{
				this.m_WrapContent.SetContentCount(0, false);
			}
			else
			{
				this.m_WrapContent.SetContentCount(this.m_dragonGroupRoleInfoList.Count, false);
			}
			this.m_ScrollView.ResetPosition();
		}

		private void SortRoleInfoList()
		{
			this.m_dragonGroupRoleInfoList.Sort(new Comparison<DragonGroupRoleInfo>(this.ComparePartner));
		}

		private int ComparePartner(DragonGroupRoleInfo a, DragonGroupRoleInfo b)
		{
			bool flag = a.stageTime != b.stageTime;
			int result;
			if (flag)
			{
				result = b.stageTime.CompareTo(a.stageTime);
			}
			else
			{
				result = b.stageCount.CompareTo(a.stageCount);
			}
			return result;
		}

		private XDragonPartnerDocument _doc = null;

		private XExpeditionDocument _expDoc = null;

		private XDragonNestDocument _dnDoc = null;

		private List<DragonGroupRoleInfo> m_dragonGroupRoleInfoList;

		private IXUIButton m_BtnDragonNest;

		private IXUIButton m_BtnRecruit;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private Transform _EmptyDetail;
	}
}
