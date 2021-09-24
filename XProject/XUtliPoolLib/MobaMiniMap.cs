using System;

namespace XUtliPoolLib
{

	public class MobaMiniMap : CVSReader
	{

		public MobaMiniMap.RowData GetByPosIndex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaMiniMap.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchPosIndex(key);
			}
			return result;
		}

		private MobaMiniMap.RowData BinarySearchPosIndex(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			MobaMiniMap.RowData rowData;
			MobaMiniMap.RowData rowData2;
			MobaMiniMap.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.PosIndex == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.PosIndex == key;
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
				bool flag4 = rowData3.PosIndex.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.PosIndex.CompareTo(key) < 0;
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
			MobaMiniMap.RowData rowData = new MobaMiniMap.RowData();
			base.Read<uint>(reader, ref rowData.PosIndex, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Position.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaMiniMap.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MobaMiniMap.RowData[] Table = null;

		public class RowData
		{

			public uint PosIndex;

			public SeqRef<float> Position;

			public string[] Icon;
		}
	}
}
