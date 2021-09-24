using System;
using UnityEngine;
using XUpdater;

namespace XUtliPoolLib
{

	public class XStringTable : XSingleton<XStringTable>
	{

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

		public override void Uninit()
		{
			this._inited = false;
			this._async_loader = null;
		}

		public bool StringTableUpdated()
		{
			return XSingleton<XUpdater.XUpdater>.singleton.ContainRes(XSingleton<XCommon>.singleton.XHash("Table/StringTable"));
		}

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

		public bool GetData(string key, out string value)
		{
			uint key2 = XSingleton<XCommon>.singleton.XHash(key);
			return this._reader.Table.TryGetValue(key2, out value);
		}

		private XTableAsyncLoader _async_loader = null;

		private StringTable _reader = new StringTable();

		private bool _inited = false;
	}
}
