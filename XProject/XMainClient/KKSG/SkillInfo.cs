using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkillInfo")]
	[Serializable]
	public class SkillInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "skillHash", DataFormat = DataFormat.TwosComplement)]
		public uint skillHash
		{
			get
			{
				return this._skillHash ?? 0U;
			}
			set
			{
				this._skillHash = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillHashSpecified
		{
			get
			{
				return this._skillHash != null;
			}
			set
			{
				bool flag = value == (this._skillHash == null);
				if (flag)
				{
					this._skillHash = (value ? new uint?(this.skillHash) : null);
				}
			}
		}

		private bool ShouldSerializeskillHash()
		{
			return this.skillHashSpecified;
		}

		private void ResetskillHash()
		{
			this.skillHashSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "skillLevel", DataFormat = DataFormat.TwosComplement)]
		public uint skillLevel
		{
			get
			{
				return this._skillLevel ?? 0U;
			}
			set
			{
				this._skillLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillLevelSpecified
		{
			get
			{
				return this._skillLevel != null;
			}
			set
			{
				bool flag = value == (this._skillLevel == null);
				if (flag)
				{
					this._skillLevel = (value ? new uint?(this.skillLevel) : null);
				}
			}
		}

		private bool ShouldSerializeskillLevel()
		{
			return this.skillLevelSpecified;
		}

		private void ResetskillLevel()
		{
			this.skillLevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "skillpoint", DataFormat = DataFormat.TwosComplement)]
		public uint skillpoint
		{
			get
			{
				return this._skillpoint ?? 0U;
			}
			set
			{
				this._skillpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillpointSpecified
		{
			get
			{
				return this._skillpoint != null;
			}
			set
			{
				bool flag = value == (this._skillpoint == null);
				if (flag)
				{
					this._skillpoint = (value ? new uint?(this.skillpoint) : null);
				}
			}
		}

		private bool ShouldSerializeskillpoint()
		{
			return this.skillpointSpecified;
		}

		private void Resetskillpoint()
		{
			this.skillpointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isbasic", DataFormat = DataFormat.Default)]
		public bool isbasic
		{
			get
			{
				return this._isbasic ?? false;
			}
			set
			{
				this._isbasic = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isbasicSpecified
		{
			get
			{
				return this._isbasic != null;
			}
			set
			{
				bool flag = value == (this._isbasic == null);
				if (flag)
				{
					this._isbasic = (value ? new bool?(this.isbasic) : null);
				}
			}
		}

		private bool ShouldSerializeisbasic()
		{
			return this.isbasicSpecified;
		}

		private void Resetisbasic()
		{
			this.isbasicSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _skillHash;

		private uint? _skillLevel;

		private uint? _skillpoint;

		private bool? _isbasic;

		private IExtension extensionObject;
	}
}
