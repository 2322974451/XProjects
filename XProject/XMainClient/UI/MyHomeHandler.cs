using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class MyHomeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Home/MyHomeHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_gotoMyHome.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGotoHome));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			this.m_LogItemPool.ReturnAll(false);
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void RefreshUi()
		{
			this.FillContent();
		}

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

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_LogItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton m_gotoMyHome;

		private Transform m_visitedTimesTra;

		private Transform m_fishingLevelTra;

		private Transform m_baitNumTra;

		private Transform m_plantNumTra;

		private Transform m_harvestTimeTra;

		private Transform m_homeStatusTra;

		private GameObject m_hadFriendsGo;

		private GameObject m_noFriendsGo;

		private GameObject m_hadInfoGo;

		private GameObject m_noInfoGo;

		private GameObject m_redDotGo;

		private IXUIWrapContent m_friendsRankWrap;

		private HomeMainDocument m_doc;
	}
}
