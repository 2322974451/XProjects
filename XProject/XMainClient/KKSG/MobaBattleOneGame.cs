using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071C RID: 1820
	[ProtoContract(Name = "MobaBattleOneGame")]
	[Serializable]
	public class MobaBattleOneGame : IExtensible
	{
		// Token: 0x17002758 RID: 10072
		// (get) Token: 0x06007C23 RID: 31779 RVA: 0x000ED530 File Offset: 0x000EB730
		[ProtoMember(1, Name = "team1", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameRole> team1
		{
			get
			{
				return this._team1;
			}
		}

		// Token: 0x17002759 RID: 10073
		// (get) Token: 0x06007C24 RID: 31780 RVA: 0x000ED548 File Offset: 0x000EB748
		[ProtoMember(2, Name = "team2", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameRole> team2
		{
			get
			{
				return this._team2;
			}
		}

		// Token: 0x1700275A RID: 10074
		// (get) Token: 0x06007C25 RID: 31781 RVA: 0x000ED560 File Offset: 0x000EB760
		// (set) Token: 0x06007C26 RID: 31782 RVA: 0x000ED58C File Offset: 0x000EB78C
		[ProtoMember(3, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		// Token: 0x1700275B RID: 10075
		// (get) Token: 0x06007C27 RID: 31783 RVA: 0x000ED59C File Offset: 0x000EB79C
		// (set) Token: 0x06007C28 RID: 31784 RVA: 0x000ED5BC File Offset: 0x000EB7BC
		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		// Token: 0x06007C29 RID: 31785 RVA: 0x000ED600 File Offset: 0x000EB800
		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		// Token: 0x06007C2A RID: 31786 RVA: 0x000ED618 File Offset: 0x000EB818
		private void Resettag()
		{
			this.tagSpecified = false;
		}

		// Token: 0x1700275C RID: 10076
		// (get) Token: 0x06007C2B RID: 31787 RVA: 0x000ED624 File Offset: 0x000EB824
		// (set) Token: 0x06007C2C RID: 31788 RVA: 0x000ED650 File Offset: 0x000EB850
		[ProtoMember(4, IsRequired = false, Name = "date", DataFormat = DataFormat.TwosComplement)]
		public uint date
		{
			get
			{
				return this._date ?? 0U;
			}
			set
			{
				this._date = new uint?(value);
			}
		}

		// Token: 0x1700275D RID: 10077
		// (get) Token: 0x06007C2D RID: 31789 RVA: 0x000ED660 File Offset: 0x000EB860
		// (set) Token: 0x06007C2E RID: 31790 RVA: 0x000ED680 File Offset: 0x000EB880
		[XmlIgnore]
		[Browsable(false)]
		public bool dateSpecified
		{
			get
			{
				return this._date != null;
			}
			set
			{
				bool flag = value == (this._date == null);
				if (flag)
				{
					this._date = (value ? new uint?(this.date) : null);
				}
			}
		}

		// Token: 0x06007C2F RID: 31791 RVA: 0x000ED6C4 File Offset: 0x000EB8C4
		private bool ShouldSerializedate()
		{
			return this.dateSpecified;
		}

		// Token: 0x06007C30 RID: 31792 RVA: 0x000ED6DC File Offset: 0x000EB8DC
		private void Resetdate()
		{
			this.dateSpecified = false;
		}

		// Token: 0x1700275E RID: 10078
		// (get) Token: 0x06007C31 RID: 31793 RVA: 0x000ED6E8 File Offset: 0x000EB8E8
		// (set) Token: 0x06007C32 RID: 31794 RVA: 0x000ED714 File Offset: 0x000EB914
		[ProtoMember(5, IsRequired = false, Name = "timeSpan", DataFormat = DataFormat.TwosComplement)]
		public uint timeSpan
		{
			get
			{
				return this._timeSpan ?? 0U;
			}
			set
			{
				this._timeSpan = new uint?(value);
			}
		}

		// Token: 0x1700275F RID: 10079
		// (get) Token: 0x06007C33 RID: 31795 RVA: 0x000ED724 File Offset: 0x000EB924
		// (set) Token: 0x06007C34 RID: 31796 RVA: 0x000ED744 File Offset: 0x000EB944
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpanSpecified
		{
			get
			{
				return this._timeSpan != null;
			}
			set
			{
				bool flag = value == (this._timeSpan == null);
				if (flag)
				{
					this._timeSpan = (value ? new uint?(this.timeSpan) : null);
				}
			}
		}

		// Token: 0x06007C35 RID: 31797 RVA: 0x000ED788 File Offset: 0x000EB988
		private bool ShouldSerializetimeSpan()
		{
			return this.timeSpanSpecified;
		}

		// Token: 0x06007C36 RID: 31798 RVA: 0x000ED7A0 File Offset: 0x000EB9A0
		private void ResettimeSpan()
		{
			this.timeSpanSpecified = false;
		}

		// Token: 0x17002760 RID: 10080
		// (get) Token: 0x06007C37 RID: 31799 RVA: 0x000ED7AC File Offset: 0x000EB9AC
		// (set) Token: 0x06007C38 RID: 31800 RVA: 0x000ED7D8 File Offset: 0x000EB9D8
		[ProtoMember(6, IsRequired = false, Name = "winteamid", DataFormat = DataFormat.TwosComplement)]
		public uint winteamid
		{
			get
			{
				return this._winteamid ?? 0U;
			}
			set
			{
				this._winteamid = new uint?(value);
			}
		}

		// Token: 0x17002761 RID: 10081
		// (get) Token: 0x06007C39 RID: 31801 RVA: 0x000ED7E8 File Offset: 0x000EB9E8
		// (set) Token: 0x06007C3A RID: 31802 RVA: 0x000ED808 File Offset: 0x000EBA08
		[XmlIgnore]
		[Browsable(false)]
		public bool winteamidSpecified
		{
			get
			{
				return this._winteamid != null;
			}
			set
			{
				bool flag = value == (this._winteamid == null);
				if (flag)
				{
					this._winteamid = (value ? new uint?(this.winteamid) : null);
				}
			}
		}

		// Token: 0x06007C3B RID: 31803 RVA: 0x000ED84C File Offset: 0x000EBA4C
		private bool ShouldSerializewinteamid()
		{
			return this.winteamidSpecified;
		}

		// Token: 0x06007C3C RID: 31804 RVA: 0x000ED864 File Offset: 0x000EBA64
		private void Resetwinteamid()
		{
			this.winteamidSpecified = false;
		}

		// Token: 0x17002762 RID: 10082
		// (get) Token: 0x06007C3D RID: 31805 RVA: 0x000ED870 File Offset: 0x000EBA70
		// (set) Token: 0x06007C3E RID: 31806 RVA: 0x000ED89D File Offset: 0x000EBA9D
		[ProtoMember(7, IsRequired = false, Name = "mvpid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002763 RID: 10083
		// (get) Token: 0x06007C3F RID: 31807 RVA: 0x000ED8AC File Offset: 0x000EBAAC
		// (set) Token: 0x06007C40 RID: 31808 RVA: 0x000ED8CC File Offset: 0x000EBACC
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

		// Token: 0x06007C41 RID: 31809 RVA: 0x000ED910 File Offset: 0x000EBB10
		private bool ShouldSerializemvpid()
		{
			return this.mvpidSpecified;
		}

		// Token: 0x06007C42 RID: 31810 RVA: 0x000ED928 File Offset: 0x000EBB28
		private void Resetmvpid()
		{
			this.mvpidSpecified = false;
		}

		// Token: 0x17002764 RID: 10084
		// (get) Token: 0x06007C43 RID: 31811 RVA: 0x000ED934 File Offset: 0x000EBB34
		// (set) Token: 0x06007C44 RID: 31812 RVA: 0x000ED961 File Offset: 0x000EBB61
		[ProtoMember(8, IsRequired = false, Name = "losemvpid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002765 RID: 10085
		// (get) Token: 0x06007C45 RID: 31813 RVA: 0x000ED970 File Offset: 0x000EBB70
		// (set) Token: 0x06007C46 RID: 31814 RVA: 0x000ED990 File Offset: 0x000EBB90
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

		// Token: 0x06007C47 RID: 31815 RVA: 0x000ED9D4 File Offset: 0x000EBBD4
		private bool ShouldSerializelosemvpid()
		{
			return this.losemvpidSpecified;
		}

		// Token: 0x06007C48 RID: 31816 RVA: 0x000ED9EC File Offset: 0x000EBBEC
		private void Resetlosemvpid()
		{
			this.losemvpidSpecified = false;
		}

		// Token: 0x17002766 RID: 10086
		// (get) Token: 0x06007C49 RID: 31817 RVA: 0x000ED9F8 File Offset: 0x000EBBF8
		// (set) Token: 0x06007C4A RID: 31818 RVA: 0x000EDA25 File Offset: 0x000EBC25
		[ProtoMember(9, IsRequired = false, Name = "damagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong damagemaxid
		{
			get
			{
				return this._damagemaxid ?? 0UL;
			}
			set
			{
				this._damagemaxid = new ulong?(value);
			}
		}

		// Token: 0x17002767 RID: 10087
		// (get) Token: 0x06007C4B RID: 31819 RVA: 0x000EDA34 File Offset: 0x000EBC34
		// (set) Token: 0x06007C4C RID: 31820 RVA: 0x000EDA54 File Offset: 0x000EBC54
		[XmlIgnore]
		[Browsable(false)]
		public bool damagemaxidSpecified
		{
			get
			{
				return this._damagemaxid != null;
			}
			set
			{
				bool flag = value == (this._damagemaxid == null);
				if (flag)
				{
					this._damagemaxid = (value ? new ulong?(this.damagemaxid) : null);
				}
			}
		}

		// Token: 0x06007C4D RID: 31821 RVA: 0x000EDA98 File Offset: 0x000EBC98
		private bool ShouldSerializedamagemaxid()
		{
			return this.damagemaxidSpecified;
		}

		// Token: 0x06007C4E RID: 31822 RVA: 0x000EDAB0 File Offset: 0x000EBCB0
		private void Resetdamagemaxid()
		{
			this.damagemaxidSpecified = false;
		}

		// Token: 0x17002768 RID: 10088
		// (get) Token: 0x06007C4F RID: 31823 RVA: 0x000EDABC File Offset: 0x000EBCBC
		// (set) Token: 0x06007C50 RID: 31824 RVA: 0x000EDAE9 File Offset: 0x000EBCE9
		[ProtoMember(10, IsRequired = false, Name = "behitdamagemaxid", DataFormat = DataFormat.TwosComplement)]
		public ulong behitdamagemaxid
		{
			get
			{
				return this._behitdamagemaxid ?? 0UL;
			}
			set
			{
				this._behitdamagemaxid = new ulong?(value);
			}
		}

		// Token: 0x17002769 RID: 10089
		// (get) Token: 0x06007C51 RID: 31825 RVA: 0x000EDAF8 File Offset: 0x000EBCF8
		// (set) Token: 0x06007C52 RID: 31826 RVA: 0x000EDB18 File Offset: 0x000EBD18
		[XmlIgnore]
		[Browsable(false)]
		public bool behitdamagemaxidSpecified
		{
			get
			{
				return this._behitdamagemaxid != null;
			}
			set
			{
				bool flag = value == (this._behitdamagemaxid == null);
				if (flag)
				{
					this._behitdamagemaxid = (value ? new ulong?(this.behitdamagemaxid) : null);
				}
			}
		}

		// Token: 0x06007C53 RID: 31827 RVA: 0x000EDB5C File Offset: 0x000EBD5C
		private bool ShouldSerializebehitdamagemaxid()
		{
			return this.behitdamagemaxidSpecified;
		}

		// Token: 0x06007C54 RID: 31828 RVA: 0x000EDB74 File Offset: 0x000EBD74
		private void Resetbehitdamagemaxid()
		{
			this.behitdamagemaxidSpecified = false;
		}

		// Token: 0x06007C55 RID: 31829 RVA: 0x000EDB80 File Offset: 0x000EBD80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D43 RID: 7491
		private readonly List<MobaBattleOneGameRole> _team1 = new List<MobaBattleOneGameRole>();

		// Token: 0x04001D44 RID: 7492
		private readonly List<MobaBattleOneGameRole> _team2 = new List<MobaBattleOneGameRole>();

		// Token: 0x04001D45 RID: 7493
		private uint? _tag;

		// Token: 0x04001D46 RID: 7494
		private uint? _date;

		// Token: 0x04001D47 RID: 7495
		private uint? _timeSpan;

		// Token: 0x04001D48 RID: 7496
		private uint? _winteamid;

		// Token: 0x04001D49 RID: 7497
		private ulong? _mvpid;

		// Token: 0x04001D4A RID: 7498
		private ulong? _losemvpid;

		// Token: 0x04001D4B RID: 7499
		private ulong? _damagemaxid;

		// Token: 0x04001D4C RID: 7500
		private ulong? _behitdamagemaxid;

		// Token: 0x04001D4D RID: 7501
		private IExtension extensionObject;
	}
}
