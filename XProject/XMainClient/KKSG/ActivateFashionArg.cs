using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E9 RID: 1001
	[ProtoContract(Name = "ActivateFashionArg")]
	[Serializable]
	public class ActivateFashionArg : IExtensible
	{
		// Token: 0x1700105E RID: 4190
		// (get) Token: 0x06003535 RID: 13621 RVA: 0x00065FA4 File Offset: 0x000641A4
		// (set) Token: 0x06003536 RID: 13622 RVA: 0x00065FD0 File Offset: 0x000641D0
		[ProtoMember(1, IsRequired = false, Name = "suit_id", DataFormat = DataFormat.TwosComplement)]
		public uint suit_id
		{
			get
			{
				return this._suit_id ?? 0U;
			}
			set
			{
				this._suit_id = new uint?(value);
			}
		}

		// Token: 0x1700105F RID: 4191
		// (get) Token: 0x06003537 RID: 13623 RVA: 0x00065FE0 File Offset: 0x000641E0
		// (set) Token: 0x06003538 RID: 13624 RVA: 0x00066000 File Offset: 0x00064200
		[XmlIgnore]
		[Browsable(false)]
		public bool suit_idSpecified
		{
			get
			{
				return this._suit_id != null;
			}
			set
			{
				bool flag = value == (this._suit_id == null);
				if (flag)
				{
					this._suit_id = (value ? new uint?(this.suit_id) : null);
				}
			}
		}

		// Token: 0x06003539 RID: 13625 RVA: 0x00066044 File Offset: 0x00064244
		private bool ShouldSerializesuit_id()
		{
			return this.suit_idSpecified;
		}

		// Token: 0x0600353A RID: 13626 RVA: 0x0006605C File Offset: 0x0006425C
		private void Resetsuit_id()
		{
			this.suit_idSpecified = false;
		}

		// Token: 0x0600353B RID: 13627 RVA: 0x00066068 File Offset: 0x00064268
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D37 RID: 3383
		private uint? _suit_id;

		// Token: 0x04000D38 RID: 3384
		private IExtension extensionObject;
	}
}
