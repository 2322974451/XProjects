using System;

namespace XUtliPoolLib
{

	public class SkillEmblem : CVSReader
	{

		public SkillEmblem.RowData GetByEmblemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SkillEmblem.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchEmblemID(key);
			}
			return result;
		}

		private SkillEmblem.RowData BinarySearchEmblemID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SkillEmblem.RowData rowData;
			SkillEmblem.RowData rowData2;
			SkillEmblem.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.EmblemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.EmblemID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.EmblemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.EmblemID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			SkillEmblem.RowData rowData = new SkillEmblem.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SkillScript, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.SkillType, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.SkillPercent, CVSReader.byteParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SkillName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SkillPPT, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ExSkillScript, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.OtherSkillScripts, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillEmblem.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SkillEmblem.RowData[] Table = null;

		public class RowData
		{

			public uint EmblemID;

			public string SkillScript;

			public byte SkillType;

			public byte SkillPercent;

			public string SkillName;

			public uint SkillPPT;

			public string ExSkillScript;

			public string[] OtherSkillScripts;
		}
	}
}
