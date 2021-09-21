using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005B5 RID: 1461
	[ProtoContract(Name = "GuildInfo")]
	[Serializable]
	public class GuildInfo : IExtensible
	{
		// Token: 0x170018CC RID: 6348
		// (get) Token: 0x0600504D RID: 20557 RVA: 0x00098B98 File Offset: 0x00096D98
		// (set) Token: 0x0600504E RID: 20558 RVA: 0x00098BB9 File Offset: 0x00096DB9
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x170018CD RID: 6349
		// (get) Token: 0x0600504F RID: 20559 RVA: 0x00098BC4 File Offset: 0x00096DC4
		// (set) Token: 0x06005050 RID: 20560 RVA: 0x00098BE0 File Offset: 0x00096DE0
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

		// Token: 0x06005051 RID: 20561 RVA: 0x00098C10 File Offset: 0x00096E10
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06005052 RID: 20562 RVA: 0x00098C28 File Offset: 0x00096E28
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170018CE RID: 6350
		// (get) Token: 0x06005053 RID: 20563 RVA: 0x00098C34 File Offset: 0x00096E34
		// (set) Token: 0x06005054 RID: 20564 RVA: 0x00098C61 File Offset: 0x00096E61
		[ProtoMember(2, IsRequired = false, Name = "leaderID", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderID
		{
			get
			{
				return this._leaderID ?? 0UL;
			}
			set
			{
				this._leaderID = new ulong?(value);
			}
		}

		// Token: 0x170018CF RID: 6351
		// (get) Token: 0x06005055 RID: 20565 RVA: 0x00098C70 File Offset: 0x00096E70
		// (set) Token: 0x06005056 RID: 20566 RVA: 0x00098C90 File Offset: 0x00096E90
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIDSpecified
		{
			get
			{
				return this._leaderID != null;
			}
			set
			{
				bool flag = value == (this._leaderID == null);
				if (flag)
				{
					this._leaderID = (value ? new ulong?(this.leaderID) : null);
				}
			}
		}

		// Token: 0x06005057 RID: 20567 RVA: 0x00098CD4 File Offset: 0x00096ED4
		private bool ShouldSerializeleaderID()
		{
			return this.leaderIDSpecified;
		}

		// Token: 0x06005058 RID: 20568 RVA: 0x00098CEC File Offset: 0x00096EEC
		private void ResetleaderID()
		{
			this.leaderIDSpecified = false;
		}

		// Token: 0x170018D0 RID: 6352
		// (get) Token: 0x06005059 RID: 20569 RVA: 0x00098CF8 File Offset: 0x00096EF8
		// (set) Token: 0x0600505A RID: 20570 RVA: 0x00098D19 File Offset: 0x00096F19
		[ProtoMember(3, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
		public string leaderName
		{
			get
			{
				return this._leaderName ?? "";
			}
			set
			{
				this._leaderName = value;
			}
		}

		// Token: 0x170018D1 RID: 6353
		// (get) Token: 0x0600505B RID: 20571 RVA: 0x00098D24 File Offset: 0x00096F24
		// (set) Token: 0x0600505C RID: 20572 RVA: 0x00098D40 File Offset: 0x00096F40
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderNameSpecified
		{
			get
			{
				return this._leaderName != null;
			}
			set
			{
				bool flag = value == (this._leaderName == null);
				if (flag)
				{
					this._leaderName = (value ? this.leaderName : null);
				}
			}
		}

		// Token: 0x0600505D RID: 20573 RVA: 0x00098D70 File Offset: 0x00096F70
		private bool ShouldSerializeleaderName()
		{
			return this.leaderNameSpecified;
		}

		// Token: 0x0600505E RID: 20574 RVA: 0x00098D88 File Offset: 0x00096F88
		private void ResetleaderName()
		{
			this.leaderNameSpecified = false;
		}

		// Token: 0x170018D2 RID: 6354
		// (get) Token: 0x0600505F RID: 20575 RVA: 0x00098D94 File Offset: 0x00096F94
		// (set) Token: 0x06005060 RID: 20576 RVA: 0x00098DC0 File Offset: 0x00096FC0
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		// Token: 0x170018D3 RID: 6355
		// (get) Token: 0x06005061 RID: 20577 RVA: 0x00098DD0 File Offset: 0x00096FD0
		// (set) Token: 0x06005062 RID: 20578 RVA: 0x00098DF0 File Offset: 0x00096FF0
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
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		// Token: 0x06005063 RID: 20579 RVA: 0x00098E34 File Offset: 0x00097034
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06005064 RID: 20580 RVA: 0x00098E4C File Offset: 0x0009704C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x170018D4 RID: 6356
		// (get) Token: 0x06005065 RID: 20581 RVA: 0x00098E58 File Offset: 0x00097058
		// (set) Token: 0x06005066 RID: 20582 RVA: 0x00098E84 File Offset: 0x00097084
		[ProtoMember(5, IsRequired = false, Name = "memberCount", DataFormat = DataFormat.TwosComplement)]
		public int memberCount
		{
			get
			{
				return this._memberCount ?? 0;
			}
			set
			{
				this._memberCount = new int?(value);
			}
		}

		// Token: 0x170018D5 RID: 6357
		// (get) Token: 0x06005067 RID: 20583 RVA: 0x00098E94 File Offset: 0x00097094
		// (set) Token: 0x06005068 RID: 20584 RVA: 0x00098EB4 File Offset: 0x000970B4
		[XmlIgnore]
		[Browsable(false)]
		public bool memberCountSpecified
		{
			get
			{
				return this._memberCount != null;
			}
			set
			{
				bool flag = value == (this._memberCount == null);
				if (flag)
				{
					this._memberCount = (value ? new int?(this.memberCount) : null);
				}
			}
		}

		// Token: 0x06005069 RID: 20585 RVA: 0x00098EF8 File Offset: 0x000970F8
		private bool ShouldSerializememberCount()
		{
			return this.memberCountSpecified;
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x00098F10 File Offset: 0x00097110
		private void ResetmemberCount()
		{
			this.memberCountSpecified = false;
		}

		// Token: 0x170018D6 RID: 6358
		// (get) Token: 0x0600506B RID: 20587 RVA: 0x00098F1C File Offset: 0x0009711C
		// (set) Token: 0x0600506C RID: 20588 RVA: 0x00098F48 File Offset: 0x00097148
		[ProtoMember(6, IsRequired = false, Name = "isSendApplication", DataFormat = DataFormat.Default)]
		public bool isSendApplication
		{
			get
			{
				return this._isSendApplication ?? false;
			}
			set
			{
				this._isSendApplication = new bool?(value);
			}
		}

		// Token: 0x170018D7 RID: 6359
		// (get) Token: 0x0600506D RID: 20589 RVA: 0x00098F58 File Offset: 0x00097158
		// (set) Token: 0x0600506E RID: 20590 RVA: 0x00098F78 File Offset: 0x00097178
		[XmlIgnore]
		[Browsable(false)]
		public bool isSendApplicationSpecified
		{
			get
			{
				return this._isSendApplication != null;
			}
			set
			{
				bool flag = value == (this._isSendApplication == null);
				if (flag)
				{
					this._isSendApplication = (value ? new bool?(this.isSendApplication) : null);
				}
			}
		}

		// Token: 0x0600506F RID: 20591 RVA: 0x00098FBC File Offset: 0x000971BC
		private bool ShouldSerializeisSendApplication()
		{
			return this.isSendApplicationSpecified;
		}

		// Token: 0x06005070 RID: 20592 RVA: 0x00098FD4 File Offset: 0x000971D4
		private void ResetisSendApplication()
		{
			this.isSendApplicationSpecified = false;
		}

		// Token: 0x170018D8 RID: 6360
		// (get) Token: 0x06005071 RID: 20593 RVA: 0x00098FE0 File Offset: 0x000971E0
		// (set) Token: 0x06005072 RID: 20594 RVA: 0x0009900D File Offset: 0x0009720D
		[ProtoMember(7, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		// Token: 0x170018D9 RID: 6361
		// (get) Token: 0x06005073 RID: 20595 RVA: 0x0009901C File Offset: 0x0009721C
		// (set) Token: 0x06005074 RID: 20596 RVA: 0x0009903C File Offset: 0x0009723C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		// Token: 0x06005075 RID: 20597 RVA: 0x00099080 File Offset: 0x00097280
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06005076 RID: 20598 RVA: 0x00099098 File Offset: 0x00097298
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170018DA RID: 6362
		// (get) Token: 0x06005077 RID: 20599 RVA: 0x000990A4 File Offset: 0x000972A4
		// (set) Token: 0x06005078 RID: 20600 RVA: 0x000990D0 File Offset: 0x000972D0
		[ProtoMember(8, IsRequired = false, Name = "ppt", DataFormat = DataFormat.TwosComplement)]
		public int ppt
		{
			get
			{
				return this._ppt ?? 0;
			}
			set
			{
				this._ppt = new int?(value);
			}
		}

		// Token: 0x170018DB RID: 6363
		// (get) Token: 0x06005079 RID: 20601 RVA: 0x000990E0 File Offset: 0x000972E0
		// (set) Token: 0x0600507A RID: 20602 RVA: 0x00099100 File Offset: 0x00097300
		[XmlIgnore]
		[Browsable(false)]
		public bool pptSpecified
		{
			get
			{
				return this._ppt != null;
			}
			set
			{
				bool flag = value == (this._ppt == null);
				if (flag)
				{
					this._ppt = (value ? new int?(this.ppt) : null);
				}
			}
		}

		// Token: 0x0600507B RID: 20603 RVA: 0x00099144 File Offset: 0x00097344
		private bool ShouldSerializeppt()
		{
			return this.pptSpecified;
		}

		// Token: 0x0600507C RID: 20604 RVA: 0x0009915C File Offset: 0x0009735C
		private void Resetppt()
		{
			this.pptSpecified = false;
		}

		// Token: 0x170018DC RID: 6364
		// (get) Token: 0x0600507D RID: 20605 RVA: 0x00099168 File Offset: 0x00097368
		// (set) Token: 0x0600507E RID: 20606 RVA: 0x00099194 File Offset: 0x00097394
		[ProtoMember(9, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public int needapproval
		{
			get
			{
				return this._needapproval ?? 0;
			}
			set
			{
				this._needapproval = new int?(value);
			}
		}

		// Token: 0x170018DD RID: 6365
		// (get) Token: 0x0600507F RID: 20607 RVA: 0x000991A4 File Offset: 0x000973A4
		// (set) Token: 0x06005080 RID: 20608 RVA: 0x000991C4 File Offset: 0x000973C4
		[XmlIgnore]
		[Browsable(false)]
		public bool needapprovalSpecified
		{
			get
			{
				return this._needapproval != null;
			}
			set
			{
				bool flag = value == (this._needapproval == null);
				if (flag)
				{
					this._needapproval = (value ? new int?(this.needapproval) : null);
				}
			}
		}

		// Token: 0x06005081 RID: 20609 RVA: 0x00099208 File Offset: 0x00097408
		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		// Token: 0x06005082 RID: 20610 RVA: 0x00099220 File Offset: 0x00097420
		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		// Token: 0x170018DE RID: 6366
		// (get) Token: 0x06005083 RID: 20611 RVA: 0x0009922C File Offset: 0x0009742C
		// (set) Token: 0x06005084 RID: 20612 RVA: 0x00099258 File Offset: 0x00097458
		[ProtoMember(10, IsRequired = false, Name = "icon", DataFormat = DataFormat.TwosComplement)]
		public int icon
		{
			get
			{
				return this._icon ?? 0;
			}
			set
			{
				this._icon = new int?(value);
			}
		}

		// Token: 0x170018DF RID: 6367
		// (get) Token: 0x06005085 RID: 20613 RVA: 0x00099268 File Offset: 0x00097468
		// (set) Token: 0x06005086 RID: 20614 RVA: 0x00099288 File Offset: 0x00097488
		[XmlIgnore]
		[Browsable(false)]
		public bool iconSpecified
		{
			get
			{
				return this._icon != null;
			}
			set
			{
				bool flag = value == (this._icon == null);
				if (flag)
				{
					this._icon = (value ? new int?(this.icon) : null);
				}
			}
		}

		// Token: 0x06005087 RID: 20615 RVA: 0x000992CC File Offset: 0x000974CC
		private bool ShouldSerializeicon()
		{
			return this.iconSpecified;
		}

		// Token: 0x06005088 RID: 20616 RVA: 0x000992E4 File Offset: 0x000974E4
		private void Reseticon()
		{
			this.iconSpecified = false;
		}

		// Token: 0x170018E0 RID: 6368
		// (get) Token: 0x06005089 RID: 20617 RVA: 0x000992F0 File Offset: 0x000974F0
		// (set) Token: 0x0600508A RID: 20618 RVA: 0x0009931C File Offset: 0x0009751C
		[ProtoMember(11, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public int capacity
		{
			get
			{
				return this._capacity ?? 0;
			}
			set
			{
				this._capacity = new int?(value);
			}
		}

		// Token: 0x170018E1 RID: 6369
		// (get) Token: 0x0600508B RID: 20619 RVA: 0x0009932C File Offset: 0x0009752C
		// (set) Token: 0x0600508C RID: 20620 RVA: 0x0009934C File Offset: 0x0009754C
		[XmlIgnore]
		[Browsable(false)]
		public bool capacitySpecified
		{
			get
			{
				return this._capacity != null;
			}
			set
			{
				bool flag = value == (this._capacity == null);
				if (flag)
				{
					this._capacity = (value ? new int?(this.capacity) : null);
				}
			}
		}

		// Token: 0x0600508D RID: 20621 RVA: 0x00099390 File Offset: 0x00097590
		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		// Token: 0x0600508E RID: 20622 RVA: 0x000993A8 File Offset: 0x000975A8
		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		// Token: 0x170018E2 RID: 6370
		// (get) Token: 0x0600508F RID: 20623 RVA: 0x000993B4 File Offset: 0x000975B4
		// (set) Token: 0x06005090 RID: 20624 RVA: 0x000993D5 File Offset: 0x000975D5
		[ProtoMember(12, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		// Token: 0x170018E3 RID: 6371
		// (get) Token: 0x06005091 RID: 20625 RVA: 0x000993E0 File Offset: 0x000975E0
		// (set) Token: 0x06005092 RID: 20626 RVA: 0x000993FC File Offset: 0x000975FC
		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		// Token: 0x06005093 RID: 20627 RVA: 0x0009942C File Offset: 0x0009762C
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06005094 RID: 20628 RVA: 0x00099444 File Offset: 0x00097644
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x170018E4 RID: 6372
		// (get) Token: 0x06005095 RID: 20629 RVA: 0x00099450 File Offset: 0x00097650
		// (set) Token: 0x06005096 RID: 20630 RVA: 0x0009947C File Offset: 0x0009767C
		[ProtoMember(13, IsRequired = false, Name = "guildExp", DataFormat = DataFormat.TwosComplement)]
		public uint guildExp
		{
			get
			{
				return this._guildExp ?? 0U;
			}
			set
			{
				this._guildExp = new uint?(value);
			}
		}

		// Token: 0x170018E5 RID: 6373
		// (get) Token: 0x06005097 RID: 20631 RVA: 0x0009948C File Offset: 0x0009768C
		// (set) Token: 0x06005098 RID: 20632 RVA: 0x000994AC File Offset: 0x000976AC
		[XmlIgnore]
		[Browsable(false)]
		public bool guildExpSpecified
		{
			get
			{
				return this._guildExp != null;
			}
			set
			{
				bool flag = value == (this._guildExp == null);
				if (flag)
				{
					this._guildExp = (value ? new uint?(this.guildExp) : null);
				}
			}
		}

		// Token: 0x06005099 RID: 20633 RVA: 0x000994F0 File Offset: 0x000976F0
		private bool ShouldSerializeguildExp()
		{
			return this.guildExpSpecified;
		}

		// Token: 0x0600509A RID: 20634 RVA: 0x00099508 File Offset: 0x00097708
		private void ResetguildExp()
		{
			this.guildExpSpecified = false;
		}

		// Token: 0x170018E6 RID: 6374
		// (get) Token: 0x0600509B RID: 20635 RVA: 0x00099514 File Offset: 0x00097714
		// (set) Token: 0x0600509C RID: 20636 RVA: 0x00099540 File Offset: 0x00097740
		[ProtoMember(14, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170018E7 RID: 6375
		// (get) Token: 0x0600509D RID: 20637 RVA: 0x00099550 File Offset: 0x00097750
		// (set) Token: 0x0600509E RID: 20638 RVA: 0x00099570 File Offset: 0x00097770
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

		// Token: 0x0600509F RID: 20639 RVA: 0x000995B4 File Offset: 0x000977B4
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x000995CC File Offset: 0x000977CC
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x170018E8 RID: 6376
		// (get) Token: 0x060050A1 RID: 20641 RVA: 0x000995D8 File Offset: 0x000977D8
		// (set) Token: 0x060050A2 RID: 20642 RVA: 0x00099604 File Offset: 0x00097804
		[ProtoMember(15, IsRequired = false, Name = "prestige", DataFormat = DataFormat.TwosComplement)]
		public uint prestige
		{
			get
			{
				return this._prestige ?? 0U;
			}
			set
			{
				this._prestige = new uint?(value);
			}
		}

		// Token: 0x170018E9 RID: 6377
		// (get) Token: 0x060050A3 RID: 20643 RVA: 0x00099614 File Offset: 0x00097814
		// (set) Token: 0x060050A4 RID: 20644 RVA: 0x00099634 File Offset: 0x00097834
		[XmlIgnore]
		[Browsable(false)]
		public bool prestigeSpecified
		{
			get
			{
				return this._prestige != null;
			}
			set
			{
				bool flag = value == (this._prestige == null);
				if (flag)
				{
					this._prestige = (value ? new uint?(this.prestige) : null);
				}
			}
		}

		// Token: 0x060050A5 RID: 20645 RVA: 0x00099678 File Offset: 0x00097878
		private bool ShouldSerializeprestige()
		{
			return this.prestigeSpecified;
		}

		// Token: 0x060050A6 RID: 20646 RVA: 0x00099690 File Offset: 0x00097890
		private void Resetprestige()
		{
			this.prestigeSpecified = false;
		}

		// Token: 0x060050A7 RID: 20647 RVA: 0x0009969C File Offset: 0x0009789C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040013C2 RID: 5058
		private string _name;

		// Token: 0x040013C3 RID: 5059
		private ulong? _leaderID;

		// Token: 0x040013C4 RID: 5060
		private string _leaderName;

		// Token: 0x040013C5 RID: 5061
		private int? _level;

		// Token: 0x040013C6 RID: 5062
		private int? _memberCount;

		// Token: 0x040013C7 RID: 5063
		private bool? _isSendApplication;

		// Token: 0x040013C8 RID: 5064
		private ulong? _id;

		// Token: 0x040013C9 RID: 5065
		private int? _ppt;

		// Token: 0x040013CA RID: 5066
		private int? _needapproval;

		// Token: 0x040013CB RID: 5067
		private int? _icon;

		// Token: 0x040013CC RID: 5068
		private int? _capacity;

		// Token: 0x040013CD RID: 5069
		private string _annoucement;

		// Token: 0x040013CE RID: 5070
		private uint? _guildExp;

		// Token: 0x040013CF RID: 5071
		private uint? _titleID;

		// Token: 0x040013D0 RID: 5072
		private uint? _prestige;

		// Token: 0x040013D1 RID: 5073
		private IExtension extensionObject;
	}
}
