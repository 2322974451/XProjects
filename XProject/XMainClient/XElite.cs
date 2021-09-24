using System;

namespace XMainClient
{

	internal sealed class XElite : XOpposer
	{

		public override bool Initilize(int flag)
		{
			base.Initilize(flag);
			this._eEntity_Type |= XEntity.EnitityType.Entity_Elite;
			return true;
		}
	}
}
