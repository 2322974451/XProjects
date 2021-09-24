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

	internal class ReplaykitDlg : DlgBase<ReplaykitDlg, ReplayBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/ReplayDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btn_camera.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnCameraClick));
			base.uiBehaviour.m_btn_stop.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStopClick));
			base.uiBehaviour.m_btn_mic.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnMicClick));
			base.uiBehaviour.m_btn_switch.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnSwitchClick));
		}

		public void CheckShow()
		{
			bool flag = this.isPlaying;
			if (flag)
			{
				this.SetVisible(true, true);
				this.Refresh();
			}
		}

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

		private void Refresh()
		{
			base.uiBehaviour.m_spr_disable_camera.SetVisible(!ReplaykitDlg.isCameraOpen);
			bool flag = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.CheckStatus("is_microphone_enabled", "");
			base.uiBehaviour.m_spr_disable_mic.SetVisible(!flag);
			XSingleton<XDebug>.singleton.AddLog("CAMERA: " + ReplaykitDlg.isCameraOpen.ToString(), " micro: " + flag.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

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

		public void OpenRepaly()
		{
			XSingleton<XDebug>.singleton.AddLog("select_broadcast_service", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("select_broadcast_service", "");
			ReplaykitDlg.isCameraOpen = false;
			this.isReadyPlaying = true;
		}

		private bool OnBtnSwitchClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddLog("OnBtnSwitchClick", null, null, null, null, null, XDebugColor.XDebug_None);
			return true;
		}

		public void ResumeReplay()
		{
			bool flag = this.isPlaying;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("resume_broadcasting", null, null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("resume_broadcasting", "");
			}
		}

		public bool isPlaying = false;

		public bool isReadyPlaying = false;

		public static bool isCameraOpen = false;
	}
}
