using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class ActionAudio : CVSReader
	{

		public ActionAudio.RowData GetByPrefab(string key)
		{
			bool flag = this.Table.Count == 0;
			ActionAudio.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				ActionAudio.RowData rowData = null;
				this.Table.TryGetValue(key, out rowData);
				result = rowData;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			ActionAudio.RowData rowData = new ActionAudio.RowData();
			base.Read<string>(reader, ref rowData.Prefab, CVSReader.stringParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.Idle, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.Move, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Jump, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Fall, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.Charge, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.Freeze, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Behit, CVSReader.stringParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.Death, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.BehitFly, CVSReader.stringParse);
			this.columnno = 10;
			base.ReadArray<string>(reader, ref rowData.BehitRoll, CVSReader.stringParse);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.BehitSuperArmor, CVSReader.stringParse);
			this.columnno = 12;
			this.Table[rowData.Prefab] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			this.Table.Clear();
		}

		public Dictionary<string, ActionAudio.RowData> Table = new Dictionary<string, ActionAudio.RowData>();

		public class RowData
		{

			public string Prefab;

			public string[] Idle;

			public string[] Move;

			public string[] Jump;

			public string[] Fall;

			public string[] Charge;

			public string[] Freeze;

			public string[] Behit;

			public string[] Death;

			public string[] BehitFly;

			public string[] BehitRoll;

			public string[] BehitSuperArmor;
		}
	}
}
