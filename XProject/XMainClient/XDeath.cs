using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FF5 RID: 4085
	internal sealed class XDeath : XSingleton<XDeath>
	{
		// Token: 0x0600D47D RID: 54397 RVA: 0x003217CC File Offset: 0x0031F9CC
		public void DeathDetect(XEntity entity, XEntity killer, bool bForce)
		{
			bool flag = bForce || entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) <= 0.0;
			if (flag)
			{
				entity.TriggerDeath(killer);
			}
		}
	}
}
