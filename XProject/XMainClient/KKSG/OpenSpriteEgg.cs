using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022A RID: 554
	[ProtoContract(Name = "OpenSpriteEgg")]
	[Serializable]
	public class OpenSpriteEgg : IExtensible
	{
		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06001EFD RID: 7933 RVA: 0x0003CD1C File Offset: 0x0003AF1C
		// (set) Token: 0x06001EFE RID: 7934 RVA: 0x0003CD48 File Offset: 0x0003AF48
		[ProtoMember(1, IsRequired = false, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public uint itemid
		{
			get
			{
				return this._itemid ?? 0U;
			}
			set
			{
				this._itemid = new uint?(value);
			}
		}

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06001EFF RID: 7935 RVA: 0x0003CD58 File Offset: 0x0003AF58
		// (set) Token: 0x06001F00 RID: 7936 RVA: 0x0003CD78 File Offset: 0x0003AF78
		[XmlIgnore]
		[Browsable(false)]
		public bool itemidSpecified
		{
			get
			{
				return this._itemid != null;
			}
			set
			{
				bool flag = value == (this._itemid == null);
				if (flag)
				{
					this._itemid = (value ? new uint?(this.itemid) : null);
				}
			}
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x0003CDBC File Offset: 0x0003AFBC
		private bool ShouldSerializeitemid()
		{
			return this.itemidSpecified;
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x0003CDD4 File Offset: 0x0003AFD4
		private void Resetitemid()
		{
			this.itemidSpecified = false;
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x0003CDE0 File Offset: 0x0003AFE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007BC RID: 1980
		private uint? _itemid;

		// Token: 0x040007BD RID: 1981
		private IExtension extensionObject;
	}
}
