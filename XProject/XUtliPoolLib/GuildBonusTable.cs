using System;

namespace XUtliPoolLib
{

	public class GuildBonusTable : CVSReader
	{

		public GuildBonusTable.RowData GetByGuildBonusID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildBonusTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GuildBonusID == key;
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
			GuildBonusTable.RowData rowData = new GuildBonusTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildBonusID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.GuildBonusName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.GuildBonusDesc, CVSReader.stringParse);
			this.columnno = 3;
			rowData.GuildBonusReward.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBonusTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildBonusTable.RowData[] Table = null;

		public class RowData
		{

			public uint GuildBonusID;

			public string GuildBonusName;

			public string GuildBonusDesc;

			public SeqRef<uint> GuildBonusReward;
		}
	}
}
