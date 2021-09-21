using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BE3 RID: 3043
	internal class ReplaykitDlg : DlgBase<ReplaykitDlg, ReplayBehaviour>
	{
		// Token: 0x1700309D RID: 12445
		// (get) Token: 0x0600AD59 RID: 44377 RVA: 0x002020CC File Offset: 0x002002CC
		public override string fileName
		{
			get
			{
				return "Hall/ReplayDlg";
			}
		}

		// Token: 0x1700309E RID: 12446
		// (get) Token: 0x0600AD5A RID: 44378 RVA: 0x002020E4 File Offset: 0x002002E4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700309F RID: 12447
		// (get) Token: 0x0600AD5B RID: 44379 RVA: 0x002020F8 File Offset: 0x002002F8
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600AD5C RID: 44380 RVA: 0x0020210B File Offset: 0x0020030B
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600AD5D RID: 44381 RVA: 0x00202118 File Offset: 0x00200318
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btn_camera.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnCameraClick));
			base.uiBehaviour.m_btn_stop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStopClick));
			base.uiBehaviour.m_btn_mic.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnMicClick));
			base.uiBehaviour.m_btn_switch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnSwitchClick));
		}

		// Token: 0x0600AD5E RID: 44382 RVA: 0x002021A4 File Offset: 0x002003A4
		public void CheckShow()
		{
			bool flag = this.isPlaying;
			if (flag)
			{
				this.SetVisible(true, true);
				this.Refresh();
			}
		}

		// Token: 0x0600AD5F RID: 44383 RVA: 0x002021D0 File Offset: 0x002003D0
		public void Show(bool show)
		{
			bool flag = DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.isBroadcast && show;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Replay_IsBroadcasting"), "fece00");
			}
			else
			{
				if (show)
				{
					this.SetVisible(true, true);
				}
				else
				{
					bool flag2 = base.IsLoaded();
					if (flag2)
					{
						this.SetVisible(false, true);
					}
				}
				if (show)
				{
					ReplaykitDlg.isCameraOpen = true;
					this.Refresh();
					this.OnBtnCameraClick(base.uiBehaviour.m_btn_camera);
				}
			}
		}

		// Token: 0x0600AD60 RID: 44384 RVA: 0x00202254 File Offset: 0x00200454
		private void Refresh()
		{
			base.uiBehaviour.m_spr_disable_camera.SetVisible(!ReplaykitDlg.isCameraOpen);
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("is_microphone_enabled", "");
			base.uiBehaviour.m_spr_disable_mic.SetVisible(!flag);
			XSingleton<XDebug>.singleton.AddLog("CAMERA: " + ReplaykitDlg.isCameraOpen.ToString(), " micro: " + flag.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600AD61 RID: 44385 RVA: 0x002022E0 File Offset: 0x002004E0
		private bool OnBtnCameraClick(IXUIButton btn)
		{
			List<float> floatList = XSingleton<XGlobalConfig>.singleton.GetFloatList("ReplayPos");
			ReplaykitDlg.isCameraOpen = !ReplaykitDlg.isCameraOpen;
			base.uiBehaviour.m_spr_disable_camera.SetVisible(!ReplaykitDlg.isCameraOpen);
			bool flag = ReplaykitDlg.isCameraOpen;
			if (flag)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary["xPoint"] = floatList[0];
				dictionary["yPoint"] = floatList[1];
				dictionary["width"] = floatList[2];
				dictionary["height"] = floatList[3];
				string text = Json.Serialize(dictionary);
				XSingleton<XDebug>.singleton.AddLog("SetPortraitFrame paramStr = ", text, null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("set_portrait_frame", text);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("remove_portrait_frame", null, null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("remove_portrait_frame", "");
			}
			return true;
		}

		// Token: 0x0600AD62 RID: 44386 RVA: 0x00202408 File Offset: 0x00200608
		private bool OnBtnMicClick(IXUIButton btn)
		{
			bool flag = !XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("is_microphone_enabled", "");
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["enable"] = (flag ? "true" : "false");
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("SetPortraitFrame paramStr = ", text, null, null, null, null, XDebugColor.XDebug_None);
			base.uiBehaviour.m_spr_disable_mic.SetVisible(!flag);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("switch_microphone", text);
			return true;
		}

		// Token: 0x0600AD63 RID: 44387 RVA: 0x002024A4 File Offset: 0x002006A4
		public bool OnStopClick(IXUIButton btn)
		{
			this.Show(false);
			this.isReadyPlaying = false;
			this.isPlaying = false;
			XSingleton<XDebug>.singleton.AddLog("finish_broadcasting", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("finish_broadcasting", "");
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("remove_portrait_frame", "");
			return true;
		}

		// Token: 0x0600AD64 RID: 44388 RVA: 0x00202517 File Offset: 0x00200717
		public void OpenRepaly()
		{
			XSingleton<XDebug>.singleton.AddLog("select_broadcast_service", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("select_broadcast_service", "");
			ReplaykitDlg.isCameraOpen = false;
			this.isReadyPlaying = true;
		}

		// Token: 0x0600AD65 RID: 44389 RVA: 0x00202558 File Offset: 0x00200758
		private bool OnBtnSwitchClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("OnBtnSwitchClick", null, null, null, null, null, XDebugColor.XDebug_None);
			return true;
		}

		// Token: 0x0600AD66 RID: 44390 RVA: 0x00202584 File Offset: 0x00200784
		public void ResumeReplay()
		{
			bool flag = this.isPlaying;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("resume_broadcasting", null, null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("resume_broadcasting", "");
			}
		}

		// Token: 0x0400414E RID: 16718
		public bool isPlaying = false;

		// Token: 0x0400414F RID: 16719
		public bool isReadyPlaying = false;

		// Token: 0x04004150 RID: 16720
		public static bool isCameraOpen = false;
	}
}
