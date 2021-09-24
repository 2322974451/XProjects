using System;

namespace XUtliPoolLib
{

	public class Prerogative : CVSReader
	{

		public Prerogative.RowData GetByLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			Prerogative.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchLevel(key);
			}
			return result;
		}

		private Prerogative.RowData BinarySearchLevel(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			Prerogative.RowData rowData;
			Prerogative.RowData rowData2;
			Prerogative.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.Level == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.Level == key;
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
				bool flag4 = rowData3.Level.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.Level.CompareTo(key) < 0;
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
			Prerogative.RowData rowData = new Prerogative.RowData();
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.MinDiamond, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.MinScore, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.PreSprite, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<uint>(reader, ref rowData.PreAuthor, CVSReader.uintParse);
			this.columnno = 4;
			rowData.PreIcon.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Prerogative.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public Prerogative.RowData[] Table = null;

		public class RowData
		{

			public uint Level;

			public uint MinDiamond;

			public uint MinScore;

			public string PreSprite;

			public uint[] PreAuthor;

			public SeqRef<string> PreIcon;
		}
	}
}
