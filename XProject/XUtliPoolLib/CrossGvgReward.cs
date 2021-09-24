using System;

namespace XUtliPoolLib
{

	public class CrossGvgReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CrossGvgReward.RowData rowData = new CrossGvgReward.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Rank.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.MemberRewardMail, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.GuildExp, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildPrestige, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CrossGvgReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CrossGvgReward.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public SeqRef<uint> Rank;

			public uint MemberRewardMail;

			public uint GuildExp;

			public uint GuildPrestige;
		}
	}
}
