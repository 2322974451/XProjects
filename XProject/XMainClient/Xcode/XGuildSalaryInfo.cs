using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class XGuildSalaryInfo
	{

		public uint Score
		{
			get
			{
				return this.m_score;
			}
		}

		public uint TotalScore
		{
			get
			{
				return this.m_totalScore;
			}
		}

		public uint Grade
		{
			get
			{
				return this.m_grade;
			}
		}

		public uint Value
		{
			get
			{
				return this.m_value;
			}
		}

		public float Percent
		{
			get
			{
				return this.m_Percent;
			}
		}

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

		private uint m_score = 0U;

		private uint m_totalScore = 0U;

		private uint m_grade = 0U;

		private uint m_value;

		private float m_Percent = 0f;
	}
}
