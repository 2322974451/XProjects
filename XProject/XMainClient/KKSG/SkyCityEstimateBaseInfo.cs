using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006AD RID: 1709
	[ProtoContract(Name = "SkyCityEstimateBaseInfo")]
	[Serializable]
	public class SkyCityEstimateBaseInfo : IExtensible
	{
		// Token: 0x1700234A RID: 9034
		// (get) Token: 0x06006F7C RID: 28540 RVA: 0x000D5510 File Offset: 0x000D3710
		// (set) Token: 0x06006F7D RID: 28541 RVA: 0x000D553C File Offset: 0x000D373C
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

		// Token: 0x1700234B RID: 9035
		// (get) Token: 0x06006F7E RID: 28542 RVA: 0x000D554C File Offset: 0x000D374C
		// (set) Token: 0x06006F7F RID: 28543 RVA: 0x000D556C File Offset: 0x000D376C
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

		// Token: 0x06006F80 RID: 28544 RVA: 0x000D55B0 File Offset: 0x000D37B0
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06006F81 RID: 28545 RVA: 0x000D55C8 File Offset: 0x000D37C8
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x1700234C RID: 9036
		// (get) Token: 0x06006F82 RID: 28546 RVA: 0x000D55D4 File Offset: 0x000D37D4
		// (set) Token: 0x06006F83 RID: 28547 RVA: 0x000D5600 File Offset: 0x000D3800
		[ProtoMember(2, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		// Token: 0x1700234D RID: 9037
		// (get) Token: 0x06006F84 RID: 28548 RVA: 0x000D5610 File Offset: 0x000D3810
		// (set) Token: 0x06006F85 RID: 28549 RVA: 0x000D5630 File Offset: 0x000D3830
		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		// Token: 0x06006F86 RID: 28550 RVA: 0x000D5674 File Offset: 0x000D3874
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x06006F87 RID: 28551 RVA: 0x000D568C File Offset: 0x000D388C
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x1700234E RID: 9038
		// (get) Token: 0x06006F88 RID: 28552 RVA: 0x000D5698 File Offset: 0x000D3898
		// (set) Token: 0x06006F89 RID: 28553 RVA: 0x000D56B9 File Offset: 0x000D38B9
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700234F RID: 9039
		// (get) Token: 0x06006F8A RID: 28554 RVA: 0x000D56C4 File Offset: 0x000D38C4
		// (set) Token: 0x06006F8B RID: 28555 RVA: 0x000D56E0 File Offset: 0x000D38E0
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06006F8C RID: 28556 RVA: 0x000D5710 File Offset: 0x000D3910
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006F8D RID: 28557 RVA: 0x000D5728 File Offset: 0x000D3928
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002350 RID: 9040
		// (get) Token: 0x06006F8E RID: 28558 RVA: 0x000D5734 File Offset: 0x000D3934
		// (set) Token: 0x06006F8F RID: 28559 RVA: 0x000D5760 File Offset: 0x000D3960
		[ProtoMember(4, IsRequired = false, Name = "killer", DataFormat = DataFormat.TwosComplement)]
		public uint killer
		{
			get
			{
				return this._killer ?? 0U;
			}
			set
			{
				this._killer = new uint?(value);
			}
		}

		// Token: 0x17002351 RID: 9041
		// (get) Token: 0x06006F90 RID: 28560 RVA: 0x000D5770 File Offset: 0x000D3970
		// (set) Token: 0x06006F91 RID: 28561 RVA: 0x000D5790 File Offset: 0x000D3990
		[XmlIgnore]
		[Browsable(false)]
		public bool killerSpecified
		{
			get
			{
				return this._killer != null;
			}
			set
			{
				bool flag = value == (this._killer == null);
				if (flag)
				{
					this._killer = (value ? new uint?(this.killer) : null);
				}
			}
		}

		// Token: 0x06006F92 RID: 28562 RVA: 0x000D57D4 File Offset: 0x000D39D4
		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		// Token: 0x06006F93 RID: 28563 RVA: 0x000D57EC File Offset: 0x000D39EC
		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		// Token: 0x17002352 RID: 9042
		// (get) Token: 0x06006F94 RID: 28564 RVA: 0x000D57F8 File Offset: 0x000D39F8
		// (set) Token: 0x06006F95 RID: 28565 RVA: 0x000D5825 File Offset: 0x000D3A25
		[ProtoMember(5, IsRequired = false, Name = "damage", DataFormat = DataFormat.TwosComplement)]
		public ulong damage
		{
			get
			{
				return this._damage ?? 0UL;
			}
			set
			{
				this._damage = new ulong?(value);
			}
		}

		// Token: 0x17002353 RID: 9043
		// (get) Token: 0x06006F96 RID: 28566 RVA: 0x000D5834 File Offset: 0x000D3A34
		// (set) Token: 0x06006F97 RID: 28567 RVA: 0x000D5854 File Offset: 0x000D3A54
		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new ulong?(this.damage) : null);
				}
			}
		}

		// Token: 0x06006F98 RID: 28568 RVA: 0x000D5898 File Offset: 0x000D3A98
		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		// Token: 0x06006F99 RID: 28569 RVA: 0x000D58B0 File Offset: 0x000D3AB0
		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		// Token: 0x17002354 RID: 9044
		// (get) Token: 0x06006F9A RID: 28570 RVA: 0x000D58BC File Offset: 0x000D3ABC
		// (set) Token: 0x06006F9B RID: 28571 RVA: 0x000D58E8 File Offset: 0x000D3AE8
		[ProtoMember(6, IsRequired = false, Name = "lv", DataFormat = DataFormat.TwosComplement)]
		public uint lv
		{
			get
			{
				return this._lv ?? 0U;
			}
			set
			{
				this._lv = new uint?(value);
			}
		}

		// Token: 0x17002355 RID: 9045
		// (get) Token: 0x06006F9C RID: 28572 RVA: 0x000D58F8 File Offset: 0x000D3AF8
		// (set) Token: 0x06006F9D RID: 28573 RVA: 0x000D5918 File Offset: 0x000D3B18
		[XmlIgnore]
		[Browsable(false)]
		public bool lvSpecified
		{
			get
			{
				return this._lv != null;
			}
			set
			{
				bool flag = value == (this._lv == null);
				if (flag)
				{
					this._lv = (value ? new uint?(this.lv) : null);
				}
			}
		}

		// Token: 0x06006F9E RID: 28574 RVA: 0x000D595C File Offset: 0x000D3B5C
		private bool ShouldSerializelv()
		{
			return this.lvSpecified;
		}

		// Token: 0x06006F9F RID: 28575 RVA: 0x000D5974 File Offset: 0x000D3B74
		private void Resetlv()
		{
			this.lvSpecified = false;
		}

		// Token: 0x17002356 RID: 9046
		// (get) Token: 0x06006FA0 RID: 28576 RVA: 0x000D5980 File Offset: 0x000D3B80
		// (set) Token: 0x06006FA1 RID: 28577 RVA: 0x000D59AD File Offset: 0x000D3BAD
		[ProtoMember(7, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17002357 RID: 9047
		// (get) Token: 0x06006FA2 RID: 28578 RVA: 0x000D59BC File Offset: 0x000D3BBC
		// (set) Token: 0x06006FA3 RID: 28579 RVA: 0x000D59DC File Offset: 0x000D3BDC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06006FA4 RID: 28580 RVA: 0x000D5A20 File Offset: 0x000D3C20
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06006FA5 RID: 28581 RVA: 0x000D5A38 File Offset: 0x000D3C38
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06006FA6 RID: 28582 RVA: 0x000D5A44 File Offset: 0x000D3C44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AAC RID: 6828
		private uint? _teamid;

		// Token: 0x04001AAD RID: 6829
		private uint? _job;

		// Token: 0x04001AAE RID: 6830
		private string _name;

		// Token: 0x04001AAF RID: 6831
		private uint? _killer;

		// Token: 0x04001AB0 RID: 6832
		private ulong? _damage;

		// Token: 0x04001AB1 RID: 6833
		private uint? _lv;

		// Token: 0x04001AB2 RID: 6834
		private ulong? _roleid;

		// Token: 0x04001AB3 RID: 6835
		private IExtension extensionObject;
	}
}
