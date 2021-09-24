using System;
using XUtliPoolLib;

namespace XMainClient
{

	public abstract class XStaticDataBase<T> : XSingleton<T> where T : new()
	{

		public override bool Init()
		{
			bool bLoaded = this.m_bLoaded;
			bool result;
			if (bLoaded)
			{
				result = false;
			}
			else
			{
				this.OnInit();
				result = true;
			}
			return result;
		}

		public override void Uninit()
		{
			this.m_bLoaded = false;
		}

		protected abstract void OnInit();

		protected bool m_bLoaded;
	}
}
