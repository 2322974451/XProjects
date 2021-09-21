using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F0 RID: 1008
	[ProtoContract(Name = "GuildCampPartyReqExchangeReq")]
	[Serializable]
	public class GuildCampPartyReqExchangeReq : IExtensible
	{
		// Token: 0x17001072 RID: 4210
		// (get) Token: 0x0600357B RID: 13691 RVA: 0x000667C0 File Offset: 0x000649C0
		// (set) Token: 0x0600357C RID: 13692 RVA: 0x000667ED File Offset: 0x000649ED
		[ProtoMember(1, IsRequired = false, Name = "role_id", DataFormat = DataFormat.TwosComplement)]
		public ulong role_id
		{
			get
			{
				return this._role_id ?? 0UL;
			}
			set
			{
				this._role_id = new ulong?(value);
			}
		}

		// Token: 0x17001073 RID: 4211
		// (get) Token: 0x0600357D RID: 13693 RVA: 0x000667FC File Offset: 0x000649FC
		// (set) Token: 0x0600357E RID: 13694 RVA: 0x0006681C File Offset: 0x00064A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool role_idSpecified
		{
			get
			{
				return this._role_id != null;
			}
			set
			{
				bool flag = value == (this._role_id == null);
				if (flag)
				{
					this._role_id = (value ? new ulong?(this.role_id) : null);
				}
			}
		}

		// Token: 0x0600357F RID: 13695 RVA: 0x00066860 File Offset: 0x00064A60
		private bool ShouldSerializerole_id()
		{
			return this.role_idSpecified;
		}

		// Token: 0x06003580 RID: 13696 RVA: 0x00066878 File Offset: 0x00064A78
		private void Resetrole_id()
		{
			this.role_idSpecified = false;
		}

		// Token: 0x06003581 RID: 13697 RVA: 0x00066884 File Offset: 0x00064A84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D49 RID: 3401
		private ulong? _role_id;

		// Token: 0x04000D4A RID: 3402
		private IExtension extensionObject;
	}
}
