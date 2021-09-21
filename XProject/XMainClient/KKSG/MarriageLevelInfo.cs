using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000726 RID: 1830
	[ProtoContract(Name = "MarriageLevelInfo")]
	[Serializable]
	public class MarriageLevelInfo : IExtensible
	{
		// Token: 0x170027FC RID: 10236
		// (get) Token: 0x06007E1D RID: 32285 RVA: 0x000F128C File Offset: 0x000EF48C
		// (set) Token: 0x06007E1E RID: 32286 RVA: 0x000F12B8 File Offset: 0x000EF4B8
		[ProtoMember(1, IsRequired = false, Name = "marriageLevel", DataFormat = DataFormat.TwosComplement)]
		public int marriageLevel
		{
			get
			{
				return this._marriageLevel ?? 0;
			}
			set
			{
				this._marriageLevel = new int?(value);
			}
		}

		// Token: 0x170027FD RID: 10237
		// (get) Token: 0x06007E1F RID: 32287 RVA: 0x000F12C8 File Offset: 0x000EF4C8
		// (set) Token: 0x06007E20 RID: 32288 RVA: 0x000F12E8 File Offset: 0x000EF4E8
		[XmlIgnore]
		[Browsable(false)]
		public bool marriageLevelSpecified
		{
			get
			{
				return this._marriageLevel != null;
			}
			set
			{
				bool flag = value == (this._marriageLevel == null);
				if (flag)
				{
					this._marriageLevel = (value ? new int?(this.marriageLevel) : null);
				}
			}
		}

		// Token: 0x06007E21 RID: 32289 RVA: 0x000F132C File Offset: 0x000EF52C
		private bool ShouldSerializemarriageLevel()
		{
			return this.marriageLevelSpecified;
		}

		// Token: 0x06007E22 RID: 32290 RVA: 0x000F1344 File Offset: 0x000EF544
		private void ResetmarriageLevel()
		{
			this.marriageLevelSpecified = false;
		}

		// Token: 0x170027FE RID: 10238
		// (get) Token: 0x06007E23 RID: 32291 RVA: 0x000F1350 File Offset: 0x000EF550
		// (set) Token: 0x06007E24 RID: 32292 RVA: 0x000F137C File Offset: 0x000EF57C
		[ProtoMember(2, IsRequired = false, Name = "marriageLevelValue", DataFormat = DataFormat.TwosComplement)]
		public int marriageLevelValue
		{
			get
			{
				return this._marriageLevelValue ?? 0;
			}
			set
			{
				this._marriageLevelValue = new int?(value);
			}
		}

		// Token: 0x170027FF RID: 10239
		// (get) Token: 0x06007E25 RID: 32293 RVA: 0x000F138C File Offset: 0x000EF58C
		// (set) Token: 0x06007E26 RID: 32294 RVA: 0x000F13AC File Offset: 0x000EF5AC
		[XmlIgnore]
		[Browsable(false)]
		public bool marriageLevelValueSpecified
		{
			get
			{
				return this._marriageLevelValue != null;
			}
			set
			{
				bool flag = value == (this._marriageLevelValue == null);
				if (flag)
				{
					this._marriageLevelValue = (value ? new int?(this.marriageLevelValue) : null);
				}
			}
		}

		// Token: 0x06007E27 RID: 32295 RVA: 0x000F13F0 File Offset: 0x000EF5F0
		private bool ShouldSerializemarriageLevelValue()
		{
			return this.marriageLevelValueSpecified;
		}

		// Token: 0x06007E28 RID: 32296 RVA: 0x000F1408 File Offset: 0x000EF608
		private void ResetmarriageLevelValue()
		{
			this.marriageLevelValueSpecified = false;
		}

		// Token: 0x17002800 RID: 10240
		// (get) Token: 0x06007E29 RID: 32297 RVA: 0x000F1414 File Offset: 0x000EF614
		// (set) Token: 0x06007E2A RID: 32298 RVA: 0x000F1440 File Offset: 0x000EF640
		[ProtoMember(3, IsRequired = false, Name = "canGetPrivilegeReward", DataFormat = DataFormat.TwosComplement)]
		public int canGetPrivilegeReward
		{
			get
			{
				return this._canGetPrivilegeReward ?? 0;
			}
			set
			{
				this._canGetPrivilegeReward = new int?(value);
			}
		}

		// Token: 0x17002801 RID: 10241
		// (get) Token: 0x06007E2B RID: 32299 RVA: 0x000F1450 File Offset: 0x000EF650
		// (set) Token: 0x06007E2C RID: 32300 RVA: 0x000F1470 File Offset: 0x000EF670
		[XmlIgnore]
		[Browsable(false)]
		public bool canGetPrivilegeRewardSpecified
		{
			get
			{
				return this._canGetPrivilegeReward != null;
			}
			set
			{
				bool flag = value == (this._canGetPrivilegeReward == null);
				if (flag)
				{
					this._canGetPrivilegeReward = (value ? new int?(this.canGetPrivilegeReward) : null);
				}
			}
		}

		// Token: 0x06007E2D RID: 32301 RVA: 0x000F14B4 File Offset: 0x000EF6B4
		private bool ShouldSerializecanGetPrivilegeReward()
		{
			return this.canGetPrivilegeRewardSpecified;
		}

		// Token: 0x06007E2E RID: 32302 RVA: 0x000F14CC File Offset: 0x000EF6CC
		private void ResetcanGetPrivilegeReward()
		{
			this.canGetPrivilegeRewardSpecified = false;
		}

		// Token: 0x06007E2F RID: 32303 RVA: 0x000F14D8 File Offset: 0x000EF6D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DA1 RID: 7585
		private int? _marriageLevel;

		// Token: 0x04001DA2 RID: 7586
		private int? _marriageLevelValue;

		// Token: 0x04001DA3 RID: 7587
		private int? _canGetPrivilegeReward;

		// Token: 0x04001DA4 RID: 7588
		private IExtension extensionObject;
	}
}
