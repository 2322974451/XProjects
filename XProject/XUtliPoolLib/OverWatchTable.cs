using System;

namespace XUtliPoolLib
{

	public class OverWatchTable : CVSReader
	{

		public OverWatchTable.RowData GetByHeroID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OverWatchTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].HeroID == key;
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
			OverWatchTable.RowData rowData = new OverWatchTable.RowData();
			base.Read<uint>(reader, ref rowData.HeroID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.StatisticsID, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Price.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.CutSceneAniamtion, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.CutSceneIdleAni, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Motto, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.MiniMapIcon, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<float>(reader, ref rowData.MobaAttributes, CVSReader.floatParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.SelectAnim, CVSReader.stringParse);
			this.columnno = 14;
			base.ReadArray<string>(reader, ref rowData.SelectFx, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.HeroUseTips, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.MobaUseTips, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.IconAtlas, CVSReader.stringParse);
			this.columnno = 18;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OverWatchTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public OverWatchTable.RowData[] Table = null;

		public class RowData
		{

			public uint HeroID;

			public uint[] StatisticsID;

			public SeqRef<uint> Price;

			public string Name;

			public string Icon;

			public string Description;

			public string CutSceneAniamtion;

			public string CutSceneIdleAni;

			public int SortID;

			public string Motto;

			public string MiniMapIcon;

			public float[] MobaAttributes;

			public string SelectAnim;

			public string[] SelectFx;

			public string HeroUseTips;

			public string MobaUseTips;

			public string IconAtlas;
		}
	}
}
