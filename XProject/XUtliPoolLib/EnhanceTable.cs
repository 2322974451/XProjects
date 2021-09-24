using System;

namespace XUtliPoolLib
{

	public class EnhanceTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceTable.RowData rowData = new EnhanceTable.RowData();
			base.Read<uint>(reader, ref rowData.EquipPos, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.UpRate, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.IsNeedBreak, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EnhanceTable.RowData[] Table = null;

		public class RowData
		{

			public uint EquipPos;

			public uint EnhanceLevel;

			public SeqListRef<uint> NeedItem;

			public uint SuccessRate;

			public uint UpRate;

			public uint IsNeedBreak;
		}
	}
}
