using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildLadderRank")]
	[Serializable]
	public class GuildLadderRank : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "wintimes", DataFormat = DataFormat.TwosComplement)]
		public uint wintimes
		{
			get
			{
				return this._wintimes ?? 0U;
			}
			set
			{
				this._wintimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wintimesSpecified
		{
			get
			{
				return this._wintimes != null;
			}
			set
			{
				bool flag = value == (this._wintimes == null);
				if (flag)
				{
					this._wintimes = (value ? new uint?(this.wintimes) : null);
				}
			}
		}

		private bool ShouldSerializewintimes()
		{
			return this.wintimesSpecified;
		}

		private void Resetwintimes()
		{
			this.wintimesSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public uint icon
		{
			get
			{
				return this._icon ?? 0U;
			}
			set
			{
				this._icon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new uint?(this.icon) : null);
				}
			}
		}

		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildid;

		private string _guildname;

		private uint? _wintimes;

		private uint? _icon;

		private IExtension extensionObject;
	}
}
