using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C1 RID: 961
	[ProtoContract(Name = "ShareRandomGiftData")]
	[Serializable]
	public class ShareRandomGiftData : IExtensible
	{
		// Token: 0x17000FD4 RID: 4052
		// (get) Token: 0x0600335A RID: 13146 RVA: 0x00062A10 File Offset: 0x00060C10
		// (set) Token: 0x0600335B RID: 13147 RVA: 0x00062A3C File Offset: 0x00060C3C
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17000FD5 RID: 4053
		// (get) Token: 0x0600335C RID: 13148 RVA: 0x00062A4C File Offset: 0x00060C4C
		// (set) Token: 0x0600335D RID: 13149 RVA: 0x00062A6C File Offset: 0x00060C6C
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x0600335E RID: 13150 RVA: 0x00062AB0 File Offset: 0x00060CB0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600335F RID: 13151 RVA: 0x00062AC8 File Offset: 0x00060CC8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06003360 RID: 13152 RVA: 0x00062AD4 File Offset: 0x00060CD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CC4 RID: 3268
		private uint? _id;

		// Token: 0x04000CC5 RID: 3269
		private IExtension extensionObject;
	}
}
