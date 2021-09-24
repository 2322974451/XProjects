using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{

	internal sealed class FieldDecorator : ProtoDecoratorBase
	{

		public override Type ExpectedType
		{
			get
			{
				return this.forType;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return false;
			}
		}

		public FieldDecorator(Type forType, FieldInfo field, IProtoSerializer tail) : base(tail)
		{
			Helpers.DebugAssert(forType != null);
			Helpers.DebugAssert(field != null);
			this.forType = forType;
			this.field = field;
		}

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

		private readonly FieldInfo field;

		private readonly Type forType;
	}
}
