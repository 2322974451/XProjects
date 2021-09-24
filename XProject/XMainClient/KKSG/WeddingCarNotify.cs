using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WeddingCarNotify")]
	[Serializable]
	public class WeddingCarNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance role1
		{
			get
			{
				return this._role1;
			}
			set
			{
				this._role1 = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance role2
		{
			get
			{
				return this._role2;
			}
			set
			{
				this._role2 = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private UnitAppearance _role1 = null;

		private UnitAppearance _role2 = null;

		private IExtension extensionObject;
	}
}
