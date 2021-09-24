using System;

namespace XUtliPoolLib
{

	public class ProfSkillTable : CVSReader
	{

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

		public ProfSkillTable.RowData[] Table = null;

		public class RowData
		{

			public int ProfID;

			public string ProfName;

			public string Skill1;

			public string Skill2;

			public string Skill3;

			public string Skill4;

			public string ProfIcon;

			public string ProfPic;

			public string ProfHeadIcon;

			public string ProfHeadIcon2;

			public float FixedEnmity;

			public float EnmityCoefficient;

			public string Description;

			public uint PromoteExperienceID;

			public uint OperateLevel;

			public bool PromoteLR;

			public string ProfNameIcon;

			public string ProfIntro;

			public string ProfTypeIntro;

			public string ProfWord1;

			public string ProfWord2;
		}
	}
}
