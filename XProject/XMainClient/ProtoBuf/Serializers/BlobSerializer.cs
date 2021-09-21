using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200085C RID: 2140
	internal sealed class BlobSerializer : IProtoSerializer
	{
		// Token: 0x17002970 RID: 10608
		// (get) Token: 0x0600835E RID: 33630 RVA: 0x000FF424 File Offset: 0x000FD624
		public Type ExpectedType
		{
			get
			{
				return BlobSerializer.expectedType;
			}
		}

		// Token: 0x0600835F RID: 33631 RVA: 0x000FF43B File Offset: 0x000FD63B
		public BlobSerializer(TypeModel model, bool overwriteList)
		{
			this.overwriteList = overwriteList;
		}

		// Token: 0x06008360 RID: 33632 RVA: 0x000FF44C File Offset: 0x000FD64C
		public object Read(object value, ProtoReader source)
		{
			return ProtoReader.AppendBytes(this.overwriteList ? null : ((byte[])value), source);
		}

		// Token: 0x06008361 RID: 33633 RVA: 0x000FF475 File Offset: 0x000FD675
		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteBytes((byte[])value, dest);
		}

		// Token: 0x17002971 RID: 10609
		// (get) Token: 0x06008362 RID: 33634 RVA: 0x000FF488 File Offset: 0x000FD688
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return !this.overwriteList;
			}
		}

		// Token: 0x17002972 RID: 10610
		// (get) Token: 0x06008363 RID: 33635 RVA: 0x000FF4A4 File Offset: 0x000FD6A4
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x040028DA RID: 10458
		private static readonly Type expectedType = typeof(byte[]);

		// Token: 0x040028DB RID: 10459
		private readonly bool overwriteList;
	}
}
