using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BA4 RID: 2980
	internal class LevelRewardAbyssPartyHandler : DlgHandlerBase
	{
		// Token: 0x17003049 RID: 12361
		// (get) Token: 0x0600AAF3 RID: 43763 RVA: 0x001EF1C4 File Offset: 0x001ED3C4
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardAbyssPartyFrame";
			}
		}

		// Token: 0x0600AAF4 RID: 43764 RVA: 0x001EF1DC File Offset: 0x001ED3DC
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.m_Return = (base.PanelObject.transform.Find("Return").GetComponent("XUISprite") as IXUISprite);
			this.m_Restart = (base.PanelObject.transform.Find("Restart").GetComponent("XUISprite") as IXUISprite);
			this.m_CostItem = base.PanelObject.transform.Find("Restart/Cost");
			this.m_AutoRestartTime = (base.PanelObject.transform.Find("Restart/Tip").GetComponent("XUILabel") as IXUILabel);
			this._TimeCounter = new XLeftTimeCounter(this.m_AutoRestartTime, false);
			this._TimeCounter.SetTimeFormat(1, 1, 4, false);
			this._TimeCounter.SetNoNeedPadLeft();
			this.m_Time = (base.PanelObject.transform.Find("Title/Time").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Normal/ItemList/ScrollView/Item");
			this.m_ItemPool.SetupPool(null, transform.gameObject, 5U, false);
			this.m_snapshot = (base.PanelObject.transform.Find("Snapshot/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		// Token: 0x0600AAF5 RID: 43765 RVA: 0x001EF347 File Offset: 0x001ED547
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClicked));
			this.m_Restart.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRestartClick));
		}

		// Token: 0x0600AAF6 RID: 43766 RVA: 0x001EF381 File Offset: 0x001ED581
		private void OnReturnClicked(IXUISprite sp)
		{
			this.doc.SendLeaveScene();
		}

		// Token: 0x0600AAF7 RID: 43767 RVA: 0x001EF390 File Offset: 0x001ED590
		private void OnRestartClick(IXUISprite sp)
		{
			this.doc.SendReEnterAbyssParty((uint)sp.ID);
		}

		// Token: 0x0600AAF8 RID: 43768 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600AAF9 RID: 43769 RVA: 0x001EF3A6 File Offset: 0x001ED5A6
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		// Token: 0x0600AAFA RID: 43770 RVA: 0x001EF3B7 File Offset: 0x001ED5B7
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._TimeCounter.Update();
		}

		// Token: 0x0600AAFB RID: 43771 RVA: 0x001EF3CD File Offset: 0x001ED5CD
		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			base.OnUnload();
		}

		// Token: 0x0600AAFC RID: 43772 RVA: 0x001EF3E8 File Offset: 0x001ED5E8
		private void OnShowUI()
		{
			XLevelRewardDocument.AbyssPartyData abyssPartyBattleData = this.doc.AbyssPartyBattleData;
			this.m_Time.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)abyssPartyBattleData.Time, 2, 3, 4, false, true));
			this.m_ItemPool.FakeReturnAll();
			for (int i = 0; i < abyssPartyBattleData.item.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)abyssPartyBattleData.item[i].itemID, (int)abyssPartyBattleData.item[i].itemCount, false);
				gameObject.transform.localPosition = new Vector3((float)(i * this.m_ItemPool.TplWidth), 0f, 0f) + this.m_ItemPool.TplPos;
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)abyssPartyBattleData.item[i].itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
			}
			this.m_ItemPool.ActualReturnAll(false);
			AbyssPartyListTable.RowData abyssPartyList = XAbyssPartyDocument.GetAbyssPartyList(abyssPartyBattleData.AbysssPartyListId);
			bool flag = abyssPartyList != null;
			if (flag)
			{
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_CostItem.gameObject, abyssPartyList.Cost[0], abyssPartyList.Cost[1], true);
				IXUISprite ixuisprite2 = this.m_CostItem.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.ID = (ulong)((long)abyssPartyList.Cost[0]);
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
				this.m_Restart.ID = 0UL;
			}
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_snapshot);
			float num = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(num, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
			num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AbyssPartyAutoStart")) + 0.5f;
			this._TimeCounter.SetLeftTime(num, -1);
			this._TimeCounter.SetFinishEventHandler(new TimeOverFinishEventHandler(this._AutoStart), null);
			this._TimeCounter.SetFormatString(XSingleton<XStringTable>.singleton.GetString("ABYSS_PARTY_AUTO_TIME"));
		}

		// Token: 0x0600AAFD RID: 43773 RVA: 0x001EF685 File Offset: 0x001ED885
		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		// Token: 0x0600AAFE RID: 43774 RVA: 0x001EF6C0 File Offset: 0x001ED8C0
		private void _AutoStart(object param)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoStartTimeID);
			AbyssPartyListTable.RowData abyssPartyList = XAbyssPartyDocument.GetAbyssPartyList(this.doc.AbyssPartyBattleData.AbysssPartyListId);
			int num = abyssPartyList.Cost[0];
			int num2 = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(num);
			ItemList.RowData itemConf = XBagDocument.GetItemConf(num);
			bool flag = num2 < abyssPartyList.Cost[1];
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ABYSS_PARTY_NO_TICKET"), "fece00");
				this.OnReturnClicked(null);
			}
			else
			{
				XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
				xplayerAttributes.AutoPlayOn = true;
				this.m_Restart.ID = (ulong)((long)this.doc.AbyssPartyBattleData.AbysssPartyListId);
				this.OnRestartClick(this.m_Restart);
			}
		}

		// Token: 0x04003FC1 RID: 16321
		private XLevelRewardDocument doc = null;

		// Token: 0x04003FC2 RID: 16322
		private IXUILabel m_Time;

		// Token: 0x04003FC3 RID: 16323
		private IUIDummy m_snapshot;

		// Token: 0x04003FC4 RID: 16324
		private uint m_show_time_token = 0U;

		// Token: 0x04003FC5 RID: 16325
		private uint _AutoStartTimeID = 0U;

		// Token: 0x04003FC6 RID: 16326
		private IXUISprite m_Return;

		// Token: 0x04003FC7 RID: 16327
		private IXUISprite m_Restart;

		// Token: 0x04003FC8 RID: 16328
		private IXUILabel m_AutoRestartTime;

		// Token: 0x04003FC9 RID: 16329
		private XLeftTimeCounter _TimeCounter;

		// Token: 0x04003FCA RID: 16330
		private Transform m_CostItem;

		// Token: 0x04003FCB RID: 16331
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
