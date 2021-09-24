using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XLuaExtion : XSingleton<XLuaExtion>, ILuaExtion, IXInterface
	{

		public void SetPlayerProprerty(string key, object value)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData != null;
			if (flag)
			{
				xplayerData.SetPublicProperty(key, value);
			}
		}

		public object GetPlayeProprerty(string key)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			return xplayerData.GetPublicProperty(key);
		}

		public object CallPlayerMethod(bool isPublic, string method, params object[] args)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			return this.CallMethod(xplayerData, isPublic, method, args);
		}

		public object GetDocument(string doc)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			return XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
		}

		public object GetDocumentMember(string doc, string key, bool isPublic, bool isField)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			return this.GetMember(xcomponent, isField, isPublic, key);
		}

		public object GetDocumentStaticMember(string doc, string key, bool isPublic, bool isField)
		{
			return this.GetStaticMember("XMainClient." + doc, key, isPublic, isField);
		}

		public void SetDocumentMember(string doc, string key, object value, bool isPublic, bool isField)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			this.SetMember(xcomponent, isField, isPublic, key, value);
		}

		public object CallDocumentMethod(string doc, bool isPublic, string method, params object[] args)
		{
			uint uuid = XSingleton<XCommon>.singleton.XHash(doc);
			XComponent xcomponent = XSingleton<XGame>.singleton.Doc.GetXComponent(uuid);
			return this.CallMethod(xcomponent, isPublic, method, args);
		}

		public object CallDocumentStaticMethod(string doc, bool isPublic, string method, params object[] args)
		{
			return this.CallStaticMethod("XMainClient." + doc, isPublic, method, args);
		}

		public object GetSingle(string className)
		{
			return PublicExt.GetStaticPublicProperty("XMainClient." + className, "singleton");
		}

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

		public Type GetType(string classname)
		{
			return Type.GetType("XMainClient." + classname);
		}

		public object GetEnumType(string classname, string value)
		{
			return Enum.Parse(this.GetType(classname), value);
		}

		public void RefreshPlayerName()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = player != null && player.BillBoard != null;
			if (flag)
			{
				player.BillBoard.Attached();
			}
		}

		public string GetStringTable(string key, params object[] args)
		{
			return XStringDefineProxy.GetString(key, args);
		}

		public string GetGlobalString(string key)
		{
			return XSingleton<XGlobalConfig>.singleton.GetValue(key);
		}

		public XLuaLong Get(string str)
		{
			return new XLuaLong(str);
		}

		public bool Deprecated { get; set; }
	}
}
