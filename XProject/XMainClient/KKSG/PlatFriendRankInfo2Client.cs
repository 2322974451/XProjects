using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006B8 RID: 1720
	[ProtoContract(Name = "PlatFriendRankInfo2Client")]
	[Serializable]
	public class PlatFriendRankInfo2Client : IExtensible
	{
		// Token: 0x170023C1 RID: 9153
		// (get) Token: 0x060070F5 RID: 28917 RVA: 0x000D820C File Offset: 0x000D640C
		// (set) Token: 0x060070F6 RID: 28918 RVA: 0x000D8224 File Offset: 0x000D6424
		[ProtoMember(1, IsRequired = false, Name = "platfriendBaseInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriend platfriendBaseInfo
		{
			get
			{
				return this._platfriendBaseInfo;
			}
			set
			{
				this._platfriendBaseInfo = value;
			}
		}

		// Token: 0x170023C2 RID: 9154
		// (get) Token: 0x060070F7 RID: 28919 RVA: 0x000D8230 File Offset: 0x000D6430
		// (set) Token: 0x060070F8 RID: 28920 RVA: 0x000D825C File Offset: 0x000D645C
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

		// Token: 0x170023C3 RID: 9155
		// (get) Token: 0x060070F9 RID: 28921 RVA: 0x000D826C File Offset: 0x000D646C
		// (set) Token: 0x060070FA RID: 28922 RVA: 0x000D828C File Offset: 0x000D648C
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

		// Token: 0x060070FB RID: 28923 RVA: 0x000D82D0 File Offset: 0x000D64D0
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060070FC RID: 28924 RVA: 0x000D82E8 File Offset: 0x000D64E8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x170023C4 RID: 9156
		// (get) Token: 0x060070FD RID: 28925 RVA: 0x000D82F4 File Offset: 0x000D64F4
		// (set) Token: 0x060070FE RID: 28926 RVA: 0x000D8320 File Offset: 0x000D6520
		[ProtoMember(3, IsRequired = false, Name = "hasGiveGift", DataFormat = DataFormat.Default)]
		public bool hasGiveGift
		{
			get
			{
				return this._hasGiveGift ?? false;
			}
			set
			{
				this._hasGiveGift = new bool?(value);
			}
		}

		// Token: 0x170023C5 RID: 9157
		// (get) Token: 0x060070FF RID: 28927 RVA: 0x000D8330 File Offset: 0x000D6530
		// (set) Token: 0x06007100 RID: 28928 RVA: 0x000D8350 File Offset: 0x000D6550
		[XmlIgnore]
		[Browsable(false)]
		public bool hasGiveGiftSpecified
		{
			get
			{
				return this._hasGiveGift != null;
			}
			set
			{
				bool flag = value == (this._hasGiveGift == null);
				if (flag)
				{
					this._hasGiveGift = (value ? new bool?(this.hasGiveGift) : null);
				}
			}
		}

		// Token: 0x06007101 RID: 28929 RVA: 0x000D8394 File Offset: 0x000D6594
		private bool ShouldSerializehasGiveGift()
		{
			return this.hasGiveGiftSpecified;
		}

		// Token: 0x06007102 RID: 28930 RVA: 0x000D83AC File Offset: 0x000D65AC
		private void ResethasGiveGift()
		{
			this.hasGiveGiftSpecified = false;
		}

		// Token: 0x170023C6 RID: 9158
		// (get) Token: 0x06007103 RID: 28931 RVA: 0x000D83B8 File Offset: 0x000D65B8
		// (set) Token: 0x06007104 RID: 28932 RVA: 0x000D83E4 File Offset: 0x000D65E4
		[ProtoMember(4, IsRequired = false, Name = "maxAbility", DataFormat = DataFormat.TwosComplement)]
		public uint maxAbility
		{
			get
			{
				return this._maxAbility ?? 0U;
			}
			set
			{
				this._maxAbility = new uint?(value);
			}
		}

		// Token: 0x170023C7 RID: 9159
		// (get) Token: 0x06007105 RID: 28933 RVA: 0x000D83F4 File Offset: 0x000D65F4
		// (set) Token: 0x06007106 RID: 28934 RVA: 0x000D8414 File Offset: 0x000D6614
		[XmlIgnore]
		[Browsable(false)]
		public bool maxAbilitySpecified
		{
			get
			{
				return this._maxAbility != null;
			}
			set
			{
				bool flag = value == (this._maxAbility == null);
				if (flag)
				{
					this._maxAbility = (value ? new uint?(this.maxAbility) : null);
				}
			}
		}

		// Token: 0x06007107 RID: 28935 RVA: 0x000D8458 File Offset: 0x000D6658
		private bool ShouldSerializemaxAbility()
		{
			return this.maxAbilitySpecified;
		}

		// Token: 0x06007108 RID: 28936 RVA: 0x000D8470 File Offset: 0x000D6670
		private void ResetmaxAbility()
		{
			this.maxAbilitySpecified = false;
		}

		// Token: 0x170023C8 RID: 9160
		// (get) Token: 0x06007109 RID: 28937 RVA: 0x000D847C File Offset: 0x000D667C
		// (set) Token: 0x0600710A RID: 28938 RVA: 0x000D84A8 File Offset: 0x000D66A8
		[ProtoMember(5, IsRequired = false, Name = "vipLevel", DataFormat = DataFormat.TwosComplement)]
		public uint vipLevel
		{
			get
			{
				return this._vipLevel ?? 0U;
			}
			set
			{
				this._vipLevel = new uint?(value);
			}
		}

		// Token: 0x170023C9 RID: 9161
		// (get) Token: 0x0600710B RID: 28939 RVA: 0x000D84B8 File Offset: 0x000D66B8
		// (set) Token: 0x0600710C RID: 28940 RVA: 0x000D84D8 File Offset: 0x000D66D8
		[XmlIgnore]
		[Browsable(false)]
		public bool vipLevelSpecified
		{
			get
			{
				return this._vipLevel != null;
			}
			set
			{
				bool flag = value == (this._vipLevel == null);
				if (flag)
				{
					this._vipLevel = (value ? new uint?(this.vipLevel) : null);
				}
			}
		}

		// Token: 0x0600710D RID: 28941 RVA: 0x000D851C File Offset: 0x000D671C
		private bool ShouldSerializevipLevel()
		{
			return this.vipLevelSpecified;
		}

		// Token: 0x0600710E RID: 28942 RVA: 0x000D8534 File Offset: 0x000D6734
		private void ResetvipLevel()
		{
			this.vipLevelSpecified = false;
		}

		// Token: 0x170023CA RID: 9162
		// (get) Token: 0x0600710F RID: 28943 RVA: 0x000D8540 File Offset: 0x000D6740
		// (set) Token: 0x06007110 RID: 28944 RVA: 0x000D856C File Offset: 0x000D676C
		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170023CB RID: 9163
		// (get) Token: 0x06007111 RID: 28945 RVA: 0x000D857C File Offset: 0x000D677C
		// (set) Token: 0x06007112 RID: 28946 RVA: 0x000D859C File Offset: 0x000D679C
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

		// Token: 0x06007113 RID: 28947 RVA: 0x000D85E0 File Offset: 0x000D67E0
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007114 RID: 28948 RVA: 0x000D85F8 File Offset: 0x000D67F8
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170023CC RID: 9164
		// (get) Token: 0x06007115 RID: 28949 RVA: 0x000D8604 File Offset: 0x000D6804
		// (set) Token: 0x06007116 RID: 28950 RVA: 0x000D8630 File Offset: 0x000D6830
		[ProtoMember(7, IsRequired = false, Name = "isOnline", DataFormat = DataFormat.Default)]
		public bool isOnline
		{
			get
			{
				return this._isOnline ?? false;
			}
			set
			{
				this._isOnline = new bool?(value);
			}
		}

		// Token: 0x170023CD RID: 9165
		// (get) Token: 0x06007117 RID: 28951 RVA: 0x000D8640 File Offset: 0x000D6840
		// (set) Token: 0x06007118 RID: 28952 RVA: 0x000D8660 File Offset: 0x000D6860
		[XmlIgnore]
		[Browsable(false)]
		public bool isOnlineSpecified
		{
			get
			{
				return this._isOnline != null;
			}
			set
			{
				bool flag = value == (this._isOnline == null);
				if (flag)
				{
					this._isOnline = (value ? new bool?(this.isOnline) : null);
				}
			}
		}

		// Token: 0x06007119 RID: 28953 RVA: 0x000D86A4 File Offset: 0x000D68A4
		private bool ShouldSerializeisOnline()
		{
			return this.isOnlineSpecified;
		}

		// Token: 0x0600711A RID: 28954 RVA: 0x000D86BC File Offset: 0x000D68BC
		private void ResetisOnline()
		{
			this.isOnlineSpecified = false;
		}

		// Token: 0x170023CE RID: 9166
		// (get) Token: 0x0600711B RID: 28955 RVA: 0x000D86C8 File Offset: 0x000D68C8
		// (set) Token: 0x0600711C RID: 28956 RVA: 0x000D86F4 File Offset: 0x000D68F4
		[ProtoMember(8, IsRequired = false, Name = "startType", DataFormat = DataFormat.TwosComplement)]
		public int startType
		{
			get
			{
				return this._startType ?? 0;
			}
			set
			{
				this._startType = new int?(value);
			}
		}

		// Token: 0x170023CF RID: 9167
		// (get) Token: 0x0600711D RID: 28957 RVA: 0x000D8704 File Offset: 0x000D6904
		// (set) Token: 0x0600711E RID: 28958 RVA: 0x000D8724 File Offset: 0x000D6924
		[XmlIgnore]
		[Browsable(false)]
		public bool startTypeSpecified
		{
			get
			{
				return this._startType != null;
			}
			set
			{
				bool flag = value == (this._startType == null);
				if (flag)
				{
					this._startType = (value ? new int?(this.startType) : null);
				}
			}
		}

		// Token: 0x0600711F RID: 28959 RVA: 0x000D8768 File Offset: 0x000D6968
		private bool ShouldSerializestartType()
		{
			return this.startTypeSpecified;
		}

		// Token: 0x06007120 RID: 28960 RVA: 0x000D8780 File Offset: 0x000D6980
		private void ResetstartType()
		{
			this.startTypeSpecified = false;
		}

		// Token: 0x170023D0 RID: 9168
		// (get) Token: 0x06007121 RID: 28961 RVA: 0x000D878C File Offset: 0x000D698C
		// (set) Token: 0x06007122 RID: 28962 RVA: 0x000D87B8 File Offset: 0x000D69B8
		[ProtoMember(9, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		// Token: 0x170023D1 RID: 9169
		// (get) Token: 0x06007123 RID: 28963 RVA: 0x000D87C8 File Offset: 0x000D69C8
		// (set) Token: 0x06007124 RID: 28964 RVA: 0x000D87E8 File Offset: 0x000D69E8
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		// Token: 0x06007125 RID: 28965 RVA: 0x000D882C File Offset: 0x000D6A2C
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06007126 RID: 28966 RVA: 0x000D8844 File Offset: 0x000D6A44
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170023D2 RID: 9170
		// (get) Token: 0x06007127 RID: 28967 RVA: 0x000D8850 File Offset: 0x000D6A50
		// (set) Token: 0x06007128 RID: 28968 RVA: 0x000D8868 File Offset: 0x000D6A68
		[ProtoMember(10, IsRequired = false, Name = "pre", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PayConsume pre
		{
			get
			{
				return this._pre;
			}
			set
			{
				this._pre = value;
			}
		}

		// Token: 0x06007129 RID: 28969 RVA: 0x000D8874 File Offset: 0x000D6A74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001AF3 RID: 6899
		private PlatFriend _platfriendBaseInfo = null;

		// Token: 0x04001AF4 RID: 6900
		private uint? _rank;

		// Token: 0x04001AF5 RID: 6901
		private bool? _hasGiveGift;

		// Token: 0x04001AF6 RID: 6902
		private uint? _maxAbility;

		// Token: 0x04001AF7 RID: 6903
		private uint? _vipLevel;

		// Token: 0x04001AF8 RID: 6904
		private uint? _level;

		// Token: 0x04001AF9 RID: 6905
		private bool? _isOnline;

		// Token: 0x04001AFA RID: 6906
		private int? _startType;

		// Token: 0x04001AFB RID: 6907
		private int? _profession;

		// Token: 0x04001AFC RID: 6908
		private PayConsume _pre = null;

		// Token: 0x04001AFD RID: 6909
		private IExtension extensionObject;
	}
}
