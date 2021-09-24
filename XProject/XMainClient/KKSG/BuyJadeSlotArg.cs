using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyJadeSlotArg")]
	[Serializable]
	public class BuyJadeSlotArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "EquipUId", DataFormat = DataFormat.TwosComplement)]
		public ulong EquipUId
		{
			get
			{
				return this._EquipUId ?? 0UL;
			}
			set
			{
				this._EquipUId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool EquipUIdSpecified
		{
			get
			{
				return this._EquipUId != null;
			}
			set
			{
				bool flag = value == (this._EquipUId == null);
				if (flag)
				{
					this._EquipUId = (value ? new ulong?(this.EquipUId) : null);
				}
			}
		}

		private bool ShouldSerializeEquipUId()
		{
			return this.EquipUIdSpecified;
		}

		private void ResetEquipUId()
		{
			this.EquipUIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _EquipUId;

		private IExtension extensionObject;
	}
}
