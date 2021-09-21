using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E9 RID: 1769
	[ProtoContract(Name = "HeroBattleTeamData")]
	[Serializable]
	public class HeroBattleTeamData : IExtensible
	{
		// Token: 0x1700257C RID: 9596
		// (get) Token: 0x06007663 RID: 30307 RVA: 0x000E280C File Offset: 0x000E0A0C
		// (set) Token: 0x06007664 RID: 30308 RVA: 0x000E2838 File Offset: 0x000E0A38
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

		// Token: 0x1700257D RID: 9597
		// (get) Token: 0x06007665 RID: 30309 RVA: 0x000E2848 File Offset: 0x000E0A48
		// (set) Token: 0x06007666 RID: 30310 RVA: 0x000E2868 File Offset: 0x000E0A68
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

		// Token: 0x06007667 RID: 30311 RVA: 0x000E28AC File Offset: 0x000E0AAC
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06007668 RID: 30312 RVA: 0x000E28C4 File Offset: 0x000E0AC4
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700257E RID: 9598
		// (get) Token: 0x06007669 RID: 30313 RVA: 0x000E28D0 File Offset: 0x000E0AD0
		// (set) Token: 0x0600766A RID: 30314 RVA: 0x000E28FC File Offset: 0x000E0AFC
		[ProtoMember(2, IsRequired = false, Name = "headcount", DataFormat = DataFormat.TwosComplement)]
		public uint headcount
		{
			get
			{
				return this._headcount ?? 0U;
			}
			set
			{
				this._headcount = new uint?(value);
			}
		}

		// Token: 0x1700257F RID: 9599
		// (get) Token: 0x0600766B RID: 30315 RVA: 0x000E290C File Offset: 0x000E0B0C
		// (set) Token: 0x0600766C RID: 30316 RVA: 0x000E292C File Offset: 0x000E0B2C
		[XmlIgnore]
		[Browsable(false)]
		public bool headcountSpecified
		{
			get
			{
				return this._headcount != null;
			}
			set
			{
				bool flag = value == (this._headcount == null);
				if (flag)
				{
					this._headcount = (value ? new uint?(this.headcount) : null);
				}
			}
		}

		// Token: 0x0600766D RID: 30317 RVA: 0x000E2970 File Offset: 0x000E0B70
		private bool ShouldSerializeheadcount()
		{
			return this.headcountSpecified;
		}

		// Token: 0x0600766E RID: 30318 RVA: 0x000E2988 File Offset: 0x000E0B88
		private void Resetheadcount()
		{
			this.headcountSpecified = false;
		}

		// Token: 0x17002580 RID: 9600
		// (get) Token: 0x0600766F RID: 30319 RVA: 0x000E2994 File Offset: 0x000E0B94
		// (set) Token: 0x06007670 RID: 30320 RVA: 0x000E29C0 File Offset: 0x000E0BC0
		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17002581 RID: 9601
		// (get) Token: 0x06007671 RID: 30321 RVA: 0x000E29D0 File Offset: 0x000E0BD0
		// (set) Token: 0x06007672 RID: 30322 RVA: 0x000E29F0 File Offset: 0x000E0BF0
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06007673 RID: 30323 RVA: 0x000E2A34 File Offset: 0x000E0C34
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06007674 RID: 30324 RVA: 0x000E2A4C File Offset: 0x000E0C4C
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x06007675 RID: 30325 RVA: 0x000E2A58 File Offset: 0x000E0C58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C0E RID: 7182
		private uint? _teamid;

		// Token: 0x04001C0F RID: 7183
		private uint? _headcount;

		// Token: 0x04001C10 RID: 7184
		private uint? _point;

		// Token: 0x04001C11 RID: 7185
		private IExtension extensionObject;
	}
}
