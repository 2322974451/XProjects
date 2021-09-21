using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E7 RID: 1767
	[ProtoContract(Name = "GuildTerrAllianceInfo")]
	[Serializable]
	public class GuildTerrAllianceInfo : IExtensible
	{
		// Token: 0x17002566 RID: 9574
		// (get) Token: 0x0600761D RID: 30237 RVA: 0x000E1FB0 File Offset: 0x000E01B0
		// (set) Token: 0x0600761E RID: 30238 RVA: 0x000E1FD1 File Offset: 0x000E01D1
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

		// Token: 0x17002567 RID: 9575
		// (get) Token: 0x0600761F RID: 30239 RVA: 0x000E1FDC File Offset: 0x000E01DC
		// (set) Token: 0x06007620 RID: 30240 RVA: 0x000E1FF8 File Offset: 0x000E01F8
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

		// Token: 0x06007621 RID: 30241 RVA: 0x000E2028 File Offset: 0x000E0228
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007622 RID: 30242 RVA: 0x000E2040 File Offset: 0x000E0240
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x17002568 RID: 9576
		// (get) Token: 0x06007623 RID: 30243 RVA: 0x000E204C File Offset: 0x000E024C
		// (set) Token: 0x06007624 RID: 30244 RVA: 0x000E2078 File Offset: 0x000E0278
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

		// Token: 0x17002569 RID: 9577
		// (get) Token: 0x06007625 RID: 30245 RVA: 0x000E2088 File Offset: 0x000E0288
		// (set) Token: 0x06007626 RID: 30246 RVA: 0x000E20A8 File Offset: 0x000E02A8
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

		// Token: 0x06007627 RID: 30247 RVA: 0x000E20EC File Offset: 0x000E02EC
		private bool ShouldSerializeguildlvl()
		{
			return this.guildlvlSpecified;
		}

		// Token: 0x06007628 RID: 30248 RVA: 0x000E2104 File Offset: 0x000E0304
		private void Resetguildlvl()
		{
			this.guildlvlSpecified = false;
		}

		// Token: 0x1700256A RID: 9578
		// (get) Token: 0x06007629 RID: 30249 RVA: 0x000E2110 File Offset: 0x000E0310
		// (set) Token: 0x0600762A RID: 30250 RVA: 0x000E213C File Offset: 0x000E033C
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

		// Token: 0x1700256B RID: 9579
		// (get) Token: 0x0600762B RID: 30251 RVA: 0x000E214C File Offset: 0x000E034C
		// (set) Token: 0x0600762C RID: 30252 RVA: 0x000E216C File Offset: 0x000E036C
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

		// Token: 0x0600762D RID: 30253 RVA: 0x000E21B0 File Offset: 0x000E03B0
		private bool ShouldSerializeguildRoleNum()
		{
			return this.guildRoleNumSpecified;
		}

		// Token: 0x0600762E RID: 30254 RVA: 0x000E21C8 File Offset: 0x000E03C8
		private void ResetguildRoleNum()
		{
			this.guildRoleNumSpecified = false;
		}

		// Token: 0x1700256C RID: 9580
		// (get) Token: 0x0600762F RID: 30255 RVA: 0x000E21D4 File Offset: 0x000E03D4
		// (set) Token: 0x06007630 RID: 30256 RVA: 0x000E2200 File Offset: 0x000E0400
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

		// Token: 0x1700256D RID: 9581
		// (get) Token: 0x06007631 RID: 30257 RVA: 0x000E2210 File Offset: 0x000E0410
		// (set) Token: 0x06007632 RID: 30258 RVA: 0x000E2230 File Offset: 0x000E0430
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

		// Token: 0x06007633 RID: 30259 RVA: 0x000E2274 File Offset: 0x000E0474
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007634 RID: 30260 RVA: 0x000E228C File Offset: 0x000E048C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x1700256E RID: 9582
		// (get) Token: 0x06007635 RID: 30261 RVA: 0x000E2298 File Offset: 0x000E0498
		// (set) Token: 0x06007636 RID: 30262 RVA: 0x000E22C5 File Offset: 0x000E04C5
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

		// Token: 0x1700256F RID: 9583
		// (get) Token: 0x06007637 RID: 30263 RVA: 0x000E22D4 File Offset: 0x000E04D4
		// (set) Token: 0x06007638 RID: 30264 RVA: 0x000E22F4 File Offset: 0x000E04F4
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

		// Token: 0x06007639 RID: 30265 RVA: 0x000E2338 File Offset: 0x000E0538
		private bool ShouldSerializeguildId()
		{
			return this.guildIdSpecified;
		}

		// Token: 0x0600763A RID: 30266 RVA: 0x000E2350 File Offset: 0x000E0550
		private void ResetguildId()
		{
			this.guildIdSpecified = false;
		}

		// Token: 0x0600763B RID: 30267 RVA: 0x000E235C File Offset: 0x000E055C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C01 RID: 7169
		private string _guildname;

		// Token: 0x04001C02 RID: 7170
		private uint? _guildlvl;

		// Token: 0x04001C03 RID: 7171
		private uint? _guildRoleNum;

		// Token: 0x04001C04 RID: 7172
		private uint? _time;

		// Token: 0x04001C05 RID: 7173
		private ulong? _guildId;

		// Token: 0x04001C06 RID: 7174
		private IExtension extensionObject;
	}
}
