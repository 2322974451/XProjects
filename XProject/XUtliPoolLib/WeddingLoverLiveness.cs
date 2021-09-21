using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024A RID: 586
	public class WeddingLoverLiveness : CVSReader
	{
		// Token: 0x06000CCE RID: 3278 RVA: 0x000435A0 File Offset: 0x000417A0
		public WeddingLoverLiveness.RowData GetByindex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			WeddingLoverLiveness.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].index == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x0004360C File Offset: 0x0004180C
		protected override void ReadLine(XBinaryReader reader)
		{
			WeddingLoverLiveness.RowData rowData = new WeddingLoverLiveness.RowData();
			base.Read<uint>(reader, ref rowData.index, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.liveness, CVSReader.uintParse);
			this.columnno = 1;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.boxPic, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000436A0 File Offset: 0x000418A0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeddingLoverLiveness.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000798 RID: 1944
		public WeddingLoverLiveness.RowData[] Table = null;

		// Token: 0x020003D9 RID: 985
		public class RowData
		{
			// Token: 0x04001154 RID: 4436
			public uint index;

			// Token: 0x04001155 RID: 4437
			public uint liveness;

			// Token: 0x04001156 RID: 4438
			public SeqListRef<uint> viewabledrop;

			// Token: 0x04001157 RID: 4439
			public string boxPic;
		}
	}
}
