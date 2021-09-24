using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class geraint_fly_away
	{

		public static bool Do(List<XActor> actors)
		{
			bool flag = actors == null;
			bool result;
			if (flag)
			{
				geraint_fly_away._once = false;
				result = true;
			}
			else
			{
				bool once = geraint_fly_away._once;
				if (once)
				{
					result = false;
				}
				else
				{
					geraint_fly_away._once = true;
					List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
					foreach (XEntity xentity in ally)
					{
						bool flag2 = xentity.Attributes.TypeID == 3002U || xentity.Attributes.TypeID == 3001U;
						if (flag2)
						{
							xentity.EngineObject.Position = XResourceLoaderMgr.Far_Far_Away;
						}
					}
					result = true;
				}
			}
			return result;
		}

		private static bool _once = false;
	}
}
