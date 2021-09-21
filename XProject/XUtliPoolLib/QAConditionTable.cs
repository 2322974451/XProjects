using System;

namespace XUtliPoolLib
{
	// Token: 0x02000159 RID: 345
	public class QAConditionTable : CVSReader
	{
		// Token: 0x060007C1 RID: 1985 RVA: 0x00027514 File Offset: 0x00025714
		public QAConditionTable.RowData GetByQAType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QAConditionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].QAType == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00027580 File Offset: 0x00025780
		protected override void ReadLine(XBinaryReader reader)
		{
			QAConditionTable.RowData rowData = new QAConditionTable.RowData();
			base.Read<int>(reader, ref rowData.QAType, CVSReader.intParse);
			this.columnno = 0;
			rowData.LevelSection.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x000275E0 File Offset: 0x000257E0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QAConditionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A5 RID: 933
		public QAConditionTable.RowData[] Table = null;

		// Token: 0x02000358 RID: 856
		public class RowData
		{
			// Token: 0x04000D62 RID: 3426
			public int QAType;

			// Token: 0x04000D63 RID: 3427
			public SeqListRef<uint> LevelSection;
		}
	}
}
