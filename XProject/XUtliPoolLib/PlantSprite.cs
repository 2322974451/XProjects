using System;

namespace XUtliPoolLib
{
	// Token: 0x0200014B RID: 331
	public class PlantSprite : CVSReader
	{
		// Token: 0x0600078E RID: 1934 RVA: 0x0002635C File Offset: 0x0002455C
		public PlantSprite.RowData GetBySpriteID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PlantSprite.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SpriteID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x000263C8 File Offset: 0x000245C8
		protected override void ReadLine(XBinaryReader reader)
		{
			PlantSprite.RowData rowData = new PlantSprite.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ReduceGrowth, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.EffectGrowRate, CVSReader.uintParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.Dialogues, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0002645C File Offset: 0x0002465C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PlantSprite.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000397 RID: 919
		public PlantSprite.RowData[] Table = null;

		// Token: 0x0200034A RID: 842
		public class RowData
		{
			// Token: 0x04000D18 RID: 3352
			public uint SpriteID;

			// Token: 0x04000D19 RID: 3353
			public uint ReduceGrowth;

			// Token: 0x04000D1A RID: 3354
			public uint EffectGrowRate;

			// Token: 0x04000D1B RID: 3355
			public string[] Dialogues;
		}
	}
}
