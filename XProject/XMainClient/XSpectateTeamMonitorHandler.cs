using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D12 RID: 3346
	internal class XSpectateTeamMonitorHandler : DlgHandlerBase
	{
		// Token: 0x0600BAC3 RID: 47811 RVA: 0x002633D4 File Offset: 0x002615D4
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

		// Token: 0x0600BAC4 RID: 47812 RVA: 0x00263580 File Offset: 0x00261780
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_RankCheckBox.ID = 0UL;
			this.m_TeamCheckBox.ID = 1UL;
			this.m_RankCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
			this.m_TeamCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._OnTabSelectionChanged));
		}

		// Token: 0x0600BAC5 RID: 47813 RVA: 0x002635E4 File Offset: 0x002617E4
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

		// Token: 0x0600BAC6 RID: 47814 RVA: 0x00263690 File Offset: 0x00261890
		protected override void OnHide()
		{
			this.m_TeamMonitor_Left.SetVisible(false);
			this.m_TeamMonitor_Right.SetVisible(false);
			this.m_RankCheckBox.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
			this.m_TeamCheckBox.gameObject.transform.localPosition = Vector3.one * (float)XGameUI._far_far_away;
		}

		// Token: 0x0600BAC7 RID: 47815 RVA: 0x00263704 File Offset: 0x00261904
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

		// Token: 0x0600BAC8 RID: 47816 RVA: 0x0026376E File Offset: 0x0026196E
		public override void OnUnload()
		{
			this.m_TeamMonitor_Left.OnUnload();
			this.m_TeamMonitor_Right.OnUnload();
			base.OnUnload();
		}

		// Token: 0x0600BAC9 RID: 47817 RVA: 0x00263790 File Offset: 0x00261990
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

		// Token: 0x0600BACA RID: 47818 RVA: 0x00263814 File Offset: 0x00261A14
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

		// Token: 0x0600BACB RID: 47819 RVA: 0x00263847 File Offset: 0x00261A47
		public void OnTeamInfoChanged()
		{
			this.m_TeamMonitor_Left.OnTeamInfoChanged();
			this.m_TeamMonitor_Right.OnTeamInfoChanged();
		}

		// Token: 0x0600BACC RID: 47820 RVA: 0x00263862 File Offset: 0x00261A62
		public override void OnUpdate()
		{
			this.m_TeamMonitor_Left.OnUpdate();
			this.m_TeamMonitor_Right.OnUpdate();
		}

		// Token: 0x04004B1F RID: 19231
		public XTeamMonitorHandler m_TeamMonitor_Left;

		// Token: 0x04004B20 RID: 19232
		public XTeamMonitorHandler m_TeamMonitor_Right;

		// Token: 0x04004B21 RID: 19233
		private GameObject m_TeamGo_Left;

		// Token: 0x04004B22 RID: 19234
		private GameObject m_TeamGo_Right;

		// Token: 0x04004B23 RID: 19235
		private IXUICheckBox m_RankCheckBox;

		// Token: 0x04004B24 RID: 19236
		private IXUICheckBox m_TeamCheckBox;

		// Token: 0x04004B25 RID: 19237
		private bool isTabsShow = true;
	}
}
