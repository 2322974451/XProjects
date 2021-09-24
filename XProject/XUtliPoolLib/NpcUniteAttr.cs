using System;

namespace XUtliPoolLib
{

	public class NpcUniteAttr : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			NpcUniteAttr.RowData rowData = new NpcUniteAttr.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			rowData.Attr.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcUniteAttr.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NpcUniteAttr.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint[] npcId;

			public uint level;

			public SeqListRef<uint> Attr;

			public string Name;

			public string Icon;
		}
	}
}
