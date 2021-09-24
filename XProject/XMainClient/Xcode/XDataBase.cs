using System;

namespace XMainClient
{

	public abstract class XDataBase
	{

		public virtual void Recycle()
		{
		}

		public virtual void Init()
		{
		}

		public bool bRecycled = true;
	}
}
