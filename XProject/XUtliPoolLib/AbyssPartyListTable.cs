using System;

namespace XUtliPoolLib
{

	public class AbyssPartyListTable : CVSReader
	{

		public AbyssPartyListTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AbyssPartyListTable.RowData result;
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
			AbyssPartyListTable.RowData rowData = new AbyssPartyListTable.RowData();
			base.Read<int>(reader, ref rowData.AbyssPartyId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Index, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			rowData.Cost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SugPPT, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AbyssPartyListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AbyssPartyListTable.RowData[] Table = null;

		public class RowData
		{

			public int AbyssPartyId;

			public int Index;

			public string Name;

			public string Icon;

			public SeqRef<int> Cost;

			public uint SugPPT;

			public int ID;
		}
	}
}
