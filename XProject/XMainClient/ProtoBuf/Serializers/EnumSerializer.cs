using System;
using XUtliPoolLib;

namespace ProtoBuf.Serializers
{

	internal sealed class EnumSerializer : IProtoSerializer
	{

		public EnumSerializer(Type enumType, EnumSerializer.EnumPair[] map)
		{
			bool flag = enumType == null;
			if (flag)
			{
				throw new ArgumentNullException("enumType");
			}
			this.enumType = enumType;
			this.map = map;
			bool flag2 = map != null;
			if (flag2)
			{
				for (int i = 1; i < map.Length; i++)
				{
					for (int j = 0; j < i; j++)
					{
						bool flag3 = map[i].WireValue == map[j].WireValue && !object.Equals(map[i].RawValue, map[j].RawValue);
						if (flag3)
						{
							throw new ProtoException("Multiple enums with wire-value " + map[i].WireValue.ToString());
						}
						bool flag4 = object.Equals(map[i].RawValue, map[j].RawValue) && map[i].WireValue != map[j].WireValue;
						if (flag4)
						{
							throw new ProtoException("Multiple enums with deserialized-value " + map[i].RawValue);
						}
					}
				}
			}
		}

		private ProtoTypeCode GetTypeCode()
		{
			Type underlyingType = Helpers.GetUnderlyingType(this.enumType);
			bool flag = underlyingType == null;
			if (flag)
			{
				underlyingType = this.enumType;
			}
			return Helpers.GetTypeCode(underlyingType);
		}

		public Type ExpectedType
		{
			get
			{
				return this.enumType;
			}
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		private int EnumToWire(object value)
		{
			int result;
			switch (this.GetTypeCode())
			{
			case ProtoTypeCode.SByte:
				result = (int)((sbyte)value);
				break;
			case ProtoTypeCode.Byte:
				result = (int)((byte)value);
				break;
			case ProtoTypeCode.Int16:
				result = (int)((short)value);
				break;
			case ProtoTypeCode.UInt16:
				result = (int)((ushort)value);
				break;
			case ProtoTypeCode.Int32:
				result = (int)value;
				break;
			case ProtoTypeCode.UInt32:
				result = (int)((uint)value);
				break;
			case ProtoTypeCode.Int64:
				result = (int)((long)value);
				break;
			case ProtoTypeCode.UInt64:
				result = (int)((ulong)value);
				break;
			default:
				throw new InvalidOperationException();
			}
			return result;
		}

		private object WireToEnum(int value)
		{
			object result;
			switch (this.GetTypeCode())
			{
			case ProtoTypeCode.SByte:
				result = Enum.ToObject(this.enumType, (sbyte)value);
				break;
			case ProtoTypeCode.Byte:
				result = Enum.ToObject(this.enumType, (byte)value);
				break;
			case ProtoTypeCode.Int16:
				result = Enum.ToObject(this.enumType, (short)value);
				break;
			case ProtoTypeCode.UInt16:
				result = Enum.ToObject(this.enumType, (ushort)value);
				break;
			case ProtoTypeCode.Int32:
				result = Enum.ToObject(this.enumType, value);
				break;
			case ProtoTypeCode.UInt32:
				result = Enum.ToObject(this.enumType, (uint)value);
				break;
			case ProtoTypeCode.Int64:
				result = Enum.ToObject(this.enumType, (long)value);
				break;
			case ProtoTypeCode.UInt64:
				result = Enum.ToObject(this.enumType, (ulong)((long)value));
				break;
			default:
				throw new InvalidOperationException();
			}
			return result;
		}

		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			int num = source.ReadInt32();
			bool flag = this.map == null;
			object result;
			if (flag)
			{
				result = this.WireToEnum(num);
			}
			else
			{
				for (int i = 0; i < this.map.Length; i++)
				{
					bool flag2 = this.map[i].WireValue == num;
					if (flag2)
					{
						return this.map[i].TypedValue;
					}
				}
				XSingleton<XDebug>.singleton.AddWarningLog("Warning: No ", (this.ExpectedType == null) ? "<null>" : this.ExpectedType.FullName, " enum is mapped to the wire-value ", num.ToString(), null, null);
				result = this.WireToEnum(num);
			}
			return result;
		}

		public void Write(object value, ProtoWriter dest)
		{
			bool flag = this.map == null;
			if (flag)
			{
				ProtoWriter.WriteInt32(this.EnumToWire(value), dest);
			}
			else
			{
				for (int i = 0; i < this.map.Length; i++)
				{
					bool flag2 = object.Equals(this.map[i].TypedValue, value);
					if (flag2)
					{
						ProtoWriter.WriteInt32(this.map[i].WireValue, dest);
						return;
					}
				}
				XSingleton<XDebug>.singleton.AddErrorLog("Warning: No wire-value is mapped to the enum ", (value == null) ? "<null>" : (value.GetType().FullName + "." + value.ToString()), " at position ", (dest == null) ? "unknown" : ProtoWriter.GetPosition(dest).ToString(), null, null);
				ProtoWriter.WriteInt32(this.EnumToWire(value), dest);
			}
		}

		private readonly Type enumType;

		private readonly EnumSerializer.EnumPair[] map;

		public struct EnumPair
		{

			public EnumPair(int wireValue, object raw, Type type)
			{
				this.WireValue = wireValue;
				this.RawValue = raw;
				this.TypedValue = (Enum)Enum.ToObject(type, raw);
			}

			public readonly object RawValue;

			public readonly Enum TypedValue;

			public readonly int WireValue;
		}
	}
}
