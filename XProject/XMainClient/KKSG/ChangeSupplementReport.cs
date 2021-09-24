using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeSupplementReport")]
	[Serializable]
	public class ChangeSupplementReport : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong uniqueid
		{
			get
			{
				return this._uniqueid ?? 0UL;
			}
			set
			{
				this._uniqueid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uniqueidSpecified
		{
			get
			{
				return this._uniqueid != null;
			}
			set
			{
				bool flag = value == (this._uniqueid == null);
				if (flag)
				{
					this._uniqueid = (value ? new ulong?(this.uniqueid) : null);
				}
			}
		}

		private bool ShouldSerializeuniqueid()
		{
			return this.uniqueidSpecified;
		}

		private void Resetuniqueid()
		{
			this.uniqueidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uniqueid;

		private uint? _slot;

		private IExtension extensionObject;
	}
}
