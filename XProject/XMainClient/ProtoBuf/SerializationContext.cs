using System;

namespace ProtoBuf
{

	public sealed class SerializationContext
	{

		internal void Freeze()
		{
			this.frozen = true;
		}

		private void ThrowIfFrozen()
		{
			bool flag = this.frozen;
			if (flag)
			{
				throw new InvalidOperationException("The serialization-context cannot be changed once it is in use");
			}
		}

		public object Context
		{
			get
			{
				return this.context;
			}
			set
			{
				bool flag = this.context != value;
				if (flag)
				{
					this.ThrowIfFrozen();
					this.context = value;
				}
			}
		}

		static SerializationContext()
		{
			SerializationContext.@default.Freeze();
		}

		internal static SerializationContext Default
		{
			get
			{
				return SerializationContext.@default;
			}
		}

		private bool frozen;

		private object context;

		private static readonly SerializationContext @default = new SerializationContext();
	}
}
