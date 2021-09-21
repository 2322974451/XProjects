using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DE RID: 1502
	[ProtoContract(Name = "BattleFieldBattleResult")]
	[Serializable]
	public class BattleFieldBattleResult : IExtensible
	{
		// Token: 0x17001AE8 RID: 6888
		// (get) Token: 0x060056A8 RID: 22184 RVA: 0x000A504C File Offset: 0x000A324C
		// (set) Token: 0x060056A9 RID: 22185 RVA: 0x000A5079 File Offset: 0x000A3279
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001AE9 RID: 6889
		// (get) Token: 0x060056AA RID: 22186 RVA: 0x000A5088 File Offset: 0x000A3288
		// (set) Token: 0x060056AB RID: 22187 RVA: 0x000A50A8 File Offset: 0x000A32A8
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

		// Token: 0x060056AC RID: 22188 RVA: 0x000A50EC File Offset: 0x000A32EC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060056AD RID: 22189 RVA: 0x000A5104 File Offset: 0x000A3304
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001AEA RID: 6890
		// (get) Token: 0x060056AE RID: 22190 RVA: 0x000A5110 File Offset: 0x000A3310
		// (set) Token: 0x060056AF RID: 22191 RVA: 0x000A513C File Offset: 0x000A333C
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17001AEB RID: 6891
		// (get) Token: 0x060056B0 RID: 22192 RVA: 0x000A514C File Offset: 0x000A334C
		// (set) Token: 0x060056B1 RID: 22193 RVA: 0x000A516C File Offset: 0x000A336C
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x060056B2 RID: 22194 RVA: 0x000A51B0 File Offset: 0x000A33B0
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060056B3 RID: 22195 RVA: 0x000A51C8 File Offset: 0x000A33C8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001AEC RID: 6892
		// (get) Token: 0x060056B4 RID: 22196 RVA: 0x000A51D4 File Offset: 0x000A33D4
		// (set) Token: 0x060056B5 RID: 22197 RVA: 0x000A5200 File Offset: 0x000A3400
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

		// Token: 0x17001AED RID: 6893
		// (get) Token: 0x060056B6 RID: 22198 RVA: 0x000A5210 File Offset: 0x000A3410
		// (set) Token: 0x060056B7 RID: 22199 RVA: 0x000A5230 File Offset: 0x000A3430
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

		// Token: 0x060056B8 RID: 22200 RVA: 0x000A5274 File Offset: 0x000A3474
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060056B9 RID: 22201 RVA: 0x000A528C File Offset: 0x000A348C
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17001AEE RID: 6894
		// (get) Token: 0x060056BA RID: 22202 RVA: 0x000A5298 File Offset: 0x000A3498
		// (set) Token: 0x060056BB RID: 22203 RVA: 0x000A52C4 File Offset: 0x000A34C4
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

		// Token: 0x17001AEF RID: 6895
		// (get) Token: 0x060056BC RID: 22204 RVA: 0x000A52D4 File Offset: 0x000A34D4
		// (set) Token: 0x060056BD RID: 22205 RVA: 0x000A52F4 File Offset: 0x000A34F4
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

		// Token: 0x060056BE RID: 22206 RVA: 0x000A5338 File Offset: 0x000A3538
		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		// Token: 0x060056BF RID: 22207 RVA: 0x000A5350 File Offset: 0x000A3550
		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		// Token: 0x17001AF0 RID: 6896
		// (get) Token: 0x060056C0 RID: 22208 RVA: 0x000A535C File Offset: 0x000A355C
		// (set) Token: 0x060056C1 RID: 22209 RVA: 0x000A5388 File Offset: 0x000A3588
		[ProtoMember(5, IsRequired = false, Name = "death", DataFormat = DataFormat.TwosComplement)]
		public uint death
		{
			get
			{
				return this._death ?? 0U;
			}
			set
			{
				this._death = new uint?(value);
			}
		}

		// Token: 0x17001AF1 RID: 6897
		// (get) Token: 0x060056C2 RID: 22210 RVA: 0x000A5398 File Offset: 0x000A3598
		// (set) Token: 0x060056C3 RID: 22211 RVA: 0x000A53B8 File Offset: 0x000A35B8
		[XmlIgnore]
		[Browsable(false)]
		public bool deathSpecified
		{
			get
			{
				return this._death != null;
			}
			set
			{
				bool flag = value == (this._death == null);
				if (flag)
				{
					this._death = (value ? new uint?(this.death) : null);
				}
			}
		}

		// Token: 0x060056C4 RID: 22212 RVA: 0x000A53FC File Offset: 0x000A35FC
		private bool ShouldSerializedeath()
		{
			return this.deathSpecified;
		}

		// Token: 0x060056C5 RID: 22213 RVA: 0x000A5414 File Offset: 0x000A3614
		private void Resetdeath()
		{
			this.deathSpecified = false;
		}

		// Token: 0x17001AF2 RID: 6898
		// (get) Token: 0x060056C6 RID: 22214 RVA: 0x000A5420 File Offset: 0x000A3620
		// (set) Token: 0x060056C7 RID: 22215 RVA: 0x000A5441 File Offset: 0x000A3641
		[ProtoMember(6, IsRequired = false, Name = "svrname", DataFormat = DataFormat.Default)]
		public string svrname
		{
			get
			{
				return this._svrname ?? "";
			}
			set
			{
				this._svrname = value;
			}
		}

		// Token: 0x17001AF3 RID: 6899
		// (get) Token: 0x060056C8 RID: 22216 RVA: 0x000A544C File Offset: 0x000A364C
		// (set) Token: 0x060056C9 RID: 22217 RVA: 0x000A5468 File Offset: 0x000A3668
		[XmlIgnore]
		[Browsable(false)]
		public bool svrnameSpecified
		{
			get
			{
				return this._svrname != null;
			}
			set
			{
				bool flag = value == (this._svrname == null);
				if (flag)
				{
					this._svrname = (value ? this.svrname : null);
				}
			}
		}

		// Token: 0x060056CA RID: 22218 RVA: 0x000A5498 File Offset: 0x000A3698
		private bool ShouldSerializesvrname()
		{
			return this.svrnameSpecified;
		}

		// Token: 0x060056CB RID: 22219 RVA: 0x000A54B0 File Offset: 0x000A36B0
		private void Resetsvrname()
		{
			this.svrnameSpecified = false;
		}

		// Token: 0x17001AF4 RID: 6900
		// (get) Token: 0x060056CC RID: 22220 RVA: 0x000A54BC File Offset: 0x000A36BC
		[ProtoMember(7, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x17001AF5 RID: 6901
		// (get) Token: 0x060056CD RID: 22221 RVA: 0x000A54D4 File Offset: 0x000A36D4
		// (set) Token: 0x060056CE RID: 22222 RVA: 0x000A5500 File Offset: 0x000A3700
		[ProtoMember(8, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x17001AF6 RID: 6902
		// (get) Token: 0x060056CF RID: 22223 RVA: 0x000A5510 File Offset: 0x000A3710
		// (set) Token: 0x060056D0 RID: 22224 RVA: 0x000A5530 File Offset: 0x000A3730
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x060056D1 RID: 22225 RVA: 0x000A5574 File Offset: 0x000A3774
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x060056D2 RID: 22226 RVA: 0x000A558C File Offset: 0x000A378C
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x17001AF7 RID: 6903
		// (get) Token: 0x060056D3 RID: 22227 RVA: 0x000A5598 File Offset: 0x000A3798
		// (set) Token: 0x060056D4 RID: 22228 RVA: 0x000A55CC File Offset: 0x000A37CC
		[ProtoMember(9, IsRequired = false, Name = "hurt", DataFormat = DataFormat.TwosComplement)]
		public double hurt
		{
			get
			{
				return this._hurt ?? 0.0;
			}
			set
			{
				this._hurt = new double?(value);
			}
		}

		// Token: 0x17001AF8 RID: 6904
		// (get) Token: 0x060056D5 RID: 22229 RVA: 0x000A55DC File Offset: 0x000A37DC
		// (set) Token: 0x060056D6 RID: 22230 RVA: 0x000A55FC File Offset: 0x000A37FC
		[XmlIgnore]
		[Browsable(false)]
		public bool hurtSpecified
		{
			get
			{
				return this._hurt != null;
			}
			set
			{
				bool flag = value == (this._hurt == null);
				if (flag)
				{
					this._hurt = (value ? new double?(this.hurt) : null);
				}
			}
		}

		// Token: 0x060056D7 RID: 22231 RVA: 0x000A5640 File Offset: 0x000A3840
		private bool ShouldSerializehurt()
		{
			return this.hurtSpecified;
		}

		// Token: 0x060056D8 RID: 22232 RVA: 0x000A5658 File Offset: 0x000A3858
		private void Resethurt()
		{
			this.hurtSpecified = false;
		}

		// Token: 0x17001AF9 RID: 6905
		// (get) Token: 0x060056D9 RID: 22233 RVA: 0x000A5664 File Offset: 0x000A3864
		// (set) Token: 0x060056DA RID: 22234 RVA: 0x000A5685 File Offset: 0x000A3885
		[ProtoMember(10, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001AFA RID: 6906
		// (get) Token: 0x060056DB RID: 22235 RVA: 0x000A5690 File Offset: 0x000A3890
		// (set) Token: 0x060056DC RID: 22236 RVA: 0x000A56AC File Offset: 0x000A38AC
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

		// Token: 0x060056DD RID: 22237 RVA: 0x000A56DC File Offset: 0x000A38DC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060056DE RID: 22238 RVA: 0x000A56F4 File Offset: 0x000A38F4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001AFB RID: 6907
		// (get) Token: 0x060056DF RID: 22239 RVA: 0x000A5700 File Offset: 0x000A3900
		// (set) Token: 0x060056E0 RID: 22240 RVA: 0x000A572C File Offset: 0x000A392C
		[ProtoMember(11, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001AFC RID: 6908
		// (get) Token: 0x060056E1 RID: 22241 RVA: 0x000A573C File Offset: 0x000A393C
		// (set) Token: 0x060056E2 RID: 22242 RVA: 0x000A575C File Offset: 0x000A395C
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

		// Token: 0x060056E3 RID: 22243 RVA: 0x000A57A0 File Offset: 0x000A39A0
		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		// Token: 0x060056E4 RID: 22244 RVA: 0x000A57B8 File Offset: 0x000A39B8
		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		// Token: 0x17001AFD RID: 6909
		// (get) Token: 0x060056E5 RID: 22245 RVA: 0x000A57C4 File Offset: 0x000A39C4
		// (set) Token: 0x060056E6 RID: 22246 RVA: 0x000A57F0 File Offset: 0x000A39F0
		[ProtoMember(12, IsRequired = false, Name = "killstreak", DataFormat = DataFormat.TwosComplement)]
		public uint killstreak
		{
			get
			{
				return this._killstreak ?? 0U;
			}
			set
			{
				this._killstreak = new uint?(value);
			}
		}

		// Token: 0x17001AFE RID: 6910
		// (get) Token: 0x060056E7 RID: 22247 RVA: 0x000A5800 File Offset: 0x000A3A00
		// (set) Token: 0x060056E8 RID: 22248 RVA: 0x000A5820 File Offset: 0x000A3A20
		[XmlIgnore]
		[Browsable(false)]
		public bool killstreakSpecified
		{
			get
			{
				return this._killstreak != null;
			}
			set
			{
				bool flag = value == (this._killstreak == null);
				if (flag)
				{
					this._killstreak = (value ? new uint?(this.killstreak) : null);
				}
			}
		}

		// Token: 0x060056E9 RID: 22249 RVA: 0x000A5864 File Offset: 0x000A3A64
		private bool ShouldSerializekillstreak()
		{
			return this.killstreakSpecified;
		}

		// Token: 0x060056EA RID: 22250 RVA: 0x000A587C File Offset: 0x000A3A7C
		private void Resetkillstreak()
		{
			this.killstreakSpecified = false;
		}

		// Token: 0x060056EB RID: 22251 RVA: 0x000A5888 File Offset: 0x000A3A88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001512 RID: 5394
		private ulong? _roleid;

		// Token: 0x04001513 RID: 5395
		private uint? _rank;

		// Token: 0x04001514 RID: 5396
		private uint? _point;

		// Token: 0x04001515 RID: 5397
		private uint? _killer;

		// Token: 0x04001516 RID: 5398
		private uint? _death;

		// Token: 0x04001517 RID: 5399
		private string _svrname;

		// Token: 0x04001518 RID: 5400
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04001519 RID: 5401
		private bool? _ismvp;

		// Token: 0x0400151A RID: 5402
		private double? _hurt;

		// Token: 0x0400151B RID: 5403
		private string _name;

		// Token: 0x0400151C RID: 5404
		private uint? _job;

		// Token: 0x0400151D RID: 5405
		private uint? _killstreak;

		// Token: 0x0400151E RID: 5406
		private IExtension extensionObject;
	}
}
