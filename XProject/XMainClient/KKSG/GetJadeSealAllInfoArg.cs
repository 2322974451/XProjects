using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetJadeSealAllInfoArg")]
	[Serializable]
	public class GetJadeSealAllInfoArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "equipPos", DataFormat = DataFormat.TwosComplement)]
		public int equipPos
		{
			get
			{
				return this._equipPos ?? 0;
			}
			set
			{
				this._equipPos = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool equipPosSpecified
		{
			get
			{
				return this._equipPos != null;
			}
			set
			{
				bool flag = value == (this._equipPos == null);
				if (flag)
				{
					this._equipPos = (value ? new int?(this.equipPos) : null);
				}
			}
		}

		private bool ShouldSerializeequipPos()
		{
			return this.equipPosSpecified;
		}

		private void ResetequipPos()
		{
			this.equipPosSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _equipPos;

		private IExtension extensionObject;
	}
}
