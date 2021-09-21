using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C35 RID: 3125
	internal class HomeMainDocument : XDocComponent
	{
		// Token: 0x17003144 RID: 12612
		// (get) Token: 0x0600B115 RID: 45333 RVA: 0x0021E48C File Offset: 0x0021C68C
		public override uint ID
		{
			get
			{
				return HomeMainDocument.uuID;
			}
		}

		// Token: 0x17003145 RID: 12613
		// (get) Token: 0x0600B116 RID: 45334 RVA: 0x0021E4A4 File Offset: 0x0021C6A4
		public static HomeMainDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(HomeMainDocument.uuID) as HomeMainDocument;
			}
		}

		// Token: 0x17003146 RID: 12614
		// (get) Token: 0x0600B117 RID: 45335 RVA: 0x0021E4D0 File Offset: 0x0021C6D0
		// (set) Token: 0x0600B118 RID: 45336 RVA: 0x0021E4E8 File Offset: 0x0021C6E8
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

		// Token: 0x0600B119 RID: 45337 RVA: 0x0021E520 File Offset: 0x0021C720
		public static void Execute(OnLoadedCallback callback = null)
		{
			HomeMainDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B11A RID: 45338 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B11B RID: 45339 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600B11C RID: 45340 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600B11D RID: 45341 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600B11E RID: 45342 RVA: 0x0021E530 File Offset: 0x0021C730
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

		// Token: 0x0600B11F RID: 45343 RVA: 0x0021E580 File Offset: 0x0021C780
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

		// Token: 0x0600B120 RID: 45344 RVA: 0x0021E5C4 File Offset: 0x0021C7C4
		public void ReqEnterHomeScene()
		{
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("HomeSceneID");
			ptcC2G_EnterSceneReq.Data.roleID = HomePlantDocument.Doc.GardenId;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
		}

		// Token: 0x0600B121 RID: 45345 RVA: 0x0021E618 File Offset: 0x0021C818
		public void ReqLeaveHome()
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			HomePlantDocument doc = HomePlantDocument.Doc;
			doc.ClearFarmInfo();
			doc.HomeSprite.ClearInfo();
			doc.GardenId = 0UL;
		}

		// Token: 0x0600B122 RID: 45346 RVA: 0x0021E654 File Offset: 0x0021C854
		public void ReqGardenOverview()
		{
			RpcC2M_GardenOverview rpc = new RpcC2M_GardenOverview();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B123 RID: 45347 RVA: 0x0021E674 File Offset: 0x0021C874
		public void ReqPlantFriendList()
		{
			RpcC2M_FriendGardenPlantLog rpc = new RpcC2M_FriendGardenPlantLog();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600B124 RID: 45348 RVA: 0x0021E694 File Offset: 0x0021C894
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

		// Token: 0x0600B125 RID: 45349 RVA: 0x0021E758 File Offset: 0x0021C958
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

		// Token: 0x0600B126 RID: 45350 RVA: 0x0021E79C File Offset: 0x0021C99C
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

		// Token: 0x0600B127 RID: 45351 RVA: 0x0021E974 File Offset: 0x0021CB74
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

		// Token: 0x0600B128 RID: 45352 RVA: 0x0021E9E0 File Offset: 0x0021CBE0
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

		// Token: 0x0600B129 RID: 45353 RVA: 0x0021EA90 File Offset: 0x0021CC90
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

		// Token: 0x0600B12A RID: 45354 RVA: 0x0021EBC0 File Offset: 0x0021CDC0
		public uint GetCookingLevel()
		{
			return this._cookingLevel;
		}

		// Token: 0x0600B12B RID: 45355 RVA: 0x0021EBD8 File Offset: 0x0021CDD8
		public uint GetCookingExp()
		{
			return this._cookingExp;
		}

		// Token: 0x0600B12C RID: 45356 RVA: 0x0021EBF0 File Offset: 0x0021CDF0
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

		// Token: 0x0600B12D RID: 45357 RVA: 0x0021EC54 File Offset: 0x0021CE54
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

		// Token: 0x17003147 RID: 12615
		// (get) Token: 0x0600B12E RID: 45358 RVA: 0x0021ECB0 File Offset: 0x0021CEB0
		public bool IsHadRedDot
		{
			get
			{
				return this.m_hadTroublemaker | this.m_bHadHarvest;
			}
		}

		// Token: 0x17003148 RID: 12616
		// (get) Token: 0x0600B12F RID: 45359 RVA: 0x0021ECD0 File Offset: 0x0021CED0
		public uint VisitedTimes
		{
			get
			{
				return this.m_visitedTimes;
			}
		}

		// Token: 0x17003149 RID: 12617
		// (get) Token: 0x0600B130 RID: 45360 RVA: 0x0021ECE8 File Offset: 0x0021CEE8
		public uint FishLevel
		{
			get
			{
				return this.m_fishLevel;
			}
		}

		// Token: 0x1700314A RID: 12618
		// (get) Token: 0x0600B131 RID: 45361 RVA: 0x0021ED00 File Offset: 0x0021CF00
		public uint PlantAmount
		{
			get
			{
				return this.m_plantAmount;
			}
		}

		// Token: 0x1700314B RID: 12619
		// (get) Token: 0x0600B132 RID: 45362 RVA: 0x0021ED18 File Offset: 0x0021CF18
		public uint MaxCanPlantAmount
		{
			get
			{
				return this.m_maxCanPlantAmount;
			}
		}

		// Token: 0x1700314C RID: 12620
		// (get) Token: 0x0600B133 RID: 45363 RVA: 0x0021ED30 File Offset: 0x0021CF30
		public List<HomeEventLog> HomeLogList
		{
			get
			{
				return this.m_homeLogList;
			}
		}

		// Token: 0x1700314D RID: 12621
		// (get) Token: 0x0600B134 RID: 45364 RVA: 0x0021ED48 File Offset: 0x0021CF48
		public List<FriendPlantLog> PlantFriendList
		{
			get
			{
				return this.m_plantFriendList;
			}
		}

		// Token: 0x1700314E RID: 12622
		// (get) Token: 0x0600B135 RID: 45365 RVA: 0x0021ED60 File Offset: 0x0021CF60
		public uint FishBaitNum
		{
			get
			{
				return this.m_fishBaitNum;
			}
		}

		// Token: 0x1700314F RID: 12623
		// (get) Token: 0x0600B136 RID: 45366 RVA: 0x0021ED78 File Offset: 0x0021CF78
		public bool HadTroublemaker
		{
			get
			{
				return this.m_hadTroublemaker;
			}
		}

		// Token: 0x17003150 RID: 12624
		// (get) Token: 0x0600B137 RID: 45367 RVA: 0x0021ED90 File Offset: 0x0021CF90
		public bool HadHarvest
		{
			get
			{
				return this.m_bHadHarvest;
			}
		}

		// Token: 0x17003151 RID: 12625
		// (get) Token: 0x0600B138 RID: 45368 RVA: 0x0021EDA8 File Offset: 0x0021CFA8
		public bool HadSpecificState
		{
			get
			{
				return this.m_bHadSpecificState;
			}
		}

		// Token: 0x17003152 RID: 12626
		// (get) Token: 0x0600B139 RID: 45369 RVA: 0x0021EDC0 File Offset: 0x0021CFC0
		public Farmland ShowFarm
		{
			get
			{
				return this.m_showFarm;
			}
		}

		// Token: 0x0600B13A RID: 45370 RVA: 0x0021EDD8 File Offset: 0x0021CFD8
		private void SetHomeLog(List<GardenEventLog> lst, uint severTime)
		{
			this.m_homeLogList.Clear();
			for (int i = 0; i < lst.Count; i++)
			{
				HomeEventLog item = new HomeEventLog(lst[i], severTime);
				this.m_homeLogList.Add(item);
			}
		}

		// Token: 0x0600B13B RID: 45371 RVA: 0x0021EE24 File Offset: 0x0021D024
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

		// Token: 0x0600B13C RID: 45372 RVA: 0x0021EE90 File Offset: 0x0021D090
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

		// Token: 0x0600B13D RID: 45373 RVA: 0x0021EFAC File Offset: 0x0021D1AC
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

		// Token: 0x0400441F RID: 17439
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeMainDocument");

		// Token: 0x04004420 RID: 17440
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004421 RID: 17441
		private bool m_homeMainRedDot = false;

		// Token: 0x04004422 RID: 17442
		private uint _cookingLevel = 0U;

		// Token: 0x04004423 RID: 17443
		private uint _cookingExp = 0U;

		// Token: 0x04004424 RID: 17444
		private List<HomeMainDocument.FoodCookedInfo> _foodCookedInfoList = new List<HomeMainDocument.FoodCookedInfo>();

		// Token: 0x04004425 RID: 17445
		private bool m_bHadHarvest = false;

		// Token: 0x04004426 RID: 17446
		private bool m_bHadSpecificState = false;

		// Token: 0x04004427 RID: 17447
		private uint m_visitedTimes = 0U;

		// Token: 0x04004428 RID: 17448
		private uint m_fishLevel = 0U;

		// Token: 0x04004429 RID: 17449
		private uint m_plantAmount = 0U;

		// Token: 0x0400442A RID: 17450
		private uint m_fishBaitNum = 0U;

		// Token: 0x0400442B RID: 17451
		private uint m_maxCanPlantAmount = 0U;

		// Token: 0x0400442C RID: 17452
		private bool m_hadTroublemaker = false;

		// Token: 0x0400442D RID: 17453
		private Farmland m_showFarm;

		// Token: 0x0400442E RID: 17454
		private List<HomeEventLog> m_homeLogList = new List<HomeEventLog>();

		// Token: 0x0400442F RID: 17455
		private List<FriendPlantLog> m_plantFriendList = new List<FriendPlantLog>();

		// Token: 0x04004430 RID: 17456
		public MyHomeHandler HomeHandler;

		// Token: 0x04004431 RID: 17457
		public HomeFriendHandler HomeFriend;

		// Token: 0x04004432 RID: 17458
		private float m_gapTime = 0f;

		// Token: 0x020019A5 RID: 6565
		public class FoodCookedInfo
		{
			// Token: 0x04007F5B RID: 32603
			public ulong food_id = 0UL;

			// Token: 0x04007F5C RID: 32604
			public uint cookedTimes = 0U;
		}
	}
}
