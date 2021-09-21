using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000458 RID: 1112
	[ProtoContract(Name = "GroupChatPlayerApplyC2S")]
	[Serializable]
	public class GroupChatPlayerApplyC2S : IExtensible
	{
		// Token: 0x170011F0 RID: 4592
		// (get) Token: 0x06003A7E RID: 14974 RVA: 0x0006FDAC File Offset: 0x0006DFAC
		// (set) Token: 0x06003A7F RID: 14975 RVA: 0x0006FDD9 File Offset: 0x0006DFD9
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

		// Token: 0x170011F1 RID: 4593
		// (get) Token: 0x06003A80 RID: 14976 RVA: 0x0006FDE8 File Offset: 0x0006DFE8
		// (set) Token: 0x06003A81 RID: 14977 RVA: 0x0006FE08 File Offset: 0x0006E008
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

		// Token: 0x06003A82 RID: 14978 RVA: 0x0006FE4C File Offset: 0x0006E04C
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003A83 RID: 14979 RVA: 0x0006FE64 File Offset: 0x0006E064
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x170011F2 RID: 4594
		// (get) Token: 0x06003A84 RID: 14980 RVA: 0x0006FE70 File Offset: 0x0006E070
		// (set) Token: 0x06003A85 RID: 14981 RVA: 0x0006FE9D File Offset: 0x0006E09D
		[ProtoMember(2, IsRequired = false, Name = "issueIndex", DataFormat = DataFormat.TwosComplement)]
		public ulong issueIndex
		{
			get
			{
				return this._issueIndex ?? 0UL;
			}
			set
			{
				this._issueIndex = new ulong?(value);
			}
		}

		// Token: 0x170011F3 RID: 4595
		// (get) Token: 0x06003A86 RID: 14982 RVA: 0x0006FEAC File Offset: 0x0006E0AC
		// (set) Token: 0x06003A87 RID: 14983 RVA: 0x0006FECC File Offset: 0x0006E0CC
		[XmlIgnore]
		[Browsable(false)]
		public bool issueIndexSpecified
		{
			get
			{
				return this._issueIndex != null;
			}
			set
			{
				bool flag = value == (this._issueIndex == null);
				if (flag)
				{
					this._issueIndex = (value ? new ulong?(this.issueIndex) : null);
				}
			}
		}

		// Token: 0x06003A88 RID: 14984 RVA: 0x0006FF10 File Offset: 0x0006E110
		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		// Token: 0x06003A89 RID: 14985 RVA: 0x0006FF28 File Offset: 0x0006E128
		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		// Token: 0x06003A8A RID: 14986 RVA: 0x0006FF34 File Offset: 0x0006E134
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E84 RID: 3716
		private ulong? _groupchatID;

		// Token: 0x04000E85 RID: 3717
		private ulong? _issueIndex;

		// Token: 0x04000E86 RID: 3718
		private IExtension extensionObject;
	}
}
