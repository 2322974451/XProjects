using System;

namespace XUtliPoolLib
{

	public class DragonGuildTable : CVSReader
	{

		public DragonGuildTable.RowData GetBylevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].level == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildTable.RowData rowData = new DragonGuildTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			rowData.buf.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildTable.RowData[] Table = null;

		public class RowData
		{

			public uint level;

			public SeqRef<int> buf;
		}
	}
}
