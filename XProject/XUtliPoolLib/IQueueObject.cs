using System;

namespace XUtliPoolLib
{

	public interface IQueueObject
	{

		IQueueObject next { get; set; }
	}
}
