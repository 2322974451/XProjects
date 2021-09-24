using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "petGetSkill")]
	[Serializable]
	public class petGetSkill : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "petLvl", DataFormat = DataFormat.TwosComplement)]
		public uint petLvl
		{
			get
			{
				return this._petLvl ?? 0U;
			}
			set
			{
				this._petLvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petLvlSpecified
		{
			get
			{
				return this._petLvl != null;
			}
			set
			{
				bool flag = value == (this._petLvl == null);
				if (flag)
				{
					this._petLvl = (value ? new uint?(this.petLvl) : null);
				}
			}
		}

		private bool ShouldSerializepetLvl()
		{
			return this.petLvlSpecified;
		}

		private void ResetpetLvl()
		{
			this.petLvlSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "skillid", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _petLvl;

		private uint? _skillid;

		private IExtension extensionObject;
	}
}
