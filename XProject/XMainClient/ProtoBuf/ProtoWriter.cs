using System;
using System.IO;
using System.Text;
using ProtoBuf.Meta;

namespace ProtoBuf
{

	public sealed class ProtoWriter : IDisposable
	{

		public static void WriteObject(object value, int key, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag2 = writer.model == null;
			if (flag2)
			{
				throw new InvalidOperationException("Cannot serialize sub-objects unless a model is provided");
			}
			SubItemToken token = ProtoWriter.StartSubItem(value, writer);
			bool flag3 = key >= 0;
			if (flag3)
			{
				writer.model.Serialize(key, value, writer);
			}
			else
			{
				bool flag4 = writer.model != null && writer.model.TrySerializeAuxiliaryType(writer, value.GetType(), DataFormat.Default, 1, value, false);
				if (!flag4)
				{
					TypeModel.ThrowUnexpectedType(value.GetType());
				}
			}
			ProtoWriter.EndSubItem(token, writer);
		}

		public static void WriteRecursionSafeObject(object value, int key, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag2 = writer.model == null;
			if (flag2)
			{
				throw new InvalidOperationException("Cannot serialize sub-objects unless a model is provided");
			}
			SubItemToken token = ProtoWriter.StartSubItem(null, writer);
			writer.model.Serialize(key, value, writer);
			ProtoWriter.EndSubItem(token, writer);
		}

		internal static void WriteObject(object value, int key, ProtoWriter writer, PrefixStyle style, int fieldNumber)
		{
			bool flag = writer.model == null;
			if (flag)
			{
				throw new InvalidOperationException("Cannot serialize sub-objects unless a model is provided");
			}
			bool flag2 = writer.wireType != WireType.None;
			if (flag2)
			{
				throw ProtoWriter.CreateException(writer);
			}
			if (style != PrefixStyle.Base128)
			{
				if (style - PrefixStyle.Fixed32 > 1)
				{
					throw new ArgumentOutOfRangeException("style");
				}
				writer.fieldNumber = 0;
				writer.wireType = WireType.Fixed32;
			}
			else
			{
				writer.wireType = WireType.String;
				writer.fieldNumber = fieldNumber;
				bool flag3 = fieldNumber > 0;
				if (flag3)
				{
					ProtoWriter.WriteHeaderCore(fieldNumber, WireType.String, writer);
				}
			}
			SubItemToken token = ProtoWriter.StartSubItem(value, writer, true);
			bool flag4 = key < 0;
			if (flag4)
			{
				bool flag5 = !writer.model.TrySerializeAuxiliaryType(writer, value.GetType(), DataFormat.Default, 1, value, false);
				if (flag5)
				{
					TypeModel.ThrowUnexpectedType(value.GetType());
				}
			}
			else
			{
				writer.model.Serialize(key, value, writer);
			}
			ProtoWriter.EndSubItem(token, writer, style);
		}

		internal int GetTypeKey(ref Type type)
		{
			return this.model.GetKey(ref type);
		}

		internal NetObjectCache NetCache
		{
			get
			{
				return this.netCache;
			}
		}

		internal WireType WireType
		{
			get
			{
				return this.wireType;
			}
		}

		public static void WriteFieldHeader(int fieldNumber, WireType wireType, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag2 = writer.wireType != WireType.None;
			if (flag2)
			{
				throw new InvalidOperationException(string.Concat(new string[]
				{
					"Cannot write a ",
					wireType.ToString(),
					" header until the ",
					writer.wireType.ToString(),
					" data has been written"
				}));
			}
			bool flag3 = fieldNumber < 0;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			switch (wireType)
			{
			case WireType.Variant:
			case WireType.Fixed64:
			case WireType.String:
			case WireType.StartGroup:
			case WireType.Fixed32:
			case WireType.SignedVariant:
			{
				bool flag4 = writer.packedFieldNumber == 0;
				if (flag4)
				{
					writer.fieldNumber = fieldNumber;
					writer.wireType = wireType;
					ProtoWriter.WriteHeaderCore(fieldNumber, wireType, writer);
				}
				else
				{
					bool flag5 = writer.packedFieldNumber == fieldNumber;
					if (!flag5)
					{
						throw new InvalidOperationException("Field mismatch during packed encoding; expected " + writer.packedFieldNumber.ToString() + " but received " + fieldNumber.ToString());
					}
					WireType wireType2 = wireType;
					if (wireType2 > WireType.Fixed64 && wireType2 != WireType.Fixed32 && wireType2 != WireType.SignedVariant)
					{
						throw new InvalidOperationException("Wire-type cannot be encoded as packed: " + wireType.ToString());
					}
					writer.fieldNumber = fieldNumber;
					writer.wireType = wireType;
				}
				return;
			}
			}
			throw new ArgumentException("Invalid wire-type: " + wireType.ToString(), "wireType");
		}

