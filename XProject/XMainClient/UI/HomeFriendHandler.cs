using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A2 RID: 6050
	internal class HomeFriendHandler : DlgHandlerBase
	{
		// Token: 0x1700385C RID: 14428
		// (get) Token: 0x0600FA0C RID: 64012 RVA: 0x0039B74C File Offset: 0x0039994C
		protected override string FileName
		{
			get
			{
				return "Home/HomeFriendHandler";
			}
		}

		// Token: 0x0600FA0D RID: 64013 RVA: 0x0039B764 File Offset: 0x00399964
		protected override void Init()
		{
			this.m_wrapContent = (base.PanelObject.transform.FindChild("Panel/ItemsWrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
			this.m_noFriendsGo = base.PanelObject.transform.FindChild("NoFriends").gameObject;
			this.m_AddFriendsBtn = (this.m_noFriendsGo.transform.FindChild("Add").GetComponent("XUIButton") as IXUIButton);
			this.m_hadFriendsGo = base.PanelObject.transform.FindChild("Panel").gameObject;
			this.m_scrollView = (this.m_hadFriendsGo.transform.GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.PanelObject.transform.FindChild("Item");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 1U, false);
			this.m_doc = HomeMainDocument.Doc;
			this.m_doc.HomeFriend = this;
			base.Init();
		}

		// Token: 0x0600FA0E RID: 64014 RVA: 0x0039B891 File Offset: 0x00399A91
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_AddFriendsBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAddFriendsBtnClick));
		}

		// Token: 0x0600FA0F RID: 64015 RVA: 0x0039B8B3 File Offset: 0x00399AB3
		protected override void OnShow()
		{
			this.m_doc.ReqPlantFriendList();
			base.OnShow();
		}

		// Token: 0x0600FA10 RID: 64016 RVA: 0x0039B8C9 File Offset: 0x00399AC9
		protected override void OnHide()
		{
			this.m_ItemPool.ReturnAll(false);
			base.OnHide();
		}

		// Token: 0x0600FA11 RID: 64017 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FA12 RID: 64018 RVA: 0x0039B8E0 File Offset: 0x00399AE0
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FA13 RID: 64019 RVA: 0x0039B8EC File Offset: 0x00399AEC
		private void FillContent()
		{
			bool flag = this.m_doc.PlantFriendList == null || this.m_doc.PlantFriendList.Count == 0;
			if (flag)
			{
				this.m_noFriendsGo.SetActive(true);
				this.m_hadFriendsGo.SetActive(false);
			}
			else
			{
				this.m_ItemPool.ReturnAll(false);
				this.m_noFriendsGo.SetActive(false);
				this.m_hadFriendsGo.SetActive(true);
				this.m_wrapContent.SetContentCount(this.m_doc.PlantFriendList.Count, false);
			}
			bool flag2 = this.m_scrollView != null;
			if (flag2)
			{
				this.m_scrollView.ResetPosition();
			}
		}

		// Token: 0x0600FA14 RID: 64020 RVA: 0x0039B9A0 File Offset: 0x00399BA0
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.m_doc.PlantFriendList == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("no data", null, null, null, null, null);
			}
			else
			{
				bool flag2 = index >= this.m_doc.PlantFriendList.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("index >= m_doc.PlantFriendList.Count", null, null, null, null, null);
				}
				else
				{
					FriendPlantLog friendPlantLog = this.m_doc.PlantFriendList[index];
					Transform transform = t.FindChild("Info");
					IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)friendPlantLog.profession_id));
					IXUILabel ixuilabel = transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(friendPlantLog.role_name);
					IXUIButton ixuibutton = t.FindChild("VisitBtn").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)index);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnVisitClicked));
					transform = t.FindChild("Status");
					for (int i = 0; i < transform.childCount; i++)
					{
						GameObject gameObject = transform.GetChild(i).gameObject;
						this.m_ItemPool.ReturnInstance(gameObject, false);
					}
					int num = 0;
					bool mature = friendPlantLog.mature;
					if (mature)
					{
						GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
						gameObject.transform.parent = transform;
						gameObject.transform.localPosition = new Vector3((float)(num * this.m_ItemPool.TplWidth), 0f, 0f);
						ixuisprite = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.SetSprite("HomeView_2");
						ixuisprite.ID = 0UL;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickStateIcon));
						num++;
					}
					bool abnormal_state = friendPlantLog.abnormal_state;
					if (abnormal_state)
					{
						GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
						gameObject.transform.parent = transform;
						gameObject.transform.localPosition = new Vector3((float)(-(float)num * this.m_ItemPool.TplWidth), 0f, 0f);
						ixuisprite = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.SetSprite("HomeView_0");
						ixuisprite.ID = 1UL;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickStateIcon));
						num++;
					}
					bool exist_sprite = friendPlantLog.exist_sprite;
					if (exist_sprite)
					{
						GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
						gameObject.transform.parent = transform;
						gameObject.transform.localPosition = new Vector3((float)(-(float)num * this.m_ItemPool.TplWidth), 0f, 0f);
						ixuisprite = (gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.SetSprite("HomeView_1");
						ixuisprite.ID = 2UL;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickStateIcon));
						num++;
					}
					bool flag3 = num == 0;
					if (flag3)
					{
						t.FindChild("No").gameObject.SetActive(true);
					}
					else
					{
						t.FindChild("No").gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600FA15 RID: 64021 RVA: 0x0039BD48 File Offset: 0x00399F48
		private bool OnVisitClicked(IXUIButton sp)
		{
			bool flag = (int)sp.ID >= this.m_doc.PlantFriendList.Count;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				FriendPlantLog friendPlantLog = this.m_doc.PlantFriendList[(int)sp.ID];
				bool flag2 = friendPlantLog == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("not find data", null, null, null, null, null);
					result = true;
				}
				else
				{
					SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
					bool flag3 = sceneType == SceneType.SCENE_FAMILYGARDEN;
					if (flag3)
					{
						ulong gardenId = HomePlantDocument.Doc.GardenId;
						bool flag4 = gardenId == friendPlantLog.role_id;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("EnterOtherHomeAgainTips"), friendPlantLog.role_name), "fece00");
							return true;
						}
					}
					this.m_doc.ReqEnterHomeScene(friendPlantLog.role_id, friendPlantLog.role_name);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FA16 RID: 64022 RVA: 0x0039BE34 File Offset: 0x0039A034
		private void ClickStateIcon(IXUISprite spr)
		{
			ulong id = spr.ID;
			ulong num = id;
			if (num <= 2UL)
			{
				switch ((uint)num)
				{
				case 0U:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CanStealTips"), "fece00");
					break;
				case 1U:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CanHelpFriend"), "fece00");
					break;
				case 2U:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DriveTroubleMaker"), "fece00");
					break;
				}
			}
		}

		// Token: 0x0600FA17 RID: 64023 RVA: 0x0039BEBC File Offset: 0x0039A0BC
		private bool OnAddFriendsBtnClick(IXUIButton btn)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
			return true;
		}

		// Token: 0x04006D86 RID: 28038
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D87 RID: 28039
		private IXUIWrapContent m_wrapContent;

		// Token: 0x04006D88 RID: 28040
		private GameObject m_noFriendsGo;

		// Token: 0x04006D89 RID: 28041
		private IXUIButton m_AddFriendsBtn;

		// Token: 0x04006D8A RID: 28042
		private GameObject m_hadFriendsGo;

		// Token: 0x04006D8B RID: 28043
		private HomeMainDocument m_doc;

		// Token: 0x04006D8C RID: 28044
		private IXUIScrollView m_scrollView;
	}
}
