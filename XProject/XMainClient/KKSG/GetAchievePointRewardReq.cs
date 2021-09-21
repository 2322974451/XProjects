using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000122 RID: 290
	[ProtoContract(Name = "GetAchievePointRewardReq")]
	[Serializable]
	public class GetAchievePointRewardReq : IExtensible
	{
		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001200 RID: 4608 RVA: 0x000249B4 File Offset: 0x00022BB4
		// (set) Token: 0x06001201 RID: 4609 RVA: 0x000249E0 File Offset: 0x00022BE0
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

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001202 RID: 4610 RVA: 0x000249F0 File Offset: 0x00022BF0
		// (set) Token: 0x06001203 RID: 4611 RVA: 0x00024A10 File Offset: 0x00022C10
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

		// Token: 0x06001204 RID: 4612 RVA: 0x00024A54 File Offset: 0x00022C54
		private bool ShouldSerializerewardId()
		{
			return this.rewardIdSpecified;
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x00024A6C File Offset: 0x00022C6C
		private void ResetrewardId()
		{
			this.rewardIdSpecified = false;
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x00024A78 File Offset: 0x00022C78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000482 RID: 1154
		private uint? _rewardId;

		// Token: 0x04000483 RID: 1155
		private IExtension extensionObject;
	}
}
