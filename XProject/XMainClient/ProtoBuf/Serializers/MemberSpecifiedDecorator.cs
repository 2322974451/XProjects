using System;
using System.Reflection;

namespace ProtoBuf.Serializers
{

	internal sealed class MemberSpecifiedDecorator : ProtoDecoratorBase
	{

		public override Type ExpectedType
		{
			get
			{
				return this.Tail.ExpectedType;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return this.Tail.RequiresOldValue;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return this.Tail.ReturnsValue;
			}
		}

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

		public override void Write(object value, ProtoWriter dest)
		{
			bool flag = this.getSpecified == null || (bool)this.getSpecified.Invoke(value, null);
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
		}

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

		private readonly MethodInfo getSpecified;

		private readonly MethodInfo setSpecified;
	}
}
