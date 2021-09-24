using System;

namespace XUtliPoolLib
{

	public abstract class XSingleton<T> : XBaseSingleton where T : new()
	{

		protected XSingleton()
		{
			bool flag = XSingleton<T>._instance != null;
			if (flag)
			{
				T instance = XSingleton<T>._instance;
				throw new XDoubleNewException(instance.ToString() + " can not be created again.");
			}
		}

		public static T singleton
		{
			get
			{
				return XSingleton<T>._instance;
			}
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}

		private static readonly T _instance = Activator.CreateInstance<T>();
	}
}
