using System;
using System.Text;
using KKSG;
using ProtoBuf;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XClientNetwork : XSingleton<XClientNetwork>, INetObserver
	{

		private uint _server_id
		{
			get
			{
				return this.__server_id;
			}
			set
			{
				this.__server_id = value;
				XFileLog.ServerID = value.ToString();
			}
		}

		public XConnection XConnect
		{
			get
			{
				return this._connection;
			}
		}

		public bool CloseOnServerErrorNtf
		{
			get
			{
				return this._close_on_server_error_ntf;
			}
			set
			{
				this._close_on_server_error_ntf = value;
			}
		}

		public ulong Session
		{
			get
			{
				return this._session;
			}
			set
			{
				this._session = value;
			}
		}

		public string XLoginToken
		{
			get
			{
				return this._loginToken;
			}
			set
			{
				this._loginToken = value;
			}
		}

		public XLoginStep XLoginStep
		{
			get
			{
				return this._loginStep;
			}
			set
			{
				this._loginStep = value;
			}
		}

		public string Server
		{
			get
			{
				return string.Format("{0} [{1}] ", this._serverName, this._zoneName);
			}
		}

		public uint ServerID
		{
			get
			{
				return this._server_id;
			}
		}

		public string ServerIP
		{
			get
			{
				return this._server_ip;
			}
		}

		public uint ServerPort
		{
			get
			{
				return this._server_port;
			}
		}

		public int RecvBytes
		{
			get
			{
				return this._network.RecvBytes;
			}
		}

		public int SendBytes
		{
			get
			{
				return this._network.SendBytes;
			}
		}

		public string OpenID
		{
			get
			{
				return this._openid;
			}
		}

		public string OpenKey
		{
			get
			{
				return XSingleton<XLoginDocument>.singleton.TokenCache;
			}
		}

		public LoginType AccountType
		{
			get
			{
				return this._loginType;
			}
		}

		public string GameId
		{
			get
			{
				return "90";
			}
		}

		public string AppId
		{
			get
			{
				bool flag = this.AccountType == LoginType.LOGIN_QQ_PF;
				string result;
				if (flag)
				{
					result = "1105309683";
				}
				else
				{
					bool flag2 = this.AccountType == LoginType.LGOIN_WECHAT_PF;
					if (flag2)
					{
						result = "wxfdab5af74990787a";
					}
					else
					{
						result = null;
					}
				}
				return result;
			}
		}

		public string AppKey
		{
			get
			{
				bool flag = this.AccountType == LoginType.LOGIN_QQ_PF;
				string result;
				if (flag)
				{
					result = "xa0seqAScOhSsgrm";
				}
				else
				{
					bool flag2 = this.AccountType == LoginType.LGOIN_WECHAT_PF;
					if (flag2)
					{
						result = "6dea891b19634f98e78d27edc74125bf";
					}
					else
					{
						result = null;
					}
				}
				return result;
			}
		}

		public string MSDKKey
		{
			get
			{
				return "02a8d5ed226237996eb3f448dfac0b1c";
			}
		}

		public string AreaId
		{
			get
			{
				bool flag = this.AccountType == LoginType.LOGIN_QQ_PF;
				string result;
				if (flag)
				{
					result = XFastEnumIntEqualityComparer<GameAppType>.ToInt(GameAppType.GAME_APP_QQ).ToString();
				}
				else
				{
					bool flag2 = this.AccountType == LoginType.LGOIN_WECHAT_PF;
					if (flag2)
					{
						result = XFastEnumIntEqualityComparer<GameAppType>.ToInt(GameAppType.GAME_APP_WECHAT).ToString();
					}
					else
					{
						result = null;
					}
				}
				return result;
			}
		}

		public string OpenCode
		{
			get
			{
				string text = null;
				bool flag = this.AccountType == LoginType.LOGIN_QQ_PF;
				if (flag)
				{
					text = "1";
				}
				bool flag2 = this.AccountType == LoginType.LGOIN_WECHAT_PF;
				if (flag2)
				{
					text = "2";
				}
				byte[] bytes = Encoding.Default.GetBytes(string.Format("{0},{1},{2},{3}", new object[]
				{
					this.OpenID,
					this.OpenKey,
					this.AppId,
					text
				}));
				return Convert.ToBase64String(bytes);
			}
		}

		public bool Initialize()
		{
			this._loginStep = XLoginStep.Begin;
			this._connection = new XConnection();
			this._network = this._connection.Init(this);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<CNetwork>(XSingleton<XCommon>.singleton.XHash("ILUANET"), this._network);
			return this._network != null;
		}

		public bool IsConnected()
		{
			return this._network.GetSocketState() == SocketState.State_Connected;
		}

		public void ClearServerInfo()
		{
			this._server_id = 0U;
			this._server_ip = "";
			this._server_port = 0U;
			this._serverName = "";
			this._zoneName = "";
		}

		public void OnConnect(bool bSuccess)
		{
			XSingleton<XDebug>.singleton.AddLog("Connection status: ", bSuccess ? "Connected" : "Disconnected", null, null, null, null, XDebugColor.XDebug_None);
			if (bSuccess)
			{
				this.OnConnected();
			}
			else
			{
				this.OnDisconnected();
			}
		}

		public void OnClosed(NetErrCode nErrCode)
		{
			XSingleton<XDebug>.singleton.AddLog("Closed with: ", nErrCode.ToString(), " in state ", this._loginStep.ToString(), null, null, XDebugColor.XDebug_None);
			bool flag = nErrCode == NetErrCode.Net_ConnectError;
			if (flag)
			{
				this.OnConnect(false);
			}
			else
			{
				bool flag2 = nErrCode == NetErrCode.Net_NoError;
				if (!flag2)
				{
					switch (this._loginStep)
					{
					case XLoginStep.Authorization:
					{
						NetErrCode netErrCode = nErrCode;
						if (netErrCode != NetErrCode.Net_Rpc_Delay)
						{
							XSingleton<XLoginDocument>.singleton.OnAuthorizedFailed();
						}
						else
						{
							XSingleton<XLoginDocument>.singleton.OnAuthorizedTimeOut();
						}
						break;
					}
					case XLoginStep.Login:
					{
						NetErrCode netErrCode2 = nErrCode;
						if (netErrCode2 != NetErrCode.Net_Rpc_Delay)
						{
							XSingleton<XLoginDocument>.singleton.OnLoginFailed(null);
						}
						else
						{
							XSingleton<XLoginDocument>.singleton.OnLoginTimeout();
						}
						break;
					}
					case XLoginStep.EnterGame:
					{
						NetErrCode netErrCode3 = nErrCode;
						if (netErrCode3 != NetErrCode.Net_SysError)
						{
							if (netErrCode3 != NetErrCode.Net_Rpc_Delay)
							{
								XSingleton<XLoginDocument>.singleton.OnEnterWorldFailed(null);
							}
							else
							{
								XSingleton<XLoginDocument>.singleton.OnEnterWorldTimeOut();
							}
						}
						else
						{
							this.OnServerErrorNotify(105U, null);
						}
						break;
					}
					case XLoginStep.Playing:
					{
						NetErrCode netErrCode4 = nErrCode;
						if (netErrCode4 != NetErrCode.Net_SysError)
						{
							if (netErrCode4 - NetErrCode.Net_Rpc_Delay <= 1)
							{
								bool flag3 = !this._connection.OnReconnect;
								if (flag3)
								{
									this._connection.Reconnect(this._server_ip, (int)this._server_port);
								}
							}
						}
						else
						{
							bool flag4 = !this._connection.OnReconnect;
							if (flag4)
							{
								bool flag5 = !this._close_on_server_error_ntf;
								if (flag5)
								{
									this._connection.Reconnect(this._server_ip, (int)this._server_port);
								}
								this._close_on_server_error_ntf = false;
							}
						}
						break;
					}
					}
				}
			}
		}

		public void OnReceive(uint dwType, int nLen)
		{
		}

		public void Send(Protocol proto)
		{
			bool flag = !this._network.Send(proto);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("send proto failed: ", proto.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		public void Send(Rpc rpc)
		{
			rpc.SetTimeOut();
			bool flag = !this._network.Send(rpc);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("send rpc failed: ", rpc.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				rpc.CallTimeOut();
			}
		}

		public void LuaSendRPC(uint _type, byte[] _reqBuff, DelLuaRespond _onRes, DelLuaError _onError)
		{
			bool flag = !this._network.LuaSendRPC(_type, _reqBuff, _onRes, _onError);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("lua send rpc failed: ", _type.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		public bool Authorization(LoginType t, string account, string password, string openid)
		{
			this._loginStep = XLoginStep.Authorization;
			this._loginType = t;
			this._account = account;
			this._password = password;
			this._openid = openid;
			string loginServerAddress;
			switch (this._loginType)
			{
			case LoginType.LOGIN_QQ_PF:
				loginServerAddress = XSingleton<XCaching>.singleton.GetLoginServerAddress("QQ");
				break;
			case LoginType.LGOIN_WECHAT_PF:
				loginServerAddress = XSingleton<XCaching>.singleton.GetLoginServerAddress("WeChat");
				break;
			case LoginType.LOGIN_IOS_GUEST:
				loginServerAddress = XSingleton<XCaching>.singleton.GetLoginServerAddress("Guest");
				break;
			default:
				loginServerAddress = XSingleton<XCaching>.singleton.GetLoginServerAddress("");
				break;
			}
			string text = loginServerAddress.Substring(0, loginServerAddress.LastIndexOf(':'));
			string text2 = loginServerAddress.Substring(loginServerAddress.LastIndexOf(':') + 1);
			XSingleton<XDebug>.singleton.AddLog("login server ", text, " : ", text2, null, null, XDebugColor.XDebug_None);
			return this.Connect(text, int.Parse(text2));
		}

		public bool OnAuthorized(QueryGateArg arg, QueryGateRes res)
		{
			bool result = false;
			try
			{
				bool flag = res.loginToken.Length != 0;
				if (flag)
				{
					this._loginStep = XLoginStep.Login;
					LoginGateData recommandGate = res.RecommandGate;
					XSingleton<XDebug>.singleton.AddLog("query gate ok [", recommandGate.ip, ":", recommandGate.port.ToString(), "] server ", recommandGate.serverid.ToString(), XDebugColor.XDebug_None);
					bool flag2 = string.IsNullOrEmpty(this._server_ip);
					if (flag2)
					{
						this._server_id = (uint)recommandGate.serverid;
						this._server_ip = recommandGate.ip;
						this._server_port = (uint)recommandGate.port;
						this._serverName = recommandGate.servername;
						this._zoneName = recommandGate.zonename;
					}
					bool flag3 = res.loginToken.Length >= 24 && res.loginToken[20] == 1;
					if (flag3)
					{
						XSingleton<XGame>.singleton.IsGMAccount = true;
						XSingleton<XDebug>.singleton.AddGreenLog("GM account Authorized", null, null, null, null, null);
					}
					else
					{
						XSingleton<XGame>.singleton.IsGMAccount = false;
					}
					this._loginToken = Convert.ToBase64String(res.loginToken);
					result = true;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("query gate ip failed!", null, null, null, null, null, XDebugColor.XDebug_None);
					result = false;
				}
			}
			catch (Exception ex)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, null, null, null, null, null);
				return false;
			}
			this.Close(NetErrCode.Net_NoError);
			return result;
		}

		public bool Login()
		{
			return this.Connect(this._server_ip, (int)this._server_port);
		}

		public void OnLogin()
		{
			XSingleton<XOperationRecord>.singleton.DoScriptRecord("login");
		}

		public bool OnServerChanged(ServerInfo data)
		{
			bool flag = this._server_id == (uint)data.ServerID;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._zoneName = data.ZoneName;
				this._serverName = data.ServerName;
				this._server_id = (uint)data.ServerID;
				this._server_ip = data.Ip;
				this._server_port = data.Port;
				result = true;
			}
			return result;
		}

		public void OnFatalErrorCallback()
		{
			bool flag = this._loginStep == XLoginStep.Playing && XSingleton<XCutScene>.singleton.IsPlaying;
			if (flag)
			{
				XSingleton<XCutScene>.singleton.Stop(true);
			}
			XSingleton<XLoginDocument>.singleton.OnError(null);
			bool flag2 = this._last_error == ErrorCode.ERR_VERSION_FAILED;
			if (flag2)
			{
				Application.Quit();
			}
		}

		public void OnServerErrorNotify(uint code, string addtional = null)
		{
			this._last_error = (ErrorCode)code;
			XLoginStep loginStep = this._loginStep;
			if (loginStep != XLoginStep.Playing)
			{
				bool flag = this._last_error == ErrorCode.ERR_VERSION_FAILED;
				if (flag)
				{
					bool sceneReady = XSingleton<XScene>.singleton.SceneReady;
					if (sceneReady)
					{
						string[] array = XSingleton<XUpdater.XUpdater>.singleton.Version.Split(new char[]
						{
							'.'
						});
						string[] array2 = addtional.Split(new char[]
						{
							'.'
						});
						bool flag2 = array.Length > 1 && array2.Length > 1;
						if (flag2)
						{
							bool flag3 = array[1] == array2[1];
							if (flag3)
							{
								XSingleton<UiUtility>.singleton.OnFatalErrorClosed(string.Format(XStringDefineProxy.GetString(ErrorCode.ERR_VERSION_FAILED), addtional));
							}
							else
							{
								bool flag4 = int.Parse(array[1]) < int.Parse(array2[1]);
								if (flag4)
								{
									XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NEED_TO_DOWNLOAD_CORRECT_PACKAGE"), XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<UiUtility>.singleton.ToDownLoadCorrectPackage), 300);
								}
								else
								{
									XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("NEED_TO_DOWNLOAD_CORRECT_PACKAGE"), XStringDefineProxy.GetString("COMMON_OK"), new ButtonClickEventHandler(XSingleton<UiUtility>.singleton.ToDownLoadCorrectPackagePre), 300);
								}
							}
						}
						else
						{
							XSingleton<UiUtility>.singleton.OnFatalErrorClosed(string.Format(XStringDefineProxy.GetString(ErrorCode.ERR_VERSION_FAILED), addtional));
						}
					}
					else
					{
						XSingleton<XScene>.singleton.Error = this._last_error;
						XSingleton<XScene>.singleton.ErrorAddtional = addtional;
					}
					XSingleton<XLoginDocument>.singleton.OnError();
				}
				else
				{
					string @string = XStringDefineProxy.GetString(this._last_error);
					XSingleton<XLoginDocument>.singleton.OnError(@string);
				}
				this.Close(NetErrCode.Net_NoError);
			}
			else
			{
				this._connection.StopReconnection();
				this._close_on_server_error_ntf = !this.Close(NetErrCode.Net_SrvNtfError);
				bool sceneReady2 = XSingleton<XScene>.singleton.SceneReady;
				if (sceneReady2)
				{
					XSingleton<UiUtility>.singleton.OnFatalErrorClosed(this._last_error);
				}
				else
				{
					XSingleton<XScene>.singleton.Error = this._last_error;
				}
			}
		}

		private bool Connect(string IP, int Port)
		{
			bool flag = this._connection.Connet(IP, Port);
			XLoginStep loginStep = this._loginStep;
			if (loginStep != XLoginStep.Authorization)
			{
				if (loginStep == XLoginStep.Login)
				{
					bool flag2 = flag;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddLog("connecting to gate server.", null, null, null, null, null, XDebugColor.XDebug_None);
					}
					else
					{
						XSingleton<XDebug>.singleton.AddErrorLog("connect to gate server failed!", null, null, null, null, null);
					}
				}
			}
			else
			{
				bool flag3 = flag;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddLog("connecting to login/authorization server.", null, null, null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("connect to login/authorization server failed!", null, null, null, null, null);
				}
			}
			return flag;
		}

		public bool Close(NetErrCode err = NetErrCode.Net_NoError)
		{
			return this._connection.Close(err);
		}

		public void Update()
		{
			this._connection.Update();
			this._network.ProcessMsg();
			XSingleton<XGameUI>.singleton.UpdateNetUI();
			bool onRpcDelay = this._connection.OnRpcDelay;
			if (onRpcDelay)
			{
				bool flag = !this._rpc_delayed_ntf && Rpc.RpcDelayedTime > Rpc.DelayThreshold + 1f && this._loginStep == XLoginStep.Playing;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CHECKING_NETWORK"), "fece00");
					this._rpc_delayed_ntf = true;
				}
			}
			else
			{
				this._rpc_delayed_ntf = false;
			}
		}

		private void OnConnected()
		{
			XLoginStep loginStep = this._loginStep;
			if (loginStep == XLoginStep.Authorization)
			{
				RpcC2I_QueryGateIP rpcC2I_QueryGateIP = new RpcC2I_QueryGateIP();
				rpcC2I_QueryGateIP.oArg.type = this._loginType;
				rpcC2I_QueryGateIP.oArg.platid = PlatType.PLAT_ANDROID;
				rpcC2I_QueryGateIP.oArg.version = XSingleton<XUpdater.XUpdater>.singleton.Version;
				RuntimePlatform platform = Application.platform;
				if (platform != (RuntimePlatform)8)
				{
					if (platform == (RuntimePlatform)11)
					{
						rpcC2I_QueryGateIP.oArg.platid = PlatType.PLAT_ANDROID;
					}
				}
				else
				{
					rpcC2I_QueryGateIP.oArg.platid = PlatType.PLAT_IOS;
				}
				switch (this._loginType)
				{
				case LoginType.LOGIN_PASSWORD:
					rpcC2I_QueryGateIP.oArg.account = this._account;
					rpcC2I_QueryGateIP.oArg.password = this._password;
					rpcC2I_QueryGateIP.oArg.openid = this._openid;
					goto IL_18D;
				case LoginType.LOGIN_QQ_PF:
					rpcC2I_QueryGateIP.oArg.token = this._account;
					rpcC2I_QueryGateIP.oArg.openid = this._openid;
					goto IL_18D;
				case LoginType.LGOIN_WECHAT_PF:
					rpcC2I_QueryGateIP.oArg.token = this._account;
					rpcC2I_QueryGateIP.oArg.openid = this._openid;
					goto IL_18D;
				case LoginType.LOGIN_IOS_GUEST:
					rpcC2I_QueryGateIP.oArg.token = this._account;
					rpcC2I_QueryGateIP.oArg.openid = this._openid;
					goto IL_18D;
				}
				rpcC2I_QueryGateIP.oArg.token = this._account;
				rpcC2I_QueryGateIP.oArg.pf = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetPFToken();
				IL_18D:
				this.Send(rpcC2I_QueryGateIP);
			}
		}

		private void OnDisconnected()
		{
			switch (this._loginStep)
			{
			case XLoginStep.Begin:
			case XLoginStep.Authorization:
				XSingleton<XLoginDocument>.singleton.OnAuthorizedConnectFailed();
				break;
			case XLoginStep.Login:
				XSingleton<XLoginDocument>.singleton.OnLoginConnectFailed();
				break;
			case XLoginStep.EnterGame:
				XSingleton<XLoginDocument>.singleton.OnEnterWorldFailed(XStringDefineProxy.GetString("CONNECT_SERVER_FAIL"));
				break;
			}
		}

		public bool IsConnectSignal()
		{
			return Application.internetReachability > 0;
		}

		public bool IsWifiEnable()
		{
			bool flag = Application.internetReachability == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = Application.internetReachability == (NetworkReachability)2;
				result = flag2;
			}
			return result;
		}

		public void OnGamePause(bool pause)
		{
			this._network.OnGamePaused(pause);
		}

		public void Clear()
		{
			Serializer.Clear();
			bool flag = this._network != null;
			if (flag)
			{
				this._network.Clear();
			}
		}

		private CNetwork _network = null;

		private ulong _session = 0UL;

		private uint __server_id = 0U;

		private string _server_ip = "";

		private uint _server_port = 0U;

		private string _serverName = "";

		private string _zoneName = "";

		private string _account;

		private string _password;

		private string _loginToken;

		private string _openid;

		private bool _close_on_server_error_ntf = false;

		private bool _rpc_delayed_ntf = false;

		private ErrorCode _last_error = ErrorCode.ERR_SUCCESS;

		private XLoginStep _loginStep = XLoginStep.Begin;

		private LoginType _loginType = LoginType.LOGIN_PASSWORD;

		private XConnection _connection = null;
	}
}
