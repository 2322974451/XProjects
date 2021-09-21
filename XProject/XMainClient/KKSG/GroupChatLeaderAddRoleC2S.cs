using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200047C RID: 1148
	[ProtoContract(Name = "GroupChatLeaderAddRoleC2S")]
	[Serializable]
	public class GroupChatLeaderAddRoleC2S : IExtensible
	{
		// Token: 0x17001266 RID: 4710
		// (get) Token: 0x06003C04 RID: 15364 RVA: 0x00072AA0 File Offset: 0x00070CA0
		// (set) Token: 0x06003C05 RID: 15365 RVA: 0x00072ACD File Offset: 0x00070CCD
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

		// Token: 0x17001267 RID: 4711
		// (get) Token: 0x06003C06 RID: 15366 RVA: 0x00072ADC File Offset: 0x00070CDC
		// (set) Token: 0x06003C07 RID: 15367 RVA: 0x00072AFC File Offset: 0x00070CFC
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

		// Token: 0x06003C08 RID: 15368 RVA: 0x00072B40 File Offset: 0x00070D40
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003C09 RID: 15369 RVA: 0x00072B58 File Offset: 0x00070D58
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x17001268 RID: 4712
		// (get) Token: 0x06003C0A RID: 15370 RVA: 0x00072B64 File Offset: 0x00070D64
		// (set) Token: 0x06003C0B RID: 15371 RVA: 0x00072B91 File Offset: 0x00070D91
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

		// Token: 0x17001269 RID: 4713
		// (get) Token: 0x06003C0C RID: 15372 RVA: 0x00072BA0 File Offset: 0x00070DA0
		// (set) Token: 0x06003C0D RID: 15373 RVA: 0x00072BC0 File Offset: 0x00070DC0
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

		// Token: 0x06003C0E RID: 15374 RVA: 0x00072C04 File Offset: 0x00070E04
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003C0F RID: 15375 RVA: 0x00072C1C File Offset: 0x00070E1C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700126A RID: 4714
		// (get) Token: 0x06003C10 RID: 15376 RVA: 0x00072C28 File Offset: 0x00070E28
		// (set) Token: 0x06003C11 RID: 15377 RVA: 0x00072C55 File Offset: 0x00070E55
		[ProtoMember(3, IsRequired = false, Name = "roleIssueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong roleIssueIndex
		{
			get
			{
				return this._roleIssueIndex ?? 0UL;
			}
			set
			{
				this._roleIssueIndex = new ulong?(value);
			}
		}

		// Token: 0x1700126B RID: 4715
		// (get) Token: 0x06003C12 RID: 15378 RVA: 0x00072C64 File Offset: 0x00070E64
		// (set) Token: 0x06003C13 RID: 15379 RVA: 0x00072C84 File Offset: 0x00070E84
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIssueIndexSpecified
		{
			get
			{
				return this._roleIssueIndex != null;
			}
			set
			{
				bool flag = value == (this._roleIssueIndex == null);
				if (flag)
				{
					this._roleIssueIndex = (value ? new ulong?(this.roleIssueIndex) : null);
				}
			}
		}

		// Token: 0x06003C14 RID: 15380 RVA: 0x00072CC8 File Offset: 0x00070EC8
		private bool ShouldSerializeroleIssueIndex()
		{
			return this.roleIssueIndexSpecified;
		}

		// Token: 0x06003C15 RID: 15381 RVA: 0x00072CE0 File Offset: 0x00070EE0
		private void ResetroleIssueIndex()
		{
			this.roleIssueIndexSpecified = false;
		}

		// Token: 0x06003C16 RID: 15382 RVA: 0x00072CEC File Offset: 0x00070EEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EED RID: 3821
		private ulong? _groupchatID;

		// Token: 0x04000EEE RID: 3822
		private ulong? _roleid;

		// Token: 0x04000EEF RID: 3823
		private ulong? _roleIssueIndex;

		// Token: 0x04000EF0 RID: 3824
		private IExtension extensionObject;
	}
}
