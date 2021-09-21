using System;
using System.IO;
using System.Text;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000856 RID: 2134
	public sealed class ProtoWriter : IDisposable
	{
		// Token: 0x06008305 RID: 33541 RVA: 0x000FD460 File Offset: 0x000FB660
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

		// Token: 0x06008306 RID: 33542 RVA: 0x000FD504 File Offset: 0x000FB704
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

		// Token: 0x06008307 RID: 33543 RVA: 0x000FD560 File Offset: 0x000FB760
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

		// Token: 0x06008308 RID: 33544 RVA: 0x000FD650 File Offset: 0x000FB850
		internal int GetTypeKey(ref Type type)
		{
			return this.model.GetKey(ref type);
		}

		// Token: 0x17002965 RID: 10597
		// (get) Token: 0x06008309 RID: 33545 RVA: 0x000FD670 File Offset: 0x000FB870
		internal NetObjectCache NetCache
		{
			get
			{
				return this.netCache;
			}
		}

		// Token: 0x17002966 RID: 10598
		// (get) Token: 0x0600830A RID: 33546 RVA: 0x000FD688 File Offset: 0x000FB888
		internal WireType WireType
		{
			get
			{
				return this.wireType;
			}
		}

		// Token: 0x0600830B RID: 33547 RVA: 0x000FD6A0 File Offset: 0x000FB8A0
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

		// Token: 0x0600830C RID: 33548 RVA: 0x000FD838 File Offset: 0x000FBA38
		internal static void WriteHeaderCore(int fieldNumber, WireType wireType, ProtoWriter writer)
		{
			uint value = (uint)(fieldNumber << 3 | (int)(wireType & (WireType)7));
			ProtoWriter.WriteUInt32Variant(value, writer);
		}

		// Token: 0x0600830D RID: 33549 RVA: 0x000FD858 File Offset: 0x000FBA58
		public static void WriteBytes(byte[] data, ProtoWriter writer)
		{
			bool flag = data == null;
			if (flag)
			{
				throw new ArgumentNullException("data");
			}
			ProtoWriter.WriteBytes(data, 0, data.Length, writer);
		}

		// Token: 0x0600830E RID: 33550 RVA: 0x000FD888 File Offset: 0x000FBA88
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

		// Token: 0x0600830F RID: 33551 RVA: 0x000FD9AC File Offset: 0x000FBBAC
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

		// Token: 0x06008310 RID: 33552 RVA: 0x000FDAD5 File Offset: 0x000FBCD5
		private static void IncrementedAndReset(int length, ProtoWriter writer)
		{
			Helpers.DebugAssert(length >= 0);
			writer.ioIndex += length;
			writer.position += length;
			writer.wireType = WireType.None;
		}

		// Token: 0x06008311 RID: 33553 RVA: 0x000FDB08 File Offset: 0x000FBD08
		public static SubItemToken StartSubItem(object instance, ProtoWriter writer)
		{
			return ProtoWriter.StartSubItem(instance, writer, false);
		}

		// Token: 0x06008312 RID: 33554 RVA: 0x000FDB24 File Offset: 0x000FBD24
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

		// Token: 0x06008313 RID: 33555 RVA: 0x000FDC0D File Offset: 0x000FBE0D
		private void PopRecursionStack()
		{
			this.recursionStack.RemoveLast();
		}

		// Token: 0x06008314 RID: 33556 RVA: 0x000FDC1C File Offset: 0x000FBE1C
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

		// Token: 0x06008315 RID: 33557 RVA: 0x000FDD73 File Offset: 0x000FBF73
		public static void EndSubItem(SubItemToken token, ProtoWriter writer)
		{
			ProtoWriter.EndSubItem(token, writer, PrefixStyle.Base128);
		}

		// Token: 0x06008316 RID: 33558 RVA: 0x000FDD80 File Offset: 0x000FBF80
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

		// Token: 0x06008317 RID: 33559 RVA: 0x000FDFC8 File Offset: 0x000FC1C8
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

		// Token: 0x17002967 RID: 10599
		// (get) Token: 0x06008318 RID: 33560 RVA: 0x000FE064 File Offset: 0x000FC264
		public SerializationContext Context
		{
			get
			{
				return this.context;
			}
		}

		// Token: 0x06008319 RID: 33561 RVA: 0x000FE07C File Offset: 0x000FC27C
		void IDisposable.Dispose()
		{
			this.Dispose();
		}

		// Token: 0x0600831A RID: 33562 RVA: 0x000FE088 File Offset: 0x000FC288
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

		// Token: 0x0600831B RID: 33563 RVA: 0x000FE0C8 File Offset: 0x000FC2C8
		internal static int GetPosition(ProtoWriter writer)
		{
			return writer.position;
		}

		// Token: 0x0600831C RID: 33564 RVA: 0x000FE0E0 File Offset: 0x000FC2E0
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

		// Token: 0x0600831D RID: 33565 RVA: 0x000FE154 File Offset: 0x000FC354
		public void Close()
		{
			bool flag = this.depth != 0 || this.flushLock != 0;
			if (flag)
			{
				throw new InvalidOperationException("Unable to close stream in an incomplete state");
			}
			this.Dispose();
		}

		// Token: 0x0600831E RID: 33566 RVA: 0x000FE18C File Offset: 0x000FC38C
		internal void CheckDepthFlushlock()
		{
			bool flag = this.depth != 0 || this.flushLock != 0;
			if (flag)
			{
				throw new InvalidOperationException("The writer is in an incomplete state");
			}
		}

		// Token: 0x17002968 RID: 10600
		// (get) Token: 0x0600831F RID: 33567 RVA: 0x000FE1C0 File Offset: 0x000FC3C0
		public TypeModel Model
		{
			get
			{
				return this.model;
			}
		}

		// Token: 0x06008320 RID: 33568 RVA: 0x000FE1D8 File Offset: 0x000FC3D8
		internal static void Flush(ProtoWriter writer)
		{
			bool flag = writer.flushLock == 0 && writer.ioIndex != 0;
			if (flag)
			{
				writer.dest.Write(writer.ioBuffer, 0, writer.ioIndex);
				writer.ioIndex = 0;
			}
		}

		// Token: 0x06008321 RID: 33569 RVA: 0x000FE220 File Offset: 0x000FC420
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

		// Token: 0x06008322 RID: 33570 RVA: 0x000FE298 File Offset: 0x000FC498
		internal static uint Zig(int value)
		{
			return (uint)(value << 1 ^ value >> 31);
		}

		// Token: 0x06008323 RID: 33571 RVA: 0x000FE2B4 File Offset: 0x000FC4B4
		internal static ulong Zig(long value)
		{
			return (ulong)(value << 1 ^ value >> 63);
		}

		// Token: 0x06008324 RID: 33572 RVA: 0x000FE2D0 File Offset: 0x000FC4D0
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

		// Token: 0x06008325 RID: 33573 RVA: 0x000FE34C File Offset: 0x000FC54C
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

		// Token: 0x06008326 RID: 33574 RVA: 0x000FE40C File Offset: 0x000FC60C
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

		// Token: 0x06008327 RID: 33575 RVA: 0x000FE474 File Offset: 0x000FC674
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

		// Token: 0x06008328 RID: 33576 RVA: 0x000FE640 File Offset: 0x000FC840
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

		// Token: 0x06008329 RID: 33577 RVA: 0x000FE6A6 File Offset: 0x000FC8A6
		public static void WriteInt16(short value, ProtoWriter writer)
		{
			ProtoWriter.WriteInt32((int)value, writer);
		}

		// Token: 0x0600832A RID: 33578 RVA: 0x000FE6B1 File Offset: 0x000FC8B1
		public static void WriteUInt16(ushort value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32((uint)value, writer);
		}

		// Token: 0x0600832B RID: 33579 RVA: 0x000FE6B1 File Offset: 0x000FC8B1
		public static void WriteByte(byte value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32((uint)value, writer);
		}

		// Token: 0x0600832C RID: 33580 RVA: 0x000FE6A6 File Offset: 0x000FC8A6
		public static void WriteSByte(sbyte value, ProtoWriter writer)
		{
			ProtoWriter.WriteInt32((int)value, writer);
		}

		// Token: 0x0600832D RID: 33581 RVA: 0x000FE6BC File Offset: 0x000FC8BC
		private static void WriteInt32ToBuffer(int value, byte[] buffer, int index)
		{
			buffer[index] = (byte)value;
			buffer[index + 1] = (byte)(value >> 8);
			buffer[index + 2] = (byte)(value >> 16);
			buffer[index + 3] = (byte)(value >> 24);
		}

		// Token: 0x0600832E RID: 33582 RVA: 0x000FE6E4 File Offset: 0x000FC8E4
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

		// Token: 0x0600832F RID: 33583 RVA: 0x000FE8A4 File Offset: 0x000FCAA4
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

		// Token: 0x06008330 RID: 33584 RVA: 0x000FE918 File Offset: 0x000FCB18
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

		// Token: 0x06008331 RID: 33585 RVA: 0x000FE96C File Offset: 0x000FCB6C
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

		// Token: 0x06008332 RID: 33586 RVA: 0x000FE9D4 File Offset: 0x000FCBD4
		internal static Exception CreateException(ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			return new ProtoException("Invalid serialization operation with wire-type " + writer.wireType.ToString() + " at position " + writer.position.ToString());
		}

		// Token: 0x06008333 RID: 33587 RVA: 0x000FEA29 File Offset: 0x000FCC29
		public static void WriteBoolean(bool value, ProtoWriter writer)
		{
			ProtoWriter.WriteUInt32(value ? 1U : 0U, writer);
		}

		// Token: 0x06008334 RID: 33588 RVA: 0x000FEA3C File Offset: 0x000FCC3C
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

		// Token: 0x06008335 RID: 33589 RVA: 0x000FEACC File Offset: 0x000FCCCC
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

		// Token: 0x06008336 RID: 33590 RVA: 0x000FEB0C File Offset: 0x000FCD0C
		internal string SerializeType(Type type)
		{
			return TypeModel.SerializeType(this.model, type);
		}

		// Token: 0x06008337 RID: 33591 RVA: 0x000FEB2A File Offset: 0x000FCD2A
		public void SetRootObject(object value)
		{
			this.NetCache.SetKeyedObject(0, value);
		}

		// Token: 0x06008338 RID: 33592 RVA: 0x000FEB3C File Offset: 0x000FCD3C
		public static void WriteType(Type value, ProtoWriter writer)
		{
			bool flag = writer == null;
			if (flag)
			{
				throw new ArgumentNullException("writer");
			}
			ProtoWriter.WriteString(writer.SerializeType(value), writer);
		}

		// Token: 0x040028B2 RID: 10418
		private Stream dest;

		// Token: 0x040028B3 RID: 10419
		private TypeModel model;

		// Token: 0x040028B4 RID: 10420
		private readonly NetObjectCache netCache = new NetObjectCache();

		// Token: 0x040028B5 RID: 10421
		private int fieldNumber;

		// Token: 0x040028B6 RID: 10422
		private int flushLock;

		// Token: 0x040028B7 RID: 10423
		private WireType wireType;

		// Token: 0x040028B8 RID: 10424
		private int depth = 0;

		// Token: 0x040028B9 RID: 10425
		private const int RecursionCheckDepth = 25;

		// Token: 0x040028BA RID: 10426
		private MutableList recursionStack;

		// Token: 0x040028BB RID: 10427
		private readonly SerializationContext context;

		// Token: 0x040028BC RID: 10428
		private byte[] ioBuffer;

		// Token: 0x040028BD RID: 10429
		private int ioIndex;

		// Token: 0x040028BE RID: 10430
		private int position;

		// Token: 0x040028BF RID: 10431
		private static readonly UTF8Encoding encoding = new UTF8Encoding();

		// Token: 0x040028C0 RID: 10432
		private int packedFieldNumber;
	}
}
