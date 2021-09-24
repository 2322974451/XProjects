using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{

	public sealed class SubType
	{

		public int FieldNumber
		{
			get
			{
				return this.fieldNumber;
			}
		}

		public MetaType DerivedType
		{
			get
			{
				return this.derivedType;
			}
		}

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

		private readonly int fieldNumber;

		private readonly MetaType derivedType;

		private readonly DataFormat dataFormat;

		private IProtoSerializer serializer;

		internal sealed class Comparer : IComparer, IComparer<SubType>
		{

			public int Compare(object x, object y)
			{
				return this.Compare(x as SubType, y as SubType);
			}

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

			public static readonly SubType.Comparer Default = new SubType.Comparer();
		}
	}
}
