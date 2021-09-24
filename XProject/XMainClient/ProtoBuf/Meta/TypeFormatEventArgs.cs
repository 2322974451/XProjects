using System;

namespace ProtoBuf.Meta
{

	public class TypeFormatEventArgs : EventArgs
	{

		public Type Type
		{
			get
			{
				return this.type;
			}
			set
			{
				bool flag = this.type != value;
				if (flag)
				{
					bool flag2 = this.typeFixed;
					if (flag2)
					{
						throw new InvalidOperationException("The type is fixed and cannot be changed");
					}
					this.type = value;
				}
			}
		}

		public string FormattedName
		{
			get
			{
				return this.formattedName;
			}
			set
			{
				bool flag = this.formattedName != value;
				if (flag)
				{
					bool flag2 = !this.typeFixed;
					if (flag2)
					{
						throw new InvalidOperationException("The formatted-name is fixed and cannot be changed");
					}
					this.formattedName = value;
				}
			}
		}

		internal TypeFormatEventArgs(string formattedName)
		{
			bool flag = Helpers.IsNullOrEmpty(formattedName);
			if (flag)
			{
				throw new ArgumentNullException("formattedName");
			}
			this.formattedName = formattedName;
		}

		internal TypeFormatEventArgs(Type type)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
			this.typeFixed = true;
		}

		private Type type;

		private string formattedName;

		private readonly bool typeFixed;
	}
}
