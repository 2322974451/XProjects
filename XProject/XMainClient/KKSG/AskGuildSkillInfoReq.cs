using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200015B RID: 347
	[ProtoContract(Name = "AskGuildSkillInfoReq")]
	[Serializable]
	public class AskGuildSkillInfoReq : IExtensible
	{
		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600152D RID: 5421 RVA: 0x0002A9C4 File Offset: 0x00028BC4
		// (set) Token: 0x0600152E RID: 5422 RVA: 0x0002A9F0 File Offset: 0x00028BF0
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

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x0600152F RID: 5423 RVA: 0x0002AA00 File Offset: 0x00028C00
		// (set) Token: 0x06001530 RID: 5424 RVA: 0x0002AA20 File Offset: 0x00028C20
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

		// Token: 0x06001531 RID: 5425 RVA: 0x0002AA64 File Offset: 0x00028C64
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0002AA7C File Offset: 0x00028C7C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06001533 RID: 5427 RVA: 0x0002AA88 File Offset: 0x00028C88
		[ProtoMember(2, Name = "SkillLel", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> SkillLel
		{
			get
			{
				return this._SkillLel;
			}
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001534 RID: 5428 RVA: 0x0002AAA0 File Offset: 0x00028CA0
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x0002AACC File Offset: 0x00028CCC
		[ProtoMember(3, IsRequired = false, Name = "LastGuildExp", DataFormat = DataFormat.TwosComplement)]
		public int LastGuildExp
		{
			get
			{
				return this._LastGuildExp ?? 0;
			}
			set
			{
				this._LastGuildExp = new int?(value);
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06001536 RID: 5430 RVA: 0x0002AADC File Offset: 0x00028CDC
		// (set) Token: 0x06001537 RID: 5431 RVA: 0x0002AAFC File Offset: 0x00028CFC
		[XmlIgnore]
		[Browsable(false)]
		public bool LastGuildExpSpecified
		{
			get
			{
				return this._LastGuildExp != null;
			}
			set
			{
				bool flag = value == (this._LastGuildExp == null);
				if (flag)
				{
					this._LastGuildExp = (value ? new int?(this.LastGuildExp) : null);
				}
			}
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0002AB40 File Offset: 0x00028D40
		private bool ShouldSerializeLastGuildExp()
		{
			return this.LastGuildExpSpecified;
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0002AB58 File Offset: 0x00028D58
		private void ResetLastGuildExp()
		{
			this.LastGuildExpSpecified = false;
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x0600153A RID: 5434 RVA: 0x0002AB64 File Offset: 0x00028D64
		[ProtoMember(4, Name = "roleSkills", DataFormat = DataFormat.Default)]
		public List<GuildSkillData> roleSkills
		{
			get
			{
				return this._roleSkills;
			}
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0002AB7C File Offset: 0x00028D7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000542 RID: 1346
		private ErrorCode? _errorcode;

		// Token: 0x04000543 RID: 1347
		private readonly List<GuildSkillData> _SkillLel = new List<GuildSkillData>();

		// Token: 0x04000544 RID: 1348
		private int? _LastGuildExp;

		// Token: 0x04000545 RID: 1349
		private readonly List<GuildSkillData> _roleSkills = new List<GuildSkillData>();

		// Token: 0x04000546 RID: 1350
		private IExtension extensionObject;
	}
}
