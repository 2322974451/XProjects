using System;

namespace XUtliPoolLib
{

	public class NpcFeelingAttr : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			NpcFeelingAttr.RowData rowData = new NpcFeelingAttr.RowData();
			base.Read<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.needExp, CVSReader.uintParse);
			this.columnno = 2;
			rowData.Attr.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.RelicsDesc, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcFeelingAttr.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NpcFeelingAttr.RowData[] Table = null;

		public class RowData
		{

			public uint npcId;

			public uint level;

			public uint needExp;

			public SeqListRef<uint> Attr;

			public string RelicsDesc;
		}
	}
}
