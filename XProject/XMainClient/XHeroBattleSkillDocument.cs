using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200091B RID: 2331
	internal class XHeroBattleSkillDocument : XDocComponent
	{
		// Token: 0x17002B83 RID: 11139
		// (get) Token: 0x06008C94 RID: 35988 RVA: 0x00131180 File Offset: 0x0012F380
		public override uint ID
		{
			get
			{
				return XHeroBattleSkillDocument.uuID;
			}
		}

		// Token: 0x17002B84 RID: 11140
		// (get) Token: 0x06008C95 RID: 35989 RVA: 0x00131198 File Offset: 0x0012F398
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

		// Token: 0x17002B85 RID: 11141
		// (get) Token: 0x06008C96 RID: 35990 RVA: 0x001311D0 File Offset: 0x0012F3D0
		public HashSet<uint> WeekFreeList
		{
			get
			{
				return this._weekFreeList;
			}
		}

		// Token: 0x17002B86 RID: 11142
		// (get) Token: 0x06008C97 RID: 35991 RVA: 0x001311E8 File Offset: 0x0012F3E8
		public HashSet<uint> AlreadyGetList
		{
			get
			{
				return this._alreadyGetList;
			}
		}

		// Token: 0x17002B87 RID: 11143
		// (get) Token: 0x06008C98 RID: 35992 RVA: 0x00131200 File Offset: 0x0012F400
		public HashSet<uint> ExperienceList
		{
			get
			{
				return this._experienceList;
			}
		}

		// Token: 0x17002B88 RID: 11144
		// (get) Token: 0x06008C99 RID: 35993 RVA: 0x00131218 File Offset: 0x0012F418
		public Dictionary<uint, uint> ExperienceTimeDict
		{
			get
			{
				return this._experienceTimeDict;
			}
		}

		// Token: 0x17002B89 RID: 11145
		// (get) Token: 0x06008C9A RID: 35994 RVA: 0x00131230 File Offset: 0x0012F430
		// (set) Token: 0x06008C9B RID: 35995 RVA: 0x00131248 File Offset: 0x0012F448
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

		// Token: 0x17002B8A RID: 11146
		// (get) Token: 0x06008C9C RID: 35996 RVA: 0x00131274 File Offset: 0x0012F474
		public uint[] CurrentEntityStatisticsID
		{
			get
			{
				return this._currentEntityStatisticsID;
			}
		}

		// Token: 0x17002B8B RID: 11147
		// (get) Token: 0x06008C9D RID: 35997 RVA: 0x0013128C File Offset: 0x0012F48C
		// (set) Token: 0x06008C9E RID: 35998 RVA: 0x00131294 File Offset: 0x0012F494
		public XDummy Dummy { get; set; }

		// Token: 0x06008C9F RID: 35999 RVA: 0x001312A0 File Offset: 0x0012F4A0
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.SkillPlayFinished));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemChange));
		}

		// Token: 0x06008CA0 RID: 36000 RVA: 0x001312F4 File Offset: 0x0012F4F4
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.IsPreViewShow = false;
		}

		// Token: 0x06008CA1 RID: 36001 RVA: 0x00131308 File Offset: 0x0012F508
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

		// Token: 0x06008CA2 RID: 36002 RVA: 0x00131400 File Offset: 0x0012F600
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

		// Token: 0x06008CA3 RID: 36003 RVA: 0x00131450 File Offset: 0x0012F650
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

		// Token: 0x06008CA4 RID: 36004 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008CA5 RID: 36005 RVA: 0x0013152C File Offset: 0x0012F72C
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

		// Token: 0x06008CA6 RID: 36006 RVA: 0x00131593 File Offset: 0x0012F793
		public void SetUnSelect()
		{
			this._currentSelect = this.UNSELECT;
		}

		// Token: 0x06008CA7 RID: 36007 RVA: 0x001315A4 File Offset: 0x0012F7A4
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

		// Token: 0x06008CA8 RID: 36008 RVA: 0x00131734 File Offset: 0x0012F934
		public void CreateSkillBlackHouse()
		{
			bool flag = this.BlackHouse == null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.GetSkillBlackHouse(ref this.BlackHouse, ref this.BlackHouseCamera);
				this.BlackHouseCamera.enabled = false;
			}
		}

		// Token: 0x06008CA9 RID: 36009 RVA: 0x00131778 File Offset: 0x0012F978
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

		// Token: 0x06008CAA RID: 36010 RVA: 0x0013183C File Offset: 0x0012FA3C
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

		// Token: 0x06008CAB RID: 36011 RVA: 0x00131884 File Offset: 0x0012FA84
		public void SetSkillPreviewTexture(RenderTexture rt)
		{
			this.skillPreView = rt;
			bool flag = this.BlackHouseCamera != null;
			if (flag)
			{
				this.BlackHouseCamera.targetTexture = rt;
			}
		}

		// Token: 0x06008CAC RID: 36012 RVA: 0x001318B8 File Offset: 0x0012FAB8
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

		// Token: 0x06008CAD RID: 36013 RVA: 0x001318FC File Offset: 0x0012FAFC
		public void QueryBuyHero(uint heroID)
		{
			RpcC2G_BuyHeroInHeroBattle rpcC2G_BuyHeroInHeroBattle = new RpcC2G_BuyHeroInHeroBattle();
			rpcC2G_BuyHeroInHeroBattle.oArg.heroid = heroID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BuyHeroInHeroBattle);
		}

		// Token: 0x06008CAE RID: 36014 RVA: 0x0013192C File Offset: 0x0012FB2C
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

		// Token: 0x06008CAF RID: 36015 RVA: 0x001319F4 File Offset: 0x0012FBF4
		public void QuerySelectBattleHero()
		{
			RpcC2G_SetHeroInHeroBattle rpcC2G_SetHeroInHeroBattle = new RpcC2G_SetHeroInHeroBattle();
			rpcC2G_SetHeroInHeroBattle.oArg.heroid = this._currentSelect;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SetHeroInHeroBattle);
		}

		// Token: 0x06008CB0 RID: 36016 RVA: 0x00131A28 File Offset: 0x0012FC28
		public void OnSelectHeroSuccess(uint heroID)
		{
			OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(heroID);
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("HeroBattleChangeHero"), byHeroID.Name), "fece00");
			XSingleton<XDebug>.singleton.AddGreenLog("Select Hero Success.", null, null, null, null, null);
			this.SetAlreadySelectHero();
		}

		// Token: 0x06008CB1 RID: 36017 RVA: 0x00131A8C File Offset: 0x0012FC8C
		public void SetAlreadySelectHero()
		{
			this.AlSelectHero = true;
			bool flag = this.m_HeroBattleSkillHandler != null;
			if (flag)
			{
				this.m_HeroBattleSkillHandler.SetVisible(false);
			}
		}

		// Token: 0x06008CB2 RID: 36018 RVA: 0x00131ABC File Offset: 0x0012FCBC
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

		// Token: 0x06008CB3 RID: 36019 RVA: 0x00131B14 File Offset: 0x0012FD14
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

		// Token: 0x06008CB4 RID: 36020 RVA: 0x00131B78 File Offset: 0x0012FD78
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

		// Token: 0x06008CB5 RID: 36021 RVA: 0x00131BE8 File Offset: 0x0012FDE8
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

		// Token: 0x04002D75 RID: 11637
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("HeroBattleSkillDocument");

		// Token: 0x04002D76 RID: 11638
		private XHeroBattleDocument _valueDoc;

		// Token: 0x04002D77 RID: 11639
		public HeroBattleSkillHandler m_HeroBattleSkillHandler;

		// Token: 0x04002D78 RID: 11640
		public HeroBattleTeamHandler _HeroBattleTeamHandler;

		// Token: 0x04002D79 RID: 11641
		private HashSet<uint> _weekFreeList = new HashSet<uint>();

		// Token: 0x04002D7A RID: 11642
		private HashSet<uint> _alreadyGetList = new HashSet<uint>();

		// Token: 0x04002D7B RID: 11643
		private HashSet<uint> _experienceList = new HashSet<uint>();

		// Token: 0x04002D7C RID: 11644
		private Dictionary<uint, uint> _experienceTimeDict = new Dictionary<uint, uint>();

		// Token: 0x04002D7D RID: 11645
		public HashSet<uint> TAS = new HashSet<uint>();

		// Token: 0x04002D7E RID: 11646
		public bool CSSH = false;

		// Token: 0x04002D7F RID: 11647
		public bool AlSelectHero = false;

		// Token: 0x04002D80 RID: 11648
		public readonly uint UNSELECT = 100000U;

		// Token: 0x04002D81 RID: 11649
		private uint _currentSelect;

		// Token: 0x04002D82 RID: 11650
		private uint[] _currentEntityStatisticsID;

		// Token: 0x04002D83 RID: 11651
		public bool IsPreViewShow;

		// Token: 0x04002D84 RID: 11652
		public uint CurrentSelectExperienceTicketID;

		// Token: 0x04002D86 RID: 11654
		public Camera BlackHouseCamera;

		// Token: 0x04002D87 RID: 11655
		public GameObject BlackHouse;

		// Token: 0x04002D88 RID: 11656
		private RenderTexture skillPreView;

		// Token: 0x04002D89 RID: 11657
		public static bool IsWeekendNestLoad;
	}
}
