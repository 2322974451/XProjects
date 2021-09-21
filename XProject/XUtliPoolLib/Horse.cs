using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011C RID: 284
	public class Horse : CVSReader
	{
		// Token: 0x060006E0 RID: 1760 RVA: 0x00021DD0 File Offset: 0x0001FFD0
		public Horse.RowData GetBysceneid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			Horse.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].sceneid == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00021E3C File Offset: 0x0002003C
		protected override void ReadLine(XBinaryReader reader)
		{
			Horse.RowData rowData = new Horse.RowData();
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Laps, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00021E9C File Offset: 0x0002009C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Horse.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000368 RID: 872
		public Horse.RowData[] Table = null;

		// Token: 0x0200031B RID: 795
		public class RowData
		{
			// Token: 0x04000BCA RID: 3018
			public uint sceneid;

			// Token: 0x04000BCB RID: 3019
			public uint Laps;
		}
	}
}
