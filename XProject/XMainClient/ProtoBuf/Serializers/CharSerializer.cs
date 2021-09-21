using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200085F RID: 2143
	internal sealed class CharSerializer : UInt16Serializer
	{
		// Token: 0x06008373 RID: 33651 RVA: 0x000FF5D8 File Offset: 0x000FD7D8
		public CharSerializer(TypeModel model) : base(model)
		{
		}

		// Token: 0x17002979 RID: 10617
		// (get) Token: 0x06008374 RID: 33652 RVA: 0x000FF5E4 File Offset: 0x000FD7E4
		public override Type ExpectedType
		{
			get
			{
				return CharSerializer.expectedType;
			}
		}

		// Token: 0x06008375 RID: 33653 RVA: 0x000FF5FB File Offset: 0x000FD7FB
		public override void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteUInt16((ushort)((char)value), dest);
		}

		// Token: 0x06008376 RID: 33654 RVA: 0x000FF60C File Offset: 0x000FD80C
		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return (char)source.ReadUInt16();
		}

		// Token: 0x040028DE RID: 10462
		private static readonly Type expectedType = typeof(char);
	}
}
