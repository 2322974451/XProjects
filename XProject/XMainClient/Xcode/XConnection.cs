using System;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XConnection
	{

		public bool OnConnectDelay
		{
			get
			{
				return this._is_connect_delay;
			}
		}

		public bool OnRpcDelay
		{
			get
			{
				return Rpc.OnRpcDelay;
			}
		}

		public bool OnReconnect
		{
			get
			{
				return this._is_on_reconnection;
			}
		}

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

		private float ConnectElapsed
		{
			get
			{
				return (float)DateTime.Now.Subtract(this._last_connect_at).TotalSeconds;
			}
		}

		private float ReconnectElapsed
		{
			get
			{
				return (float)DateTime.Now.Subtract(this._reconnect_at).TotalSeconds;
			}
		}

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

		public void OnReconnected()
		{
			this._is_on_reconnection = false;
			XSingleton<XDebug>.singleton.AddLog("Reconnected.", null, null, null, null, null, XDebugColor.XDebug_None);
			Rpc.delayRpcName = "";
		}

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

		public void StopReconnection()
		{
			bool is_on_reconnection = this._is_on_reconnection;
			if (is_on_reconnection)
			{
				this._is_on_reconnection = false;
			}
		}

		public SocketState GetSocketState()
		{
			return this._network.GetSocketState();
		}

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

		private readonly uint _buffer_size = 262140U;

		private readonly float _connect_time_out = 5f;

		private readonly float _connect_delay_notice_threshold = 0.5f;

		private DateTime _last_connect_at = DateTime.Now;

		private DateTime _reconnect_at = DateTime.Now;

		private CNetwork _network = null;

		private bool _reconnection_enabled = true;

		private bool _is_on_reconnection = false;

		private bool _is_manually_reconnection = false;

		private bool _is_manually_reconnect_ui_bshow = false;

		private bool _is_connect_delay = false;

		private string _reconnect_ip = null;

		private int _reconnect_port = 0;

		private int _try_reconnect_count = 0;
	}
}
