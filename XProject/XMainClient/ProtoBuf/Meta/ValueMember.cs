using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using ProtoBuf.Serializers;

namespace ProtoBuf.Meta
{
	// Token: 0x0200088F RID: 2191
	public class ValueMember
	{
		// Token: 0x17002A17 RID: 10775
		// (get) Token: 0x0600858B RID: 34187 RVA: 0x0010A328 File Offset: 0x00108528
		public int FieldNumber
		{
			get
			{
				return this.fieldNumber;
			}
		}

		// Token: 0x17002A18 RID: 10776
		// (get) Token: 0x0600858C RID: 34188 RVA: 0x0010A340 File Offset: 0x00108540
		public MemberInfo Member
		{
			get
			{
				return this.member;
			}
		}

		// Token: 0x17002A19 RID: 10777
		// (get) Token: 0x0600858D RID: 34189 RVA: 0x0010A358 File Offset: 0x00108558
		public Type ItemType
		{
			get
			{
				return this.itemType;
			}
		}

		// Token: 0x17002A1A RID: 10778
		// (get) Token: 0x0600858E RID: 34190 RVA: 0x0010A370 File Offset: 0x00108570
		public Type MemberType
		{
			get
			{
				return this.memberType;
			}
		}

		// Token: 0x17002A1B RID: 10779
		// (get) Token: 0x0600858F RID: 34191 RVA: 0x0010A388 File Offset: 0x00108588
		public Type DefaultType
		{
			get
			{
				return this.defaultType;
			}
		}

		// Token: 0x17002A1C RID: 10780
		// (get) Token: 0x06008590 RID: 34192 RVA: 0x0010A3A0 File Offset: 0x001085A0
		public Type ParentType
		{
			get
			{
				return this.parentType;
			}
		}

		// Token: 0x17002A1D RID: 10781
		// (get) Token: 0x06008591 RID: 34193 RVA: 0x0010A3B8 File Offset: 0x001085B8
		// (set) Token: 0x06008592 RID: 34194 RVA: 0x0010A3D0 File Offset: 0x001085D0
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

		// Token: 0x06008593 RID: 34195 RVA: 0x0010A3E4 File Offset: 0x001085E4
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

		// Token: 0x06008594 RID: 34196 RVA: 0x0010A4E4 File Offset: 0x001086E4
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

		// Token: 0x06008595 RID: 34197 RVA: 0x0010A54C File Offset: 0x0010874C
		internal object GetRawEnumValue()
		{
			return ((FieldInfo)this.member).GetRawConstantValue();
		}

		// Token: 0x06008596 RID: 34198 RVA: 0x0010A570 File Offset: 0x00108770
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

		// Token: 0x17002A1E RID: 10782
		// (get) Token: 0x06008597 RID: 34199 RVA: 0x0010A810 File Offset: 0x00108A10
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

		// Token: 0x17002A1F RID: 10783
		// (get) Token: 0x06008598 RID: 34200 RVA: 0x0010A844 File Offset: 0x00108A44
		// (set) Token: 0x06008599 RID: 34201 RVA: 0x0010A85C File Offset: 0x00108A5C
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

		// Token: 0x17002A20 RID: 10784
		// (get) Token: 0x0600859A RID: 34202 RVA: 0x0010A870 File Offset: 0x00108A70
		// (set) Token: 0x0600859B RID: 34203 RVA: 0x0010A889 File Offset: 0x00108A89
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

		// Token: 0x17002A21 RID: 10785
		// (get) Token: 0x0600859C RID: 34204 RVA: 0x0010A898 File Offset: 0x00108A98
		// (set) Token: 0x0600859D RID: 34205 RVA: 0x0010A8B1 File Offset: 0x00108AB1
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

		// Token: 0x17002A22 RID: 10786
		// (get) Token: 0x0600859E RID: 34206 RVA: 0x0010A8C0 File Offset: 0x00108AC0
		// (set) Token: 0x0600859F RID: 34207 RVA: 0x0010A8D9 File Offset: 0x00108AD9
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

		// Token: 0x17002A23 RID: 10787
		// (get) Token: 0x060085A0 RID: 34208 RVA: 0x0010A8E8 File Offset: 0x00108AE8
		// (set) Token: 0x060085A1 RID: 34209 RVA: 0x0010A901 File Offset: 0x00108B01
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

		// Token: 0x17002A24 RID: 10788
		// (get) Token: 0x060085A2 RID: 34210 RVA: 0x0010A910 File Offset: 0x00108B10
		// (set) Token: 0x060085A3 RID: 34211 RVA: 0x0010A928 File Offset: 0x00108B28
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

