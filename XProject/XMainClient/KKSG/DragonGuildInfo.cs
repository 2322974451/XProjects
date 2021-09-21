using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072E RID: 1838
	[ProtoContract(Name = "DragonGuildInfo")]
	[Serializable]
	public class DragonGuildInfo : IExtensible
	{
		// Token: 0x17002835 RID: 10293
		// (get) Token: 0x06007ED0 RID: 32464 RVA: 0x000F27D0 File Offset: 0x000F09D0
		// (set) Token: 0x06007ED1 RID: 32465 RVA: 0x000F27F1 File Offset: 0x000F09F1
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

		// Token: 0x17002836 RID: 10294
		// (get) Token: 0x06007ED2 RID: 32466 RVA: 0x000F27FC File Offset: 0x000F09FC
		// (set) Token: 0x06007ED3 RID: 32467 RVA: 0x000F2818 File Offset: 0x000F0A18
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

		// Token: 0x06007ED4 RID: 32468 RVA: 0x000F2848 File Offset: 0x000F0A48
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007ED5 RID: 32469 RVA: 0x000F2860 File Offset: 0x000F0A60
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002837 RID: 10295
		// (get) Token: 0x06007ED6 RID: 32470 RVA: 0x000F286C File Offset: 0x000F0A6C
		// (set) Token: 0x06007ED7 RID: 32471 RVA: 0x000F2899 File Offset: 0x000F0A99
		[ProtoMember(2, IsRequired = false, Name = "leaderId", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderId
		{
			get
			{
				return this._leaderId ?? 0UL;
			}
			set
			{
				this._leaderId = new ulong?(value);
			}
		}

		// Token: 0x17002838 RID: 10296
		// (get) Token: 0x06007ED8 RID: 32472 RVA: 0x000F28A8 File Offset: 0x000F0AA8
		// (set) Token: 0x06007ED9 RID: 32473 RVA: 0x000F28C8 File Offset: 0x000F0AC8
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderIdSpecified
		{
			get
			{
				return this._leaderId != null;
			}
			set
			{
				bool flag = value == (this._leaderId == null);
				if (flag)
				{
					this._leaderId = (value ? new ulong?(this.leaderId) : null);
				}
			}
		}

		// Token: 0x06007EDA RID: 32474 RVA: 0x000F290C File Offset: 0x000F0B0C
		private bool ShouldSerializeleaderId()
		{
			return this.leaderIdSpecified;
		}

		// Token: 0x06007EDB RID: 32475 RVA: 0x000F2924 File Offset: 0x000F0B24
		private void ResetleaderId()
		{
			this.leaderIdSpecified = false;
		}

		// Token: 0x17002839 RID: 10297
		// (get) Token: 0x06007EDC RID: 32476 RVA: 0x000F2930 File Offset: 0x000F0B30
		// (set) Token: 0x06007EDD RID: 32477 RVA: 0x000F2951 File Offset: 0x000F0B51
		[ProtoMember(3, IsRequired = false, Name = "leadername", DataFormat = DataFormat.Default)]
		public string leadername
		{
			get
			{
				return this._leadername ?? "";
			}
			set
			{
				this._leadername = value;
			}
		}

		// Token: 0x1700283A RID: 10298
		// (get) Token: 0x06007EDE RID: 32478 RVA: 0x000F295C File Offset: 0x000F0B5C
		// (set) Token: 0x06007EDF RID: 32479 RVA: 0x000F2978 File Offset: 0x000F0B78
		[XmlIgnore]
		[Browsable(false)]
		public bool leadernameSpecified
		{
			get
			{
				return this._leadername != null;
			}
			set
			{
				bool flag = value == (this._leadername == null);
				if (flag)
				{
					this._leadername = (value ? this.leadername : null);
				}
			}
		}

		// Token: 0x06007EE0 RID: 32480 RVA: 0x000F29A8 File Offset: 0x000F0BA8
		private bool ShouldSerializeleadername()
		{
			return this.leadernameSpecified;
		}

		// Token: 0x06007EE1 RID: 32481 RVA: 0x000F29C0 File Offset: 0x000F0BC0
		private void Resetleadername()
		{
			this.leadernameSpecified = false;
		}

		// Token: 0x1700283B RID: 10299
		// (get) Token: 0x06007EE2 RID: 32482 RVA: 0x000F29CC File Offset: 0x000F0BCC
		// (set) Token: 0x06007EE3 RID: 32483 RVA: 0x000F29F8 File Offset: 0x000F0BF8
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700283C RID: 10300
		// (get) Token: 0x06007EE4 RID: 32484 RVA: 0x000F2A08 File Offset: 0x000F0C08
		// (set) Token: 0x06007EE5 RID: 32485 RVA: 0x000F2A28 File Offset: 0x000F0C28
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

		// Token: 0x06007EE6 RID: 32486 RVA: 0x000F2A6C File Offset: 0x000F0C6C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06007EE7 RID: 32487 RVA: 0x000F2A84 File Offset: 0x000F0C84
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x1700283D RID: 10301
		// (get) Token: 0x06007EE8 RID: 32488 RVA: 0x000F2A90 File Offset: 0x000F0C90
		// (set) Token: 0x06007EE9 RID: 32489 RVA: 0x000F2ABC File Offset: 0x000F0CBC
		[ProtoMember(5, IsRequired = false, Name = "membercounts", DataFormat = DataFormat.TwosComplement)]
		public uint membercounts
		{
			get
			{
				return this._membercounts ?? 0U;
			}
			set
			{
				this._membercounts = new uint?(value);
			}
		}

		// Token: 0x1700283E RID: 10302
		// (get) Token: 0x06007EEA RID: 32490 RVA: 0x000F2ACC File Offset: 0x000F0CCC
		// (set) Token: 0x06007EEB RID: 32491 RVA: 0x000F2AEC File Offset: 0x000F0CEC
		[XmlIgnore]
		[Browsable(false)]
		public bool membercountsSpecified
		{
			get
			{
				return this._membercounts != null;
			}
			set
			{
				bool flag = value == (this._membercounts == null);
				if (flag)
				{
					this._membercounts = (value ? new uint?(this.membercounts) : null);
				}
			}
		}

		// Token: 0x06007EEC RID: 32492 RVA: 0x000F2B30 File Offset: 0x000F0D30
		private bool ShouldSerializemembercounts()
		{
			return this.membercountsSpecified;
		}

		// Token: 0x06007EED RID: 32493 RVA: 0x000F2B48 File Offset: 0x000F0D48
		private void Resetmembercounts()
		{
			this.membercountsSpecified = false;
		}

		// Token: 0x1700283F RID: 10303
		// (get) Token: 0x06007EEE RID: 32494 RVA: 0x000F2B54 File Offset: 0x000F0D54
		// (set) Token: 0x06007EEF RID: 32495 RVA: 0x000F2B80 File Offset: 0x000F0D80
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

		// Token: 0x17002840 RID: 10304
		// (get) Token: 0x06007EF0 RID: 32496 RVA: 0x000F2B90 File Offset: 0x000F0D90
		// (set) Token: 0x06007EF1 RID: 32497 RVA: 0x000F2BB0 File Offset: 0x000F0DB0
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

		// Token: 0x06007EF2 RID: 32498 RVA: 0x000F2BF4 File Offset: 0x000F0DF4
		private bool ShouldSerializeisSendApplication()
		{
			return this.isSendApplicationSpecified;
		}

		// Token: 0x06007EF3 RID: 32499 RVA: 0x000F2C0C File Offset: 0x000F0E0C
		private void ResetisSendApplication()
		{
			this.isSendApplicationSpecified = false;
		}

		// Token: 0x17002841 RID: 10305
		// (get) Token: 0x06007EF4 RID: 32500 RVA: 0x000F2C18 File Offset: 0x000F0E18
		// (set) Token: 0x06007EF5 RID: 32501 RVA: 0x000F2C45 File Offset: 0x000F0E45
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

		// Token: 0x17002842 RID: 10306
		// (get) Token: 0x06007EF6 RID: 32502 RVA: 0x000F2C54 File Offset: 0x000F0E54
		// (set) Token: 0x06007EF7 RID: 32503 RVA: 0x000F2C74 File Offset: 0x000F0E74
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

		// Token: 0x06007EF8 RID: 32504 RVA: 0x000F2CB8 File Offset: 0x000F0EB8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06007EF9 RID: 32505 RVA: 0x000F2CD0 File Offset: 0x000F0ED0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17002843 RID: 10307
		// (get) Token: 0x06007EFA RID: 32506 RVA: 0x000F2CDC File Offset: 0x000F0EDC
		// (set) Token: 0x06007EFB RID: 32507 RVA: 0x000F2D08 File Offset: 0x000F0F08
		[ProtoMember(8, IsRequired = false, Name = "recruitppt", DataFormat = DataFormat.TwosComplement)]
		public uint recruitppt
		{
			get
			{
				return this._recruitppt ?? 0U;
			}
			set
			{
				this._recruitppt = new uint?(value);
			}
		}

		// Token: 0x17002844 RID: 10308
		// (get) Token: 0x06007EFC RID: 32508 RVA: 0x000F2D18 File Offset: 0x000F0F18
		// (set) Token: 0x06007EFD RID: 32509 RVA: 0x000F2D38 File Offset: 0x000F0F38
		[XmlIgnore]
		[Browsable(false)]
		public bool recruitpptSpecified
		{
			get
			{
				return this._recruitppt != null;
			}
			set
			{
				bool flag = value == (this._recruitppt == null);
				if (flag)
				{
					this._recruitppt = (value ? new uint?(this.recruitppt) : null);
				}
			}
		}

		// Token: 0x06007EFE RID: 32510 RVA: 0x000F2D7C File Offset: 0x000F0F7C
		private bool ShouldSerializerecruitppt()
		{
			return this.recruitpptSpecified;
		}

		// Token: 0x06007EFF RID: 32511 RVA: 0x000F2D94 File Offset: 0x000F0F94
		private void Resetrecruitppt()
		{
			this.recruitpptSpecified = false;
		}

		// Token: 0x17002845 RID: 10309
		// (get) Token: 0x06007F00 RID: 32512 RVA: 0x000F2DA0 File Offset: 0x000F0FA0
		// (set) Token: 0x06007F01 RID: 32513 RVA: 0x000F2DCC File Offset: 0x000F0FCC
		[ProtoMember(9, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.Default)]
		public bool needapproval
		{
			get
			{
				return this._needapproval ?? false;
			}
			set
			{
				this._needapproval = new bool?(value);
			}
		}

		// Token: 0x17002846 RID: 10310
		// (get) Token: 0x06007F02 RID: 32514 RVA: 0x000F2DDC File Offset: 0x000F0FDC
		// (set) Token: 0x06007F03 RID: 32515 RVA: 0x000F2DFC File Offset: 0x000F0FFC
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
					this._needapproval = (value ? new bool?(this.needapproval) : null);
				}
			}
		}

		// Token: 0x06007F04 RID: 32516 RVA: 0x000F2E40 File Offset: 0x000F1040
		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		// Token: 0x06007F05 RID: 32517 RVA: 0x000F2E58 File Offset: 0x000F1058
		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		// Token: 0x17002847 RID: 10311
		// (get) Token: 0x06007F06 RID: 32518 RVA: 0x000F2E64 File Offset: 0x000F1064
		// (set) Token: 0x06007F07 RID: 32519 RVA: 0x000F2E90 File Offset: 0x000F1090
		[ProtoMember(10, IsRequired = false, Name = "capacity", DataFormat = DataFormat.TwosComplement)]
		public uint capacity
		{
			get
			{
				return this._capacity ?? 0U;
			}
			set
			{
				this._capacity = new uint?(value);
			}
		}

		// Token: 0x17002848 RID: 10312
		// (get) Token: 0x06007F08 RID: 32520 RVA: 0x000F2EA0 File Offset: 0x000F10A0
		// (set) Token: 0x06007F09 RID: 32521 RVA: 0x000F2EC0 File Offset: 0x000F10C0
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
					this._capacity = (value ? new uint?(this.capacity) : null);
				}
			}
		}

		// Token: 0x06007F0A RID: 32522 RVA: 0x000F2F04 File Offset: 0x000F1104
		private bool ShouldSerializecapacity()
		{
			return this.capacitySpecified;
		}

		// Token: 0x06007F0B RID: 32523 RVA: 0x000F2F1C File Offset: 0x000F111C
		private void Resetcapacity()
		{
			this.capacitySpecified = false;
		}

		// Token: 0x17002849 RID: 10313
		// (get) Token: 0x06007F0C RID: 32524 RVA: 0x000F2F28 File Offset: 0x000F1128
		// (set) Token: 0x06007F0D RID: 32525 RVA: 0x000F2F49 File Offset: 0x000F1149
		[ProtoMember(11, IsRequired = false, Name = "announcement", DataFormat = DataFormat.Default)]
		public string announcement
		{
			get
			{
				return this._announcement ?? "";
			}
			set
			{
				this._announcement = value;
			}
		}

		// Token: 0x1700284A RID: 10314
		// (get) Token: 0x06007F0E RID: 32526 RVA: 0x000F2F54 File Offset: 0x000F1154
		// (set) Token: 0x06007F0F RID: 32527 RVA: 0x000F2F70 File Offset: 0x000F1170
		[XmlIgnore]
		[Browsable(false)]
		public bool announcementSpecified
		{
			get
			{
				return this._announcement != null;
			}
			set
			{
				bool flag = value == (this._announcement == null);
				if (flag)
				{
					this._announcement = (value ? this.announcement : null);
				}
			}
		}

		// Token: 0x06007F10 RID: 32528 RVA: 0x000F2FA0 File Offset: 0x000F11A0
		private bool ShouldSerializeannouncement()
		{
			return this.announcementSpecified;
		}

		// Token: 0x06007F11 RID: 32529 RVA: 0x000F2FB8 File Offset: 0x000F11B8
		private void Resetannouncement()
		{
			this.announcementSpecified = false;
		}

		// Token: 0x1700284B RID: 10315
		// (get) Token: 0x06007F12 RID: 32530 RVA: 0x000F2FC4 File Offset: 0x000F11C4
		// (set) Token: 0x06007F13 RID: 32531 RVA: 0x000F2FF0 File Offset: 0x000F11F0
		[ProtoMember(12, IsRequired = false, Name = "guildExp", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700284C RID: 10316
		// (get) Token: 0x06007F14 RID: 32532 RVA: 0x000F3000 File Offset: 0x000F1200
		// (set) Token: 0x06007F15 RID: 32533 RVA: 0x000F3020 File Offset: 0x000F1220
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

		// Token: 0x06007F16 RID: 32534 RVA: 0x000F3064 File Offset: 0x000F1264
		private bool ShouldSerializeguildExp()
		{
			return this.guildExpSpecified;
		}

		// Token: 0x06007F17 RID: 32535 RVA: 0x000F307C File Offset: 0x000F127C
		private void ResetguildExp()
		{
			this.guildExpSpecified = false;
		}

		// Token: 0x1700284D RID: 10317
		// (get) Token: 0x06007F18 RID: 32536 RVA: 0x000F3088 File Offset: 0x000F1288
		// (set) Token: 0x06007F19 RID: 32537 RVA: 0x000F30B5 File Offset: 0x000F12B5
		[ProtoMember(13, IsRequired = false, Name = "totalPPT", DataFormat = DataFormat.TwosComplement)]
		public ulong totalPPT
		{
			get
			{
				return this._totalPPT ?? 0UL;
			}
			set
			{
				this._totalPPT = new ulong?(value);
			}
		}

		// Token: 0x1700284E RID: 10318
		// (get) Token: 0x06007F1A RID: 32538 RVA: 0x000F30C4 File Offset: 0x000F12C4
		// (set) Token: 0x06007F1B RID: 32539 RVA: 0x000F30E4 File Offset: 0x000F12E4
		[XmlIgnore]
		[Browsable(false)]
		public bool totalPPTSpecified
		{
			get
			{
				return this._totalPPT != null;
			}
			set
			{
				bool flag = value == (this._totalPPT == null);
				if (flag)
				{
					this._totalPPT = (value ? new ulong?(this.totalPPT) : null);
				}
			}
		}

		// Token: 0x06007F1C RID: 32540 RVA: 0x000F3128 File Offset: 0x000F1328
		private bool ShouldSerializetotalPPT()
		{
			return this.totalPPTSpecified;
		}

		// Token: 0x06007F1D RID: 32541 RVA: 0x000F3140 File Offset: 0x000F1340
		private void ResettotalPPT()
		{
			this.totalPPTSpecified = false;
		}

		// Token: 0x1700284F RID: 10319
		// (get) Token: 0x06007F1E RID: 32542 RVA: 0x000F314C File Offset: 0x000F134C
		// (set) Token: 0x06007F1F RID: 32543 RVA: 0x000F3178 File Offset: 0x000F1378
		[ProtoMember(14, IsRequired = false, Name = "sceneId", DataFormat = DataFormat.TwosComplement)]
		public uint sceneId
		{
			get
			{
				return this._sceneId ?? 0U;
			}
			set
			{
				this._sceneId = new uint?(value);
			}
		}

		// Token: 0x17002850 RID: 10320
		// (get) Token: 0x06007F20 RID: 32544 RVA: 0x000F3188 File Offset: 0x000F1388
		// (set) Token: 0x06007F21 RID: 32545 RVA: 0x000F31A8 File Offset: 0x000F13A8
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneIdSpecified
		{
			get
			{
				return this._sceneId != null;
			}
			set
			{
				bool flag = value == (this._sceneId == null);
				if (flag)
				{
					this._sceneId = (value ? new uint?(this.sceneId) : null);
				}
			}
		}

		// Token: 0x06007F22 RID: 32546 RVA: 0x000F31EC File Offset: 0x000F13EC
		private bool ShouldSerializesceneId()
		{
			return this.sceneIdSpecified;
		}

		// Token: 0x06007F23 RID: 32547 RVA: 0x000F3204 File Offset: 0x000F1404
		private void ResetsceneId()
		{
			this.sceneIdSpecified = false;
		}

		// Token: 0x17002851 RID: 10321
		// (get) Token: 0x06007F24 RID: 32548 RVA: 0x000F3210 File Offset: 0x000F1410
		// (set) Token: 0x06007F25 RID: 32549 RVA: 0x000F323C File Offset: 0x000F143C
		[ProtoMember(15, IsRequired = false, Name = "sceneCnt", DataFormat = DataFormat.TwosComplement)]
		public uint sceneCnt
		{
			get
			{
				return this._sceneCnt ?? 0U;
			}
			set
			{
				this._sceneCnt = new uint?(value);
			}
		}

		// Token: 0x17002852 RID: 10322
		// (get) Token: 0x06007F26 RID: 32550 RVA: 0x000F324C File Offset: 0x000F144C
		// (set) Token: 0x06007F27 RID: 32551 RVA: 0x000F326C File Offset: 0x000F146C
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneCntSpecified
		{
			get
			{
				return this._sceneCnt != null;
			}
			set
			{
				bool flag = value == (this._sceneCnt == null);
				if (flag)
				{
					this._sceneCnt = (value ? new uint?(this.sceneCnt) : null);
				}
			}
		}

		// Token: 0x06007F28 RID: 32552 RVA: 0x000F32B0 File Offset: 0x000F14B0
		private bool ShouldSerializesceneCnt()
		{
			return this.sceneCntSpecified;
		}

		// Token: 0x06007F29 RID: 32553 RVA: 0x000F32C8 File Offset: 0x000F14C8
		private void ResetsceneCnt()
		{
			this.sceneCntSpecified = false;
		}

		// Token: 0x06007F2A RID: 32554 RVA: 0x000F32D4 File Offset: 0x000F14D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DC8 RID: 7624
		private string _name;

		// Token: 0x04001DC9 RID: 7625
		private ulong? _leaderId;

		// Token: 0x04001DCA RID: 7626
		private string _leadername;

		// Token: 0x04001DCB RID: 7627
		private uint? _level;

		// Token: 0x04001DCC RID: 7628
		private uint? _membercounts;

		// Token: 0x04001DCD RID: 7629
		private bool? _isSendApplication;

		// Token: 0x04001DCE RID: 7630
		private ulong? _id;

		// Token: 0x04001DCF RID: 7631
		private uint? _recruitppt;

		// Token: 0x04001DD0 RID: 7632
		private bool? _needapproval;

		// Token: 0x04001DD1 RID: 7633
		private uint? _capacity;

		// Token: 0x04001DD2 RID: 7634
		private string _announcement;

		// Token: 0x04001DD3 RID: 7635
		private uint? _guildExp;

		// Token: 0x04001DD4 RID: 7636
		private ulong? _totalPPT;

		// Token: 0x04001DD5 RID: 7637
		private uint? _sceneId;

		// Token: 0x04001DD6 RID: 7638
		private uint? _sceneCnt;

		// Token: 0x04001DD7 RID: 7639
		private IExtension extensionObject;
	}
}
