using System;

namespace XUtliPoolLib
{

	public interface ISeqRef<T>
	{

		T this[int key]
		{
			get;
		}
	}
}
