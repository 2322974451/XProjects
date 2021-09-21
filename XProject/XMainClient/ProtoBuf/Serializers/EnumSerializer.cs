using System;
using XUtliPoolLib;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000864 RID: 2148
	internal sealed class EnumSerializer : IProtoSerializer
	{
		// Token: 0x06008393 RID: 33683 RVA: 0x000FF8F0 File Offset: 0x000FDAF0
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

		// Token: 0x06008394 RID: 33684 RVA: 0x000FFA34 File Offset: 0x000FDC34
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

		// Token: 0x17002986 RID: 10630
		// (get) Token: 0x06008395 RID: 33685 RVA: 0x000FFA68 File Offset: 0x000FDC68
		public Type ExpectedType
		{
			get
			{
				return this.enumType;
			}
		}

		// Token: 0x17002987 RID: 10631
		// (get) Token: 0x06008396 RID: 33686 RVA: 0x000FFA80 File Offset: 0x000FDC80
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17002988 RID: 10632
		// (get) Token: 0x06008397 RID: 33687 RVA: 0x000FFA94 File Offset: 0x000FDC94
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008398 RID: 33688 RVA: 0x000FFAA8 File Offset: 0x000FDCA8
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

		// Token: 0x06008399 RID: 33689 RVA: 0x000FFB3C File Offset: 0x000FDD3C
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

		// Token: 0x0600839A RID: 33690 RVA: 0x000FFC04 File Offset: 0x000FDE04
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

		// Token: 0x0600839B RID: 33691 RVA: 0x000FFCCC File Offset: 0x000FDECC
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

		// Token: 0x040028E3 RID: 10467
		private readonly Type enumType;

		// Token: 0x040028E4 RID: 10468
		private readonly EnumSerializer.EnumPair[] map;

		// Token: 0x02001941 RID: 6465
		public struct EnumPair
		{
			// Token: 0x06010FAF RID: 69551 RVA: 0x00452333 File Offset: 0x00450533
			public EnumPair(int wireValue, object raw, Type type)
			{
				this.WireValue = wireValue;
				this.RawValue = raw;
				this.TypedValue = (Enum)Enum.ToObject(type, raw);
			}

			// Token: 0x04007D62 RID: 32098
			public readonly object RawValue;

			// Token: 0x04007D63 RID: 32099
			public readonly Enum TypedValue;

			// Token: 0x04007D64 RID: 32100
			public readonly int WireValue;
		}
	}
}
