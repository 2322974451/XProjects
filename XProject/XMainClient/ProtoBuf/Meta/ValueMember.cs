using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{

	public class ValueMember
	{

		public int FieldNumber
		{
			get
			{
				return this.fieldNumber;
			}
		}

		public MemberInfo Member
		{
			get
			{
				return this.member;
			}
		}

		public Type ItemType
		{
			get
			{
				return this.itemType;
			}
		}

		public Type MemberType
		{
			get
			{
				return this.memberType;
			}
		}

		public Type DefaultType
		{
			get
			{
				return this.defaultType;
			}
		}

		public Type ParentType
		{
			get
			{
				return this.parentType;
			}
		}

		public object DefaultValue
		{
			get
			{
				return this.defaultValue;
			}
			set
			{
				this.ThrowIfFrozen();
				this.defaultValue = value;
			}
		}

		public ValueMember(RuntimeTypeModel model, Type parentType, int fieldNumber, MemberInfo member, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat, object defaultValue) : this(model, fieldNumber, memberType, itemType, defaultType, dataFormat)
		{
			bool flag = member == null;
			if (flag)
			{
				throw new ArgumentNullException("member");
			}
			bool flag2 = parentType == null;
			if (flag2)
			{
				throw new ArgumentNullException("parentType");
			}
			bool flag3 = fieldNumber < 1 && !Helpers.IsEnum(parentType);
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			this.member = member;
			this.parentType = parentType;
			bool flag4 = fieldNumber < 1 && !Helpers.IsEnum(parentType);
			if (flag4)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			bool flag5 = defaultValue != null && model.MapType(defaultValue.GetType()) != memberType;
			if (flag5)
			{
				defaultValue = ValueMember.ParseDefaultValue(memberType, defaultValue);
			}
			this.defaultValue = defaultValue;
			MetaType metaType = model.FindWithoutAdd(memberType);
			bool flag6 = metaType != null;
			if (flag6)
			{
				this.asReference = metaType.AsReferenceDefault;
			}
			else
			{
				this.asReference = MetaType.GetAsReferenceDefault(model, memberType);
			}
		}

		internal ValueMember(RuntimeTypeModel model, int fieldNumber, Type memberType, Type itemType, Type defaultType, DataFormat dataFormat)
		{
			bool flag = memberType == null;
			if (flag)
			{
				throw new ArgumentNullException("memberType");
			}
			bool flag2 = model == null;
			if (flag2)
			{
				throw new ArgumentNullException("model");
			}
			this.fieldNumber = fieldNumber;
			this.memberType = memberType;
			this.itemType = itemType;
			this.defaultType = defaultType;
			this.model = model;
			this.dataFormat = dataFormat;
		}

		internal object GetRawEnumValue()
		{
			return ((FieldInfo)this.member).GetRawConstantValue();
		}

		private static object ParseDefaultValue(Type type, object value)
		{
			Type underlyingType = Helpers.GetUnderlyingType(type);
			bool flag = underlyingType != null;
			if (flag)
			{
				type = underlyingType;
			}
			bool flag2 = value is string;
			if (flag2)
			{
				string text = (string)value;
				bool flag3 = Helpers.IsEnum(type);
				if (flag3)
				{
					return Helpers.ParseEnum(type, text);
				}
				ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
				switch (typeCode)
				{
				case ProtoTypeCode.Boolean:
					return bool.Parse(text);
				case ProtoTypeCode.Char:
				{
					bool flag4 = text.Length == 1;
					if (flag4)
					{
						return text[0];
					}
					throw new FormatException("Single character expected: \"" + text + "\"");
				}
				case ProtoTypeCode.SByte:
					return sbyte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Byte:
					return byte.Parse(text, NumberStyles.Integer, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int16:
					return short.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.UInt16:
					return ushort.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int32:
					return int.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.UInt32:
					return uint.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Int64:
					return long.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.UInt64:
					return ulong.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Single:
					return float.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Double:
					return double.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.Decimal:
					return decimal.Parse(text, NumberStyles.Any, CultureInfo.InvariantCulture);
				case ProtoTypeCode.DateTime:
					return DateTime.Parse(text, CultureInfo.InvariantCulture);
				case (ProtoTypeCode)17:
					break;
				case ProtoTypeCode.String:
					return text;
				default:
					switch (typeCode)
					{
					case ProtoTypeCode.TimeSpan:
						return TimeSpan.Parse(text);
					case ProtoTypeCode.Guid:
						return new Guid(text);
					case ProtoTypeCode.Uri:
						return text;
					}
					break;
				}
			}
			bool flag5 = Helpers.IsEnum(type);
			object result;
			if (flag5)
			{
				result = Enum.ToObject(type, value);
			}
			else
			{
				result = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
			}
			return result;
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

		public DataFormat DataFormat
		{
			get
			{
				return this.dataFormat;
			}
			set
			{
				this.ThrowIfFrozen();
				this.dataFormat = value;
			}
		}

		public bool IsStrict
		{
			get
			{
				return this.HasFlag(1);
			}
			set
			{
				this.SetFlag(1, value, true);
			}
		}

		public bool IsPacked
		{
			get
			{
				return this.HasFlag(2);
			}
			set
			{
				this.SetFlag(2, value, true);
			}
		}

		public bool OverwriteList
		{
			get
			{
				return this.HasFlag(8);
			}
			set
			{
				this.SetFlag(8, value, true);
			}
		}

		public bool IsRequired
		{
			get
			{
				return this.HasFlag(4);
			}
			set
			{
				this.SetFlag(4, value, true);
			}
		}

		public bool AsReference
		{
			get
			{
				return this.asReference;
			}
			set
			{
				this.ThrowIfFrozen();
				this.asReference = value;
			}
		}

		public bool DynamicType
		{
			get
			{
				return this.dynamicType;
			}
			set
			{
				this.ThrowIfFrozen();
				this.dynamicType = value;
			}
		}

		public void SetSpecified(MethodInfo getSpecified, MethodInfo setSpecified)
		{
			bool flag = getSpecified != null;
			if (flag)
			{
				bool flag2 = getSpecified.ReturnType != this.model.MapType(typeof(bool)) || getSpecified.IsStatic || getSpecified.GetParameters().Length != 0;
				if (flag2)
				{
					throw new ArgumentException("Invalid pattern for checking member-specified", "getSpecified");
				}
			}
			bool flag3 = setSpecified != null;
			if (flag3)
			{
				ParameterInfo[] parameters;
				bool flag4 = setSpecified.ReturnType != this.model.MapType(typeof(void)) || setSpecified.IsStatic || (parameters = setSpecified.GetParameters()).Length != 1 || parameters[0].ParameterType != this.model.MapType(typeof(bool));
				if (flag4)
				{
					throw new ArgumentException("Invalid pattern for setting member-specified", "setSpecified");
				}
			}
			this.ThrowIfFrozen();
			this.getSpecified = getSpecified;
			this.setSpecified = setSpecified;
		}

		private void ThrowIfFrozen()
		{
			bool flag = this.serializer != null;
			if (flag)
			{
				throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
			}
		}

		private IProtoSerializer BuildSerializer()
		{
			int opaqueToken = 0;
			IProtoSerializer result;
			try
			{
				this.model.TakeLock(ref opaqueToken);
				Type type = (this.itemType == null) ? this.memberType : this.itemType;
				WireType wireType;
				IProtoSerializer protoSerializer = ValueMember.TryGetCoreSerializer(this.model, this.dataFormat, type, out wireType, this.asReference, this.dynamicType, this.OverwriteList, true);
				bool flag = protoSerializer == null;
				if (flag)
				{
					throw new InvalidOperationException("No serializer defined for type: " + type.FullName);
				}
				bool flag2 = this.itemType != null && this.SupportNull;
				if (flag2)
				{
					bool isPacked = this.IsPacked;
					if (isPacked)
					{
						throw new NotSupportedException("Packed encodings cannot support null values");
					}
					protoSerializer = new TagDecorator(1, wireType, this.IsStrict, protoSerializer);
					protoSerializer = new NullDecorator(this.model, protoSerializer);
					protoSerializer = new TagDecorator(this.fieldNumber, WireType.StartGroup, false, protoSerializer);
				}
				else
				{
					protoSerializer = new TagDecorator(this.fieldNumber, wireType, this.IsStrict, protoSerializer);
				}
				bool flag3 = this.itemType != null;
				if (flag3)
				{
					Type type2 = this.SupportNull ? this.itemType : (Helpers.GetUnderlyingType(this.itemType) ?? this.itemType);
					Helpers.DebugAssert(type2 == protoSerializer.ExpectedType, "Wrong type in the tail; expected {0}, received {1}", new object[]
					{
						protoSerializer.ExpectedType,
						type2
					});
					bool isArray = this.memberType.IsArray;
					if (isArray)
					{
						protoSerializer = new ArrayDecorator(this.model, protoSerializer, this.fieldNumber, this.IsPacked, wireType, this.memberType, this.OverwriteList, this.SupportNull);
					}
					else
					{
						protoSerializer = ListDecorator.Create(this.model, this.memberType, this.defaultType, protoSerializer, this.fieldNumber, this.IsPacked, wireType, this.member != null && PropertyDecorator.CanWrite(this.model, this.member), this.OverwriteList, this.SupportNull);
					}
				}
				else
				{
					bool flag4 = this.defaultValue != null && !this.IsRequired && this.getSpecified == null;
					if (flag4)
					{
						protoSerializer = new DefaultValueDecorator(this.model, this.defaultValue, protoSerializer);
					}
				}
				bool flag5 = this.memberType == this.model.MapType(typeof(Uri));
				if (flag5)
				{
					protoSerializer = new UriDecorator(this.model, protoSerializer);
				}
				bool flag6 = this.member != null;
				if (flag6)
				{
					PropertyInfo propertyInfo = this.member as PropertyInfo;
					bool flag7 = propertyInfo != null;
					if (flag7)
					{
						protoSerializer = new PropertyDecorator(this.model, this.parentType, (PropertyInfo)this.member, protoSerializer);
					}
					else
					{
						FieldInfo fieldInfo = this.member as FieldInfo;
						bool flag8 = fieldInfo != null;
						if (!flag8)
						{
							throw new InvalidOperationException();
						}
						protoSerializer = new FieldDecorator(this.parentType, (FieldInfo)this.member, protoSerializer);
					}
					bool flag9 = this.getSpecified != null || this.setSpecified != null;
					if (flag9)
					{
						protoSerializer = new MemberSpecifiedDecorator(this.getSpecified, this.setSpecified, protoSerializer);
					}
				}
				result = protoSerializer;
			}
			finally
			{
				this.model.ReleaseLock(opaqueToken);
			}
			return result;
		}

		private static WireType GetIntWireType(DataFormat format, int width)
		{
			WireType result;
			switch (format)
			{
			case DataFormat.Default:
			case DataFormat.TwosComplement:
				result = WireType.Variant;
				break;
			case DataFormat.ZigZag:
				result = WireType.SignedVariant;
				break;
			case DataFormat.FixedSize:
				result = ((width == 32) ? WireType.Fixed32 : WireType.Fixed64);
				break;
			default:
				throw new InvalidOperationException();
			}
			return result;
		}

		private static WireType GetDateTimeWireType(DataFormat format)
		{
			switch (format)
			{
			case DataFormat.Default:
				return WireType.String;
			case DataFormat.FixedSize:
				return WireType.Fixed64;
			case DataFormat.Group:
				return WireType.StartGroup;
			}
			throw new InvalidOperationException();
		}

		internal static IProtoSerializer TryGetCoreSerializer(RuntimeTypeModel model, DataFormat dataFormat, Type type, out WireType defaultWireType, bool asReference, bool dynamicType, bool overwriteList, bool allowComplexTypes)
		{
			Type underlyingType = Helpers.GetUnderlyingType(type);
			bool flag = underlyingType != null;
			if (flag)
			{
				type = underlyingType;
			}
			bool flag2 = Helpers.IsEnum(type);
			IProtoSerializer result;
			if (flag2)
			{
				bool flag3 = allowComplexTypes && model != null;
				if (flag3)
				{
					defaultWireType = WireType.Variant;
					result = new EnumSerializer(type, model.GetEnumMap(type));
				}
				else
				{
					defaultWireType = WireType.None;
					result = null;
				}
			}
			else
			{
				ProtoTypeCode typeCode = Helpers.GetTypeCode(type);
				ProtoTypeCode protoTypeCode = typeCode;
				switch (protoTypeCode)
				{
				case ProtoTypeCode.Boolean:
					defaultWireType = WireType.Variant;
					return new BooleanSerializer(model);
				case ProtoTypeCode.Char:
					defaultWireType = WireType.Variant;
					return new CharSerializer(model);
				case ProtoTypeCode.SByte:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new SByteSerializer(model);
				case ProtoTypeCode.Byte:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new ByteSerializer(model);
				case ProtoTypeCode.Int16:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new Int16Serializer(model);
				case ProtoTypeCode.UInt16:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new UInt16Serializer(model);
				case ProtoTypeCode.Int32:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new Int32Serializer(model);
				case ProtoTypeCode.UInt32:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 32);
					return new UInt32Serializer(model);
				case ProtoTypeCode.Int64:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 64);
					return new Int64Serializer(model);
				case ProtoTypeCode.UInt64:
					defaultWireType = ValueMember.GetIntWireType(dataFormat, 64);
					return new UInt64Serializer(model);
				case ProtoTypeCode.Single:
					defaultWireType = WireType.Fixed32;
					return new SingleSerializer(model);
				case ProtoTypeCode.Double:
					defaultWireType = WireType.Fixed64;
					return new DoubleSerializer(model);
				case ProtoTypeCode.Decimal:
					defaultWireType = WireType.String;
					return new DecimalSerializer(model);
				case ProtoTypeCode.DateTime:
					defaultWireType = ValueMember.GetDateTimeWireType(dataFormat);
					return new DateTimeSerializer(model);
				case (ProtoTypeCode)17:
					break;
				case ProtoTypeCode.String:
					defaultWireType = WireType.String;
					if (asReference)
					{
						return new NetObjectSerializer(model, model.MapType(typeof(string)), 0, BclHelpers.NetObjectOptions.AsReference);
					}
					return new StringSerializer(model);
				default:
					switch (protoTypeCode)
					{
					case ProtoTypeCode.TimeSpan:
						defaultWireType = ValueMember.GetDateTimeWireType(dataFormat);
						return new TimeSpanSerializer(model);
					case ProtoTypeCode.ByteArray:
						defaultWireType = WireType.String;
						return new BlobSerializer(model, overwriteList);
					case ProtoTypeCode.Guid:
						defaultWireType = WireType.String;
						return new GuidSerializer(model);
					case ProtoTypeCode.Uri:
						defaultWireType = WireType.String;
						return new StringSerializer(model);
					case ProtoTypeCode.Type:
						defaultWireType = WireType.String;
						return new SystemTypeSerializer(model);
					}
					break;
				}
				IProtoSerializer protoSerializer = model.AllowParseableTypes ? ParseableSerializer.TryCreate(type, model) : null;
				bool flag4 = protoSerializer != null;
				if (flag4)
				{
					defaultWireType = WireType.String;
					result = protoSerializer;
				}
				else
				{
					bool flag5 = allowComplexTypes && model != null;
					if (flag5)
					{
						int key = model.GetKey(type, false, true);
						bool flag6 = asReference || dynamicType;
						if (flag6)
						{
							defaultWireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
							BclHelpers.NetObjectOptions netObjectOptions = BclHelpers.NetObjectOptions.None;
							if (asReference)
							{
								netObjectOptions |= BclHelpers.NetObjectOptions.AsReference;
							}
							if (dynamicType)
							{
								netObjectOptions |= BclHelpers.NetObjectOptions.DynamicType;
							}
							bool flag7 = key >= 0;
							if (flag7)
							{
								bool flag8 = asReference && Helpers.IsValueType(type);
								if (flag8)
								{
									string text = "AsReference cannot be used with value-types";
									bool flag9 = type.Name == "KeyValuePair`2";
									if (flag9)
									{
										text += "; please see http://stackoverflow.com/q/14436606/";
									}
									else
									{
										text = text + ": " + type.FullName;
									}
									throw new InvalidOperationException(text);
								}
								MetaType metaType = model[type];
								bool flag10 = asReference && metaType.IsAutoTuple;
								if (flag10)
								{
									netObjectOptions |= BclHelpers.NetObjectOptions.LateSet;
								}
								bool useConstructor = metaType.UseConstructor;
								if (useConstructor)
								{
									netObjectOptions |= BclHelpers.NetObjectOptions.UseConstructor;
								}
							}
							return new NetObjectSerializer(model, type, key, netObjectOptions);
						}
						bool flag11 = key >= 0;
						if (flag11)
						{
							defaultWireType = ((dataFormat == DataFormat.Group) ? WireType.StartGroup : WireType.String);
							return new SubItemSerializer(type, key, model[type], true);
						}
					}
					defaultWireType = WireType.None;
					result = null;
				}
			}
			return result;
		}

		internal void SetName(string name)
		{
			this.ThrowIfFrozen();
			this.name = name;
		}

		public string Name
		{
			get
			{
				return Helpers.IsNullOrEmpty(this.name) ? this.member.Name : this.name;
			}
		}

		private bool HasFlag(byte flag)
		{
			return (this.flags & flag) == flag;
		}

		private void SetFlag(byte flag, bool value, bool throwIfFrozen)
		{
			bool flag2 = throwIfFrozen && this.HasFlag(flag) != value;
			if (flag2)
			{
				this.ThrowIfFrozen();
			}
			if (value)
			{
				this.flags |= flag;
			}
			else
			{
				this.flags &= (byte)~flag;
			}
		}

		public bool SupportNull
		{
			get
			{
				return this.HasFlag(16);
			}
			set
			{
				this.SetFlag(16, value, true);
			}
		}

		internal string GetSchemaTypeName(bool applyNetObjectProxy, ref bool requiresBclImport)
		{
			Type type = this.ItemType;
			bool flag = type == null;
			if (flag)
			{
				type = this.MemberType;
			}
			return this.model.GetSchemaTypeName(type, this.DataFormat, applyNetObjectProxy && this.asReference, applyNetObjectProxy && this.dynamicType, ref requiresBclImport);
		}

		private readonly int fieldNumber;

		private readonly MemberInfo member;

		private readonly Type parentType;

		private readonly Type itemType;

		private readonly Type defaultType;

		private readonly Type memberType;

		private object defaultValue;

		private readonly RuntimeTypeModel model;

		private IProtoSerializer serializer;

		private DataFormat dataFormat;

		private bool asReference;

		private bool dynamicType;

		private MethodInfo getSpecified;

		private MethodInfo setSpecified;

		private string name;

		private const byte OPTIONS_IsStrict = 1;

		private const byte OPTIONS_IsPacked = 2;

		private const byte OPTIONS_IsRequired = 4;

		private const byte OPTIONS_OverwriteList = 8;

		private const byte OPTIONS_SupportNull = 16;

		private byte flags;

		internal sealed class Comparer : IComparer, IComparer<ValueMember>
		{

			public int Compare(object x, object y)
			{
				return this.Compare(x as ValueMember, y as ValueMember);
			}

			public int Compare(ValueMember x, ValueMember y)
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

			public static readonly ValueMember.Comparer Default = new ValueMember.Comparer();
		}
	}
}
