using System;

namespace XUtliPoolLib
{

	public class PlantSprite : CVSReader
	{

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

		public PlantSprite.RowData[] Table = null;

		public class RowData
		{

			public uint SpriteID;

			public uint ReduceGrowth;

			public uint EffectGrowRate;

			public string[] Dialogues;
		}
	}
}
