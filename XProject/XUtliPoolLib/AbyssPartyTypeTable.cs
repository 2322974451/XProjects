using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022A RID: 554
	public class AbyssPartyTypeTable : CVSReader
	{
		// Token: 0x06000C58 RID: 3160 RVA: 0x00040E78 File Offset: 0x0003F078
		public AbyssPartyTypeTable.RowData GetByAbyssPartyId(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AbyssPartyTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].AbyssPartyId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00040EE4 File Offset: 0x0003F0E4
		protected override void ReadLine(XBinaryReader reader)
		{
			AbyssPartyTypeTable.RowData rowData = new AbyssPartyTypeTable.RowData();
			base.Read<int>(reader, ref rowData.AbyssPartyId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SugLevel, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.PandoraID, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.TitanItemID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00040FC4 File Offset: 0x0003F1C4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AbyssPartyTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000778 RID: 1912
		public AbyssPartyTypeTable.RowData[] Table = null;

		// Token: 0x020003B9 RID: 953
		public class RowData
		{
			// Token: 0x040010BB RID: 4283
			public int AbyssPartyId;

			// Token: 0x040010BC RID: 4284
			public string Name;

			// Token: 0x040010BD RID: 4285
			public string Icon;

			// Token: 0x040010BE RID: 4286
			public int OpenLevel;

			// Token: 0x040010BF RID: 4287
			public string SugLevel;

			// Token: 0x040010C0 RID: 4288
			public int PandoraID;

			// Token: 0x040010C1 RID: 4289
			public int[] TitanItemID;
		}
	}
}
