using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000941 RID: 2369
	internal class XHomeFishingDocument : XDocComponent
	{
		// Token: 0x17002C17 RID: 11287
		// (get) Token: 0x06008F2A RID: 36650 RVA: 0x001402A0 File Offset: 0x0013E4A0
		public override uint ID
		{
			get
			{
				return XHomeFishingDocument.uuID;
			}
		}

		// Token: 0x17002C18 RID: 11288
		// (get) Token: 0x06008F2B RID: 36651 RVA: 0x001402B8 File Offset: 0x0013E4B8
		public GardenFishConfig _HomeFishTable
		{
			get
			{
				return XHomeFishingDocument._homeFishTable;
			}
		}

		// Token: 0x17002C19 RID: 11289
		// (get) Token: 0x06008F2C RID: 36652 RVA: 0x001402D0 File Offset: 0x0013E4D0
		public FishInfo FishInfoTable
		{
			get
			{
				return XHomeFishingDocument._fishInfo;
			}
		}

		// Token: 0x17002C1A RID: 11290
		// (get) Token: 0x06008F2D RID: 36653 RVA: 0x001402E7 File Offset: 0x0013E4E7
		// (set) Token: 0x06008F2E RID: 36654 RVA: 0x001402EF File Offset: 0x0013E4EF
		public bool isSweep { get; set; }

		// Token: 0x17002C1B RID: 11291
		// (get) Token: 0x06008F2F RID: 36655 RVA: 0x001402F8 File Offset: 0x0013E4F8
		public List<ItemBrief> FishList
		{
			get
			{
				return this._fishList;
			}
		}

		// Token: 0x17002C1C RID: 11292
		// (get) Token: 0x06008F30 RID: 36656 RVA: 0x00140310 File Offset: 0x0013E510
		public uint TimerToken
		{
			get
			{
				return this._timerToken;
			}
		}

		// Token: 0x06008F31 RID: 36657 RVA: 0x00140328 File Offset: 0x0013E528
		public static void Execute(OnLoadedCallback callback = null)
		{
			XHomeFishingDocument.AsyncLoader.AddTask("Table/GardenFishing", XHomeFishingDocument._homeFishTable, false);
			XHomeFishingDocument.AsyncLoader.AddTask("Table/FishInfo", XHomeFishingDocument._fishInfo, false);
			XHomeFishingDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008F32 RID: 36658 RVA: 0x00140363 File Offset: 0x0013E563
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._fishingRodPresentation = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(50001U);
		}

		// Token: 0x06008F33 RID: 36659 RVA: 0x00140388 File Offset: 0x0013E588
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
		}

		// Token: 0x06008F34 RID: 36660 RVA: 0x001403A7 File Offset: 0x0013E5A7
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._nearFishPoolState = false;
		}

		// Token: 0x06008F35 RID: 36661 RVA: 0x001403B8 File Offset: 0x0013E5B8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.IsFishing && this._currState == HomeFishingState.WAITSERVER;
			if (flag)
			{
				bool flag2 = this._reconnectSign == XBagDocument.BagDoc.GetItemCount(5500) + 1UL;
				if (flag2)
				{
					this.LastFishingHasFish = false;
					this.OnFishingStateChange(null);
				}
				else
				{
					bool flag3 = this._reconnectSign == XBagDocument.BagDoc.GetItemCount(5500);
					if (flag3)
					{
						this.SendFishingQuery();
					}
				}
			}
			bool flag4 = this.IsFishing && DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
			if (flag4)
			{
				XSingleton<XInput>.singleton.Freezed = true;
			}
		}

		// Token: 0x06008F36 RID: 36662 RVA: 0x0014045C File Offset: 0x0013E65C
		public void SendLevelExpQuery()
		{
			RpcC2M_GardenFishInfo rpcC2M_GardenFishInfo = new RpcC2M_GardenFishInfo();
			HomePlantDocument specificDocument = XDocuments.GetSpecificDocument<HomePlantDocument>(HomePlantDocument.uuID);
			rpcC2M_GardenFishInfo.oArg.garden_id = specificDocument.GardenId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenFishInfo);
		}

		// Token: 0x06008F37 RID: 36663 RVA: 0x0014049C File Offset: 0x0013E69C
		private void SendFishingQuery()
		{
			XCharacterItemDocument specificDocument = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
			bool flag = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				specificDocument.ToggleBlock(true);
			}
			RpcC2M_TryFish rpcC2M_TryFish = new RpcC2M_TryFish();
			HomePlantDocument specificDocument2 = XDocuments.GetSpecificDocument<HomePlantDocument>(HomePlantDocument.uuID);
			bool flag2 = specificDocument2.HomeType == HomeTypeEnum.MyHome;
			if (flag2)
			{
				rpcC2M_TryFish.oArg.quest_type = GardenQuestType.MYSELF;
			}
			else
			{
				bool flag3 = specificDocument2.HomeType == HomeTypeEnum.OtherHome;
				if (!flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("try fishing error. home type error.", null, null, null, null, null);
					return;
				}
				rpcC2M_TryFish.oArg.quest_type = GardenQuestType.FRIEND;
			}
			rpcC2M_TryFish.oArg.garden_id = specificDocument2.GardenId;
			rpcC2M_TryFish.oArg.casting_net = this.isSweep;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_TryFish);
		}

		// Token: 0x06008F38 RID: 36664 RVA: 0x00140560 File Offset: 0x0013E760
		public void SetLevelExpInfo(uint level, uint exp)
		{
			this.FishingLevel = level;
			this.CurrentExp = exp;
			bool flag = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.Refresh(false);
			}
		}

		// Token: 0x06008F39 RID: 36665 RVA: 0x00140598 File Offset: 0x0013E798
		public void OnFishingResultGet(List<ItemBrief> list, uint level, uint exp)
		{
			bool flag = !this.IsFishing;
			if (!flag)
			{
				bool flag2 = list.Count == 0;
				if (flag2)
				{
					this.LastFishingHasFish = false;
					this.OnFishingStateChange(null);
				}
				else
				{
					this.LastFishingHasFish = true;
					this.LastLevelUp = (this.FishingLevel != level);
					this.FishingLevel = level;
					this.CurrentExp = exp;
					for (int i = 0; i < list.Count; i++)
					{
						uint num = list[i].itemCount;
						for (int j = 0; j < this._fishList.Count; j++)
						{
							bool flag3 = this._fishList[j].itemID == list[i].itemID;
							if (flag3)
							{
								num += this._fishList[j].itemCount;
								this._fishList.RemoveAt(j);
								break;
							}
						}
						ItemBrief itemBrief = new ItemBrief();
						itemBrief.itemID = list[i].itemID;
						itemBrief.itemCount = num;
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemBrief.itemID);
						XSingleton<XDebug>.singleton.AddGreenLog("fishing get ", itemConf.ItemName[0], null, null, null, null);
						itemBrief.isbind = !itemConf.CanTrade;
						this._fishList.Add(itemBrief);
					}
					this.OnFishingStateChange(null);
				}
			}
		}

		// Token: 0x06008F3A RID: 36666 RVA: 0x00140714 File Offset: 0x0013E914
		public void StartFishing()
		{
			XDanceDocument.Doc.ReqStopJustDance();
			this._entity = XSingleton<XEntityMgr>.singleton.Player;
			XComponent xcomponent = XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XEntityMgr>.singleton.Player, XFishingComponent.uuID);
			xcomponent.Attached();
			this.SetStartFishingState();
			this.IsFishing = true;
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(true);
		}

		// Token: 0x06008F3B RID: 36667 RVA: 0x00140778 File Offset: 0x0013E978
		public void StopFishing()
		{
			XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this._entity.Present.PresentLib.FishingIdle);
			this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(false);
		}

		// Token: 0x06008F3C RID: 36668 RVA: 0x001407D3 File Offset: 0x0013E9D3
		public void ContinueFishing()
		{
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(true);
		}

		// Token: 0x06008F3D RID: 36669 RVA: 0x00140804 File Offset: 0x0013EA04
		public void LeaveFishing()
		{
			bool serverStopFishing = this.ServerStopFishing;
			if (serverStopFishing)
			{
				this.ServerStopFishing = false;
			}
			else
			{
				PtcC2M_GardenFishStop ptcC2M_GardenFishStop = new PtcC2M_GardenFishStop();
				HomePlantDocument specificDocument = XDocuments.GetSpecificDocument<HomePlantDocument>(HomePlantDocument.uuID);
				ptcC2M_GardenFishStop.Data.garden_id = specificDocument.GardenId;
				XSingleton<XDebug>.singleton.AddGreenLog("notice server stop fishing.", null, null, null, null, null);
				XSingleton<XClientNetwork>.singleton.Send(ptcC2M_GardenFishStop);
			}
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.DetachComponent(XFishingComponent.uuID);
			}
			this.IsFishing = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timerToken);
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(false);
		}

		// Token: 0x06008F3E RID: 36670 RVA: 0x001408B8 File Offset: 0x0013EAB8
		private void SetStartFishingState()
		{
			this.m_first_cast = true;
			this._currState = HomeFishingState.GET;
			XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this._entity.Present.PresentLib.FishingIdle);
			this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
		}

		// Token: 0x06008F3F RID: 36671 RVA: 0x00140938 File Offset: 0x0013EB38
		private void OnFishingStateChange(object o = null)
		{
			bool flag = !this.IsFishing || XSingleton<XEntityMgr>.singleton.Player == null || this._entity == null;
			if (!flag)
			{
				float num = 5f;
				switch (this._currState)
				{
				case HomeFishingState.CAST:
				{
					this._currState = HomeFishingState.WAIT;
					num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingWait);
					bool flag2 = num < 0f;
					if (flag2)
					{
						this.ErrorLeaveFishing();
						return;
					}
					this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingWait);
					num = 2f;
					XSingleton<XDebug>.singleton.AddGreenLog("state = wait, time = 2.0", null, null, null, null, null);
					break;
				}
				case HomeFishingState.WAIT:
					this._currState = HomeFishingState.WAITSERVER;
					this._reconnectSign = XBagDocument.BagDoc.GetItemCount(5500);
					this.SendFishingQuery();
					num = -1f;
					XSingleton<XDebug>.singleton.AddGreenLog("state = wait server, time = infinite", null, null, null, null, null);
					break;
				case HomeFishingState.WAITSERVER:
				{
					bool lastFishingHasFish = this.LastFishingHasFish;
					if (lastFishingHasFish)
					{
						bool high = XHomeFishingDocument._fishInfo.GetByFishID(this._fishList[this._fishList.Count - 1].itemID).quality > 0;
						DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.PlayGetFishFx(high);
					}
					this._currState = HomeFishingState.PULL;
					num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingPull);
					bool flag3 = num < 0f;
					if (flag3)
					{
						this.ErrorLeaveFishing();
						return;
					}
					this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingPull);
					XSingleton<XDebug>.singleton.AddGreenLog("state = pull, time = ", num.ToString(), null, null, null, null);
					bool flag4 = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
					if (flag4)
					{
						DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.DelayShowFish();
					}
					break;
				}
				case HomeFishingState.PULL:
				{
					this._currState = HomeFishingState.GET;
					bool lastFishingHasFish2 = this.LastFishingHasFish;
					if (lastFishingHasFish2)
					{
						num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingWin);
						bool flag5 = num < 0f;
						if (flag5)
						{
							this.ErrorLeaveFishing();
							return;
						}
						this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingWin);
						XSingleton<XDebug>.singleton.AddGreenLog("state = win, time = ", num.ToString(), null, null, null, null);
					}
					else
					{
						num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingLose);
						bool flag6 = num < 0f;
						if (flag6)
						{
							this.ErrorLeaveFishing();
							return;
						}
						this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingLose);
					}
					break;
				}
				case HomeFishingState.GET:
				{
					bool first_cast = this.m_first_cast;
					if (first_cast)
					{
						this.m_first_cast = false;
						XCameraMotionData xcameraMotionData = new XCameraMotionData();
						xcameraMotionData.Motion = "Animation/Main_Camera/Main_Camera_fishing_start";
						xcameraMotionData.AutoSync_At_Begin = false;
						xcameraMotionData.Coordinate = CameraMotionSpace.World;
						xcameraMotionData.Follow_Position = true;
						xcameraMotionData.LookAt_Target = false;
						xcameraMotionData.At = 0f;
						XCameraMotionEventArgs @event = XEventPool<XCameraMotionEventArgs>.GetEvent();
						@event.Motion = xcameraMotionData;
						@event.Target = XSingleton<XEntityMgr>.singleton.Player;
						@event.Trigger = "ToEffect";
						@event.Firer = XSingleton<XScene>.singleton.GameCamera;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
					bool flag7 = XBagDocument.BagDoc.GetItemCount(XHomeFishingDocument.stoshID) == 0UL;
					if (flag7)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FishingStoshLess"), "fece00");
						this.StopFishing();
						return;
					}
					this._currState = HomeFishingState.CAST;
					num = XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimationGetLength(this._entity.Present.PresentLib.FishingCast);
					bool flag8 = num < 0f;
					if (flag8)
					{
						this.ErrorLeaveFishing();
						return;
					}
					this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingCast);
					XSingleton<XDebug>.singleton.AddGreenLog("state = cast, time = ", num.ToString(), null, null, null, null);
					break;
				}
				}
				bool flag9 = num > 0f;
				if (flag9)
				{
					this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(num, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
				}
			}
		}

		// Token: 0x06008F40 RID: 36672 RVA: 0x00140DD4 File Offset: 0x0013EFD4
		public void SetFishingUIState(bool state)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_FAMILYGARDEN;
			if (!flag)
			{
				bool flag2 = state == this._nearFishPoolState;
				if (!flag2)
				{
					this._nearFishPoolState = state;
					DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetUIState(state);
				}
			}
		}

		// Token: 0x06008F41 RID: 36673 RVA: 0x00140E1C File Offset: 0x0013F01C
		public void ErrorLeaveFishing()
		{
			bool flag = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.OnCloseBtnClick(null);
			}
			else
			{
				this.LeaveFishing();
			}
		}

		// Token: 0x06008F42 RID: 36674 RVA: 0x00140E50 File Offset: 0x0013F050
		protected bool OnAddItem(XEventArgs args)
		{
			bool flag = !this._nearFishPoolState;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
				for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
				{
					bool flag2 = xaddItemEventArgs.items[i].itemID == XHomeFishingDocument.stoshID;
					if (flag2)
					{
						bool flag3 = DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.IsVisible() && DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.uiBehaviour.m_InFishingFrame.activeInHierarchy;
						if (flag3)
						{
							bool flag4 = XBagDocument.BagDoc.GetItemCount(XHomeFishingDocument.stoshID) == (ulong)((long)xaddItemEventArgs.items[i].itemCount);
							if (flag4)
							{
								this.ContinueFishing();
							}
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06008F43 RID: 36675 RVA: 0x00140F20 File Offset: 0x0013F120
		public static void OnFishingStateStop(OutLookStateType newType, XEntity entity)
		{
			bool flag = newType == OutLookStateType.OutLook_Fish;
			if (!flag)
			{
				XRole xrole = entity as XRole;
				bool flag2 = xrole.Attributes.RoleID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("outlook delete fishingRom.", null, null, null, null, null);
					xrole.DetachComponent(XFishingComponent.uuID);
				}
				else
				{
					XHomeFishingDocument specificDocument = XDocuments.GetSpecificDocument<XHomeFishingDocument>(XHomeFishingDocument.uuID);
					bool isFishing = specificDocument.IsFishing;
					if (isFishing)
					{
						specificDocument.ServerStopFishing = true;
						specificDocument.FishList.Clear();
						specificDocument.ErrorLeaveFishing();
					}
				}
			}
		}

		// Token: 0x04002EF9 RID: 12025
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeFishingDocument");

		// Token: 0x04002EFA RID: 12026
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002EFB RID: 12027
		private static GardenFishConfig _homeFishTable = new GardenFishConfig();

		// Token: 0x04002EFC RID: 12028
		private static FishInfo _fishInfo = new FishInfo();

		// Token: 0x04002EFE RID: 12030
		private bool _nearFishPoolState = false;

		// Token: 0x04002EFF RID: 12031
		public uint FishingLevel = 1U;

		// Token: 0x04002F00 RID: 12032
		public uint CurrentExp = 0U;

		// Token: 0x04002F01 RID: 12033
		private List<ItemBrief> _fishList = new List<ItemBrief>();

		// Token: 0x04002F02 RID: 12034
		public bool LastFishingHasFish = true;

		// Token: 0x04002F03 RID: 12035
		private uint _timerToken;

		// Token: 0x04002F04 RID: 12036
		private HomeFishingState _currState;

		// Token: 0x04002F05 RID: 12037
		private bool m_first_cast = false;

		// Token: 0x04002F06 RID: 12038
		public bool LastLevelUp = false;

		// Token: 0x04002F07 RID: 12039
		private ulong _reconnectSign;

		// Token: 0x04002F08 RID: 12040
		public bool IsFishing = false;

		// Token: 0x04002F09 RID: 12041
		public bool ServerStopFishing = false;

		// Token: 0x04002F0A RID: 12042
		private XEntityPresentation.RowData _fishingRodPresentation;

		// Token: 0x04002F0B RID: 12043
		public static readonly int stoshID = 5500;

		// Token: 0x04002F0C RID: 12044
		public static readonly string LEVELUPFX = "Effects/FX_Particle/UIfx/UI_jy_dy_sj";
	}
}
