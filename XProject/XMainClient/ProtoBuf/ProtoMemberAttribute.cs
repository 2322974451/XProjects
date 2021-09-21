using System;
using System.Reflection;

namespace ProtoBuf
{
	// Token: 0x02000852 RID: 2130
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ProtoMemberAttribute : Attribute, IComparable, IComparable<ProtoMemberAttribute>
	{
		// Token: 0x060082A1 RID: 33441 RVA: 0x000FACA4 File Offset: 0x000F8EA4
		public int CompareTo(object other)
		{
			return this.CompareTo(other as ProtoMemberAttribute);
		}

		// Token: 0x060082A2 RID: 33442 RVA: 0x000FACC4 File Offset: 0x000F8EC4
		public int CompareTo(ProtoMemberAttribute other)
		{
			bool flag = other == null;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = this == other;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					int num = this.tag.CompareTo(other.tag);
					bool flag3 = num == 0;
					if (flag3)
					{
						num = string.CompareOrdinal(this.name, other.name);
					}
					result = num;
				}
			}
			return result;
		}

		// Token: 0x060082A3 RID: 33443 RVA: 0x000FAD1D File Offset: 0x000F8F1D
		public ProtoMemberAttribute(int tag) : this(tag, false)
		{
		}

		// Token: 0x060082A4 RID: 33444 RVA: 0x000FAD2C File Offset: 0x000F8F2C
		internal ProtoMemberAttribute(int tag, bool forced)
		{
			bool flag = tag <= 0 && !forced;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("tag");
			}
			this.tag = tag;
		}

		// Token: 0x17002953 RID: 10579
		// (get) Token: 0x060082A5 RID: 33445 RVA: 0x000FAD64 File Offset: 0x000F8F64
		// (set) Token: 0x060082A6 RID: 33446 RVA: 0x000FAD7C File Offset: 0x000F8F7C
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

		// Token: 0x17002954 RID: 10580
		// (get) Token: 0x060082A7 RID: 33447 RVA: 0x000FAD88 File Offset: 0x000F8F88
		// (set) Token: 0x060082A8 RID: 33448 RVA: 0x000FADA0 File Offset: 0x000F8FA0
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

		// Token: 0x17002955 RID: 10581
		// (get) Token: 0x060082A9 RID: 33449 RVA: 0x000FADAC File Offset: 0x000F8FAC
		public int Tag
		{
			get
			{
				return this.tag;
			}
		}

		// Token: 0x060082AA RID: 33450 RVA: 0x000FADC4 File Offset: 0x000F8FC4
		internal void Rebase(int tag)
		{
			this.tag = tag;
		}

		// Token: 0x17002956 RID: 10582
		// (get) Token: 0x060082AB RID: 33451 RVA: 0x000FADD0 File Offset: 0x000F8FD0
		// (set) Token: 0x060082AC RID: 33452 RVA: 0x000FADF0 File Offset: 0x000F8FF0
		public bool IsRequired
		{
			get
			{
				return (this.options & MemberSerializationOptions.Required) == MemberSerializationOptions.Required;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.Required;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.Required;
				}
			}
		}

		// Token: 0x17002957 RID: 10583
		// (get) Token: 0x060082AD RID: 33453 RVA: 0x000FAE24 File Offset: 0x000F9024
		// (set) Token: 0x060082AE RID: 33454 RVA: 0x000FAE44 File Offset: 0x000F9044
		public bool IsPacked
		{
			get
			{
				return (this.options & MemberSerializationOptions.Packed) == MemberSerializationOptions.Packed;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.Packed;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.Packed;
				}
			}
		}

		// Token: 0x17002958 RID: 10584
		// (get) Token: 0x060082AF RID: 33455 RVA: 0x000FAE78 File Offset: 0x000F9078
		// (set) Token: 0x060082B0 RID: 33456 RVA: 0x000FAE98 File Offset: 0x000F9098
		public bool OverwriteList
		{
			get
			{
				return (this.options & MemberSerializationOptions.OverwriteList) == MemberSerializationOptions.OverwriteList;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.OverwriteList;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.OverwriteList;
				}
			}
		}

		// Token: 0x17002959 RID: 10585
		// (get) Token: 0x060082B1 RID: 33457 RVA: 0x000FAECC File Offset: 0x000F90CC
		// (set) Token: 0x060082B2 RID: 33458 RVA: 0x000FAEEC File Offset: 0x000F90EC
		public bool AsReference
		{
			get
			{
				return (this.options & MemberSerializationOptions.AsReference) == MemberSerializationOptions.AsReference;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.AsReference;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.AsReference;
				}
				this.options |= MemberSerializationOptions.AsReferenceHasValue;
			}
		}

		// Token: 0x1700295A RID: 10586
		// (get) Token: 0x060082B3 RID: 33459 RVA: 0x000FAF30 File Offset: 0x000F9130
		// (set) Token: 0x060082B4 RID: 33460 RVA: 0x000FAF50 File Offset: 0x000F9150
		internal bool AsReferenceHasValue
		{
			get
			{
				return (this.options & MemberSerializationOptions.AsReferenceHasValue) == MemberSerializationOptions.AsReferenceHasValue;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.AsReferenceHasValue;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.AsReferenceHasValue;
				}
			}
		}

		// Token: 0x1700295B RID: 10587
		// (get) Token: 0x060082B5 RID: 33461 RVA: 0x000FAF84 File Offset: 0x000F9184
		// (set) Token: 0x060082B6 RID: 33462 RVA: 0x000FAFA4 File Offset: 0x000F91A4
		public bool DynamicType
		{
			get
			{
				return (this.options & MemberSerializationOptions.DynamicType) == MemberSerializationOptions.DynamicType;
			}
			set
			{
				if (value)
				{
					this.options |= MemberSerializationOptions.DynamicType;
				}
				else
				{
					this.options &= ~MemberSerializationOptions.DynamicType;
				}
			}
		}

		// Token: 0x1700295C RID: 10588
		// (get) Token: 0x060082B7 RID: 33463 RVA: 0x000FAFD8 File Offset: 0x000F91D8
		// (set) Token: 0x060082B8 RID: 33464 RVA: 0x000FAFF0 File Offset: 0x000F91F0
		public MemberSerializationOptions Options
		{
			get
			{
				return this.options;
			}
			set
			{
				this.options = value;
			}
		}

		// Token: 0x0400288C RID: 10380
		internal MemberInfo Member;

		// Token: 0x0400288D RID: 10381
		internal bool TagIsPinned;

		// Token: 0x0400288E RID: 10382
		private string name;

		// Token: 0x0400288F RID: 10383
		private DataFormat dataFormat;

		// Token: 0x04002890 RID: 10384
		private int tag;

		// Token: 0x04002891 RID: 10385
		private MemberSerializationOptions options;
	}
}
