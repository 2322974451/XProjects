using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C8 RID: 968
	[ProtoContract(Name = "WorldBossGuildAddAttrSyncClient")]
	[Serializable]
	public class WorldBossGuildAddAttrSyncClient : IExtensible
	{
		// Token: 0x17000FE2 RID: 4066
		// (get) Token: 0x06003392 RID: 13202 RVA: 0x00062FFC File Offset: 0x000611FC
		// (set) Token: 0x06003393 RID: 13203 RVA: 0x00063028 File Offset: 0x00061228
		[ProtoMember(1, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000FE3 RID: 4067
		// (get) Token: 0x06003394 RID: 13204 RVA: 0x00063038 File Offset: 0x00061238
		// (set) Token: 0x06003395 RID: 13205 RVA: 0x00063058 File Offset: 0x00061258
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x0006309C File Offset: 0x0006129C
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x000630B4 File Offset: 0x000612B4
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x000630C0 File Offset: 0x000612C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CD2 RID: 3282
		private uint? _count;

		// Token: 0x04000CD3 RID: 3283
		private IExtension extensionObject;
	}
}
