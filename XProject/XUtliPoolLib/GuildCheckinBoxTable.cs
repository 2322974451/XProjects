using System;

namespace XUtliPoolLib
{

	public class GuildCheckinBoxTable : CVSReader
	{

		public GuildCheckinBoxTable.RowData GetByprocess(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildCheckinBoxTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].process == key;
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
			GuildCheckinBoxTable.RowData rowData = new GuildCheckinBoxTable.RowData();
			base.Read<uint>(reader, ref rowData.process, CVSReader.uintParse);
			this.columnno = 0;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildCheckinBoxTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildCheckinBoxTable.RowData[] Table = null;

		public class RowData
		{

			public uint process;

			public SeqListRef<uint> viewabledrop;
		}
	}
}
