using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageGuildInfo")]
	[Serializable]
	public class StageGuildInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildexp", DataFormat = DataFormat.TwosComplement)]
		public uint guildexp
		{
			get
			{
				return this._guildexp ?? 0U;
			}
			set
			{
				this._guildexp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildexpSpecified
		{
			get
			{
				return this._guildexp != null;
			}
			set
			{
				bool flag = value == (this._guildexp == null);
				if (flag)
				{
					this._guildexp = (value ? new uint?(this.guildexp) : null);
				}
			}
		}

		private bool ShouldSerializeguildexp()
		{
			return this.guildexpSpecified;
		}

		private void Resetguildexp()
		{
			this.guildexpSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildcon", DataFormat = DataFormat.TwosComplement)]
		public uint guildcon
		{
			get
			{
				return this._guildcon ?? 0U;
			}
			set
			{
				this._guildcon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildconSpecified
		{
			get
			{
				return this._guildcon != null;
			}
			set
			{
				bool flag = value == (this._guildcon == null);
				if (flag)
				{
					this._guildcon = (value ? new uint?(this.guildcon) : null);
				}
			}
		}

		private bool ShouldSerializeguildcon()
		{
			return this.guildconSpecified;
		}

		private void Resetguildcon()
		{
			this.guildconSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "dragon", DataFormat = DataFormat.TwosComplement)]
		public uint dragon
		{
			get
			{
				return this._dragon ?? 0U;
			}
			set
			{
				this._dragon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonSpecified
		{
			get
			{
				return this._dragon != null;
			}
			set
			{
				bool flag = value == (this._dragon == null);
				if (flag)
				{
					this._dragon = (value ? new uint?(this.dragon) : null);
				}
			}
		}

		private bool ShouldSerializedragon()
		{
			return this.dragonSpecified;
		}

		private void Resetdragon()
		{
			this.dragonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _guildexp;

		private uint? _guildcon;

		private uint? _dragon;

		private IExtension extensionObject;
	}
}
