using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildTerrChallInfo")]
	[Serializable]
	public class GuildTerrChallInfo : IExtensible
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

		[ProtoMember(3, IsRequired = false, Name = "allianceid", DataFormat = DataFormat.TwosComplement)]
		public ulong allianceid
		{
			get
			{
				return this._allianceid ?? 0UL;
			}
			set
			{
				this._allianceid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allianceidSpecified
		{
			get
			{
				return this._allianceid != null;
			}
			set
			{
				bool flag = value == (this._allianceid == null);
				if (flag)
				{
					this._allianceid = (value ? new ulong?(this.allianceid) : null);
				}
			}
		}

		private bool ShouldSerializeallianceid()
		{
			return this.allianceidSpecified;
		}

		private void Resetallianceid()
		{
			this.allianceidSpecified = false;
		}

		[ProtoMember(4, Name = "tryallianceid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> tryallianceid
		{
			get
			{
				return this._tryallianceid;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildid;

		private string _guildname;

		private ulong? _allianceid;

		private readonly List<ulong> _tryallianceid = new List<ulong>();

		private IExtension extensionObject;
	}
}
