using System;

namespace XUtliPoolLib
{

	public class ArgentaDaily : CVSReader
	{

		public ArgentaDaily.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ArgentaDaily.RowData result;
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

		protected override void ReadLine(XBinaryReader reader)
		{
			ArgentaDaily.RowData rowData = new ArgentaDaily.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Title, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArgentaDaily.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ArgentaDaily.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public SeqListRef<uint> Reward;

			public string Description;

			public string Title;
		}
	}
}
