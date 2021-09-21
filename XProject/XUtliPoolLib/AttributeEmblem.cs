using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B2 RID: 178
	public class AttributeEmblem : CVSReader
	{
		// Token: 0x0600053D RID: 1341 RVA: 0x00017310 File Offset: 0x00015510
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

		// Token: 0x0600053E RID: 1342 RVA: 0x000173A4 File Offset: 0x000155A4
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

		// Token: 0x040002D8 RID: 728
		public AttributeEmblem.RowData[] Table = null;

		// Token: 0x020002B0 RID: 688
		public class RowData
		{
			// Token: 0x04000900 RID: 2304
			public uint EmblemID;

			// Token: 0x04000901 RID: 2305
			public byte Position;

			// Token: 0x04000902 RID: 2306
			public byte AttrID;

			// Token: 0x04000903 RID: 2307
			public SeqRef<uint> Range;
		}
	}
}
