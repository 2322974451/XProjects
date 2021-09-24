using System;

namespace XMainClient
{

	internal interface ILogData : IComparable<ILogData>
	{

		string GetContent();

		string GetTime();
	}
}
