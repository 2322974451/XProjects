using System;

namespace XUtliPoolLib
{
	// Token: 0x02000152 RID: 338
	public class ProfSkillTable : CVSReader
	{
		// Token: 0x060007A7 RID: 1959 RVA: 0x00026B64 File Offset: 0x00024D64
		public ProfSkillTable.RowData GetByProfID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ProfSkillTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ProfID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00026BD0 File Offset: 0x00024DD0
		protected override void ReadLine(XBinaryReader reader)
		{
			ProfSkillTable.RowData rowData = new ProfSkillTable.RowData();
			base.Read<int>(reader, ref rowData.ProfID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ProfName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Skill1, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Skill2, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Skill3, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Skill4, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ProfIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ProfPic, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.ProfHeadIcon, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.ProfHeadIcon2, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<float>(reader, ref rowData.FixedEnmity, CVSReader.floatParse);
			this.columnno = 10;
			base.Read<float>(reader, ref rowData.EnmityCoefficient, CVSReader.floatParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.PromoteExperienceID, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.OperateLevel, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.PromoteLR, CVSReader.boolParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.ProfNameIcon, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.ProfIntro, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.ProfTypeIntro, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.ProfWord1, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.ProfWord2, CVSReader.stringParse);
			this.columnno = 20;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00026E28 File Offset: 0x00025028
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ProfSkillTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400039E RID: 926
		public ProfSkillTable.RowData[] Table = null;

		// Token: 0x02000351 RID: 849
		public class RowData
		{
			// Token: 0x04000D37 RID: 3383
			public int ProfID;

			// Token: 0x04000D38 RID: 3384
			public string ProfName;

			// Token: 0x04000D39 RID: 3385
			public string Skill1;

			// Token: 0x04000D3A RID: 3386
			public string Skill2;

			// Token: 0x04000D3B RID: 3387
			public string Skill3;

			// Token: 0x04000D3C RID: 3388
			public string Skill4;

			// Token: 0x04000D3D RID: 3389
			public string ProfIcon;

			// Token: 0x04000D3E RID: 3390
			public string ProfPic;

			// Token: 0x04000D3F RID: 3391
			public string ProfHeadIcon;

			// Token: 0x04000D40 RID: 3392
			public string ProfHeadIcon2;

			// Token: 0x04000D41 RID: 3393
			public float FixedEnmity;

			// Token: 0x04000D42 RID: 3394
			public float EnmityCoefficient;

			// Token: 0x04000D43 RID: 3395
			public string Description;

			// Token: 0x04000D44 RID: 3396
			public uint PromoteExperienceID;

			// Token: 0x04000D45 RID: 3397
			public uint OperateLevel;

			// Token: 0x04000D46 RID: 3398
			public bool PromoteLR;

			// Token: 0x04000D47 RID: 3399
			public string ProfNameIcon;

			// Token: 0x04000D48 RID: 3400
			public string ProfIntro;

			// Token: 0x04000D49 RID: 3401
			public string ProfTypeIntro;

			// Token: 0x04000D4A RID: 3402
			public string ProfWord1;

			// Token: 0x04000D4B RID: 3403
			public string ProfWord2;
		}
	}
}
