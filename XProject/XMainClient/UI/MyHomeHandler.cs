using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017A6 RID: 6054
	internal class MyHomeHandler : DlgHandlerBase
	{
		// Token: 0x1700386A RID: 14442
		// (get) Token: 0x0600FA4D RID: 64077 RVA: 0x0039D0DC File Offset: 0x0039B2DC
		protected override string FileName
		{
			get
			{
				return "Home/MyHomeHandler";
			}
		}

		// Token: 0x0600FA4E RID: 64078 RVA: 0x0039D0F4 File Offset: 0x0039B2F4
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("HomeInfo");
			this.m_gotoMyHome = (transform.FindChild("GoToHome").GetComponent("XUIButton") as IXUIButton);
			this.m_redDotGo = transform.FindChild("RedPoint").gameObject;
			this.m_visitedTimesTra = transform.FindChild("VisitedTimes");
			this.m_fishingLevelTra = transform.FindChild("FishingLevel");
			this.m_baitNumTra = transform.FindChild("BaitNum");
			this.m_plantNumTra = transform.FindChild("PlantNum");
			this.m_harvestTimeTra = transform.FindChild("HarvestTime");
			this.m_homeStatusTra = transform.FindChild("HomeStatus");
			transform = this.m_homeStatusTra.FindChild("Status");
			this.m_ItemPool.SetupPool(transform.gameObject, transform.FindChild("Icon").gameObject, 3U, false);
			this.m_hadInfoGo = base.PanelObject.transform.FindChild("HomeLog/Panel").gameObject;
			this.m_noInfoGo = base.PanelObject.transform.FindChild("HomeLog/NoInfo").gameObject;
			transform = base.PanelObject.transform.FindChild("HomeLog/Panel/LabsWrap");
			this.m_LogItemPool.SetupPool(transform.gameObject, transform.FindChild("Tpl").gameObject, 2U, false);
			this.m_hadFriendsGo = base.PanelObject.transform.FindChild("FriendsRank/Panel").gameObject;
			this.m_noFriendsGo = base.PanelObject.transform.FindChild("FriendsRank/NoFriends").gameObject;
			transform = base.PanelObject.transform.FindChild("FriendsRank/Panel");
			this.m_friendsRankWrap = (transform.FindChild("ItemsWrap").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_friendsRankWrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.FriendsRankWrapItemUpdated));
			this.m_doc = HomeMainDocument.Doc;
			this.m_doc.HomeHandler = this;
		}

		// Token: 0x0600FA4F RID: 64079 RVA: 0x0039D30F File Offset: 0x0039B50F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_gotoMyHome.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoHome));
		}

		// Token: 0x0600FA50 RID: 64080 RVA: 0x0039D331 File Offset: 0x0039B531
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FA51 RID: 64081 RVA: 0x0039D342 File Offset: 0x0039B542
		protected override void OnHide()
		{
			this.m_LogItemPool.ReturnAll(false);
			base.OnHide();
		}

		// Token: 0x0600FA52 RID: 64082 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FA53 RID: 64083 RVA: 0x0039D359 File Offset: 0x0039B559
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FA54 RID: 64084 RVA: 0x0039D364 File Offset: 0x0039B564
		private void FillContent()
		{
			this.m_redDotGo.SetActive(this.m_doc.IsHadRedDot);
			IXUILabel ixuilabel = this.m_visitedTimesTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this.m_doc.VisitedTimes.ToString());
			ixuilabel = (this.m_fishingLevelTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_LEVEL_FMT"), this.m_doc.FishLevel));
			ixuilabel = (this.m_baitNumTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(this.m_doc.FishBaitNum.ToString());
			ixuilabel = (this.m_plantNumTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(string.Format("{0}/{1}", this.m_doc.PlantAmount, this.m_doc.MaxCanPlantAmount));
			ixuilabel = (this.m_harvestTimeTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			bool flag = this.m_doc.ShowFarm == null;
			if (flag)
			{
				ixuilabel.SetText(XStringDefineProxy.GetString("CanPlanting"));
			}
			else
			{
				bool flag2 = this.m_doc.ShowFarm.Stage == GrowStage.Ripe;
				if (flag2)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString("CanHarvest"));
				}
				else
				{
					ixuilabel.SetText(this.GetTimeString(this.m_doc.ShowFarm.GrowLeftTime()));
				}
			}
			this.m_ItemPool.ReturnAll(false);
			int num = 0;
			bool hadHarvest = this.m_doc.HadHarvest;
			if (hadHarvest)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(-(float)num * this.m_ItemPool.TplWidth), 0f, 0f);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite("HomeView_2");
				num++;
			}
			bool hadSpecificState = this.m_doc.HadSpecificState;
			if (hadSpecificState)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(-(float)num * this.m_ItemPool.TplWidth), 0f, 0f);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite("HomeView_0");
				num++;
			}
			bool hadTroublemaker = this.m_doc.HadTroublemaker;
			if (hadTroublemaker)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(-(float)num * this.m_ItemPool.TplWidth), 0f, 0f);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite("HomeView_1");
				num++;
			}
			bool flag3 = this.m_doc.HomeLogList == null || this.m_doc.HomeLogList.Count == 0;
			if (flag3)
			{
				this.m_hadInfoGo.SetActive(false);
				this.m_noInfoGo.SetActive(true);
			}
			else
			{
				this.m_hadInfoGo.SetActive(true);
				this.m_noInfoGo.SetActive(false);
				this.SetHomeLog();
			}
			bool flag4 = this.m_doc.PlantFriendList == null || this.m_doc.PlantFriendList.Count == 0;
			if (flag4)
			{
				this.m_hadFriendsGo.SetActive(false);
				this.m_noFriendsGo.SetActive(true);
			}
			else
			{
				this.m_hadFriendsGo.SetActive(true);
				this.m_noFriendsGo.SetActive(false);
				this.m_friendsRankWrap.SetContentCount(this.m_doc.PlantFriendList.Count, false);
			}
		}

		// Token: 0x0600FA55 RID: 64085 RVA: 0x0039D774 File Offset: 0x0039B974
		private void SetHomeLog()
		{
			this.m_LogItemPool.ReturnAll(false);
			float num = 0f;
			for (int i = 0; i < this.m_doc.HomeLogList.Count; i++)
			{
				GameObject gameObject = this.m_LogItemPool.FetchGameObject(false);
				gameObject.SetActive(false);
				gameObject.SetActive(true);
				gameObject.transform.localPosition = new Vector3(0f, num, 0f);
				HomeEventLog homeEventLog = this.m_doc.HomeLogList[i];
				IXUILabel ixuilabel = gameObject.transform.GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(homeEventLog.Txt);
				num -= (float)(ixuilabel.spriteHeight + 5);
				ixuilabel = (gameObject.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(homeEventLog.Time);
			}
		}

		// Token: 0x0600FA56 RID: 64086 RVA: 0x0039D86C File Offset: 0x0039BA6C
		private void FriendsRankWrapItemUpdated(Transform t, int index)
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
					bool flag3 = index >= 3;
					if (!flag3)
					{
						FriendPlantLog friendPlantLog = this.m_doc.PlantFriendList[index];
						Transform transform = t.FindChild("Info");
						IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)friendPlantLog.profession_id));
						IXUILabel ixuilabel = transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(friendPlantLog.role_name);
						ixuilabel = (transform.FindChild("Times").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText(string.Format("{0}{1}", XStringDefineProxy.GetString("HelpTimes"), friendPlantLog.help_times));
						IXUIButton ixuibutton = t.FindChild("VisitBtn").GetComponent("XUIButton") as IXUIButton;
						ixuibutton.ID = (ulong)((long)index);
						ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoOtherHome));
						this.SetRank(t, index);
					}
				}
			}
		}

		// Token: 0x0600FA57 RID: 64087 RVA: 0x0039D9F0 File Offset: 0x0039BBF0
		private void SetRank(Transform tra, int rankIndex)
		{
			IXUILabel ixuilabel = tra.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = tra.FindChild("RankImage").GetComponent("XUISprite") as IXUISprite;
			bool flag = (long)rankIndex == (long)((ulong)XRankDocument.INVALID_RANK);
			if (flag)
			{
				ixuilabel.SetVisible(false);
				ixuisprite.SetVisible(false);
			}
			else
			{
				bool flag2 = rankIndex < 3;
				if (flag2)
				{
					ixuisprite.SetSprite("N" + (rankIndex + 1));
					ixuisprite.SetVisible(true);
					ixuilabel.SetVisible(false);
				}
				else
				{
					ixuisprite.SetVisible(false);
					ixuilabel.SetText((rankIndex + 1).ToString());
					ixuilabel.SetVisible(true);
				}
			}
		}

		// Token: 0x0600FA58 RID: 64088 RVA: 0x0039DAB0 File Offset: 0x0039BCB0
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_doc == null || this.m_doc.ShowFarm == null;
			if (!flag)
			{
				IXUILabel ixuilabel = this.m_harvestTimeTra.FindChild("Num").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = this.m_doc.ShowFarm.Stage == GrowStage.Ripe;
				if (flag2)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString("CanHarvest"));
				}
				else
				{
					bool flag3 = this.m_doc.ShowFarm.Stage > GrowStage.None;
					if (flag3)
					{
						ixuilabel.SetText(this.GetTimeString(this.m_doc.ShowFarm.GrowLeftTime()));
					}
				}
			}
		}

		// Token: 0x0600FA59 RID: 64089 RVA: 0x0039DB64 File Offset: 0x0039BD64
		private string GetTimeString(long ti)
		{
			bool flag = ti < 60L;
			string result;
			if (flag)
			{
				string text = string.Format("{0}{1}", ti, XStringDefineProxy.GetString("MINUTE_DUARATION"));
				result = text;
			}
			else
			{
				long num = ti / 60L;
				long num2 = ti % 60L;
				bool flag2 = num2 != 0L;
				string text;
				if (flag2)
				{
					text = string.Format("{0}{1}{2}{3}", new object[]
					{
						num,
						XStringDefineProxy.GetString("HOUR_DUARATION"),
						num2,
						XStringDefineProxy.GetString("MINUTE_DUARATION")
					});
				}
				else
				{
					text = string.Format("{0}{1}", num, XStringDefineProxy.GetString("HOUR_DUARATION"));
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600FA5A RID: 64090 RVA: 0x0039DC1C File Offset: 0x0039BE1C
		private bool OnGotoHome(IXUIButton btn)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType == SceneType.SCENE_FAMILYGARDEN;
			if (flag)
			{
				HomeTypeEnum homeType = HomePlantDocument.Doc.HomeType;
				bool flag2 = homeType == HomeTypeEnum.MyHome;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EnterHomeAgainTips"), "fece00");
					return true;
				}
			}
			DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
			this.m_doc.ReqEnterHomeScene(XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID, XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
			return true;
		}

		// Token: 0x0600FA5B RID: 64091 RVA: 0x0039DCB4 File Offset: 0x0039BEB4
		private bool OnGotoOtherHome(IXUIButton btn)
		{
			FriendPlantLog friendPlantLog = this.m_doc.PlantFriendList[(int)btn.ID];
			bool flag = friendPlantLog == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find data", null, null, null, null, null);
				result = true;
			}
			else
			{
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				bool flag2 = sceneType == SceneType.SCENE_FAMILYGARDEN;
				if (flag2)
				{
					ulong gardenId = HomePlantDocument.Doc.GardenId;
					bool flag3 = gardenId == friendPlantLog.role_id;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("EnterOtherHomeAgainTips"), friendPlantLog.role_name), "fece00");
						return true;
					}
				}
				this.m_doc.ReqEnterHomeScene(friendPlantLog.role_id, friendPlantLog.role_name);
				result = true;
			}
			return result;
		}

		// Token: 0x04006DAB RID: 28075
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006DAC RID: 28076
		private XUIPool m_LogItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006DAD RID: 28077
		private IXUIButton m_gotoMyHome;

		// Token: 0x04006DAE RID: 28078
		private Transform m_visitedTimesTra;

		// Token: 0x04006DAF RID: 28079
		private Transform m_fishingLevelTra;

		// Token: 0x04006DB0 RID: 28080
		private Transform m_baitNumTra;

		// Token: 0x04006DB1 RID: 28081
		private Transform m_plantNumTra;

		// Token: 0x04006DB2 RID: 28082
		private Transform m_harvestTimeTra;

		// Token: 0x04006DB3 RID: 28083
		private Transform m_homeStatusTra;

		// Token: 0x04006DB4 RID: 28084
		private GameObject m_hadFriendsGo;

		// Token: 0x04006DB5 RID: 28085
		private GameObject m_noFriendsGo;

		// Token: 0x04006DB6 RID: 28086
		private GameObject m_hadInfoGo;

		// Token: 0x04006DB7 RID: 28087
		private GameObject m_noInfoGo;

		// Token: 0x04006DB8 RID: 28088
		private GameObject m_redDotGo;

		// Token: 0x04006DB9 RID: 28089
		private IXUIWrapContent m_friendsRankWrap;

		// Token: 0x04006DBA RID: 28090
		private HomeMainDocument m_doc;
	}
}
