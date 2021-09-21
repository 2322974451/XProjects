using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000A5 RID: 165
	[ProtoContract(Name = "GetOtherGuildBriefArg")]
	[Serializable]
	public class GetOtherGuildBriefArg : IExtensible
	{
		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x00018208 File Offset: 0x00016408
		// (set) Token: 0x06000B48 RID: 2888 RVA: 0x00018235 File Offset: 0x00016435
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

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x00018244 File Offset: 0x00016444
		// (set) Token: 0x06000B4A RID: 2890 RVA: 0x00018264 File Offset: 0x00016464
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

		// Token: 0x06000B4B RID: 2891 RVA: 0x000182A8 File Offset: 0x000164A8
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x000182C0 File Offset: 0x000164C0
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x000182CC File Offset: 0x000164CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002D3 RID: 723
		private ulong? _roleid;

		// Token: 0x040002D4 RID: 724
		private IExtension extensionObject;
	}
}
