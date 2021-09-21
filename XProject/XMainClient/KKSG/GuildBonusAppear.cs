using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005BC RID: 1468
	[ProtoContract(Name = "GuildBonusAppear")]
	[Serializable]
	public class GuildBonusAppear : IExtensible
	{
		// Token: 0x1700194C RID: 6476
		// (get) Token: 0x060051DB RID: 20955 RVA: 0x0009BAAC File Offset: 0x00099CAC
		// (set) Token: 0x060051DC RID: 20956 RVA: 0x0009BAD8 File Offset: 0x00099CD8
		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		// Token: 0x1700194D RID: 6477
		// (get) Token: 0x060051DD RID: 20957 RVA: 0x0009BAE8 File Offset: 0x00099CE8
		// (set) Token: 0x060051DE RID: 20958 RVA: 0x0009BB08 File Offset: 0x00099D08
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		// Token: 0x060051DF RID: 20959 RVA: 0x0009BB4C File Offset: 0x00099D4C
		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		// Token: 0x060051E0 RID: 20960 RVA: 0x0009BB64 File Offset: 0x00099D64
		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		// Token: 0x1700194E RID: 6478
		// (get) Token: 0x060051E1 RID: 20961 RVA: 0x0009BB70 File Offset: 0x00099D70
		// (set) Token: 0x060051E2 RID: 20962 RVA: 0x0009BB9C File Offset: 0x00099D9C
		[ProtoMember(2, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusType
		{
			get
			{
				return this._bonusType ?? 0U;
			}
			set
			{
				this._bonusType = new uint?(value);
			}
		}

		// Token: 0x1700194F RID: 6479
		// (get) Token: 0x060051E3 RID: 20963 RVA: 0x0009BBAC File Offset: 0x00099DAC
		// (set) Token: 0x060051E4 RID: 20964 RVA: 0x0009BBCC File Offset: 0x00099DCC
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusTypeSpecified
		{
			get
			{
				return this._bonusType != null;
			}
			set
			{
				bool flag = value == (this._bonusType == null);
				if (flag)
				{
					this._bonusType = (value ? new uint?(this.bonusType) : null);
				}
			}
		}

		// Token: 0x060051E5 RID: 20965 RVA: 0x0009BC10 File Offset: 0x00099E10
		private bool ShouldSerializebonusType()
		{
			return this.bonusTypeSpecified;
		}

		// Token: 0x060051E6 RID: 20966 RVA: 0x0009BC28 File Offset: 0x00099E28
		private void ResetbonusType()
		{
			this.bonusTypeSpecified = false;
		}

		// Token: 0x17001950 RID: 6480
		// (get) Token: 0x060051E7 RID: 20967 RVA: 0x0009BC34 File Offset: 0x00099E34
		// (set) Token: 0x060051E8 RID: 20968 RVA: 0x0009BC60 File Offset: 0x00099E60
		[ProtoMember(3, IsRequired = false, Name = "maxPeopleNum", DataFormat = DataFormat.TwosComplement)]
		public uint maxPeopleNum
		{
			get
			{
				return this._maxPeopleNum ?? 0U;
			}
			set
			{
				this._maxPeopleNum = new uint?(value);
			}
		}

		// Token: 0x17001951 RID: 6481
		// (get) Token: 0x060051E9 RID: 20969 RVA: 0x0009BC70 File Offset: 0x00099E70
		// (set) Token: 0x060051EA RID: 20970 RVA: 0x0009BC90 File Offset: 0x00099E90
		[XmlIgnore]
		[Browsable(false)]
		public bool maxPeopleNumSpecified
		{
			get
			{
				return this._maxPeopleNum != null;
			}
			set
			{
				bool flag = value == (this._maxPeopleNum == null);
				if (flag)
				{
					this._maxPeopleNum = (value ? new uint?(this.maxPeopleNum) : null);
				}
			}
		}

		// Token: 0x060051EB RID: 20971 RVA: 0x0009BCD4 File Offset: 0x00099ED4
		private bool ShouldSerializemaxPeopleNum()
		{
			return this.maxPeopleNumSpecified;
		}

		// Token: 0x060051EC RID: 20972 RVA: 0x0009BCEC File Offset: 0x00099EEC
		private void ResetmaxPeopleNum()
		{
			this.maxPeopleNumSpecified = false;
		}

		// Token: 0x17001952 RID: 6482
		// (get) Token: 0x060051ED RID: 20973 RVA: 0x0009BCF8 File Offset: 0x00099EF8
		// (set) Token: 0x060051EE RID: 20974 RVA: 0x0009BD24 File Offset: 0x00099F24
		[ProtoMember(4, IsRequired = false, Name = "bonusStatus", DataFormat = DataFormat.TwosComplement)]
		public uint bonusStatus
		{
			get
			{
				return this._bonusStatus ?? 0U;
			}
			set
			{
				this._bonusStatus = new uint?(value);
			}
		}

		// Token: 0x17001953 RID: 6483
		// (get) Token: 0x060051EF RID: 20975 RVA: 0x0009BD34 File Offset: 0x00099F34
		// (set) Token: 0x060051F0 RID: 20976 RVA: 0x0009BD54 File Offset: 0x00099F54
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusStatusSpecified
		{
			get
			{
				return this._bonusStatus != null;
			}
			set
			{
				bool flag = value == (this._bonusStatus == null);
				if (flag)
				{
					this._bonusStatus = (value ? new uint?(this.bonusStatus) : null);
				}
			}
		}

		// Token: 0x060051F1 RID: 20977 RVA: 0x0009BD98 File Offset: 0x00099F98
		private bool ShouldSerializebonusStatus()
		{
			return this.bonusStatusSpecified;
		}

		// Token: 0x060051F2 RID: 20978 RVA: 0x0009BDB0 File Offset: 0x00099FB0
		private void ResetbonusStatus()
		{
			this.bonusStatusSpecified = false;
		}

		// Token: 0x17001954 RID: 6484
		// (get) Token: 0x060051F3 RID: 20979 RVA: 0x0009BDBC File Offset: 0x00099FBC
		// (set) Token: 0x060051F4 RID: 20980 RVA: 0x0009BDE8 File Offset: 0x00099FE8
		[ProtoMember(5, IsRequired = false, Name = "leftOpenTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftOpenTime
		{
			get
			{
				return this._leftOpenTime ?? 0U;
			}
			set
			{
				this._leftOpenTime = new uint?(value);
			}
		}

		// Token: 0x17001955 RID: 6485
		// (get) Token: 0x060051F5 RID: 20981 RVA: 0x0009BDF8 File Offset: 0x00099FF8
		// (set) Token: 0x060051F6 RID: 20982 RVA: 0x0009BE18 File Offset: 0x0009A018
		[XmlIgnore]
		[Browsable(false)]
		public bool leftOpenTimeSpecified
		{
			get
			{
				return this._leftOpenTime != null;
			}
			set
			{
				bool flag = value == (this._leftOpenTime == null);
				if (flag)
				{
					this._leftOpenTime = (value ? new uint?(this.leftOpenTime) : null);
				}
			}
		}

		// Token: 0x060051F7 RID: 20983 RVA: 0x0009BE5C File Offset: 0x0009A05C
		private bool ShouldSerializeleftOpenTime()
		{
			return this.leftOpenTimeSpecified;
		}

		// Token: 0x060051F8 RID: 20984 RVA: 0x0009BE74 File Offset: 0x0009A074
		private void ResetleftOpenTime()
		{
			this.leftOpenTimeSpecified = false;
		}

		// Token: 0x17001956 RID: 6486
		// (get) Token: 0x060051F9 RID: 20985 RVA: 0x0009BE80 File Offset: 0x0009A080
		// (set) Token: 0x060051FA RID: 20986 RVA: 0x0009BEAC File Offset: 0x0009A0AC
		[ProtoMember(6, IsRequired = false, Name = "leftBringBackTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftBringBackTime
		{
			get
			{
				return this._leftBringBackTime ?? 0U;
			}
			set
			{
				this._leftBringBackTime = new uint?(value);
			}
		}

		// Token: 0x17001957 RID: 6487
		// (get) Token: 0x060051FB RID: 20987 RVA: 0x0009BEBC File Offset: 0x0009A0BC
		// (set) Token: 0x060051FC RID: 20988 RVA: 0x0009BEDC File Offset: 0x0009A0DC
		[XmlIgnore]
		[Browsable(false)]
		public bool leftBringBackTimeSpecified
		{
			get
			{
				return this._leftBringBackTime != null;
			}
			set
			{
				bool flag = value == (this._leftBringBackTime == null);
				if (flag)
				{
					this._leftBringBackTime = (value ? new uint?(this.leftBringBackTime) : null);
				}
			}
		}

		// Token: 0x060051FD RID: 20989 RVA: 0x0009BF20 File Offset: 0x0009A120
		private bool ShouldSerializeleftBringBackTime()
		{
			return this.leftBringBackTimeSpecified;
		}

		// Token: 0x060051FE RID: 20990 RVA: 0x0009BF38 File Offset: 0x0009A138
		private void ResetleftBringBackTime()
		{
			this.leftBringBackTimeSpecified = false;
		}

		// Token: 0x17001958 RID: 6488
		// (get) Token: 0x060051FF RID: 20991 RVA: 0x0009BF44 File Offset: 0x0009A144
		// (set) Token: 0x06005200 RID: 20992 RVA: 0x0009BF65 File Offset: 0x0009A165
		[ProtoMember(7, IsRequired = false, Name = "sourceName", DataFormat = DataFormat.Default)]
		public string sourceName
		{
			get
			{
				return this._sourceName ?? "";
			}
			set
			{
				this._sourceName = value;
			}
		}

		// Token: 0x17001959 RID: 6489
		// (get) Token: 0x06005201 RID: 20993 RVA: 0x0009BF70 File Offset: 0x0009A170
		// (set) Token: 0x06005202 RID: 20994 RVA: 0x0009BF8C File Offset: 0x0009A18C
		[XmlIgnore]
		[Browsable(false)]
		public bool sourceNameSpecified
		{
			get
			{
				return this._sourceName != null;
			}
			set
			{
				bool flag = value == (this._sourceName == null);
				if (flag)
				{
					this._sourceName = (value ? this.sourceName : null);
				}
			}
		}

		// Token: 0x06005203 RID: 20995 RVA: 0x0009BFBC File Offset: 0x0009A1BC
		private bool ShouldSerializesourceName()
		{
			return this.sourceNameSpecified;
		}

		// Token: 0x06005204 RID: 20996 RVA: 0x0009BFD4 File Offset: 0x0009A1D4
		private void ResetsourceName()
		{
			this.sourceNameSpecified = false;
		}

		// Token: 0x1700195A RID: 6490
		// (get) Token: 0x06005205 RID: 20997 RVA: 0x0009BFE0 File Offset: 0x0009A1E0
		// (set) Token: 0x06005206 RID: 20998 RVA: 0x0009C00C File Offset: 0x0009A20C
		[ProtoMember(8, IsRequired = false, Name = "alreadyGetPeopleNum", DataFormat = DataFormat.TwosComplement)]
		public uint alreadyGetPeopleNum
		{
			get
			{
				return this._alreadyGetPeopleNum ?? 0U;
			}
			set
			{
				this._alreadyGetPeopleNum = new uint?(value);
			}
		}

		// Token: 0x1700195B RID: 6491
		// (get) Token: 0x06005207 RID: 20999 RVA: 0x0009C01C File Offset: 0x0009A21C
		// (set) Token: 0x06005208 RID: 21000 RVA: 0x0009C03C File Offset: 0x0009A23C
		[XmlIgnore]
		[Browsable(false)]
		public bool alreadyGetPeopleNumSpecified
		{
			get
			{
				return this._alreadyGetPeopleNum != null;
			}
			set
			{
				bool flag = value == (this._alreadyGetPeopleNum == null);
				if (flag)
				{
					this._alreadyGetPeopleNum = (value ? new uint?(this.alreadyGetPeopleNum) : null);
				}
			}
		}

		// Token: 0x06005209 RID: 21001 RVA: 0x0009C080 File Offset: 0x0009A280
		private bool ShouldSerializealreadyGetPeopleNum()
		{
			return this.alreadyGetPeopleNumSpecified;
		}

		// Token: 0x0600520A RID: 21002 RVA: 0x0009C098 File Offset: 0x0009A298
		private void ResetalreadyGetPeopleNum()
		{
			this.alreadyGetPeopleNumSpecified = false;
		}

		// Token: 0x1700195C RID: 6492
		// (get) Token: 0x0600520B RID: 21003 RVA: 0x0009C0A4 File Offset: 0x0009A2A4
		// (set) Token: 0x0600520C RID: 21004 RVA: 0x0009C0D0 File Offset: 0x0009A2D0
		[ProtoMember(9, IsRequired = false, Name = "needCheckInNum", DataFormat = DataFormat.TwosComplement)]
		public uint needCheckInNum
		{
			get
			{
				return this._needCheckInNum ?? 0U;
			}
			set
			{
				this._needCheckInNum = new uint?(value);
			}
		}

		// Token: 0x1700195D RID: 6493
		// (get) Token: 0x0600520D RID: 21005 RVA: 0x0009C0E0 File Offset: 0x0009A2E0
		// (set) Token: 0x0600520E RID: 21006 RVA: 0x0009C100 File Offset: 0x0009A300
		[XmlIgnore]
		[Browsable(false)]
		public bool needCheckInNumSpecified
		{
			get
			{
				return this._needCheckInNum != null;
			}
			set
			{
				bool flag = value == (this._needCheckInNum == null);
				if (flag)
				{
					this._needCheckInNum = (value ? new uint?(this.needCheckInNum) : null);
				}
			}
		}

		// Token: 0x0600520F RID: 21007 RVA: 0x0009C144 File Offset: 0x0009A344
		private bool ShouldSerializeneedCheckInNum()
		{
			return this.needCheckInNumSpecified;
		}

		// Token: 0x06005210 RID: 21008 RVA: 0x0009C15C File Offset: 0x0009A35C
		private void ResetneedCheckInNum()
		{
			this.needCheckInNumSpecified = false;
		}

		// Token: 0x1700195E RID: 6494
		// (get) Token: 0x06005211 RID: 21009 RVA: 0x0009C168 File Offset: 0x0009A368
		// (set) Token: 0x06005212 RID: 21010 RVA: 0x0009C194 File Offset: 0x0009A394
		[ProtoMember(10, IsRequired = false, Name = "bonusContentType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusContentType
		{
			get
			{
				return this._bonusContentType ?? 0U;
			}
			set
			{
				this._bonusContentType = new uint?(value);
			}
		}

		// Token: 0x1700195F RID: 6495
		// (get) Token: 0x06005213 RID: 21011 RVA: 0x0009C1A4 File Offset: 0x0009A3A4
		// (set) Token: 0x06005214 RID: 21012 RVA: 0x0009C1C4 File Offset: 0x0009A3C4
		[XmlIgnore]
		[Browsable(false)]
		public bool bonusContentTypeSpecified
		{
			get
			{
				return this._bonusContentType != null;
			}
			set
			{
				bool flag = value == (this._bonusContentType == null);
				if (flag)
				{
					this._bonusContentType = (value ? new uint?(this.bonusContentType) : null);
				}
			}
		}

		// Token: 0x06005215 RID: 21013 RVA: 0x0009C208 File Offset: 0x0009A408
		private bool ShouldSerializebonusContentType()
		{
			return this.bonusContentTypeSpecified;
		}

		// Token: 0x06005216 RID: 21014 RVA: 0x0009C220 File Offset: 0x0009A420
		private void ResetbonusContentType()
		{
			this.bonusContentTypeSpecified = false;
		}

		// Token: 0x17001960 RID: 6496
		// (get) Token: 0x06005217 RID: 21015 RVA: 0x0009C22C File Offset: 0x0009A42C
		// (set) Token: 0x06005218 RID: 21016 RVA: 0x0009C259 File Offset: 0x0009A459
		[ProtoMember(11, IsRequired = false, Name = "sourceID", DataFormat = DataFormat.TwosComplement)]
		public ulong sourceID
		{
			get
			{
				return this._sourceID ?? 0UL;
			}
			set
			{
				this._sourceID = new ulong?(value);
			}
		}

		// Token: 0x17001961 RID: 6497
		// (get) Token: 0x06005219 RID: 21017 RVA: 0x0009C268 File Offset: 0x0009A468
		// (set) Token: 0x0600521A RID: 21018 RVA: 0x0009C288 File Offset: 0x0009A488
		[XmlIgnore]
		[Browsable(false)]
		public bool sourceIDSpecified
		{
			get
			{
				return this._sourceID != null;
			}
			set
			{
				bool flag = value == (this._sourceID == null);
				if (flag)
				{
					this._sourceID = (value ? new ulong?(this.sourceID) : null);
				}
			}
		}

		// Token: 0x0600521B RID: 21019 RVA: 0x0009C2CC File Offset: 0x0009A4CC
		private bool ShouldSerializesourceID()
		{
			return this.sourceIDSpecified;
		}

		// Token: 0x0600521C RID: 21020 RVA: 0x0009C2E4 File Offset: 0x0009A4E4
		private void ResetsourceID()
		{
			this.sourceIDSpecified = false;
		}

		// Token: 0x17001962 RID: 6498
		// (get) Token: 0x0600521D RID: 21021 RVA: 0x0009C2F0 File Offset: 0x0009A4F0
		// (set) Token: 0x0600521E RID: 21022 RVA: 0x0009C311 File Offset: 0x0009A511
		[ProtoMember(12, IsRequired = false, Name = "iconUrl", DataFormat = DataFormat.Default)]
		public string iconUrl
		{
			get
			{
				return this._iconUrl ?? "";
			}
			set
			{
				this._iconUrl = value;
			}
		}

		// Token: 0x17001963 RID: 6499
		// (get) Token: 0x0600521F RID: 21023 RVA: 0x0009C31C File Offset: 0x0009A51C
		// (set) Token: 0x06005220 RID: 21024 RVA: 0x0009C338 File Offset: 0x0009A538
		[XmlIgnore]
		[Browsable(false)]
		public bool iconUrlSpecified
		{
			get
			{
				return this._iconUrl != null;
			}
			set
			{
				bool flag = value == (this._iconUrl == null);
				if (flag)
				{
					this._iconUrl = (value ? this.iconUrl : null);
				}
			}
		}

		// Token: 0x06005221 RID: 21025 RVA: 0x0009C368 File Offset: 0x0009A568
		private bool ShouldSerializeiconUrl()
		{
			return this.iconUrlSpecified;
		}

		// Token: 0x06005222 RID: 21026 RVA: 0x0009C380 File Offset: 0x0009A580
		private void ReseticonUrl()
		{
			this.iconUrlSpecified = false;
		}

		// Token: 0x06005223 RID: 21027 RVA: 0x0009C38C File Offset: 0x0009A58C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001409 RID: 5129
		private uint? _bonusID;

		// Token: 0x0400140A RID: 5130
		private uint? _bonusType;

		// Token: 0x0400140B RID: 5131
		private uint? _maxPeopleNum;

		// Token: 0x0400140C RID: 5132
		private uint? _bonusStatus;

		// Token: 0x0400140D RID: 5133
		private uint? _leftOpenTime;

		// Token: 0x0400140E RID: 5134
		private uint? _leftBringBackTime;

		// Token: 0x0400140F RID: 5135
		private string _sourceName;

		// Token: 0x04001410 RID: 5136
		private uint? _alreadyGetPeopleNum;

		// Token: 0x04001411 RID: 5137
		private uint? _needCheckInNum;

		// Token: 0x04001412 RID: 5138
		private uint? _bonusContentType;

		// Token: 0x04001413 RID: 5139
		private ulong? _sourceID;

		// Token: 0x04001414 RID: 5140
		private string _iconUrl;

		// Token: 0x04001415 RID: 5141
		private IExtension extensionObject;
	}
}
