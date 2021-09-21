using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000738 RID: 1848
	[ProtoContract(Name = "NpcFlRoleExp")]
	[Serializable]
	public class NpcFlRoleExp : IExtensible
	{
		// Token: 0x1700288B RID: 10379
		// (get) Token: 0x06007FE3 RID: 32739 RVA: 0x000F4890 File Offset: 0x000F2A90
		// (set) Token: 0x06007FE4 RID: 32740 RVA: 0x000F48BD File Offset: 0x000F2ABD
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x1700288C RID: 10380
		// (get) Token: 0x06007FE5 RID: 32741 RVA: 0x000F48CC File Offset: 0x000F2ACC
		// (set) Token: 0x06007FE6 RID: 32742 RVA: 0x000F48EC File Offset: 0x000F2AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06007FE7 RID: 32743 RVA: 0x000F4930 File Offset: 0x000F2B30
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06007FE8 RID: 32744 RVA: 0x000F4948 File Offset: 0x000F2B48
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700288D RID: 10381
		// (get) Token: 0x06007FE9 RID: 32745 RVA: 0x000F4954 File Offset: 0x000F2B54
		// (set) Token: 0x06007FEA RID: 32746 RVA: 0x000F4980 File Offset: 0x000F2B80
		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public uint exp
		{
			get
			{
				return this._exp ?? 0U;
			}
			set
			{
				this._exp = new uint?(value);
			}
		}

		// Token: 0x1700288E RID: 10382
		// (get) Token: 0x06007FEB RID: 32747 RVA: 0x000F4990 File Offset: 0x000F2B90
		// (set) Token: 0x06007FEC RID: 32748 RVA: 0x000F49B0 File Offset: 0x000F2BB0
		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new uint?(this.exp) : null);
				}
			}
		}

		// Token: 0x06007FED RID: 32749 RVA: 0x000F49F4 File Offset: 0x000F2BF4
		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		// Token: 0x06007FEE RID: 32750 RVA: 0x000F4A0C File Offset: 0x000F2C0C
		private void Resetexp()
		{
			this.expSpecified = false;
		}

		// Token: 0x06007FEF RID: 32751 RVA: 0x000F4A18 File Offset: 0x000F2C18
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DFE RID: 7678
		private ulong? _roleid;

		// Token: 0x04001DFF RID: 7679
		private uint? _exp;

		// Token: 0x04001E00 RID: 7680
		private IExtension extensionObject;
	}
}
