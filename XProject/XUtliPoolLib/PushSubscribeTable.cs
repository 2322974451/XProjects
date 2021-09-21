using System;

namespace XUtliPoolLib
{
	// Token: 0x02000155 RID: 341
	public class PushSubscribeTable : CVSReader
	{
		// Token: 0x060007B1 RID: 1969 RVA: 0x00027078 File Offset: 0x00025278
		public PushSubscribeTable.RowData GetByMsgId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PushSubscribeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].MsgId == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x000270E4 File Offset: 0x000252E4
		protected override void ReadLine(XBinaryReader reader)
		{
			PushSubscribeTable.RowData rowData = new PushSubscribeTable.RowData();
			base.Read<uint>(reader, ref rowData.MsgId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<bool>(reader, ref rowData.IsShow, CVSReader.boolParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SubscribeDescription, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.CancelDescription, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00027178 File Offset: 0x00025378
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PushSubscribeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A1 RID: 929
		public PushSubscribeTable.RowData[] Table = null;

		// Token: 0x02000354 RID: 852
		public class RowData
		{
			// Token: 0x04000D58 RID: 3416
			public uint MsgId;

			// Token: 0x04000D59 RID: 3417
			public bool IsShow;

			// Token: 0x04000D5A RID: 3418
			public string SubscribeDescription;

			// Token: 0x04000D5B RID: 3419
			public string CancelDescription;
		}
	}
}
