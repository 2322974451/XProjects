using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000671 RID: 1649
	[ProtoContract(Name = "TajieHelpSceneData")]
	[Serializable]
	public class TajieHelpSceneData : IExtensible
	{
		// Token: 0x1700212F RID: 8495
		// (get) Token: 0x060068F0 RID: 26864 RVA: 0x000C89A8 File Offset: 0x000C6BA8
		// (set) Token: 0x060068F1 RID: 26865 RVA: 0x000C89D4 File Offset: 0x000C6BD4
		[ProtoMember(1, IsRequired = false, Name = "sceneID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17002130 RID: 8496
		// (get) Token: 0x060068F2 RID: 26866 RVA: 0x000C89E4 File Offset: 0x000C6BE4
		// (set) Token: 0x060068F3 RID: 26867 RVA: 0x000C8A04 File Offset: 0x000C6C04
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

		// Token: 0x060068F4 RID: 26868 RVA: 0x000C8A48 File Offset: 0x000C6C48
		private bool ShouldSerializesceneID()
		{
			return this.sceneIDSpecified;
		}

		// Token: 0x060068F5 RID: 26869 RVA: 0x000C8A60 File Offset: 0x000C6C60
		private void ResetsceneID()
		{
			this.sceneIDSpecified = false;
		}

		// Token: 0x17002131 RID: 8497
		// (get) Token: 0x060068F6 RID: 26870 RVA: 0x000C8A6C File Offset: 0x000C6C6C
		// (set) Token: 0x060068F7 RID: 26871 RVA: 0x000C8A98 File Offset: 0x000C6C98
		[ProtoMember(2, IsRequired = false, Name = "intervalContinueFailTimes", DataFormat = DataFormat.TwosComplement)]
		public int intervalContinueFailTimes
		{
			get
			{
				return this._intervalContinueFailTimes ?? 0;
			}
			set
			{
				this._intervalContinueFailTimes = new int?(value);
			}
		}

		// Token: 0x17002132 RID: 8498
		// (get) Token: 0x060068F8 RID: 26872 RVA: 0x000C8AA8 File Offset: 0x000C6CA8
		// (set) Token: 0x060068F9 RID: 26873 RVA: 0x000C8AC8 File Offset: 0x000C6CC8
		[XmlIgnore]
		[Browsable(false)]
		public bool intervalContinueFailTimesSpecified
		{
			get
			{
				return this._intervalContinueFailTimes != null;
			}
			set
			{
				bool flag = value == (this._intervalContinueFailTimes == null);
				if (flag)
				{
					this._intervalContinueFailTimes = (value ? new int?(this.intervalContinueFailTimes) : null);
				}
			}
		}

		// Token: 0x060068FA RID: 26874 RVA: 0x000C8B0C File Offset: 0x000C6D0C
		private bool ShouldSerializeintervalContinueFailTimes()
		{
			return this.intervalContinueFailTimesSpecified;
		}

		// Token: 0x060068FB RID: 26875 RVA: 0x000C8B24 File Offset: 0x000C6D24
		private void ResetintervalContinueFailTimes()
		{
			this.intervalContinueFailTimesSpecified = false;
		}

		// Token: 0x17002133 RID: 8499
		// (get) Token: 0x060068FC RID: 26876 RVA: 0x000C8B30 File Offset: 0x000C6D30
		// (set) Token: 0x060068FD RID: 26877 RVA: 0x000C8B5C File Offset: 0x000C6D5C
		[ProtoMember(3, IsRequired = false, Name = "intervalFailNoticeTimes", DataFormat = DataFormat.TwosComplement)]
		public int intervalFailNoticeTimes
		{
			get
			{
				return this._intervalFailNoticeTimes ?? 0;
			}
			set
			{
				this._intervalFailNoticeTimes = new int?(value);
			}
		}

		// Token: 0x17002134 RID: 8500
		// (get) Token: 0x060068FE RID: 26878 RVA: 0x000C8B6C File Offset: 0x000C6D6C
		// (set) Token: 0x060068FF RID: 26879 RVA: 0x000C8B8C File Offset: 0x000C6D8C
		[XmlIgnore]
		[Browsable(false)]
		public bool intervalFailNoticeTimesSpecified
		{
			get
			{
				return this._intervalFailNoticeTimes != null;
			}
			set
			{
				bool flag = value == (this._intervalFailNoticeTimes == null);
				if (flag)
				{
					this._intervalFailNoticeTimes = (value ? new int?(this.intervalFailNoticeTimes) : null);
				}
			}
		}

		// Token: 0x06006900 RID: 26880 RVA: 0x000C8BD0 File Offset: 0x000C6DD0
		private bool ShouldSerializeintervalFailNoticeTimes()
		{
			return this.intervalFailNoticeTimesSpecified;
		}

		// Token: 0x06006901 RID: 26881 RVA: 0x000C8BE8 File Offset: 0x000C6DE8
		private void ResetintervalFailNoticeTimes()
		{
			this.intervalFailNoticeTimesSpecified = false;
		}

		// Token: 0x06006902 RID: 26882 RVA: 0x000C8BF4 File Offset: 0x000C6DF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001950 RID: 6480
		private int? _sceneID;

		// Token: 0x04001951 RID: 6481
		private int? _intervalContinueFailTimes;

		// Token: 0x04001952 RID: 6482
		private int? _intervalFailNoticeTimes;

		// Token: 0x04001953 RID: 6483
		private IExtension extensionObject;
	}
}
