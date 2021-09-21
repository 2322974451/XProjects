using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000624 RID: 1572
	[ProtoContract(Name = "PayMemberRecord")]
	[Serializable]
	public class PayMemberRecord : IExtensible
	{
		// Token: 0x17001E46 RID: 7750
		// (get) Token: 0x0600603C RID: 24636 RVA: 0x000B7890 File Offset: 0x000B5A90
		// (set) Token: 0x0600603D RID: 24637 RVA: 0x000B78BC File Offset: 0x000B5ABC
		[ProtoMember(1, IsRequired = false, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public int ID
		{
			get
			{
				return this._ID ?? 0;
			}
			set
			{
				this._ID = new int?(value);
			}
		}

		// Token: 0x17001E47 RID: 7751
		// (get) Token: 0x0600603E RID: 24638 RVA: 0x000B78CC File Offset: 0x000B5ACC
		// (set) Token: 0x0600603F RID: 24639 RVA: 0x000B78EC File Offset: 0x000B5AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool IDSpecified
		{
			get
			{
				return this._ID != null;
			}
			set
			{
				bool flag = value == (this._ID == null);
				if (flag)
				{
					this._ID = (value ? new int?(this.ID) : null);
				}
			}
		}

		// Token: 0x06006040 RID: 24640 RVA: 0x000B7930 File Offset: 0x000B5B30
		private bool ShouldSerializeID()
		{
			return this.IDSpecified;
		}

		// Token: 0x06006041 RID: 24641 RVA: 0x000B7948 File Offset: 0x000B5B48
		private void ResetID()
		{
			this.IDSpecified = false;
		}

		// Token: 0x17001E48 RID: 7752
		// (get) Token: 0x06006042 RID: 24642 RVA: 0x000B7954 File Offset: 0x000B5B54
		// (set) Token: 0x06006043 RID: 24643 RVA: 0x000B7980 File Offset: 0x000B5B80
		[ProtoMember(2, IsRequired = false, Name = "ExpireTime", DataFormat = DataFormat.TwosComplement)]
		public int ExpireTime
		{
			get
			{
				return this._ExpireTime ?? 0;
			}
			set
			{
				this._ExpireTime = new int?(value);
			}
		}

		// Token: 0x17001E49 RID: 7753
		// (get) Token: 0x06006044 RID: 24644 RVA: 0x000B7990 File Offset: 0x000B5B90
		// (set) Token: 0x06006045 RID: 24645 RVA: 0x000B79B0 File Offset: 0x000B5BB0
		[XmlIgnore]
		[Browsable(false)]
		public bool ExpireTimeSpecified
		{
			get
			{
				return this._ExpireTime != null;
			}
			set
			{
				bool flag = value == (this._ExpireTime == null);
				if (flag)
				{
					this._ExpireTime = (value ? new int?(this.ExpireTime) : null);
				}
			}
		}

		// Token: 0x06006046 RID: 24646 RVA: 0x000B79F4 File Offset: 0x000B5BF4
		private bool ShouldSerializeExpireTime()
		{
			return this.ExpireTimeSpecified;
		}

		// Token: 0x06006047 RID: 24647 RVA: 0x000B7A0C File Offset: 0x000B5C0C
		private void ResetExpireTime()
		{
			this.ExpireTimeSpecified = false;
		}

		// Token: 0x17001E4A RID: 7754
		// (get) Token: 0x06006048 RID: 24648 RVA: 0x000B7A18 File Offset: 0x000B5C18
		// (set) Token: 0x06006049 RID: 24649 RVA: 0x000B7A44 File Offset: 0x000B5C44
		[ProtoMember(3, IsRequired = false, Name = "isClick", DataFormat = DataFormat.Default)]
		public bool isClick
		{
			get
			{
				return this._isClick ?? false;
			}
			set
			{
				this._isClick = new bool?(value);
			}
		}

		// Token: 0x17001E4B RID: 7755
		// (get) Token: 0x0600604A RID: 24650 RVA: 0x000B7A54 File Offset: 0x000B5C54
		// (set) Token: 0x0600604B RID: 24651 RVA: 0x000B7A74 File Offset: 0x000B5C74
		[XmlIgnore]
		[Browsable(false)]
		public bool isClickSpecified
		{
			get
			{
				return this._isClick != null;
			}
			set
			{
				bool flag = value == (this._isClick == null);
				if (flag)
				{
					this._isClick = (value ? new bool?(this.isClick) : null);
				}
			}
		}

		// Token: 0x0600604C RID: 24652 RVA: 0x000B7AB8 File Offset: 0x000B5CB8
		private bool ShouldSerializeisClick()
		{
			return this.isClickSpecified;
		}

		// Token: 0x0600604D RID: 24653 RVA: 0x000B7AD0 File Offset: 0x000B5CD0
		private void ResetisClick()
		{
			this.isClickSpecified = false;
		}

		// Token: 0x17001E4C RID: 7756
		// (get) Token: 0x0600604E RID: 24654 RVA: 0x000B7ADC File Offset: 0x000B5CDC
		// (set) Token: 0x0600604F RID: 24655 RVA: 0x000B7B08 File Offset: 0x000B5D08
		[ProtoMember(4, IsRequired = false, Name = "buttonStatus", DataFormat = DataFormat.TwosComplement)]
		public int buttonStatus
		{
			get
			{
				return this._buttonStatus ?? 0;
			}
			set
			{
				this._buttonStatus = new int?(value);
			}
		}

		// Token: 0x17001E4D RID: 7757
		// (get) Token: 0x06006050 RID: 24656 RVA: 0x000B7B18 File Offset: 0x000B5D18
		// (set) Token: 0x06006051 RID: 24657 RVA: 0x000B7B38 File Offset: 0x000B5D38
		[XmlIgnore]
		[Browsable(false)]
		public bool buttonStatusSpecified
		{
			get
			{
				return this._buttonStatus != null;
			}
			set
			{
				bool flag = value == (this._buttonStatus == null);
				if (flag)
				{
					this._buttonStatus = (value ? new int?(this.buttonStatus) : null);
				}
			}
		}

		// Token: 0x06006052 RID: 24658 RVA: 0x000B7B7C File Offset: 0x000B5D7C
		private bool ShouldSerializebuttonStatus()
		{
			return this.buttonStatusSpecified;
		}

		// Token: 0x06006053 RID: 24659 RVA: 0x000B7B94 File Offset: 0x000B5D94
		private void ResetbuttonStatus()
		{
			this.buttonStatusSpecified = false;
		}

		// Token: 0x17001E4E RID: 7758
		// (get) Token: 0x06006054 RID: 24660 RVA: 0x000B7BA0 File Offset: 0x000B5DA0
		// (set) Token: 0x06006055 RID: 24661 RVA: 0x000B7BCC File Offset: 0x000B5DCC
		[ProtoMember(5, IsRequired = false, Name = "lastDragonFlowerTime", DataFormat = DataFormat.TwosComplement)]
		public int lastDragonFlowerTime
		{
			get
			{
				return this._lastDragonFlowerTime ?? 0;
			}
			set
			{
				this._lastDragonFlowerTime = new int?(value);
			}
		}

		// Token: 0x17001E4F RID: 7759
		// (get) Token: 0x06006056 RID: 24662 RVA: 0x000B7BDC File Offset: 0x000B5DDC
		// (set) Token: 0x06006057 RID: 24663 RVA: 0x000B7BFC File Offset: 0x000B5DFC
		[XmlIgnore]
		[Browsable(false)]
		public bool lastDragonFlowerTimeSpecified
		{
			get
			{
				return this._lastDragonFlowerTime != null;
			}
			set
			{
				bool flag = value == (this._lastDragonFlowerTime == null);
				if (flag)
				{
					this._lastDragonFlowerTime = (value ? new int?(this.lastDragonFlowerTime) : null);
				}
			}
		}

		// Token: 0x06006058 RID: 24664 RVA: 0x000B7C40 File Offset: 0x000B5E40
		private bool ShouldSerializelastDragonFlowerTime()
		{
			return this.lastDragonFlowerTimeSpecified;
		}

		// Token: 0x06006059 RID: 24665 RVA: 0x000B7C58 File Offset: 0x000B5E58
		private void ResetlastDragonFlowerTime()
		{
			this.lastDragonFlowerTimeSpecified = false;
		}

		// Token: 0x17001E50 RID: 7760
		// (get) Token: 0x0600605A RID: 24666 RVA: 0x000B7C64 File Offset: 0x000B5E64
		// (set) Token: 0x0600605B RID: 24667 RVA: 0x000B7C90 File Offset: 0x000B5E90
		[ProtoMember(6, IsRequired = false, Name = "isNotifyExpire", DataFormat = DataFormat.Default)]
		public bool isNotifyExpire
		{
			get
			{
				return this._isNotifyExpire ?? false;
			}
			set
			{
				this._isNotifyExpire = new bool?(value);
			}
		}

		// Token: 0x17001E51 RID: 7761
		// (get) Token: 0x0600605C RID: 24668 RVA: 0x000B7CA0 File Offset: 0x000B5EA0
		// (set) Token: 0x0600605D RID: 24669 RVA: 0x000B7CC0 File Offset: 0x000B5EC0
		[XmlIgnore]
		[Browsable(false)]
		public bool isNotifyExpireSpecified
		{
			get
			{
				return this._isNotifyExpire != null;
			}
			set
			{
				bool flag = value == (this._isNotifyExpire == null);
				if (flag)
				{
					this._isNotifyExpire = (value ? new bool?(this.isNotifyExpire) : null);
				}
			}
		}

		// Token: 0x0600605E RID: 24670 RVA: 0x000B7D04 File Offset: 0x000B5F04
		private bool ShouldSerializeisNotifyExpire()
		{
			return this.isNotifyExpireSpecified;
		}

		// Token: 0x0600605F RID: 24671 RVA: 0x000B7D1C File Offset: 0x000B5F1C
		private void ResetisNotifyExpire()
		{
			this.isNotifyExpireSpecified = false;
		}

		// Token: 0x17001E52 RID: 7762
		// (get) Token: 0x06006060 RID: 24672 RVA: 0x000B7D28 File Offset: 0x000B5F28
		// (set) Token: 0x06006061 RID: 24673 RVA: 0x000B7D54 File Offset: 0x000B5F54
		[ProtoMember(7, IsRequired = false, Name = "begintime", DataFormat = DataFormat.TwosComplement)]
		public int begintime
		{
			get
			{
				return this._begintime ?? 0;
			}
			set
			{
				this._begintime = new int?(value);
			}
		}

		// Token: 0x17001E53 RID: 7763
		// (get) Token: 0x06006062 RID: 24674 RVA: 0x000B7D64 File Offset: 0x000B5F64
		// (set) Token: 0x06006063 RID: 24675 RVA: 0x000B7D84 File Offset: 0x000B5F84
		[XmlIgnore]
		[Browsable(false)]
		public bool begintimeSpecified
		{
			get
			{
				return this._begintime != null;
			}
			set
			{
				bool flag = value == (this._begintime == null);
				if (flag)
				{
					this._begintime = (value ? new int?(this.begintime) : null);
				}
			}
		}

		// Token: 0x06006064 RID: 24676 RVA: 0x000B7DC8 File Offset: 0x000B5FC8
		private bool ShouldSerializebegintime()
		{
			return this.begintimeSpecified;
		}

		// Token: 0x06006065 RID: 24677 RVA: 0x000B7DE0 File Offset: 0x000B5FE0
		private void Resetbegintime()
		{
			this.begintimeSpecified = false;
		}

		// Token: 0x17001E54 RID: 7764
		// (get) Token: 0x06006066 RID: 24678 RVA: 0x000B7DEC File Offset: 0x000B5FEC
		// (set) Token: 0x06006067 RID: 24679 RVA: 0x000B7E18 File Offset: 0x000B6018
		[ProtoMember(8, IsRequired = false, Name = "isNotifyExpireSoon", DataFormat = DataFormat.Default)]
		public bool isNotifyExpireSoon
		{
			get
			{
				return this._isNotifyExpireSoon ?? false;
			}
			set
			{
				this._isNotifyExpireSoon = new bool?(value);
			}
		}

		// Token: 0x17001E55 RID: 7765
		// (get) Token: 0x06006068 RID: 24680 RVA: 0x000B7E28 File Offset: 0x000B6028
		// (set) Token: 0x06006069 RID: 24681 RVA: 0x000B7E48 File Offset: 0x000B6048
		[XmlIgnore]
		[Browsable(false)]
		public bool isNotifyExpireSoonSpecified
		{
			get
			{
				return this._isNotifyExpireSoon != null;
			}
			set
			{
				bool flag = value == (this._isNotifyExpireSoon == null);
				if (flag)
				{
					this._isNotifyExpireSoon = (value ? new bool?(this.isNotifyExpireSoon) : null);
				}
			}
		}

		// Token: 0x0600606A RID: 24682 RVA: 0x000B7E8C File Offset: 0x000B608C
		private bool ShouldSerializeisNotifyExpireSoon()
		{
			return this.isNotifyExpireSoonSpecified;
		}

		// Token: 0x0600606B RID: 24683 RVA: 0x000B7EA4 File Offset: 0x000B60A4
		private void ResetisNotifyExpireSoon()
		{
			this.isNotifyExpireSoonSpecified = false;
		}

		// Token: 0x0600606C RID: 24684 RVA: 0x000B7EB0 File Offset: 0x000B60B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001760 RID: 5984
		private int? _ID;

		// Token: 0x04001761 RID: 5985
		private int? _ExpireTime;

		// Token: 0x04001762 RID: 5986
		private bool? _isClick;

		// Token: 0x04001763 RID: 5987
		private int? _buttonStatus;

		// Token: 0x04001764 RID: 5988
		private int? _lastDragonFlowerTime;

		// Token: 0x04001765 RID: 5989
		private bool? _isNotifyExpire;

		// Token: 0x04001766 RID: 5990
		private int? _begintime;

		// Token: 0x04001767 RID: 5991
		private bool? _isNotifyExpireSoon;

		// Token: 0x04001768 RID: 5992
		private IExtension extensionObject;
	}
}
