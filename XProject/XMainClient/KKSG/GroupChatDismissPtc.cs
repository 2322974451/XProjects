using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000468 RID: 1128
	[ProtoContract(Name = "GroupChatDismissPtc")]
	[Serializable]
	public class GroupChatDismissPtc : IExtensible
	{
		// Token: 0x1700121D RID: 4637
		// (get) Token: 0x06003B17 RID: 15127 RVA: 0x00070F2C File Offset: 0x0006F12C
		// (set) Token: 0x06003B18 RID: 15128 RVA: 0x00070F59 File Offset: 0x0006F159
		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		// Token: 0x1700121E RID: 4638
		// (get) Token: 0x06003B19 RID: 15129 RVA: 0x00070F68 File Offset: 0x0006F168
		// (set) Token: 0x06003B1A RID: 15130 RVA: 0x00070F88 File Offset: 0x0006F188
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		// Token: 0x06003B1B RID: 15131 RVA: 0x00070FCC File Offset: 0x0006F1CC
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003B1C RID: 15132 RVA: 0x00070FE4 File Offset: 0x0006F1E4
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x1700121F RID: 4639
		// (get) Token: 0x06003B1D RID: 15133 RVA: 0x00070FF0 File Offset: 0x0006F1F0
		// (set) Token: 0x06003B1E RID: 15134 RVA: 0x0007101D File Offset: 0x0006F21D
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

		// Token: 0x17001220 RID: 4640
		// (get) Token: 0x06003B1F RID: 15135 RVA: 0x0007102C File Offset: 0x0006F22C
		// (set) Token: 0x06003B20 RID: 15136 RVA: 0x0007104C File Offset: 0x0006F24C
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

		// Token: 0x06003B21 RID: 15137 RVA: 0x00071090 File Offset: 0x0006F290
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003B22 RID: 15138 RVA: 0x000710A8 File Offset: 0x0006F2A8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06003B23 RID: 15139 RVA: 0x000710B4 File Offset: 0x0006F2B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EAE RID: 3758
		private ulong? _groupchatID;

		// Token: 0x04000EAF RID: 3759
		private ulong? _roleid;

		// Token: 0x04000EB0 RID: 3760
		private IExtension extensionObject;
	}
}
