using System;

namespace XUtliPoolLib
{

	public class PVEAttrModify : CVSReader
	{

		public PVEAttrModify.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PVEAttrModify.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSceneID(key);
			}
			return result;
		}

		private PVEAttrModify.RowData BinarySearchSceneID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			PVEAttrModify.RowData rowData;
			PVEAttrModify.RowData rowData2;
			PVEAttrModify.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SceneID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SceneID == key;
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
				bool flag4 = rowData3.SceneID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SceneID.CompareTo(key) < 0;
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
			PVEAttrModify.RowData rowData = new PVEAttrModify.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PVEAttrModify.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PVEAttrModify.RowData[] Table = null;

		public class RowData
		{

			public uint SceneID;
		}
	}
}
