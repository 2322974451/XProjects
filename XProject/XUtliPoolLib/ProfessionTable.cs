using System;

namespace XUtliPoolLib
{
	// Token: 0x02000151 RID: 337
	public class ProfessionTable : CVSReader
	{
		// Token: 0x060007A3 RID: 1955 RVA: 0x00026A24 File Offset: 0x00024C24
		public ProfessionTable.RowData GetByProfID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ProfessionTable.RowData result;
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

		// Token: 0x060007A4 RID: 1956 RVA: 0x00026A90 File Offset: 0x00024C90
		protected override void ReadLine(XBinaryReader reader)
		{
			ProfessionTable.RowData rowData = new ProfessionTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.AttackType, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.AwakeHair, CVSReader.uintParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00026B24 File Offset: 0x00024D24
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039D RID: 925
		public ProfessionTable.RowData[] Table = null;

		// Token: 0x02000350 RID: 848
		public class RowData
		{
			// Token: 0x04000D33 RID: 3379
			public uint ID;

			// Token: 0x04000D34 RID: 3380
			public uint PresentID;

			// Token: 0x04000D35 RID: 3381
			public uint AttackType;

			// Token: 0x04000D36 RID: 3382
			public uint AwakeHair;
		}
	}
}
