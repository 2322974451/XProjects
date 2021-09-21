using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FC RID: 1532
	[ProtoContract(Name = "FlowerRecord")]
	[Serializable]
	public class FlowerRecord : IExtensible
	{
		// Token: 0x17001C93 RID: 7315
		// (get) Token: 0x06005B54 RID: 23380 RVA: 0x000ADEB4 File Offset: 0x000AC0B4
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x17001C94 RID: 7316
		// (get) Token: 0x06005B55 RID: 23381 RVA: 0x000ADECC File Offset: 0x000AC0CC
		[ProtoMember(2, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public List<uint> count
		{
			get
			{
				return this._count;
			}
		}

		// Token: 0x17001C95 RID: 7317
		// (get) Token: 0x06005B56 RID: 23382 RVA: 0x000ADEE4 File Offset: 0x000AC0E4
		// (set) Token: 0x06005B57 RID: 23383 RVA: 0x000ADF10 File Offset: 0x000AC110
		[ProtoMember(3, IsRequired = false, Name = "updateday", DataFormat = DataFormat.TwosComplement)]
		public uint updateday
		{
			get
			{
				return this._updateday ?? 0U;
			}
			set
			{
				this._updateday = new uint?(value);
			}
		}

		// Token: 0x17001C96 RID: 7318
		// (get) Token: 0x06005B58 RID: 23384 RVA: 0x000ADF20 File Offset: 0x000AC120
		// (set) Token: 0x06005B59 RID: 23385 RVA: 0x000ADF40 File Offset: 0x000AC140
		[XmlIgnore]
		[Browsable(false)]
		public bool updatedaySpecified
		{
			get
			{
				return this._updateday != null;
			}
			set
			{
				bool flag = value == (this._updateday == null);
				if (flag)
				{
					this._updateday = (value ? new uint?(this.updateday) : null);
				}
			}
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x000ADF84 File Offset: 0x000AC184
		private bool ShouldSerializeupdateday()
		{
			return this.updatedaySpecified;
		}

		// Token: 0x06005B5B RID: 23387 RVA: 0x000ADF9C File Offset: 0x000AC19C
		private void Resetupdateday()
		{
			this.updatedaySpecified = false;
		}

		// Token: 0x17001C97 RID: 7319
		// (get) Token: 0x06005B5C RID: 23388 RVA: 0x000ADFA8 File Offset: 0x000AC1A8
		// (set) Token: 0x06005B5D RID: 23389 RVA: 0x000ADFD4 File Offset: 0x000AC1D4
		[ProtoMember(4, IsRequired = false, Name = "getRankReward", DataFormat = DataFormat.Default)]
		public bool getRankReward
		{
			get
			{
				return this._getRankReward ?? false;
			}
			set
			{
				this._getRankReward = new bool?(value);
			}
		}

		// Token: 0x17001C98 RID: 7320
		// (get) Token: 0x06005B5E RID: 23390 RVA: 0x000ADFE4 File Offset: 0x000AC1E4
		// (set) Token: 0x06005B5F RID: 23391 RVA: 0x000AE004 File Offset: 0x000AC204
		[XmlIgnore]
		[Browsable(false)]
		public bool getRankRewardSpecified
		{
			get
			{
				return this._getRankReward != null;
			}
			set
			{
				bool flag = value == (this._getRankReward == null);
				if (flag)
				{
					this._getRankReward = (value ? new bool?(this.getRankReward) : null);
				}
			}
		}

		// Token: 0x06005B60 RID: 23392 RVA: 0x000AE048 File Offset: 0x000AC248
		private bool ShouldSerializegetRankReward()
		{
			return this.getRankRewardSpecified;
		}

		// Token: 0x06005B61 RID: 23393 RVA: 0x000AE060 File Offset: 0x000AC260
		private void ResetgetRankReward()
		{
			this.getRankRewardSpecified = false;
		}

		// Token: 0x17001C99 RID: 7321
		// (get) Token: 0x06005B62 RID: 23394 RVA: 0x000AE06C File Offset: 0x000AC26C
		// (set) Token: 0x06005B63 RID: 23395 RVA: 0x000AE098 File Offset: 0x000AC298
		[ProtoMember(5, IsRequired = false, Name = "getFlowerTime", DataFormat = DataFormat.TwosComplement)]
		public uint getFlowerTime
		{
			get
			{
				return this._getFlowerTime ?? 0U;
			}
			set
			{
				this._getFlowerTime = new uint?(value);
			}
		}

		// Token: 0x17001C9A RID: 7322
		// (get) Token: 0x06005B64 RID: 23396 RVA: 0x000AE0A8 File Offset: 0x000AC2A8
		// (set) Token: 0x06005B65 RID: 23397 RVA: 0x000AE0C8 File Offset: 0x000AC2C8
		[XmlIgnore]
		[Browsable(false)]
		public bool getFlowerTimeSpecified
		{
			get
			{
				return this._getFlowerTime != null;
			}
			set
			{
				bool flag = value == (this._getFlowerTime == null);
				if (flag)
				{
					this._getFlowerTime = (value ? new uint?(this.getFlowerTime) : null);
				}
			}
		}

		// Token: 0x06005B66 RID: 23398 RVA: 0x000AE10C File Offset: 0x000AC30C
		private bool ShouldSerializegetFlowerTime()
		{
			return this.getFlowerTimeSpecified;
		}

		// Token: 0x06005B67 RID: 23399 RVA: 0x000AE124 File Offset: 0x000AC324
		private void ResetgetFlowerTime()
		{
			this.getFlowerTimeSpecified = false;
		}

		// Token: 0x17001C9B RID: 7323
		// (get) Token: 0x06005B68 RID: 23400 RVA: 0x000AE130 File Offset: 0x000AC330
		// (set) Token: 0x06005B69 RID: 23401 RVA: 0x000AE15C File Offset: 0x000AC35C
		[ProtoMember(6, IsRequired = false, Name = "getFlowerNum", DataFormat = DataFormat.TwosComplement)]
		public uint getFlowerNum
		{
			get
			{
				return this._getFlowerNum ?? 0U;
			}
			set
			{
				this._getFlowerNum = new uint?(value);
			}
		}

		// Token: 0x17001C9C RID: 7324
		// (get) Token: 0x06005B6A RID: 23402 RVA: 0x000AE16C File Offset: 0x000AC36C
		// (set) Token: 0x06005B6B RID: 23403 RVA: 0x000AE18C File Offset: 0x000AC38C
		[XmlIgnore]
		[Browsable(false)]
		public bool getFlowerNumSpecified
		{
			get
			{
				return this._getFlowerNum != null;
			}
			set
			{
				bool flag = value == (this._getFlowerNum == null);
				if (flag)
				{
					this._getFlowerNum = (value ? new uint?(this.getFlowerNum) : null);
				}
			}
		}

		// Token: 0x06005B6C RID: 23404 RVA: 0x000AE1D0 File Offset: 0x000AC3D0
		private bool ShouldSerializegetFlowerNum()
		{
			return this.getFlowerNumSpecified;
		}

		// Token: 0x06005B6D RID: 23405 RVA: 0x000AE1E8 File Offset: 0x000AC3E8
		private void ResetgetFlowerNum()
		{
			this.getFlowerNumSpecified = false;
		}

		// Token: 0x06005B6E RID: 23406 RVA: 0x000AE1F4 File Offset: 0x000AC3F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400163A RID: 5690
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x0400163B RID: 5691
		private readonly List<uint> _count = new List<uint>();

		// Token: 0x0400163C RID: 5692
		private uint? _updateday;

		// Token: 0x0400163D RID: 5693
		private bool? _getRankReward;

		// Token: 0x0400163E RID: 5694
		private uint? _getFlowerTime;

		// Token: 0x0400163F RID: 5695
		private uint? _getFlowerNum;

		// Token: 0x04001640 RID: 5696
		private IExtension extensionObject;
	}
}
