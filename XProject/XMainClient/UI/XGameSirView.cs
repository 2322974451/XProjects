using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGameSirView : DlgBase<XGameSirView, XGameSirBehaviour>
	{

		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		public override string fileName
		{
			get
			{
				return "Common/GameSirDlg";
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		private IXGameSirControl SirControl
		{
			get
			{
				return XSingleton<XUpdater.XUpdater>.singleton.GameSirControl;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.m_ConnectBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ConnectClick));
			base.uiBehaviour.m_ShowKeyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ShowKeyCodeClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateGameSirStatu();
			this.RefreshWhenShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.mConnecting = false;
			this.m_ConnectTimeOut.LeftTime = 0f;
			this.mConnectStatu = XGameSirView.ConnectStatu.CONNECT;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateGameSirStatu();
		}

		private void UpdateGameSirStatu()
		{
			bool flag = this.SirControl == null;
			if (flag)
			{
				this.SetGameSirStatu(XGameSirView.ConnectStatu.CONNECT);
			}
			else
			{
				bool flag2 = this.SirControl.IsConnected();
				if (flag2)
				{
					this.SetGameSirStatu(XGameSirView.ConnectStatu.CONNECTED);
				}
				else
				{
					bool flag3 = this.mConnecting;
					if (flag3)
					{
						this.m_ConnectTimeOut.Update();
						bool flag4 = this.m_ConnectTimeOut.LeftTime > 0f;
						if (flag4)
						{
							this.SetGameSirStatu(XGameSirView.ConnectStatu.CONNECTING);
						}
						else
						{
							this.mConnecting = false;
						}
					}
					else
					{
						this.SetGameSirStatu(XGameSirView.ConnectStatu.CONNECT);
					}
				}
			}
		}

		private void SetGameSirStatu(XGameSirView.ConnectStatu statu)
		{
			bool flag = this.mConnectStatu == statu;
			if (!flag)
			{
				this.mConnectStatu = statu;
				this.RefreshWhenShow();
			}
		}

		private void RefreshWhenShow()
		{
			XGameSirView.ConnectStatu connectStatu = this.mConnectStatu;
			if (connectStatu != XGameSirView.ConnectStatu.CONNECTING)
			{
				if (connectStatu != XGameSirView.ConnectStatu.CONNECTED)
				{
					this.mConnecting = false;
					base.uiBehaviour.m_ConntectStatus.SetText(XStringDefineProxy.GetString("HANDLE_STATU_CONNECT"));
					base.uiBehaviour.m_ConnectBtn.SetEnable(true, false);
				}
				else
				{
					this.mConnecting = false;
					base.uiBehaviour.m_ConntectStatus.SetText(XStringDefineProxy.GetString("HANDLE_STATU_CONNECTED"));
					base.uiBehaviour.m_ConnectBtn.SetEnable(true, false);
				}
			}
			else
			{
				base.uiBehaviour.m_ConntectStatus.SetText(XStringDefineProxy.GetString("HANDLE_STATU_CONNECTING"));
				base.uiBehaviour.m_ConnectBtn.SetEnable(false, false);
			}
		}

		private bool CloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool ConnectClick(IXUIButton btn)
		{
			bool flag = this.mConnectStatu == XGameSirView.ConnectStatu.CONNECT;
			if (flag)
			{
				this.m_ConnectTimeOut.LeftTime = (float)XSingleton<XGlobalConfig>.singleton.GetInt("GameSirTimeOut");
				this.mConnecting = true;
				bool flag2 = this.SirControl != null;
				if (flag2)
				{
					this.SirControl.StartSir();
				}
			}
			else
			{
				bool flag3 = this.mConnectStatu == XGameSirView.ConnectStatu.CONNECTED;
				if (flag3)
				{
					this.mConnecting = false;
					bool flag4 = this.SirControl != null;
					if (flag4)
					{
						this.SirControl.StopSir();
					}
				}
			}
			return true;
		}

		private bool ShowKeyCodeClick(IXUIButton btn)
		{
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("GameSirKeyUrl");
			bool flag = string.IsNullOrEmpty(value);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				XSingleton<XDebug>.singleton.AddGreenLog("Open GameSir Key:", value, null, null, null, null);
				dictionary["url"] = value;
				dictionary["screendir"] = "SENSOR";
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("open_url", Json.Serialize(dictionary));
				result = true;
			}
			return result;
		}

		private XGameSirView.ConnectStatu mConnectStatu = XGameSirView.ConnectStatu.CONNECT;

		private bool mConnecting = false;

		private XElapseTimer m_ConnectTimeOut = new XElapseTimer();

		public enum ConnectStatu
		{

			CONNECT,

			CONNECTING,

			CONNECTED
		}
	}
}
