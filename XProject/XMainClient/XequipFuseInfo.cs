using System;

namespace XMainClient
{

	internal struct XequipFuseInfo
	{

		public uint BreakNum { get; set; }

		public uint FuseExp { get; set; }

		public void Init()
		{
			this.BreakNum = 0U;
			this.FuseExp = 0U;
		}
	}
}
