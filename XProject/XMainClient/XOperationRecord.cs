using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E97 RID: 3735
	internal class XOperationRecord : XSingleton<XOperationRecord>, IXOperationRecord, IXInterface
	{
		// Token: 0x170034BC RID: 13500
		// (get) Token: 0x0600C754 RID: 51028 RVA: 0x002C6F70 File Offset: 0x002C5170
		// (set) Token: 0x0600C755 RID: 51029 RVA: 0x002C6F78 File Offset: 0x002C5178
		public bool Deprecated { get; set; }

		// Token: 0x0600C756 RID: 51030 RVA: 0x002C6F84 File Offset: 0x002C5184
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/OperationRecord", this.table, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				XSingleton<XInterfaceMgr>.singleton.AttachInterface<IXOperationRecord>(XSingleton<XCommon>.singleton.XHash("XOperationRecord"), this);
				for (int i = 0; i < this.table.Table.Length; i++)
				{
					OperationRecord.RowData rowData = this.table.Table[i];
					bool flag3 = this._string_table.ContainsKey(rowData.WindowName);
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Operation ID duplicate:", rowData.WindowName, null, null, null, null);
					}
					uint stringTableID = this.GetStringTableID(rowData.WindowName);
					bool flag4 = rowData.WindowName.StartsWith("sc:");
					if (flag4)
					{
						this._script_operation_id.Add(stringTableID, rowData.RecordID);
					}
					else
					{
						this._string_operation_id.Add(stringTableID, rowData.RecordID);
					}
				}
				this.SetupStringDictionary();
				result = true;
			}
			return result;
		}

		// Token: 0x0600C757 RID: 51031 RVA: 0x002C70CD File Offset: 0x002C52CD
		public override void Uninit()
		{
			this._string_table.Clear();
			this._string_dictionary.Clear();
			this._string_operation_id.Clear();
			this._script_operation_id.Clear();
			this._async_loader = null;
		}

		// Token: 0x0600C758 RID: 51032 RVA: 0x002C7108 File Offset: 0x002C5308
		protected uint GetStringTableID(string key)
		{
			bool flag = this._string_table.ContainsKey(key);
			uint result;
			if (flag)
			{
				result = this._string_table[key];
			}
			else
			{
				this._string_table_index += 1U;
				this._string_table.Add(key, this._string_table_index);
				result = this._string_table_index;
			}
			return result;
		}

		// Token: 0x0600C759 RID: 51033 RVA: 0x002C7164 File Offset: 0x002C5364
		protected string GetStringByID(uint id)
		{
			foreach (KeyValuePair<string, uint> keyValuePair in this._string_table)
			{
				bool flag = keyValuePair.Value == id;
				if (flag)
				{
					return keyValuePair.Key;
				}
			}
			return "";
		}

		// Token: 0x0600C75A RID: 51034 RVA: 0x002C71D8 File Offset: 0x002C53D8
		protected string GetStringSectionFromEnd(string s, int section)
		{
			string text = s;
			string text2 = "";
			for (int i = 0; i < section; i++)
			{
				int num = text.LastIndexOf('/');
				bool flag = num == -1;
				if (flag)
				{
					return s;
				}
				text2 = text.Substring(num) + text2;
				text = text.Substring(0, num);
			}
			bool flag2 = text2.Length > 1;
			if (flag2)
			{
				return text2.Substring(1);
			}
			return text2;
		}

		// Token: 0x0600C75B RID: 51035 RVA: 0x002C7254 File Offset: 0x002C5454
		protected void SetupStringDictionary()
		{
			for (int i = 0; i < this.table.Table.Length; i++)
			{
				OperationRecord.RowData rowData = this.table.Table[i];
				bool flag = rowData.WindowName.StartsWith("sc:");
				if (!flag)
				{
					string stringSectionFromEnd = this.GetStringSectionFromEnd(rowData.WindowName, 1);
					uint stringTableID = this.GetStringTableID(rowData.WindowName);
					bool flag2 = this._string_dictionary.ContainsKey(stringSectionFromEnd);
					if (flag2)
					{
						this._string_dictionary[stringSectionFromEnd].Add(stringTableID);
					}
					else
					{
						List<uint> value = new List<uint>();
						this._string_dictionary.Add(stringSectionFromEnd, value);
						this._string_dictionary[stringSectionFromEnd].Add(stringTableID);
					}
				}
			}
			Dictionary<string, List<uint>> dictionary = new Dictionary<string, List<uint>>();
			Dictionary<string, List<uint>> dictionary2 = new Dictionary<string, List<uint>>();
			this.CloneDictionary(this._string_dictionary, ref dictionary);
			for (int j = 2; j < 20; j++)
			{
				dictionary2.Clear();
				bool flag3 = true;
				foreach (KeyValuePair<string, List<uint>> keyValuePair in dictionary)
				{
					bool flag4 = keyValuePair.Value.Count > 1;
					if (flag4)
					{
						for (int k = 0; k < keyValuePair.Value.Count; k++)
						{
							string stringByID = this.GetStringByID(keyValuePair.Value[k]);
							string stringSectionFromEnd2 = this.GetStringSectionFromEnd(stringByID, j);
							bool flag5 = dictionary2.ContainsKey(stringSectionFromEnd2);
							if (flag5)
							{
								dictionary2[stringSectionFromEnd2].Add(keyValuePair.Value[k]);
							}
							else
							{
								List<uint> value2 = new List<uint>();
								dictionary2.Add(stringSectionFromEnd2, value2);
								dictionary2[stringSectionFromEnd2].Add(keyValuePair.Value[k]);
							}
						}
						flag3 = false;
					}
				}
				bool flag6 = dictionary2.Count > 0;
				if (flag6)
				{
					foreach (KeyValuePair<string, List<uint>> keyValuePair2 in dictionary2)
					{
						this._string_dictionary.Add(keyValuePair2.Key, keyValuePair2.Value);
					}
					this.CloneDictionary(dictionary2, ref dictionary);
				}
				bool flag7 = flag3;
				if (flag7)
				{
					break;
				}
			}
		}

		// Token: 0x0600C75C RID: 51036 RVA: 0x002C74F0 File Offset: 0x002C56F0
		protected void CloneDictionary(Dictionary<string, List<uint>> src, ref Dictionary<string, List<uint>> dst)
		{
			dst.Clear();
			foreach (KeyValuePair<string, List<uint>> keyValuePair in src)
			{
				dst.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		// Token: 0x0600C75D RID: 51037 RVA: 0x002C755C File Offset: 0x002C575C
		public int FindRecordID(Transform go)
		{
			Transform transform = go;
			bool flag = this._string_dictionary.ContainsKey(transform.name);
			if (flag)
			{
				bool flag2 = this._string_dictionary[transform.name].Count > 1;
				if (flag2)
				{
					string text = transform.name;
					for (;;)
					{
						transform = transform.transform.parent;
						text = transform.name + "/" + text;
						bool flag3 = this._GetRecordID(text) == 0;
						if (flag3)
						{
							break;
						}
						bool flag4 = this._GetRecordID(text) == 1;
						if (flag4)
						{
							goto Block_4;
						}
					}
					return 0;
					Block_4:;
				}
				string gameObjectPath = this.GetGameObjectPath(go);
				bool flag5 = this._string_table.ContainsKey(gameObjectPath);
				if (flag5)
				{
					uint key = this._string_table[gameObjectPath];
					PtcC2G_OperateRecordNtf ptcC2G_OperateRecordNtf = new PtcC2G_OperateRecordNtf();
					ptcC2G_OperateRecordNtf.Data.position = this._string_operation_id[key];
					ptcC2G_OperateRecordNtf.Data.account = XSingleton<XLoginDocument>.singleton.Account;
					ptcC2G_OperateRecordNtf.Data.arg = XSingleton<XTutorialMgr>.singleton.GetCurrentCmdStep().ToString();
					XSingleton<XClientNetwork>.singleton.Send(ptcC2G_OperateRecordNtf);
					XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
					{
						"record:",
						gameObjectPath,
						"-->",
						ptcC2G_OperateRecordNtf.Data.position
					}), null, null, null, null, null);
					return (int)this._string_operation_id[key];
				}
			}
			return 0;
		}

		// Token: 0x0600C75E RID: 51038 RVA: 0x002C76F0 File Offset: 0x002C58F0
		public void DoScriptRecord(string key)
		{
			string key2 = "sc:" + key;
			bool flag = this._string_table.ContainsKey(key2);
			if (flag)
			{
				uint key3 = this._string_table[key2];
				PtcC2G_OperateRecordNtf ptcC2G_OperateRecordNtf = new PtcC2G_OperateRecordNtf();
				ptcC2G_OperateRecordNtf.Data.position = this._script_operation_id[key3];
				ptcC2G_OperateRecordNtf.Data.account = XSingleton<XLoginDocument>.singleton.Account;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2G_OperateRecordNtf);
			}
		}

		// Token: 0x0600C75F RID: 51039 RVA: 0x002C776C File Offset: 0x002C596C
		protected int _GetRecordID(string key)
		{
			bool flag = this._string_dictionary.ContainsKey(key);
			int result;
			if (flag)
			{
				result = this._string_dictionary[key].Count;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600C760 RID: 51040 RVA: 0x002C77A4 File Offset: 0x002C59A4
		protected string GetGameObjectPath(Transform obj)
		{
			string text = "/" + obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent;
				text = "/" + obj.name + text;
			}
			text = text.Substring(1);
			int num = text.IndexOf('/');
			return text.Substring(num + 1);
		}

		// Token: 0x0400578E RID: 22414
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x0400578F RID: 22415
		private Dictionary<string, uint> _string_table = new Dictionary<string, uint>();

		// Token: 0x04005790 RID: 22416
		private uint _string_table_index = 0U;

		// Token: 0x04005791 RID: 22417
		private Dictionary<string, List<uint>> _string_dictionary = new Dictionary<string, List<uint>>();

		// Token: 0x04005792 RID: 22418
		private Dictionary<uint, uint> _string_operation_id = new Dictionary<uint, uint>();

		// Token: 0x04005793 RID: 22419
		private Dictionary<uint, uint> _script_operation_id = new Dictionary<uint, uint>();

		// Token: 0x04005794 RID: 22420
		private OperationRecord table = new OperationRecord();
	}
}
