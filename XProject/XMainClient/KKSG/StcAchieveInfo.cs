using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E7 RID: 1511
	[ProtoContract(Name = "StcAchieveInfo")]
	[Serializable]
	public class StcAchieveInfo : IExtensible
	{
		// Token: 0x17001B5E RID: 7006
		// (get) Token: 0x06005814 RID: 22548 RVA: 0x000A7C94 File Offset: 0x000A5E94
		// (set) Token: 0x06005815 RID: 22549 RVA: 0x000A7CC0 File Offset: 0x000A5EC0
		[ProtoMember(1, IsRequired = false, Name = "achieveID", DataFormat = DataFormat.TwosComplement)]
		public uint achieveID
		{
			get
			{
				return this._achieveID ?? 0U;
			}
			set
			{
				this._achieveID = new uint?(value);
			}
		}

		// Token: 0x17001B5F RID: 7007
		// (get) Token: 0x06005816 RID: 22550 RVA: 0x000A7CD0 File Offset: 0x000A5ED0
		// (set) Token: 0x06005817 RID: 22551 RVA: 0x000A7CF0 File Offset: 0x000A5EF0
		[XmlIgnore]
		[Browsable(false)]
		public bool achieveIDSpecified
		{
			get
			{
				return this._achieveID != null;
			}
			set
			{
				bool flag = value == (this._achieveID == null);
				if (flag)
				{
					this._achieveID = (value ? new uint?(this.achieveID) : null);
				}
			}
		}

		// Token: 0x06005818 RID: 22552 RVA: 0x000A7D34 File Offset: 0x000A5F34
		private bool ShouldSerializeachieveID()
		{
			return this.achieveIDSpecified;
		}

		// Token: 0x06005819 RID: 22553 RVA: 0x000A7D4C File Offset: 0x000A5F4C
		private void ResetachieveID()
		{
			this.achieveIDSpecified = false;
		}

		// Token: 0x17001B60 RID: 7008
		// (get) Token: 0x0600581A RID: 22554 RVA: 0x000A7D58 File Offset: 0x000A5F58
		// (set) Token: 0x0600581B RID: 22555 RVA: 0x000A7D84 File Offset: 0x000A5F84
		[ProtoMember(2, IsRequired = false, Name = "rewardStatus", DataFormat = DataFormat.TwosComplement)]
		public uint rewardStatus
		{
			get
			{
				return this._rewardStatus ?? 0U;
			}
			set
			{
				this._rewardStatus = new uint?(value);
			}
		}

		// Token: 0x17001B61 RID: 7009
		// (get) Token: 0x0600581C RID: 22556 RVA: 0x000A7D94 File Offset: 0x000A5F94
		// (set) Token: 0x0600581D RID: 22557 RVA: 0x000A7DB4 File Offset: 0x000A5FB4
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardStatusSpecified
		{
			get
			{
				return this._rewardStatus != null;
			}
			set
			{
				bool flag = value == (this._rewardStatus == null);
				if (flag)
				{
					this._rewardStatus = (value ? new uint?(this.rewardStatus) : null);
				}
			}
		}

		// Token: 0x0600581E RID: 22558 RVA: 0x000A7DF8 File Offset: 0x000A5FF8
		private bool ShouldSerializerewardStatus()
		{
			return this.rewardStatusSpecified;
		}

		// Token: 0x0600581F RID: 22559 RVA: 0x000A7E10 File Offset: 0x000A6010
		private void ResetrewardStatus()
		{
			this.rewardStatusSpecified = false;
		}

		// Token: 0x06005820 RID: 22560 RVA: 0x000A7E1C File Offset: 0x000A601C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001558 RID: 5464
		private uint? _achieveID;

		// Token: 0x04001559 RID: 5465
		private uint? _rewardStatus;

		// Token: 0x0400155A RID: 5466
		private IExtension extensionObject;
	}
}
