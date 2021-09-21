using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000665 RID: 1637
	[ProtoContract(Name = "STC_ACHIEVE_POINT_REWARD")]
	[Serializable]
	public class STC_ACHIEVE_POINT_REWARD : IExtensible
	{
		// Token: 0x1700209F RID: 8351
		// (get) Token: 0x06006748 RID: 26440 RVA: 0x000C54FC File Offset: 0x000C36FC
		// (set) Token: 0x06006749 RID: 26441 RVA: 0x000C5528 File Offset: 0x000C3728
		[ProtoMember(1, IsRequired = false, Name = "rewardId", DataFormat = DataFormat.TwosComplement)]
		public uint rewardId
		{
			get
			{
				return this._rewardId ?? 0U;
			}
			set
			{
				this._rewardId = new uint?(value);
			}
		}

		// Token: 0x170020A0 RID: 8352
		// (get) Token: 0x0600674A RID: 26442 RVA: 0x000C5538 File Offset: 0x000C3738
		// (set) Token: 0x0600674B RID: 26443 RVA: 0x000C5558 File Offset: 0x000C3758
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardIdSpecified
		{
			get
			{
				return this._rewardId != null;
			}
			set
			{
				bool flag = value == (this._rewardId == null);
				if (flag)
				{
					this._rewardId = (value ? new uint?(this.rewardId) : null);
				}
			}
		}

		// Token: 0x0600674C RID: 26444 RVA: 0x000C559C File Offset: 0x000C379C
		private bool ShouldSerializerewardId()
		{
			return this.rewardIdSpecified;
		}

		// Token: 0x0600674D RID: 26445 RVA: 0x000C55B4 File Offset: 0x000C37B4
		private void ResetrewardId()
		{
			this.rewardIdSpecified = false;
		}

		// Token: 0x170020A1 RID: 8353
		// (get) Token: 0x0600674E RID: 26446 RVA: 0x000C55C0 File Offset: 0x000C37C0
		// (set) Token: 0x0600674F RID: 26447 RVA: 0x000C55EC File Offset: 0x000C37EC
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

		// Token: 0x170020A2 RID: 8354
		// (get) Token: 0x06006750 RID: 26448 RVA: 0x000C55FC File Offset: 0x000C37FC
		// (set) Token: 0x06006751 RID: 26449 RVA: 0x000C561C File Offset: 0x000C381C
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

		// Token: 0x06006752 RID: 26450 RVA: 0x000C5660 File Offset: 0x000C3860
		private bool ShouldSerializerewardStatus()
		{
			return this.rewardStatusSpecified;
		}

		// Token: 0x06006753 RID: 26451 RVA: 0x000C5678 File Offset: 0x000C3878
		private void ResetrewardStatus()
		{
			this.rewardStatusSpecified = false;
		}

		// Token: 0x06006754 RID: 26452 RVA: 0x000C5684 File Offset: 0x000C3884
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018F4 RID: 6388
		private uint? _rewardId;

		// Token: 0x040018F5 RID: 6389
		private uint? _rewardStatus;

		// Token: 0x040018F6 RID: 6390
		private IExtension extensionObject;
	}
}
