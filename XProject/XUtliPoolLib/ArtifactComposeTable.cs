using System;

namespace XUtliPoolLib
{

	public class ArtifactComposeTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactComposeTable.RowData rowData = new ArtifactComposeTable.RowData();
			base.Read<uint>(reader, ref rowData.ArtifactLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ArtifactQuality, CVSReader.uintParse);
			this.columnno = 1;
			rowData.ArtifactNum2DropID.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactComposeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ArtifactComposeTable.RowData[] Table = null;

		public class RowData
		{

			public uint ArtifactLevel;

			public uint ArtifactQuality;

			public SeqListRef<uint> ArtifactNum2DropID;
		}
	}
}
