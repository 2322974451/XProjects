using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000466 RID: 1126
	[ProtoContract(Name = "GroupChatManagerPtc")]
	[Serializable]
	public class GroupChatManagerPtc : IExtensible
	{
		// Token: 0x17001215 RID: 4629
		// (get) Token: 0x06003AFF RID: 15103 RVA: 0x00070C70 File Offset: 0x0006EE70
		// (set) Token: 0x06003B00 RID: 15104 RVA: 0x00070C9D File Offset: 0x0006EE9D
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

		// Token: 0x17001216 RID: 4630
		// (get) Token: 0x06003B01 RID: 15105 RVA: 0x00070CAC File Offset: 0x0006EEAC
		// (set) Token: 0x06003B02 RID: 15106 RVA: 0x00070CCC File Offset: 0x0006EECC
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

		// Token: 0x06003B03 RID: 15107 RVA: 0x00070D10 File Offset: 0x0006EF10
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003B04 RID: 15108 RVA: 0x00070D28 File Offset: 0x0006EF28
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x17001217 RID: 4631
		// (get) Token: 0x06003B05 RID: 15109 RVA: 0x00070D34 File Offset: 0x0006EF34
		[ProtoMember(2, Name = "addrolelist", DataFormat = DataFormat.Default)]
		public List<GroupChatPlayerInfo> addrolelist
		{
			get
			{
				return this._addrolelist;
			}
		}

		// Token: 0x17001218 RID: 4632
		// (get) Token: 0x06003B06 RID: 15110 RVA: 0x00070D4C File Offset: 0x0006EF4C
		[ProtoMember(3, Name = "subrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> subrolelist
		{
			get
			{
				return this._subrolelist;
			}
		}

		// Token: 0x06003B07 RID: 15111 RVA: 0x00070D64 File Offset: 0x0006EF64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EA7 RID: 3751
		private ulong? _groupchatID;

		// Token: 0x04000EA8 RID: 3752
		private readonly List<GroupChatPlayerInfo> _addrolelist = new List<GroupChatPlayerInfo>();

		// Token: 0x04000EA9 RID: 3753
		private readonly List<ulong> _subrolelist = new List<ulong>();

		// Token: 0x04000EAA RID: 3754
		private IExtension extensionObject;
	}
}
