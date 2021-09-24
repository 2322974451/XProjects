using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DragonGroupDB")]
	[Serializable]
	public class DragonGroupDB : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGroupRecordS2C record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "rolelist", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DragonGroupRoleListS2C rolelist
		{
			get
			{
				return this._rolelist;
			}
			set
			{
				this._rolelist = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private DragonGroupRecordS2C _record = null;

		private DragonGroupRoleListS2C _rolelist = null;

		private IExtension extensionObject;
	}
}
