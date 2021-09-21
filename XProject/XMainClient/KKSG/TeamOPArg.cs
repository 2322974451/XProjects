using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200005F RID: 95
	[ProtoContract(Name = "TeamOPArg")]
	[Serializable]
	public class TeamOPArg : IExtensible
	{
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0000E890 File Offset: 0x0000CA90
		// (set) Token: 0x06000633 RID: 1587 RVA: 0x0000E8BC File Offset: 0x0000CABC
		[ProtoMember(1, IsRequired = false, Name = "request", DataFormat = DataFormat.TwosComplement)]
		public TeamOperate request
		{
			get
			{
				return this._request ?? TeamOperate.TEAM_CREATE;
			}
			set
			{
				this._request = new TeamOperate?(value);
			}
		}

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x0000E8CC File Offset: 0x0000CACC
		// (set) Token: 0x06000635 RID: 1589 RVA: 0x0000E8EC File Offset: 0x0000CAEC
		[XmlIgnore]
		[Browsable(false)]
		public bool requestSpecified
		{
			get
			{
				return this._request != null;
			}
			set
			{
				bool flag = value == (this._request == null);
				if (flag)
				{
					this._request = (value ? new TeamOperate?(this.request) : null);
				}
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0000E930 File Offset: 0x0000CB30
		private bool ShouldSerializerequest()
		{
			return this.requestSpecified;
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0000E948 File Offset: 0x0000CB48
		private void Resetrequest()
		{
			this.requestSpecified = false;
		}

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0000E954 File Offset: 0x0000CB54
		// (set) Token: 0x06000639 RID: 1593 RVA: 0x0000E980 File Offset: 0x0000CB80
		[ProtoMember(2, IsRequired = false, Name = "teamID", DataFormat = DataFormat.TwosComplement)]
		public int teamID
		{
			get
			{
				return this._teamID ?? 0;
			}
			set
			{
				this._teamID = new int?(value);
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0000E990 File Offset: 0x0000CB90
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x0000E9B0 File Offset: 0x0000CBB0
		[XmlIgnore]
		[Browsable(false)]
		public bool teamIDSpecified
		{
			get
			{
				return this._teamID != null;
			}
			set
			{
				bool flag = value == (this._teamID == null);
				if (flag)
				{
					this._teamID = (value ? new int?(this.teamID) : null);
				}
			}
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0000E9F4 File Offset: 0x0000CBF4
		private bool ShouldSerializeteamID()
		{
			return this.teamIDSpecified;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0000EA0C File Offset: 0x0000CC0C
		private void ResetteamID()
		{
			this.teamIDSpecified = false;
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000EA18 File Offset: 0x0000CC18
		// (set) Token: 0x0600063F RID: 1599 RVA: 0x0000EA39 File Offset: 0x0000CC39
		[ProtoMember(3, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000EA44 File Offset: 0x0000CC44
		// (set) Token: 0x06000641 RID: 1601 RVA: 0x0000EA60 File Offset: 0x0000CC60
		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0000EA90 File Offset: 0x0000CC90
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0000EAA8 File Offset: 0x0000CCA8
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0000EAB4 File Offset: 0x0000CCB4
		// (set) Token: 0x06000645 RID: 1605 RVA: 0x0000EAE0 File Offset: 0x0000CCE0
		[ProtoMember(4, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
		public uint expID
		{
			get
			{
				return this._expID ?? 0U;
			}
			set
			{
				this._expID = new uint?(value);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x0000EAF0 File Offset: 0x0000CCF0
		// (set) Token: 0x06000647 RID: 1607 RVA: 0x0000EB10 File Offset: 0x0000CD10
		[XmlIgnore]
		[Browsable(false)]
		public bool expIDSpecified
		{
			get
			{
				return this._expID != null;
			}
			set
			{
				bool flag = value == (this._expID == null);
				if (flag)
				{
					this._expID = (value ? new uint?(this.expID) : null);
				}
			}
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0000EB54 File Offset: 0x0000CD54
		private bool ShouldSerializeexpID()
		{
			return this.expIDSpecified;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0000EB6C File Offset: 0x0000CD6C
		private void ResetexpID()
		{
			this.expIDSpecified = false;
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x0000EB78 File Offset: 0x0000CD78
		// (set) Token: 0x0600064B RID: 1611 RVA: 0x0000EBA5 File Offset: 0x0000CDA5
		[ProtoMember(5, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x0000EBD4 File Offset: 0x0000CDD4
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

		// Token: 0x0600064E RID: 1614 RVA: 0x0000EC18 File Offset: 0x0000CE18
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0000EC30 File Offset: 0x0000CE30
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x0000EC3C File Offset: 0x0000CE3C
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x0000EC54 File Offset: 0x0000CE54
		[ProtoMember(6, IsRequired = false, Name = "extrainfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamExtraInfo extrainfo
		{
			get
			{
				return this._extrainfo;
			}
			set
			{
				this._extrainfo = value;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x0000EC60 File Offset: 0x0000CE60
		// (set) Token: 0x06000653 RID: 1619 RVA: 0x0000EC8D File Offset: 0x0000CE8D
		[ProtoMember(7, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public ulong param
		{
			get
			{
				return this._param ?? 0UL;
			}
			set
			{
				this._param = new ulong?(value);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x0000EC9C File Offset: 0x0000CE9C
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x0000ECBC File Offset: 0x0000CEBC
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new ulong?(this.param) : null);
				}
			}
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0000ED00 File Offset: 0x0000CF00
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0000ED18 File Offset: 0x0000CF18
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x0000ED24 File Offset: 0x0000CF24
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x0000ED50 File Offset: 0x0000CF50
		[ProtoMember(8, IsRequired = false, Name = "membertype", DataFormat = DataFormat.TwosComplement)]
		public TeamMemberType membertype
		{
			get
			{
				return this._membertype ?? TeamMemberType.TMT_NORMAL;
			}
			set
			{
				this._membertype = new TeamMemberType?(value);
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x0000ED60 File Offset: 0x0000CF60
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x0000ED80 File Offset: 0x0000CF80
		[XmlIgnore]
		[Browsable(false)]
		public bool membertypeSpecified
		{
			get
			{
				return this._membertype != null;
			}
			set
			{
				bool flag = value == (this._membertype == null);
				if (flag)
				{
					this._membertype = (value ? new TeamMemberType?(this.membertype) : null);
				}
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		private bool ShouldSerializemembertype()
		{
			return this.membertypeSpecified;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000EDDC File Offset: 0x0000CFDC
		private void Resetmembertype()
		{
			this.membertypeSpecified = false;
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0000EDE8 File Offset: 0x0000CFE8
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x0000EE09 File Offset: 0x0000D009
		[ProtoMember(9, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x0000EE14 File Offset: 0x0000D014
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x0000EE30 File Offset: 0x0000D030
		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x0000EE60 File Offset: 0x0000D060
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0000EE78 File Offset: 0x0000D078
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000EE84 File Offset: 0x0000D084
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x0000EEB0 File Offset: 0x0000D0B0
		[ProtoMember(10, IsRequired = false, Name = "isplatfriend", DataFormat = DataFormat.Default)]
		public bool isplatfriend
		{
			get
			{
				return this._isplatfriend ?? false;
			}
			set
			{
				this._isplatfriend = new bool?(value);
			}
		}

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0000EEC0 File Offset: 0x0000D0C0
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
		[XmlIgnore]
		[Browsable(false)]
		public bool isplatfriendSpecified
		{
			get
			{
				return this._isplatfriend != null;
			}
			set
			{
				bool flag = value == (this._isplatfriend == null);
				if (flag)
				{
					this._isplatfriend = (value ? new bool?(this.isplatfriend) : null);
				}
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0000EF24 File Offset: 0x0000D124
		private bool ShouldSerializeisplatfriend()
		{
			return this.isplatfriendSpecified;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0000EF3C File Offset: 0x0000D13C
		private void Resetisplatfriend()
		{
			this.isplatfriendSpecified = false;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0000EF48 File Offset: 0x0000D148
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000195 RID: 405
		private TeamOperate? _request;

		// Token: 0x04000196 RID: 406
		private int? _teamID;

		// Token: 0x04000197 RID: 407
		private string _password;

		// Token: 0x04000198 RID: 408
		private uint? _expID;

		// Token: 0x04000199 RID: 409
		private ulong? _roleid;

		// Token: 0x0400019A RID: 410
		private TeamExtraInfo _extrainfo = null;

		// Token: 0x0400019B RID: 411
		private ulong? _param;

		// Token: 0x0400019C RID: 412
		private TeamMemberType? _membertype;

		// Token: 0x0400019D RID: 413
		private string _account;

		// Token: 0x0400019E RID: 414
		private bool? _isplatfriend;

		// Token: 0x0400019F RID: 415
		private IExtension extensionObject;
	}
}
