using System;
using System.Collections.Generic;
using KKSG;

namespace XMainClient
{

	public class PkInfo
	{

		public uint percent
		{
			get
			{
				bool flag = this.win + this.lose == 0U;
				uint result;
				if (flag)
				{
					result = 100U;
				}
				else
				{
					bool flag2 = this.win == 0U;
					if (flag2)
					{
						result = 0U;
					}
					else
					{
						result = Math.Max(1U, 100U * this.win / (this.win + this.lose));
					}
				}
				return result;
			}
		}

		public RoleSmallInfo brief;

		public uint win;

		public uint lose;

		public uint point;

		public List<uint> records;
	}
}
