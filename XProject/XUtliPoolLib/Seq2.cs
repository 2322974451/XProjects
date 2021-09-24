using System;

namespace XUtliPoolLib
{

	public struct Seq2<T>
	{

		public Seq2(T v0, T v1)
		{
			this.value0 = v0;
			this.value1 = v1;
		}

		public T value0;

		public T value1;
	}
}
