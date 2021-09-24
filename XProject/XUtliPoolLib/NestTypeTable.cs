using System;

namespace XUtliPoolLib
{

	public class NestTypeTable : CVSReader
	{

		public NestTypeTable.RowData GetByTypeID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			NestTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].TypeID == key;
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
			NestTypeTable.RowData rowData = new NestTypeTable.RowData();
			base.Read<int>(reader, ref rowData.TypeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.TypeBgTransform, CVSReader.floatParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NestTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NestTypeTable.RowData[] Table = null;

		public class RowData
		{

			public int TypeID;

			public string TypeName;

			public string TypeBg;

			public string TypeIcon;

			public float[] TypeBgTransform;
		}
	}
}
