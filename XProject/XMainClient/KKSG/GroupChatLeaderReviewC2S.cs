using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000456 RID: 1110
	[ProtoContract(Name = "GroupChatLeaderReviewC2S")]
	[Serializable]
	public class GroupChatLeaderReviewC2S : IExtensible
	{
		// Token: 0x170011E6 RID: 4582
		// (get) Token: 0x06003A5C RID: 14940 RVA: 0x0006F998 File Offset: 0x0006DB98
		// (set) Token: 0x06003A5D RID: 14941 RVA: 0x0006F9C5 File Offset: 0x0006DBC5
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

		// Token: 0x170011E7 RID: 4583
		// (get) Token: 0x06003A5E RID: 14942 RVA: 0x0006F9D4 File Offset: 0x0006DBD4
		// (set) Token: 0x06003A5F RID: 14943 RVA: 0x0006F9F4 File Offset: 0x0006DBF4
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

		// Token: 0x06003A60 RID: 14944 RVA: 0x0006FA38 File Offset: 0x0006DC38
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003A61 RID: 14945 RVA: 0x0006FA50 File Offset: 0x0006DC50
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x170011E8 RID: 4584
		// (get) Token: 0x06003A62 RID: 14946 RVA: 0x0006FA5C File Offset: 0x0006DC5C
		// (set) Token: 0x06003A63 RID: 14947 RVA: 0x0006FA89 File Offset: 0x0006DC89
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

		// Token: 0x170011E9 RID: 4585
		// (get) Token: 0x06003A64 RID: 14948 RVA: 0x0006FA98 File Offset: 0x0006DC98
		// (set) Token: 0x06003A65 RID: 14949 RVA: 0x0006FAB8 File Offset: 0x0006DCB8
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

		// Token: 0x06003A66 RID: 14950 RVA: 0x0006FAFC File Offset: 0x0006DCFC
		private bool ShouldSerializeissueIndex()
		{
			return this.issueIndexSpecified;
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x0006FB14 File Offset: 0x0006DD14
		private void ResetissueIndex()
		{
			this.issueIndexSpecified = false;
		}

		// Token: 0x170011EA RID: 4586
		// (get) Token: 0x06003A68 RID: 14952 RVA: 0x0006FB20 File Offset: 0x0006DD20
		// (set) Token: 0x06003A69 RID: 14953 RVA: 0x0006FB4D File Offset: 0x0006DD4D
		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170011EB RID: 4587
		// (get) Token: 0x06003A6A RID: 14954 RVA: 0x0006FB5C File Offset: 0x0006DD5C
		// (set) Token: 0x06003A6B RID: 14955 RVA: 0x0006FB7C File Offset: 0x0006DD7C
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

		// Token: 0x06003A6C RID: 14956 RVA: 0x0006FBC0 File Offset: 0x0006DDC0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06003A6D RID: 14957 RVA: 0x0006FBD8 File Offset: 0x0006DDD8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170011EC RID: 4588
		// (get) Token: 0x06003A6E RID: 14958 RVA: 0x0006FBE4 File Offset: 0x0006DDE4
		// (set) Token: 0x06003A6F RID: 14959 RVA: 0x0006FC10 File Offset: 0x0006DE10
		[ProtoMember(4, IsRequired = false, Name = "isAgree", DataFormat = DataFormat.Default)]
		public bool isAgree
		{
			get
			{
				return this._isAgree ?? false;
			}
			set
			{
				this._isAgree = new bool?(value);
			}
		}

		// Token: 0x170011ED RID: 4589
		// (get) Token: 0x06003A70 RID: 14960 RVA: 0x0006FC20 File Offset: 0x0006DE20
		// (set) Token: 0x06003A71 RID: 14961 RVA: 0x0006FC40 File Offset: 0x0006DE40
		[XmlIgnore]
		[Browsable(false)]
		public bool isAgreeSpecified
		{
			get
			{
				return this._isAgree != null;
			}
			set
			{
				bool flag = value == (this._isAgree == null);
				if (flag)
				{
					this._isAgree = (value ? new bool?(this.isAgree) : null);
				}
			}
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x0006FC84 File Offset: 0x0006DE84
		private bool ShouldSerializeisAgree()
		{
			return this.isAgreeSpecified;
		}

		// Token: 0x06003A73 RID: 14963 RVA: 0x0006FC9C File Offset: 0x0006DE9C
		private void ResetisAgree()
		{
			this.isAgreeSpecified = false;
		}

		// Token: 0x06003A74 RID: 14964 RVA: 0x0006FCA8 File Offset: 0x0006DEA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E7D RID: 3709
		private ulong? _groupchatID;

		// Token: 0x04000E7E RID: 3710
		private ulong? _issueIndex;

		// Token: 0x04000E7F RID: 3711
		private ulong? _roleid;

		// Token: 0x04000E80 RID: 3712
		private bool? _isAgree;

		// Token: 0x04000E81 RID: 3713
		private IExtension extensionObject;
	}
}
