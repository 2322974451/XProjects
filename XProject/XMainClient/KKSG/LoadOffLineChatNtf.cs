using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B1 RID: 433
	[ProtoContract(Name = "LoadOffLineChatNtf")]
	[Serializable]
	public class LoadOffLineChatNtf : IExtensible
	{
		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06001989 RID: 6537 RVA: 0x00032B14 File Offset: 0x00030D14
		// (set) Token: 0x0600198A RID: 6538 RVA: 0x00032B41 File Offset: 0x00030D41
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x0600198B RID: 6539 RVA: 0x00032B50 File Offset: 0x00030D50
		// (set) Token: 0x0600198C RID: 6540 RVA: 0x00032B70 File Offset: 0x00030D70
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x0600198D RID: 6541 RVA: 0x00032BB4 File Offset: 0x00030DB4
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x0600198E RID: 6542 RVA: 0x00032BCC File Offset: 0x00030DCC
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x0600198F RID: 6543 RVA: 0x00032BD8 File Offset: 0x00030DD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000658 RID: 1624
		private ulong? _roleID;

		// Token: 0x04000659 RID: 1625
		private IExtension extensionObject;
	}
}
