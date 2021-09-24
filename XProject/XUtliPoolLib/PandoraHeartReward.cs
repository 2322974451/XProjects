using System;

namespace XUtliPoolLib
{

	public class PandoraHeartReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PandoraHeartReward.RowData rowData = new PandoraHeartReward.RowData();
			base.Read<uint>(reader, ref rowData.pandoraid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			rowData.showlevel.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PandoraHeartReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PandoraHeartReward.RowData[] Table = null;

		public class RowData
		{

			public uint pandoraid;

			public uint itemid;

			public SeqRef<uint> showlevel;
		}
	}
}
