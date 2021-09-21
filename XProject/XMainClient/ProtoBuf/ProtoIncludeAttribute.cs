using System;
using System.ComponentModel;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000851 RID: 2129
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoIncludeAttribute : Attribute
	{
		// Token: 0x0600829A RID: 33434 RVA: 0x000FABB4 File Offset: 0x000F8DB4
		public ProtoIncludeAttribute(int tag, Type knownType) : this(tag, (knownType == null) ? "" : knownType.AssemblyQualifiedName)
		{
		}

		// Token: 0x0600829B RID: 33435 RVA: 0x000FABD0 File Offset: 0x000F8DD0
		public ProtoIncludeAttribute(int tag, string knownTypeName)
		{
			bool flag = tag <= 0;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("tag", "Tags must be positive integers");
			}
			bool flag2 = Helpers.IsNullOrEmpty(knownTypeName);
			if (flag2)
			{
				throw new ArgumentNullException("knownTypeName", "Known type cannot be blank");
			}
			this.tag = tag;
			this.knownTypeName = knownTypeName;
		}

		// Token: 0x1700294F RID: 10575
		// (get) Token: 0x0600829C RID: 33436 RVA: 0x000FAC30 File Offset: 0x000F8E30
		public int Tag
		{
			get
			{
				return this.tag;
			}
		}

		// Token: 0x17002950 RID: 10576
		// (get) Token: 0x0600829D RID: 33437 RVA: 0x000FAC48 File Offset: 0x000F8E48
		public string KnownTypeName
		{
			get
			{
				return this.knownTypeName;
			}
		}

		// Token: 0x17002951 RID: 10577
		// (get) Token: 0x0600829E RID: 33438 RVA: 0x000FAC60 File Offset: 0x000F8E60
		public Type KnownType
		{
			get
			{
				return TypeModel.ResolveKnownType(this.KnownTypeName, null, null);
			}
		}

		// Token: 0x17002952 RID: 10578
		// (get) Token: 0x0600829F RID: 33439 RVA: 0x000FAC80 File Offset: 0x000F8E80
		// (set) Token: 0x060082A0 RID: 33440 RVA: 0x000FAC98 File Offset: 0x000F8E98
		[DefaultValue(DataFormat.Default)]
		public DataFormat DataFormat
		{
			get
			{
				return this.dataFormat;
			}
			set
			{
				this.dataFormat = value;
			}
		}

		// Token: 0x04002889 RID: 10377
		private readonly int tag;

		// Token: 0x0400288A RID: 10378
		private readonly string knownTypeName;

		// Token: 0x0400288B RID: 10379
		private DataFormat dataFormat = DataFormat.Default;
	}
}
