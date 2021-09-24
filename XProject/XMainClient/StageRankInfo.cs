using System;

namespace XMainClient
{

	internal class StageRankInfo
	{

		public int Rank
		{
			get
			{
				switch (this._rank)
				{
				case 0:
					return 0;
				case 1:
				case 2:
				case 4:
					return 1;
				case 7:
					return 3;
				}
				return 2;
			}
		}

		public int RankValue
		{
			get
			{
				return this._rank;
			}
			set
			{
				this._rank = value;
			}
		}

		private int _rank;
	}
}
