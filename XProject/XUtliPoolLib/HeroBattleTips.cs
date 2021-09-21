using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011B RID: 283
	public class HeroBattleTips : CVSReader
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x00021CC4 File Offset: 0x0001FEC4
		public HeroBattleTips.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleTips.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00021D30 File Offset: 0x0001FF30
		protected override void ReadLine(XBinaryReader reader)
		{
			HeroBattleTips.RowData rowData = new HeroBattleTips.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00021D90 File Offset: 0x0001FF90
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleTips.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000367 RID: 871
		public HeroBattleTips.RowData[] Table = null;

		// Token: 0x0200031A RID: 794
		public class RowData
		{
			// Token: 0x04000BC8 RID: 3016
			public uint id;

			// Token: 0x04000BC9 RID: 3017
			public string tips;
		}
	}
}
