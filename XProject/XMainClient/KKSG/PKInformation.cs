using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FE RID: 1790
	[ProtoContract(Name = "PKInformation")]
	[Serializable]
	public class PKInformation : IExtensible
	{
		// Token: 0x1700264A RID: 9802
		// (get) Token: 0x060078E2 RID: 30946 RVA: 0x000E733C File Offset: 0x000E553C
		// (set) Token: 0x060078E3 RID: 30947 RVA: 0x000E7354 File Offset: 0x000E5554
		[ProtoMember(1, IsRequired = false, Name = "pk_record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PkRecord pk_record
		{
			get
			{
				return this._pk_record;
			}
			set
			{
				this._pk_record = value;
			}
		}

		// Token: 0x1700264B RID: 9803
		// (get) Token: 0x060078E4 RID: 30948 RVA: 0x000E7360 File Offset: 0x000E5560
		// (set) Token: 0x060078E5 RID: 30949 RVA: 0x000E738C File Offset: 0x000E558C
		[ProtoMember(2, IsRequired = false, Name = "pk_rank", DataFormat = DataFormat.TwosComplement)]
		public uint pk_rank
		{
			get
			{
				return this._pk_rank ?? 0U;
			}
			set
			{
				this._pk_rank = new uint?(value);
			}
		}

		// Token: 0x1700264C RID: 9804
		// (get) Token: 0x060078E6 RID: 30950 RVA: 0x000E739C File Offset: 0x000E559C
		// (set) Token: 0x060078E7 RID: 30951 RVA: 0x000E73BC File Offset: 0x000E55BC
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_rankSpecified
		{
			get
			{
				return this._pk_rank != null;
			}
			set
			{
				bool flag = value == (this._pk_rank == null);
				if (flag)
				{
					this._pk_rank = (value ? new uint?(this.pk_rank) : null);
				}
			}
		}

		// Token: 0x060078E8 RID: 30952 RVA: 0x000E7400 File Offset: 0x000E5600
		private bool ShouldSerializepk_rank()
		{
			return this.pk_rankSpecified;
		}

		// Token: 0x060078E9 RID: 30953 RVA: 0x000E7418 File Offset: 0x000E5618
		private void Resetpk_rank()
		{
			this.pk_rankSpecified = false;
		}

		// Token: 0x1700264D RID: 9805
		// (get) Token: 0x060078EA RID: 30954 RVA: 0x000E7424 File Offset: 0x000E5624
		// (set) Token: 0x060078EB RID: 30955 RVA: 0x000E7450 File Offset: 0x000E5650
		[ProtoMember(3, IsRequired = false, Name = "pk_profession_rank", DataFormat = DataFormat.TwosComplement)]
		public uint pk_profession_rank
		{
			get
			{
				return this._pk_profession_rank ?? 0U;
			}
			set
			{
				this._pk_profession_rank = new uint?(value);
			}
		}

		// Token: 0x1700264E RID: 9806
		// (get) Token: 0x060078EC RID: 30956 RVA: 0x000E7460 File Offset: 0x000E5660
		// (set) Token: 0x060078ED RID: 30957 RVA: 0x000E7480 File Offset: 0x000E5680
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_profession_rankSpecified
		{
			get
			{
				return this._pk_profession_rank != null;
			}
			set
			{
				bool flag = value == (this._pk_profession_rank == null);
				if (flag)
				{
					this._pk_profession_rank = (value ? new uint?(this.pk_profession_rank) : null);
				}
			}
		}

		// Token: 0x060078EE RID: 30958 RVA: 0x000E74C4 File Offset: 0x000E56C4
		private bool ShouldSerializepk_profession_rank()
		{
			return this.pk_profession_rankSpecified;
		}

		// Token: 0x060078EF RID: 30959 RVA: 0x000E74DC File Offset: 0x000E56DC
		private void Resetpk_profession_rank()
		{
			this.pk_profession_rankSpecified = false;
		}

		// Token: 0x1700264F RID: 9807
		// (get) Token: 0x060078F0 RID: 30960 RVA: 0x000E74E8 File Offset: 0x000E56E8
		// (set) Token: 0x060078F1 RID: 30961 RVA: 0x000E7514 File Offset: 0x000E5714
		[ProtoMember(4, IsRequired = false, Name = "pk_max_score", DataFormat = DataFormat.TwosComplement)]
		public uint pk_max_score
		{
			get
			{
				return this._pk_max_score ?? 0U;
			}
			set
			{
				this._pk_max_score = new uint?(value);
			}
		}

		// Token: 0x17002650 RID: 9808
		// (get) Token: 0x060078F2 RID: 30962 RVA: 0x000E7524 File Offset: 0x000E5724
		// (set) Token: 0x060078F3 RID: 30963 RVA: 0x000E7544 File Offset: 0x000E5744
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_max_scoreSpecified
		{
			get
			{
				return this._pk_max_score != null;
			}
			set
			{
				bool flag = value == (this._pk_max_score == null);
				if (flag)
				{
					this._pk_max_score = (value ? new uint?(this.pk_max_score) : null);
				}
			}
		}

		// Token: 0x060078F4 RID: 30964 RVA: 0x000E7588 File Offset: 0x000E5788
		private bool ShouldSerializepk_max_score()
		{
			return this.pk_max_scoreSpecified;
		}

		// Token: 0x060078F5 RID: 30965 RVA: 0x000E75A0 File Offset: 0x000E57A0
		private void Resetpk_max_score()
		{
			this.pk_max_scoreSpecified = false;
		}

		// Token: 0x17002651 RID: 9809
		// (get) Token: 0x060078F6 RID: 30966 RVA: 0x000E75AC File Offset: 0x000E57AC
		// (set) Token: 0x060078F7 RID: 30967 RVA: 0x000E75CD File Offset: 0x000E57CD
		[ProtoMember(5, IsRequired = false, Name = "pk_all_roles_rate", DataFormat = DataFormat.Default)]
		public string pk_all_roles_rate
		{
			get
			{
				return this._pk_all_roles_rate ?? "";
			}
			set
			{
				this._pk_all_roles_rate = value;
			}
		}

		// Token: 0x17002652 RID: 9810
		// (get) Token: 0x060078F8 RID: 30968 RVA: 0x000E75D8 File Offset: 0x000E57D8
		// (set) Token: 0x060078F9 RID: 30969 RVA: 0x000E75F4 File Offset: 0x000E57F4
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_all_roles_rateSpecified
		{
			get
			{
				return this._pk_all_roles_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_all_roles_rate == null);
				if (flag)
				{
					this._pk_all_roles_rate = (value ? this.pk_all_roles_rate : null);
				}
			}
		}

		// Token: 0x060078FA RID: 30970 RVA: 0x000E7624 File Offset: 0x000E5824
		private bool ShouldSerializepk_all_roles_rate()
		{
			return this.pk_all_roles_rateSpecified;
		}

		// Token: 0x060078FB RID: 30971 RVA: 0x000E763C File Offset: 0x000E583C
		private void Resetpk_all_roles_rate()
		{
			this.pk_all_roles_rateSpecified = false;
		}

		// Token: 0x17002653 RID: 9811
		// (get) Token: 0x060078FC RID: 30972 RVA: 0x000E7648 File Offset: 0x000E5848
		// (set) Token: 0x060078FD RID: 30973 RVA: 0x000E7669 File Offset: 0x000E5869
		[ProtoMember(6, IsRequired = false, Name = "pk_warrior_rate", DataFormat = DataFormat.Default)]
		public string pk_warrior_rate
		{
			get
			{
				return this._pk_warrior_rate ?? "";
			}
			set
			{
				this._pk_warrior_rate = value;
			}
		}

		// Token: 0x17002654 RID: 9812
		// (get) Token: 0x060078FE RID: 30974 RVA: 0x000E7674 File Offset: 0x000E5874
		// (set) Token: 0x060078FF RID: 30975 RVA: 0x000E7690 File Offset: 0x000E5890
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_warrior_rateSpecified
		{
			get
			{
				return this._pk_warrior_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_warrior_rate == null);
				if (flag)
				{
					this._pk_warrior_rate = (value ? this.pk_warrior_rate : null);
				}
			}
		}

		// Token: 0x06007900 RID: 30976 RVA: 0x000E76C0 File Offset: 0x000E58C0
		private bool ShouldSerializepk_warrior_rate()
		{
			return this.pk_warrior_rateSpecified;
		}

		// Token: 0x06007901 RID: 30977 RVA: 0x000E76D8 File Offset: 0x000E58D8
		private void Resetpk_warrior_rate()
		{
			this.pk_warrior_rateSpecified = false;
		}

		// Token: 0x17002655 RID: 9813
		// (get) Token: 0x06007902 RID: 30978 RVA: 0x000E76E4 File Offset: 0x000E58E4
		// (set) Token: 0x06007903 RID: 30979 RVA: 0x000E7705 File Offset: 0x000E5905
		[ProtoMember(7, IsRequired = false, Name = "pk_archer_rate", DataFormat = DataFormat.Default)]
		public string pk_archer_rate
		{
			get
			{
				return this._pk_archer_rate ?? "";
			}
			set
			{
				this._pk_archer_rate = value;
			}
		}

		// Token: 0x17002656 RID: 9814
		// (get) Token: 0x06007904 RID: 30980 RVA: 0x000E7710 File Offset: 0x000E5910
		// (set) Token: 0x06007905 RID: 30981 RVA: 0x000E772C File Offset: 0x000E592C
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_archer_rateSpecified
		{
			get
			{
				return this._pk_archer_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_archer_rate == null);
				if (flag)
				{
					this._pk_archer_rate = (value ? this.pk_archer_rate : null);
				}
			}
		}

		// Token: 0x06007906 RID: 30982 RVA: 0x000E775C File Offset: 0x000E595C
		private bool ShouldSerializepk_archer_rate()
		{
			return this.pk_archer_rateSpecified;
		}

		// Token: 0x06007907 RID: 30983 RVA: 0x000E7774 File Offset: 0x000E5974
		private void Resetpk_archer_rate()
		{
			this.pk_archer_rateSpecified = false;
		}

		// Token: 0x17002657 RID: 9815
		// (get) Token: 0x06007908 RID: 30984 RVA: 0x000E7780 File Offset: 0x000E5980
		// (set) Token: 0x06007909 RID: 30985 RVA: 0x000E77A1 File Offset: 0x000E59A1
		[ProtoMember(8, IsRequired = false, Name = "pk_minister_rate", DataFormat = DataFormat.Default)]
		public string pk_minister_rate
		{
			get
			{
				return this._pk_minister_rate ?? "";
			}
			set
			{
				this._pk_minister_rate = value;
			}
		}

		// Token: 0x17002658 RID: 9816
		// (get) Token: 0x0600790A RID: 30986 RVA: 0x000E77AC File Offset: 0x000E59AC
		// (set) Token: 0x0600790B RID: 30987 RVA: 0x000E77C8 File Offset: 0x000E59C8
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_minister_rateSpecified
		{
			get
			{
				return this._pk_minister_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_minister_rate == null);
				if (flag)
				{
					this._pk_minister_rate = (value ? this.pk_minister_rate : null);
				}
			}
		}

		// Token: 0x0600790C RID: 30988 RVA: 0x000E77F8 File Offset: 0x000E59F8
		private bool ShouldSerializepk_minister_rate()
		{
			return this.pk_minister_rateSpecified;
		}

		// Token: 0x0600790D RID: 30989 RVA: 0x000E7810 File Offset: 0x000E5A10
		private void Resetpk_minister_rate()
		{
			this.pk_minister_rateSpecified = false;
		}

		// Token: 0x17002659 RID: 9817
		// (get) Token: 0x0600790E RID: 30990 RVA: 0x000E781C File Offset: 0x000E5A1C
		// (set) Token: 0x0600790F RID: 30991 RVA: 0x000E783D File Offset: 0x000E5A3D
		[ProtoMember(9, IsRequired = false, Name = "pk_master_rate", DataFormat = DataFormat.Default)]
		public string pk_master_rate
		{
			get
			{
				return this._pk_master_rate ?? "";
			}
			set
			{
				this._pk_master_rate = value;
			}
		}

		// Token: 0x1700265A RID: 9818
		// (get) Token: 0x06007910 RID: 30992 RVA: 0x000E7848 File Offset: 0x000E5A48
		// (set) Token: 0x06007911 RID: 30993 RVA: 0x000E7864 File Offset: 0x000E5A64
		[XmlIgnore]
		[Browsable(false)]
		public bool pk_master_rateSpecified
		{
			get
			{
				return this._pk_master_rate != null;
			}
			set
			{
				bool flag = value == (this._pk_master_rate == null);
				if (flag)
				{
					this._pk_master_rate = (value ? this.pk_master_rate : null);
				}
			}
		}

		// Token: 0x06007912 RID: 30994 RVA: 0x000E7894 File Offset: 0x000E5A94
		private bool ShouldSerializepk_master_rate()
		{
			return this.pk_master_rateSpecified;
		}

		// Token: 0x06007913 RID: 30995 RVA: 0x000E78AC File Offset: 0x000E5AAC
		private void Resetpk_master_rate()
		{
			this.pk_master_rateSpecified = false;
		}

		// Token: 0x06007914 RID: 30996 RVA: 0x000E78B8 File Offset: 0x000E5AB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C91 RID: 7313
		private PkRecord _pk_record = null;

		// Token: 0x04001C92 RID: 7314
		private uint? _pk_rank;

		// Token: 0x04001C93 RID: 7315
		private uint? _pk_profession_rank;

		// Token: 0x04001C94 RID: 7316
		private uint? _pk_max_score;

		// Token: 0x04001C95 RID: 7317
		private string _pk_all_roles_rate;

		// Token: 0x04001C96 RID: 7318
		private string _pk_warrior_rate;

		// Token: 0x04001C97 RID: 7319
		private string _pk_archer_rate;

		// Token: 0x04001C98 RID: 7320
		private string _pk_minister_rate;

		// Token: 0x04001C99 RID: 7321
		private string _pk_master_rate;

		// Token: 0x04001C9A RID: 7322
		private IExtension extensionObject;
	}
}
