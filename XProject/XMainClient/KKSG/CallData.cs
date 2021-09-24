using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CallData")]
	[Serializable]
	public class CallData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "skillid", DataFormat = DataFormat.TwosComplement)]
		public uint skillid
		{
			get
			{
				return this._skillid ?? 0U;
			}
			set
			{
				this._skillid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillidSpecified
		{
			get
			{
				return this._skillid != null;
			}
			set
			{
				bool flag = value == (this._skillid == null);
				if (flag)
				{
					this._skillid = (value ? new uint?(this.skillid) : null);
				}
			}
		}

		private bool ShouldSerializeskillid()
		{
			return this.skillidSpecified;
		}

		private void Resetskillid()
		{
			this.skillidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sequence", DataFormat = DataFormat.TwosComplement)]
		public int sequence
		{
			get
			{
				return this._sequence ?? 0;
			}
			set
			{
				this._sequence = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sequenceSpecified
		{
			get
			{
				return this._sequence != null;
			}
			set
			{
				bool flag = value == (this._sequence == null);
				if (flag)
				{
					this._sequence = (value ? new int?(this.sequence) : null);
				}
			}
		}

		private bool ShouldSerializesequence()
		{
			return this.sequenceSpecified;
		}

		private void Resetsequence()
		{
			this.sequenceSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public int slot
		{
			get
			{
				return this._slot ?? 0;
			}
			set
			{
				this._slot = new int?(value);
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
					this._slot = (value ? new int?(this.slot) : null);
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

		[ProtoMember(4, IsRequired = false, Name = "leftrunningtime", DataFormat = DataFormat.TwosComplement)]
		public int leftrunningtime
		{
			get
			{
				return this._leftrunningtime ?? 0;
			}
			set
			{
				this._leftrunningtime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftrunningtimeSpecified
		{
			get
			{
				return this._leftrunningtime != null;
			}
			set
			{
				bool flag = value == (this._leftrunningtime == null);
				if (flag)
				{
					this._leftrunningtime = (value ? new int?(this.leftrunningtime) : null);
				}
			}
		}

		private bool ShouldSerializeleftrunningtime()
		{
			return this.leftrunningtimeSpecified;
		}

		private void Resetleftrunningtime()
		{
			this.leftrunningtimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "onsyntonic", DataFormat = DataFormat.Default)]
		public bool onsyntonic
		{
			get
			{
				return this._onsyntonic ?? false;
			}
			set
			{
				this._onsyntonic = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool onsyntonicSpecified
		{
			get
			{
				return this._onsyntonic != null;
			}
			set
			{
				bool flag = value == (this._onsyntonic == null);
				if (flag)
				{
					this._onsyntonic = (value ? new bool?(this.onsyntonic) : null);
				}
			}
		}

		private bool ShouldSerializeonsyntonic()
		{
			return this.onsyntonicSpecified;
		}

		private void Resetonsyntonic()
		{
			this.onsyntonicSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _skillid;

		private int? _sequence;

		private int? _slot;

		private int? _leftrunningtime;

		private bool? _onsyntonic;

		private IExtension extensionObject;
	}
}
