using System;

namespace XMainClient
{

	internal interface XTimeoutHandler
	{

		void OnReport(int limit, int used);
	}
}
