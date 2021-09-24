using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BingSkillArg")]
	[Serializable]
	public class BingSkillArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "skillhash", DataFormat = DataFormat.TwosComplement)]
		public uint skillhash
		{
			get
			{
				return this._skillhash ?? 0U;
			}
			set
			{
				this._skillhash = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillhashSpecified
		{
			get
			{
				return this._skillhash != null;
			}
			set
			{
				bool flag = value == (this._skillhash == null);
				if (flag)
				{
					this._skillhash = (value ? new uint?(this.skillhash) : null);
				}
			}
		}

		private bool ShouldSerializeskillhash()
		{
			return this.skillhashSpecified;
		}

		private void Resetskillhash()
		{
			this.skillhashSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _slot;

		private uint? _skillhash;

		private IExtension extensionObject;
	}
}
