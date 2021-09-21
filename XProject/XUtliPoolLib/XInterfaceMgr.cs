using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020000A7 RID: 167
	public class XInterfaceMgr : XSingleton<XInterfaceMgr>
	{
		// Token: 0x06000510 RID: 1296 RVA: 0x000160E8 File Offset: 0x000142E8
		public T GetInterface<T>(uint key) where T : IXInterface
		{
			IXInterface ixinterface = null;
			this._interfaces.TryGetValue(key, out ixinterface);
			return (T)(ixinterface);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00016114 File Offset: 0x00014314
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

		// Token: 0x06000512 RID: 1298 RVA: 0x000161C0 File Offset: 0x000143C0
		public void DetachInterface(uint key)
		{
			bool flag = this._interfaces.ContainsKey(key);
			if (flag)
			{
				this._interfaces[key].Deprecated = true;
				this._interfaces.Remove(key);
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00016200 File Offset: 0x00014400
		public override bool Init()
		{
			return true;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00016213 File Offset: 0x00014413
		public override void Uninit()
		{
			this._interfaces.Clear();
		}

		// Token: 0x040002CD RID: 717
		private Dictionary<uint, IXInterface> _interfaces = new Dictionary<uint, IXInterface>();
	}
}
