using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AC RID: 940
	[ProtoContract(Name = "ChangeSkillSetArg")]
	[Serializable]
	public class ChangeSkillSetArg : IExtensible
	{
		// Token: 0x17000F92 RID: 3986
		// (get) Token: 0x06003273 RID: 12915 RVA: 0x00061098 File Offset: 0x0005F298
		// (set) Token: 0x06003274 RID: 12916 RVA: 0x000610C4 File Offset: 0x0005F2C4
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

		// Token: 0x17000F93 RID: 3987
		// (get) Token: 0x06003275 RID: 12917 RVA: 0x000610D4 File Offset: 0x0005F2D4
		// (set) Token: 0x06003276 RID: 12918 RVA: 0x000610F4 File Offset: 0x0005F2F4
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

		// Token: 0x06003277 RID: 12919 RVA: 0x00061138 File Offset: 0x0005F338
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x00061150 File Offset: 0x0005F350
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x06003279 RID: 12921 RVA: 0x0006115C File Offset: 0x0005F35C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C8B RID: 3211
		private uint? _index;

		// Token: 0x04000C8C RID: 3212
		private IExtension extensionObject;
	}
}
