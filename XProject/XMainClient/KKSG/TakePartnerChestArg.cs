using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000317 RID: 791
	[ProtoContract(Name = "TakePartnerChestArg")]
	[Serializable]
	public class TakePartnerChestArg : IExtensible
	{
		// Token: 0x17000D70 RID: 3440
		// (get) Token: 0x06002B60 RID: 11104 RVA: 0x0005408C File Offset: 0x0005228C
		// (set) Token: 0x06002B61 RID: 11105 RVA: 0x000540B8 File Offset: 0x000522B8
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x17000D71 RID: 3441
		// (get) Token: 0x06002B62 RID: 11106 RVA: 0x000540C8 File Offset: 0x000522C8
		// (set) Token: 0x06002B63 RID: 11107 RVA: 0x000540E8 File Offset: 0x000522E8
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x0005412C File Offset: 0x0005232C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x00054144 File Offset: 0x00052344
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x00054150 File Offset: 0x00052350
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AC0 RID: 2752
		private uint? _index;

		// Token: 0x04000AC1 RID: 2753
		private IExtension extensionObject;
	}
}
