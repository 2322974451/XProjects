using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200183A RID: 6202
	internal class XMainInterfaceBriefHandler : DlgHandlerBase
	{
		// Token: 0x17003944 RID: 14660
		// (get) Token: 0x060101C4 RID: 65988 RVA: 0x003D99E8 File Offset: 0x003D7BE8
		public XMainInterfaceTeamHandler TeamHandler
		{
			get
			{
				return this._TeamHandler;
			}
		}

		// Token: 0x17003945 RID: 14661
		// (get) Token: 0x060101C5 RID: 65989 RVA: 0x003D9A00 File Offset: 0x003D7C00
		public XMainInterfaceTaskHandler TaskHandler
		{
			get
			{
				return this._TaskHandler;
			}
		}

		// Token: 0x17003946 RID: 14662
		// (get) Token: 0x060101C6 RID: 65990 RVA: 0x003D9A18 File Offset: 0x003D7C18
		public bool IsShowingTaskTab
		{
			get
			{
				return this.m_SelectedTab == 1;
			}
		}

		// Token: 0x17003947 RID: 14663
		// (get) Token: 0x060101C7 RID: 65991 RVA: 0x003D9A34 File Offset: 0x003D7C34
		protected override string FileName
		{
			get
			{
				return "Hall/HallTaskNaviFrame";
			}
		}

		// Token: 0x060101C8 RID: 65992 RVA: 0x003D9A4C File Offset: 0x003D7C4C
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("Main/TabList/Task");
			this._TaskTab = (transform.GetComponent("XUICheckBox") as IXUICheckBox);
			this._TaskSprite = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.PanelObject.transform.Find("Main/TabList/Team");
			this._TeamTab = (transform.GetComponent("XUICheckBox") as IXUICheckBox);
			this._TeamSprite = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_List = (base.PanelObject.transform.Find("Main/TabList").GetComponent("XUIList") as IXUIList);
			DlgHandlerBase.EnsureCreate<XMainInterfaceTeamHandler>(ref this._TeamHandler, base.PanelObject.transform.Find("Main/TeamFrame").gameObject, null, true);
			DlgHandlerBase.EnsureCreate<XMainInterfaceTaskHandler>(ref this._TaskHandler, base.PanelObject.transform.Find("Main/TaskFrame").gameObject, null, true);
			this._TeamMemberGo = this._TeamTab.gameObject.transform.Find("Member").gameObject;
			this._TeamMatchingGo = this._TeamTab.gameObject.transform.Find("Matching").gameObject;
			transform = this._TeamMemberGo.transform.Find("Num");
			this._TeamMemberCount = (transform.GetComponent("XUILabel") as IXUILabel);
			this._TeamMemberTween = (transform.GetComponent("XUIPlayTween") as IXUITweenTool);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (flag)
			{
				this._TaskTab.gameObject.SetActive(false);
				this._TeamTab.bChecked = true;
				this.m_SelectedTab = 2;
			}
			else
			{
				this._TaskTab.bChecked = true;
				this.m_SelectedTab = 1;
			}
			this.m_List.Refresh();
			this.m_SwitchBtn = (base.PanelObject.transform.Find("TaskSwitchBtn").GetComponent("XUISprite") as IXUISprite);
			this.m_SwitchTween = (this.m_SwitchBtn.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_MainTween = (base.PanelObject.transform.Find("Main").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		// Token: 0x060101C9 RID: 65993 RVA: 0x003D9CC0 File Offset: 0x003D7EC0
		protected override void OnShow()
		{
			bool flag = this._TaskHandler != null;
			if (flag)
			{
				this._TaskHandler.RefreshData();
			}
		}

		// Token: 0x060101CA RID: 65994 RVA: 0x003D9CEC File Offset: 0x003D7EEC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._TaskTab.ID = 1UL;
			this._TaskSprite.ID = 1UL;
			this._TaskTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			this._TaskSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSpriteClick));
			this._TeamTab.ID = 2UL;
			this._TeamSprite.ID = 2UL;
			this._TeamTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
			this._TeamSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSpriteClick));
			this.m_SwitchBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTaskSwitchBtnClick));
		}

		// Token: 0x060101CB RID: 65995 RVA: 0x003D9DB1 File Offset: 0x003D7FB1
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMainInterfaceTeamHandler>(ref this._TeamHandler);
			DlgHandlerBase.EnsureUnload<XMainInterfaceTaskHandler>(ref this._TaskHandler);
			base.OnUnload();
		}

		// Token: 0x060101CC RID: 65996 RVA: 0x003D9DD4 File Offset: 0x003D7FD4
		private void _OnSpriteClick(IXUISprite iSp)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SKYCITY_WAITING;
			if (!flag)
			{
				int num = (int)iSp.ID;
				bool flag2 = num == this.m_SelectedTab;
				if (flag2)
				{
					bool flag3 = num == 1;
					if (!flag3)
					{
						DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
					}
				}
				this.m_SelectedTab = num;
			}
		}

		// Token: 0x060101CD RID: 65997 RVA: 0x003D9E30 File Offset: 0x003D8030
		private bool OnTabClick(IXUICheckBox iXUICheckBox)
		{
			bool flag = !base.bLoaded;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !iXUICheckBox.bChecked;
				if (flag2)
				{
					result = true;
				}
				else
				{
					int num = (int)iXUICheckBox.ID;
					bool flag3 = num == 1;
					if (flag3)
					{
						this._TaskHandler.SetVisible(true);
						this._TeamHandler.SetVisible(false);
					}
					else
					{
						this._TaskHandler.SetVisible(false);
						this._TeamHandler.SetVisible(true);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060101CE RID: 65998 RVA: 0x003D9EB4 File Offset: 0x003D80B4
		public void NavigateToBattle()
		{
			XSingleton<XInput>.singleton.LastNpc = null;
			Vector3 normalized = (XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position - XSingleton<XScene>.singleton.BattleTargetPoint).normalized;
			Vector3 dest = XSingleton<XScene>.singleton.BattleTargetPoint + normalized * 5.8f;
			XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Dest = dest;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this.IsNavigateToBattle = 1;
		}

		// Token: 0x060101CF RID: 65999 RVA: 0x003D9F48 File Offset: 0x003D8148
		public void NavigateToNest()
		{
			XSingleton<XInput>.singleton.LastNpc = null;
			Vector3 nestTargetPoint = XSingleton<XScene>.singleton.NestTargetPoint;
			XNavigationEventArgs @event = XEventPool<XNavigationEventArgs>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			@event.Dest = nestTargetPoint;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this.IsNavigateToBattle = 2;
		}

		// Token: 0x060101D0 RID: 66000 RVA: 0x003D9FA0 File Offset: 0x003D81A0
		public void SetTeamMemberCount(int count)
		{
			bool flag = count == 0;
			if (flag)
			{
				this._TeamMemberGo.SetActive(false);
			}
			else
			{
				this._TeamMemberGo.SetActive(true);
				this._TeamMemberCount.SetText(count.ToString());
				this._TeamMemberTween.PlayTween(true, -1f);
			}
		}

		// Token: 0x060101D1 RID: 66001 RVA: 0x003D9FF9 File Offset: 0x003D81F9
		public void SetTeamMatching(bool bMatching)
		{
			this._TeamMatchingGo.SetActive(bMatching);
		}

		// Token: 0x060101D2 RID: 66002 RVA: 0x003DA009 File Offset: 0x003D8209
		public void OnSysChange()
		{
			this._TeamTab.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Team));
			this.m_List.Refresh();
		}

		// Token: 0x060101D3 RID: 66003 RVA: 0x003DA030 File Offset: 0x003D8230
		private void OnTaskSwitchBtnClick(IXUISprite iSp)
		{
			this._TaskSwitchBtnState = !this._TaskSwitchBtnState;
			int tweenGroup = this._TaskSwitchBtnState ? 1 : 0;
			this.m_MainTween.SetTweenGroup(tweenGroup);
			this.m_SwitchTween.SetTweenGroup(tweenGroup);
			this.m_MainTween.PlayTween(true, -1f);
			this.m_SwitchTween.PlayTween(true, -1f);
		}

		// Token: 0x040072DB RID: 29403
		private IXUICheckBox _TaskTab;

		// Token: 0x040072DC RID: 29404
		private IXUICheckBox _TeamTab;

		// Token: 0x040072DD RID: 29405
		private IXUISprite _TaskSprite;

		// Token: 0x040072DE RID: 29406
		private IXUISprite _TeamSprite;

		// Token: 0x040072DF RID: 29407
		private IXUIList m_List;

		// Token: 0x040072E0 RID: 29408
		private IXUISprite m_SwitchBtn;

		// Token: 0x040072E1 RID: 29409
		private IXUITweenTool m_SwitchTween;

		// Token: 0x040072E2 RID: 29410
		private IXUITweenTool m_MainTween;

		// Token: 0x040072E3 RID: 29411
		private XMainInterfaceTeamHandler _TeamHandler;

		// Token: 0x040072E4 RID: 29412
		private XMainInterfaceTaskHandler _TaskHandler;

		// Token: 0x040072E5 RID: 29413
		public bool _TaskSwitchBtnState = true;

		// Token: 0x040072E6 RID: 29414
		public int IsNavigateToBattle = 0;

		// Token: 0x040072E7 RID: 29415
		private int m_SelectedTab = 0;

		// Token: 0x040072E8 RID: 29416
		private IXUILabel _TeamMemberCount;

		// Token: 0x040072E9 RID: 29417
		private IXUITweenTool _TeamMemberTween;

		// Token: 0x040072EA RID: 29418
		private GameObject _TeamMemberGo;

		// Token: 0x040072EB RID: 29419
		private GameObject _TeamMatchingGo;
	}
}
