using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000025 RID: 37
	[ProtoContract(Name = "ResetSkillRes")]
	[Serializable]
	public class ResetSkillRes : IExtensible
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00007AF8 File Offset: 0x00005CF8
		// (set) Token: 0x0600029D RID: 669 RVA: 0x00007B24 File Offset: 0x00005D24
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

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x0600029E RID: 670 RVA: 0x00007B34 File Offset: 0x00005D34
		// (set) Token: 0x0600029F RID: 671 RVA: 0x00007B54 File Offset: 0x00005D54
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

		// Token: 0x060002A0 RID: 672 RVA: 0x00007B98 File Offset: 0x00005D98
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00007BB0 File Offset: 0x00005DB0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x00007BBC File Offset: 0x00005DBC
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x00007BE8 File Offset: 0x00005DE8
		[ProtoMember(2, IsRequired = false, Name = "prof", DataFormat = DataFormat.TwosComplement)]
		public RoleType prof
		{
			get
			{
				return this._prof ?? RoleType.Role_INVALID;
			}
			set
			{
				this._prof = new RoleType?(value);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00007BF8 File Offset: 0x00005DF8
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00007C18 File Offset: 0x00005E18
		[XmlIgnore]
		[Browsable(false)]
		public bool profSpecified
		{
			get
			{
				return this._prof != null;
			}
			set
			{
				bool flag = value == (this._prof == null);
				if (flag)
				{
					this._prof = (value ? new RoleType?(this.prof) : null);
				}
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00007C5C File Offset: 0x00005E5C
		private bool ShouldSerializeprof()
		{
			return this.profSpecified;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00007C74 File Offset: 0x00005E74
		private void Resetprof()
		{
			this.profSpecified = false;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00007C80 File Offset: 0x00005E80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000B1 RID: 177
		private ErrorCode? _errorcode;

		// Token: 0x040000B2 RID: 178
		private RoleType? _prof;

		// Token: 0x040000B3 RID: 179
		private IExtension extensionObject;
	}
}
