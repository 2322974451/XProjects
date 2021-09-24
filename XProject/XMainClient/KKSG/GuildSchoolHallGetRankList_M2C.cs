using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildSchoolHallGetRankList_M2C")]
	[Serializable]
	public class GuildSchoolHallGetRankList_M2C : IExtensible
	{

		[ProtoMember(1, Name = "unranklist", DataFormat = DataFormat.Default)]
		public List<GuildSchoolHallRankData> unranklist
		{
			get
			{
				return this._unranklist;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "guildweeklyschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyschoolpoint
		{
			get
			{
				return this._guildweeklyschoolpoint ?? 0U;
			}
			set
			{
				this._guildweeklyschoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyschoolpointSpecified
		{
			get
			{
				return this._guildweeklyschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyschoolpoint == null);
				if (flag)
				{
					this._guildweeklyschoolpoint = (value ? new uint?(this.guildweeklyschoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializeguildweeklyschoolpoint()
		{
			return this.guildweeklyschoolpointSpecified;
		}

		private void Resetguildweeklyschoolpoint()
		{
			this.guildweeklyschoolpointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "guildweeklyhallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyhallpoint
		{
			get
			{
				return this._guildweeklyhallpoint ?? 0U;
			}
			set
			{
				this._guildweeklyhallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyhallpointSpecified
		{
			get
			{
				return this._guildweeklyhallpoint != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyhallpoint == null);
				if (flag)
				{
					this._guildweeklyhallpoint = (value ? new uint?(this.guildweeklyhallpoint) : null);
				}
			}
		}

		private bool ShouldSerializeguildweeklyhallpoint()
		{
			return this.guildweeklyhallpointSpecified;
		}

		private void Resetguildweeklyhallpoint()
		{
			this.guildweeklyhallpointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		private void Resetec()
		{
			this.ecSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildweeklyhuntingcount", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklyhuntingcount
		{
			get
			{
				return this._guildweeklyhuntingcount ?? 0U;
			}
			set
			{
				this._guildweeklyhuntingcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklyhuntingcountSpecified
		{
			get
			{
				return this._guildweeklyhuntingcount != null;
			}
			set
			{
				bool flag = value == (this._guildweeklyhuntingcount == null);
				if (flag)
				{
					this._guildweeklyhuntingcount = (value ? new uint?(this.guildweeklyhuntingcount) : null);
				}
			}
		}

		private bool ShouldSerializeguildweeklyhuntingcount()
		{
			return this.guildweeklyhuntingcountSpecified;
		}

		private void Resetguildweeklyhuntingcount()
		{
			this.guildweeklyhuntingcountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "guildweeklydonatecount", DataFormat = DataFormat.TwosComplement)]
		public uint guildweeklydonatecount
		{
			get
			{
				return this._guildweeklydonatecount ?? 0U;
			}
			set
			{
				this._guildweeklydonatecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildweeklydonatecountSpecified
		{
			get
			{
				return this._guildweeklydonatecount != null;
			}
			set
			{
				bool flag = value == (this._guildweeklydonatecount == null);
				if (flag)
				{
					this._guildweeklydonatecount = (value ? new uint?(this.guildweeklydonatecount) : null);
				}
			}
		}

		private bool ShouldSerializeguildweeklydonatecount()
		{
			return this.guildweeklydonatecountSpecified;
		}

		private void Resetguildweeklydonatecount()
		{
			this.guildweeklydonatecountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildSchoolHallRankData> _unranklist = new List<GuildSchoolHallRankData>();

		private uint? _guildweeklyschoolpoint;

		private uint? _guildweeklyhallpoint;

		private ErrorCode? _ec;

		private uint? _guildweeklyhuntingcount;

		private uint? _guildweeklydonatecount;

		private IExtension extensionObject;
	}
}
