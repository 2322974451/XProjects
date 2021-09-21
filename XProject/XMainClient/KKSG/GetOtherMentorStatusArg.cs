using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000308 RID: 776
	[ProtoContract(Name = "GetOtherMentorStatusArg")]
	[Serializable]
	public class GetOtherMentorStatusArg : IExtensible
	{
		// Token: 0x17000D28 RID: 3368
		// (get) Token: 0x06002A75 RID: 10869 RVA: 0x000524B0 File Offset: 0x000506B0
		// (set) Token: 0x06002A76 RID: 10870 RVA: 0x000524DD File Offset: 0x000506DD
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

		// Token: 0x17000D29 RID: 3369
		// (get) Token: 0x06002A77 RID: 10871 RVA: 0x000524EC File Offset: 0x000506EC
		// (set) Token: 0x06002A78 RID: 10872 RVA: 0x0005250C File Offset: 0x0005070C
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

		// Token: 0x06002A79 RID: 10873 RVA: 0x00052550 File Offset: 0x00050750
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x00052568 File Offset: 0x00050768
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x00052574 File Offset: 0x00050774
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A8A RID: 2698
		private ulong? _roleid;

		// Token: 0x04000A8B RID: 2699
		private IExtension extensionObject;
	}
}
