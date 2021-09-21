using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000870 RID: 2160
	internal sealed class NetObjectSerializer : IProtoSerializer
	{
		// Token: 0x060083E4 RID: 33764 RVA: 0x00100F3C File Offset: 0x000FF13C
		public NetObjectSerializer(TypeModel model, Type type, int key, BclHelpers.NetObjectOptions options)
		{
			bool flag = (options & BclHelpers.NetObjectOptions.DynamicType) > BclHelpers.NetObjectOptions.None;
			this.key = (flag ? -1 : key);
			this.type = (flag ? model.MapType(typeof(object)) : type);
			this.options = options;
		}

		// Token: 0x170029AA RID: 10666
		// (get) Token: 0x060083E5 RID: 33765 RVA: 0x00100F8C File Offset: 0x000FF18C
		public Type ExpectedType
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x170029AB RID: 10667
		// (get) Token: 0x060083E6 RID: 33766 RVA: 0x00100FA4 File Offset: 0x000FF1A4
		public bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029AC RID: 10668
		// (get) Token: 0x060083E7 RID: 33767 RVA: 0x00100FB8 File Offset: 0x000FF1B8
		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060083E8 RID: 33768 RVA: 0x00100FCC File Offset: 0x000FF1CC
		public object Read(object value, ProtoReader source)
		{
			return BclHelpers.ReadNetObject(value, source, this.key, (this.type == typeof(object)) ? null : this.type, this.options);
		}

		// Token: 0x060083E9 RID: 33769 RVA: 0x0010100C File Offset: 0x000FF20C
		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteNetObject(value, dest, this.key, this.options);
		}

		// Token: 0x040028FF RID: 10495
		private readonly int key;

		// Token: 0x04002900 RID: 10496
		private readonly Type type;

		// Token: 0x04002901 RID: 10497
		private readonly BclHelpers.NetObjectOptions options;
	}
}
