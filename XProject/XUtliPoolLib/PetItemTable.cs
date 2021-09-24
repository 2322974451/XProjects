using System;

namespace XUtliPoolLib
{

	public class PetItemTable : CVSReader
	{

		public PetItemTable.RowData GetByitemid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetItemTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].itemid == key;
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
			PetItemTable.RowData rowData = new PetItemTable.RowData();
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.petid, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetItemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PetItemTable.RowData[] Table = null;

		public class RowData
		{

			public uint itemid;

			public uint petid;
		}
	}
}
