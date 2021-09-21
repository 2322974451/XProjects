using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000939 RID: 2361
	public class XGuildSalaryInfo
	{
		// Token: 0x17002C03 RID: 11267
		// (get) Token: 0x06008EA8 RID: 36520 RVA: 0x0013C5DC File Offset: 0x0013A7DC
		public uint Score
		{
			get
			{
				return this.m_score;
			}
		}

		// Token: 0x17002C04 RID: 11268
		// (get) Token: 0x06008EA9 RID: 36521 RVA: 0x0013C5F4 File Offset: 0x0013A7F4
		public uint TotalScore
		{
			get
			{
				return this.m_totalScore;
			}
		}

		// Token: 0x17002C05 RID: 11269
		// (get) Token: 0x06008EAA RID: 36522 RVA: 0x0013C60C File Offset: 0x0013A80C
		public uint Grade
		{
			get
			{
				return this.m_grade;
			}
		}

		// Token: 0x17002C06 RID: 11270
		// (get) Token: 0x06008EAB RID: 36523 RVA: 0x0013C624 File Offset: 0x0013A824
		public uint Value
		{
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x17002C07 RID: 11271
		// (get) Token: 0x06008EAC RID: 36524 RVA: 0x0013C63C File Offset: 0x0013A83C
		public float Percent
		{
			get
			{
				return this.m_Percent;
			}
		}

		// Token: 0x06008EAD RID: 36525 RVA: 0x0013C654 File Offset: 0x0013A854
		public void Init(uint value, GuildSalaryTable.RowData rowData, uint index)
		{
			this.m_value = value;
			bool flag = rowData == null;
			if (!flag)
			{
				switch (index)
				{
				case 0U:
					this.CalculateScore(ref rowData.NumberTransformation, value);
					break;
				case 1U:
					this.CalculateScore(ref rowData.PrestigeTransformation, value);
					break;
				case 2U:
					this.CalculateScore(ref rowData.ActiveTransformation, value);
					break;
				case 3U:
					this.CalculateScore(ref rowData.EXPTransformation, value);
					break;
				}
				this.CalculateGrade(rowData.GuildReview, this.m_score);
			}
		}

		// Token: 0x06008EAE RID: 36526 RVA: 0x0013C6E0 File Offset: 0x0013A8E0
		private void CalculateScore(ref SeqListRef<uint> transformation, uint value)
		{
			uint num = transformation[0, 0];
			uint num2 = transformation[0, 1];
			uint num3 = transformation[1, 0];
			uint num4 = transformation[1, 1];
			this.m_totalScore = num2;
			bool flag = value > num2;
			if (flag)
			{
				value = num2;
			}
			this.m_Percent = value / num2;
			float num5 = this.m_Percent * num4;
			this.m_score = (uint)Math.Floor((double)num5);
		}

		// Token: 0x06008EAF RID: 36527 RVA: 0x0013C750 File Offset: 0x0013A950
		private void CalculateGrade(uint[] scores, uint cur)
		{
			this.m_grade = 1U;
			bool flag = scores != null;
			if (flag)
			{
				for (int i = scores.Length - 1; i >= 0; i--)
				{
					bool flag2 = cur < scores[i];
					if (!flag2)
					{
						break;
					}
					this.m_grade += 1U;
				}
			}
		}

		// Token: 0x04002E93 RID: 11923
		private uint m_score = 0U;

		// Token: 0x04002E94 RID: 11924
		private uint m_totalScore = 0U;

		// Token: 0x04002E95 RID: 11925
		private uint m_grade = 0U;

		// Token: 0x04002E96 RID: 11926
		private uint m_value;

		// Token: 0x04002E97 RID: 11927
		private float m_Percent = 0f;
	}
}
