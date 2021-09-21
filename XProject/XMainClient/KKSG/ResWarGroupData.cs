using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C3 RID: 1731
	[ProtoContract(Name = "ResWarGroupData")]
	[Serializable]
	public class ResWarGroupData : IExtensible
	{
		// Token: 0x17002403 RID: 9219
		// (get) Token: 0x060071C3 RID: 29123 RVA: 0x000D9A44 File Offset: 0x000D7C44
		// (set) Token: 0x060071C4 RID: 29124 RVA: 0x000D9A70 File Offset: 0x000D7C70
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x17002404 RID: 9220
		// (get) Token: 0x060071C5 RID: 29125 RVA: 0x000D9A80 File Offset: 0x000D7C80
		// (set) Token: 0x060071C6 RID: 29126 RVA: 0x000D9AA0 File Offset: 0x000D7CA0
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x060071C7 RID: 29127 RVA: 0x000D9AE4 File Offset: 0x000D7CE4
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x060071C8 RID: 29128 RVA: 0x000D9AFC File Offset: 0x000D7CFC
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17002405 RID: 9221
		// (get) Token: 0x060071C9 RID: 29129 RVA: 0x000D9B08 File Offset: 0x000D7D08
		// (set) Token: 0x060071CA RID: 29130 RVA: 0x000D9B34 File Offset: 0x000D7D34
		[ProtoMember(2, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		// Token: 0x17002406 RID: 9222
		// (get) Token: 0x060071CB RID: 29131 RVA: 0x000D9B44 File Offset: 0x000D7D44
		// (set) Token: 0x060071CC RID: 29132 RVA: 0x000D9B64 File Offset: 0x000D7D64
		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		// Token: 0x060071CD RID: 29133 RVA: 0x000D9BA8 File Offset: 0x000D7DA8
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x060071CE RID: 29134 RVA: 0x000D9BC0 File Offset: 0x000D7DC0
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x17002407 RID: 9223
		// (get) Token: 0x060071CF RID: 29135 RVA: 0x000D9BCC File Offset: 0x000D7DCC
		// (set) Token: 0x060071D0 RID: 29136 RVA: 0x000D9BF8 File Offset: 0x000D7DF8
		[ProtoMember(3, IsRequired = false, Name = "totaldamage", DataFormat = DataFormat.TwosComplement)]
		public uint totaldamage
		{
			get
			{
				return this._totaldamage ?? 0U;
			}
			set
			{
				this._totaldamage = new uint?(value);
			}
		}

		// Token: 0x17002408 RID: 9224
		// (get) Token: 0x060071D1 RID: 29137 RVA: 0x000D9C08 File Offset: 0x000D7E08
		// (set) Token: 0x060071D2 RID: 29138 RVA: 0x000D9C28 File Offset: 0x000D7E28
		[XmlIgnore]
		[Browsable(false)]
		public bool totaldamageSpecified
		{
			get
			{
				return this._totaldamage != null;
			}
			set
			{
				bool flag = value == (this._totaldamage == null);
				if (flag)
				{
					this._totaldamage = (value ? new uint?(this.totaldamage) : null);
				}
			}
		}

		// Token: 0x060071D3 RID: 29139 RVA: 0x000D9C6C File Offset: 0x000D7E6C
		private bool ShouldSerializetotaldamage()
		{
			return this.totaldamageSpecified;
		}

		// Token: 0x060071D4 RID: 29140 RVA: 0x000D9C84 File Offset: 0x000D7E84
		private void Resettotaldamage()
		{
			this.totaldamageSpecified = false;
		}

		// Token: 0x060071D5 RID: 29141 RVA: 0x000D9C90 File Offset: 0x000D7E90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B24 RID: 6948
		private uint? _teamid;

		// Token: 0x04001B25 RID: 6949
		private uint? _killcount;

		// Token: 0x04001B26 RID: 6950
		private uint? _totaldamage;

		// Token: 0x04001B27 RID: 6951
		private IExtension extensionObject;
	}
}
