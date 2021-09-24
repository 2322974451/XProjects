using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class UriDecorator : ProtoDecoratorBase
	{

		public UriDecorator(TypeModel model, IProtoSerializer tail) : base(tail)
		{
		}

		public override Type ExpectedType
		{
			get
			{
				return UriDecorator.expectedType;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public override void Write(object value, ProtoWriter dest)
		{
			this.Tail.Write(((Uri)value).AbsoluteUri, dest);
		}

		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			string text = (string)this.Tail.Read(null, source);
			return (text.Length == 0) ? null : new Uri(text);
		}

		private static readonly Type expectedType = typeof(Uri);
	}
}
