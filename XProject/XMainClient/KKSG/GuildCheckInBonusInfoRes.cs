using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012D RID: 301
	[ProtoContract(Name = "GuildCheckInBonusInfoRes")]
	[Serializable]
	public class GuildCheckInBonusInfoRes : IExtensible
	{
		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x0600128B RID: 4747 RVA: 0x00025A14 File Offset: 0x00023C14
		// (set) Token: 0x0600128C RID: 4748 RVA: 0x00025A40 File Offset: 0x00023C40
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x0600128D RID: 4749 RVA: 0x00025A50 File Offset: 0x00023C50
		// (set) Token: 0x0600128E RID: 4750 RVA: 0x00025A70 File Offset: 0x00023C70
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x0600128F RID: 4751 RVA: 0x00025AB4 File Offset: 0x00023CB4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001290 RID: 4752 RVA: 0x00025ACC File Offset: 0x00023CCC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001291 RID: 4753 RVA: 0x00025AD8 File Offset: 0x00023CD8
		// (set) Token: 0x06001292 RID: 4754 RVA: 0x00025B04 File Offset: 0x00023D04
		[ProtoMember(2, IsRequired = false, Name = "isCheckedIn", DataFormat = DataFormat.Default)]
		public bool isCheckedIn
		{
			get
			{
				return this._isCheckedIn ?? false;
			}
			set
			{
				this._isCheckedIn = new bool?(value);
			}
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06001293 RID: 4755 RVA: 0x00025B14 File Offset: 0x00023D14
		// (set) Token: 0x06001294 RID: 4756 RVA: 0x00025B34 File Offset: 0x00023D34
		[XmlIgnore]
		[Browsable(false)]
		public bool isCheckedInSpecified
		{
			get
			{
				return this._isCheckedIn != null;
			}
			set
			{
				bool flag = value == (this._isCheckedIn == null);
				if (flag)
				{
					this._isCheckedIn = (value ? new bool?(this.isCheckedIn) : null);
				}
			}
		}

		// Token: 0x06001295 RID: 4757 RVA: 0x00025B78 File Offset: 0x00023D78
		private bool ShouldSerializeisCheckedIn()
		{
			return this.isCheckedInSpecified;
		}

		// Token: 0x06001296 RID: 4758 RVA: 0x00025B90 File Offset: 0x00023D90
		private void ResetisCheckedIn()
		{
			this.isCheckedInSpecified = false;
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06001297 RID: 4759 RVA: 0x00025B9C File Offset: 0x00023D9C
		// (set) Token: 0x06001298 RID: 4760 RVA: 0x00025BC8 File Offset: 0x00023DC8
		[ProtoMember(3, IsRequired = false, Name = "checkInNum", DataFormat = DataFormat.TwosComplement)]
		public int checkInNum
		{
			get
			{
				return this._checkInNum ?? 0;
			}
			set
			{
				this._checkInNum = new int?(value);
			}
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06001299 RID: 4761 RVA: 0x00025BD8 File Offset: 0x00023DD8
		// (set) Token: 0x0600129A RID: 4762 RVA: 0x00025BF8 File Offset: 0x00023DF8
		[XmlIgnore]
		[Browsable(false)]
		public bool checkInNumSpecified
		{
			get
			{
				return this._checkInNum != null;
			}
			set
			{
				bool flag = value == (this._checkInNum == null);
				if (flag)
				{
					this._checkInNum = (value ? new int?(this.checkInNum) : null);
				}
			}
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x00025C3C File Offset: 0x00023E3C
		private bool ShouldSerializecheckInNum()
		{
			return this.checkInNumSpecified;
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x00025C54 File Offset: 0x00023E54
		private void ResetcheckInNum()
		{
			this.checkInNumSpecified = false;
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x0600129D RID: 4765 RVA: 0x00025C60 File Offset: 0x00023E60
		// (set) Token: 0x0600129E RID: 4766 RVA: 0x00025C8C File Offset: 0x00023E8C
		[ProtoMember(4, IsRequired = false, Name = "onlineNum", DataFormat = DataFormat.TwosComplement)]
		public int onlineNum
		{
			get
			{
				return this._onlineNum ?? 0;
			}
			set
			{
				this._onlineNum = new int?(value);
			}
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x0600129F RID: 4767 RVA: 0x00025C9C File Offset: 0x00023E9C
		// (set) Token: 0x060012A0 RID: 4768 RVA: 0x00025CBC File Offset: 0x00023EBC
		[XmlIgnore]
		[Browsable(false)]
		public bool onlineNumSpecified
		{
			get
			{
				return this._onlineNum != null;
			}
			set
			{
				bool flag = value == (this._onlineNum == null);
				if (flag)
				{
					this._onlineNum = (value ? new int?(this.onlineNum) : null);
				}
			}
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x00025D00 File Offset: 0x00023F00
		private bool ShouldSerializeonlineNum()
		{
			return this.onlineNumSpecified;
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x00025D18 File Offset: 0x00023F18
		private void ResetonlineNum()
		{
			this.onlineNumSpecified = false;
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x060012A3 RID: 4771 RVA: 0x00025D24 File Offset: 0x00023F24
		// (set) Token: 0x060012A4 RID: 4772 RVA: 0x00025D50 File Offset: 0x00023F50
		[ProtoMember(5, IsRequired = false, Name = "guildMemberNum", DataFormat = DataFormat.TwosComplement)]
		public int guildMemberNum
		{
			get
			{
				return this._guildMemberNum ?? 0;
			}
			set
			{
				this._guildMemberNum = new int?(value);
			}
		}

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x060012A5 RID: 4773 RVA: 0x00025D60 File Offset: 0x00023F60
		// (set) Token: 0x060012A6 RID: 4774 RVA: 0x00025D80 File Offset: 0x00023F80
		[XmlIgnore]
		[Browsable(false)]
		public bool guildMemberNumSpecified
		{
			get
			{
				return this._guildMemberNum != null;
			}
			set
			{
				bool flag = value == (this._guildMemberNum == null);
				if (flag)
				{
					this._guildMemberNum = (value ? new int?(this.guildMemberNum) : null);
				}
			}
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x00025DC4 File Offset: 0x00023FC4
		private bool ShouldSerializeguildMemberNum()
		{
			return this.guildMemberNumSpecified;
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x00025DDC File Offset: 0x00023FDC
		private void ResetguildMemberNum()
		{
			this.guildMemberNumSpecified = false;
		}

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x060012A9 RID: 4777 RVA: 0x00025DE8 File Offset: 0x00023FE8
		[ProtoMember(6, Name = "checkInBonusInfo", DataFormat = DataFormat.Default)]
		public List<GuildBonusAppear> checkInBonusInfo
		{
			get
			{
				return this._checkInBonusInfo;
			}
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x00025E00 File Offset: 0x00024000
		// (set) Token: 0x060012AB RID: 4779 RVA: 0x00025E2C File Offset: 0x0002402C
		[ProtoMember(7, IsRequired = false, Name = "leftAskBonusTime", DataFormat = DataFormat.TwosComplement)]
		public int leftAskBonusTime
		{
			get
			{
				return this._leftAskBonusTime ?? 0;
			}
			set
			{
				this._leftAskBonusTime = new int?(value);
			}
		}

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x060012AC RID: 4780 RVA: 0x00025E3C File Offset: 0x0002403C
		// (set) Token: 0x060012AD RID: 4781 RVA: 0x00025E5C File Offset: 0x0002405C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftAskBonusTimeSpecified
		{
			get
			{
				return this._leftAskBonusTime != null;
			}
			set
			{
				bool flag = value == (this._leftAskBonusTime == null);
				if (flag)
				{
					this._leftAskBonusTime = (value ? new int?(this.leftAskBonusTime) : null);
				}
			}
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x00025EA0 File Offset: 0x000240A0
		private bool ShouldSerializeleftAskBonusTime()
		{
			return this.leftAskBonusTimeSpecified;
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x00025EB8 File Offset: 0x000240B8
		private void ResetleftAskBonusTime()
		{
			this.leftAskBonusTimeSpecified = false;
		}

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x060012B0 RID: 4784 RVA: 0x00025EC4 File Offset: 0x000240C4
		// (set) Token: 0x060012B1 RID: 4785 RVA: 0x00025EF0 File Offset: 0x000240F0
		[ProtoMember(8, IsRequired = false, Name = "timeofday", DataFormat = DataFormat.TwosComplement)]
		public int timeofday
		{
			get
			{
				return this._timeofday ?? 0;
			}
			set
			{
				this._timeofday = new int?(value);
			}
		}

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x00025F00 File Offset: 0x00024100
		// (set) Token: 0x060012B3 RID: 4787 RVA: 0x00025F20 File Offset: 0x00024120
		[XmlIgnore]
		[Browsable(false)]
		public bool timeofdaySpecified
		{
			get
			{
				return this._timeofday != null;
			}
			set
			{
				bool flag = value == (this._timeofday == null);
				if (flag)
				{
					this._timeofday = (value ? new int?(this.timeofday) : null);
				}
			}
		}

		// Token: 0x060012B4 RID: 4788 RVA: 0x00025F64 File Offset: 0x00024164
		private bool ShouldSerializetimeofday()
		{
			return this.timeofdaySpecified;
		}

		// Token: 0x060012B5 RID: 4789 RVA: 0x00025F7C File Offset: 0x0002417C
		private void Resettimeofday()
		{
			this.timeofdaySpecified = false;
		}

		// Token: 0x060012B6 RID: 4790 RVA: 0x00025F88 File Offset: 0x00024188
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004A2 RID: 1186
		private ErrorCode? _errorcode;

		// Token: 0x040004A3 RID: 1187
		private bool? _isCheckedIn;

		// Token: 0x040004A4 RID: 1188
		private int? _checkInNum;

		// Token: 0x040004A5 RID: 1189
		private int? _onlineNum;

		// Token: 0x040004A6 RID: 1190
		private int? _guildMemberNum;

		// Token: 0x040004A7 RID: 1191
		private readonly List<GuildBonusAppear> _checkInBonusInfo = new List<GuildBonusAppear>();

		// Token: 0x040004A8 RID: 1192
		private int? _leftAskBonusTime;

		// Token: 0x040004A9 RID: 1193
		private int? _timeofday;

		// Token: 0x040004AA RID: 1194
		private IExtension extensionObject;
	}
}
