using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200045E RID: 1118
	[ProtoContract(Name = "GroupChatQuitC2S")]
	[Serializable]
	public class GroupChatQuitC2S : IExtensible
	{
		// Token: 0x17001201 RID: 4609
		// (get) Token: 0x06003AB7 RID: 15031 RVA: 0x00070444 File Offset: 0x0006E644
		// (set) Token: 0x06003AB8 RID: 15032 RVA: 0x00070471 File Offset: 0x0006E671
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

		// Token: 0x17001202 RID: 4610
		// (get) Token: 0x06003AB9 RID: 15033 RVA: 0x00070480 File Offset: 0x0006E680
		// (set) Token: 0x06003ABA RID: 15034 RVA: 0x000704A0 File Offset: 0x0006E6A0
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

		// Token: 0x06003ABB RID: 15035 RVA: 0x000704E4 File Offset: 0x0006E6E4
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x000704FC File Offset: 0x0006E6FC
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x00070508 File Offset: 0x0006E708
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E94 RID: 3732
		private ulong? _groupchatID;

		// Token: 0x04000E95 RID: 3733
		private IExtension extensionObject;
	}
}
