using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000597 RID: 1431
	[ProtoContract(Name = "ClientReviveInfo")]
	[Serializable]
	public class ClientReviveInfo : IExtensible
	{
		// Token: 0x17001781 RID: 6017
		// (get) Token: 0x06004C55 RID: 19541 RVA: 0x00091334 File Offset: 0x0008F534
		// (set) Token: 0x06004C56 RID: 19542 RVA: 0x00091360 File Offset: 0x0008F560
		[ProtoMember(1, IsRequired = false, Name = "islimit", DataFormat = DataFormat.Default)]
		public bool islimit
		{
			get
			{
				return this._islimit ?? false;
			}
			set
			{
				this._islimit = new bool?(value);
			}
		}

		// Token: 0x17001782 RID: 6018
		// (get) Token: 0x06004C57 RID: 19543 RVA: 0x00091370 File Offset: 0x0008F570
		// (set) Token: 0x06004C58 RID: 19544 RVA: 0x00091390 File Offset: 0x0008F590
		[XmlIgnore]
		[Browsable(false)]
		public bool islimitSpecified
		{
			get
			{
				return this._islimit != null;
			}
			set
			{
				bool flag = value == (this._islimit == null);
				if (flag)
				{
					this._islimit = (value ? new bool?(this.islimit) : null);
				}
			}
		}

		// Token: 0x06004C59 RID: 19545 RVA: 0x000913D4 File Offset: 0x0008F5D4
		private bool ShouldSerializeislimit()
		{
			return this.islimitSpecified;
		}

		// Token: 0x06004C5A RID: 19546 RVA: 0x000913EC File Offset: 0x0008F5EC
		private void Resetislimit()
		{
			this.islimitSpecified = false;
		}

		// Token: 0x06004C5B RID: 19547 RVA: 0x000913F8 File Offset: 0x0008F5F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012F0 RID: 4848
		private bool? _islimit;

		// Token: 0x040012F1 RID: 4849
		private IExtension extensionObject;
	}
}
