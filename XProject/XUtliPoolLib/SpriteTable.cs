using System;

namespace XUtliPoolLib
{

	public class SpriteTable : CVSReader
	{

		public SpriteTable.RowData GetBySpriteID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SpriteTable.RowData result;
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

		public SpriteTable.RowData GetByPresentID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SpriteTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].PresentID == key;
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
			SpriteTable.RowData rowData = new SpriteTable.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SpriteName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SpriteQuality, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SpriteIcon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.SpriteModelID, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SpriteSkillID, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.AttrID1, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.AttrID2, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.AttrID3, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.AttrID4, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.AttrID5, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.BaseAttr1, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.BaseAttr2, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.BaseAttr3, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.BaseAttr4, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.BaseAttr5, CVSReader.uintParse);
			this.columnno = 19;
			rowData.Range1.Read(reader, this.m_DataHandler);
			this.columnno = 25;
			rowData.Range2.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			rowData.Range3.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			rowData.Range4.Read(reader, this.m_DataHandler);
			this.columnno = 28;
			rowData.Range5.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 47;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<string>(reader, ref rowData.DeathAnim, CVSReader.stringParse);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.ReviveAnim, CVSReader.stringParse);
			this.columnno = 50;
			base.Read<int>(reader, ref rowData.IllustrationShow, CVSReader.intParse);
			this.columnno = 51;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SpriteTable.RowData[] Table = null;

		public class RowData
		{

			public uint SpriteID;

			public string SpriteName;

			public uint SpriteQuality;

			public string SpriteIcon;

			public uint SpriteModelID;

			public uint SpriteSkillID;

			public uint AttrID1;

			public uint AttrID2;

			public uint AttrID3;

			public uint AttrID4;

			public uint AttrID5;

			public uint BaseAttr1;

			public uint BaseAttr2;

			public uint BaseAttr3;

			public uint BaseAttr4;

			public uint BaseAttr5;

			public SeqRef<uint> Range1;

			public SeqRef<uint> Range2;

			public SeqRef<uint> Range3;

			public SeqRef<uint> Range4;

			public SeqRef<uint> Range5;

			public uint PresentID;

			public string Color;

			public string DeathAnim;

			public string ReviveAnim;

			public int IllustrationShow;
		}
	}
}
