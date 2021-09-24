using System;
using KKSG;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcT2C_LoginChallenge
	{

		public static void Process(PtcT2C_LoginChallenge roPtc)
		{
			bool onReconnect = XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect;
			if (onReconnect)
			{
				RpcC2T_Reconnect rpcC2T_Reconnect = new RpcC2T_Reconnect();
				rpcC2T_Reconnect.oArg.session = XSingleton<XClientNetwork>.singleton.Session;
				rpcC2T_Reconnect.oArg.sceneid = XSingleton<XScene>.singleton.SceneID;
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag)
				{
					rpcC2T_Reconnect.oArg.roleid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				}
				XSingleton<XClientNetwork>.singleton.Send(rpcC2T_Reconnect);
				XSingleton<XDebug>.singleton.AddLog("send Reconnect rpc.", null, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("receive challenge, start sync time.", null, null, null, null, null, XDebugColor.XDebug_None);
				bool flag2 = !string.IsNullOrEmpty(XSingleton<XClientNetwork>.singleton.XLoginToken);
				if (flag2)
				{
					RpcC2T_ClientLoginRequest rpcC2T_ClientLoginRequest = new RpcC2T_ClientLoginRequest();
					rpcC2T_ClientLoginRequest.oArg.token = Convert.FromBase64String(XSingleton<XClientNetwork>.singleton.XLoginToken);
					rpcC2T_ClientLoginRequest.oArg.gameserverid = XSingleton<XClientNetwork>.singleton.ServerID;
					rpcC2T_ClientLoginRequest.oArg.openid = XSingleton<XLoginDocument>.singleton.OpenID;
					rpcC2T_ClientLoginRequest.oArg.loginzoneid = XSingleton<XLoginDocument>.singleton.LoginZoneID;
					RuntimePlatform platform = Application.platform;
					if (platform != (RuntimePlatform)8)
					{
						if (platform != (RuntimePlatform)11)
						{
							rpcC2T_ClientLoginRequest.oArg.pc = "0.0.0";
						}
						else
						{
							rpcC2T_ClientLoginRequest.oArg.android = XSingleton<XUpdater.XUpdater>.singleton.Version;
							rpcC2T_ClientLoginRequest.oArg.clientInfo = new ClientInfo();
							rpcC2T_ClientLoginRequest.oArg.clientInfo.PlatID = XFastEnumIntEqualityComparer<PlatType>.ToInt(PlatType.PLAT_ANDROID);
							rpcC2T_ClientLoginRequest.oArg.clientInfo.ClientVersion = XSingleton<XUpdater.XUpdater>.singleton.Version;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.LoginChannel = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetChannelID();
							rpcC2T_ClientLoginRequest.oArg.clientInfo.pf = "openmobile_android";
							rpcC2T_ClientLoginRequest.oArg.clientInfo.starttype = XSingleton<XLoginDocument>.singleton.GetLaunchType();
							rpcC2T_ClientLoginRequest.oArg.clientInfo.logintype = XSingleton<XClientNetwork>.singleton.AccountType;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.token = XSingleton<XLoginDocument>.singleton.TokenCache;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.ScreenWidth = Screen.width;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.ScreenHight = Screen.height;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.DeviceId = SystemInfo.deviceUniqueIdentifier;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.SystemHardware = SystemInfo.deviceModel;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.SystemSoftware = SystemInfo.operatingSystem;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.Memory = SystemInfo.systemMemorySize;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.CpuHardware = SystemInfo.processorType + "-" + SystemInfo.processorCount;
							rpcC2T_ClientLoginRequest.oArg.clientInfo.Network = Application.internetReachability.ToString();
							rpcC2T_ClientLoginRequest.oArg.clientInfo.Density = (float)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetDensity();
							rpcC2T_ClientLoginRequest.oArg.clientInfo.TelecomOper = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetSim();
						}
					}
					else
					{
						rpcC2T_ClientLoginRequest.oArg.ios = XSingleton<XUpdater.XUpdater>.singleton.Version;
						rpcC2T_ClientLoginRequest.oArg.clientInfo = new ClientInfo();
						rpcC2T_ClientLoginRequest.oArg.clientInfo.PlatID = XFastEnumIntEqualityComparer<PlatType>.ToInt(PlatType.PLAT_IOS);
						rpcC2T_ClientLoginRequest.oArg.clientInfo.ClientVersion = XSingleton<XUpdater.XUpdater>.singleton.Version;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.LoginChannel = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetChannelID();
						rpcC2T_ClientLoginRequest.oArg.clientInfo.pf = "openmobile_ios";
						rpcC2T_ClientLoginRequest.oArg.clientInfo.starttype = XSingleton<XLoginDocument>.singleton.GetLaunchType();
						rpcC2T_ClientLoginRequest.oArg.clientInfo.logintype = XSingleton<XClientNetwork>.singleton.AccountType;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.token = XSingleton<XLoginDocument>.singleton.TokenCache;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.ScreenWidth = Screen.width;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.ScreenHight = Screen.height;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.DeviceId = SystemInfo.deviceUniqueIdentifier;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.SystemHardware = SystemInfo.deviceModel;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.SystemSoftware = SystemInfo.operatingSystem;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.Memory = SystemInfo.systemMemorySize;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.CpuHardware = SystemInfo.processorType + "-" + SystemInfo.processorCount;
						rpcC2T_ClientLoginRequest.oArg.clientInfo.Network = Application.internetReachability.ToString();
						rpcC2T_ClientLoginRequest.oArg.clientInfo.Density = (float)XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetDensity();
						rpcC2T_ClientLoginRequest.oArg.clientInfo.TelecomOper = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetSim();
					}
					XSingleton<XClientNetwork>.singleton.Send(rpcC2T_ClientLoginRequest);
				}
				XSingleton<XClientNetwork>.singleton.Session = roPtc.Data.session;
			}
		}
	}
}
