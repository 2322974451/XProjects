using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	// Token: 0x0200088B RID: 2187
	public sealed class SubType
	{
		// Token: 0x17002A11 RID: 10769
		// (get) Token: 0x06008541 RID: 34113 RVA: 0x00108268 File Offset: 0x00106468
		public int FieldNumber
		{
			get
			{
				return this.fieldNumber;
			}
		}

		// Token: 0x17002A12 RID: 10770
		// (get) Token: 0x06008542 RID: 34114 RVA: 0x00108280 File Offset: 0x00106480
		public MetaType DerivedType
		{
			get
			{
				return this.derivedType;
			}
		}

		// Token: 0x06008543 RID: 34115 RVA: 0x00108298 File Offset: 0x00106498
		public SubType(int fieldNumber, MetaType derivedType, DataFormat format)
		{
			bool flag = derivedType == null;
			if (flag)
			{
				throw new ArgumentNullException("derivedType");
			}
			bool flag2 = fieldNumber <= 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			this.fieldNumber = fieldNumber;
			this.derivedType = derivedType;
			this.dataFormat = format;
		}

		// Token: 0x17002A13 RID: 10771
		// (get) Token: 0x06008544 RID: 34116 RVA: 0x001082EC File Offset: 0x001064EC
		internal IProtoSerializer Serializer
		{
			get
			{
				bool flag = this.serializer == null;
				if (flag)
				{
					this.serializer = this.BuildSerializer();
				}
				return this.serializer;
			}
		}

		// Token: 0x06008545 RID: 34117 RVA: 0x00108320 File Offset: 0x00106520
		private IProtoSerializer BuildSerializer()
		{
			WireType wireType = WireType.String;
			bool flag = this.dataFormat == DataFormat.Group;
			if (flag)
			{
				wireType = WireType.StartGroup;
			}
			IProtoSerializer tail = new SubItemSerializer(this.derivedType.Type, this.derivedType.GetKey(false, false), this.derivedType, false);
			return new TagDecorator(this.fieldNumber, wireType, false, tail);
		}

		// Token: 0x0400295F RID: 10591
		private readonly int fieldNumber;

		// Token: 0x04002960 RID: 10592
		private readonly MetaType derivedType;

		// Token: 0x04002961 RID: 10593
		private readonly DataFormat dataFormat;

		// Token: 0x04002962 RID: 10594
		private IProtoSerializer serializer;

		// Token: 0x0200194B RID: 6475
		internal sealed class Comparer : IComparer, IComparer<SubType>
		{
			// Token: 0x06010FD3 RID: 69587 RVA: 0x00452930 File Offset: 0x00450B30
			public int Compare(object x, object y)
			{
				return this.Compare(x as SubType, y as SubType);
			}

			// Token: 0x06010FD4 RID: 69588 RVA: 0x00452954 File Offset: 0x00450B54
			public int Compare(SubType x, SubType y)
			{
				bool flag = x == y;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					bool flag2 = x == null;
					if (flag2)
					{
						result = -1;
					}
					else
					{
						bool flag3 = y == null;
						if (flag3)
						{
							result = 1;
						}
						else
						{
							result = x.FieldNumber.CompareTo(y.FieldNumber);
						}
					}
				}
				return result;
			}

			// Token: 0x04007D78 RID: 32120
			public static readonly SubType.Comparer Default = new SubType.Comparer();
		}
	}
}
