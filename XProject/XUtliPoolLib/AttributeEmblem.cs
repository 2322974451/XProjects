using System;

namespace XUtliPoolLib
{

	public class AttributeEmblem : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			AttributeEmblem.RowData rowData = new AttributeEmblem.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Position, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.AttrID, CVSReader.byteParse);
			this.columnno = 2;
			rowData.Range.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AttributeEmblem.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AttributeEmblem.RowData[] Table = null;

		public class RowData
		{

			public uint EmblemID;

			public byte Position;

			public byte AttrID;

			public SeqRef<uint> Range;
		}
	}
}
