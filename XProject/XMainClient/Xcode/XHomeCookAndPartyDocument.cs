using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHomeCookAndPartyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XHomeCookAndPartyDocument.uuID;
			}
		}

		public static XHomeCookAndPartyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XHomeCookAndPartyDocument.uuID) as XHomeCookAndPartyDocument;
			}
		}

		public static CookingFoodInfo CookingFoolInfoTable
		{
			get
			{
				return XHomeCookAndPartyDocument._cookingFoodInfoTable;
			}
		}

		public static CookingLevel CookingLevelTable
		{
			get
			{
				return XHomeCookAndPartyDocument._cookingLevelTable;
			}
		}

		public static GardenBanquetCfg GardenBanquetCfgTable
		{
			get
			{
				return XHomeCookAndPartyDocument._gardenBanquetCfg;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/CookingFoodInfo", XHomeCookAndPartyDocument._cookingFoodInfoTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/CookingLevel", XHomeCookAndPartyDocument._cookingLevelTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/GardenBanquetCfg", XHomeCookAndPartyDocument._gardenBanquetCfg, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/ItemBuff", XHomeCookAndPartyDocument._itemBuffTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.Execute(callback);
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
			this.ResetBanquetState();
		}

		private void ResetBanquetState()
		{
			bool flag = this._curBanquetID > 0U;
			if (flag)
			{
				this._curBanquetID = 0U;
				bool flag2 = this._curBanquetState > 0U;
				if (flag2)
				{
					XSingleton<XInput>.singleton.Freezed = false;
				}
				this._curBanquetState = 0U;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ResetBanquetState();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public uint CurBanquetID
		{
			get
			{
				return this._curBanquetID;
			}
			set
			{
				this._curBanquetID = value;
			}
		}

		public uint CurBanquetState
		{
			get
			{
				return this._curBanquetState;
			}
			set
			{
				this._curBanquetState = value;
			}
		}

		public CookingFoodInfo.RowData GetCookInfoByCuisineID(uint id)
		{
			for (int i = 0; i < XHomeCookAndPartyDocument._cookingFoodInfoTable.Table.Length; i++)
			{
				bool flag = XHomeCookAndPartyDocument._cookingFoodInfoTable.Table[i].FoodID == id;
				if (flag)
				{
					return XHomeCookAndPartyDocument._cookingFoodInfoTable.Table[i];
				}
			}
			return null;
		}

		public GardenBanquetCfg.RowData GetGardenBanquetInfoByID(uint id)
		{
			GardenBanquetCfg.RowData[] table = XHomeCookAndPartyDocument._gardenBanquetCfg.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].BanquetID == id;
				if (flag)
				{
					return table[i];
				}
			}
			return null;
		}

		public bool IsFoodIdActiveInTable(uint id)
		{
			for (int i = 0; i < XHomeCookAndPartyDocument.CookingFoolInfoTable.Table.Length; i++)
			{
				bool flag = XHomeCookAndPartyDocument.CookingFoolInfoTable.Table[i].FoodID == id;
				if (flag)
				{
					return XHomeCookAndPartyDocument.CookingFoolInfoTable.Table[i].CookBookID == 0U;
				}
			}
			return false;
		}

		public void ReqGardenCookingFood(uint foodId)
		{
			RpcC2M_GardenCookingFood rpcC2M_GardenCookingFood = new RpcC2M_GardenCookingFood();
			rpcC2M_GardenCookingFood.oArg.food_id = foodId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenCookingFood);
		}

		public void AddNewCookItem(uint id)
		{
			bool flag = !this._newCookingItems.Contains(id);
			if (flag)
			{
				this._newCookingItems.Add(id);
			}
		}

		public bool RemoveNewCookItem(uint id)
		{
			bool flag = this._newCookingItems.Contains(id);
			bool result;
			if (flag)
			{
				this._newCookingItems.Remove(id);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool IsNewAddedCookItem(uint id)
		{
			return this._newCookingItems.Contains(id);
		}

		public void StartCreateFood(uint foodID)
		{
			CookingFoodInfo.RowData cookInfoByCuisineID = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(foodID);
			bool flag = cookInfoByCuisineID != null;
			if (flag)
			{
				this._timeToCooking = cookInfoByCuisineID.Duration;
				this._curPassedTime = 0f;
				this.TimerUp();
			}
		}

		private void TimerUp()
		{
			this.StopCreateFoodTimer();
			this._timerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(0.025f, new XTimerMgr.AccurateElapsedEventHandler(this.OnCreatingFood), 0.025f);
		}

		public void StopCreateFoodTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerID);
			this._timerID = 0U;
		}

		public void CookingFoodSuccess()
		{
			bool flag = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.IsVisible();
			if (flag)
			{
				DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.CookingSuccess();
			}
		}

		public void BeginToFeast(uint banquet_id)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType != SceneType.SCENE_FAMILYGARDEN;
			if (!flag)
			{
				this._curBanquetID = banquet_id;
				GardenBanquetCfg.RowData gardenBanquetInfoByID = this.GetGardenBanquetInfoByID(this._curBanquetID);
				bool flag2 = gardenBanquetInfoByID != null;
				if (flag2)
				{
					this._curFeastRemainTime = (int)this.GetTotalFeastTimeByID(this._curBanquetID);
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player != null;
					if (flag3)
					{
						XCharacterShowChatComponent xcharacterShowChatComponent = XSingleton<XEntityMgr>.singleton.Player.GetXComponent(XCharacterShowChatComponent.uuID) as XCharacterShowChatComponent;
						bool flag4 = xcharacterShowChatComponent != null;
						if (flag4)
						{
							xcharacterShowChatComponent.AttachFeastCdTime();
							this.CountDownTimerUp();
							XAutoFade.FadeIn(2f, true);
						}
					}
					bool flag5 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler != null && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.IsVisible();
					if (flag5)
					{
						DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.BeginToFeast();
						DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
					}
				}
				else
				{
					this._curFeastRemainTime = 0;
					this._curBanquetID = 0U;
					this._curBanquetState = 0U;
				}
			}
		}

		public void SendActiveFoodMenu(uint foodID)
		{
			RpcC2M_ActiveCookbook rpcC2M_ActiveCookbook = new RpcC2M_ActiveCookbook();
			rpcC2M_ActiveCookbook.oArg.garden_id = HomePlantDocument.Doc.GardenId;
			rpcC2M_ActiveCookbook.oArg.cook_book_id = foodID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ActiveCookbook);
		}

		public string GetFoodNameByID(uint id)
		{
			for (int i = 0; i < XHomeCookAndPartyDocument.CookingFoolInfoTable.Table.Length; i++)
			{
				bool flag = XHomeCookAndPartyDocument.CookingFoolInfoTable.Table[i].FoodID == id;
				if (flag)
				{
					return XHomeCookAndPartyDocument.CookingFoolInfoTable.Table[i].FoodName;
				}
			}
			return "";
		}

		public void SortFoodTableData()
		{
			CookingFoodInfo.RowData[] table = XHomeCookAndPartyDocument._cookingFoodInfoTable.Table;
			for (int i = 0; i < table.Length; i++)
			{
				for (int j = i + 1; j < table.Length; j++)
				{
					bool flag = this.SortData(table[i], table[j]) > 0;
					if (flag)
					{
						CookingFoodInfo.RowData rowData = table[i];
						table[i] = table[j];
						table[j] = rowData;
					}
				}
			}
		}

		public bool IsTimeLimited(uint foodId)
		{
			uint frequency = XHomeCookAndPartyDocument.Doc.GetCookInfoByCuisineID(foodId).Frequency;
			bool flag = frequency <= 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = frequency <= HomeMainDocument.Doc.GetFoodMakedTimes(foodId);
				result = flag2;
			}
			return result;
		}

		public void SendGardenBanquet(uint banquetID)
		{
			RpcC2M_GardenBanquet rpcC2M_GardenBanquet = new RpcC2M_GardenBanquet();
			rpcC2M_GardenBanquet.oArg.banquet_id = banquetID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenBanquet);
		}

		public void OnGardenFeastPhase(PtcG2C_GardenBanquetNotice res)
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			bool flag = sceneType != SceneType.SCENE_FAMILYGARDEN;
			if (!flag)
			{
				this._totalFeastedTimesWeekly = res.Data.timesTSWK;
				this._curBanquetState = res.Data.banquet_stage;
				bool flag2 = this._curBanquetState == 1U;
				if (flag2)
				{
					this.EnableBackToMainCity(false);
					XSingleton<XInput>.singleton.Freezed = true;
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Nav != null;
					if (flag3)
					{
						bool flag4 = XSingleton<XEntityMgr>.singleton.Player.Ator != null;
						if (flag4)
						{
							XSingleton<XEntityMgr>.singleton.Player.Ator.EnableRootMotion(true);
						}
						XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
						XSingleton<XEntityMgr>.singleton.Player.Nav.Enabled = false;
					}
				}
				else
				{
					bool flag5 = this._curBanquetState == 0U;
					if (flag5)
					{
						this.EnableBackToMainCity(true);
						bool flag6 = this.IsHasRewards();
						if (flag6)
						{
							this.OnGetGardenFeastRewards();
						}
						this._curFeastRemainTime = 0;
						this._curBanquetID = 0U;
						XSingleton<XInput>.singleton.Freezed = false;
						bool flag7 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Nav != null;
						if (flag7)
						{
							bool flag8 = XSingleton<XEntityMgr>.singleton.Player.Ator != null;
							if (flag8)
							{
								XSingleton<XEntityMgr>.singleton.Player.Ator.EnableRootMotion(false);
							}
							XSingleton<XEntityMgr>.singleton.Player.Nav.Interrupt();
							XSingleton<XEntityMgr>.singleton.Player.Nav.Enabled = true;
						}
					}
				}
				this.ChangeFeastPhase();
			}
		}

		private bool IsHasRewards()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GardenBanquetAwardTimesTSWK");
			return (ulong)this._totalFeastedTimesWeekly <= (ulong)((long)@int);
		}

		public void OnHomeFeastingCountDown(object argu, float delay)
		{
			this._curFeastRemainTime--;
			XEvent_HomeFeastingArgs @event = XEventPool<XEvent_HomeFeastingArgs>.GetEvent();
			@event.time = (uint)Math.Max(0, this._curFeastRemainTime);
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			bool flag = this._curFeastRemainTime >= 1;
			if (flag)
			{
				this.CountDownTimerUp();
			}
			else
			{
				this.StopCountDownTimer();
			}
		}

		private void CountDownTimerUp()
		{
			this.StopCountDownTimer();
			this._CountDownTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, new XTimerMgr.AccurateElapsedEventHandler(this.OnHomeFeastingCountDown), null);
		}

		private void StopCountDownTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CountDownTimerID);
			this._CountDownTimerID = 0U;
		}

		public void OnGetGardenFeastRewards()
		{
			GardenBanquetCfg.RowData gardenBanquetInfoByID = this.GetGardenBanquetInfoByID(this._curBanquetID);
			bool flag = gardenBanquetInfoByID != null;
			if (flag)
			{
				List<ItemBrief> list = new List<ItemBrief>();
				for (int i = 0; i < gardenBanquetInfoByID.BanquetAwards.Count; i++)
				{
					list.Add(new ItemBrief
					{
						itemID = gardenBanquetInfoByID.BanquetAwards[i, 0],
						itemCount = gardenBanquetInfoByID.BanquetAwards[i, 1]
					});
				}
				DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.ShowByTitle(list, XSingleton<XStringTable>.singleton.GetString("FeastReward"), null);
				bool flag2 = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.IsVisible();
				if (flag2)
				{
					DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeFeastHandler.RefreshPartyBtnState(true);
				}
			}
		}

		public uint GetExpByCookLevel(uint level)
		{
			foreach (CookingLevel.RowData rowData in XHomeCookAndPartyDocument._cookingLevelTable.Table)
			{
				bool flag = rowData.CookLevel == level;
				if (flag)
				{
					return rowData.Experiences;
				}
			}
			return 0U;
		}

		public ItemBuffTable.RowData GetItembuffDataByID(uint id)
		{
			for (int i = 0; i < XHomeCookAndPartyDocument._itemBuffTable.Table.Length; i++)
			{
				ItemBuffTable.RowData rowData = XHomeCookAndPartyDocument._itemBuffTable.Table[i];
				bool flag = rowData.ItemId == id;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		public uint GetItemIDByBuffID(uint id)
		{
			for (int i = 0; i < XHomeCookAndPartyDocument._itemBuffTable.Table.Length; i++)
			{
				ItemBuffTable.RowData rowData = XHomeCookAndPartyDocument._itemBuffTable.Table[i];
				for (int j = 0; j < rowData.Buffs.Count; j++)
				{
					bool flag = rowData.Buffs[j, 0] == id;
					if (flag)
					{
						return rowData.ItemId;
					}
				}
			}
			return 0U;
		}

		private void ChangeFeastPhase()
		{
			GardenBanquetCfg.RowData gardenBanquetInfoByID = this.GetGardenBanquetInfoByID(this._curBanquetID);
			bool flag = gardenBanquetInfoByID == null;
			if (!flag)
			{
				XBubbleEventArgs @event = XEventPool<XBubbleEventArgs>.GetEvent();
				string bubbletext = "";
				uint num = 0U;
				bool flag2 = this._curBanquetState != 0U && (ulong)this._curBanquetState <= (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("HomePartyMaxPhase"));
				if (flag2)
				{
					switch (this._curBanquetState)
					{
					case 1U:
						bubbletext = gardenBanquetInfoByID.VoiceOver1;
						num = gardenBanquetInfoByID.VoiceOver1Duration;
						break;
					case 2U:
						bubbletext = gardenBanquetInfoByID.VoiceOver2;
						num = gardenBanquetInfoByID.VoiceOver2Duration;
						break;
					case 3U:
						bubbletext = gardenBanquetInfoByID.VoiceOver3;
						num = gardenBanquetInfoByID.VoiceOver3Duration;
						break;
					case 4U:
						bubbletext = gardenBanquetInfoByID.VoiceOver4;
						num = gardenBanquetInfoByID.VoiceOver4Duration;
						break;
					default:
						XSingleton<XDebug>.singleton.AddErrorLog("Invalid _curBanquetState", null, null, null, null, null);
						break;
					}
					XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc((uint)XSingleton<XGlobalConfig>.singleton.GetInt("HouseKeeperID"));
					bool flag3 = npc == null;
					if (!flag3)
					{
						@event.bubbletext = bubbletext;
						@event.existtime = num;
						@event.Firer = npc;
						@event.speaker = npc.Name;
						XBubbleComponent xbubbleComponent = @event.Firer.GetXComponent(XBubbleComponent.uuID) as XBubbleComponent;
						bool flag4 = xbubbleComponent == null;
						if (flag4)
						{
							XSingleton<XComponentMgr>.singleton.CreateComponent(@event.Firer, XBubbleComponent.uuID);
						}
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
			}
		}

		public uint GetTotalFeastTimeByID(uint banquetID)
		{
			GardenBanquetCfg.RowData gardenBanquetInfoByID = this.GetGardenBanquetInfoByID(banquetID);
			bool flag = gardenBanquetInfoByID != null;
			uint result;
			if (flag)
			{
				result = gardenBanquetInfoByID.VoiceOver1Duration + gardenBanquetInfoByID.VoiceOver2Duration + gardenBanquetInfoByID.VoiceOver3Duration + gardenBanquetInfoByID.VoiceOver4Duration;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		public string GetHomeFeastAction(uint basicType)
		{
			return string.Format("Player_{0}_{1}", XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord(basicType), "yanhui");
		}

		public uint GetMaxLevel()
		{
			bool flag = this.MaxCookLevel == 0U;
			if (flag)
			{
				uint num = 0U;
				for (int i = 0; i < XHomeCookAndPartyDocument._cookingLevelTable.Table.Length; i++)
				{
					num = Math.Max(XHomeCookAndPartyDocument._cookingLevelTable.Table[i].CookLevel, num);
				}
				this.MaxCookLevel = num;
			}
			return this.MaxCookLevel;
		}

		private void EnableBackToMainCity(bool Enable)
		{
			bool flag = DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.SetVisible(false, true);
			}
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag2 = !Enable;
			if (flag2)
			{
				XSingleton<UIManager>.singleton.CloseAllUI();
			}
			HomeHandler homeHandler = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._HomeHandler;
			bool flag3 = homeHandler != null;
			if (flag3)
			{
				homeHandler.EnableBackToMainCity(Enable);
			}
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.BottomDownBtns(Enable);
		}

		private void OnCreatingFood(object argu, float delay)
		{
			this._curPassedTime += (float)argu;
			bool flag = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.IsVisible();
			if (flag)
			{
				DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.SetProgress(this._curPassedTime / this._timeToCooking);
			}
			bool flag2 = this._curPassedTime >= this._timeToCooking;
			if (flag2)
			{
				this.StopCreateFoodTimer();
			}
			else
			{
				this.TimerUp();
			}
		}

		private int SortData(CookingFoodInfo.RowData x1, CookingFoodInfo.RowData x2)
		{
			int num = x1.Level.CompareTo(x2.Level);
			return (num == 0) ? this.FoodActiveCompare(x1.FoodID, x2.FoodID) : num;
		}

		private int FoodActiveCompare(uint foodIdL, uint foodIdR)
		{
			bool flag = HomeMainDocument.Doc.IsFoodIDActive(foodIdL);
			bool flag2 = HomeMainDocument.Doc.IsFoodIDActive(foodIdR);
			bool flag3 = flag ^ flag2;
			int result;
			if (flag3)
			{
				bool flag4 = flag;
				if (flag4)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeCookAndPartyDocument");

		private static CookingFoodInfo _cookingFoodInfoTable = new CookingFoodInfo();

		private static CookingLevel _cookingLevelTable = new CookingLevel();

		private static GardenBanquetCfg _gardenBanquetCfg = new GardenBanquetCfg();

		private static ItemBuffTable _itemBuffTable = new ItemBuffTable();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private uint MaxCookLevel = 0U;

		private List<uint> _newCookingItems = new List<uint>();

		private uint _timerID = 0U;

		private uint _curBanquetID = 0U;

		private uint _curBanquetState = 0U;

		private uint _CountDownTimerID = 0U;

		private int _curFeastRemainTime = 0;

		private uint _totalFeastedTimesWeekly = 0U;

		private uint _timeToCooking = 5U;

		protected float _curPassedTime = 0f;
	}
}
