using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000467 RID: 1127
	[ProtoContract(Name = "GroupChatQuitPtc")]
	[Serializable]
	public class GroupChatQuitPtc : IExtensible
	{
		// Token: 0x17001219 RID: 4633
		// (get) Token: 0x06003B09 RID: 15113 RVA: 0x00070D84 File Offset: 0x0006EF84
		// (set) Token: 0x06003B0A RID: 15114 RVA: 0x00070DB1 File Offset: 0x0006EFB1
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

		// Token: 0x1700121A RID: 4634
		// (get) Token: 0x06003B0B RID: 15115 RVA: 0x00070DC0 File Offset: 0x0006EFC0
		// (set) Token: 0x06003B0C RID: 15116 RVA: 0x00070DE0 File Offset: 0x0006EFE0
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

		// Token: 0x06003B0D RID: 15117 RVA: 0x00070E24 File Offset: 0x0006F024
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003B0E RID: 15118 RVA: 0x00070E3C File Offset: 0x0006F03C
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x1700121B RID: 4635
		// (get) Token: 0x06003B0F RID: 15119 RVA: 0x00070E48 File Offset: 0x0006F048
		// (set) Token: 0x06003B10 RID: 15120 RVA: 0x00070E75 File Offset: 0x0006F075
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

		// Token: 0x1700121C RID: 4636
		// (get) Token: 0x06003B11 RID: 15121 RVA: 0x00070E84 File Offset: 0x0006F084
		// (set) Token: 0x06003B12 RID: 15122 RVA: 0x00070EA4 File Offset: 0x0006F0A4
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

		// Token: 0x06003B13 RID: 15123 RVA: 0x00070EE8 File Offset: 0x0006F0E8
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003B14 RID: 15124 RVA: 0x00070F00 File Offset: 0x0006F100
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06003B15 RID: 15125 RVA: 0x00070F0C File Offset: 0x0006F10C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EAB RID: 3755
		private ulong? _groupchatID;

		// Token: 0x04000EAC RID: 3756
		private ulong? _roleid;

		// Token: 0x04000EAD RID: 3757
		private IExtension extensionObject;
	}
}
