using System;

namespace XUtliPoolLib
{

	public class ProfessionTable : CVSReader
	{

		public ProfessionTable.RowData GetByProfID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ProfessionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			ProfessionTable.RowData rowData = new ProfessionTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.AttackType, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.AwakeHair, CVSReader.uintParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ProfessionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ProfessionTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint PresentID;

			public uint AttackType;

			public uint AwakeHair;
		}
	}
}
