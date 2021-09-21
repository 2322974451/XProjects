using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045C RID: 1116
	[ProtoContract(Name = "GroupChatManagerC2S")]
	[Serializable]
	public class GroupChatManagerC2S : IExtensible
	{
		// Token: 0x170011FB RID: 4603
		// (get) Token: 0x06003AA5 RID: 15013 RVA: 0x0007024C File Offset: 0x0006E44C
		// (set) Token: 0x06003AA6 RID: 15014 RVA: 0x00070279 File Offset: 0x0006E479
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

		// Token: 0x170011FC RID: 4604
		// (get) Token: 0x06003AA7 RID: 15015 RVA: 0x00070288 File Offset: 0x0006E488
		// (set) Token: 0x06003AA8 RID: 15016 RVA: 0x000702A8 File Offset: 0x0006E4A8
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

		// Token: 0x06003AA9 RID: 15017 RVA: 0x000702EC File Offset: 0x0006E4EC
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003AAA RID: 15018 RVA: 0x00070304 File Offset: 0x0006E504
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x170011FD RID: 4605
		// (get) Token: 0x06003AAB RID: 15019 RVA: 0x00070310 File Offset: 0x0006E510
		[ProtoMember(2, Name = "subrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> subrolelist
		{
			get
			{
				return this._subrolelist;
			}
		}

		// Token: 0x170011FE RID: 4606
		// (get) Token: 0x06003AAC RID: 15020 RVA: 0x00070328 File Offset: 0x0006E528
		[ProtoMember(3, Name = "addrolelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> addrolelist
		{
			get
			{
				return this._addrolelist;
			}
		}

		// Token: 0x06003AAD RID: 15021 RVA: 0x00070340 File Offset: 0x0006E540
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E8E RID: 3726
		private ulong? _groupchatID;

		// Token: 0x04000E8F RID: 3727
		private readonly List<ulong> _subrolelist = new List<ulong>();

		// Token: 0x04000E90 RID: 3728
		private readonly List<ulong> _addrolelist = new List<ulong>();

		// Token: 0x04000E91 RID: 3729
		private IExtension extensionObject;
	}
}
