using System;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{
	// Token: 0x020001B2 RID: 434
	public class XStringTable : XSingleton<XStringTable>
	{
		// Token: 0x060009B0 RID: 2480 RVA: 0x00032C20 File Offset: 0x00030E20
		public bool ReInit(TextAsset ta)
		{
			this.Uninit();
			bool flag = XSingleton<XResourceLoaderMgr>.singleton.ReadFile(ta, this._reader);
			bool result;
			if (flag)
			{
				this._inited = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00032C5C File Offset: 0x00030E5C
		public bool SyncInit()
		{
			bool inited = this._inited;
			bool result;
			if (inited)
			{
				result = true;
			}
			else
			{
				this._inited = XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/StringTable", this._reader);
				bool inited2 = this._inited;
				if (inited2)
				{
				}
				result = this._inited;
			}
			return result;
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x00032CAC File Offset: 0x00030EAC
		public override bool Init()
		{
			bool inited = this._inited;
			bool result;
			if (inited)
			{
				result = true;
			}
			else
			{
				bool flag = this._async_loader == null;
				if (flag)
				{
					this._async_loader = new XTableAsyncLoader();
					this._async_loader.AddTask("Table/StringTable", this._reader, false);
					this._async_loader.Execute(null);
				}
				this._inited = this._async_loader.IsDone;
				result = this._inited;
			}
			return result;
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00032D22 File Offset: 0x00030F22
		public override void Uninit()
		{
			this._inited = false;
			this._async_loader = null;
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00032D34 File Offset: 0x00030F34
		public bool StringTableUpdated()
		{
			return XSingleton<XUpdater.XUpdater>.singleton.ContainRes(XSingleton<XCommon>.singleton.XHash("Table/StringTable"));
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x00032D60 File Offset: 0x00030F60
		public string GetString(string key)
		{
			string text = "";
			bool data = this.GetData(key, out text);
			string result;
			if (data)
			{
				result = text;
			}
			else
			{
				bool flag = key != "UNKNOWN_TARGET";
				if (flag)
				{
					result = this.GetString("UNKNOWN_TARGET") + " " + key;
				}
				else
				{
					result = "UNKNOWN_TARGET not found in StringTable";
				}
			}
			return result;
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x00032DB8 File Offset: 0x00030FB8
		public bool GetData(string key, out string value)
		{
			uint key2 = XSingleton<XCommon>.singleton.XHash(key);
			return this._reader.Table.TryGetValue(key2, out value);
		}

		// Token: 0x04000496 RID: 1174
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04000497 RID: 1175
		private StringTable _reader = new StringTable();

		// Token: 0x04000498 RID: 1176
		private bool _inited = false;
	}
}
