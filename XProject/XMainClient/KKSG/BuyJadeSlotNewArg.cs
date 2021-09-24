using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyJadeSlotNewArg")]
	[Serializable]
	public class BuyJadeSlotNewArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "EquipUId", DataFormat = DataFormat.Default)]
		public string EquipUId
		{
			get
			{
				return this._EquipUId ?? "";
			}
			set
			{
				this._EquipUId = value;
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
					this._EquipUId = (value ? this.EquipUId : null);
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

		private string _EquipUId;

		private IExtension extensionObject;
	}
}
