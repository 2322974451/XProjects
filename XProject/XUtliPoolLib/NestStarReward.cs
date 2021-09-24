using System;

namespace XUtliPoolLib
{

	public class NestStarReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			NestStarReward.RowData rowData = new NestStarReward.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Stars, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.IsHadTittle, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 3;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestStarReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NestStarReward.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public uint Stars;

			public uint IsHadTittle;

			public string Tittle;

			public SeqListRef<uint> Reward;
		}
	}
}
