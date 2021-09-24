using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class newbie_level_end
	{

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
