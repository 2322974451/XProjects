using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005D9 RID: 1497
	[ProtoContract(Name = "HeroBattleResult")]
	[Serializable]
	public class HeroBattleResult : IExtensible
	{
		// Token: 0x17001AA4 RID: 6820
		// (get) Token: 0x060055DA RID: 21978 RVA: 0x000A36B0 File Offset: 0x000A18B0
		// (set) Token: 0x060055DB RID: 21979 RVA: 0x000A36DC File Offset: 0x000A18DC
		[ProtoMember(1, IsRequired = false, Name = "over", DataFormat = DataFormat.TwosComplement)]
		public HeroBattleOver over
		{
			get
			{
				return this._over ?? HeroBattleOver.HeroBattleOver_Win;
			}
			set
			{
				this._over = new HeroBattleOver?(value);
			}
		}

		// Token: 0x17001AA5 RID: 6821
		// (get) Token: 0x060055DC RID: 21980 RVA: 0x000A36EC File Offset: 0x000A18EC
		// (set) Token: 0x060055DD RID: 21981 RVA: 0x000A370C File Offset: 0x000A190C
		[XmlIgnore]
		[Browsable(false)]
		public bool overSpecified
		{
			get
			{
				return this._over != null;
			}
			set
			{
				bool flag = value == (this._over == null);
				if (flag)
				{
					this._over = (value ? new HeroBattleOver?(this.over) : null);
				}
			}
		}

		// Token: 0x060055DE RID: 21982 RVA: 0x000A3750 File Offset: 0x000A1950
		private bool ShouldSerializeover()
		{
			return this.overSpecified;
		}

		// Token: 0x060055DF RID: 21983 RVA: 0x000A3768 File Offset: 0x000A1968
		private void Resetover()
		{
			this.overSpecified = false;
		}

		// Token: 0x17001AA6 RID: 6822
		// (get) Token: 0x060055E0 RID: 21984 RVA: 0x000A3774 File Offset: 0x000A1974
		// (set) Token: 0x060055E1 RID: 21985 RVA: 0x000A37A1 File Offset: 0x000A19A1
		[ProtoMember(2, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong mvpid
		{
			get
			{
				return this._mvpid ?? 0UL;
			}
			set
			{
				this._mvpid = new ulong?(value);
			}
		}

		// Token: 0x17001AA7 RID: 6823
		// (get) Token: 0x060055E2 RID: 21986 RVA: 0x000A37B0 File Offset: 0x000A19B0
		// (set) Token: 0x060055E3 RID: 21987 RVA: 0x000A37D0 File Offset: 0x000A19D0
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpidSpecified
		{
			get
			{
				return this._mvpid != null;
			}
			set
			{
				bool flag = value == (this._mvpid == null);
				if (flag)
				{
					this._mvpid = (value ? new ulong?(this.mvpid) : null);
				}
			}
		}

		// Token: 0x060055E4 RID: 21988 RVA: 0x000A3814 File Offset: 0x000A1A14
		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		// Token: 0x060055E5 RID: 21989 RVA: 0x000A382C File Offset: 0x000A1A2C
		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		// Token: 0x17001AA8 RID: 6824
		// (get) Token: 0x060055E6 RID: 21990 RVA: 0x000A3838 File Offset: 0x000A1A38
		// (set) Token: 0x060055E7 RID: 21991 RVA: 0x000A3864 File Offset: 0x000A1A64
		[ProtoMember(3, IsRequired = false, Name = "mvpheroid", DataFormat = DataFormat.TwosComplement)]
		public uint mvpheroid
		{
			get
			{
				return this._mvpheroid ?? 0U;
			}
			set
			{
				this._mvpheroid = new uint?(value);
			}
		}

		// Token: 0x17001AA9 RID: 6825
		// (get) Token: 0x060055E8 RID: 21992 RVA: 0x000A3874 File Offset: 0x000A1A74
		// (set) Token: 0x060055E9 RID: 21993 RVA: 0x000A3894 File Offset: 0x000A1A94
		[XmlIgnore]
		[Browsable(false)]
		public bool mvpheroidSpecified
		{
			get
			{
				return this._mvpheroid != null;
			}
			set
			{
				bool flag = value == (this._mvpheroid == null);
				if (flag)
				{
					this._mvpheroid = (value ? new uint?(this.mvpheroid) : null);
				}
			}
		}

		// Token: 0x060055EA RID: 21994 RVA: 0x000A38D8 File Offset: 0x000A1AD8
		private bool ShouldSerializemvpheroid()
		{
			return this.mvpheroidSpecified;
		}

		// Token: 0x060055EB RID: 21995 RVA: 0x000A38F0 File Offset: 0x000A1AF0
		private void Resetmvpheroid()
		{
			this.mvpheroidSpecified = false;
		}

		// Token: 0x17001AAA RID: 6826
		// (get) Token: 0x060055EC RID: 21996 RVA: 0x000A38FC File Offset: 0x000A1AFC
		// (set) Token: 0x060055ED RID: 21997 RVA: 0x000A3928 File Offset: 0x000A1B28
		[ProtoMember(4, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001AAB RID: 6827
		// (get) Token: 0x060055EE RID: 21998 RVA: 0x000A3938 File Offset: 0x000A1B38
		// (set) Token: 0x060055EF RID: 21999 RVA: 0x000A3958 File Offset: 0x000A1B58
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

		// Token: 0x060055F0 RID: 22000 RVA: 0x000A399C File Offset: 0x000A1B9C
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x060055F1 RID: 22001 RVA: 0x000A39B4 File Offset: 0x000A1BB4
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17001AAC RID: 6828
		// (get) Token: 0x060055F2 RID: 22002 RVA: 0x000A39C0 File Offset: 0x000A1BC0
		[ProtoMember(5, Name = "dayjoinreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> dayjoinreward
		{
			get
			{
				return this._dayjoinreward;
			}
		}

		// Token: 0x17001AAD RID: 6829
		// (get) Token: 0x060055F3 RID: 22003 RVA: 0x000A39D8 File Offset: 0x000A1BD8
		[ProtoMember(6, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		// Token: 0x17001AAE RID: 6830
		// (get) Token: 0x060055F4 RID: 22004 RVA: 0x000A39F0 File Offset: 0x000A1BF0
		// (set) Token: 0x060055F5 RID: 22005 RVA: 0x000A3A1D File Offset: 0x000A1C1D
		[ProtoMember(7, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
		public ulong losemvpid
		{
			get
			{
				return this._losemvpid ?? 0UL;
			}
			set
			{
				this._losemvpid = new ulong?(value);
			}
		}

		// Token: 0x17001AAF RID: 6831
		// (get) Token: 0x060055F6 RID: 22006 RVA: 0x000A3A2C File Offset: 0x000A1C2C
		// (set) Token: 0x060055F7 RID: 22007 RVA: 0x000A3A4C File Offset: 0x000A1C4C
		[XmlIgnore]
		[Browsable(false)]
		public bool losemvpidSpecified
		{
			get
			{
				return this._losemvpid != null;
			}
			set
			{
				bool flag = value == (this._losemvpid == null);
				if (flag)
				{
					this._losemvpid = (value ? new ulong?(this.losemvpid) : null);
				}
			}
		}

		// Token: 0x060055F8 RID: 22008 RVA: 0x000A3A90 File Offset: 0x000A1C90
		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		// Token: 0x060055F9 RID: 22009 RVA: 0x000A3AA8 File Offset: 0x000A1CA8
		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		// Token: 0x17001AB0 RID: 6832
		// (get) Token: 0x060055FA RID: 22010 RVA: 0x000A3AB4 File Offset: 0x000A1CB4
		// (set) Token: 0x060055FB RID: 22011 RVA: 0x000A3AE4 File Offset: 0x000A1CE4
		[ProtoMember(8, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		// Token: 0x17001AB1 RID: 6833
		// (get) Token: 0x060055FC RID: 22012 RVA: 0x000A3AF4 File Offset: 0x000A1CF4
		// (set) Token: 0x060055FD RID: 22013 RVA: 0x000A3B14 File Offset: 0x000A1D14
		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		// Token: 0x060055FE RID: 22014 RVA: 0x000A3B58 File Offset: 0x000A1D58
		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		// Token: 0x060055FF RID: 22015 RVA: 0x000A3B70 File Offset: 0x000A1D70
		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		// Token: 0x06005600 RID: 22016 RVA: 0x000A3B7C File Offset: 0x000A1D7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014E9 RID: 5353
		private HeroBattleOver? _over;

		// Token: 0x040014EA RID: 5354
		private ulong? _mvpid;

		// Token: 0x040014EB RID: 5355
		private uint? _mvpheroid;

		// Token: 0x040014EC RID: 5356
		private uint? _teamid;

		// Token: 0x040014ED RID: 5357
		private readonly List<ItemBrief> _dayjoinreward = new List<ItemBrief>();

		// Token: 0x040014EE RID: 5358
		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		// Token: 0x040014EF RID: 5359
		private ulong? _losemvpid;

		// Token: 0x040014F0 RID: 5360
		private float? _kda;

		// Token: 0x040014F1 RID: 5361
		private IExtension extensionObject;
	}
}
