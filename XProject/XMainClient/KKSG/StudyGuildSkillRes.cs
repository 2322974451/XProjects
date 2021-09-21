using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015D RID: 349
	[ProtoContract(Name = "StudyGuildSkillRes")]
	[Serializable]
	public class StudyGuildSkillRes : IExtensible
	{
		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001545 RID: 5445 RVA: 0x0002AC80 File Offset: 0x00028E80
		// (set) Token: 0x06001546 RID: 5446 RVA: 0x0002ACAC File Offset: 0x00028EAC
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06001547 RID: 5447 RVA: 0x0002ACBC File Offset: 0x00028EBC
		// (set) Token: 0x06001548 RID: 5448 RVA: 0x0002ACDC File Offset: 0x00028EDC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0002AD20 File Offset: 0x00028F20
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0002AD38 File Offset: 0x00028F38
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x0600154B RID: 5451 RVA: 0x0002AD44 File Offset: 0x00028F44
		// (set) Token: 0x0600154C RID: 5452 RVA: 0x0002AD70 File Offset: 0x00028F70
		[ProtoMember(2, IsRequired = false, Name = "skillId", DataFormat = DataFormat.TwosComplement)]
		public uint skillId
		{
			get
			{
				return this._skillId ?? 0U;
			}
			set
			{
				this._skillId = new uint?(value);
			}
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x0600154D RID: 5453 RVA: 0x0002AD80 File Offset: 0x00028F80
		// (set) Token: 0x0600154E RID: 5454 RVA: 0x0002ADA0 File Offset: 0x00028FA0
		[XmlIgnore]
		[Browsable(false)]
		public bool skillIdSpecified
		{
			get
			{
				return this._skillId != null;
			}
			set
			{
				bool flag = value == (this._skillId == null);
				if (flag)
				{
					this._skillId = (value ? new uint?(this.skillId) : null);
				}
			}
		}

		// Token: 0x0600154F RID: 5455 RVA: 0x0002ADE4 File Offset: 0x00028FE4
		private bool ShouldSerializeskillId()
		{
			return this.skillIdSpecified;
		}

		// Token: 0x06001550 RID: 5456 RVA: 0x0002ADFC File Offset: 0x00028FFC
		private void ResetskillId()
		{
			this.skillIdSpecified = false;
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001551 RID: 5457 RVA: 0x0002AE08 File Offset: 0x00029008
		// (set) Token: 0x06001552 RID: 5458 RVA: 0x0002AE34 File Offset: 0x00029034
		[ProtoMember(3, IsRequired = false, Name = "skillLel", DataFormat = DataFormat.TwosComplement)]
		public uint skillLel
		{
			get
			{
				return this._skillLel ?? 0U;
			}
			set
			{
				this._skillLel = new uint?(value);
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x06001553 RID: 5459 RVA: 0x0002AE44 File Offset: 0x00029044
		// (set) Token: 0x06001554 RID: 5460 RVA: 0x0002AE64 File Offset: 0x00029064
		[XmlIgnore]
		[Browsable(false)]
		public bool skillLelSpecified
		{
			get
			{
				return this._skillLel != null;
			}
			set
			{
				bool flag = value == (this._skillLel == null);
				if (flag)
				{
					this._skillLel = (value ? new uint?(this.skillLel) : null);
				}
			}
		}

		// Token: 0x06001555 RID: 5461 RVA: 0x0002AEA8 File Offset: 0x000290A8
		private bool ShouldSerializeskillLel()
		{
			return this.skillLelSpecified;
		}

		// Token: 0x06001556 RID: 5462 RVA: 0x0002AEC0 File Offset: 0x000290C0
		private void ResetskillLel()
		{
			this.skillLelSpecified = false;
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x06001557 RID: 5463 RVA: 0x0002AECC File Offset: 0x000290CC
		// (set) Token: 0x06001558 RID: 5464 RVA: 0x0002AEF8 File Offset: 0x000290F8
		[ProtoMember(4, IsRequired = false, Name = "lastExp", DataFormat = DataFormat.TwosComplement)]
		public uint lastExp
		{
			get
			{
				return this._lastExp ?? 0U;
			}
			set
			{
				this._lastExp = new uint?(value);
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06001559 RID: 5465 RVA: 0x0002AF08 File Offset: 0x00029108
		// (set) Token: 0x0600155A RID: 5466 RVA: 0x0002AF28 File Offset: 0x00029128
		[XmlIgnore]
		[Browsable(false)]
		public bool lastExpSpecified
		{
			get
			{
				return this._lastExp != null;
			}
			set
			{
				bool flag = value == (this._lastExp == null);
				if (flag)
				{
					this._lastExp = (value ? new uint?(this.lastExp) : null);
				}
			}
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0002AF6C File Offset: 0x0002916C
		private bool ShouldSerializelastExp()
		{
			return this.lastExpSpecified;
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0002AF84 File Offset: 0x00029184
		private void ResetlastExp()
		{
			this.lastExpSpecified = false;
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0002AF90 File Offset: 0x00029190
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000549 RID: 1353
		private ErrorCode? _errorcode;

		// Token: 0x0400054A RID: 1354
		private uint? _skillId;

		// Token: 0x0400054B RID: 1355
		private uint? _skillLel;

		// Token: 0x0400054C RID: 1356
		private uint? _lastExp;

		// Token: 0x0400054D RID: 1357
		private IExtension extensionObject;
	}
}
