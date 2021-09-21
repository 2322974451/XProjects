using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000442 RID: 1090
	[ProtoContract(Name = "MobaHintNtf")]
	[Serializable]
	public class MobaHintNtf : IExtensible
	{
		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x06003983 RID: 14723 RVA: 0x0006E064 File Offset: 0x0006C264
		// (set) Token: 0x06003984 RID: 14724 RVA: 0x0006E090 File Offset: 0x0006C290
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x06003985 RID: 14725 RVA: 0x0006E0A0 File Offset: 0x0006C2A0
		// (set) Token: 0x06003986 RID: 14726 RVA: 0x0006E0C0 File Offset: 0x0006C2C0
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
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x06003987 RID: 14727 RVA: 0x0006E104 File Offset: 0x0006C304
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06003988 RID: 14728 RVA: 0x0006E11C File Offset: 0x0006C31C
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06003989 RID: 14729 RVA: 0x0006E128 File Offset: 0x0006C328
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E46 RID: 3654
		private int? _index;

		// Token: 0x04000E47 RID: 3655
		private IExtension extensionObject;
	}
}
