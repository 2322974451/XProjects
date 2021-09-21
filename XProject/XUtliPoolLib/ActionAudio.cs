using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020000AB RID: 171
	public class ActionAudio : CVSReader
	{
		// Token: 0x06000523 RID: 1315 RVA: 0x00016788 File Offset: 0x00014988
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

		// Token: 0x06000524 RID: 1316 RVA: 0x000167C4 File Offset: 0x000149C4
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

		// Token: 0x06000525 RID: 1317 RVA: 0x0001692E File Offset: 0x00014B2E
		protected override void OnClear(int lineCount)
		{
			this.Table.Clear();
		}

		// Token: 0x040002D1 RID: 721
		public Dictionary<string, ActionAudio.RowData> Table = new Dictionary<string, ActionAudio.RowData>();

		// Token: 0x020002A9 RID: 681
		public class RowData
		{
			// Token: 0x040008BE RID: 2238
			public string Prefab;

			// Token: 0x040008BF RID: 2239
			public string[] Idle;

			// Token: 0x040008C0 RID: 2240
			public string[] Move;

			// Token: 0x040008C1 RID: 2241
			public string[] Jump;

			// Token: 0x040008C2 RID: 2242
			public string[] Fall;

			// Token: 0x040008C3 RID: 2243
			public string[] Charge;

			// Token: 0x040008C4 RID: 2244
			public string[] Freeze;

			// Token: 0x040008C5 RID: 2245
			public string[] Behit;

			// Token: 0x040008C6 RID: 2246
			public string[] Death;

			// Token: 0x040008C7 RID: 2247
			public string[] BehitFly;

			// Token: 0x040008C8 RID: 2248
			public string[] BehitRoll;

			// Token: 0x040008C9 RID: 2249
			public string[] BehitSuperArmor;
		}
	}
}
