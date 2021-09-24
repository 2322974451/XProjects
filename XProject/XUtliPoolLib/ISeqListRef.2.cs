using System;

namespace XUtliPoolLib
{

	public interface ISeqListRef<T>
	{

		T this[int index, int key]
		{
			get;
		}

		int Count { get; }
	}
}
