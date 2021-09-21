using System;

namespace XUtliPoolLib
{
	// Token: 0x02000132 RID: 306
	public class OverWatchTable : CVSReader
	{
		// Token: 0x06000739 RID: 1849 RVA: 0x00024300 File Offset: 0x00022500
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

		// Token: 0x0600073A RID: 1850 RVA: 0x0002436C File Offset: 0x0002256C
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

		// Token: 0x0600073B RID: 1851 RVA: 0x00024558 File Offset: 0x00022758
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

		// Token: 0x0400037E RID: 894
		public OverWatchTable.RowData[] Table = null;

		// Token: 0x02000331 RID: 817
		public class RowData
		{
			// Token: 0x04000C6C RID: 3180
			public uint HeroID;

			// Token: 0x04000C6D RID: 3181
			public uint[] StatisticsID;

			// Token: 0x04000C6E RID: 3182
			public SeqRef<uint> Price;

			// Token: 0x04000C6F RID: 3183
			public string Name;

			// Token: 0x04000C70 RID: 3184
			public string Icon;

			// Token: 0x04000C71 RID: 3185
			public string Description;

			// Token: 0x04000C72 RID: 3186
			public string CutSceneAniamtion;

			// Token: 0x04000C73 RID: 3187
			public string CutSceneIdleAni;

			// Token: 0x04000C74 RID: 3188
			public int SortID;

			// Token: 0x04000C75 RID: 3189
			public string Motto;

			// Token: 0x04000C76 RID: 3190
			public string MiniMapIcon;

			// Token: 0x04000C77 RID: 3191
			public float[] MobaAttributes;

			// Token: 0x04000C78 RID: 3192
			public string SelectAnim;

			// Token: 0x04000C79 RID: 3193
			public string[] SelectFx;

			// Token: 0x04000C7A RID: 3194
			public string HeroUseTips;

			// Token: 0x04000C7B RID: 3195
			public string MobaUseTips;

			// Token: 0x04000C7C RID: 3196
			public string IconAtlas;
		}
	}
}
