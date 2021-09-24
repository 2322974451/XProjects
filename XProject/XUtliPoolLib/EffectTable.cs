using System;

namespace XUtliPoolLib
{

	public class EffectTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			EffectTable.RowData rowData = new EffectTable.RowData();
			base.Read<uint>(reader, ref rowData.EffectID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.BuffID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.TemplateBuffID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SkillScript, CVSReader.uintParse);
			this.columnno = 3;
			rowData.EffectParams.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ConstantParams.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<byte>(reader, ref rowData.SortID, CVSReader.byteParse);
			this.columnno = 6;
			base.Read<byte>(reader, ref rowData.CompareSortID, CVSReader.byteParse);
			this.columnno = 7;
			rowData.CompareParams.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EffectTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EffectTable.RowData[] Table = null;

		public class RowData
		{

			public uint EffectID;

			public uint BuffID;

			public uint TemplateBuffID;

			public uint SkillScript;

			public SeqListRef<int> EffectParams;

			public SeqListRef<string> ConstantParams;

			public byte SortID;

			public byte CompareSortID;

			public SeqListRef<uint> CompareParams;
		}
	}
}
