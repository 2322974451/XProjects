using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SelectHeroAncientPowerArg")]
	[Serializable]
	public class SelectHeroAncientPowerArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "selectpower", DataFormat = DataFormat.TwosComplement)]
		public uint selectpower
		{
			get
			{
				return this._selectpower ?? 0U;
			}
			set
			{
				this._selectpower = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selectpowerSpecified
		{
			get
			{
				return this._selectpower != null;
			}
			set
			{
				bool flag = value == (this._selectpower == null);
				if (flag)
				{
					this._selectpower = (value ? new uint?(this.selectpower) : null);
				}
			}
		}

		private bool ShouldSerializeselectpower()
		{
			return this.selectpowerSpecified;
		}

		private void Resetselectpower()
		{
			this.selectpowerSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _selectpower;

		private IExtension extensionObject;
	}
}
