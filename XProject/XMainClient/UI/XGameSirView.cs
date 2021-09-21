using System;
using System.Collections.Generic;
using MiniJSON;
using UILib;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017ED RID: 6125
	internal class XGameSirView : DlgBase<XGameSirView, XGameSirBehaviour>
	{
		// Token: 0x170038C3 RID: 14531
		// (get) Token: 0x0600FDDA RID: 64986 RVA: 0x003B9368 File Offset: 0x003B7568
		public override bool fullscreenui
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170038C4 RID: 14532
		// (get) Token: 0x0600FDDB RID: 64987 RVA: 0x003B937C File Offset: 0x003B757C
		public override string fileName
		{
			get
			{
				return "Common/GameSirDlg";
			}
		}

		// Token: 0x170038C5 RID: 14533
		// (get) Token: 0x0600FDDC RID: 64988 RVA: 0x003B9394 File Offset: 0x003B7594
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170038C6 RID: 14534
		// (get) Token: 0x0600FDDD RID: 64989 RVA: 0x003B93A8 File Offset: 0x003B75A8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038C7 RID: 14535
		// (get) Token: 0x0600FDDE RID: 64990 RVA: 0x003B93BC File Offset: 0x003B75BC
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038C8 RID: 14536
		// (get) Token: 0x0600FDDF RID: 64991 RVA: 0x003B93D0 File Offset: 0x003B75D0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038C9 RID: 14537
		// (get) Token: 0x0600FDE0 RID: 64992 RVA: 0x003B93E4 File Offset: 0x003B75E4
		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170038CA RID: 14538
		// (get) Token: 0x0600FDE1 RID: 64993 RVA: 0x003B93F8 File Offset: 0x003B75F8
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170038CB RID: 14539
		// (get) Token: 0x0600FDE2 RID: 64994 RVA: 0x003B940C File Offset: 0x003B760C
		private IXGameSirControl SirControl
		{
			get
			{
				return XSingleton<XUpdater.XUpdater>.singleton.GameSirControl;
			}
		}

		// Token: 0x0600FDE3 RID: 64995 RVA: 0x003B9428 File Offset: 0x003B7628
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.m_ConnectBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ConnectClick));
			base.uiBehaviour.m_ShowKeyBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ShowKeyCodeClick));
		}

		// Token: 0x0600FDE4 RID: 64996 RVA: 0x003B9494 File Offset: 0x003B7694
		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateGameSirStatu();
			this.RefreshWhenShow();
		}

		// Token: 0x0600FDE5 RID: 64997 RVA: 0x003B94AC File Offset: 0x003B76AC
		protected override void OnHide()
		{
			base.OnHide();
			this.mConnecting = false;
			this.m_ConnectTimeOut.LeftTime = 0f;
			this.mConnectStatu = XGameSirView.ConnectStatu.CONNECT;
		}

		// Token: 0x0600FDE6 RID: 64998 RVA: 0x003B94D5 File Offset: 0x003B76D5
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateGameSirStatu();
		}

		// Token: 0x0600FDE7 RID: 64999 RVA: 0x003B94E8 File Offset: 0x003B76E8
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

		// Token: 0x0600FDE8 RID: 65000 RVA: 0x003B9578 File Offset: 0x003B7778
		private void SetGameSirStatu(XGameSirView.ConnectStatu statu)
		{
			bool flag = this.mConnectStatu == statu;
			if (!flag)
			{
				this.mConnectStatu = statu;
				this.RefreshWhenShow();
			}
		}

		// Token: 0x0600FDE9 RID: 65001 RVA: 0x003B95A4 File Offset: 0x003B77A4
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

		// Token: 0x0600FDEA RID: 65002 RVA: 0x003B9664 File Offset: 0x003B7864
		private bool CloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600FDEB RID: 65003 RVA: 0x003B9680 File Offset: 0x003B7880
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

		// Token: 0x0600FDEC RID: 65004 RVA: 0x003B9714 File Offset: 0x003B7914
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

		// Token: 0x04007010 RID: 28688
		private XGameSirView.ConnectStatu mConnectStatu = XGameSirView.ConnectStatu.CONNECT;

		// Token: 0x04007011 RID: 28689
		private bool mConnecting = false;

		// Token: 0x04007012 RID: 28690
		private XElapseTimer m_ConnectTimeOut = new XElapseTimer();

		// Token: 0x02001A11 RID: 6673
		public enum ConnectStatu
		{
			// Token: 0x04008230 RID: 33328
			CONNECT,
			// Token: 0x04008231 RID: 33329
			CONNECTING,
			// Token: 0x04008232 RID: 33330
			CONNECTED
		}
	}
}
