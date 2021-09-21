using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B34 RID: 2868
	public class XLuaExtion : XSingleton<XLuaExtion>, ILuaExtion, IXInterface
	{
		// Token: 0x0600A7D9 RID: 42969 RVA: 0x001DD9A4 File Offset: 0x001DBBA4
		public void SetPlayerProprerty(string key, object value)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData != null;
			if (flag)
			{
				xplayerData.SetPublicProperty(key, value);
			}
		}

		// Token: 0x0600A7DA RID: 42970 RVA: 0x001DD9D0 File Offset: 0x001DBBD0
		public object GetPlayeProprerty(string key)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			return xplayerData.GetPublicProperty(key);
		}

		// Token: 0x0600A7DB RID: 42971 RVA: 0x001DD9F4 File Offset: 0x001DBBF4
		public object CallPlayerMethod(bool isPublic, string method, params object[] args)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			return this.CallMethod(xplayerData, isPublic, method, args);
		}

		// Token: 0x0600A7DC RID: 42972 RVA: 0x001DDA1C File Offset: 0x001DBC1C
		public object GetDocument(string doc)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			return XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
		}

		// Token: 0x0600A7DD RID: 42973 RVA: 0x001DDA4C File Offset: 0x001DBC4C
		public object GetDocumentMember(string doc, string key, bool isPublic, bool isField)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			return this.GetMember(xcomponent, isField, isPublic, key);
		}

		// Token: 0x0600A7DE RID: 42974 RVA: 0x001DDA88 File Offset: 0x001DBC88
		public object GetDocumentStaticMember(string doc, string key, bool isPublic, bool isField)
		{
			return this.GetStaticMember("XMainClient." + doc, key, isPublic, isField);
		}

		// Token: 0x0600A7DF RID: 42975 RVA: 0x001DDAB0 File Offset: 0x001DBCB0
		public void SetDocumentMember(string doc, string key, object value, bool isPublic, bool isField)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			this.SetMember(xcomponent, isField, isPublic, key, value);
		}

		// Token: 0x0600A7E0 RID: 42976 RVA: 0x001DDAEC File Offset: 0x001DBCEC
		public object CallDocumentMethod(string doc, bool isPublic, string method, params object[] args)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			return this.CallMethod(xcomponent, isPublic, method, args);
		}

		// Token: 0x0600A7E1 RID: 42977 RVA: 0x001DDB28 File Offset: 0x001DBD28
		public object CallDocumentStaticMethod(string doc, bool isPublic, string method, params object[] args)
		{
			return this.CallStaticMethod("XMainClient." + doc, isPublic, method, args);
		}

		// Token: 0x0600A7E2 RID: 42978 RVA: 0x001DDB50 File Offset: 0x001DBD50
		public object GetSingle(string className)
		{
			return PublicExt.GetStaticPublicProperty("XMainClient." + className, "singleton");
		}

		// Token: 0x0600A7E3 RID: 42979 RVA: 0x001DDB78 File Offset: 0x001DBD78
		public object GetSingleMember(string className, string key, bool isPublic, bool isField, bool isStatic)
		{
			object result;
			if (isStatic)
			{
				result = this.GetStaticMember("XMainClient." + className, key, isPublic, isField);
			}
			else
			{
				object staticPublicProperty = PublicExt.GetStaticPublicProperty("XMainClient." + className, "singleton");
				result = this.GetMember(staticPublicProperty, isField, isPublic, key);
			}
			return result;
		}

		// Token: 0x0600A7E4 RID: 42980 RVA: 0x001DDBCC File Offset: 0x001DBDCC
		public void SetSingleMember(string className, string key, object value, bool isPublic, bool isField, bool isStatic)
		{
			if (isStatic)
			{
				this.SetStaticMember("XMainClient." + className, isField, isPublic, key, value);
			}
			else
			{
				object staticPublicProperty = PublicExt.GetStaticPublicProperty("XMainClient." + className, "singleton");
				this.SetMember(staticPublicProperty, isField, isPublic, key, value);
			}
		}

		// Token: 0x0600A7E5 RID: 42981 RVA: 0x001DDC24 File Offset: 0x001DBE24
		public object CallSingleMethod(string className, bool isPublic, bool isStatic, string methodName, params object[] args)
		{
			object result;
			if (isStatic)
			{
				result = this.CallStaticMethod("XMainClient." + className, isPublic, methodName, args);
			}
			else
			{
				object staticPublicProperty = PublicExt.GetStaticPublicProperty("XMainClient." + className, "singleton");
				result = this.CallMethod(staticPublicProperty, isPublic, methodName, args);
			}
			return result;
		}

		// Token: 0x0600A7E6 RID: 42982 RVA: 0x001DDC78 File Offset: 0x001DBE78
		private object GetMember(object o, bool isField, bool isPublic, string key)
		{
			object result;
			if (isPublic)
			{
				if (isField)
				{
					result = o.GetPublicField(key);
				}
				else
				{
					result = o.GetPublicProperty(key);
				}
			}
			else if (isField)
			{
				result = o.GetPrivateField(key);
			}
			else
			{
				result = o.GetPrivateProperty(key);
			}
			return result;
		}

		// Token: 0x0600A7E7 RID: 42983 RVA: 0x001DDCC4 File Offset: 0x001DBEC4
		private object GetStaticMember(string className, string key, bool isPublic, bool isField)
		{
			object result;
			if (isPublic)
			{
				if (isField)
				{
					result = PublicExt.GetStaticPublicField(className, key);
				}
				else
				{
					result = PublicExt.GetStaticPublicProperty(className, key);
				}
			}
			else if (isField)
			{
				result = PrivateExt.GetStaticPrivateField(className, key);
			}
			else
			{
				result = PrivateExt.GetStaticPrivateProperty(className, key);
			}
			return result;
		}

		// Token: 0x0600A7E8 RID: 42984 RVA: 0x001DDD10 File Offset: 0x001DBF10
		private void SetMember(object o, bool isField, bool isPublic, string key, object value)
		{
			if (isPublic)
			{
				if (isField)
				{
					o.SetPublicField(key, value);
				}
				else
				{
					o.SetPublicProperty(key, value);
				}
			}
			else if (isField)
			{
				o.SetPrivateField(key, value);
			}
			else
			{
				o.SetPrivateProperty(key, value);
			}
		}

		// Token: 0x0600A7E9 RID: 42985 RVA: 0x001DDD64 File Offset: 0x001DBF64
		private void SetStaticMember(string className, bool isField, bool isPublic, string key, object value)
		{
			if (isPublic)
			{
				if (isField)
				{
					PublicExt.SetStaticPublicField(className, key, value);
				}
				else
				{
					PublicExt.SetStaticPublicProperty(className, key, value);
				}
			}
			else if (isField)
			{
				PrivateExt.SetStaticPrivateField(className, key, value);
			}
			else
			{
				PrivateExt.SetStaticPrivateProperty(className, key, value);
			}
		}

		// Token: 0x0600A7EA RID: 42986 RVA: 0x001DDDB8 File Offset: 0x001DBFB8
		private object CallStaticMethod(string className, bool isPublic, string methodName, params object[] args)
		{
			object result;
			if (isPublic)
			{
				result = PublicExt.CallStaticPublicMethod(className, methodName, args);
			}
			else
			{
				result = PrivateExt.CallStaticPrivateMethod(className, methodName, args);
			}
			return result;
		}

		// Token: 0x0600A7EB RID: 42987 RVA: 0x001DDDE8 File Offset: 0x001DBFE8
		private object CallMethod(object o, bool isPublic, string methodName, params object[] args)
		{
			object result;
			if (isPublic)
			{
				result = o.CallPublicMethod(methodName, args);
			}
			else
			{
				result = o.CallPrivateMethod(methodName, args);
			}
			return result;
		}

		// Token: 0x0600A7EC RID: 42988 RVA: 0x001DDE18 File Offset: 0x001DC018
		public Type GetType(string classname)
		{
			return Type.GetType("XMainClient." + classname);
		}

		// Token: 0x0600A7ED RID: 42989 RVA: 0x001DDE3C File Offset: 0x001DC03C
		public object GetEnumType(string classname, string value)
		{
			return Enum.Parse(this.GetType(classname), value);
		}

		// Token: 0x0600A7EE RID: 42990 RVA: 0x001DDE5C File Offset: 0x001DC05C
		public void RefreshPlayerName()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = player != null && player.BillBoard != null;
			if (flag)
			{
				player.BillBoard.Attached();
			}
		}

		// Token: 0x0600A7EF RID: 42991 RVA: 0x001DDE98 File Offset: 0x001DC098
		public string GetStringTable(string key, params object[] args)
		{
			return XStringDefineProxy.GetString(key, args);
		}

		// Token: 0x0600A7F0 RID: 42992 RVA: 0x001DDEB4 File Offset: 0x001DC0B4
		public string GetGlobalString(string key)
		{
			return XSingleton<XGlobalConfig>.singleton.GetValue(key);
		}

		// Token: 0x0600A7F1 RID: 42993 RVA: 0x001DDED4 File Offset: 0x001DC0D4
		public XLuaLong Get(string str)
		{
			return new XLuaLong(str);
		}

		// Token: 0x17003016 RID: 12310
		// (get) Token: 0x0600A7F2 RID: 42994 RVA: 0x001DDEEC File Offset: 0x001DC0EC
		// (set) Token: 0x0600A7F3 RID: 42995 RVA: 0x001DDEF4 File Offset: 0x001DC0F4
		public bool Deprecated { get; set; }
	}
}
