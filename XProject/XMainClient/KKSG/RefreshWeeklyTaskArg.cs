using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E3 RID: 1251
	[ProtoContract(Name = "RefreshWeeklyTaskArg")]
	[Serializable]
	public class RefreshWeeklyTaskArg : IExtensible
	{
		// Token: 0x170013CB RID: 5067
		// (get) Token: 0x060040AC RID: 16556 RVA: 0x0007B28C File Offset: 0x0007948C
		// (set) Token: 0x060040AD RID: 16557 RVA: 0x0007B2B8 File Offset: 0x000794B8
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

		// Token: 0x170013CC RID: 5068
		// (get) Token: 0x060040AE RID: 16558 RVA: 0x0007B2C8 File Offset: 0x000794C8
		// (set) Token: 0x060040AF RID: 16559 RVA: 0x0007B2E8 File Offset: 0x000794E8
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

		// Token: 0x060040B0 RID: 16560 RVA: 0x0007B32C File Offset: 0x0007952C
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x060040B1 RID: 16561 RVA: 0x0007B344 File Offset: 0x00079544
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x060040B2 RID: 16562 RVA: 0x0007B350 File Offset: 0x00079550
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400101E RID: 4126
		private uint? _index;

		// Token: 0x0400101F RID: 4127
		private IExtension extensionObject;
	}
}
