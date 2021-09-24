using System;

namespace XUtliPoolLib
{

	public class CharacterAttributesList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CharacterAttributesList.RowData rowData = new CharacterAttributesList.RowData();
			base.Read<uint>(reader, ref rowData.AttributeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Section, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CharacterAttributesList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CharacterAttributesList.RowData[] Table = null;

		public class RowData
		{

			public uint AttributeID;

			public string Section;
		}
	}
}
