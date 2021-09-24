using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal interface ILogSource
	{

		List<ILogData> GetLogList();
	}
}
