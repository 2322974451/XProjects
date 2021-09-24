using System;

namespace XUtliPoolLib
{

	public class DragonGuildConfigTable : CVSReader
	{

		public DragonGuildConfigTable.RowData GetByDragonGuildLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].DragonGuildLevel == key;
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
			DragonGuildConfigTable.RowData rowData = new DragonGuildConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.DragonGuildLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DragonGuildExpNeed, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DragonGuildNumber, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.PresidentNum, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.VicePresidentNum, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonGuildConfigTable.RowData[] Table = null;

		public class RowData
		{

			public uint DragonGuildLevel;

			public uint DragonGuildExpNeed;

			public uint DragonGuildNumber;

			public uint PresidentNum;

			public uint VicePresidentNum;
		}
	}
}
