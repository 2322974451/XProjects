using System;

namespace XUtliPoolLib
{

	public class JadeSealTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			JadeSealTable.RowData rowData = new JadeSealTable.RowData();
			base.Read<uint>(reader, ref rowData.SealID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.SealJob, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.SealEquip, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SealNum, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SealName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SealLevel, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SealQuality, CVSReader.uintParse);
			this.columnno = 6;
			rowData.SealAttributes.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.SealSuit, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.SealWeight, CVSReader.uintParse);
			this.columnno = 9;
			rowData.SealBuff.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeSealTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public JadeSealTable.RowData[] Table = null;

		public class RowData
		{

			public uint SealID;

			public uint[] SealJob;

			public uint[] SealEquip;

			public uint SealNum;

			public string SealName;

			public uint SealLevel;

			public uint SealQuality;

			public SeqListRef<uint> SealAttributes;

			public uint[] SealSuit;

			public uint SealWeight;

			public SeqListRef<uint> SealBuff;
		}
	}
}
