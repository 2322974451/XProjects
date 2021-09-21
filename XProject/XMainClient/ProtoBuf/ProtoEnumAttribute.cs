using System;

namespace ProtoBuf
{
	// Token: 0x0200084D RID: 2125
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class ProtoEnumAttribute : Attribute
	{
		// Token: 0x1700294C RID: 10572
		// (get) Token: 0x0600828E RID: 33422 RVA: 0x000FAAE0 File Offset: 0x000F8CE0
		// (set) Token: 0x0600828F RID: 33423 RVA: 0x000FAAF8 File Offset: 0x000F8CF8
		public int Value
		{
			get
			{
				return this.enumValue;
			}
			set
			{
				this.enumValue = value;
				this.hasValue = true;
			}
		}

		// Token: 0x06008290 RID: 33424 RVA: 0x000FAB0C File Offset: 0x000F8D0C
		public bool HasValue()
		{
			return this.hasValue;
		}

		// Token: 0x1700294D RID: 10573
		// (get) Token: 0x06008291 RID: 33425 RVA: 0x000FAB24 File Offset: 0x000F8D24
		// (set) Token: 0x06008292 RID: 33426 RVA: 0x000FAB3C File Offset: 0x000F8D3C
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x04002885 RID: 10373
		private bool hasValue;

		// Token: 0x04002886 RID: 10374
		private int enumValue;

		// Token: 0x04002887 RID: 10375
		private string name;
	}
}
