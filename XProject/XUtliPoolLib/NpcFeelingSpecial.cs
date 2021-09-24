using System;

namespace XUtliPoolLib
{

	public class NpcFeelingSpecial : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			NpcFeelingSpecial.RowData rowData = new NpcFeelingSpecial.RowData();
			base.Read<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 0;
			rowData.enhanceReduce.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcFeelingSpecial.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NpcFeelingSpecial.RowData[] Table = null;

		public class RowData
		{

			public uint npcId;

			public SeqListRef<uint> enhanceReduce;
		}
	}
}
