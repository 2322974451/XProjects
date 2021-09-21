using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000599 RID: 1433
	[ProtoContract(Name = "TeamBrief")]
	[Serializable]
	public class TeamBrief : IExtensible
	{
		// Token: 0x1700178C RID: 6028
		// (get) Token: 0x06004C79 RID: 19577 RVA: 0x0009178C File Offset: 0x0008F98C
		// (set) Token: 0x06004C7A RID: 19578 RVA: 0x000917B8 File Offset: 0x0008F9B8
		[ProtoMember(1, IsRequired = false, Name = "teamID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700178D RID: 6029
		// (get) Token: 0x06004C7B RID: 19579 RVA: 0x000917C8 File Offset: 0x0008F9C8
		// (set) Token: 0x06004C7C RID: 19580 RVA: 0x000917E8 File Offset: 0x0008F9E8
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

		// Token: 0x06004C7D RID: 19581 RVA: 0x0009182C File Offset: 0x0008FA2C
		private bool ShouldSerializeteamID()
		{
			return this.teamIDSpecified;
		}

		// Token: 0x06004C7E RID: 19582 RVA: 0x00091844 File Offset: 0x0008FA44
		private void ResetteamID()
		{
			this.teamIDSpecified = false;
		}

		// Token: 0x1700178E RID: 6030
		// (get) Token: 0x06004C7F RID: 19583 RVA: 0x00091850 File Offset: 0x0008FA50
		// (set) Token: 0x06004C80 RID: 19584 RVA: 0x0009187C File Offset: 0x0008FA7C
		[ProtoMember(2, IsRequired = false, Name = "teamMemberCount", DataFormat = DataFormat.TwosComplement)]
		public int teamMemberCount
		{
			get
			{
				return this._teamMemberCount ?? 0;
			}
			set
			{
				this._teamMemberCount = new int?(value);
			}
		}

		// Token: 0x1700178F RID: 6031
		// (get) Token: 0x06004C81 RID: 19585 RVA: 0x0009188C File Offset: 0x0008FA8C
		// (set) Token: 0x06004C82 RID: 19586 RVA: 0x000918AC File Offset: 0x0008FAAC
		[XmlIgnore]
		[Browsable(false)]
		public bool teamMemberCountSpecified
		{
			get
			{
				return this._teamMemberCount != null;
			}
			set
			{
				bool flag = value == (this._teamMemberCount == null);
				if (flag)
				{
					this._teamMemberCount = (value ? new int?(this.teamMemberCount) : null);
				}
			}
		}

		// Token: 0x06004C83 RID: 19587 RVA: 0x000918F0 File Offset: 0x0008FAF0
		private bool ShouldSerializeteamMemberCount()
		{
			return this.teamMemberCountSpecified;
		}

		// Token: 0x06004C84 RID: 19588 RVA: 0x00091908 File Offset: 0x0008FB08
		private void ResetteamMemberCount()
		{
			this.teamMemberCountSpecified = false;
		}

		// Token: 0x17001790 RID: 6032
		// (get) Token: 0x06004C85 RID: 19589 RVA: 0x00091914 File Offset: 0x0008FB14
		// (set) Token: 0x06004C86 RID: 19590 RVA: 0x00091940 File Offset: 0x0008FB40
		[ProtoMember(3, IsRequired = false, Name = "teamState", DataFormat = DataFormat.TwosComplement)]
		public int teamState
		{
			get
			{
				return this._teamState ?? 0;
			}
			set
			{
				this._teamState = new int?(value);
			}
		}

		// Token: 0x17001791 RID: 6033
		// (get) Token: 0x06004C87 RID: 19591 RVA: 0x00091950 File Offset: 0x0008FB50
		// (set) Token: 0x06004C88 RID: 19592 RVA: 0x00091970 File Offset: 0x0008FB70
		[XmlIgnore]
		[Browsable(false)]
		public bool teamStateSpecified
		{
			get
			{
				return this._teamState != null;
			}
			set
			{
				bool flag = value == (this._teamState == null);
				if (flag)
				{
					this._teamState = (value ? new int?(this.teamState) : null);
				}
			}
		}

		// Token: 0x06004C89 RID: 19593 RVA: 0x000919B4 File Offset: 0x0008FBB4
		private bool ShouldSerializeteamState()
		{
			return this.teamStateSpecified;
		}

		// Token: 0x06004C8A RID: 19594 RVA: 0x000919CC File Offset: 0x0008FBCC
		private void ResetteamState()
		{
			this.teamStateSpecified = false;
		}

		// Token: 0x17001792 RID: 6034
		// (get) Token: 0x06004C8B RID: 19595 RVA: 0x000919D8 File Offset: 0x0008FBD8
		// (set) Token: 0x06004C8C RID: 19596 RVA: 0x000919F9 File Offset: 0x0008FBF9
		[ProtoMember(4, IsRequired = false, Name = "leaderName", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001793 RID: 6035
		// (get) Token: 0x06004C8D RID: 19597 RVA: 0x00091A04 File Offset: 0x0008FC04
		// (set) Token: 0x06004C8E RID: 19598 RVA: 0x00091A20 File Offset: 0x0008FC20
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

		// Token: 0x06004C8F RID: 19599 RVA: 0x00091A50 File Offset: 0x0008FC50
		private bool ShouldSerializeleaderName()
		{
			return this.leaderNameSpecified;
		}

		// Token: 0x06004C90 RID: 19600 RVA: 0x00091A68 File Offset: 0x0008FC68
		private void ResetleaderName()
		{
			this.leaderNameSpecified = false;
		}

		// Token: 0x17001794 RID: 6036
		// (get) Token: 0x06004C91 RID: 19601 RVA: 0x00091A74 File Offset: 0x0008FC74
		// (set) Token: 0x06004C92 RID: 19602 RVA: 0x00091AA0 File Offset: 0x0008FCA0
		[ProtoMember(5, IsRequired = false, Name = "expID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001795 RID: 6037
		// (get) Token: 0x06004C93 RID: 19603 RVA: 0x00091AB0 File Offset: 0x0008FCB0
		// (set) Token: 0x06004C94 RID: 19604 RVA: 0x00091AD0 File Offset: 0x0008FCD0
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

		// Token: 0x06004C95 RID: 19605 RVA: 0x00091B14 File Offset: 0x0008FD14
		private bool ShouldSerializeexpID()
		{
			return this.expIDSpecified;
		}

		// Token: 0x06004C96 RID: 19606 RVA: 0x00091B2C File Offset: 0x0008FD2C
		private void ResetexpID()
		{
			this.expIDSpecified = false;
		}

		// Token: 0x17001796 RID: 6038
		// (get) Token: 0x06004C97 RID: 19607 RVA: 0x00091B38 File Offset: 0x0008FD38
		// (set) Token: 0x06004C98 RID: 19608 RVA: 0x00091B64 File Offset: 0x0008FD64
		[ProtoMember(6, IsRequired = false, Name = "haspassword", DataFormat = DataFormat.Default)]
		public bool haspassword
		{
			get
			{
				return this._haspassword ?? false;
			}
			set
			{
				this._haspassword = new bool?(value);
			}
		}

		// Token: 0x17001797 RID: 6039
		// (get) Token: 0x06004C99 RID: 19609 RVA: 0x00091B74 File Offset: 0x0008FD74
		// (set) Token: 0x06004C9A RID: 19610 RVA: 0x00091B94 File Offset: 0x0008FD94
		[XmlIgnore]
		[Browsable(false)]
		public bool haspasswordSpecified
		{
			get
			{
				return this._haspassword != null;
			}
			set
			{
				bool flag = value == (this._haspassword == null);
				if (flag)
				{
					this._haspassword = (value ? new bool?(this.haspassword) : null);
				}
			}
		}

		// Token: 0x06004C9B RID: 19611 RVA: 0x00091BD8 File Offset: 0x0008FDD8
		private bool ShouldSerializehaspassword()
		{
			return this.haspasswordSpecified;
		}

		// Token: 0x06004C9C RID: 19612 RVA: 0x00091BF0 File Offset: 0x0008FDF0
		private void Resethaspassword()
		{
			this.haspasswordSpecified = false;
		}

		// Token: 0x17001798 RID: 6040
		// (get) Token: 0x06004C9D RID: 19613 RVA: 0x00091BFC File Offset: 0x0008FDFC
		// (set) Token: 0x06004C9E RID: 19614 RVA: 0x00091C28 File Offset: 0x0008FE28
		[ProtoMember(7, IsRequired = false, Name = "leaderLevel", DataFormat = DataFormat.TwosComplement)]
		public uint leaderLevel
		{
			get
			{
				return this._leaderLevel ?? 0U;
			}
			set
			{
				this._leaderLevel = new uint?(value);
			}
		}

		// Token: 0x17001799 RID: 6041
		// (get) Token: 0x06004C9F RID: 19615 RVA: 0x00091C38 File Offset: 0x0008FE38
		// (set) Token: 0x06004CA0 RID: 19616 RVA: 0x00091C58 File Offset: 0x0008FE58
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderLevelSpecified
		{
			get
			{
				return this._leaderLevel != null;
			}
			set
			{
				bool flag = value == (this._leaderLevel == null);
				if (flag)
				{
					this._leaderLevel = (value ? new uint?(this.leaderLevel) : null);
				}
			}
		}

		// Token: 0x06004CA1 RID: 19617 RVA: 0x00091C9C File Offset: 0x0008FE9C
		private bool ShouldSerializeleaderLevel()
		{
			return this.leaderLevelSpecified;
		}

		// Token: 0x06004CA2 RID: 19618 RVA: 0x00091CB4 File Offset: 0x0008FEB4
		private void ResetleaderLevel()
		{
			this.leaderLevelSpecified = false;
		}

		// Token: 0x1700179A RID: 6042
		// (get) Token: 0x06004CA3 RID: 19619 RVA: 0x00091CC0 File Offset: 0x0008FEC0
		// (set) Token: 0x06004CA4 RID: 19620 RVA: 0x00091CEC File Offset: 0x0008FEEC
		[ProtoMember(8, IsRequired = false, Name = "leaderPowerPoint", DataFormat = DataFormat.TwosComplement)]
		public uint leaderPowerPoint
		{
			get
			{
				return this._leaderPowerPoint ?? 0U;
			}
			set
			{
				this._leaderPowerPoint = new uint?(value);
			}
		}

		// Token: 0x1700179B RID: 6043
		// (get) Token: 0x06004CA5 RID: 19621 RVA: 0x00091CFC File Offset: 0x0008FEFC
		// (set) Token: 0x06004CA6 RID: 19622 RVA: 0x00091D1C File Offset: 0x0008FF1C
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderPowerPointSpecified
		{
			get
			{
				return this._leaderPowerPoint != null;
			}
			set
			{
				bool flag = value == (this._leaderPowerPoint == null);
				if (flag)
				{
					this._leaderPowerPoint = (value ? new uint?(this.leaderPowerPoint) : null);
				}
			}
		}

		// Token: 0x06004CA7 RID: 19623 RVA: 0x00091D60 File Offset: 0x0008FF60
		private bool ShouldSerializeleaderPowerPoint()
		{
			return this.leaderPowerPointSpecified;
		}

		// Token: 0x06004CA8 RID: 19624 RVA: 0x00091D78 File Offset: 0x0008FF78
		private void ResetleaderPowerPoint()
		{
			this.leaderPowerPointSpecified = false;
		}

		// Token: 0x1700179C RID: 6044
		// (get) Token: 0x06004CA9 RID: 19625 RVA: 0x00091D84 File Offset: 0x0008FF84
		// (set) Token: 0x06004CAA RID: 19626 RVA: 0x00091DB0 File Offset: 0x0008FFB0
		[ProtoMember(9, IsRequired = false, Name = "leaderProfession", DataFormat = DataFormat.TwosComplement)]
		public RoleType leaderProfession
		{
			get
			{
				return this._leaderProfession ?? RoleType.Role_INVALID;
			}
			set
			{
				this._leaderProfession = new RoleType?(value);
			}
		}

		// Token: 0x1700179D RID: 6045
		// (get) Token: 0x06004CAB RID: 19627 RVA: 0x00091DC0 File Offset: 0x0008FFC0
		// (set) Token: 0x06004CAC RID: 19628 RVA: 0x00091DE0 File Offset: 0x0008FFE0
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderProfessionSpecified
		{
			get
			{
				return this._leaderProfession != null;
			}
			set
			{
				bool flag = value == (this._leaderProfession == null);
				if (flag)
				{
					this._leaderProfession = (value ? new RoleType?(this.leaderProfession) : null);
				}
			}
		}

		// Token: 0x06004CAD RID: 19629 RVA: 0x00091E24 File Offset: 0x00090024
		private bool ShouldSerializeleaderProfession()
		{
			return this.leaderProfessionSpecified;
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x00091E3C File Offset: 0x0009003C
		private void ResetleaderProfession()
		{
			this.leaderProfessionSpecified = false;
		}

		// Token: 0x1700179E RID: 6046
		// (get) Token: 0x06004CAF RID: 19631 RVA: 0x00091E48 File Offset: 0x00090048
		// (set) Token: 0x06004CB0 RID: 19632 RVA: 0x00091E60 File Offset: 0x00090060
		[ProtoMember(10, IsRequired = false, Name = "extrainfo", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700179F RID: 6047
		// (get) Token: 0x06004CB1 RID: 19633 RVA: 0x00091E6C File Offset: 0x0009006C
		// (set) Token: 0x06004CB2 RID: 19634 RVA: 0x00091E8D File Offset: 0x0009008D
		[ProtoMember(11, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
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

		// Token: 0x170017A0 RID: 6048
		// (get) Token: 0x06004CB3 RID: 19635 RVA: 0x00091E98 File Offset: 0x00090098
		// (set) Token: 0x06004CB4 RID: 19636 RVA: 0x00091EB4 File Offset: 0x000900B4
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

		// Token: 0x06004CB5 RID: 19637 RVA: 0x00091EE4 File Offset: 0x000900E4
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x06004CB6 RID: 19638 RVA: 0x00091EFC File Offset: 0x000900FC
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x170017A1 RID: 6049
		// (get) Token: 0x06004CB7 RID: 19639 RVA: 0x00091F08 File Offset: 0x00090108
		// (set) Token: 0x06004CB8 RID: 19640 RVA: 0x00091F34 File Offset: 0x00090134
		[ProtoMember(12, IsRequired = false, Name = "matchtype", DataFormat = DataFormat.TwosComplement)]
		public KMatchType matchtype
		{
			get
			{
				return this._matchtype ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._matchtype = new KMatchType?(value);
			}
		}

		// Token: 0x170017A2 RID: 6050
		// (get) Token: 0x06004CB9 RID: 19641 RVA: 0x00091F44 File Offset: 0x00090144
		// (set) Token: 0x06004CBA RID: 19642 RVA: 0x00091F64 File Offset: 0x00090164
		[XmlIgnore]
		[Browsable(false)]
		public bool matchtypeSpecified
		{
			get
			{
				return this._matchtype != null;
			}
			set
			{
				bool flag = value == (this._matchtype == null);
				if (flag)
				{
					this._matchtype = (value ? new KMatchType?(this.matchtype) : null);
				}
			}
		}

		// Token: 0x06004CBB RID: 19643 RVA: 0x00091FA8 File Offset: 0x000901A8
		private bool ShouldSerializematchtype()
		{
			return this.matchtypeSpecified;
		}

		// Token: 0x06004CBC RID: 19644 RVA: 0x00091FC0 File Offset: 0x000901C0
		private void Resetmatchtype()
		{
			this.matchtypeSpecified = false;
		}

		// Token: 0x170017A3 RID: 6051
		// (get) Token: 0x06004CBD RID: 19645 RVA: 0x00091FCC File Offset: 0x000901CC
		// (set) Token: 0x06004CBE RID: 19646 RVA: 0x00091FF8 File Offset: 0x000901F8
		[ProtoMember(13, IsRequired = false, Name = "kingback", DataFormat = DataFormat.Default)]
		public bool kingback
		{
			get
			{
				return this._kingback ?? false;
			}
			set
			{
				this._kingback = new bool?(value);
			}
		}

		// Token: 0x170017A4 RID: 6052
		// (get) Token: 0x06004CBF RID: 19647 RVA: 0x00092008 File Offset: 0x00090208
		// (set) Token: 0x06004CC0 RID: 19648 RVA: 0x00092028 File Offset: 0x00090228
		[XmlIgnore]
		[Browsable(false)]
		public bool kingbackSpecified
		{
			get
			{
				return this._kingback != null;
			}
			set
			{
				bool flag = value == (this._kingback == null);
				if (flag)
				{
					this._kingback = (value ? new bool?(this.kingback) : null);
				}
			}
		}

		// Token: 0x06004CC1 RID: 19649 RVA: 0x0009206C File Offset: 0x0009026C
		private bool ShouldSerializekingback()
		{
			return this.kingbackSpecified;
		}

		// Token: 0x06004CC2 RID: 19650 RVA: 0x00092084 File Offset: 0x00090284
		private void Resetkingback()
		{
			this.kingbackSpecified = false;
		}

		// Token: 0x06004CC3 RID: 19651 RVA: 0x00092090 File Offset: 0x00090290
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012F8 RID: 4856
		private int? _teamID;

		// Token: 0x040012F9 RID: 4857
		private int? _teamMemberCount;

		// Token: 0x040012FA RID: 4858
		private int? _teamState;

		// Token: 0x040012FB RID: 4859
		private string _leaderName;

		// Token: 0x040012FC RID: 4860
		private uint? _expID;

		// Token: 0x040012FD RID: 4861
		private bool? _haspassword;

		// Token: 0x040012FE RID: 4862
		private uint? _leaderLevel;

		// Token: 0x040012FF RID: 4863
		private uint? _leaderPowerPoint;

		// Token: 0x04001300 RID: 4864
		private RoleType? _leaderProfession;

		// Token: 0x04001301 RID: 4865
		private TeamExtraInfo _extrainfo = null;

		// Token: 0x04001302 RID: 4866
		private string _password;

		// Token: 0x04001303 RID: 4867
		private KMatchType? _matchtype;

		// Token: 0x04001304 RID: 4868
		private bool? _kingback;

		// Token: 0x04001305 RID: 4869
		private IExtension extensionObject;
	}
}
