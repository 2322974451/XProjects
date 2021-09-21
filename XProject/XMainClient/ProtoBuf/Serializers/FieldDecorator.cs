using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000865 RID: 2149
	internal sealed class FieldDecorator : ProtoDecoratorBase
	{
		// Token: 0x17002989 RID: 10633
		// (get) Token: 0x0600839C RID: 33692 RVA: 0x000FFDB0 File Offset: 0x000FDFB0
		public override Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		// Token: 0x1700298A RID: 10634
		// (get) Token: 0x0600839D RID: 33693 RVA: 0x000FFDC8 File Offset: 0x000FDFC8
		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700298B RID: 10635
		// (get) Token: 0x0600839E RID: 33694 RVA: 0x000FFDDC File Offset: 0x000FDFDC
		public override bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600839F RID: 33695 RVA: 0x000FFDEF File Offset: 0x000FDFEF
		public FieldDecorator(Type forType, FieldInfo field, IProtoSerializer tail) : base(tail)
		{
			Helpers.DebugAssert(forType != null);
			Helpers.DebugAssert(field != null);
			this.forType = forType;
			this.field = field;
		}

		// Token: 0x060083A0 RID: 33696 RVA: 0x000FFE1C File Offset: 0x000FE01C
		public override void Write(object value, ProtoWriter dest)
		{
			Helpers.DebugAssert(value != null);
			value = this.field.GetValue(value);
			bool flag = value != null;
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
		}

		// Token: 0x060083A1 RID: 33697 RVA: 0x000FFE58 File Offset: 0x000FE058
		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value != null);
			object obj = this.Tail.Read(this.Tail.RequiresOldValue ? this.field.GetValue(value) : null, source);
			bool flag = obj != null;
			if (flag)
			{
				this.field.SetValue(value, obj);
			}
			return null;
		}

		// Token: 0x040028E5 RID: 10469
		private readonly FieldInfo field;

		// Token: 0x040028E6 RID: 10470
		private readonly Type forType;
	}
}
