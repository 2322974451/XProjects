using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000862 RID: 2146
	internal sealed class DefaultValueDecorator : ProtoDecoratorBase
	{
		// Token: 0x17002980 RID: 10624
		// (get) Token: 0x06008386 RID: 33670 RVA: 0x000FF754 File Offset: 0x000FD954
		public override Type ExpectedType
		{
			get
			{
				return this.Tail.ExpectedType;
			}
		}

		// Token: 0x17002981 RID: 10625
		// (get) Token: 0x06008387 RID: 33671 RVA: 0x000FF774 File Offset: 0x000FD974
		public override bool RequiresOldValue
		{
			get
			{
				return this.Tail.RequiresOldValue;
			}
		}

		// Token: 0x17002982 RID: 10626
		// (get) Token: 0x06008388 RID: 33672 RVA: 0x000FF794 File Offset: 0x000FD994
		public override bool ReturnsValue
		{
			get
			{
				return this.Tail.ReturnsValue;
			}
		}

		// Token: 0x06008389 RID: 33673 RVA: 0x000FF7B4 File Offset: 0x000FD9B4
		public DefaultValueDecorator(TypeModel model, object defaultValue, IProtoSerializer tail) : base(tail)
		{
			bool flag = defaultValue == null;
			if (flag)
			{
				throw new ArgumentNullException("defaultValue");
			}
			Type type = model.MapType(defaultValue.GetType());
			bool flag2 = type != tail.ExpectedType;
			if (flag2)
			{
				throw new ArgumentException("Default value is of incorrect type", "defaultValue");
			}
			this.defaultValue = defaultValue;
		}

		// Token: 0x0600838A RID: 33674 RVA: 0x000FF814 File Offset: 0x000FDA14
		public override void Write(object value, ProtoWriter dest)
		{
			bool flag = !object.Equals(value, this.defaultValue);
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
		}

		// Token: 0x0600838B RID: 33675 RVA: 0x000FF848 File Offset: 0x000FDA48
		public override object Read(object value, ProtoReader source)
		{
			return this.Tail.Read(value, source);
		}

		// Token: 0x040028E1 RID: 10465
		private readonly object defaultValue;
	}
}
