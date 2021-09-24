using System;

namespace XMainClient
{

	internal interface ICostHandler
	{

		CostInfo GetCost(int i);

		bool ParseCostConfigString(string str);
	}
}
