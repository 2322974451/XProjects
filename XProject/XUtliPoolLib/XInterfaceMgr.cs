using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class XInterfaceMgr : XSingleton<XInterfaceMgr>
	{

		public T GetInterface<T>(uint key) where T : IXInterface
		{
			IXInterface ixinterface = null;
			this._interfaces.TryGetValue(key, out ixinterface);
			return (T)(ixinterface);
		}

		public T AttachInterface<T>(uint key, T value) where T : IXInterface
		{
			bool flag = this._interfaces.ContainsKey(key);
			if (flag)
			{
				this._interfaces[key].Deprecated = true;
				XSingleton<XDebug>.singleton.AddLog("Duplication key for interface ", this._interfaces[key].ToString(), " and ", value.ToString(), null, null, XDebugColor.XDebug_None);
				this._interfaces[key] = value;
			}
			else
			{
				this._interfaces.Add(key, value);
			}
			this._interfaces[key].Deprecated = false;
			return value;
		}

		public void DetachInterface(uint key)
		{
			bool flag = this._interfaces.ContainsKey(key);
			if (flag)
			{
				this._interfaces[key].Deprecated = true;
				this._interfaces.Remove(key);
			}
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
			this._interfaces.Clear();
		}

		private Dictionary<uint, IXInterface> _interfaces = new Dictionary<uint, IXInterface>();
	}
}
