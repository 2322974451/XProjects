using System;
using System.Collections;
using System.Text;
using DeJson;

namespace XUtliPoolLib
{
	// Token: 0x0200009D RID: 157
	public class PUtil : XSingleton<PUtil>
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00015FC4 File Offset: 0x000141C4
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

		// Token: 0x060004D3 RID: 1235 RVA: 0x00015FF4 File Offset: 0x000141F4
		public T Deserialize<T>(string str)
		{
			return this.deserial.Deserialize<T>(str);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00016014 File Offset: 0x00014214
		public T Deserialize<T>(UnityEngine.Object o)
		{
			return this.deserial.Deserialize<T>(o);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00016034 File Offset: 0x00014234
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

		// Token: 0x040002C8 RID: 712
		private Deserializer _deserial;
	}
}
