using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class newbie_level
	{

		public static bool Do(List<XActor> actors)
		{
			bool flag = actors == null;
			if (flag)
			{
				XSingleton<XCutScene>.singleton.IsExcludeNewBorn = true;
				XSingleton<XLevelScriptMgr>.singleton.SetExternalString("npctalk", true);
				newbie_level._once = false;
			}
			else
			{
				bool flag2 = !newbie_level._once;
				if (flag2)
				{
					XSingleton<XCutScene>.singleton.IsExcludeNewBorn = false;
					newbie_level._once = true;
				}
			}
			return true;
		}

		private static bool _once = false;
	}
}
