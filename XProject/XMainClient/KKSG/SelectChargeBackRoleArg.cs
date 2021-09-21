using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000521 RID: 1313
	[ProtoContract(Name = "SelectChargeBackRoleArg")]
	[Serializable]
	public class SelectChargeBackRoleArg : IExtensible
	{
		// Token: 0x170014A8 RID: 5288
		// (get) Token: 0x06004395 RID: 17301 RVA: 0x00080950 File Offset: 0x0007EB50
		// (set) Token: 0x06004396 RID: 17302 RVA: 0x0008097D File Offset: 0x0007EB7D
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

		// Token: 0x170014A9 RID: 5289
		// (get) Token: 0x06004397 RID: 17303 RVA: 0x0008098C File Offset: 0x0007EB8C
		// (set) Token: 0x06004398 RID: 17304 RVA: 0x000809AC File Offset: 0x0007EBAC
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

		// Token: 0x06004399 RID: 17305 RVA: 0x000809F0 File Offset: 0x0007EBF0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600439A RID: 17306 RVA: 0x00080A08 File Offset: 0x0007EC08
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x0600439B RID: 17307 RVA: 0x00080A14 File Offset: 0x0007EC14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010D7 RID: 4311
		private ulong? _roleid;

		// Token: 0x040010D8 RID: 4312
		private IExtension extensionObject;
	}
}
