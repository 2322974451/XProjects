using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AncientTimes")]
	[Serializable]
	public class AncientTimes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "award", DataFormat = DataFormat.TwosComplement)]
		public uint award
		{
			get
			{
				return this._award ?? 0U;
			}
			set
			{
				this._award = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool awardSpecified
		{
			get
			{
				return this._award != null;
			}
			set
			{
				bool flag = value == (this._award == null);
				if (flag)
				{
					this._award = (value ? new uint?(this.award) : null);
				}
			}
		}

		private bool ShouldSerializeaward()
		{
			return this.awardSpecified;
		}

		private void Resetaward()
		{
			this.awardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _award;

		private IExtension extensionObject;
	}
}
