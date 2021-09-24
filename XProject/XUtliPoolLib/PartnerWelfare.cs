using System;

namespace XUtliPoolLib
{

	public class PartnerWelfare : CVSReader
	{

		public PartnerWelfare.RowData GetById(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PartnerWelfare.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Id == key;
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
			PartnerWelfare.RowData rowData = new PartnerWelfare.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ContentTxt, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PartnerWelfare.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PartnerWelfare.RowData[] Table = null;

		public class RowData
		{

			public uint Id;

			public string ContentTxt;
		}
	}
}
