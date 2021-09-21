using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050A RID: 1290
	[ProtoContract(Name = "MulActivityIconSys")]
	[Serializable]
	public class MulActivityIconSys : IExtensible
	{
		// Token: 0x1700145A RID: 5210
		// (get) Token: 0x06004284 RID: 17028 RVA: 0x0007E9BC File Offset: 0x0007CBBC
		// (set) Token: 0x06004285 RID: 17029 RVA: 0x0007E9E8 File Offset: 0x0007CBE8
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

		// Token: 0x1700145B RID: 5211
		// (get) Token: 0x06004286 RID: 17030 RVA: 0x0007E9F8 File Offset: 0x0007CBF8
		// (set) Token: 0x06004287 RID: 17031 RVA: 0x0007EA18 File Offset: 0x0007CC18
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

		// Token: 0x06004288 RID: 17032 RVA: 0x0007EA5C File Offset: 0x0007CC5C
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06004289 RID: 17033 RVA: 0x0007EA74 File Offset: 0x0007CC74
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x0600428A RID: 17034 RVA: 0x0007EA80 File Offset: 0x0007CC80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001097 RID: 4247
		private uint? _id;

		// Token: 0x04001098 RID: 4248
		private IExtension extensionObject;
	}
}
