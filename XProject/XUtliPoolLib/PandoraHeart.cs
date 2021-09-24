using System;

namespace XUtliPoolLib
{

	public class PandoraHeart : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PandoraHeart.RowData rowData = new PandoraHeart.RowData();
			base.Read<uint>(reader, ref rowData.PandoraID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.FireID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot0, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle0, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot1, CVSReader.uintParse);
			this.columnno = 6;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle1, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.DisplaySlot2, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.DisplayAngle2, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.DisplayName0, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.DisplayName1, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.DisplayName2, CVSReader.stringParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PandoraHeart.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PandoraHeart.RowData[] Table = null;

		public class RowData
		{

			public uint PandoraID;

			public uint ProfID;

			public uint FireID;

			public uint[] DisplaySlot0;

			public uint[] DisplayAngle0;

			public uint[] DisplaySlot1;

			public uint[] DisplayAngle1;

			public uint[] DisplaySlot2;

			public uint[] DisplayAngle2;

			public string DisplayName0;

			public string DisplayName1;

			public string DisplayName2;
		}
	}
}
