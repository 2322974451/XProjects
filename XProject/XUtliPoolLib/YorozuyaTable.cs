using System;

namespace XUtliPoolLib
{
	// Token: 0x02000261 RID: 609
	public class YorozuyaTable : CVSReader
	{
		// Token: 0x06000D21 RID: 3361 RVA: 0x000454CC File Offset: 0x000436CC
		public YorozuyaTable.RowData GetByID(byte key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			YorozuyaTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00045538 File Offset: 0x00043738
		protected override void ReadLine(XBinaryReader reader)
		{
			YorozuyaTable.RowData rowData = new YorozuyaTable.RowData();
			base.Read<byte>(reader, ref rowData.ID, CVSReader.byteParse);
			this.columnno = 0;
			rowData.SceneIDs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<byte>(reader, ref rowData.IsOpen, CVSReader.byteParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x000455E4 File Offset: 0x000437E4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new YorozuyaTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AF RID: 1967
		public YorozuyaTable.RowData[] Table = null;

		// Token: 0x020003F0 RID: 1008
		public class RowData
		{
			// Token: 0x040011E6 RID: 4582
			public byte ID;

			// Token: 0x040011E7 RID: 4583
			public SeqListRef<uint> SceneIDs;

			// Token: 0x040011E8 RID: 4584
			public string IconName;

			// Token: 0x040011E9 RID: 4585
			public string Name;

			// Token: 0x040011EA RID: 4586
			public byte IsOpen;
		}
	}
}
