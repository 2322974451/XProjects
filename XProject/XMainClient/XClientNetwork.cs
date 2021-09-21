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
	// Token: 0x02000D86 RID: 3462
	internal class XClientNetwork : XSingleton<XClientNetwork>, INetObserver
	{
		// Token: 0x1700331C RID: 13084
		// (get) Token: 0x0600BCC6 RID: 48326 RVA: 0x0026EBAC File Offset: 0x0026CDAC
		// (set) Token: 0x0600BCC7 RID: 48327 RVA: 0x0026EBC4 File Offset: 0x0026CDC4
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

		// Token: 0x1700331D RID: 13085
		// (get) Token: 0x0600BCC8 RID: 48328 RVA: 0x0026EBDC File Offset: 0x0026CDDC
		public XConnection XConnect
		{
			get
			{
				return this._connection;
			}
		}

		// Token: 0x1700331E RID: 13086
		// (get) Token: 0x0600BCC9 RID: 48329 RVA: 0x0026EBF4 File Offset: 0x0026CDF4
		// (set) Token: 0x0600BCCA RID: 48330 RVA: 0x0026EC0C File Offset: 0x0026CE0C
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

		// Token: 0x1700331F RID: 13087
		// (get) Token: 0x0600BCCB RID: 48331 RVA: 0x0026EC18 File Offset: 0x0026CE18
		// (set) Token: 0x0600BCCC RID: 48332 RVA: 0x0026EC30 File Offset: 0x0026CE30
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

		// Token: 0x17003320 RID: 13088
		// (get) Token: 0x0600BCCD RID: 48333 RVA: 0x0026EC3C File Offset: 0x0026CE3C
		// (set) Token: 0x0600BCCE RID: 48334 RVA: 0x0026EC54 File Offset: 0x0026CE54
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

		// Token: 0x17003321 RID: 13089
		// (get) Token: 0x0600BCCF RID: 48335 RVA: 0x0026EC60 File Offset: 0x0026CE60
		// (set) Token: 0x0600BCD0 RID: 48336 RVA: 0x0026EC78 File Offset: 0x0026CE78
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

		// Token: 0x17003322 RID: 13090
		// (get) Token: 0x0600BCD1 RID: 48337 RVA: 0x0026EC84 File Offset: 0x0026CE84
		public string Server
		{
			get
			{
				return string.Format("{0} [{1}] ", this._serverName, this._zoneName);
			}
		}

		// Token: 0x17003323 RID: 13091
		// (get) Token: 0x0600BCD2 RID: 48338 RVA: 0x0026ECAC File Offset: 0x0026CEAC
		public uint ServerID
		{
			get
			{
				return this._server_id;
			}
		}

		// Token: 0x17003324 RID: 13092
		// (get) Token: 0x0600BCD3 RID: 48339 RVA: 0x0026ECC4 File Offset: 0x0026CEC4
		public string ServerIP
		{
			get
			{
				return this._server_ip;
			}
		}

		// Token: 0x17003325 RID: 13093
		// (get) Token: 0x0600BCD4 RID: 48340 RVA: 0x0026ECDC File Offset: 0x0026CEDC
		public uint ServerPort
		{
			get
			{
				return this._server_port;
			}
		}

		// Token: 0x17003326 RID: 13094
		// (get) Token: 0x0600BCD5 RID: 48341 RVA: 0x0026ECF4 File Offset: 0x0026CEF4
		public int RecvBytes
		{
			get
			{
				return this._network.RecvBytes;
			}
		}

		// Token: 0x17003327 RID: 13095
		// (get) Token: 0x0600BCD6 RID: 48342 RVA: 0x0026ED14 File Offset: 0x0026CF14
		public int SendBytes
		{
			get
			{
				return this._network.SendBytes;
			}
		}

		// Token: 0x17003328 RID: 13096
		// (get) Token: 0x0600BCD7 RID: 48343 RVA: 0x0026ED34 File Offset: 0x0026CF34
		public string OpenID
		{
			get
			{
				return this._openid;
			}
		}

		// Token: 0x17003329 RID: 13097
		// (get) Token: 0x0600BCD8 RID: 48344 RVA: 0x0026ED4C File Offset: 0x0026CF4C
		public string OpenKey
		{
			get
			{
				return XSingleton<XLoginDocument>.singleton.TokenCache;
			}
		}

		// Token: 0x1700332A RID: 13098
		// (get) Token: 0x0600BCD9 RID: 48345 RVA: 0x0026ED68 File Offset: 0x0026CF68
		public LoginType AccountType
		{
			get
			{
				return this._loginType;
			}
		}

		// Token: 0x1700332B RID: 13099
		// (get) Token: 0x0600BCDA RID: 48346 RVA: 0x0026ED80 File Offset: 0x0026CF80
		public string GameId
		{
			get
			{
				return "90";
			}
		}

		// Token: 0x1700332C RID: 13100
		// (get) Token: 0x0600BCDB RID: 48347 RVA: 0x0026ED98 File Offset: 0x0026CF98
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

		// Token: 0x1700332D RID: 13101
		// (get) Token: 0x0600BCDC RID: 48348 RVA: 0x0026EDD8 File Offset: 0x0026CFD8
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

		// Token: 0x1700332E RID: 13102
		// (get) Token: 0x0600BCDD RID: 48349 RVA: 0x0026EE18 File Offset: 0x0026D018
		public string MSDKKey
		{
			get
			{
				return "02a8d5ed226237996eb3f448dfac0b1c";
			}
		}

		// Token: 0x1700332F RID: 13103
		// (get) Token: 0x0600BCDE RID: 48350 RVA: 0x0026EE30 File Offset: 0x0026D030
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

		// Token: 0x17003330 RID: 13104
		// (get) Token: 0x0600BCDF RID: 48351 RVA: 0x0026EE80 File Offset: 0x0026D080
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

		// Token: 0x0600BCE0 RID: 48352 RVA: 0x0026EEFC File Offset: 0x0026D0FC
		public bool Initialize()
		{
			this._loginStep = XLoginStep.Begin;
			this._connection = new XConnection();
			this._network = this._connection.Init(this);
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<CNetwork>(XSingleton<XCommon>.singleton.XHash("ILUANET"), this._network);
			return this._network != null;
		}

		// Token: 0x0600BCE1 RID: 48353 RVA: 0x0026EF5C File Offset: 0x0026D15C
		public bool IsConnected()
		{
			return this._network.GetSocketState() == SocketState.State_Connected;
		}

		// Token: 0x0600BCE2 RID: 48354 RVA: 0x0026EF7C File Offset: 0x0026D17C
		public void ClearServerInfo()
		{
			this._server_id = 0U;
			this._server_ip = "";
			this._server_port = 0U;
			this._serverName = "";
			this._zoneName = "";
		}

		// Token: 0x0600BCE3 RID: 48355 RVA: 0x0026EFB0 File Offset: 0x0026D1B0
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

		// Token: 0x0600BCE4 RID: 48356 RVA: 0x0026EFFC File Offset: 0x0026D1FC
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

		// Token: 0x0600BCE5 RID: 48357 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnReceive(uint dwType, int nLen)
		{
		}

		// Token: 0x0600BCE6 RID: 48358 RVA: 0x0026F1C0 File Offset: 0x0026D3C0
		public void Send(Protocol proto)
		{
			bool flag = !this._network.Send(proto);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("send proto failed: ", proto.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600BCE7 RID: 48359 RVA: 0x0026F200 File Offset: 0x0026D400
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

		// Token: 0x0600BCE8 RID: 48360 RVA: 0x0026F250 File Offset: 0x0026D450
		public void LuaSendRPC(uint _type, byte[] _reqBuff, DelLuaRespond _onRes, DelLuaError _onError)
		{
			bool flag = !this._network.LuaSendRPC(_type, _reqBuff, _onRes, _onError);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("lua send rpc failed: ", _type.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600BCE9 RID: 48361 RVA: 0x0026F294 File Offset: 0x0026D494
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

		// Token: 0x0600BCEA RID: 48362 RVA: 0x0026F37C File Offset: 0x0026D57C
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

		// Token: 0x0600BCEB RID: 48363 RVA: 0x0026F50C File Offset: 0x0026D70C
		public bool Login()
		{
			return this.Connect(this._server_ip, (int)this._server_port);
		}

		// Token: 0x0600BCEC RID: 48364 RVA: 0x0026F530 File Offset: 0x0026D730
		public void OnLogin()
		{
			XSingleton<XOperationRecord>.singleton.DoScriptRecord("login");
		}

		// Token: 0x0600BCED RID: 48365 RVA: 0x0026F544 File Offset: 0x0026D744
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

		// Token: 0x0600BCEE RID: 48366 RVA: 0x0026F5AC File Offset: 0x0026D7AC
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

		// Token: 0x0600BCEF RID: 48367 RVA: 0x0026F608 File Offset: 0x0026D808
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

		// Token: 0x0600BCF0 RID: 48368 RVA: 0x0026F828 File Offset: 0x0026DA28
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

		// Token: 0x0600BCF1 RID: 48369 RVA: 0x0026F8D4 File Offset: 0x0026DAD4
		public bool Close(NetErrCode err = NetErrCode.Net_NoError)
		{
			return this._connection.Close(err);
		}

		// Token: 0x0600BCF2 RID: 48370 RVA: 0x0026F8F4 File Offset: 0x0026DAF4
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

		// Token: 0x0600BCF3 RID: 48371 RVA: 0x0026F98C File Offset: 0x0026DB8C
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

		// Token: 0x0600BCF4 RID: 48372 RVA: 0x0026FB34 File Offset: 0x0026DD34
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

		// Token: 0x0600BCF5 RID: 48373 RVA: 0x0026FB98 File Offset: 0x0026DD98
		public bool IsConnectSignal()
		{
			return Application.internetReachability > 0;
		}

		// Token: 0x0600BCF6 RID: 48374 RVA: 0x0026FBB4 File Offset: 0x0026DDB4
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

		// Token: 0x0600BCF7 RID: 48375 RVA: 0x0026FBE7 File Offset: 0x0026DDE7
		public void OnGamePause(bool pause)
		{
			this._network.OnGamePaused(pause);
		}

		// Token: 0x0600BCF8 RID: 48376 RVA: 0x0026FBF8 File Offset: 0x0026DDF8
		public void Clear()
		{
			Serializer.Clear();
			bool flag = this._network != null;
			if (flag)
			{
				this._network.Clear();
			}
		}

		// Token: 0x04004CD0 RID: 19664
		private CNetwork _network = null;

		// Token: 0x04004CD1 RID: 19665
		private ulong _session = 0UL;

		// Token: 0x04004CD2 RID: 19666
		private uint __server_id = 0U;

		// Token: 0x04004CD3 RID: 19667
		private string _server_ip = "";

		// Token: 0x04004CD4 RID: 19668
		private uint _server_port = 0U;

		// Token: 0x04004CD5 RID: 19669
		private string _serverName = "";

		// Token: 0x04004CD6 RID: 19670
		private string _zoneName = "";

		// Token: 0x04004CD7 RID: 19671
		private string _account;

		// Token: 0x04004CD8 RID: 19672
		private string _password;

		// Token: 0x04004CD9 RID: 19673
		private string _loginToken;

		// Token: 0x04004CDA RID: 19674
		private string _openid;

		// Token: 0x04004CDB RID: 19675
		private bool _close_on_server_error_ntf = false;

		// Token: 0x04004CDC RID: 19676
		private bool _rpc_delayed_ntf = false;

		// Token: 0x04004CDD RID: 19677
		private ErrorCode _last_error = ErrorCode.ERR_SUCCESS;

		// Token: 0x04004CDE RID: 19678
		private XLoginStep _loginStep = XLoginStep.Begin;

		// Token: 0x04004CDF RID: 19679
		private LoginType _loginType = LoginType.LOGIN_PASSWORD;

		// Token: 0x04004CE0 RID: 19680
		private XConnection _connection = null;
	}
}
