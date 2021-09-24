using System;

namespace XMainClient
{

	public class EquipFuseData
	{

		public uint AttrId { get; set; }

		public uint BeforeBaseAttrNum { get; set; }

		public uint BeforeAddNum { get; set; }

		public uint AfterAddNum { get; set; }

		public bool IsExtra { get; set; }

		public uint UpNum
		{
			get
			{
				return (this.AfterAddNum > this.BeforeAddNum) ? (this.AfterAddNum - this.BeforeAddNum) : 0U;
			}
		}

		public void Init()
		{
			this.AttrId = 0U;
			this.BeforeAddNum = 0U;
			this.AfterAddNum = 0U;
			this.IsExtra = false;
		}
	}
}
