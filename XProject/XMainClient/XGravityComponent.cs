using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FD9 RID: 4057
	internal sealed class XGravityComponent : XComponent
	{
		// Token: 0x170036CB RID: 14027
		// (get) Token: 0x0600D2B6 RID: 53942 RVA: 0x003145E4 File Offset: 0x003127E4
		public override uint ID
		{
			get
			{
				return XGravityComponent.uuID;
			}
		}

		// Token: 0x0600D2B7 RID: 53943 RVA: 0x003145FC File Offset: 0x003127FC
		public override void Update(float fDeltaT)
		{
			bool flag = !this._entity.GravityDisabled;
			if (flag)
			{
				this._entity.ApplyMove(0f, -1f, 0f);
			}
		}

		// Token: 0x04005FBD RID: 24509
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Entity_Gravity");
	}
}
