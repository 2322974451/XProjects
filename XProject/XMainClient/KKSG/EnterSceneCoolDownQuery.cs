using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200006B RID: 107
	[ProtoContract(Name = "EnterSceneCoolDownQuery")]
	[Serializable]
	public class EnterSceneCoolDownQuery : IExtensible
	{
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x000103BC File Offset: 0x0000E5BC
		[ProtoMember(1, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> groupid
		{
			get
			{
				return this._groupid;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x000103D4 File Offset: 0x0000E5D4
		// (set) Token: 0x06000717 RID: 1815 RVA: 0x00010400 File Offset: 0x0000E600
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00010410 File Offset: 0x0000E610
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x00010430 File Offset: 0x0000E630
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00010474 File Offset: 0x0000E674
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001048C File Offset: 0x0000E68C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00010498 File Offset: 0x0000E698
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001CA RID: 458
		private readonly List<uint> _groupid = new List<uint>();

		// Token: 0x040001CB RID: 459
		private uint? _type;

		// Token: 0x040001CC RID: 460
		private IExtension extensionObject;
	}
}
