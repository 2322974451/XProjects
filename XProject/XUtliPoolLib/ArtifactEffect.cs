using System;

namespace XUtliPoolLib
{

	public class ArtifactEffect : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactEffect.RowData rowData = new ArtifactEffect.RowData();
			base.Read<uint>(reader, ref rowData.Quanlity, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.AttrTyte, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Path, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactEffect.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ArtifactEffect.RowData[] Table = null;

		public class RowData
		{

			public uint Quanlity;

			public uint AttrTyte;

			public string Path;
		}
	}
}
