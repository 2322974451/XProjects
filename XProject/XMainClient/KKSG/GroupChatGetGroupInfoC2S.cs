using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045A RID: 1114
	[ProtoContract(Name = "GroupChatGetGroupInfoC2S")]
	[Serializable]
	public class GroupChatGetGroupInfoC2S : IExtensible
	{
		// Token: 0x170011F6 RID: 4598
		// (get) Token: 0x06003A94 RID: 14996 RVA: 0x00070038 File Offset: 0x0006E238
		// (set) Token: 0x06003A95 RID: 14997 RVA: 0x00070065 File Offset: 0x0006E265
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

		// Token: 0x170011F7 RID: 4599
		// (get) Token: 0x06003A96 RID: 14998 RVA: 0x00070074 File Offset: 0x0006E274
		// (set) Token: 0x06003A97 RID: 14999 RVA: 0x00070094 File Offset: 0x0006E294
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

		// Token: 0x06003A98 RID: 15000 RVA: 0x000700D8 File Offset: 0x0006E2D8
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003A99 RID: 15001 RVA: 0x000700F0 File Offset: 0x0006E2F0
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x06003A9A RID: 15002 RVA: 0x000700FC File Offset: 0x0006E2FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E89 RID: 3721
		private ulong? _groupchatID;

		// Token: 0x04000E8A RID: 3722
		private IExtension extensionObject;
	}
}
