using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XDeath : XSingleton<XDeath>
	{

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
