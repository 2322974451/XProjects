using System;

namespace XUtliPoolLib
{

	public class GuildCheckinTable : CVSReader
	{

		public GuildCheckinTable.RowData GetBytype(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildCheckinTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].type == key;
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
			GuildCheckinTable.RowData rowData = new GuildCheckinTable.RowData();
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 0;
			rowData.consume.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCheckinTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildCheckinTable.RowData[] Table = null;

		public class RowData
		{

			public uint type;

			public SeqRef<uint> consume;

			public SeqRef<uint> reward;

			public uint process;
		}
	}
}
