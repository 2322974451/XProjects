using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004FE RID: 1278
	[ProtoContract(Name = "DailyTaskRefreshOperArg")]
	[Serializable]
	public class DailyTaskRefreshOperArg : IExtensible
	{
		// Token: 0x17001435 RID: 5173
		// (get) Token: 0x06004202 RID: 16898 RVA: 0x0007DAAC File Offset: 0x0007BCAC
		// (set) Token: 0x06004203 RID: 16899 RVA: 0x0007DAD8 File Offset: 0x0007BCD8
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public DailyRefreshOperType type
		{
			get
			{
				return this._type ?? DailyRefreshOperType.DROT_Refresh;
			}
			set
			{
				this._type = new DailyRefreshOperType?(value);
			}
		}

		// Token: 0x17001436 RID: 5174
		// (get) Token: 0x06004204 RID: 16900 RVA: 0x0007DAE8 File Offset: 0x0007BCE8
		// (set) Token: 0x06004205 RID: 16901 RVA: 0x0007DB08 File Offset: 0x0007BD08
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new DailyRefreshOperType?(this.type) : null);
				}
			}
		}

		// Token: 0x06004206 RID: 16902 RVA: 0x0007DB4C File Offset: 0x0007BD4C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004207 RID: 16903 RVA: 0x0007DB64 File Offset: 0x0007BD64
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001437 RID: 5175
		// (get) Token: 0x06004208 RID: 16904 RVA: 0x0007DB70 File Offset: 0x0007BD70
		// (set) Token: 0x06004209 RID: 16905 RVA: 0x0007DB9D File Offset: 0x0007BD9D
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001438 RID: 5176
		// (get) Token: 0x0600420A RID: 16906 RVA: 0x0007DBAC File Offset: 0x0007BDAC
		// (set) Token: 0x0600420B RID: 16907 RVA: 0x0007DBCC File Offset: 0x0007BDCC
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

		// Token: 0x0600420C RID: 16908 RVA: 0x0007DC10 File Offset: 0x0007BE10
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600420D RID: 16909 RVA: 0x0007DC28 File Offset: 0x0007BE28
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x0600420E RID: 16910 RVA: 0x0007DC34 File Offset: 0x0007BE34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001077 RID: 4215
		private DailyRefreshOperType? _type;

		// Token: 0x04001078 RID: 4216
		private ulong? _roleid;

		// Token: 0x04001079 RID: 4217
		private IExtension extensionObject;
	}
}
