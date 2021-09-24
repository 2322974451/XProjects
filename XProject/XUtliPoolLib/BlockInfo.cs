using System;

namespace XUtliPoolLib
{

	public struct BlockInfo
	{

		public BlockInfo(int s, int c)
		{
			this.size = s;
			this.count = c;
		}

		public int size;

		public int count;
	}
}
