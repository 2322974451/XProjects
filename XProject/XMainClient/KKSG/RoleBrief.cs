using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E9 RID: 1513
	[ProtoContract(Name = "RoleBrief")]
	[Serializable]
	public class RoleBrief : IExtensible
	{
		// Token: 0x17001B9E RID: 7070
		// (get) Token: 0x0600589C RID: 22684 RVA: 0x000A88A0 File Offset: 0x000A6AA0
		// (set) Token: 0x0600589D RID: 22685 RVA: 0x000A88CC File Offset: 0x000A6ACC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public RoleType type
		{
			get
			{
				return this._type ?? RoleType.Role_INVALID;
			}
			set
			{
				this._type = new RoleType?(value);
			}
		}

		// Token: 0x17001B9F RID: 7071
		// (get) Token: 0x0600589E RID: 22686 RVA: 0x000A88DC File Offset: 0x000A6ADC
		// (set) Token: 0x0600589F RID: 22687 RVA: 0x000A88FC File Offset: 0x000A6AFC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new RoleType?(this.type) : null);
				}
			}
		}

		// Token: 0x060058A0 RID: 22688 RVA: 0x000A8940 File Offset: 0x000A6B40
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x000A8958 File Offset: 0x000A6B58
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001BA0 RID: 7072
		// (get) Token: 0x060058A2 RID: 22690 RVA: 0x000A8964 File Offset: 0x000A6B64
		// (set) Token: 0x060058A3 RID: 22691 RVA: 0x000A8985 File Offset: 0x000A6B85
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001BA1 RID: 7073
		// (get) Token: 0x060058A4 RID: 22692 RVA: 0x000A8990 File Offset: 0x000A6B90
		// (set) Token: 0x060058A5 RID: 22693 RVA: 0x000A89AC File Offset: 0x000A6BAC
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

		// Token: 0x060058A6 RID: 22694 RVA: 0x000A89DC File Offset: 0x000A6BDC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x000A89F4 File Offset: 0x000A6BF4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001BA2 RID: 7074
		// (get) Token: 0x060058A8 RID: 22696 RVA: 0x000A8A00 File Offset: 0x000A6C00
		// (set) Token: 0x060058A9 RID: 22697 RVA: 0x000A8A2D File Offset: 0x000A6C2D
		[ProtoMember(3, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17001BA3 RID: 7075
		// (get) Token: 0x060058AA RID: 22698 RVA: 0x000A8A3C File Offset: 0x000A6C3C
		// (set) Token: 0x060058AB RID: 22699 RVA: 0x000A8A5C File Offset: 0x000A6C5C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x060058AC RID: 22700 RVA: 0x000A8AA0 File Offset: 0x000A6CA0
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060058AD RID: 22701 RVA: 0x000A8AB8 File Offset: 0x000A6CB8
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17001BA4 RID: 7076
		// (get) Token: 0x060058AE RID: 22702 RVA: 0x000A8AC4 File Offset: 0x000A6CC4
		// (set) Token: 0x060058AF RID: 22703 RVA: 0x000A8AE5 File Offset: 0x000A6CE5
		[ProtoMember(4, IsRequired = false, Name = "accountID", DataFormat = DataFormat.Default)]
		public string accountID
		{
			get
			{
				return this._accountID ?? "";
			}
			set
			{
				this._accountID = value;
			}
		}

		// Token: 0x17001BA5 RID: 7077
		// (get) Token: 0x060058B0 RID: 22704 RVA: 0x000A8AF0 File Offset: 0x000A6CF0
		// (set) Token: 0x060058B1 RID: 22705 RVA: 0x000A8B0C File Offset: 0x000A6D0C
		[XmlIgnore]
		[Browsable(false)]
		public bool accountIDSpecified
		{
			get
			{
				return this._accountID != null;
			}
			set
			{
				bool flag = value == (this._accountID == null);
				if (flag)
				{
					this._accountID = (value ? this.accountID : null);
				}
			}
		}

		// Token: 0x060058B2 RID: 22706 RVA: 0x000A8B3C File Offset: 0x000A6D3C
		private bool ShouldSerializeaccountID()
		{
			return this.accountIDSpecified;
		}

		// Token: 0x060058B3 RID: 22707 RVA: 0x000A8B54 File Offset: 0x000A6D54
		private void ResetaccountID()
		{
			this.accountIDSpecified = false;
		}

		// Token: 0x17001BA6 RID: 7078
		// (get) Token: 0x060058B4 RID: 22708 RVA: 0x000A8B60 File Offset: 0x000A6D60
		// (set) Token: 0x060058B5 RID: 22709 RVA: 0x000A8B8C File Offset: 0x000A6D8C
		[ProtoMember(5, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001BA7 RID: 7079
		// (get) Token: 0x060058B6 RID: 22710 RVA: 0x000A8B9C File Offset: 0x000A6D9C
		// (set) Token: 0x060058B7 RID: 22711 RVA: 0x000A8BBC File Offset: 0x000A6DBC
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

		// Token: 0x060058B8 RID: 22712 RVA: 0x000A8C00 File Offset: 0x000A6E00
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x060058B9 RID: 22713 RVA: 0x000A8C18 File Offset: 0x000A6E18
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17001BA8 RID: 7080
		// (get) Token: 0x060058BA RID: 22714 RVA: 0x000A8C24 File Offset: 0x000A6E24
		// (set) Token: 0x060058BB RID: 22715 RVA: 0x000A8C51 File Offset: 0x000A6E51
		[ProtoMember(6, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public ulong exp
		{
			get
			{
				return this._exp ?? 0UL;
			}
			set
			{
				this._exp = new ulong?(value);
			}
		}

		// Token: 0x17001BA9 RID: 7081
		// (get) Token: 0x060058BC RID: 22716 RVA: 0x000A8C60 File Offset: 0x000A6E60
		// (set) Token: 0x060058BD RID: 22717 RVA: 0x000A8C80 File Offset: 0x000A6E80
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new ulong?(this.exp) : null);
				}
			}
		}

		// Token: 0x060058BE RID: 22718 RVA: 0x000A8CC4 File Offset: 0x000A6EC4
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x060058BF RID: 22719 RVA: 0x000A8CDC File Offset: 0x000A6EDC
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x17001BAA RID: 7082
		// (get) Token: 0x060058C0 RID: 22720 RVA: 0x000A8CE8 File Offset: 0x000A6EE8
		// (set) Token: 0x060058C1 RID: 22721 RVA: 0x000A8D15 File Offset: 0x000A6F15
		[ProtoMember(7, IsRequired = false, Name = "maxexp", DataFormat = DataFormat.TwosComplement)]
		public ulong maxexp
		{
			get
			{
				return this._maxexp ?? 0UL;
			}
			set
			{
				this._maxexp = new ulong?(value);
			}
		}

		// Token: 0x17001BAB RID: 7083
		// (get) Token: 0x060058C2 RID: 22722 RVA: 0x000A8D24 File Offset: 0x000A6F24
		// (set) Token: 0x060058C3 RID: 22723 RVA: 0x000A8D44 File Offset: 0x000A6F44
		[XmlIgnore]
		[Browsable(false)]
		public bool maxexpSpecified
		{
			get
			{
				return this._maxexp != null;
			}
			set
			{
				bool flag = value == (this._maxexp == null);
				if (flag)
				{
					this._maxexp = (value ? new ulong?(this.maxexp) : null);
				}
			}
		}

		// Token: 0x060058C4 RID: 22724 RVA: 0x000A8D88 File Offset: 0x000A6F88
		private bool ShouldSerializemaxexp()
		{
			return this.maxexpSpecified;
		}

		// Token: 0x060058C5 RID: 22725 RVA: 0x000A8DA0 File Offset: 0x000A6FA0
		private void Resetmaxexp()
		{
			this.maxexpSpecified = false;
		}

		// Token: 0x17001BAC RID: 7084
		// (get) Token: 0x060058C6 RID: 22726 RVA: 0x000A8DAC File Offset: 0x000A6FAC
		// (set) Token: 0x060058C7 RID: 22727 RVA: 0x000A8DC4 File Offset: 0x000A6FC4
		[ProtoMember(8, IsRequired = false, Name = "position", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Vec3 position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x17001BAD RID: 7085
		// (get) Token: 0x060058C8 RID: 22728 RVA: 0x000A8DD0 File Offset: 0x000A6FD0
		// (set) Token: 0x060058C9 RID: 22729 RVA: 0x000A8DFC File Offset: 0x000A6FFC
		[ProtoMember(9, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
		public int sceneID
		{
			get
			{
				return this._sceneID ?? 0;
			}
			set
			{
				this._sceneID = new int?(value);
			}
		}

		// Token: 0x17001BAE RID: 7086
		// (get) Token: 0x060058CA RID: 22730 RVA: 0x000A8E0C File Offset: 0x000A700C
		// (set) Token: 0x060058CB RID: 22731 RVA: 0x000A8E2C File Offset: 0x000A702C
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIDSpecified
		{
			get
			{
				return this._sceneID != null;
			}
			set
			{
				bool flag = value == (this._sceneID == null);
				if (flag)
				{
					this._sceneID = (value ? new int?(this.sceneID) : null);
				}
			}
		}

		// Token: 0x060058CC RID: 22732 RVA: 0x000A8E70 File Offset: 0x000A7070
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060058CD RID: 22733 RVA: 0x000A8E88 File Offset: 0x000A7088
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x17001BAF RID: 7087
		// (get) Token: 0x060058CE RID: 22734 RVA: 0x000A8E94 File Offset: 0x000A7094
		// (set) Token: 0x060058CF RID: 22735 RVA: 0x000A8EC4 File Offset: 0x000A70C4
		[ProtoMember(10, IsRequired = false, Name = "face", DataFormat = DataFormat.FixedSize)]
		public float face
		{
			get
			{
				return this._face ?? 0f;
			}
			set
			{
				this._face = new float?(value);
			}
		}

		// Token: 0x17001BB0 RID: 7088
		// (get) Token: 0x060058D0 RID: 22736 RVA: 0x000A8ED4 File Offset: 0x000A70D4
		// (set) Token: 0x060058D1 RID: 22737 RVA: 0x000A8EF4 File Offset: 0x000A70F4
		[XmlIgnore]
		[Browsable(false)]
		public bool faceSpecified
		{
			get
			{
				return this._face != null;
			}
			set
			{
				bool flag = value == (this._face == null);
				if (flag)
				{
					this._face = (value ? new float?(this.face) : null);
				}
			}
		}

		// Token: 0x060058D2 RID: 22738 RVA: 0x000A8F38 File Offset: 0x000A7138
		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		// Token: 0x060058D3 RID: 22739 RVA: 0x000A8F50 File Offset: 0x000A7150
		private void Resetface()
		{
			this.faceSpecified = false;
		}

		// Token: 0x17001BB1 RID: 7089
		// (get) Token: 0x060058D4 RID: 22740 RVA: 0x000A8F5C File Offset: 0x000A715C
		// (set) Token: 0x060058D5 RID: 22741 RVA: 0x000A8F88 File Offset: 0x000A7188
		[ProtoMember(11, IsRequired = false, Name = "offlineTime", DataFormat = DataFormat.TwosComplement)]
		public uint offlineTime
		{
			get
			{
				return this._offlineTime ?? 0U;
			}
			set
			{
				this._offlineTime = new uint?(value);
			}
		}

		// Token: 0x17001BB2 RID: 7090
		// (get) Token: 0x060058D6 RID: 22742 RVA: 0x000A8F98 File Offset: 0x000A7198
		// (set) Token: 0x060058D7 RID: 22743 RVA: 0x000A8FB8 File Offset: 0x000A71B8
		[XmlIgnore]
		[Browsable(false)]
		public bool offlineTimeSpecified
		{
			get
			{
				return this._offlineTime != null;
			}
			set
			{
				bool flag = value == (this._offlineTime == null);
				if (flag)
				{
					this._offlineTime = (value ? new uint?(this.offlineTime) : null);
				}
			}
		}

		// Token: 0x060058D8 RID: 22744 RVA: 0x000A8FFC File Offset: 0x000A71FC
		private bool ShouldSerializeofflineTime()
		{
			return this.offlineTimeSpecified;
		}

		// Token: 0x060058D9 RID: 22745 RVA: 0x000A9014 File Offset: 0x000A7214
		private void ResetofflineTime()
		{
			this.offlineTimeSpecified = false;
		}

		// Token: 0x17001BB3 RID: 7091
		// (get) Token: 0x060058DA RID: 22746 RVA: 0x000A9020 File Offset: 0x000A7220
		// (set) Token: 0x060058DB RID: 22747 RVA: 0x000A904C File Offset: 0x000A724C
		[ProtoMember(12, IsRequired = false, Name = "completeguidestage", DataFormat = DataFormat.Default)]
		public bool completeguidestage
		{
			get
			{
				return this._completeguidestage ?? false;
			}
			set
			{
				this._completeguidestage = new bool?(value);
			}
		}

		// Token: 0x17001BB4 RID: 7092
		// (get) Token: 0x060058DC RID: 22748 RVA: 0x000A905C File Offset: 0x000A725C
		// (set) Token: 0x060058DD RID: 22749 RVA: 0x000A907C File Offset: 0x000A727C
		[XmlIgnore]
		[Browsable(false)]
		public bool completeguidestageSpecified
		{
			get
			{
				return this._completeguidestage != null;
			}
			set
			{
				bool flag = value == (this._completeguidestage == null);
				if (flag)
				{
					this._completeguidestage = (value ? new bool?(this.completeguidestage) : null);
				}
			}
		}

		// Token: 0x060058DE RID: 22750 RVA: 0x000A90C0 File Offset: 0x000A72C0
		private bool ShouldSerializecompleteguidestage()
		{
			return this.completeguidestageSpecified;
		}

		// Token: 0x060058DF RID: 22751 RVA: 0x000A90D8 File Offset: 0x000A72D8
		private void Resetcompleteguidestage()
		{
			this.completeguidestageSpecified = false;
		}

		// Token: 0x17001BB5 RID: 7093
		// (get) Token: 0x060058E0 RID: 22752 RVA: 0x000A90E4 File Offset: 0x000A72E4
		// (set) Token: 0x060058E1 RID: 22753 RVA: 0x000A9111 File Offset: 0x000A7311
		[ProtoMember(13, IsRequired = false, Name = "tutorialBits", DataFormat = DataFormat.TwosComplement)]
		public ulong tutorialBits
		{
			get
			{
				return this._tutorialBits ?? 0UL;
			}
			set
			{
				this._tutorialBits = new ulong?(value);
			}
		}

		// Token: 0x17001BB6 RID: 7094
		// (get) Token: 0x060058E2 RID: 22754 RVA: 0x000A9120 File Offset: 0x000A7320
		// (set) Token: 0x060058E3 RID: 22755 RVA: 0x000A9140 File Offset: 0x000A7340
		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialBitsSpecified
		{
			get
			{
				return this._tutorialBits != null;
			}
			set
			{
				bool flag = value == (this._tutorialBits == null);
				if (flag)
				{
					this._tutorialBits = (value ? new ulong?(this.tutorialBits) : null);
				}
			}
		}

		// Token: 0x060058E4 RID: 22756 RVA: 0x000A9184 File Offset: 0x000A7384
		private bool ShouldSerializetutorialBits()
		{
			return this.tutorialBitsSpecified;
		}

		// Token: 0x060058E5 RID: 22757 RVA: 0x000A919C File Offset: 0x000A739C
		private void ResettutorialBits()
		{
			this.tutorialBitsSpecified = false;
		}

		// Token: 0x17001BB7 RID: 7095
		// (get) Token: 0x060058E6 RID: 22758 RVA: 0x000A91A8 File Offset: 0x000A73A8
		// (set) Token: 0x060058E7 RID: 22759 RVA: 0x000A91D4 File Offset: 0x000A73D4
		[ProtoMember(14, IsRequired = false, Name = "onlimetime", DataFormat = DataFormat.TwosComplement)]
		public uint onlimetime
		{
			get
			{
				return this._onlimetime ?? 0U;
			}
			set
			{
				this._onlimetime = new uint?(value);
			}
		}

		// Token: 0x17001BB8 RID: 7096
		// (get) Token: 0x060058E8 RID: 22760 RVA: 0x000A91E4 File Offset: 0x000A73E4
		// (set) Token: 0x060058E9 RID: 22761 RVA: 0x000A9204 File Offset: 0x000A7404
		[XmlIgnore]
		[Browsable(false)]
		public bool onlimetimeSpecified
		{
			get
			{
				return this._onlimetime != null;
			}
			set
			{
				bool flag = value == (this._onlimetime == null);
				if (flag)
				{
					this._onlimetime = (value ? new uint?(this.onlimetime) : null);
				}
			}
		}

		// Token: 0x060058EA RID: 22762 RVA: 0x000A9248 File Offset: 0x000A7448
		private bool ShouldSerializeonlimetime()
		{
			return this.onlimetimeSpecified;
		}

		// Token: 0x060058EB RID: 22763 RVA: 0x000A9260 File Offset: 0x000A7460
		private void Resetonlimetime()
		{
			this.onlimetimeSpecified = false;
		}

		// Token: 0x17001BB9 RID: 7097
		// (get) Token: 0x060058EC RID: 22764 RVA: 0x000A926C File Offset: 0x000A746C
		// (set) Token: 0x060058ED RID: 22765 RVA: 0x000A9298 File Offset: 0x000A7498
		[ProtoMember(15, IsRequired = false, Name = "auctionPoint", DataFormat = DataFormat.TwosComplement)]
		public uint auctionPoint
		{
			get
			{
				return this._auctionPoint ?? 0U;
			}
			set
			{
				this._auctionPoint = new uint?(value);
			}
		}

		// Token: 0x17001BBA RID: 7098
		// (get) Token: 0x060058EE RID: 22766 RVA: 0x000A92A8 File Offset: 0x000A74A8
		// (set) Token: 0x060058EF RID: 22767 RVA: 0x000A92C8 File Offset: 0x000A74C8
		[XmlIgnore]
		[Browsable(false)]
		public bool auctionPointSpecified
		{
			get
			{
				return this._auctionPoint != null;
			}
			set
			{
				bool flag = value == (this._auctionPoint == null);
				if (flag)
				{
					this._auctionPoint = (value ? new uint?(this.auctionPoint) : null);
				}
			}
		}

		// Token: 0x060058F0 RID: 22768 RVA: 0x000A930C File Offset: 0x000A750C
		private bool ShouldSerializeauctionPoint()
		{
			return this.auctionPointSpecified;
		}

		// Token: 0x060058F1 RID: 22769 RVA: 0x000A9324 File Offset: 0x000A7524
		private void ResetauctionPoint()
		{
			this.auctionPointSpecified = false;
		}

		// Token: 0x17001BBB RID: 7099
		// (get) Token: 0x060058F2 RID: 22770 RVA: 0x000A9330 File Offset: 0x000A7530
		// (set) Token: 0x060058F3 RID: 22771 RVA: 0x000A935C File Offset: 0x000A755C
		[ProtoMember(16, IsRequired = false, Name = "campID", DataFormat = DataFormat.TwosComplement)]
		public uint campID
		{
			get
			{
				return this._campID ?? 0U;
			}
			set
			{
				this._campID = new uint?(value);
			}
		}

		// Token: 0x17001BBC RID: 7100
		// (get) Token: 0x060058F4 RID: 22772 RVA: 0x000A936C File Offset: 0x000A756C
		// (set) Token: 0x060058F5 RID: 22773 RVA: 0x000A938C File Offset: 0x000A758C
		[XmlIgnore]
		[Browsable(false)]
		public bool campIDSpecified
		{
			get
			{
				return this._campID != null;
			}
			set
			{
				bool flag = value == (this._campID == null);
				if (flag)
				{
					this._campID = (value ? new uint?(this.campID) : null);
				}
			}
		}

		// Token: 0x060058F6 RID: 22774 RVA: 0x000A93D0 File Offset: 0x000A75D0
		private bool ShouldSerializecampID()
		{
			return this.campIDSpecified;
		}

		// Token: 0x060058F7 RID: 22775 RVA: 0x000A93E8 File Offset: 0x000A75E8
		private void ResetcampID()
		{
			this.campIDSpecified = false;
		}

		// Token: 0x17001BBD RID: 7101
		// (get) Token: 0x060058F8 RID: 22776 RVA: 0x000A93F4 File Offset: 0x000A75F4
		// (set) Token: 0x060058F9 RID: 22777 RVA: 0x000A9420 File Offset: 0x000A7620
		[ProtoMember(17, IsRequired = false, Name = "accountNumberLastDay", DataFormat = DataFormat.TwosComplement)]
		public uint accountNumberLastDay
		{
			get
			{
				return this._accountNumberLastDay ?? 0U;
			}
			set
			{
				this._accountNumberLastDay = new uint?(value);
			}
		}

		// Token: 0x17001BBE RID: 7102
		// (get) Token: 0x060058FA RID: 22778 RVA: 0x000A9430 File Offset: 0x000A7630
		// (set) Token: 0x060058FB RID: 22779 RVA: 0x000A9450 File Offset: 0x000A7650
		[XmlIgnore]
		[Browsable(false)]
		public bool accountNumberLastDaySpecified
		{
			get
			{
				return this._accountNumberLastDay != null;
			}
			set
			{
				bool flag = value == (this._accountNumberLastDay == null);
				if (flag)
				{
					this._accountNumberLastDay = (value ? new uint?(this.accountNumberLastDay) : null);
				}
			}
		}

		// Token: 0x060058FC RID: 22780 RVA: 0x000A9494 File Offset: 0x000A7694
		private bool ShouldSerializeaccountNumberLastDay()
		{
			return this.accountNumberLastDaySpecified;
		}

		// Token: 0x060058FD RID: 22781 RVA: 0x000A94AC File Offset: 0x000A76AC
		private void ResetaccountNumberLastDay()
		{
			this.accountNumberLastDaySpecified = false;
		}

		// Token: 0x17001BBF RID: 7103
		// (get) Token: 0x060058FE RID: 22782 RVA: 0x000A94B8 File Offset: 0x000A76B8
		// (set) Token: 0x060058FF RID: 22783 RVA: 0x000A94E5 File Offset: 0x000A76E5
		[ProtoMember(18, IsRequired = false, Name = "lastAccountTime", DataFormat = DataFormat.TwosComplement)]
		public ulong lastAccountTime
		{
			get
			{
				return this._lastAccountTime ?? 0UL;
			}
			set
			{
				this._lastAccountTime = new ulong?(value);
			}
		}

		// Token: 0x17001BC0 RID: 7104
		// (get) Token: 0x06005900 RID: 22784 RVA: 0x000A94F4 File Offset: 0x000A76F4
		// (set) Token: 0x06005901 RID: 22785 RVA: 0x000A9514 File Offset: 0x000A7714
		[XmlIgnore]
		[Browsable(false)]
		public bool lastAccountTimeSpecified
		{
			get
			{
				return this._lastAccountTime != null;
			}
			set
			{
				bool flag = value == (this._lastAccountTime == null);
				if (flag)
				{
					this._lastAccountTime = (value ? new ulong?(this.lastAccountTime) : null);
				}
			}
		}

		// Token: 0x06005902 RID: 22786 RVA: 0x000A9558 File Offset: 0x000A7758
		private bool ShouldSerializelastAccountTime()
		{
			return this.lastAccountTimeSpecified;
		}

		// Token: 0x06005903 RID: 22787 RVA: 0x000A9570 File Offset: 0x000A7770
		private void ResetlastAccountTime()
		{
			this.lastAccountTimeSpecified = false;
		}

		// Token: 0x17001BC1 RID: 7105
		// (get) Token: 0x06005904 RID: 22788 RVA: 0x000A957C File Offset: 0x000A777C
		// (set) Token: 0x06005905 RID: 22789 RVA: 0x000A95A8 File Offset: 0x000A77A8
		[ProtoMember(19, IsRequired = false, Name = "nickID", DataFormat = DataFormat.TwosComplement)]
		public uint nickID
		{
			get
			{
				return this._nickID ?? 0U;
			}
			set
			{
				this._nickID = new uint?(value);
			}
		}

		// Token: 0x17001BC2 RID: 7106
		// (get) Token: 0x06005906 RID: 22790 RVA: 0x000A95B8 File Offset: 0x000A77B8
		// (set) Token: 0x06005907 RID: 22791 RVA: 0x000A95D8 File Offset: 0x000A77D8
		[XmlIgnore]
		[Browsable(false)]
		public bool nickIDSpecified
		{
			get
			{
				return this._nickID != null;
			}
			set
			{
				bool flag = value == (this._nickID == null);
				if (flag)
				{
					this._nickID = (value ? new uint?(this.nickID) : null);
				}
			}
		}

		// Token: 0x06005908 RID: 22792 RVA: 0x000A961C File Offset: 0x000A781C
		private bool ShouldSerializenickID()
		{
			return this.nickIDSpecified;
		}

		// Token: 0x06005909 RID: 22793 RVA: 0x000A9634 File Offset: 0x000A7834
		private void ResetnickID()
		{
			this.nickIDSpecified = false;
		}

		// Token: 0x17001BC3 RID: 7107
		// (get) Token: 0x0600590A RID: 22794 RVA: 0x000A9640 File Offset: 0x000A7840
		// (set) Token: 0x0600590B RID: 22795 RVA: 0x000A965D File Offset: 0x000A785D
		[ProtoMember(20, IsRequired = false, Name = "tutorialBitsArray", DataFormat = DataFormat.Default)]
		public byte[] tutorialBitsArray
		{
			get
			{
				return this._tutorialBitsArray ?? null;
			}
			set
			{
				this._tutorialBitsArray = value;
			}
		}

		// Token: 0x17001BC4 RID: 7108
		// (get) Token: 0x0600590C RID: 22796 RVA: 0x000A9668 File Offset: 0x000A7868
		// (set) Token: 0x0600590D RID: 22797 RVA: 0x000A9684 File Offset: 0x000A7884
		[XmlIgnore]
		[Browsable(false)]
		public bool tutorialBitsArraySpecified
		{
			get
			{
				return this._tutorialBitsArray != null;
			}
			set
			{
				bool flag = value == (this._tutorialBitsArray == null);
				if (flag)
				{
					this._tutorialBitsArray = (value ? this.tutorialBitsArray : null);
				}
			}
		}

		// Token: 0x0600590E RID: 22798 RVA: 0x000A96B4 File Offset: 0x000A78B4
		private bool ShouldSerializetutorialBitsArray()
		{
			return this.tutorialBitsArraySpecified;
		}

		// Token: 0x0600590F RID: 22799 RVA: 0x000A96CC File Offset: 0x000A78CC
		private void ResettutorialBitsArray()
		{
			this.tutorialBitsArraySpecified = false;
		}

		// Token: 0x17001BC5 RID: 7109
		// (get) Token: 0x06005910 RID: 22800 RVA: 0x000A96D8 File Offset: 0x000A78D8
		// (set) Token: 0x06005911 RID: 22801 RVA: 0x000A9704 File Offset: 0x000A7904
		[ProtoMember(21, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		// Token: 0x17001BC6 RID: 7110
		// (get) Token: 0x06005912 RID: 22802 RVA: 0x000A9714 File Offset: 0x000A7914
		// (set) Token: 0x06005913 RID: 22803 RVA: 0x000A9734 File Offset: 0x000A7934
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		// Token: 0x06005914 RID: 22804 RVA: 0x000A9778 File Offset: 0x000A7978
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x06005915 RID: 22805 RVA: 0x000A9790 File Offset: 0x000A7990
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x17001BC7 RID: 7111
		// (get) Token: 0x06005916 RID: 22806 RVA: 0x000A979C File Offset: 0x000A799C
		// (set) Token: 0x06005917 RID: 22807 RVA: 0x000A97C8 File Offset: 0x000A79C8
		[ProtoMember(22, IsRequired = false, Name = "paymemberid", DataFormat = DataFormat.TwosComplement)]
		public uint paymemberid
		{
			get
			{
				return this._paymemberid ?? 0U;
			}
			set
			{
				this._paymemberid = new uint?(value);
			}
		}

		// Token: 0x17001BC8 RID: 7112
		// (get) Token: 0x06005918 RID: 22808 RVA: 0x000A97D8 File Offset: 0x000A79D8
		// (set) Token: 0x06005919 RID: 22809 RVA: 0x000A97F8 File Offset: 0x000A79F8
		[XmlIgnore]
		[Browsable(false)]
		public bool paymemberidSpecified
		{
			get
			{
				return this._paymemberid != null;
			}
			set
			{
				bool flag = value == (this._paymemberid == null);
				if (flag)
				{
					this._paymemberid = (value ? new uint?(this.paymemberid) : null);
				}
			}
		}

		// Token: 0x0600591A RID: 22810 RVA: 0x000A983C File Offset: 0x000A7A3C
		private bool ShouldSerializepaymemberid()
		{
			return this.paymemberidSpecified;
		}

		// Token: 0x0600591B RID: 22811 RVA: 0x000A9854 File Offset: 0x000A7A54
		private void Resetpaymemberid()
		{
			this.paymemberidSpecified = false;
		}

		// Token: 0x17001BC9 RID: 7113
		// (get) Token: 0x0600591C RID: 22812 RVA: 0x000A9860 File Offset: 0x000A7A60
		// (set) Token: 0x0600591D RID: 22813 RVA: 0x000A988C File Offset: 0x000A7A8C
		[ProtoMember(23, IsRequired = false, Name = "changenamecount", DataFormat = DataFormat.TwosComplement)]
		public uint changenamecount
		{
			get
			{
				return this._changenamecount ?? 0U;
			}
			set
			{
				this._changenamecount = new uint?(value);
			}
		}

		// Token: 0x17001BCA RID: 7114
		// (get) Token: 0x0600591E RID: 22814 RVA: 0x000A989C File Offset: 0x000A7A9C
		// (set) Token: 0x0600591F RID: 22815 RVA: 0x000A98BC File Offset: 0x000A7ABC
		[XmlIgnore]
		[Browsable(false)]
		public bool changenamecountSpecified
		{
			get
			{
				return this._changenamecount != null;
			}
			set
			{
				bool flag = value == (this._changenamecount == null);
				if (flag)
				{
					this._changenamecount = (value ? new uint?(this.changenamecount) : null);
				}
			}
		}

		// Token: 0x06005920 RID: 22816 RVA: 0x000A9900 File Offset: 0x000A7B00
		private bool ShouldSerializechangenamecount()
		{
			return this.changenamecountSpecified;
		}

		// Token: 0x06005921 RID: 22817 RVA: 0x000A9918 File Offset: 0x000A7B18
		private void Resetchangenamecount()
		{
			this.changenamecountSpecified = false;
		}

		// Token: 0x17001BCB RID: 7115
		// (get) Token: 0x06005922 RID: 22818 RVA: 0x000A9924 File Offset: 0x000A7B24
		// (set) Token: 0x06005923 RID: 22819 RVA: 0x000A993C File Offset: 0x000A7B3C
		[ProtoMember(24, IsRequired = false, Name = "op", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLookOp op
		{
			get
			{
				return this._op;
			}
			set
			{
				this._op = value;
			}
		}

		// Token: 0x17001BCC RID: 7116
		// (get) Token: 0x06005924 RID: 22820 RVA: 0x000A9948 File Offset: 0x000A7B48
		// (set) Token: 0x06005925 RID: 22821 RVA: 0x000A9975 File Offset: 0x000A7B75
		[ProtoMember(25, IsRequired = false, Name = "inittime", DataFormat = DataFormat.TwosComplement)]
		public ulong inittime
		{
			get
			{
				return this._inittime ?? 0UL;
			}
			set
			{
				this._inittime = new ulong?(value);
			}
		}

		// Token: 0x17001BCD RID: 7117
		// (get) Token: 0x06005926 RID: 22822 RVA: 0x000A9984 File Offset: 0x000A7B84
		// (set) Token: 0x06005927 RID: 22823 RVA: 0x000A99A4 File Offset: 0x000A7BA4
		[XmlIgnore]
		[Browsable(false)]
		public bool inittimeSpecified
		{
			get
			{
				return this._inittime != null;
			}
			set
			{
				bool flag = value == (this._inittime == null);
				if (flag)
				{
					this._inittime = (value ? new ulong?(this.inittime) : null);
				}
			}
		}

		// Token: 0x06005928 RID: 22824 RVA: 0x000A99E8 File Offset: 0x000A7BE8
		private bool ShouldSerializeinittime()
		{
			return this.inittimeSpecified;
		}

		// Token: 0x06005929 RID: 22825 RVA: 0x000A9A00 File Offset: 0x000A7C00
		private void Resetinittime()
		{
			this.inittimeSpecified = false;
		}

		// Token: 0x0600592A RID: 22826 RVA: 0x000A9A0C File Offset: 0x000A7C0C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001598 RID: 5528
		private RoleType? _type;

		// Token: 0x04001599 RID: 5529
		private string _name;

		// Token: 0x0400159A RID: 5530
		private ulong? _roleID;

		// Token: 0x0400159B RID: 5531
		private string _accountID;

		// Token: 0x0400159C RID: 5532
		private uint? _level;

		// Token: 0x0400159D RID: 5533
		private ulong? _exp;

		// Token: 0x0400159E RID: 5534
		private ulong? _maxexp;

		// Token: 0x0400159F RID: 5535
		private Vec3 _position = null;

		// Token: 0x040015A0 RID: 5536
		private int? _sceneID;

		// Token: 0x040015A1 RID: 5537
		private float? _face;

		// Token: 0x040015A2 RID: 5538
		private uint? _offlineTime;

		// Token: 0x040015A3 RID: 5539
		private bool? _completeguidestage;

		// Token: 0x040015A4 RID: 5540
		private ulong? _tutorialBits;

		// Token: 0x040015A5 RID: 5541
		private uint? _onlimetime;

		// Token: 0x040015A6 RID: 5542
		private uint? _auctionPoint;

		// Token: 0x040015A7 RID: 5543
		private uint? _campID;

		// Token: 0x040015A8 RID: 5544
		private uint? _accountNumberLastDay;

		// Token: 0x040015A9 RID: 5545
		private ulong? _lastAccountTime;

		// Token: 0x040015AA RID: 5546
		private uint? _nickID;

		// Token: 0x040015AB RID: 5547
		private byte[] _tutorialBitsArray;

		// Token: 0x040015AC RID: 5548
		private uint? _titleID;

		// Token: 0x040015AD RID: 5549
		private uint? _paymemberid;

		// Token: 0x040015AE RID: 5550
		private uint? _changenamecount;

		// Token: 0x040015AF RID: 5551
		private OutLookOp _op = null;

		// Token: 0x040015B0 RID: 5552
		private ulong? _inittime;

		// Token: 0x040015B1 RID: 5553
		private IExtension extensionObject;
	}
}
