using System;

namespace XUtliPoolLib
{

	public class ArtifactSuitTable : CVSReader
	{

		public ArtifactSuitTable.RowData GetByArtifactSuitID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ArtifactSuitTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ArtifactSuitID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactSuitTable.RowData rowData = new ArtifactSuitTable.RowData();
			base.Read<uint>(reader, ref rowData.ArtifactSuitID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<byte>(reader, ref rowData.IsCreateShow, CVSReader.byteParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.ElementType, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<byte>(reader, ref rowData.SuitQuality, CVSReader.byteParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ArtifactSuitTable.RowData[] Table = null;

		public class RowData
		{

			public uint ArtifactSuitID;

			public uint Level;

			public string Name;

			public SeqListRef<uint> Effect2;

			public SeqListRef<uint> Effect3;

			public SeqListRef<uint> Effect4;

			public SeqListRef<uint> Effect5;

			public SeqListRef<uint> Effect6;

			public byte IsCreateShow;

			public uint ElementType;

			public byte SuitQuality;
		}
	}
}
