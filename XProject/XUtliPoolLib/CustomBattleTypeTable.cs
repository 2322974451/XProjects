using System;

namespace XUtliPoolLib
{
	// Token: 0x02000230 RID: 560
	public class CustomBattleTypeTable : CVSReader
	{
		// Token: 0x06000C6C RID: 3180 RVA: 0x0004152C File Offset: 0x0003F72C
		public CustomBattleTypeTable.RowData GetBytype(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00041598 File Offset: 0x0003F798
		protected override void ReadLine(XBinaryReader reader)
		{
			CustomBattleTypeTable.RowData rowData = new CustomBattleTypeTable.RowData();
			base.Read<int>(reader, ref rowData.type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.show, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.notopen, CVSReader.boolParse);
			this.columnno = 3;
			base.Read<bool>(reader, ref rowData.gmcreate, CVSReader.boolParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00041644 File Offset: 0x0003F844
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400077E RID: 1918
		public CustomBattleTypeTable.RowData[] Table = null;

		// Token: 0x020003BF RID: 959
		public class RowData
		{
			// Token: 0x040010DC RID: 4316
			public int type;

			// Token: 0x040010DD RID: 4317
			public string name;

			// Token: 0x040010DE RID: 4318
			public string show;

			// Token: 0x040010DF RID: 4319
			public bool notopen;

			// Token: 0x040010E0 RID: 4320
			public bool gmcreate;
		}
	}
}
