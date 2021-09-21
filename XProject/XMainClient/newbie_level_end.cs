using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000D97 RID: 3479
	internal class newbie_level_end
	{
		// Token: 0x0600BD4E RID: 48462 RVA: 0x00273B3C File Offset: 0x00271D3C
		public static bool Do(List<XActor> actors)
		{
			bool flag = actors == null;
			if (flag)
			{
				XAutoFade.MakeBlack(true);
			}
			return true;
		}
	}
}
