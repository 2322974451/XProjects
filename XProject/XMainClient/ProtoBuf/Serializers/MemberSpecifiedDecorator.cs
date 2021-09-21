using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200086F RID: 2159
	internal sealed class MemberSpecifiedDecorator : ProtoDecoratorBase
	{
		// Token: 0x170029A7 RID: 10663
		// (get) Token: 0x060083DE RID: 33758 RVA: 0x00100E14 File Offset: 0x000FF014
		public override Type ExpectedType
		{
			get
			{
				return this.Tail.ExpectedType;
			}
		}

		// Token: 0x170029A8 RID: 10664
		// (get) Token: 0x060083DF RID: 33759 RVA: 0x00100E34 File Offset: 0x000FF034
		public override bool RequiresOldValue
		{
			get
			{
				return this.Tail.RequiresOldValue;
			}
		}

		// Token: 0x170029A9 RID: 10665
		// (get) Token: 0x060083E0 RID: 33760 RVA: 0x00100E54 File Offset: 0x000FF054
		public override bool ReturnsValue
		{
			get
			{
				return this.Tail.ReturnsValue;
			}
		}

		// Token: 0x060083E1 RID: 33761 RVA: 0x00100E74 File Offset: 0x000FF074
		public MemberSpecifiedDecorator(MethodInfo getSpecified, MethodInfo setSpecified, IProtoSerializer tail) : base(tail)
		{
			bool flag = getSpecified == null && setSpecified == null;
			if (flag)
			{
				throw new InvalidOperationException();
			}
			this.getSpecified = getSpecified;
			this.setSpecified = setSpecified;
		}

		// Token: 0x060083E2 RID: 33762 RVA: 0x00100EAC File Offset: 0x000FF0AC
		public override void Write(object value, ProtoWriter dest)
		{
			bool flag = this.getSpecified == null || (bool)this.getSpecified.Invoke(value, null);
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
		}

		// Token: 0x060083E3 RID: 33763 RVA: 0x00100EEC File Offset: 0x000FF0EC
		public override object Read(object value, ProtoReader source)
		{
			object result = this.Tail.Read(value, source);
			ProtoDecoratorBase.s_argsRead[0] = true;
			bool flag = this.setSpecified != null;
			if (flag)
			{
				this.setSpecified.Invoke(value, ProtoDecoratorBase.s_argsRead);
			}
			return result;
		}

		// Token: 0x040028FD RID: 10493
		private readonly MethodInfo getSpecified;

		// Token: 0x040028FE RID: 10494
		private readonly MethodInfo setSpecified;
	}
}