		internal static void WriteHeaderCore(int fieldNumber, WireType wireType, ProtoWriter writer)
		{
			uint value = (uint)(fieldNumber << 3 | (int)(wireType & (WireType)7));
			ProtoWriter.WriteUInt32Variant(value, writer);
		}

		public static void WriteBytes(byte[] data, ProtoWriter writer)
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			ProtoWriter.WriteBytes(data, 0, data.Length, writer);
		}

		public static void WriteBytes(byte[] data, int offset, int length, ProtoWriter writer)
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			bool flag2 = writer == null;
			if (flag2)
			{
				throw new ArgumentNullException("writer");
			}
			switch (writer.wireType)
			{
			case WireType.Fixed64:
			{
				bool flag3 = length != 8;
				if (flag3)
				{
					throw new ArgumentException("length");
				}
				goto IL_EE;
			}
			case WireType.String:
			{
				ProtoWriter.WriteUInt32Variant((uint)length, writer);
				writer.wireType = WireType.None;
				bool flag4 = length == 0;
				if (flag4)
				{
					return;
				}
				bool flag5 = writer.flushLock != 0 || length <= writer.ioBuffer.Length;
				if (flag5)
				{
					goto IL_EE;
				}
				ProtoWriter.Flush(writer);
				writer.dest.Write(data, offset, length);
				writer.position += length;
				return;
			}
			case WireType.Fixed32:
			{
				bool flag6 = length != 4;
				if (flag6)
				{
					throw new ArgumentException("length");
				}
				goto IL_EE;
			}
			}
			throw ProtoWriter.CreateException(writer);
			IL_EE:
			ProtoWriter.DemandSpace(length, writer);
			Helpers.BlockCopy(data, offset, writer.ioBuffer, writer.ioIndex, length);
			ProtoWriter.IncrementedAndReset(length, writer);
		}

		private static void CopyRawFromStream(Stream source, ProtoWriter writer)
		{
			byte[] array = writer.ioBuffer;
			int num = array.Length - writer.ioIndex;
			int num2 = 1;
			while (num > 0 && (num2 = source.Read(array, writer.ioIndex, num)) > 0)
			{
				writer.ioIndex += num2;
				writer.position += num2;
				num -= num2;
			}
			bool flag = num2 <= 0;
			if (!flag)
			{
				bool flag2 = writer.flushLock == 0;
				if (flag2)
				{
					ProtoWriter.Flush(writer);
					while ((num2 = source.Read(array, 0, array.Length)) > 0)
					{
						writer.dest.Write(array, 0, num2);
						writer.position += num2;
					}
				}
				else
				{
					for (;;)
					{
						ProtoWriter.DemandSpace(128, writer);
						bool flag3 = (num2 = source.Read(writer.ioBuffer, writer.ioIndex, writer.ioBuffer.Length - writer.ioIndex)) <= 0;
						if (flag3)
						{
							break;
						}
						writer.position += num2;
						writer.ioIndex += num2;
					}
				}
			}
		}

		private static void IncrementedAndReset(int length, ProtoWriter writer)
		{
			Helpers.DebugAssert(length >= 0);
			writer.ioIndex += length;
			writer.position += length;
			writer.wireType = WireType.None;
		}

		public static SubItemToken StartSubItem(object instance, ProtoWriter writer)
		{
			return ProtoWriter.StartSubItem(instance, writer, false);
		}

		private void CheckRecursionStackAndPush(object instance)
		{
			bool flag = this.recursionStack == null;
			if (flag)
			{
				this.recursionStack = new MutableList();
			}
			else
			{
				int num = default;
				bool flag2 = instance != null && (num = this.recursionStack.IndexOfReference(instance)) >= 0;
				if (flag2)
				{
					Helpers.DebugWriteLine("Stack:");
					foreach (object obj in this.recursionStack)
					{
						Helpers.DebugWriteLine((obj == null) ? "<null>" : obj.ToString());
					}
					Helpers.DebugWriteLine((instance == null) ? "<null>" : instance.ToString());
					throw new ProtoException("Possible recursion detected (offset: " + (this.recursionStack.Count - num).ToString() + " level(s)): " + instance.ToString());
				}
			}
			this.recursionStack.Add(instance);
		}

		private void PopRecursionStack()
		{
			this.recursionStack.RemoveLast();
		}

		private static SubItemToken StartSubItem(object instance, ProtoWriter writer, bool allowFixed)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			int num = writer.depth + 1;
			writer.depth = num;
			bool flag2 = num > 25;
			if (flag2)
			{
				writer.CheckRecursionStackAndPush(instance);
			}
			bool flag3 = writer.packedFieldNumber != 0;
			if (flag3)
			{
				throw new InvalidOperationException("Cannot begin a sub-item while performing packed encoding");
			}
			switch (writer.wireType)
			{
			case WireType.String:
			{
				bool flag4 = writer.model != null && writer.model.ForwardsOnly;
				if (flag4)
				{
					throw new ProtoException("Should not be buffering data");
				}
				writer.wireType = WireType.None;
				ProtoWriter.DemandSpace(32, writer);
				writer.flushLock++;
				writer.position++;
				num = writer.ioIndex;
				writer.ioIndex = num + 1;
				return new SubItemToken(num);
			}
			case WireType.StartGroup:
				writer.wireType = WireType.None;
				return new SubItemToken(-writer.fieldNumber);
			case WireType.Fixed32:
			{
				bool flag5 = !allowFixed;
				if (flag5)
				{
					throw ProtoWriter.CreateException(writer);
				}
				ProtoWriter.DemandSpace(32, writer);
				writer.flushLock++;
				SubItemToken result = new SubItemToken(writer.ioIndex);
				ProtoWriter.IncrementedAndReset(4, writer);
				return result;
			}
			}
			throw ProtoWriter.CreateException(writer);
		}

		public static void EndSubItem(SubItemToken token, ProtoWriter writer)
		{
			ProtoWriter.EndSubItem(token, writer, PrefixStyle.Base128);
		}

		private static void EndSubItem(SubItemToken token, ProtoWriter writer, PrefixStyle style)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag2 = writer.wireType != WireType.None;
			if (flag2)
			{
				throw ProtoWriter.CreateException(writer);
			}
			int value = token.value;
			bool flag3 = writer.depth <= 0;
			if (flag3)
			{
				throw ProtoWriter.CreateException(writer);
			}
			int num = writer.depth;
			writer.depth = num - 1;
			bool flag4 = num > 25;
			if (flag4)
			{
				writer.PopRecursionStack();
			}
			writer.packedFieldNumber = 0;
			bool flag5 = value < 0;
			if (flag5)
			{
				ProtoWriter.WriteHeaderCore(-value, WireType.EndGroup, writer);
				writer.wireType = WireType.None;
			}
			else
			{
				switch (style)
				{
				case PrefixStyle.Base128:
				{
					int num2 = writer.ioIndex - value - 1;
					int num3 = 0;
					uint num4 = (uint)num2;
					while ((num4 >>= 7) > 0U)
					{
						num3++;
					}
					bool flag6 = num3 == 0;
					if (flag6)
					{
						writer.ioBuffer[value] = (byte)(num2 & 127);
					}
					else
					{
						ProtoWriter.DemandSpace(num3, writer);
						byte[] array = writer.ioBuffer;
						Helpers.BlockCopy(array, value + 1, array, value + 1 + num3, num2);
						num4 = (uint)num2;
						do
						{
							array[value++] = (byte)((num4 & 127U) | 128U);
						}
						while ((num4 >>= 7) > 0U);
						array[value - 1] = (byte)((int)array[value - 1] & -129);
						writer.position += num3;
						writer.ioIndex += num3;
					}
					break;
				}
				case PrefixStyle.Fixed32:
				{
					int num2 = writer.ioIndex - value - 4;
					ProtoWriter.WriteInt32ToBuffer(num2, writer.ioBuffer, value);
					break;
				}
				case PrefixStyle.Fixed32BigEndian:
				{
					int num2 = writer.ioIndex - value - 4;
					byte[] array2 = writer.ioBuffer;
					ProtoWriter.WriteInt32ToBuffer(num2, array2, value);
					byte b = array2[value];
					array2[value] = array2[value + 3];
					array2[value + 3] = b;
					b = array2[value + 1];
					array2[value + 1] = array2[value + 2];
					array2[value + 2] = b;
					break;
				}
				default:
					throw new ArgumentOutOfRangeException("style");
				}
				num = writer.flushLock - 1;
				writer.flushLock = num;
				bool flag7 = num == 0 && writer.ioIndex >= 1024;
				if (flag7)
				{
					ProtoWriter.Flush(writer);
				}
			}
		}

		public ProtoWriter(Stream dest, TypeModel model, SerializationContext context)
		{
			bool flag = dest == null;
			if (flag)
			{
				throw new ArgumentNullException("dest");
			}
			bool flag2 = !dest.CanWrite;
			if (flag2)
			{
				throw new ArgumentException("Cannot write to stream", "dest");
			}
			this.dest = dest;
			this.ioBuffer = BufferPool.GetBuffer();
			this.model = model;
			this.wireType = WireType.None;
			bool flag3 = context == null;
			if (flag3)
			{
				context = SerializationContext.Default;
			}
			else
			{
				context.Freeze();
			}
			this.context = context;
		}

		public SerializationContext Context
		{
			get
			{
				return this.context;
			}
		}

		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		private void Dispose()
		{
			bool flag = this.dest != null;
			if (flag)
			{
				ProtoWriter.Flush(this);
				this.dest = null;
			}
			this.model = null;
			BufferPool.ReleaseBufferToPool(ref this.ioBuffer);
		}

		internal static int GetPosition(ProtoWriter writer)
		{
			return writer.position;
		}

		private static void DemandSpace(int required, ProtoWriter writer)
		{
			bool flag = writer.ioBuffer.Length - writer.ioIndex < required;
			if (flag)
			{
				bool flag2 = writer.flushLock == 0;
				if (flag2)
				{
					ProtoWriter.Flush(writer);
					bool flag3 = writer.ioBuffer.Length - writer.ioIndex >= required;
					if (flag3)
					{
						return;
					}
				}
				BufferPool.ResizeAndFlushLeft(ref writer.ioBuffer, required + writer.ioIndex, 0, writer.ioIndex);
			}
		}

		public void Close()
		{
			bool flag = this.depth != 0 || this.flushLock != 0;
			if (flag)
			{
				throw new InvalidOperationException("Unable to close stream in an incomplete state");
			}
			this.Dispose();
		}

		internal void CheckDepthFlushlock()
		{
			bool flag = this.depth != 0 || this.flushLock != 0;
			if (flag)
			{
				throw new InvalidOperationException("The writer is in an incomplete state");
			}
		}

		public TypeModel Model
		{
			get
			{
				return this.model;
			}
		}

		internal static void Flush(ProtoWriter writer)
		{
			bool flag = writer.flushLock == 0 && writer.ioIndex != 0;
			if (flag)
			{
				writer.dest.Write(writer.ioBuffer, 0, writer.ioIndex);
				writer.ioIndex = 0;
			}
		}

		private static void WriteUInt32Variant(uint value, ProtoWriter writer)
		{
			ProtoWriter.DemandSpace(5, writer);
			int num = 0;
			do
			{
				byte[] array = writer.ioBuffer;
				int num2 = writer.ioIndex;
				writer.ioIndex = num2 + 1;
				array[num2] = (byte)((value & 127U) | 128U);
				num++;
			}
			while ((value >>= 7) > 0U);
			byte[] array2 = writer.ioBuffer;
			int num3 = writer.ioIndex - 1;
			array2[num3] &= 127;
			writer.position += num;
		}

		internal static uint Zig(int value)
		{
			return (uint)(value << 1 ^ value >> 31);
		}

		internal static ulong Zig(long value)
		{
			return (ulong)(value << 1 ^ value >> 63);
		}

		private static void WriteUInt64Variant(ulong value, ProtoWriter writer)
		{
			ProtoWriter.DemandSpace(10, writer);
			int num = 0;
			do
			{
				byte[] array = writer.ioBuffer;
				int num2 = writer.ioIndex;
				writer.ioIndex = num2 + 1;
				array[num2] = (byte)((value & 127UL) | 128UL);
				num++;
			}
			while ((value >>= 7) > 0UL);
			byte[] array2 = writer.ioBuffer;
			int num3 = writer.ioIndex - 1;
			array2[num3] &= 127;
			writer.position += num;
		}

		public static void WriteString(string value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag2 = writer.wireType != WireType.String;
			if (flag2)
			{
				throw ProtoWriter.CreateException(writer);
			}
			bool flag3 = value == null;
			if (flag3)
			{
				throw new ArgumentNullException("value");
			}
			int length = value.Length;
			bool flag4 = length == 0;
			if (flag4)
			{
				ProtoWriter.WriteUInt32Variant(0U, writer);
				writer.wireType = WireType.None;
			}
			else
			{
				int byteCount = ProtoWriter.encoding.GetByteCount(value);
				ProtoWriter.WriteUInt32Variant((uint)byteCount, writer);
				ProtoWriter.DemandSpace(byteCount, writer);
				int bytes = ProtoWriter.encoding.GetBytes(value, 0, value.Length, writer.ioBuffer, writer.ioIndex);
				Helpers.DebugAssert(byteCount == bytes);
				ProtoWriter.IncrementedAndReset(bytes, writer);
			}
		}

		public static void WriteUInt64(ulong value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType != WireType.Variant)
			{
				if (wireType != WireType.Fixed64)
				{
					if (wireType != WireType.Fixed32)
					{
						throw ProtoWriter.CreateException(writer);
					}
					ProtoWriter.WriteUInt32(checked((uint)value), writer);
				}
				else
				{
					ProtoWriter.WriteInt64((long)value, writer);
				}
			}
			else
			{
				ProtoWriter.WriteUInt64Variant(value, writer);
				writer.wireType = WireType.None;
			}
		}

		public static void WriteInt64(long value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType <= WireType.Fixed64)
			{
				if (wireType == WireType.Variant)
				{
					bool flag2 = value >= 0L;
					if (flag2)
					{
						ProtoWriter.WriteUInt64Variant((ulong)value, writer);
						writer.wireType = WireType.None;
					}
					else
					{
						ProtoWriter.DemandSpace(10, writer);
						byte[] array = writer.ioBuffer;
						int num = writer.ioIndex;
						array[num] = (byte)(value | 128L);
						array[num + 1] = (byte)((int)(value >> 7) | 128);
						array[num + 2] = (byte)((int)(value >> 14) | 128);
						array[num + 3] = (byte)((int)(value >> 21) | 128);
						array[num + 4] = (byte)((int)(value >> 28) | 128);
						array[num + 5] = (byte)((int)(value >> 35) | 128);
						array[num + 6] = (byte)((int)(value >> 42) | 128);
						array[num + 7] = (byte)((int)(value >> 49) | 128);
						array[num + 8] = (byte)((int)(value >> 56) | 128);
						array[num + 9] = 1;
						ProtoWriter.IncrementedAndReset(10, writer);
					}
					return;
				}
				if (wireType == WireType.Fixed64)
				{
					ProtoWriter.DemandSpace(8, writer);
					byte[] array = writer.ioBuffer;
					int num = writer.ioIndex;
					array[num] = (byte)value;
					array[num + 1] = (byte)(value >> 8);
					array[num + 2] = (byte)(value >> 16);
					array[num + 3] = (byte)(value >> 24);
					array[num + 4] = (byte)(value >> 32);
					array[num + 5] = (byte)(value >> 40);
					array[num + 6] = (byte)(value >> 48);
					array[num + 7] = (byte)(value >> 56);
					ProtoWriter.IncrementedAndReset(8, writer);
					return;
				}
			}
			else
			{
				if (wireType == WireType.Fixed32)
				{
					ProtoWriter.WriteInt32(checked((int)value), writer);
					return;
				}
				if (wireType == WireType.SignedVariant)
				{
					ProtoWriter.WriteUInt64Variant(ProtoWriter.Zig(value), writer);
					writer.wireType = WireType.None;
					return;
				}
			}
			throw ProtoWriter.CreateException(writer);
		}

		public static void WriteUInt32(uint value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType != WireType.Variant)
			{
				if (wireType != WireType.Fixed64)
				{
					if (wireType != WireType.Fixed32)
					{
						throw ProtoWriter.CreateException(writer);
					}
					ProtoWriter.WriteInt32((int)value, writer);
				}
				else
				{
					ProtoWriter.WriteInt64((long)value, writer);
				}
			}
			else
			{
				ProtoWriter.WriteUInt32Variant(value, writer);
				writer.wireType = WireType.None;
			}
		}

		public static void WriteInt16(short value, ProtoWriter writer)
		{
			ProtoWriter.WriteInt32((int)value, writer);
		}

		public static void WriteUInt16(ushort value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32((uint)value, writer);
		}

		public static void WriteByte(byte value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32((uint)value, writer);
		}

		public static void WriteSByte(sbyte value, ProtoWriter writer)
		{
			ProtoWriter.WriteInt32((int)value, writer);
		}

		private static void WriteInt32ToBuffer(int value, byte[] buffer, int index)
		{
			buffer[index] = (byte)value;
			buffer[index + 1] = (byte)(value >> 8);
			buffer[index + 2] = (byte)(value >> 16);
			buffer[index + 3] = (byte)(value >> 24);
		}

		public static void WriteInt32(int value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType <= WireType.Fixed64)
			{
				if (wireType == WireType.Variant)
				{
					bool flag2 = value >= 0;
					if (flag2)
					{
						ProtoWriter.WriteUInt32Variant((uint)value, writer);
						writer.wireType = WireType.None;
					}
					else
					{
						ProtoWriter.DemandSpace(10, writer);
						byte[] array = writer.ioBuffer;
						int num = writer.ioIndex;
						array[num] = (byte)(value | 128);
						array[num + 1] = (byte)(value >> 7 | 128);
						array[num + 2] = (byte)(value >> 14 | 128);
						array[num + 3] = (byte)(value >> 21 | 128);
						array[num + 4] = (byte)(value >> 28 | 128);
						array[num + 5] = (array[num + 6] = (array[num + 7] = (array[num + 8] = byte.MaxValue)));
						array[num + 9] = 1;
						ProtoWriter.IncrementedAndReset(10, writer);
					}
					return;
				}
				if (wireType == WireType.Fixed64)
				{
					ProtoWriter.DemandSpace(8, writer);
					byte[] array = writer.ioBuffer;
					int num = writer.ioIndex;
					array[num] = (byte)value;
					array[num + 1] = (byte)(value >> 8);
					array[num + 2] = (byte)(value >> 16);
					array[num + 3] = (byte)(value >> 24);
					array[num + 4] = (array[num + 5] = (array[num + 6] = (array[num + 7] = 0)));
					ProtoWriter.IncrementedAndReset(8, writer);
					return;
				}
			}
			else
			{
				if (wireType == WireType.Fixed32)
				{
					ProtoWriter.DemandSpace(4, writer);
					ProtoWriter.WriteInt32ToBuffer(value, writer.ioBuffer, writer.ioIndex);
					ProtoWriter.IncrementedAndReset(4, writer);
					return;
				}
				if (wireType == WireType.SignedVariant)
				{
					ProtoWriter.WriteUInt32Variant(ProtoWriter.Zig(value), writer);
					writer.wireType = WireType.None;
					return;
				}
			}
			throw ProtoWriter.CreateException(writer);
		}

		public unsafe static void WriteDouble(double value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType != WireType.Fixed64)
			{
				if (wireType != WireType.Fixed32)
				{
					throw ProtoWriter.CreateException(writer);
				}
				float value2 = (float)value;
				bool flag2 = Helpers.IsInfinity(value2) && !Helpers.IsInfinity(value);
				if (flag2)
				{
					throw new OverflowException();
				}
				ProtoWriter.WriteSingle(value2, writer);
			}
			else
			{
				ProtoWriter.WriteInt64(*(long*)(&value), writer);
			}
		}

		public unsafe static void WriteSingle(float value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			WireType wireType = writer.wireType;
			if (wireType != WireType.Fixed64)
			{
				if (wireType != WireType.Fixed32)
				{
					throw ProtoWriter.CreateException(writer);
				}
				ProtoWriter.WriteInt32(*(int*)(&value), writer);
			}
			else
			{
				ProtoWriter.WriteDouble((double)value, writer);
			}
		}

		public static void ThrowEnumException(ProtoWriter writer, object enumValue)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			string str = (enumValue == null) ? "<null>" : (enumValue.GetType().FullName + "." + enumValue.ToString());
			throw new ProtoException("No wire-value is mapped to the enum " + str + " at position " + writer.position.ToString());
		}

		internal static Exception CreateException(ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			return new ProtoException("Invalid serialization operation with wire-type " + writer.wireType.ToString() + " at position " + writer.position.ToString());
		}

		public static void WriteBoolean(bool value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32(value ? 1U : 0U, writer);
		}

		public static void AppendExtensionData(IExtensible instance, ProtoWriter writer)
		{
			bool flag = instance == null;
			if (flag)
			{
				throw new ArgumentNullException("instance");
			}
			bool flag2 = writer == null;
			if (flag2)
			{
				throw new ArgumentNullException("writer");
			}
			bool flag3 = writer.wireType != WireType.None;
			if (flag3)
			{
				throw ProtoWriter.CreateException(writer);
			}
			IExtension extensionObject = instance.GetExtensionObject(false);
			bool flag4 = extensionObject != null;
			if (flag4)
			{
				Stream stream = extensionObject.BeginQuery();
				try
				{
					ProtoWriter.CopyRawFromStream(stream, writer);
				}
				finally
				{
					extensionObject.EndQuery(stream);
				}
			}
		}

		public static void SetPackedField(int fieldNumber, ProtoWriter writer)
		{
			bool flag = fieldNumber <= 0;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			bool flag2 = writer == null;
			if (flag2)
			{
				throw new ArgumentNullException("writer");
			}
			writer.packedFieldNumber = fieldNumber;
		}

		internal string SerializeType(Type type)
		{
			return TypeModel.SerializeType(this.model, type);
		}

		public void SetRootObject(object value)
		{
			this.NetCache.SetKeyedObject(0, value);
		}

		public static void WriteType(Type value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			ProtoWriter.WriteString(writer.SerializeType(value), writer);
		}

		private Stream dest;

		private TypeModel model;

		private readonly NetObjectCache netCache = new NetObjectCache();

		private int fieldNumber;

		private int flushLock;

		private WireType wireType;

		private int depth = 0;

		private const int RecursionCheckDepth = 25;

		private MutableList recursionStack;

		private readonly SerializationContext context;

		private byte[] ioBuffer;

		private int ioIndex;

		private int position;

		private static readonly UTF8Encoding encoding = new UTF8Encoding();

		private int packedFieldNumber;
	}
}
