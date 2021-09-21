using System;

namespace XUtliPoolLib
{
	// Token: 0x02000172 RID: 370
	public class SpriteTable : CVSReader
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x0002A5D8 File Offset: 0x000287D8
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

		// Token: 0x06000821 RID: 2081 RVA: 0x0002A644 File Offset: 0x00028844
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

		// Token: 0x06000822 RID: 2082 RVA: 0x0002A6B0 File Offset: 0x000288B0
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

		// Token: 0x06000823 RID: 2083 RVA: 0x0002A994 File Offset: 0x00028B94
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

		// Token: 0x040003BE RID: 958
		public SpriteTable.RowData[] Table = null;

		// Token: 0x02000371 RID: 881
		public class RowData
		{
			// Token: 0x04000E77 RID: 3703
			public uint SpriteID;

			// Token: 0x04000E78 RID: 3704
			public string SpriteName;

			// Token: 0x04000E79 RID: 3705
			public uint SpriteQuality;

			// Token: 0x04000E7A RID: 3706
			public string SpriteIcon;

			// Token: 0x04000E7B RID: 3707
			public uint SpriteModelID;

			// Token: 0x04000E7C RID: 3708
			public uint SpriteSkillID;

			// Token: 0x04000E7D RID: 3709
			public uint AttrID1;

			// Token: 0x04000E7E RID: 3710
			public uint AttrID2;

			// Token: 0x04000E7F RID: 3711
			public uint AttrID3;

			// Token: 0x04000E80 RID: 3712
			public uint AttrID4;

			// Token: 0x04000E81 RID: 3713
			public uint AttrID5;

			// Token: 0x04000E82 RID: 3714
			public uint BaseAttr1;

			// Token: 0x04000E83 RID: 3715
			public uint BaseAttr2;

			// Token: 0x04000E84 RID: 3716
			public uint BaseAttr3;

			// Token: 0x04000E85 RID: 3717
			public uint BaseAttr4;

			// Token: 0x04000E86 RID: 3718
			public uint BaseAttr5;

			// Token: 0x04000E87 RID: 3719
			public SeqRef<uint> Range1;

			// Token: 0x04000E88 RID: 3720
			public SeqRef<uint> Range2;

			// Token: 0x04000E89 RID: 3721
			public SeqRef<uint> Range3;

			// Token: 0x04000E8A RID: 3722
			public SeqRef<uint> Range4;

			// Token: 0x04000E8B RID: 3723
			public SeqRef<uint> Range5;

			// Token: 0x04000E8C RID: 3724
			public uint PresentID;

			// Token: 0x04000E8D RID: 3725
			public string Color;

			// Token: 0x04000E8E RID: 3726
			public string DeathAnim;

			// Token: 0x04000E8F RID: 3727
			public string ReviveAnim;

			// Token: 0x04000E90 RID: 3728
			public int IllustrationShow;
		}
	}
}
