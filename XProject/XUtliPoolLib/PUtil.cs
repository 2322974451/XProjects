using System;
using System.Collections;
using System.Text;
using DeJson;

namespace XUtliPoolLib
{

	public class PUtil : XSingleton<PUtil>
	{

		public Deserializer deserial
		{
			get
			{
				bool flag = this._deserial == null;
				if (flag)
				{
					this._deserial = new Deserializer();
				}
				return this._deserial;
			}
		}

		public T Deserialize<T>(string str)
		{
			return this.deserial.Deserialize<T>(str);
		}

		public T Deserialize<T>(UnityEngine.Object o)
		{
			return this.deserial.Deserialize<T>(o);
		}

		public string SerializeArray(IList array)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('[');
			int num = 0;
			foreach (UnityEngine.Object value in array)
			{
				num++;
				bool flag = num < array.Count;
				if (flag)
				{
					stringBuilder.Append(value);
					stringBuilder.Append(',');
				}
				else
				{
					stringBuilder.Append(value);
				}
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}

		private Deserializer _deserial;
	}
}
