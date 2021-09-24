using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public sealed class XGameEntrance : IEntrance, IXInterface
	{

		public bool Deprecated { get; set; }

		public static void Fire()
		{
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IEntrance>(0U, new XGameEntrance());
		}

		public static void Test(Assembly ass)
		{
			Type[] types = ass.GetTypes();
			bool flag = types != null;
			if (flag)
			{
				MemoryStream memoryStream = new MemoryStream();
				foreach (Type type in types)
				{
					bool flag2 = type.IsSubclassOf(typeof(Protocol));
					if (flag2)
					{
						Protocol protocol = Activator.CreateInstance(type) as Protocol;
						bool flag3 = protocol != null;
						if (flag3)
						{
							memoryStream.SetLength(0L);
							memoryStream.Position = 0L;
							protocol.SerializeWithHead(memoryStream);
						}
					}
					else
					{
						bool flag4 = type.IsSubclassOf(typeof(Rpc));
						if (flag4)
						{
							Rpc rpc = Activator.CreateInstance(type) as Rpc;
							bool flag5 = rpc != null;
							if (flag5)
							{
								rpc.SocketID = 0;
								rpc.BeforeSend();
								memoryStream.SetLength(0L);
								memoryStream.Position = 0L;
								rpc.SerializeWithHead(memoryStream);
							}
						}
					}
				}
				memoryStream.Close();
			}
			else
			{
				Debug.Log("null types");
			}
		}

		public bool Awaked
		{
			get
			{
				return this._be_awaked;
			}
		}

		public void Awake()
		{
			bool flag = this._game == null;
			if (flag)
			{
				this._game = XSingleton<XGame>.singleton;
			}
			bool flag2 = this._awake == null;
			if (flag2)
			{
				this._awake = this._game.Awake();
			}
			else
			{
				bool flag3 = !this._awake.MoveNext();
				if (flag3)
				{
					this._awake = null;
					this._be_awaked = true;
				}
			}
		}

		public void Start()
		{
			bool flag = !this._game.Init();
			if (flag)
			{
				Application.Quit();
			}
		}

		public void NetUpdate()
		{
			this._game.UpdateNetwork();
		}

		public void PreUpdate()
		{
			this._game.PreUpdate(Time.deltaTime);
		}

		public void Update()
		{
			this._game.Update(Time.deltaTime);
		}

		public void PostUpdate()
		{
			this._game.PostUpdate(Time.deltaTime);
		}

		public void Quit()
		{
			bool flag = this._game != null;
			if (flag)
			{
				this._game.Uninit();
				this._game = null;
			}
		}

		public void Authorization(string token)
		{
			XSingleton<XDebug>.singleton.AddLog("[XGameEntrance.Authorization]", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = token != null && token != "";
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[XGameEntrance.Authorization] token = " + token, null, null, null, null, null, XDebugColor.XDebug_None);
				string[] array = Regex.Split(token, "__RXSN__", RegexOptions.None);
				bool flag2 = array.Length == 2;
				if (flag2)
				{
					XSingleton<XLoginDocument>.singleton.RefreshAccessToken(array[0]);
				}
				XRechargeDocument specificDocument = XDocuments.GetSpecificDocument<XRechargeDocument>(XRechargeDocument.uuID);
				bool flag3 = specificDocument != null;
				if (flag3)
				{
					specificDocument.PayParameterNtf();
				}
				XSingleton<XPandoraSDKDocument>.singleton.PandoraLogin();
			}
			bool authorized = XSingleton<XLoginDocument>.singleton.Authorized;
			if (!authorized)
			{
				switch (XSingleton<XLoginDocument>.singleton.Channel)
				{
				case XAuthorizationChannel.XAuthorization_SD:
					XSingleton<XLoginDocument>.singleton.OnAuthorization(token, "", "", XAuthorizationChannel.XAuthorization_SD);
					break;
				case XAuthorizationChannel.XAuthorization_QQ:
				{
					string[] array2 = Regex.Split(token, "__RXSN__", RegexOptions.None);
					bool flag4 = array2.Length < 2;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddLog("login token error!!!", null, null, null, null, null, XDebugColor.XDebug_None);
						XSingleton<XLoginDocument>.singleton.OnAuthorization("", "", "", XAuthorizationChannel.XAuthorization_QQ);
					}
					else
					{
						XSingleton<XLoginDocument>.singleton.OnAuthorization(array2[0], "", array2[1], XAuthorizationChannel.XAuthorization_QQ);
					}
					break;
				}
				case XAuthorizationChannel.XAuthorization_WeChat:
				{
					string[] array3 = Regex.Split(token, "__RXSN__", RegexOptions.None);
					bool flag5 = array3.Length < 2;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddLog("long token error!!!", null, null, null, null, null, XDebugColor.XDebug_None);
						XSingleton<XLoginDocument>.singleton.OnAuthorization("", "", "", XAuthorizationChannel.XAuthorization_WeChat);
					}
					else
					{
						XSingleton<XLoginDocument>.singleton.OnAuthorization(array3[0], "", array3[1], XAuthorizationChannel.XAuthorization_WeChat);
					}
					break;
				}
				case XAuthorizationChannel.XAuthorization_Guest:
				{
					string[] array4 = Regex.Split(token, "__RXSN__", RegexOptions.None);
					bool flag6 = array4.Length < 2;
					if (flag6)
					{
						XSingleton<XDebug>.singleton.AddLog("long token error!!!", null, null, null, null, null, XDebugColor.XDebug_None);
						XSingleton<XLoginDocument>.singleton.OnAuthorization("", "", "", XAuthorizationChannel.XAuthorization_Guest);
					}
					else
					{
						XSingleton<XLoginDocument>.singleton.OnAuthorization(array4[0], "", array4[1], XAuthorizationChannel.XAuthorization_Guest);
					}
					break;
				}
				}
			}
		}

		public void AuthorizationSignOut(string msg)
		{
			XSingleton<XLoginDocument>.singleton.OnAuthorizationSignOut(msg);
		}

		public void SetQualityLevel(int level)
		{
			XQualitySetting.Init();
			XQualitySetting.SetQuality(level, true);
		}

		public void FadeUpdate()
		{
			XAutoFade.PostUpdate();
		}

		public void MonoObjectRegister(string key, MonoBehaviour behavior)
		{
			bool flag = behavior is IEnvSetting;
			if (flag)
			{
				XQualitySetting.SetEnvSet(behavior as IEnvSetting);
			}
		}

		private XGame _game = null;

		private IEnumerator _awake = null;

		private bool _be_awaked = false;
	}
}
