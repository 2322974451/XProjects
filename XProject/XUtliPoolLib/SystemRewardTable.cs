using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017B RID: 379
	public class SystemRewardTable : CVSReader
	{
		// Token: 0x06000845 RID: 2117 RVA: 0x0002B638 File Offset: 0x00029838
		public SystemRewardTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SystemRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0002B6A4 File Offset: 0x000298A4
		protected override void ReadLine(XBinaryReader reader)
		{
			SystemRewardTable.RowData rowData = new SystemRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SubType, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Sort, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Remark, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0002B750 File Offset: 0x00029950
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SystemRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C7 RID: 967
		public SystemRewardTable.RowData[] Table = null;

		// Token: 0x0200037A RID: 890
		public class RowData
		{
			// Token: 0x04000EC3 RID: 3779
			public uint Type;

			// Token: 0x04000EC4 RID: 3780
			public string Name;

			// Token: 0x04000EC5 RID: 3781
			public uint SubType;

			// Token: 0x04000EC6 RID: 3782
			public uint Sort;

			// Token: 0x04000EC7 RID: 3783
			public string Remark;
		}
	}
}
