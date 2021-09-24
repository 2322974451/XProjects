using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Integralunit")]
	[Serializable]
	public class Integralunit : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildscore", DataFormat = DataFormat.TwosComplement)]
		public uint guildscore
		{
			get
			{
				return this._guildscore ?? 0U;
			}
			set
			{
				this._guildscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildscoreSpecified
		{
			get
			{
				return this._guildscore != null;
			}
			set
			{
				bool flag = value == (this._guildscore == null);
				if (flag)
				{
					this._guildscore = (value ? new uint?(this.guildscore) : null);
				}
			}
		}

		private bool ShouldSerializeguildscore()
		{
			return this.guildscoreSpecified;
		}

		private void Resetguildscore()
		{
			this.guildscoreSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildid;

		private uint? _guildscore;

		private string _name;

		private uint? _guildicon;

		private IExtension extensionObject;
	}
}
