using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HomeMainDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return HomeMainDocument.uuID;
			}
		}

		public static HomeMainDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(HomeMainDocument.uuID) as HomeMainDocument;
			}
		}

		public bool HomeMainRedDot
		{
			get
			{
				return this.m_homeMainRedDot;
			}
			set
			{
				bool flag = this.m_homeMainRedDot != value;
				if (flag)
				{
					this.m_homeMainRedDot = value;
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Home, true);
				}
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			HomeMainDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_FAMILYGARDEN;
			if (flag)
			{
				HomePlantDocument doc = HomePlantDocument.Doc;
				doc.ClearFarmInfo();
				doc.HomeSprite.ClearInfo();
				HomePlantDocument.Doc.FetchPlantInfo(0U);
			}
			base.OnEnterSceneFinally();
		}

		public void ReqEnterHomeScene(ulong roleId, string name = "")
		{
			HomePlantDocument.Doc.GardenId = roleId;
			HomePlantDocument.Doc.HomeOwnerName = name;
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new EventDelegate(this.ReqEnterHomeScene));
			if (!flag)
			{
				this.ReqEnterHomeScene();
			}
		}

		public void ReqEnterHomeScene()
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("HomeSceneID");
			ptcC2G_EnterSceneReq.Data.roleID = HomePlantDocument.Doc.GardenId;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
		}

		public void ReqLeaveHome()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			HomePlantDocument doc = HomePlantDocument.Doc;
			doc.ClearFarmInfo();
			doc.HomeSprite.ClearInfo();
			doc.GardenId = 0UL;
		}

		public void ReqGardenOverview()
		{
			RpcC2M_GardenOverview rpc = new RpcC2M_GardenOverview();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void ReqPlantFriendList()
		{
			RpcC2M_FriendGardenPlantLog rpc = new RpcC2M_FriendGardenPlantLog();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void RefreshCookingInfo(uint foodID, GardenCookingFoodRes res)
		{
			this._cookingLevel = res.cooking_level;
			this._cookingExp = res.cooking_experiences;
			foreach (HomeMainDocument.FoodCookedInfo foodCookedInfo in this._foodCookedInfoList)
			{
				bool flag = foodCookedInfo.food_id == (ulong)foodID;
				if (flag)
				{
					foodCookedInfo.cookedTimes += 1U;
					return;
				}
			}
			bool flag2 = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(foodID).Frequency > 0U;
			if (flag2)
			{
				this._foodCookedInfoList.Add(new HomeMainDocument.FoodCookedInfo
				{
					food_id = (ulong)foodID,
					cookedTimes = 1U
				});
			}
		}

		public bool IsInMyOwnHomeGarden()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType == SceneType.SCENE_FAMILYGARDEN;
			if (flag)
			{
				HomeTypeEnum homeType = HomePlantDocument.Doc.HomeType;
				bool flag2 = homeType == HomeTypeEnum.MyHome;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public void OnGetGardenOverview(GardenOverviewRes oRes)
		{
			this._cookingLevel = oRes.cooking_level;
			this._cookingExp = oRes.cooking_experiences;
			int i = Math.Min(oRes.food_id.Count, this._foodCookedInfoList.Count);
			for (int j = 0; j < i; j++)
			{
				this._foodCookedInfoList[j].food_id = oRes.food_id[j].key;
				this._foodCookedInfoList[j].cookedTimes = oRes.food_id[j].value;
			}
			while (i < oRes.food_id.Count)
			{
				this._foodCookedInfoList.Add(new HomeMainDocument.FoodCookedInfo
				{
					food_id = oRes.food_id[i].key,
					cookedTimes = oRes.food_id[i].value
				});
				i++;
			}
			bool flag = i < this._foodCookedInfoList.Count;
			if (flag)
			{
				this._foodCookedInfoList.RemoveRange(i, this._foodCookedInfoList.Count - i);
			}
			this.m_hadTroublemaker = (oRes.sprite_id > 0U);
			this.m_visitedTimes = oRes.visited_times;
			this.m_fishLevel = oRes.fish_level;
			this.m_fishBaitNum = (uint)XBagDocument.BagDoc.GetItemCount(5500);
			this.m_maxCanPlantAmount = oRes.plant_farmland_max;
			this.m_plantAmount = (uint)oRes.plant_info.Count;
			this.m_plantFriendList = oRes.friend_log;
			this.SetHarvestTimeFarm(oRes.plant_info, oRes.server_time);
			this.SetHomeLog(oRes.event_log, oRes.server_time);
			this.SetHomeState(oRes.plant_info);
			this.m_plantFriendList.Sort(new Comparison<FriendPlantLog>(this.FriendListCompare));
			this.RefreshUI();
		}

		private int FriendListCompare(FriendPlantLog left, FriendPlantLog right)
		{
			bool flag = left.abnormal_state | left.exist_sprite | left.mature;
			int result;
			if (flag)
			{
				bool flag2 = right.abnormal_state | right.exist_sprite | right.mature;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				bool flag3 = right.abnormal_state | right.exist_sprite | right.mature;
				if (flag3)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		public void OnGetPlantFriendList(FriendGardenPlantLogRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					this.m_plantFriendList = oRes.frinend_plant_log;
					this.m_plantFriendList.Sort(new Comparison<FriendPlantLog>(this.FriendListCompare));
					bool flag3 = this.HomeFriend != null && this.HomeFriend.IsVisible();
					if (flag3)
					{
						this.HomeFriend.RefreshUi();
					}
				}
			}
		}

		private void RefreshUI()
		{
			bool flag = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.CurrentSysIs(XSysDefine.XSys_Home_MyHome);
			if (flag)
			{
				bool flag2 = this.HomeHandler != null && this.HomeHandler.IsVisible();
				if (flag2)
				{
					this.HomeHandler.RefreshUi();
				}
			}
			else
			{
				bool flag3 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.CurrentSysIs(XSysDefine.XSys_Home_Cooking);
				if (flag3)
				{
					bool flag4 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler != null && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.IsVisible();
					if (flag4)
					{
						DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.RefreshUI();
					}
				}
				else
				{
					bool flag5 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.CurrentSysIs(XSysDefine.XSys_Home_Feast);
					if (flag5)
					{
						bool flag6 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler != null && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.IsVisible();
						if (flag6)
						{
							DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.RefreshUI();
						}
					}
					else
					{
						bool flag7 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.CurrentSysIs(XSysDefine.XSys_Home_HomeFriends);
						if (flag7)
						{
							bool flag8 = this.HomeFriend != null && this.HomeFriend.IsVisible();
							if (flag8)
							{
								this.HomeFriend.RefreshUi();
							}
						}
					}
				}
			}
		}

		public uint GetCookingLevel()
		{
			return this._cookingLevel;
		}

		public uint GetCookingExp()
		{
			return this._cookingExp;
		}

		public bool IsFoodIDActive(uint foodId)
		{
			bool flag = XHomeCookAndPartyDocument.Doc.IsFoodIdActiveInTable(foodId);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				for (int i = 0; i < this._foodCookedInfoList.Count; i++)
				{
					bool flag2 = this._foodCookedInfoList[i].food_id == (ulong)foodId;
					if (flag2)
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		public uint GetFoodMakedTimes(uint foodId)
		{
			for (int i = 0; i < this._foodCookedInfoList.Count; i++)
			{
				bool flag = this._foodCookedInfoList[i].food_id == (ulong)foodId;
				if (flag)
				{
					return this._foodCookedInfoList[i].cookedTimes;
				}
			}
			return 0U;
		}

		public bool IsHadRedDot
		{
			get
			{
				return this.m_hadTroublemaker | this.m_bHadHarvest;
			}
		}

		public uint VisitedTimes
		{
			get
			{
				return this.m_visitedTimes;
			}
		}

		public uint FishLevel
		{
			get
			{
				return this.m_fishLevel;
			}
		}

		public uint PlantAmount
		{
			get
			{
				return this.m_plantAmount;
			}
		}

		public uint MaxCanPlantAmount
		{
			get
			{
				return this.m_maxCanPlantAmount;
			}
		}

		public List<HomeEventLog> HomeLogList
		{
			get
			{
				return this.m_homeLogList;
			}
		}

		public List<FriendPlantLog> PlantFriendList
		{
			get
			{
				return this.m_plantFriendList;
			}
		}

		public uint FishBaitNum
		{
			get
			{
				return this.m_fishBaitNum;
			}
		}

		public bool HadTroublemaker
		{
			get
			{
				return this.m_hadTroublemaker;
			}
		}

		public bool HadHarvest
		{
			get
			{
				return this.m_bHadHarvest;
			}
		}

		public bool HadSpecificState
		{
			get
			{
				return this.m_bHadSpecificState;
			}
		}

		public Farmland ShowFarm
		{
			get
			{
				return this.m_showFarm;
			}
		}

		private void SetHomeLog(List<GardenEventLog> lst, uint severTime)
		{
			this.m_homeLogList.Clear();
			for (int i = 0; i < lst.Count; i++)
			{
				HomeEventLog item = new HomeEventLog(lst[i], severTime);
				this.m_homeLogList.Add(item);
			}
		}

		private void SetHomeState(List<PlantInfo> lst)
		{
			this.m_bHadHarvest = false;
			this.m_bHadSpecificState = false;
			for (int i = 0; i < lst.Count; i++)
			{
				bool flag = lst[i].plant_grow_state == PlantGrowState.growMature;
				if (flag)
				{
					this.m_bHadHarvest = true;
				}
				else
				{
					bool flag2 = lst[i].plant_grow_state != PlantGrowState.growCD;
					if (flag2)
					{
						this.m_bHadSpecificState = true;
					}
				}
			}
		}

		private void SetHarvestTimeFarm(List<PlantInfo> lst, uint severTime)
		{
			this.m_showFarm = null;
			bool flag = lst == null || lst.Count == 0;
			if (!flag)
			{
				for (int i = 0; i < lst.Count; i++)
				{
					Farmland farmland = new Farmland(lst[i].farmland_id);
					farmland.SetFarmInfo(lst[i].seed_id, lst[i].growup_amount, lst[i].notice_times, (ulong)lst[i].start_time, lst[i].owner);
					farmland.SetFarmlandLog(lst[i].event_log, severTime);
					farmland.SetCropState(lst[i].plant_grow_state);
					bool flag2 = farmland.Stage == GrowStage.Ripe;
					if (flag2)
					{
						this.m_showFarm = farmland;
						break;
					}
					bool flag3 = this.m_showFarm == null;
					if (flag3)
					{
						this.m_showFarm = farmland;
					}
					else
					{
						bool flag4 = this.m_showFarm.GrowLeftTime() > farmland.GrowLeftTime();
						if (flag4)
						{
							this.m_showFarm = farmland;
						}
					}
				}
			}
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			this.m_gapTime += fDeltaT;
			bool flag = this.m_gapTime < 60f;
			if (!flag)
			{
				this.m_gapTime = 0f;
				bool flag2 = this.m_showFarm == null || this.m_showFarm.IsFree;
				if (!flag2)
				{
					this.m_showFarm.UpdateGrowth();
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeMainDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private bool m_homeMainRedDot = false;

		private uint _cookingLevel = 0U;

		private uint _cookingExp = 0U;

		private List<HomeMainDocument.FoodCookedInfo> _foodCookedInfoList = new List<HomeMainDocument.FoodCookedInfo>();

		private bool m_bHadHarvest = false;

		private bool m_bHadSpecificState = false;

		private uint m_visitedTimes = 0U;

		private uint m_fishLevel = 0U;

		private uint m_plantAmount = 0U;

		private uint m_fishBaitNum = 0U;

		private uint m_maxCanPlantAmount = 0U;

		private bool m_hadTroublemaker = false;

		private Farmland m_showFarm;

		private List<HomeEventLog> m_homeLogList = new List<HomeEventLog>();

		private List<FriendPlantLog> m_plantFriendList = new List<FriendPlantLog>();

		public MyHomeHandler HomeHandler;

		public HomeFriendHandler HomeFriend;

		private float m_gapTime = 0f;

		public class FoodCookedInfo
		{

			public ulong food_id = 0UL;

			public uint cookedTimes = 0U;
		}
	}
}
