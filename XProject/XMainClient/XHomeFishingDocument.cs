using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHomeFishingDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XHomeFishingDocument.uuID;
			}
		}

		public GardenFishConfig _HomeFishTable
		{
			get
			{
				return XHomeFishingDocument._homeFishTable;
			}
		}

		public FishInfo FishInfoTable
		{
			get
			{
				return XHomeFishingDocument._fishInfo;
			}
		}

		public bool isSweep { get; set; }

		public List<ItemBrief> FishList
		{
			get
			{
				return this._fishList;
			}
		}

		public uint TimerToken
		{
			get
			{
				return this._timerToken;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XHomeFishingDocument.AsyncLoader.AddTask("Table/GardenFishing", XHomeFishingDocument._homeFishTable, false);
			XHomeFishingDocument.AsyncLoader.AddTask("Table/FishInfo", XHomeFishingDocument._fishInfo, false);
			XHomeFishingDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._fishingRodPresentation = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(50001U);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			this._nearFishPoolState = false;
		}

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

		public void SendLevelExpQuery()
		{
			RpcC2M_GardenFishInfo rpcC2M_GardenFishInfo = new RpcC2M_GardenFishInfo();
			HomePlantDocument specificDocument = XDocuments.GetSpecificDocument<HomePlantDocument>(HomePlantDocument.uuID);
			rpcC2M_GardenFishInfo.oArg.garden_id = specificDocument.GardenId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GardenFishInfo);
		}

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

		public void StopFishing()
		{
			XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this._entity.Present.PresentLib.FishingIdle);
			this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(false);
		}

		public void ContinueFishing()
		{
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
			DlgBase<HomeFishingDlg, HomeFishingBehaviour>.singleton.SetFishingTipsState(true);
		}

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

		private void SetStartFishingState()
		{
			this.m_first_cast = true;
			this._currState = HomeFishingState.GET;
			XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this._entity.Present.PresentLib.FishingIdle);
			this._entity.Equipment.PlayFishingRodAnimation(this._fishingRodPresentation.FishingIdle);
			this._timerToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.OnFishingStateChange), null);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HomeFishingDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GardenFishConfig _homeFishTable = new GardenFishConfig();

		private static FishInfo _fishInfo = new FishInfo();

		private bool _nearFishPoolState = false;

		public uint FishingLevel = 1U;

		public uint CurrentExp = 0U;

		private List<ItemBrief> _fishList = new List<ItemBrief>();

		public bool LastFishingHasFish = true;

		private uint _timerToken;

		private HomeFishingState _currState;

		private bool m_first_cast = false;

		public bool LastLevelUp = false;

		private ulong _reconnectSign;

		public bool IsFishing = false;

		public bool ServerStopFishing = false;

		private XEntityPresentation.RowData _fishingRodPresentation;

		public static readonly int stoshID = 5500;

		public static readonly string LEVELUPFX = "Effects/FX_Particle/UIfx/UI_jy_dy_sj";
	}
}
