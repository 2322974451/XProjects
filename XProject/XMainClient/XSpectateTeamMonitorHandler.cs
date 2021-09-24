using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpectateTeamMonitorHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			this.m_TeamGo_Left = base.PanelObject.transform.Find("L/TeamFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XTeamMonitorHandler>(ref this.m_TeamMonitor_Left, this.m_TeamGo_Left, null, false);
			this.m_TeamGo_Left = base.PanelObject.transform.Find("L/TeamFrame/TeamPanel").gameObject;
			this.m_TeamGo_Right = base.PanelObject.transform.Find("R/TeamFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XTeamMonitorHandler>(ref this.m_TeamMonitor_Right, this.m_TeamGo_Right, null, false);
			this.m_TeamGo_Right = base.PanelObject.transform.Find("R/TeamFrame/TeamPanel").gameObject;
			this.m_RankCheckBox = (base.PanelObject.transform.Find("TabList/RankParent/Rank").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_TeamCheckBox = (base.PanelObject.transform.Find("TabList/TeamParent/Team").GetComponent("XUICheckBox") as IXUICheckBox);
			XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PK || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GMF || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GPR || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_LEAGUE_BATTLE || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CUSTOMPK || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PKTWO || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GCF;
			if (flag)
			{
				this.isTabsShow = false;
				this.m_RankCheckBox.gameObject.SetActive(false);
				this.m_TeamCheckBox.gameObject.SetActive(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RankCheckBox.ID = 0UL;
			this.m_TeamCheckBox.ID = 1UL;
			this.m_RankCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
			this.m_TeamCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
		}

		private bool _OnTabSelectionChanged(IXUICheckBox ckb)
		{
			bool flag = !ckb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = ckb.ID == 0UL;
				if (flag2)
				{
					this.m_TeamMonitor_Left.m_DamageRankHandler.SetVisible(true);
					this.m_TeamGo_Left.SetActive(false);
					this.m_TeamGo_Right.SetActive(false);
				}
				else
				{
					this.m_TeamMonitor_Left.m_DamageRankHandler.SetVisible(false);
					this.m_TeamGo_Left.SetActive(true);
					this.m_TeamGo_Right.SetActive(true);
					this.m_TeamMonitor_Left.CheckToggleState();
					this.m_TeamMonitor_Right.CheckToggleState();
				}
				result = true;
			}
			return result;
		}

		protected override void OnHide()
		{
			this.m_TeamMonitor_Left.SetVisible(false);
			this.m_TeamMonitor_Right.SetVisible(false);
			this.m_RankCheckBox.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
			this.m_TeamCheckBox.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
		}

		protected override void OnShow()
		{
			this.m_TeamMonitor_Left.SetVisible(true);
			this.m_TeamMonitor_Right.SetVisible(true);
			bool flag = this.isTabsShow;
			if (flag)
			{
				this.m_RankCheckBox.gameObject.transform.localPosition = Vector3.zero;
				this.m_TeamCheckBox.gameObject.transform.localPosition = Vector3.zero;
			}
		}

		public override void OnUnload()
		{
			this.m_TeamMonitor_Left.OnUnload();
			this.m_TeamMonitor_Right.OnUnload();
			base.OnUnload();
		}

		public void InitWhenShowMainUI()
		{
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			this.m_TeamMonitor_Left.InitWhenShowMainUIByBloodList(specificDocument.LeftTeamMonitorData);
			this.m_TeamMonitor_Right.InitWhenShowMainUIByBloodList(specificDocument.RightTeamMonitorData);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			byte teamInfoDefaultTab = sceneData.TeamInfoDefaultTab;
			if (teamInfoDefaultTab != 0)
			{
				if (teamInfoDefaultTab == 1)
				{
					this.m_RankCheckBox.bChecked = true;
				}
			}
			else
			{
				this.m_TeamCheckBox.bChecked = true;
			}
		}

		public void OnLeftTeamInfoChanged(bool isLeft, List<XTeamBloodUIData> list)
		{
			if (isLeft)
			{
				this.m_TeamMonitor_Left.TeamInfoChangeOnSpectate(list);
			}
			else
			{
				this.m_TeamMonitor_Right.TeamInfoChangeOnSpectate(list);
			}
		}

		public void OnTeamInfoChanged()
		{
			this.m_TeamMonitor_Left.OnTeamInfoChanged();
			this.m_TeamMonitor_Right.OnTeamInfoChanged();
		}

		public override void OnUpdate()
		{
			this.m_TeamMonitor_Left.OnUpdate();
			this.m_TeamMonitor_Right.OnUpdate();
		}

		public XTeamMonitorHandler m_TeamMonitor_Left;

		public XTeamMonitorHandler m_TeamMonitor_Right;

		private GameObject m_TeamGo_Left;

		private GameObject m_TeamGo_Right;

		private IXUICheckBox m_RankCheckBox;

		private IXUICheckBox m_TeamCheckBox;

		private bool isTabsShow = true;
	}
}
