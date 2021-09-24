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

	internal class XOptionsBattleHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/BattleSetDlg";
			}
		}

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

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Continue.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_Leave.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnLeaveClicked));
			this.m_CameraTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCameraCheckBoxClicked));
			this.m_OperateTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnOperateCheckBoxClicked));
			this.m_OtherTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnOtherCheckBoxClicked));
		}

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

		protected override void OnHide()
		{
			XSingleton<XShell>.singleton.Pause = false;
			DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.SetMaqueeSwitch(true);
			base.OnHide();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XOptionsBattleDetailHandler>(ref this.m_DetailHandler);
			base.OnUnload();
		}

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

		private XOptionsDocument doc = null;

		private XOptionsBattleDetailHandler m_DetailHandler;

		public OptionsBattleTab prefabTab = OptionsBattleTab.CameraTab;

		private IXUIButton m_Close;

		private IXUIButton m_Continue;

		private IXUIButton m_Leave;

		private IXUICheckBox m_CameraTab;

		private IXUICheckBox m_OperateTab;

		private IXUICheckBox m_OtherTab;

		private IXUILabel m_CameraTabLabel;

		private IXUILabel m_OperateTabLabel;

		private IXUILabel m_OtherTabTabLabel;

		private IXUILabel m_CameraSelecteTabLabel;

		private IXUILabel m_OperateSelecteTabLabel;

		private IXUILabel m_OtherSelecteTabTabLabel;
	}
}
