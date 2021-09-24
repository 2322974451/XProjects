using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardAbyssPartyHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardAbyssPartyFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Return.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClicked));
			this.m_Restart.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRestartClick));
		}

		private void OnReturnClicked(IXUISprite sp)
		{
			this.doc.SendLeaveScene();
		}

		private void OnRestartClick(IXUISprite sp)
		{
			this.doc.SendReEnterAbyssParty((uint)sp.ID);
		}

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._TimeCounter.Update();
		}

		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			base.OnUnload();
		}

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

		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

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

		private XLevelRewardDocument doc = null;

		private IXUILabel m_Time;

		private IUIDummy m_snapshot;

		private uint m_show_time_token = 0U;

		private uint _AutoStartTimeID = 0U;

		private IXUISprite m_Return;

		private IXUISprite m_Restart;

		private IXUILabel m_AutoRestartTime;

		private XLeftTimeCounter _TimeCounter;

		private Transform m_CostItem;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
