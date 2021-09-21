using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D96 RID: 3478
	internal class newbie_level
	{
		// Token: 0x0600BD4B RID: 48459 RVA: 0x00273AD0 File Offset: 0x00271CD0
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

		// Token: 0x04004D0C RID: 19724
		private static bool _once = false;
	}
}
