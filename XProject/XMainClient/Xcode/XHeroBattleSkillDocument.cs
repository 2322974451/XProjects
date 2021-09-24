using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XHeroBattleSkillDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XHeroBattleSkillDocument.uuID;
			}
		}

		private XHeroBattleDocument _heroDoc
		{
			get
			{
				bool flag = this._valueDoc == null;
				if (flag)
				{
					this._valueDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
				}
				return this._valueDoc;
			}
		}

		public HashSet<uint> WeekFreeList
		{
			get
			{
				return this._weekFreeList;
			}
		}

		public HashSet<uint> AlreadyGetList
		{
			get
			{
				return this._alreadyGetList;
			}
		}

		public HashSet<uint> ExperienceList
		{
			get
			{
				return this._experienceList;
			}
		}

		public Dictionary<uint, uint> ExperienceTimeDict
		{
			get
			{
				return this._experienceTimeDict;
			}
		}

		public uint CurrentSelect
		{
			get
			{
				return this._currentSelect;
			}
			set
			{
				this._currentSelect = value;
				this._currentEntityStatisticsID = this._heroDoc.OverWatchReader.GetByHeroID(this._currentSelect).StatisticsID;
			}
		}

		public uint[] CurrentEntityStatisticsID
		{
			get
			{
				return this._currentEntityStatisticsID;
			}
		}

		public XDummy Dummy { get; set; }

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.SkillPlayFinished));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemChange));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.IsPreViewShow = false;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XHeroBattleSkillDocument.IsWeekendNestLoad = false;
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag)
			{
				this.CSSH = (XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleCanChooseSame") == "1");
			}
			else
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
				if (flag2)
				{
					this.CSSH = false;
				}
				else
				{
					this.CSSH = true;
				}
			}
			bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag3)
			{
				bool flag4 = this.m_HeroBattleSkillHandler != null;
				if (flag4)
				{
					this.m_HeroBattleSkillHandler.SetCountDown(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HeroBattleChooseHeroTime")), true);
				}
			}
			bool flag5 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag5)
			{
				bool flag6 = this.m_HeroBattleSkillHandler != null;
				if (flag6)
				{
					this.m_HeroBattleSkillHandler.SetCountDown(float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MobaBattleChooseHeroTime")), true);
				}
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
			if (flag)
			{
				this.TAS.Clear();
			}
			this.AlSelectHero = false;
		}

		public void SetHeroHoldStatus(List<uint> weekList, List<uint> haveList, List<uint> experienceList, List<uint> expTimeList)
		{
			this._weekFreeList.Clear();
			this._alreadyGetList.Clear();
			this._experienceList.Clear();
			this._experienceTimeDict.Clear();
			for (int i = 0; i < weekList.Count; i++)
			{
				this._weekFreeList.Add(weekList[i]);
			}
			for (int j = 0; j < haveList.Count; j++)
			{
				this._alreadyGetList.Add(haveList[j]);
			}
			for (int k = 0; k < experienceList.Count; k++)
			{
				this._experienceList.Add(experienceList[k]);
				this._experienceTimeDict[experienceList[k]] = expTimeList[k];
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void SetHeroBattleCanUseHero(HeroBattleCanUseHeroData data)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.CheckWeekFreeDif(data.freehero, data.havehero, data.experiencehero);
				bool isWeekendNestLoad = XHeroBattleSkillDocument.IsWeekendNestLoad;
				if (isWeekendNestLoad)
				{
					this.m_HeroBattleSkillHandler.SetCountDown(data.leftChooseTime, true);
				}
			}
		}

		public void SetUnSelect()
		{
			this._currentSelect = this.UNSELECT;
		}

		private void CheckWeekFreeDif(List<uint> freeList, List<uint> haveList, List<uint> experienceList)
		{
			bool flag = false;
			for (int i = 0; i < freeList.Count; i++)
			{
				bool flag2 = !this._weekFreeList.Contains(freeList[i]);
				if (flag2)
				{
					this._weekFreeList.Clear();
					for (int j = 0; j < freeList.Count; j++)
					{
						this._weekFreeList.Add(freeList[j]);
					}
					flag = true;
					break;
				}
			}
			for (int k = 0; k < haveList.Count; k++)
			{
				bool flag3 = !this._alreadyGetList.Contains(haveList[k]);
				if (flag3)
				{
					this._alreadyGetList.Clear();
					for (int l = 0; l < haveList.Count; l++)
					{
						this._alreadyGetList.Add(haveList[l]);
					}
					flag = true;
					break;
				}
			}
			for (int m = 0; m < experienceList.Count; m++)
			{
				bool flag4 = !this._experienceList.Contains(experienceList[m]);
				if (flag4)
				{
					this._experienceList.Clear();
					for (int n = 0; n < experienceList.Count; n++)
					{
						this._experienceList.Add(experienceList[n]);
					}
					flag = true;
					break;
				}
			}
			bool flag5 = flag && this.m_HeroBattleSkillHandler != null;
			if (flag5)
			{
				this.m_HeroBattleSkillHandler.RefreshTab();
			}
		}

		public void CreateSkillBlackHouse()
		{
			bool flag = this.BlackHouse == null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.GetSkillBlackHouse(ref this.BlackHouse, ref this.BlackHouseCamera);
				this.BlackHouseCamera.enabled = false;
			}
		}

		public void ReplaceDummy(int HandlerType)
		{
			this.DelDummy();
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(this._currentEntityStatisticsID[HandlerType]);
			XOutlookData xoutlookData = new XOutlookData();
			xoutlookData.SetDefaultFashion(byID.FashionTemplate);
			this.Dummy = XSingleton<XEntityMgr>.singleton.CreateDummy(byID.PresentID, 0U, null, true, true, true);
			bool flag = this.Dummy == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Dummy Creat Fail.", null, null, null, null, null);
			}
			else
			{
				XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
				this.Dummy.OverrideAnimClip("Idle", byPresentID.Idle, true, false);
				XSingleton<XSkillPreViewMgr>.singleton.ResetDummyPos(this.Dummy);
			}
		}

		public void DelDummy()
		{
			bool flag = this.Dummy != null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this.Dummy);
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this.Dummy);
				this.Dummy = null;
			}
		}

		public void SetSkillPreviewTexture(RenderTexture rt)
		{
			this.skillPreView = rt;
			bool flag = this.BlackHouseCamera != null;
			if (flag)
			{
				this.BlackHouseCamera.targetTexture = rt;
			}
		}

		public bool SkillPlayFinished(XEventArgs args)
		{
			bool flag = this.m_HeroBattleSkillHandler == null || !this.m_HeroBattleSkillHandler.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_HeroBattleSkillHandler.SetPlayBtnState(true);
				result = true;
			}
			return result;
		}

		public void QueryBuyHero(uint heroID)
		{
			RpcC2G_BuyHeroInHeroBattle rpcC2G_BuyHeroInHeroBattle = new RpcC2G_BuyHeroInHeroBattle();
			rpcC2G_BuyHeroInHeroBattle.oArg.heroid = heroID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyHeroInHeroBattle);
		}

		public void OnBuyHeroSuccess(uint heroID)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("HeroBattleBuySuccess"), "fece00");
			this._alreadyGetList.Add(heroID);
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.RefreshTab();
				bool flag2 = this.m_HeroBattleSkillHandler.LastSelectSprite != null;
				if (flag2)
				{
					this.m_HeroBattleSkillHandler.OnTabClick(this.m_HeroBattleSkillHandler.LastSelectSprite);
				}
			}
			bool flag3 = DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.uiBehaviour.m_BuyBtn.SetVisible(false);
			}
			bool flag4 = this.m_HeroBattleSkillHandler != null && this.m_HeroBattleSkillHandler.IsVisible();
			if (flag4)
			{
				this.m_HeroBattleSkillHandler.SetFx();
			}
		}

		public void QuerySelectBattleHero()
		{
			RpcC2G_SetHeroInHeroBattle rpcC2G_SetHeroInHeroBattle = new RpcC2G_SetHeroInHeroBattle();
			rpcC2G_SetHeroInHeroBattle.oArg.heroid = this._currentSelect;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SetHeroInHeroBattle);
		}

		public void OnSelectHeroSuccess(uint heroID)
		{
			OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(heroID);
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("HeroBattleChangeHero"), byHeroID.Name), "fece00");
			XSingleton<XDebug>.singleton.AddGreenLog("Select Hero Success.", null, null, null, null, null);
			this.SetAlreadySelectHero();
		}

		public void SetAlreadySelectHero()
		{
			this.AlSelectHero = true;
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.SetVisible(false);
			}
		}

		protected bool OnItemChange(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool flag = xitemNumChangedEventArgs.item.type == 30U && xitemNumChangedEventArgs.oldCount > xitemNumChangedEventArgs.item.itemCount;
			if (flag)
			{
				this.OnUseTicketSuccess((uint)xitemNumChangedEventArgs.item.itemID);
			}
			return true;
		}

		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			for (int i = 0; i < xremoveItemEventArgs.types.Count; i++)
			{
				bool flag = xremoveItemEventArgs.types[i] == ItemType.Hero_Experience_Ticket;
				if (flag)
				{
					this.OnUseTicketSuccess((uint)xremoveItemEventArgs.ids[i]);
				}
			}
			return true;
		}

		public void QueryUseExperienceTicket()
		{
			for (int i = 0; i < XBagDocument.BagDoc.ItemBag.Count; i++)
			{
				bool flag = (long)XBagDocument.BagDoc.ItemBag[i].itemID == (long)((ulong)this.CurrentSelectExperienceTicketID);
				if (flag)
				{
					XBagDocument.BagDoc.UseItem(XBagDocument.BagDoc.ItemBag[i], 0U);
					break;
				}
			}
		}

		public void OnUseTicketSuccess(uint itemID)
		{
			HeroBattleExperienceHero.RowData byItemID = this._heroDoc.HeroExperienceReader.GetByItemID(itemID);
			bool flag = byItemID != null && !this._alreadyGetList.Contains(byItemID.HeroID) && !this._experienceList.Contains(byItemID.HeroID);
			if (flag)
			{
				OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(byItemID.HeroID);
				string text = string.Format(XStringDefineProxy.GetString("HeroBattleUseTicketSuccess"), byHeroID.Name, byItemID.ShowTime);
				XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
				this._experienceList.Add(byItemID.HeroID);
				this._experienceTimeDict[byItemID.HeroID] = byItemID.LastTime * 3600U;
				bool flag2 = this.m_HeroBattleSkillHandler != null;
				if (flag2)
				{
					this.m_HeroBattleSkillHandler.RefreshTab();
					bool flag3 = this.m_HeroBattleSkillHandler.LastSelectSprite != null;
					if (flag3)
					{
						this.m_HeroBattleSkillHandler.OnTabClick(this.m_HeroBattleSkillHandler.LastSelectSprite);
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HeroBattleSkillDocument");

		private XHeroBattleDocument _valueDoc;

		public HeroBattleSkillHandler m_HeroBattleSkillHandler;

		public HeroBattleTeamHandler _HeroBattleTeamHandler;

		private HashSet<uint> _weekFreeList = new HashSet<uint>();

		private HashSet<uint> _alreadyGetList = new HashSet<uint>();

		private HashSet<uint> _experienceList = new HashSet<uint>();

		private Dictionary<uint, uint> _experienceTimeDict = new Dictionary<uint, uint>();

		public HashSet<uint> TAS = new HashSet<uint>();

		public bool CSSH = false;

		public bool AlSelectHero = false;

		public readonly uint UNSELECT = 100000U;

		private uint _currentSelect;

		private uint[] _currentEntityStatisticsID;

		public bool IsPreViewShow;

		public uint CurrentSelectExperienceTicketID;

		public Camera BlackHouseCamera;

		public GameObject BlackHouse;

		private RenderTexture skillPreView;

		public static bool IsWeekendNestLoad;
	}
}
