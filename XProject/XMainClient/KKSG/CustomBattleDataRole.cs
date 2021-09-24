using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleDataRole")]
	[Serializable]
	public class CustomBattleDataRole : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleRole role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CustomBattleData _data = null;

		private CustomBattleRole _role = null;

		private IExtension extensionObject;
	}
}