		// Token: 0x17002A25 RID: 10789
		// (get) Token: 0x060085A4 RID: 34212 RVA: 0x0010A93C File Offset: 0x00108B3C
		// (set) Token: 0x060085A5 RID: 34213 RVA: 0x0010A954 File Offset: 0x00108B54
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

		// Token: 0x060085A6 RID: 34214 RVA: 0x0010A968 File Offset: 0x00108B68
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

		// Token: 0x060085A7 RID: 34215 RVA: 0x0010AA54 File Offset: 0x00108C54
		private void ThrowIfFrozen()
		{
			bool flag = this.serializer != null;
			if (flag)
			{
				throw new InvalidOperationException("The type cannot be changed once a serializer has been generated");
			}
		}

		// Token: 0x060085A8 RID: 34216 RVA: 0x0010AA7C File Offset: 0x00108C7C
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

		// Token: 0x060085A9 RID: 34217 RVA: 0x0010ADBC File Offset: 0x00108FBC
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

		// Token: 0x060085AA RID: 34218 RVA: 0x0010AE00 File Offset: 0x00109000
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

		// Token: 0x060085AB RID: 34219 RVA: 0x0010AE40 File Offset: 0x00109040
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

		// Token: 0x060085AC RID: 34220 RVA: 0x0010B23A File Offset: 0x0010943A
		internal void SetName(string name)
		{
			this.ThrowIfFrozen();
			this.name = name;
		}

		// Token: 0x17002A26 RID: 10790
		// (get) Token: 0x060085AD RID: 34221 RVA: 0x0010B24C File Offset: 0x0010944C
		public string Name
		{
			get
			{
				return Helpers.IsNullOrEmpty(this.name) ? this.member.Name : this.name;
			}
		}

		// Token: 0x060085AE RID: 34222 RVA: 0x0010B280 File Offset: 0x00109480
		private bool HasFlag(byte flag)
		{
			return (this.flags & flag) == flag;
		}

		// Token: 0x060085AF RID: 34223 RVA: 0x0010B2A0 File Offset: 0x001094A0
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

		// Token: 0x17002A27 RID: 10791
		// (get) Token: 0x060085B0 RID: 34224 RVA: 0x0010B2F4 File Offset: 0x001094F4
		// (set) Token: 0x060085B1 RID: 34225 RVA: 0x0010B30E File Offset: 0x0010950E
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

		// Token: 0x060085B2 RID: 34226 RVA: 0x0010B31C File Offset: 0x0010951C
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

		// Token: 0x04002969 RID: 10601
		private readonly int fieldNumber;

		// Token: 0x0400296A RID: 10602
		private readonly MemberInfo member;

		// Token: 0x0400296B RID: 10603
		private readonly Type parentType;

		// Token: 0x0400296C RID: 10604
		private readonly Type itemType;

		// Token: 0x0400296D RID: 10605
		private readonly Type defaultType;

		// Token: 0x0400296E RID: 10606
		private readonly Type memberType;

		// Token: 0x0400296F RID: 10607
		private object defaultValue;

		// Token: 0x04002970 RID: 10608
		private readonly RuntimeTypeModel model;

		// Token: 0x04002971 RID: 10609
		private IProtoSerializer serializer;

		// Token: 0x04002972 RID: 10610
		private DataFormat dataFormat;

		// Token: 0x04002973 RID: 10611
		private bool asReference;

		// Token: 0x04002974 RID: 10612
		private bool dynamicType;

		// Token: 0x04002975 RID: 10613
		private MethodInfo getSpecified;

		// Token: 0x04002976 RID: 10614
		private MethodInfo setSpecified;

		// Token: 0x04002977 RID: 10615
		private string name;

		// Token: 0x04002978 RID: 10616
		private const byte OPTIONS_IsStrict = 1;

		// Token: 0x04002979 RID: 10617
		private const byte OPTIONS_IsPacked = 2;

		// Token: 0x0400297A RID: 10618
		private const byte OPTIONS_IsRequired = 4;

		// Token: 0x0400297B RID: 10619
		private const byte OPTIONS_OverwriteList = 8;

		// Token: 0x0400297C RID: 10620
		private const byte OPTIONS_SupportNull = 16;

		// Token: 0x0400297D RID: 10621
		private byte flags;

		// Token: 0x0200194F RID: 6479
		internal sealed class Comparer : IComparer, IComparer<ValueMember>
		{
			// Token: 0x06010FE0 RID: 69600 RVA: 0x00452AE4 File Offset: 0x00450CE4
			public int Compare(object x, object y)
			{
				return this.Compare(x as ValueMember, y as ValueMember);
			}

			// Token: 0x06010FE1 RID: 69601 RVA: 0x00452B08 File Offset: 0x00450D08
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

			// Token: 0x04007D87 RID: 32135
			public static readonly ValueMember.Comparer Default = new ValueMember.Comparer();
		}
	}
}
