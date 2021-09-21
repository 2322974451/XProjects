using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017C RID: 380
	[ProtoContract(Name = "GetMyWatchRecordRes")]
	[Serializable]
	public class GetMyWatchRecordRes : IExtensible
	{
		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x0002E028 File Offset: 0x0002C228
		// (set) Token: 0x060016FE RID: 5886 RVA: 0x0002E054 File Offset: 0x0002C254
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x0002E064 File Offset: 0x0002C264
		// (set) Token: 0x06001700 RID: 5888 RVA: 0x0002E084 File Offset: 0x0002C284
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06001701 RID: 5889 RVA: 0x0002E0C8 File Offset: 0x0002C2C8
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001702 RID: 5890 RVA: 0x0002E0E0 File Offset: 0x0002C2E0
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001703 RID: 5891 RVA: 0x0002E0EC File Offset: 0x0002C2EC
		// (set) Token: 0x06001704 RID: 5892 RVA: 0x0002E118 File Offset: 0x0002C318
		[ProtoMember(2, IsRequired = false, Name = "myCommendedNum", DataFormat = DataFormat.TwosComplement)]
		public int myCommendedNum
		{
			get
			{
				return this._myCommendedNum ?? 0;
			}
			set
			{
				this._myCommendedNum = new int?(value);
			}
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001705 RID: 5893 RVA: 0x0002E128 File Offset: 0x0002C328
		// (set) Token: 0x06001706 RID: 5894 RVA: 0x0002E148 File Offset: 0x0002C348
		[XmlIgnore]
		[Browsable(false)]
		public bool myCommendedNumSpecified
		{
			get
			{
				return this._myCommendedNum != null;
			}
			set
			{
				bool flag = value == (this._myCommendedNum == null);
				if (flag)
				{
					this._myCommendedNum = (value ? new int?(this.myCommendedNum) : null);
				}
			}
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x0002E18C File Offset: 0x0002C38C
		private bool ShouldSerializemyCommendedNum()
		{
			return this.myCommendedNumSpecified;
		}

		// Token: 0x06001708 RID: 5896 RVA: 0x0002E1A4 File Offset: 0x0002C3A4
		private void ResetmyCommendedNum()
		{
			this.myCommendedNumSpecified = false;
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001709 RID: 5897 RVA: 0x0002E1B0 File Offset: 0x0002C3B0
		// (set) Token: 0x0600170A RID: 5898 RVA: 0x0002E1DC File Offset: 0x0002C3DC
		[ProtoMember(3, IsRequired = false, Name = "myWatchedNum", DataFormat = DataFormat.TwosComplement)]
		public int myWatchedNum
		{
			get
			{
				return this._myWatchedNum ?? 0;
			}
			set
			{
				this._myWatchedNum = new int?(value);
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x0600170B RID: 5899 RVA: 0x0002E1EC File Offset: 0x0002C3EC
		// (set) Token: 0x0600170C RID: 5900 RVA: 0x0002E20C File Offset: 0x0002C40C
		[XmlIgnore]
		[Browsable(false)]
		public bool myWatchedNumSpecified
		{
			get
			{
				return this._myWatchedNum != null;
			}
			set
			{
				bool flag = value == (this._myWatchedNum == null);
				if (flag)
				{
					this._myWatchedNum = (value ? new int?(this.myWatchedNum) : null);
				}
			}
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x0002E250 File Offset: 0x0002C450
		private bool ShouldSerializemyWatchedNum()
		{
			return this.myWatchedNumSpecified;
		}

		// Token: 0x0600170E RID: 5902 RVA: 0x0002E268 File Offset: 0x0002C468
		private void ResetmyWatchedNum()
		{
			this.myWatchedNumSpecified = false;
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x0600170F RID: 5903 RVA: 0x0002E274 File Offset: 0x0002C474
		// (set) Token: 0x06001710 RID: 5904 RVA: 0x0002E28C File Offset: 0x0002C48C
		[ProtoMember(4, IsRequired = false, Name = "myMostWatchedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo myMostWatchedRecord
		{
			get
			{
				return this._myMostWatchedRecord;
			}
			set
			{
				this._myMostWatchedRecord = value;
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06001711 RID: 5905 RVA: 0x0002E298 File Offset: 0x0002C498
		// (set) Token: 0x06001712 RID: 5906 RVA: 0x0002E2B0 File Offset: 0x0002C4B0
		[ProtoMember(5, IsRequired = false, Name = "myMostCommendedRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OneLiveRecordInfo myMostCommendedRecord
		{
			get
			{
				return this._myMostCommendedRecord;
			}
			set
			{
				this._myMostCommendedRecord = value;
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06001713 RID: 5907 RVA: 0x0002E2BC File Offset: 0x0002C4BC
		[ProtoMember(6, Name = "myRecentRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> myRecentRecords
		{
			get
			{
				return this._myRecentRecords;
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0002E2D4 File Offset: 0x0002C4D4
		// (set) Token: 0x06001715 RID: 5909 RVA: 0x0002E300 File Offset: 0x0002C500
		[ProtoMember(7, IsRequired = false, Name = "visibleSetting", DataFormat = DataFormat.Default)]
		public bool visibleSetting
		{
			get
			{
				return this._visibleSetting ?? false;
			}
			set
			{
				this._visibleSetting = new bool?(value);
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0002E310 File Offset: 0x0002C510
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x0002E330 File Offset: 0x0002C530
		[XmlIgnore]
		[Browsable(false)]
		public bool visibleSettingSpecified
		{
			get
			{
				return this._visibleSetting != null;
			}
			set
			{
				bool flag = value == (this._visibleSetting == null);
				if (flag)
				{
					this._visibleSetting = (value ? new bool?(this.visibleSetting) : null);
				}
			}
		}

		// Token: 0x06001718 RID: 5912 RVA: 0x0002E374 File Offset: 0x0002C574
		private bool ShouldSerializevisibleSetting()
		{
			return this.visibleSettingSpecified;
		}

		// Token: 0x06001719 RID: 5913 RVA: 0x0002E38C File Offset: 0x0002C58C
		private void ResetvisibleSetting()
		{
			this.visibleSettingSpecified = false;
		}

		// Token: 0x0600171A RID: 5914 RVA: 0x0002E398 File Offset: 0x0002C598
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005AF RID: 1455
		private ErrorCode? _error;

		// Token: 0x040005B0 RID: 1456
		private int? _myCommendedNum;

		// Token: 0x040005B1 RID: 1457
		private int? _myWatchedNum;

		// Token: 0x040005B2 RID: 1458
		private OneLiveRecordInfo _myMostWatchedRecord = null;

		// Token: 0x040005B3 RID: 1459
		private OneLiveRecordInfo _myMostCommendedRecord = null;

		// Token: 0x040005B4 RID: 1460
		private readonly List<OneLiveRecordInfo> _myRecentRecords = new List<OneLiveRecordInfo>();

		// Token: 0x040005B5 RID: 1461
		private bool? _visibleSetting;

		// Token: 0x040005B6 RID: 1462
		private IExtension extensionObject;
	}
}
