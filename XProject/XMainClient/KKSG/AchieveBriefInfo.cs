using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E6 RID: 1510
	[ProtoContract(Name = "AchieveBriefInfo")]
	[Serializable]
	public class AchieveBriefInfo : IExtensible
	{
		// Token: 0x17001B56 RID: 6998
		// (get) Token: 0x060057FA RID: 22522 RVA: 0x000A7964 File Offset: 0x000A5B64
		// (set) Token: 0x060057FB RID: 22523 RVA: 0x000A7990 File Offset: 0x000A5B90
		[ProtoMember(1, IsRequired = false, Name = "achieveClassifyType", DataFormat = DataFormat.TwosComplement)]
		public uint achieveClassifyType
		{
			get
			{
				return this._achieveClassifyType ?? 0U;
			}
			set
			{
				this._achieveClassifyType = new uint?(value);
			}
		}

		// Token: 0x17001B57 RID: 6999
		// (get) Token: 0x060057FC RID: 22524 RVA: 0x000A79A0 File Offset: 0x000A5BA0
		// (set) Token: 0x060057FD RID: 22525 RVA: 0x000A79C0 File Offset: 0x000A5BC0
		[XmlIgnore]
		[Browsable(false)]
		public bool achieveClassifyTypeSpecified
		{
			get
			{
				return this._achieveClassifyType != null;
			}
			set
			{
				bool flag = value == (this._achieveClassifyType == null);
				if (flag)
				{
					this._achieveClassifyType = (value ? new uint?(this.achieveClassifyType) : null);
				}
			}
		}

		// Token: 0x060057FE RID: 22526 RVA: 0x000A7A04 File Offset: 0x000A5C04
		private bool ShouldSerializeachieveClassifyType()
		{
			return this.achieveClassifyTypeSpecified;
		}

		// Token: 0x060057FF RID: 22527 RVA: 0x000A7A1C File Offset: 0x000A5C1C
		private void ResetachieveClassifyType()
		{
			this.achieveClassifyTypeSpecified = false;
		}

		// Token: 0x17001B58 RID: 7000
		// (get) Token: 0x06005800 RID: 22528 RVA: 0x000A7A28 File Offset: 0x000A5C28
		// (set) Token: 0x06005801 RID: 22529 RVA: 0x000A7A54 File Offset: 0x000A5C54
		[ProtoMember(2, IsRequired = false, Name = "achievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint achievePoint
		{
			get
			{
				return this._achievePoint ?? 0U;
			}
			set
			{
				this._achievePoint = new uint?(value);
			}
		}

		// Token: 0x17001B59 RID: 7001
		// (get) Token: 0x06005802 RID: 22530 RVA: 0x000A7A64 File Offset: 0x000A5C64
		// (set) Token: 0x06005803 RID: 22531 RVA: 0x000A7A84 File Offset: 0x000A5C84
		[XmlIgnore]
		[Browsable(false)]
		public bool achievePointSpecified
		{
			get
			{
				return this._achievePoint != null;
			}
			set
			{
				bool flag = value == (this._achievePoint == null);
				if (flag)
				{
					this._achievePoint = (value ? new uint?(this.achievePoint) : null);
				}
			}
		}

		// Token: 0x06005804 RID: 22532 RVA: 0x000A7AC8 File Offset: 0x000A5CC8
		private bool ShouldSerializeachievePoint()
		{
			return this.achievePointSpecified;
		}

		// Token: 0x06005805 RID: 22533 RVA: 0x000A7AE0 File Offset: 0x000A5CE0
		private void ResetachievePoint()
		{
			this.achievePointSpecified = false;
		}

		// Token: 0x17001B5A RID: 7002
		// (get) Token: 0x06005806 RID: 22534 RVA: 0x000A7AEC File Offset: 0x000A5CEC
		// (set) Token: 0x06005807 RID: 22535 RVA: 0x000A7B18 File Offset: 0x000A5D18
		[ProtoMember(3, IsRequired = false, Name = "maxAchievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint maxAchievePoint
		{
			get
			{
				return this._maxAchievePoint ?? 0U;
			}
			set
			{
				this._maxAchievePoint = new uint?(value);
			}
		}

		// Token: 0x17001B5B RID: 7003
		// (get) Token: 0x06005808 RID: 22536 RVA: 0x000A7B28 File Offset: 0x000A5D28
		// (set) Token: 0x06005809 RID: 22537 RVA: 0x000A7B48 File Offset: 0x000A5D48
		[XmlIgnore]
		[Browsable(false)]
		public bool maxAchievePointSpecified
		{
			get
			{
				return this._maxAchievePoint != null;
			}
			set
			{
				bool flag = value == (this._maxAchievePoint == null);
				if (flag)
				{
					this._maxAchievePoint = (value ? new uint?(this.maxAchievePoint) : null);
				}
			}
		}

		// Token: 0x0600580A RID: 22538 RVA: 0x000A7B8C File Offset: 0x000A5D8C
		private bool ShouldSerializemaxAchievePoint()
		{
			return this.maxAchievePointSpecified;
		}

		// Token: 0x0600580B RID: 22539 RVA: 0x000A7BA4 File Offset: 0x000A5DA4
		private void ResetmaxAchievePoint()
		{
			this.maxAchievePointSpecified = false;
		}

		// Token: 0x17001B5C RID: 7004
		// (get) Token: 0x0600580C RID: 22540 RVA: 0x000A7BB0 File Offset: 0x000A5DB0
		// (set) Token: 0x0600580D RID: 22541 RVA: 0x000A7BDC File Offset: 0x000A5DDC
		[ProtoMember(4, IsRequired = false, Name = "canRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint canRewardCount
		{
			get
			{
				return this._canRewardCount ?? 0U;
			}
			set
			{
				this._canRewardCount = new uint?(value);
			}
		}

		// Token: 0x17001B5D RID: 7005
		// (get) Token: 0x0600580E RID: 22542 RVA: 0x000A7BEC File Offset: 0x000A5DEC
		// (set) Token: 0x0600580F RID: 22543 RVA: 0x000A7C0C File Offset: 0x000A5E0C
		[XmlIgnore]
		[Browsable(false)]
		public bool canRewardCountSpecified
		{
			get
			{
				return this._canRewardCount != null;
			}
			set
			{
				bool flag = value == (this._canRewardCount == null);
				if (flag)
				{
					this._canRewardCount = (value ? new uint?(this.canRewardCount) : null);
				}
			}
		}

		// Token: 0x06005810 RID: 22544 RVA: 0x000A7C50 File Offset: 0x000A5E50
		private bool ShouldSerializecanRewardCount()
		{
			return this.canRewardCountSpecified;
		}

		// Token: 0x06005811 RID: 22545 RVA: 0x000A7C68 File Offset: 0x000A5E68
		private void ResetcanRewardCount()
		{
			this.canRewardCountSpecified = false;
		}

		// Token: 0x06005812 RID: 22546 RVA: 0x000A7C74 File Offset: 0x000A5E74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001553 RID: 5459
		private uint? _achieveClassifyType;

		// Token: 0x04001554 RID: 5460
		private uint? _achievePoint;

		// Token: 0x04001555 RID: 5461
		private uint? _maxAchievePoint;

		// Token: 0x04001556 RID: 5462
		private uint? _canRewardCount;

		// Token: 0x04001557 RID: 5463
		private IExtension extensionObject;
	}
}
