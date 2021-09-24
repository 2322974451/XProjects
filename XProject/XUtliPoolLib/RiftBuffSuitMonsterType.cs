using System;

namespace XUtliPoolLib
{

	public class RiftBuffSuitMonsterType : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RiftBuffSuitMonsterType.RowData rowData = new RiftBuffSuitMonsterType.RowData();
			rowData.buff.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.suitmonstertype, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.scription, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiftBuffSuitMonsterType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RiftBuffSuitMonsterType.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> buff;

			public uint[] suitmonstertype;

			public string atlas;

			public string icon;

			public string scription;
		}
	}
}
