using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FE6 RID: 4070
	public sealed class XGameEntrance : IEntrance, IXInterface
	{
		// Token: 0x170036F4 RID: 14068
		// (get) Token: 0x0600D3B2 RID: 54194 RVA: 0x0031C508 File Offset: 0x0031A708
		// (set) Token: 0x0600D3B3 RID: 54195 RVA: 0x0031C510 File Offset: 0x0031A710
		public bool Deprecated { get; set; }

		// Token: 0x0600D3B4 RID: 54196 RVA: 0x0031C519 File Offset: 0x0031A719
		public static void Fire()
		{
			XSingleton<XInterfaceMgr>.singleton.AttachInterface<IEntrance>(0U, new XGameEntrance());
		}

		// Token: 0x0600D3B5 RID: 54197 RVA: 0x0031C530 File Offset: 0x0031A730
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

		// Token: 0x170036F5 RID: 14069
		// (get) Token: 0x0600D3B6 RID: 54198 RVA: 0x0031C640 File Offset: 0x0031A840
		public bool Awaked
		{
			get
			{
				return this._be_awaked;
			}
		}

		// Token: 0x0600D3B7 RID: 54199 RVA: 0x0031C658 File Offset: 0x0031A858
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

		// Token: 0x0600D3B8 RID: 54200 RVA: 0x0031C6C4 File Offset: 0x0031A8C4
		public void Start()
		{
			bool flag = !this._game.Init();
			if (flag)
			{
				Application.Quit();
			}
		}

		// Token: 0x0600D3B9 RID: 54201 RVA: 0x0031C6EC File Offset: 0x0031A8EC
		public void NetUpdate()
		{
			this._game.UpdateNetwork();
		}

		// Token: 0x0600D3BA RID: 54202 RVA: 0x0031C6FB File Offset: 0x0031A8FB
		public void PreUpdate()
		{
			this._game.PreUpdate(Time.deltaTime);
		}

		// Token: 0x0600D3BB RID: 54203 RVA: 0x0031C70F File Offset: 0x0031A90F
		public void Update()
		{
			this._game.Update(Time.deltaTime);
		}

		// Token: 0x0600D3BC RID: 54204 RVA: 0x0031C723 File Offset: 0x0031A923
		public void PostUpdate()
		{
			this._game.PostUpdate(Time.deltaTime);
		}

		// Token: 0x0600D3BD RID: 54205 RVA: 0x0031C738 File Offset: 0x0031A938
		public void Quit()
		{
			bool flag = this._game != null;
			if (flag)
			{
				this._game.Uninit();
				this._game = null;
			}
		}

		// Token: 0x0600D3BE RID: 54206 RVA: 0x0031C768 File Offset: 0x0031A968
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

		// Token: 0x0600D3BF RID: 54207 RVA: 0x0031C9B7 File Offset: 0x0031ABB7
		public void AuthorizationSignOut(string msg)
		{
			XSingleton<XLoginDocument>.singleton.OnAuthorizationSignOut(msg);
		}

		// Token: 0x0600D3C0 RID: 54208 RVA: 0x0031C9C6 File Offset: 0x0031ABC6
		public void SetQualityLevel(int level)
		{
			XQualitySetting.Init();
			XQualitySetting.SetQuality(level, true);
		}

		// Token: 0x0600D3C1 RID: 54209 RVA: 0x0031C9D7 File Offset: 0x0031ABD7
		public void FadeUpdate()
		{
			XAutoFade.PostUpdate();
		}

		// Token: 0x0600D3C2 RID: 54210 RVA: 0x0031C9E0 File Offset: 0x0031ABE0
		public void MonoObjectRegister(string key, MonoBehaviour behavior)
		{
			bool flag = behavior is IEnvSetting;
			if (flag)
			{
				XQualitySetting.SetEnvSet(behavior as IEnvSetting);
			}
		}

		// Token: 0x04006041 RID: 24641
		private XGame _game = null;

		// Token: 0x04006042 RID: 24642
		private IEnumerator _awake = null;

		// Token: 0x04006043 RID: 24643
		private bool _be_awaked = false;
	}
}
