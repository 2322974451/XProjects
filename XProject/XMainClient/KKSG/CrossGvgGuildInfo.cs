using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000740 RID: 1856
	[ProtoContract(Name = "CrossGvgGuildInfo")]
	[Serializable]
	public class CrossGvgGuildInfo : IExtensible
	{
		// Token: 0x170028DC RID: 10460
		// (get) Token: 0x060080E1 RID: 32993 RVA: 0x000F6750 File Offset: 0x000F4950
		// (set) Token: 0x060080E2 RID: 32994 RVA: 0x000F677D File Offset: 0x000F497D
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

		// Token: 0x170028DD RID: 10461
		// (get) Token: 0x060080E3 RID: 32995 RVA: 0x000F678C File Offset: 0x000F498C
		// (set) Token: 0x060080E4 RID: 32996 RVA: 0x000F67AC File Offset: 0x000F49AC
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

		// Token: 0x060080E5 RID: 32997 RVA: 0x000F67F0 File Offset: 0x000F49F0
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x060080E6 RID: 32998 RVA: 0x000F6808 File Offset: 0x000F4A08
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x170028DE RID: 10462
		// (get) Token: 0x060080E7 RID: 32999 RVA: 0x000F6814 File Offset: 0x000F4A14
		// (set) Token: 0x060080E8 RID: 33000 RVA: 0x000F6835 File Offset: 0x000F4A35
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

		// Token: 0x170028DF RID: 10463
		// (get) Token: 0x060080E9 RID: 33001 RVA: 0x000F6840 File Offset: 0x000F4A40
		// (set) Token: 0x060080EA RID: 33002 RVA: 0x000F685C File Offset: 0x000F4A5C
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

		// Token: 0x060080EB RID: 33003 RVA: 0x000F688C File Offset: 0x000F4A8C
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x060080EC RID: 33004 RVA: 0x000F68A4 File Offset: 0x000F4AA4
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x170028E0 RID: 10464
		// (get) Token: 0x060080ED RID: 33005 RVA: 0x000F68B0 File Offset: 0x000F4AB0
		// (set) Token: 0x060080EE RID: 33006 RVA: 0x000F68DC File Offset: 0x000F4ADC
		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x170028E1 RID: 10465
		// (get) Token: 0x060080EF RID: 33007 RVA: 0x000F68EC File Offset: 0x000F4AEC
		// (set) Token: 0x060080F0 RID: 33008 RVA: 0x000F690C File Offset: 0x000F4B0C
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x060080F1 RID: 33009 RVA: 0x000F6950 File Offset: 0x000F4B50
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x060080F2 RID: 33010 RVA: 0x000F6968 File Offset: 0x000F4B68
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x170028E2 RID: 10466
		// (get) Token: 0x060080F3 RID: 33011 RVA: 0x000F6974 File Offset: 0x000F4B74
		// (set) Token: 0x060080F4 RID: 33012 RVA: 0x000F6995 File Offset: 0x000F4B95
		[ProtoMember(4, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x170028E3 RID: 10467
		// (get) Token: 0x060080F5 RID: 33013 RVA: 0x000F69A0 File Offset: 0x000F4BA0
		// (set) Token: 0x060080F6 RID: 33014 RVA: 0x000F69BC File Offset: 0x000F4BBC
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x060080F7 RID: 33015 RVA: 0x000F69EC File Offset: 0x000F4BEC
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x060080F8 RID: 33016 RVA: 0x000F6A04 File Offset: 0x000F4C04
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x170028E4 RID: 10468
		// (get) Token: 0x060080F9 RID: 33017 RVA: 0x000F6A10 File Offset: 0x000F4C10
		// (set) Token: 0x060080FA RID: 33018 RVA: 0x000F6A3C File Offset: 0x000F4C3C
		[ProtoMember(5, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x170028E5 RID: 10469
		// (get) Token: 0x060080FB RID: 33019 RVA: 0x000F6A4C File Offset: 0x000F4C4C
		// (set) Token: 0x060080FC RID: 33020 RVA: 0x000F6A6C File Offset: 0x000F4C6C
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x060080FD RID: 33021 RVA: 0x000F6AB0 File Offset: 0x000F4CB0
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x060080FE RID: 33022 RVA: 0x000F6AC8 File Offset: 0x000F4CC8
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x170028E6 RID: 10470
		// (get) Token: 0x060080FF RID: 33023 RVA: 0x000F6AD4 File Offset: 0x000F4CD4
		// (set) Token: 0x06008100 RID: 33024 RVA: 0x000F6B00 File Offset: 0x000F4D00
		[ProtoMember(6, IsRequired = false, Name = "killnum", DataFormat = DataFormat.TwosComplement)]
		public uint killnum
		{
			get
			{
				return this._killnum ?? 0U;
			}
			set
			{
				this._killnum = new uint?(value);
			}
		}

		// Token: 0x170028E7 RID: 10471
		// (get) Token: 0x06008101 RID: 33025 RVA: 0x000F6B10 File Offset: 0x000F4D10
		// (set) Token: 0x06008102 RID: 33026 RVA: 0x000F6B30 File Offset: 0x000F4D30
		[XmlIgnore]
		[Browsable(false)]
		public bool killnumSpecified
		{
			get
			{
				return this._killnum != null;
			}
			set
			{
				bool flag = value == (this._killnum == null);
				if (flag)
				{
					this._killnum = (value ? new uint?(this.killnum) : null);
				}
			}
		}

		// Token: 0x06008103 RID: 33027 RVA: 0x000F6B74 File Offset: 0x000F4D74
		private bool ShouldSerializekillnum()
		{
			return this.killnumSpecified;
		}

		// Token: 0x06008104 RID: 33028 RVA: 0x000F6B8C File Offset: 0x000F4D8C
		private void Resetkillnum()
		{
			this.killnumSpecified = false;
		}

		// Token: 0x170028E8 RID: 10472
		// (get) Token: 0x06008105 RID: 33029 RVA: 0x000F6B98 File Offset: 0x000F4D98
		// (set) Token: 0x06008106 RID: 33030 RVA: 0x000F6BC4 File Offset: 0x000F4DC4
		[ProtoMember(7, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028E9 RID: 10473
		// (get) Token: 0x06008107 RID: 33031 RVA: 0x000F6BD4 File Offset: 0x000F4DD4
		// (set) Token: 0x06008108 RID: 33032 RVA: 0x000F6BF4 File Offset: 0x000F4DF4
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

		// Token: 0x06008109 RID: 33033 RVA: 0x000F6C38 File Offset: 0x000F4E38
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x0600810A RID: 33034 RVA: 0x000F6C50 File Offset: 0x000F4E50
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x170028EA RID: 10474
		// (get) Token: 0x0600810B RID: 33035 RVA: 0x000F6C5C File Offset: 0x000F4E5C
		// (set) Token: 0x0600810C RID: 33036 RVA: 0x000F6C88 File Offset: 0x000F4E88
		[ProtoMember(8, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
		public uint prestige
		{
			get
			{
				return this._prestige ?? 0U;
			}
			set
			{
				this._prestige = new uint?(value);
			}
		}

		// Token: 0x170028EB RID: 10475
		// (get) Token: 0x0600810D RID: 33037 RVA: 0x000F6C98 File Offset: 0x000F4E98
		// (set) Token: 0x0600810E RID: 33038 RVA: 0x000F6CB8 File Offset: 0x000F4EB8
		[XmlIgnore]
		[Browsable(false)]
		public bool prestigeSpecified
		{
			get
			{
				return this._prestige != null;
			}
			set
			{
				bool flag = value == (this._prestige == null);
				if (flag)
				{
					this._prestige = (value ? new uint?(this.prestige) : null);
				}
			}
		}

		// Token: 0x0600810F RID: 33039 RVA: 0x000F6CFC File Offset: 0x000F4EFC
		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		// Token: 0x06008110 RID: 33040 RVA: 0x000F6D14 File Offset: 0x000F4F14
		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		// Token: 0x170028EC RID: 10476
		// (get) Token: 0x06008111 RID: 33041 RVA: 0x000F6D20 File Offset: 0x000F4F20
		// (set) Token: 0x06008112 RID: 33042 RVA: 0x000F6D4C File Offset: 0x000F4F4C
		[ProtoMember(9, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x170028ED RID: 10477
		// (get) Token: 0x06008113 RID: 33043 RVA: 0x000F6D5C File Offset: 0x000F4F5C
		// (set) Token: 0x06008114 RID: 33044 RVA: 0x000F6D7C File Offset: 0x000F4F7C
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06008115 RID: 33045 RVA: 0x000F6DC0 File Offset: 0x000F4FC0
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06008116 RID: 33046 RVA: 0x000F6DD8 File Offset: 0x000F4FD8
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170028EE RID: 10478
		// (get) Token: 0x06008117 RID: 33047 RVA: 0x000F6DE4 File Offset: 0x000F4FE4
		// (set) Token: 0x06008118 RID: 33048 RVA: 0x000F6E10 File Offset: 0x000F5010
		[ProtoMember(10, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170028EF RID: 10479
		// (get) Token: 0x06008119 RID: 33049 RVA: 0x000F6E20 File Offset: 0x000F5020
		// (set) Token: 0x0600811A RID: 33050 RVA: 0x000F6E40 File Offset: 0x000F5040
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

		// Token: 0x0600811B RID: 33051 RVA: 0x000F6E84 File Offset: 0x000F5084
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600811C RID: 33052 RVA: 0x000F6E9C File Offset: 0x000F509C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x0600811D RID: 33053 RVA: 0x000F6EA8 File Offset: 0x000F50A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001E30 RID: 7728
		private ulong? _guildid;

		// Token: 0x04001E31 RID: 7729
		private string _guildname;

		// Token: 0x04001E32 RID: 7730
		private uint? _serverid;

		// Token: 0x04001E33 RID: 7731
		private string _servername;

		// Token: 0x04001E34 RID: 7732
		private uint? _score;

		// Token: 0x04001E35 RID: 7733
		private uint? _killnum;

		// Token: 0x04001E36 RID: 7734
		private uint? _icon;

		// Token: 0x04001E37 RID: 7735
		private uint? _prestige;

		// Token: 0x04001E38 RID: 7736
		private uint? _level;

		// Token: 0x04001E39 RID: 7737
		private uint? _time;

		// Token: 0x04001E3A RID: 7738
		private IExtension extensionObject;
	}
}
