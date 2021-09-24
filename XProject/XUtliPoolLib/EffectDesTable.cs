using System;

namespace XUtliPoolLib
{

	public class EffectDesTable : CVSReader
	{

		public EffectDesTable.RowData GetByEffectID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			EffectDesTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].EffectID == key;
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
			EffectDesTable.RowData rowData = new EffectDesTable.RowData();
			base.Read<uint>(reader, ref rowData.EffectID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.EffectDes, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<float>(reader, ref rowData.ParamCoefficient, CVSReader.floatParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.ColorDes, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<byte>(reader, ref rowData.BaseProf, CVSReader.byteParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.EffectType, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EffectDesTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EffectDesTable.RowData[] Table = null;

		public class RowData
		{

			public uint EffectID;

			public string EffectDes;

			public float[] ParamCoefficient;

			public string[] ColorDes;

			public byte BaseProf;

			public uint EffectType;
		}
	}
}
