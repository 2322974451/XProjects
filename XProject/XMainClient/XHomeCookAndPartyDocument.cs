using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C34 RID: 3124
	internal class XHomeCookAndPartyDocument : XDocComponent
	{
		// Token: 0x1700313D RID: 12605
		// (get) Token: 0x0600B0E1 RID: 45281 RVA: 0x0021D454 File Offset: 0x0021B654
		public override uint ID
		{
			get
			{
				return XHomeCookAndPartyDocument.uuID;
			}
		}

		// Token: 0x1700313E RID: 12606
		// (get) Token: 0x0600B0E2 RID: 45282 RVA: 0x0021D46C File Offset: 0x0021B66C
		public static XHomeCookAndPartyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XHomeCookAndPartyDocument.uuID) as XHomeCookAndPartyDocument;
			}
		}

		// Token: 0x1700313F RID: 12607
		// (get) Token: 0x0600B0E3 RID: 45283 RVA: 0x0021D498 File Offset: 0x0021B698
		public static CookingFoodInfo CookingFoolInfoTable
		{
			get
			{
				return XHomeCookAndPartyDocument._cookingFoodInfoTable;
			}
		}

		// Token: 0x17003140 RID: 12608
		// (get) Token: 0x0600B0E4 RID: 45284 RVA: 0x0021D4B0 File Offset: 0x0021B6B0
		public static CookingLevel CookingLevelTable
		{
			get
			{
				return XHomeCookAndPartyDocument._cookingLevelTable;
			}
		}

		// Token: 0x17003141 RID: 12609
		// (get) Token: 0x0600B0E5 RID: 45285 RVA: 0x0021D4C8 File Offset: 0x0021B6C8
		public static GardenBanquetCfg GardenBanquetCfgTable
		{
			get
			{
				return XHomeCookAndPartyDocument._gardenBanquetCfg;
			}
		}

		// Token: 0x0600B0E6 RID: 45286 RVA: 0x0021D4E0 File Offset: 0x0021B6E0
		public static void Execute(OnLoadedCallback callback = null)
		{
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/CookingFoodInfo", XHomeCookAndPartyDocument._cookingFoodInfoTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/CookingLevel", XHomeCookAndPartyDocument._cookingLevelTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/GardenBanquetCfg", XHomeCookAndPartyDocument._gardenBanquetCfg, false);
			XHomeCookAndPartyDocument.AsyncLoader.AddTask("Table/ItemBuff", XHomeCookAndPartyDocument._itemBuffTable, false);
			XHomeCookAndPartyDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600B0E7 RID: 45287 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600B0E8 RID: 45288 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600B0E9 RID: 45289 RVA: 0x0021D552 File Offset: 0x0021B752
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.ResetBanquetState();
		}

		// Token: 0x0600B0EA RID: 45290 RVA: 0x0021D564 File Offset: 0x0021B764
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

		// Token: 0x0600B0EB RID: 45291 RVA: 0x0021D5A8 File Offset: 0x0021B7A8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ResetBanquetState();
		}

		// Token: 0x0600B0EC RID: 45292 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x17003142 RID: 12610
		// (get) Token: 0x0600B0ED RID: 45293 RVA: 0x0021D5B4 File Offset: 0x0021B7B4
		// (set) Token: 0x0600B0EE RID: 45294 RVA: 0x0021D5CC File Offset: 0x0021B7CC
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

		// Token: 0x17003143 RID: 12611
		// (get) Token: 0x0600B0EF RID: 45295 RVA: 0x0021D5D8 File Offset: 0x0021B7D8
		// (set) Token: 0x0600B0F0 RID: 45296 RVA: 0x0021D5F0 File Offset: 0x0021B7F0
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

		// Token: 0x0600B0F1 RID: 45297 RVA: 0x0021D5FC File Offset: 0x0021B7FC
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

		// Token: 0x0600B0F2 RID: 45298 RVA: 0x0021D654 File Offset: 0x0021B854
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

		// Token: 0x0600B0F3 RID: 45299 RVA: 0x0021D6A0 File Offset: 0x0021B8A0
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

		// Token: 0x0600B0F4 RID: 45300 RVA: 0x0021D700 File Offset: 0x0021B900
		public void ReqGardenCookingFood(uint foodId)
		{
			RpcC2M_GardenCookingFood rpcC2M_GardenCookingFood = new RpcC2M_GardenCookingFood();
			rpcC2M_GardenCookingFood.oArg.food_id = foodId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenCookingFood);
		}

		// Token: 0x0600B0F5 RID: 45301 RVA: 0x0021D730 File Offset: 0x0021B930
		public void AddNewCookItem(uint id)
		{
			bool flag = !this._newCookingItems.Contains(id);
			if (flag)
			{
				this._newCookingItems.Add(id);
			}
		}

		// Token: 0x0600B0F6 RID: 45302 RVA: 0x0021D760 File Offset: 0x0021B960
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

		// Token: 0x0600B0F7 RID: 45303 RVA: 0x0021D798 File Offset: 0x0021B998
		public bool IsNewAddedCookItem(uint id)
		{
			return this._newCookingItems.Contains(id);
		}

		// Token: 0x0600B0F8 RID: 45304 RVA: 0x0021D7C0 File Offset: 0x0021B9C0
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

		// Token: 0x0600B0F9 RID: 45305 RVA: 0x0021D802 File Offset: 0x0021BA02
		private void TimerUp()
		{
			this.StopCreateFoodTimer();
			this._timerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(0.025f, new XTimerMgr.AccurateElapsedEventHandler(this.OnCreatingFood), 0.025f);
		}

		// Token: 0x0600B0FA RID: 45306 RVA: 0x0021D837 File Offset: 0x0021BA37
		public void StopCreateFoodTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerID);
			this._timerID = 0U;
		}

		// Token: 0x0600B0FB RID: 45307 RVA: 0x0021D854 File Offset: 0x0021BA54
		public void CookingFoodSuccess()
		{
			bool flag = DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.IsVisible();
			if (flag)
			{
				DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.HomeCookingHandler.CookingSuccess();
			}
		}

		// Token: 0x0600B0FC RID: 45308 RVA: 0x0021D898 File Offset: 0x0021BA98
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

		// Token: 0x0600B0FD RID: 45309 RVA: 0x0021D9B8 File Offset: 0x0021BBB8
		public void SendActiveFoodMenu(uint foodID)
		{
			RpcC2M_ActiveCookbook rpcC2M_ActiveCookbook = new RpcC2M_ActiveCookbook();
			rpcC2M_ActiveCookbook.oArg.garden_id = HomePlantDocument.Doc.GardenId;
			rpcC2M_ActiveCookbook.oArg.cook_book_id = foodID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ActiveCookbook);
		}

		// Token: 0x0600B0FE RID: 45310 RVA: 0x0021D9FC File Offset: 0x0021BBFC
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

		// Token: 0x0600B0FF RID: 45311 RVA: 0x0021DA5C File Offset: 0x0021BC5C
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

		// Token: 0x0600B100 RID: 45312 RVA: 0x0021DAC8 File Offset: 0x0021BCC8
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

		// Token: 0x0600B101 RID: 45313 RVA: 0x0021DB14 File Offset: 0x0021BD14
		public void SendGardenBanquet(uint banquetID)
		{
			RpcC2M_GardenBanquet rpcC2M_GardenBanquet = new RpcC2M_GardenBanquet();
			rpcC2M_GardenBanquet.oArg.banquet_id = banquetID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenBanquet);
		}

		// Token: 0x0600B102 RID: 45314 RVA: 0x0021DB44 File Offset: 0x0021BD44
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

		// Token: 0x0600B103 RID: 45315 RVA: 0x0021DD14 File Offset: 0x0021BF14
		private bool IsHasRewards()
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GardenBanquetAwardTimesTSWK");
			return (ulong)this._totalFeastedTimesWeekly <= (ulong)((long)@int);
		}

		// Token: 0x0600B104 RID: 45316 RVA: 0x0021DD48 File Offset: 0x0021BF48
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

		// Token: 0x0600B105 RID: 45317 RVA: 0x0021DDB9 File Offset: 0x0021BFB9
		private void CountDownTimerUp()
		{
			this.StopCountDownTimer();
			this._CountDownTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f, new XTimerMgr.AccurateElapsedEventHandler(this.OnHomeFeastingCountDown), null);
		}

		// Token: 0x0600B106 RID: 45318 RVA: 0x0021DDE5 File Offset: 0x0021BFE5
		private void StopCountDownTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CountDownTimerID);
			this._CountDownTimerID = 0U;
		}

		// Token: 0x0600B107 RID: 45319 RVA: 0x0021DE00 File Offset: 0x0021C000
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

		// Token: 0x0600B108 RID: 45320 RVA: 0x0021DEDC File Offset: 0x0021C0DC
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

		// Token: 0x0600B109 RID: 45321 RVA: 0x0021DF28 File Offset: 0x0021C128
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

		// Token: 0x0600B10A RID: 45322 RVA: 0x0021DF78 File Offset: 0x0021C178
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

		// Token: 0x0600B10B RID: 45323 RVA: 0x0021DFF8 File Offset: 0x0021C1F8
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

		// Token: 0x0600B10C RID: 45324 RVA: 0x0021E174 File Offset: 0x0021C374
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

		// Token: 0x0600B10D RID: 45325 RVA: 0x0021E1B8 File Offset: 0x0021C3B8
		public string GetHomeFeastAction(uint basicType)
		{
			return string.Format("Player_{0}_{1}", XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord(basicType), "yanhui");
		}

		// Token: 0x0600B10E RID: 45326 RVA: 0x0021E1E4 File Offset: 0x0021C3E4
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

		// Token: 0x0600B10F RID: 45327 RVA: 0x0021E24C File Offset: 0x0021C44C
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

		// Token: 0x0600B110 RID: 45328 RVA: 0x0021E2C0 File Offset: 0x0021C4C0
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

		// Token: 0x0600B111 RID: 45329 RVA: 0x0021E350 File Offset: 0x0021C550
		private int SortData(CookingFoodInfo.RowData x1, CookingFoodInfo.RowData x2)
		{
			int num = x1.Level.CompareTo(x2.Level);
			return (num == 0) ? this.FoodActiveCompare(x1.FoodID, x2.FoodID) : num;
		}

		// Token: 0x0600B112 RID: 45330 RVA: 0x0021E38C File Offset: 0x0021C58C
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

		// Token: 0x0400440F RID: 17423
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeCookAndPartyDocument");

		// Token: 0x04004410 RID: 17424
		private static CookingFoodInfo _cookingFoodInfoTable = new CookingFoodInfo();

		// Token: 0x04004411 RID: 17425
		private static CookingLevel _cookingLevelTable = new CookingLevel();

		// Token: 0x04004412 RID: 17426
		private static GardenBanquetCfg _gardenBanquetCfg = new GardenBanquetCfg();

		// Token: 0x04004413 RID: 17427
		private static ItemBuffTable _itemBuffTable = new ItemBuffTable();

		// Token: 0x04004414 RID: 17428
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04004415 RID: 17429
		private uint MaxCookLevel = 0U;

		// Token: 0x04004416 RID: 17430
		private List<uint> _newCookingItems = new List<uint>();

		// Token: 0x04004417 RID: 17431
		private uint _timerID = 0U;

		// Token: 0x04004418 RID: 17432
		private uint _curBanquetID = 0U;

		// Token: 0x04004419 RID: 17433
		private uint _curBanquetState = 0U;

		// Token: 0x0400441A RID: 17434
		private uint _CountDownTimerID = 0U;

		// Token: 0x0400441B RID: 17435
		private int _curFeastRemainTime = 0;

		// Token: 0x0400441C RID: 17436
		private uint _totalFeastedTimesWeekly = 0U;

		// Token: 0x0400441D RID: 17437
		private uint _timeToCooking = 5U;

		// Token: 0x0400441E RID: 17438
		protected float _curPassedTime = 0f;
	}
}
