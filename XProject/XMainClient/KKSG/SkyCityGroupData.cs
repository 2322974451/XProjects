using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B4 RID: 1716
	[ProtoContract(Name = "SkyCityGroupData")]
	[Serializable]
	public class SkyCityGroupData : IExtensible
	{
		// Token: 0x1700239D RID: 9117
		// (get) Token: 0x06007081 RID: 28801 RVA: 0x000D74BC File Offset: 0x000D56BC
		// (set) Token: 0x06007082 RID: 28802 RVA: 0x000D74E8 File Offset: 0x000D56E8
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

		// Token: 0x1700239E RID: 9118
		// (get) Token: 0x06007083 RID: 28803 RVA: 0x000D74F8 File Offset: 0x000D56F8
		// (set) Token: 0x06007084 RID: 28804 RVA: 0x000D7518 File Offset: 0x000D5718
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

		// Token: 0x06007085 RID: 28805 RVA: 0x000D755C File Offset: 0x000D575C
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06007086 RID: 28806 RVA: 0x000D7574 File Offset: 0x000D5774
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700239F RID: 9119
		// (get) Token: 0x06007087 RID: 28807 RVA: 0x000D7580 File Offset: 0x000D5780
		// (set) Token: 0x06007088 RID: 28808 RVA: 0x000D75AC File Offset: 0x000D57AC
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

		// Token: 0x170023A0 RID: 9120
		// (get) Token: 0x06007089 RID: 28809 RVA: 0x000D75BC File Offset: 0x000D57BC
		// (set) Token: 0x0600708A RID: 28810 RVA: 0x000D75DC File Offset: 0x000D57DC
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

		// Token: 0x0600708B RID: 28811 RVA: 0x000D7620 File Offset: 0x000D5820
		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		// Token: 0x0600708C RID: 28812 RVA: 0x000D7638 File Offset: 0x000D5838
		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		// Token: 0x170023A1 RID: 9121
		// (get) Token: 0x0600708D RID: 28813 RVA: 0x000D7644 File Offset: 0x000D5844
		// (set) Token: 0x0600708E RID: 28814 RVA: 0x000D7678 File Offset: 0x000D5878
		[ProtoMember(3, IsRequired = false, Name = "totaldamage", DataFormat = DataFormat.TwosComplement)]
		public double totaldamage
		{
			get
			{
				return this._totaldamage ?? 0.0;
			}
			set
			{
				this._totaldamage = new double?(value);
			}
		}

		// Token: 0x170023A2 RID: 9122
		// (get) Token: 0x0600708F RID: 28815 RVA: 0x000D7688 File Offset: 0x000D5888
		// (set) Token: 0x06007090 RID: 28816 RVA: 0x000D76A8 File Offset: 0x000D58A8
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
					this._totaldamage = (value ? new double?(this.totaldamage) : null);
				}
			}
		}

		// Token: 0x06007091 RID: 28817 RVA: 0x000D76EC File Offset: 0x000D58EC
		private bool ShouldSerializetotaldamage()
		{
			return this.totaldamageSpecified;
		}

		// Token: 0x06007092 RID: 28818 RVA: 0x000D7704 File Offset: 0x000D5904
		private void Resettotaldamage()
		{
			this.totaldamageSpecified = false;
		}

		// Token: 0x06007093 RID: 28819 RVA: 0x000D7710 File Offset: 0x000D5910
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001ADD RID: 6877
		private uint? _teamid;

		// Token: 0x04001ADE RID: 6878
		private uint? _killcount;

		// Token: 0x04001ADF RID: 6879
		private double? _totaldamage;

		// Token: 0x04001AE0 RID: 6880
		private IExtension extensionObject;
	}
}
