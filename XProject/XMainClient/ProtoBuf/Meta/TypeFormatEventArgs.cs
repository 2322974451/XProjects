using System;

namespace ProtoBuf.Meta
{
	// Token: 0x0200088C RID: 2188
	public class TypeFormatEventArgs : EventArgs
	{
		// Token: 0x17002A14 RID: 10772
		// (get) Token: 0x06008546 RID: 34118 RVA: 0x00108378 File Offset: 0x00106578
		// (set) Token: 0x06008547 RID: 34119 RVA: 0x00108390 File Offset: 0x00106590
		public Type Type
		{
			get
			{
				return this.type;
			}
			set
			{
				bool flag = this.type != value;
				if (flag)
				{
					bool flag2 = this.typeFixed;
					if (flag2)
					{
						throw new InvalidOperationException("The type is fixed and cannot be changed");
					}
					this.type = value;
				}
			}
		}

		// Token: 0x17002A15 RID: 10773
		// (get) Token: 0x06008548 RID: 34120 RVA: 0x001083CC File Offset: 0x001065CC
		// (set) Token: 0x06008549 RID: 34121 RVA: 0x001083E4 File Offset: 0x001065E4
		public string FormattedName
		{
			get
			{
				return this.formattedName;
			}
			set
			{
				bool flag = this.formattedName != value;
				if (flag)
				{
					bool flag2 = !this.typeFixed;
					if (flag2)
					{
						throw new InvalidOperationException("The formatted-name is fixed and cannot be changed");
					}
					this.formattedName = value;
				}
			}
		}

		// Token: 0x0600854A RID: 34122 RVA: 0x00108424 File Offset: 0x00106624
		internal TypeFormatEventArgs(string formattedName)
		{
			bool flag = Helpers.IsNullOrEmpty(formattedName);
			if (flag)
			{
				throw new ArgumentNullException("formattedName");
			}
			this.formattedName = formattedName;
		}

		// Token: 0x0600854B RID: 34123 RVA: 0x00108458 File Offset: 0x00106658
		internal TypeFormatEventArgs(Type type)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
			this.typeFixed = true;
		}

		// Token: 0x04002963 RID: 10595
		private Type type;

		// Token: 0x04002964 RID: 10596
		private string formattedName;

		// Token: 0x04002965 RID: 10597
		private readonly bool typeFixed;
	}
}
