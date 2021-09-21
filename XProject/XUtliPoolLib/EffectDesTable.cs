using System;

namespace XUtliPoolLib
{
	// Token: 0x0200022C RID: 556
	public class EffectDesTable : CVSReader
	{
		// Token: 0x06000C5F RID: 3167 RVA: 0x00041158 File Offset: 0x0003F358
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

		// Token: 0x06000C60 RID: 3168 RVA: 0x000411C4 File Offset: 0x0003F3C4
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

		// Token: 0x06000C61 RID: 3169 RVA: 0x0004128C File Offset: 0x0003F48C
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

		// Token: 0x0400077A RID: 1914
		public EffectDesTable.RowData[] Table = null;

		// Token: 0x020003BB RID: 955
		public class RowData
		{
			// Token: 0x040010CB RID: 4299
			public uint EffectID;

			// Token: 0x040010CC RID: 4300
			public string EffectDes;

			// Token: 0x040010CD RID: 4301
			public float[] ParamCoefficient;

			// Token: 0x040010CE RID: 4302
			public string[] ColorDes;

			// Token: 0x040010CF RID: 4303
			public byte BaseProf;

			// Token: 0x040010D0 RID: 4304
			public uint EffectType;
		}
	}
}
