using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D8A RID: 3466
	internal class XConnection
	{
		// Token: 0x17003331 RID: 13105
		// (get) Token: 0x0600BD0A RID: 48394 RVA: 0x0027027C File Offset: 0x0026E47C
		public bool OnConnectDelay
		{
			get
			{
				return this._is_connect_delay;
			}
		}

		// Token: 0x17003332 RID: 13106
		// (get) Token: 0x0600BD0B RID: 48395 RVA: 0x00270294 File Offset: 0x0026E494
		public bool OnRpcDelay
		{
			get
			{
				return Rpc.OnRpcDelay;
			}
		}

		// Token: 0x17003333 RID: 13107
		// (get) Token: 0x0600BD0C RID: 48396 RVA: 0x002702AC File Offset: 0x0026E4AC
		public bool OnReconnect
		{
			get
			{
				return this._is_on_reconnection;
			}
		}

		// Token: 0x17003334 RID: 13108
		// (get) Token: 0x0600BD0D RID: 48397 RVA: 0x002702C4 File Offset: 0x0026E4C4
		// (set) Token: 0x0600BD0E RID: 48398 RVA: 0x002702DC File Offset: 0x0026E4DC
		public bool ReconnectionEnabled
		{
			get
			{
				return this._reconnection_enabled;
			}
			set
			{
				this._reconnection_enabled = value;
			}
		}

		// Token: 0x17003335 RID: 13109
		// (get) Token: 0x0600BD0F RID: 48399 RVA: 0x002702E8 File Offset: 0x0026E4E8
		private float ConnectElapsed
		{
			get
			{
				return (float)DateTime.Now.Subtract(this._last_connect_at).TotalSeconds;
			}
		}

		// Token: 0x17003336 RID: 13110
		// (get) Token: 0x0600BD10 RID: 48400 RVA: 0x00270318 File Offset: 0x0026E518
		private float ReconnectElapsed
		{
			get
			{
				return (float)DateTime.Now.Subtract(this._reconnect_at).TotalSeconds;
			}
		}

		// Token: 0x0600BD11 RID: 48401 RVA: 0x00270348 File Offset: 0x0026E548
		public CNetwork Init(INetObserver observer)
		{
			this._network = new CNetwork();
			CNetSender oSender = new CNetSender(this._network);
			CNetProcessor oProc = new CNetProcessor(this._network, observer);
			bool flag = !this._network.Init(oProc, oSender, new CPacketBreaker(), this._buffer_size, this._buffer_size);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("network initialization failed!", null, null, null, null, null);
				this._network = null;
			}
			return this._network;
		}

		// Token: 0x0600BD12 RID: 48402 RVA: 0x002703C8 File Offset: 0x0026E5C8
		public bool Connet(string IP, int Port)
		{
			this.Close(NetErrCode.Net_NoError);
			this._last_connect_at = DateTime.Now;
			bool flag = this._network.Connect(IP, Port);
			bool flag2 = !flag;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddLog("connect to ", IP, "failed!", null, null, null, XDebugColor.XDebug_None);
			}
			return flag;
		}

		// Token: 0x0600BD13 RID: 48403 RVA: 0x00270420 File Offset: 0x0026E620
		public void Reconnect(string IP, int Port)
		{
			XSingleton<XDebug>.singleton.AddLog("Begin Reconnection.", null, null, null, null, null, XDebugColor.XDebug_None);
			this._reconnect_ip = IP;
			this._reconnect_port = Port;
			bool flag = !this._is_on_reconnection;
			if (flag)
			{
				this._is_on_reconnection = true;
				this._is_manually_reconnection = false;
				this._is_manually_reconnect_ui_bshow = false;
				this._reconnect_at = DateTime.Now;
			}
		}

		// Token: 0x0600BD14 RID: 48404 RVA: 0x00270484 File Offset: 0x0026E684
		public bool Close(NetErrCode err)
		{
			bool flag = !this._network.IsDisconnect();
			bool result;
			if (flag)
			{
				this._network.Close(err);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600BD15 RID: 48405 RVA: 0x002704BB File Offset: 0x0026E6BB
		public void OnReconnected()
		{
			this._is_on_reconnection = false;
			XSingleton<XDebug>.singleton.AddLog("Reconnected.", null, null, null, null, null, XDebugColor.XDebug_None);
			Rpc.delayRpcName = "";
		}

		// Token: 0x0600BD16 RID: 48406 RVA: 0x002704E8 File Offset: 0x0026E6E8
		public void OnReconnectFailed()
		{
			bool is_on_reconnection = this._is_on_reconnection;
			if (is_on_reconnection)
			{
				this._is_on_reconnection = false;
				bool flag = this._network.GetSocketState() > SocketState.State_Closed;
				if (flag)
				{
					this.Close(NetErrCode.Net_ReconnectFailed);
				}
				XSingleton<XDebug>.singleton.AddLog("Reconnect Failed.", null, null, null, null, null, XDebugColor.XDebug_None);
				bool sceneReady = XSingleton<XScene>.singleton.SceneReady;
				if (sceneReady)
				{
					XSingleton<UiUtility>.singleton.OnFatalErrorClosed(ErrorCode.ERR_RECONNECT_FAIL);
				}
				else
				{
					XSingleton<XScene>.singleton.Error = ErrorCode.ERR_RECONNECT_FAIL;
				}
			}
		}

		// Token: 0x0600BD17 RID: 48407 RVA: 0x0027056C File Offset: 0x0026E76C
		public void StopReconnection()
		{
			bool is_on_reconnection = this._is_on_reconnection;
			if (is_on_reconnection)
			{
				this._is_on_reconnection = false;
			}
		}

		// Token: 0x0600BD18 RID: 48408 RVA: 0x00270590 File Offset: 0x0026E790
		public SocketState GetSocketState()
		{
			return this._network.GetSocketState();
		}

		// Token: 0x0600BD19 RID: 48409 RVA: 0x002705B0 File Offset: 0x0026E7B0
		public void Update()
		{
			this._is_connect_delay = false;
			switch (this._network.GetSocketState())
			{
			case SocketState.State_Closed:
			{
				bool is_on_reconnection = this._is_on_reconnection;
				if (is_on_reconnection)
				{
					bool flag = !this._is_manually_reconnection;
					if (flag)
					{
						this._try_reconnect_count = XSingleton<XGlobalConfig>.singleton.GetInt("ReconnectTime");
						bool flag2 = this.Connet(this._reconnect_ip, this._reconnect_port);
						if (flag2)
						{
							bool flag3 = !string.IsNullOrEmpty(Rpc.delayRpcName);
							if (flag3)
							{
								XSingleton<XDebug>.singleton.AddWarningLog("rpc delay: ", Rpc.delayRpcName, null, null, null, null);
							}
							XSingleton<XDebug>.singleton.AddLog("reconnecting...", null, null, null, null, null, XDebugColor.XDebug_None);
						}
						this._is_manually_reconnection = true;
					}
					else
					{
						bool flag4 = !this._is_manually_reconnect_ui_bshow;
						if (flag4)
						{
							bool flag5 = this._try_reconnect_count > 0;
							if (flag5)
							{
								this._is_manually_reconnect_ui_bshow = true;
								XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("RECONNECT_TIP"), XStringDefineProxy.GetString("RECONNECT"), new ButtonClickEventHandler(this.OnReconnetButtonClicked), 300);
								this._try_reconnect_count--;
							}
							else
							{
								this.OnReconnectFailed();
							}
						}
					}
				}
				break;
			}
			case SocketState.State_Connecting:
			{
				bool flag6 = this.ConnectElapsed > this._connect_time_out;
				if (flag6)
				{
					this.Close(NetErrCode.Net_ConnectError);
				}
				else
				{
					bool flag7 = this.ConnectElapsed > this._connect_delay_notice_threshold;
					if (flag7)
					{
						this._is_connect_delay = true;
						XSingleton<XVirtualTab>.singleton.Cancel();
					}
				}
				break;
			}
			case SocketState.State_Connected:
				Rpc.CheckDelay();
				break;
			}
			bool onRpcTimeOutClosed = Rpc.OnRpcTimeOutClosed;
			if (onRpcTimeOutClosed)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("Rpc ", Rpc.delayRpcName + " delay closing...", null, null, null, null);
				this.Close(NetErrCode.Net_Rpc_Delay);
			}
		}

		// Token: 0x0600BD1A RID: 48410 RVA: 0x0027078C File Offset: 0x0026E98C
		private bool OnReconnetButtonClicked(IXUIButton button)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag = this.Connet(this._reconnect_ip, this._reconnect_port);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("START_RECONNECT"), "fece00");
				XSingleton<XDebug>.singleton.AddLog("reconnecting...", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			this._is_manually_reconnect_ui_bshow = false;
			return true;
		}

		// Token: 0x04004CF5 RID: 19701
		private readonly uint _buffer_size = 262140U;

		// Token: 0x04004CF6 RID: 19702
		private readonly float _connect_time_out = 5f;

		// Token: 0x04004CF7 RID: 19703
		private readonly float _connect_delay_notice_threshold = 0.5f;

		// Token: 0x04004CF8 RID: 19704
		private DateTime _last_connect_at = DateTime.Now;

		// Token: 0x04004CF9 RID: 19705
		private DateTime _reconnect_at = DateTime.Now;

		// Token: 0x04004CFA RID: 19706
		private CNetwork _network = null;

		// Token: 0x04004CFB RID: 19707
		private bool _reconnection_enabled = true;

		// Token: 0x04004CFC RID: 19708
		private bool _is_on_reconnection = false;

		// Token: 0x04004CFD RID: 19709
		private bool _is_manually_reconnection = false;

		// Token: 0x04004CFE RID: 19710
		private bool _is_manually_reconnect_ui_bshow = false;

		// Token: 0x04004CFF RID: 19711
		private bool _is_connect_delay = false;

		// Token: 0x04004D00 RID: 19712
		private string _reconnect_ip = null;

		// Token: 0x04004D01 RID: 19713
		private int _reconnect_port = 0;

		// Token: 0x04004D02 RID: 19714
		private int _try_reconnect_count = 0;
	}
}
