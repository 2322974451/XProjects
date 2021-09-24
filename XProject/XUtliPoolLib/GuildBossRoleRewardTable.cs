using System;

namespace XUtliPoolLib
{

	public class GuildBossRoleRewardTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildBossRoleRewardTable.RowData rowData = new GuildBossRoleRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.prestige.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildBossRoleRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildBossRoleRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint BossID;

			public SeqListRef<uint> prestige;
		}
	}
}
