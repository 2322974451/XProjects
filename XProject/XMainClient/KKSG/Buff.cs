using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Buff")]
	[Serializable]
	public class Buff : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "buffID", DataFormat = DataFormat.TwosComplement)]
		public int buffID
		{
			get
			{
				return this._buffID ?? 0;
			}
			set
			{
				this._buffID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffIDSpecified
		{
			get
			{
				return this._buffID != null;
			}
			set
			{
				bool flag = value == (this._buffID == null);
				if (flag)
				{
					this._buffID = (value ? new int?(this.buffID) : null);
				}
			}
		}

		private bool ShouldSerializebuffID()
		{
			return this.buffIDSpecified;
		}

		private void ResetbuffID()
		{
			this.buffIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "buffLevel", DataFormat = DataFormat.TwosComplement)]
		public int buffLevel
		{
			get
			{
				return this._buffLevel ?? 0;
			}
			set
			{
				this._buffLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buffLevelSpecified
		{
			get
			{
				return this._buffLevel != null;
			}
			set
			{
				bool flag = value == (this._buffLevel == null);
				if (flag)
				{
					this._buffLevel = (value ? new int?(this.buffLevel) : null);
				}
			}
		}

		private bool ShouldSerializebuffLevel()
		{
			return this.buffLevelSpecified;
		}

		private void ResetbuffLevel()
		{
			this.buffLevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "effecttime", DataFormat = DataFormat.TwosComplement)]
		public uint effecttime
		{
			get
			{
				return this._effecttime ?? 0U;
			}
			set
			{
				this._effecttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool effecttimeSpecified
		{
			get
			{
				return this._effecttime != null;
			}
			set
			{
				bool flag = value == (this._effecttime == null);
				if (flag)
				{
					this._effecttime = (value ? new uint?(this.effecttime) : null);
				}
			}
		}

		private bool ShouldSerializeeffecttime()
		{
			return this.effecttimeSpecified;
		}

		private void Reseteffecttime()
		{
			this.effecttimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "skillID", DataFormat = DataFormat.TwosComplement)]
		public uint skillID
		{
			get
			{
				return this._skillID ?? 0U;
			}
			set
			{
				this._skillID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool skillIDSpecified
		{
			get
			{
				return this._skillID != null;
			}
			set
			{
				bool flag = value == (this._skillID == null);
				if (flag)
				{
					this._skillID = (value ? new uint?(this.skillID) : null);
				}
			}
		}

		private bool ShouldSerializeskillID()
		{
			return this.skillIDSpecified;
		}

		private void ResetskillID()
		{
			this.skillIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _buffID;

		private int? _buffLevel;

		private uint? _effecttime;

		private uint? _skillID;

		private IExtension extensionObject;
	}
}
