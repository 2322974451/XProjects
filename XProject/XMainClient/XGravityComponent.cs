using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XGravityComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XGravityComponent.uuID;
			}
		}

		public override void Update(float fDeltaT)
		{
			bool flag = !this._entity.GravityDisabled;
			if (flag)
			{
				this._entity.ApplyMove(0f, -1f, 0f);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Entity_Gravity");
	}
}
