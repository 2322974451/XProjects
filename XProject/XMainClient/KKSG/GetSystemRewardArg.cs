using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000051 RID: 81
	[ProtoContract(Name = "GetSystemRewardArg")]
	[Serializable]
	public class GetSystemRewardArg : IExtensible
	{
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x0000D284 File Offset: 0x0000B484
		// (set) Token: 0x0600057A RID: 1402 RVA: 0x0000D2B1 File Offset: 0x0000B4B1
		[ProtoMember(1, IsRequired = false, Name = "RewardUniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong RewardUniqueId
		{
			get
			{
				return this._RewardUniqueId ?? 0UL;
			}
			set
			{
				this._RewardUniqueId = new ulong?(value);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		// (set) Token: 0x0600057C RID: 1404 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
		[XmlIgnore]
		[Browsable(false)]
		public bool RewardUniqueIdSpecified
		{
			get
			{
				return this._RewardUniqueId != null;
			}
			set
			{
				bool flag = value == (this._RewardUniqueId == null);
				if (flag)
				{
					this._RewardUniqueId = (value ? new ulong?(this.RewardUniqueId) : null);
				}
			}
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000D324 File Offset: 0x0000B524
		private bool ShouldSerializeRewardUniqueId()
		{
			return this.RewardUniqueIdSpecified;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0000D33C File Offset: 0x0000B53C
		private void ResetRewardUniqueId()
		{
			this.RewardUniqueIdSpecified = false;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0000D348 File Offset: 0x0000B548
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000164 RID: 356
		private ulong? _RewardUniqueId;

		// Token: 0x04000165 RID: 357
		private IExtension extensionObject;
	}
}
