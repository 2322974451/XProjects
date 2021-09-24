using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildTerrAllianceInfo")]
	[Serializable]
	public class GuildTerrAllianceInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
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

		[ProtoMember(2, IsRequired = false, Name = "guildlvl", DataFormat = DataFormat.TwosComplement)]
		public uint guildlvl
		{
			get
			{
				return this._guildlvl ?? 0U;
			}
			set
			{
				this._guildlvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildlvlSpecified
		{
			get
			{
				return this._guildlvl != null;
			}
			set
			{
				bool flag = value == (this._guildlvl == null);
				if (flag)
				{
					this._guildlvl = (value ? new uint?(this.guildlvl) : null);
				}
			}
		}

		private bool ShouldSerializeguildlvl()
		{
			return this.guildlvlSpecified;
		}

		private void Resetguildlvl()
		{
			this.guildlvlSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guildRoleNum", DataFormat = DataFormat.TwosComplement)]
		public uint guildRoleNum
		{
			get
			{
				return this._guildRoleNum ?? 0U;
			}
			set
			{
				this._guildRoleNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildRoleNumSpecified
		{
			get
			{
				return this._guildRoleNum != null;
			}
			set
			{
				bool flag = value == (this._guildRoleNum == null);
				if (flag)
				{
					this._guildRoleNum = (value ? new uint?(this.guildRoleNum) : null);
				}
			}
		}

		private bool ShouldSerializeguildRoleNum()
		{
			return this.guildRoleNumSpecified;
		}

		private void ResetguildRoleNum()
		{
			this.guildRoleNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildId", DataFormat = DataFormat.TwosComplement)]
		public ulong guildId
		{
			get
			{
				return this._guildId ?? 0UL;
			}
			set
			{
				this._guildId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildIdSpecified
		{
			get
			{
				return this._guildId != null;
			}
			set
			{
				bool flag = value == (this._guildId == null);
				if (flag)
				{
					this._guildId = (value ? new ulong?(this.guildId) : null);
				}
			}
		}

		private bool ShouldSerializeguildId()
		{
			return this.guildIdSpecified;
		}

		private void ResetguildId()
		{
			this.guildIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _guildname;

		private uint? _guildlvl;

		private uint? _guildRoleNum;

		private uint? _time;

		private ulong? _guildId;

		private IExtension extensionObject;
	}
}
