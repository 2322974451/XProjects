using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XMainInterfaceBriefHandler : DlgHandlerBase
	{

		public XMainInterfaceTeamHandler TeamHandler
		{
			get
			{
				return this._TeamHandler;
			}
		}

		public XMainInterfaceTaskHandler TaskHandler
		{
			get
			{
				return this._TaskHandler;
			}
		}

		public bool IsShowingTaskTab
		{
			get
			{
				return this.m_SelectedTab == 1;
			}
		}

		protected override string FileName
		{
			get
			{
				return "Hall/HallTaskNaviFrame";
			}
		}

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

		protected override void OnShow()
		{
			bool flag = this._TaskHandler != null;
			if (flag)
			{
				this._TaskHandler.RefreshData();
			}
		}

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

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XMainInterfaceTeamHandler>(ref this._TeamHandler);
			DlgHandlerBase.EnsureUnload<XMainInterfaceTaskHandler>(ref this._TaskHandler);
			base.OnUnload();
		}

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

		public void SetTeamMatching(bool bMatching)
		{
			this._TeamMatchingGo.SetActive(bMatching);
		}

		public void OnSysChange()
		{
			this._TeamTab.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Team));
			this.m_List.Refresh();
		}

		private void OnTaskSwitchBtnClick(IXUISprite iSp)
		{
			this._TaskSwitchBtnState = !this._TaskSwitchBtnState;
			int tweenGroup = this._TaskSwitchBtnState ? 1 : 0;
			this.m_MainTween.SetTweenGroup(tweenGroup);
			this.m_SwitchTween.SetTweenGroup(tweenGroup);
			this.m_MainTween.PlayTween(true, -1f);
			this.m_SwitchTween.PlayTween(true, -1f);
		}

		private IXUICheckBox _TaskTab;

		private IXUICheckBox _TeamTab;

		private IXUISprite _TaskSprite;

		private IXUISprite _TeamSprite;

		private IXUIList m_List;

		private IXUISprite m_SwitchBtn;

		private IXUITweenTool m_SwitchTween;

		private IXUITweenTool m_MainTween;

		private XMainInterfaceTeamHandler _TeamHandler;

		private XMainInterfaceTaskHandler _TaskHandler;

		public bool _TaskSwitchBtnState = true;

		public int IsNavigateToBattle = 0;

		private int m_SelectedTab = 0;

		private IXUILabel _TeamMemberCount;

		private IXUITweenTool _TeamMemberTween;

		private GameObject _TeamMemberGo;

		private GameObject _TeamMatchingGo;
	}
}
