using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004A6 RID: 1190
	[ProtoContract(Name = "UpgradeEquipArg")]
	[Serializable]
	public class UpgradeEquipArg : IExtensible
	{
		// Token: 0x170012F8 RID: 4856
		// (get) Token: 0x06003DEA RID: 15850 RVA: 0x00076210 File Offset: 0x00074410
		// (set) Token: 0x06003DEB RID: 15851 RVA: 0x0007623D File Offset: 0x0007443D
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x170012F9 RID: 4857
		// (get) Token: 0x06003DEC RID: 15852 RVA: 0x0007624C File Offset: 0x0007444C
		// (set) Token: 0x06003DED RID: 15853 RVA: 0x0007626C File Offset: 0x0007446C
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06003DEE RID: 15854 RVA: 0x000762B0 File Offset: 0x000744B0
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06003DEF RID: 15855 RVA: 0x000762C8 File Offset: 0x000744C8
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06003DF0 RID: 15856 RVA: 0x000762D4 File Offset: 0x000744D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F6B RID: 3947
		private ulong? _uid;

		// Token: 0x04000F6C RID: 3948
		private IExtension extensionObject;
	}
}
