using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C60 RID: 3168
	internal class XOptionsBattleHandler : DlgHandlerBase
	{
		// Token: 0x170031B4 RID: 12724
		// (get) Token: 0x0600B36E RID: 45934 RVA: 0x0022EA90 File Offset: 0x0022CC90
		protected override string FileName
		{
			get
			{
				return "Battle/BattleSetDlg";
			}
		}

		// Token: 0x0600B36F RID: 45935 RVA: 0x0022EAA8 File Offset: 0x0022CCA8
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Continue = (base.transform.Find("Bg/Btn/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_Leave = (base.transform.Find("Bg/Btn/Leave").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Tabs");
			this.m_CameraTab = (transform.Find("CameraTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_OperateTab = (transform.Find("OperateTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_OtherTab = (transform.Find("OtherTab").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_CameraTabLabel = (transform.Find("CameraTab/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OperateTabLabel = (transform.Find("OperateTab/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherTabTabLabel = (transform.Find("OtherTab/T").GetComponent("XUILabel") as IXUILabel);
			this.m_CameraSelecteTabLabel = (transform.Find("CameraTab/Selected/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OperateSelecteTabLabel = (transform.Find("OperateTab/Selected/T").GetComponent("XUILabel") as IXUILabel);
			this.m_OtherSelecteTabTabLabel = (transform.Find("OtherTab/Selected/T").GetComponent("XUILabel") as IXUILabel);
			DlgHandlerBase.EnsureCreate<XOptionsBattleDetailHandler>(ref this.m_DetailHandler, base.transform.Find("Bg/DetailPanel").gameObject, null, true);
		}

		// Token: 0x0600B370 RID: 45936 RVA: 0x0022EC90 File Offset: 0x0022CE90
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Continue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Leave.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLeaveClicked));
			this.m_CameraTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCameraCheckBoxClicked));
			this.m_OperateTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnOperateCheckBoxClicked));
			this.m_OtherTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnOtherCheckBoxClicked));
		}

		// Token: 0x0600B371 RID: 45937 RVA: 0x0022ED30 File Offset: 0x0022CF30
		public bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			bool flag = this.m_DetailHandler != null;
			if (flag)
			{
				this.m_DetailHandler.SaveOption();
				bool flag2 = this.m_DetailHandler.bDirty || XSingleton<XOperationData>.singleton.OperationMode != (XOperationMode)this.doc.GetValue(XOptionsDefine.OD_VIEW);
				if (flag2)
				{
					this.doc.SetBattleOptionValue();
					this.m_DetailHandler.bDirty = false;
				}
			}
			return true;
		}

		// Token: 0x0600B372 RID: 45938 RVA: 0x0022EDB4 File Offset: 0x0022CFB4
		public bool OnLeaveClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			bool flag = this.m_DetailHandler != null;
			if (flag)
			{
				this.m_DetailHandler.SaveOption();
			}
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_TOWER;
				if (flag2)
				{
					PtcC2G_SyncSceneFinish proto = new PtcC2G_SyncSceneFinish();
					XSingleton<XClientNetwork>.singleton.Send(proto);
				}
				else
				{
					bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BOSSRUSH;
					if (flag3)
					{
						bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag4)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowBossrushQuit();
						}
					}
					else
					{
						XSingleton<XScene>.singleton.ReqLeaveScene();
					}
				}
			}
			else
			{
				RpcC2G_ReportBattle rpcC2G_ReportBattle = new RpcC2G_ReportBattle();
				rpcC2G_ReportBattle.oArg.battledata = new BattleData();
				rpcC2G_ReportBattle.oArg.battledata.BeHit = 0;
				rpcC2G_ReportBattle.oArg.battledata.hppercent = 100U;
				rpcC2G_ReportBattle.oArg.battledata.Combo = 100;
				XSingleton<XLevelFinishMgr>.singleton.IsFastLevelFinish = true;
				XSingleton<XLevelDoodadMgr>.singleton.ReportServerList(rpcC2G_ReportBattle.oArg.battledata.pickDoodadWaveID);
				XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
				specificDocument.RequestServer = true;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ReportBattle);
			}
			XSingleton<XGameSysMgr>.singleton.bStopBlockRedPoint = true;
			return true;
		}

		// Token: 0x0600B373 RID: 45939 RVA: 0x0022EF18 File Offset: 0x0022D118
		public void ShowUI()
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				base.SetVisible(true);
			}
			this.OnTabChanged(this.prefabTab);
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(false);
		}

		// Token: 0x0600B374 RID: 45940 RVA: 0x0022EF54 File Offset: 0x0022D154
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowUI();
			XOptions.RowData optionData = XOptionsDocument.GetOptionData(XOptionsDefine.OD_VIEW);
			this.m_CameraTabLabel.SetText(optionData.Text);
			this.m_CameraSelecteTabLabel.SetText(optionData.Text);
			optionData = XOptionsDocument.GetOptionData(XOptionsDefine.OD_OPERATE);
			this.m_OperateTabLabel.SetText(optionData.Text);
			this.m_OperateSelecteTabLabel.SetText(optionData.Text);
			optionData = XOptionsDocument.GetOptionData(XOptionsDefine.OD_OTHER);
			this.m_OtherTabTabLabel.SetText(optionData.Text);
			this.m_OtherSelecteTabTabLabel.SetText(optionData.Text);
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			bool flag = sceneData.IsCanQuit || XSingleton<XScene>.singleton.bSpectator;
			if (flag)
			{
				this.m_Leave.SetEnable(true, false);
			}
			else
			{
				this.m_Leave.SetEnable(true, false);
			}
		}

		// Token: 0x0600B375 RID: 45941 RVA: 0x0022F04D File Offset: 0x0022D24D
		protected override void OnHide()
		{
			XSingleton<XShell>.singleton.Pause = false;
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			base.OnHide();
		}

		// Token: 0x0600B376 RID: 45942 RVA: 0x0022F06F File Offset: 0x0022D26F
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XOptionsBattleDetailHandler>(ref this.m_DetailHandler);
			base.OnUnload();
		}

		// Token: 0x0600B377 RID: 45943 RVA: 0x0022F088 File Offset: 0x0022D288
		private bool OnCameraCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsBattleTab.CameraTab);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B378 RID: 45944 RVA: 0x0022F0B4 File Offset: 0x0022D2B4
		private bool OnOperateCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsBattleTab.OperateTab);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B379 RID: 45945 RVA: 0x0022F0E0 File Offset: 0x0022D2E0
		private bool OnOtherCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnTabChanged(OptionsBattleTab.OtherTab);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B37A RID: 45946 RVA: 0x0022F10C File Offset: 0x0022D30C
		public void OnTabChanged(OptionsBattleTab handler)
		{
			switch (handler)
			{
			case OptionsBattleTab.CameraTab:
			{
				bool flag = this.m_CameraTab != null;
				if (flag)
				{
					this.m_CameraTab.bChecked = true;
				}
				break;
			}
			case OptionsBattleTab.OperateTab:
			{
				bool flag2 = this.m_OperateTab != null;
				if (flag2)
				{
					this.m_OperateTab.bChecked = true;
				}
				break;
			}
			case OptionsBattleTab.OtherTab:
			{
				bool flag3 = this.m_OtherTab != null;
				if (flag3)
				{
					this.m_OtherTab.bChecked = true;
				}
				break;
			}
			}
			bool flag4 = this.m_DetailHandler != null;
			if (flag4)
			{
				this.m_DetailHandler.ShowUI(handler);
			}
			this.prefabTab = handler;
		}

		// Token: 0x0400457C RID: 17788
		private XOptionsDocument doc = null;

		// Token: 0x0400457D RID: 17789
		private XOptionsBattleDetailHandler m_DetailHandler;

		// Token: 0x0400457E RID: 17790
		public OptionsBattleTab prefabTab = OptionsBattleTab.CameraTab;

		// Token: 0x0400457F RID: 17791
		private IXUIButton m_Close;

		// Token: 0x04004580 RID: 17792
		private IXUIButton m_Continue;

		// Token: 0x04004581 RID: 17793
		private IXUIButton m_Leave;

		// Token: 0x04004582 RID: 17794
		private IXUICheckBox m_CameraTab;

		// Token: 0x04004583 RID: 17795
		private IXUICheckBox m_OperateTab;

		// Token: 0x04004584 RID: 17796
		private IXUICheckBox m_OtherTab;

		// Token: 0x04004585 RID: 17797
		private IXUILabel m_CameraTabLabel;

		// Token: 0x04004586 RID: 17798
		private IXUILabel m_OperateTabLabel;

		// Token: 0x04004587 RID: 17799
		private IXUILabel m_OtherTabTabLabel;

		// Token: 0x04004588 RID: 17800
		private IXUILabel m_CameraSelecteTabLabel;

		// Token: 0x04004589 RID: 17801
		private IXUILabel m_OperateSelecteTabLabel;

		// Token: 0x0400458A RID: 17802
		private IXUILabel m_OtherSelecteTabTabLabel;
	}
}
