using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001AC RID: 428
	[ProtoContract(Name = "AddAttrCount")]
	[Serializable]
	public class AddAttrCount : IExtensible
	{
		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x0600194D RID: 6477 RVA: 0x000323FC File Offset: 0x000305FC
		// (set) Token: 0x0600194E RID: 6478 RVA: 0x00032428 File Offset: 0x00030628
		[ProtoMember(1, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x0600194F RID: 6479 RVA: 0x00032438 File Offset: 0x00030638
		// (set) Token: 0x06001950 RID: 6480 RVA: 0x00032458 File Offset: 0x00030658
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x0003249C File Offset: 0x0003069C
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x000324B4 File Offset: 0x000306B4
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x000324C0 File Offset: 0x000306C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000649 RID: 1609
		private uint? _count;

		// Token: 0x0400064A RID: 1610
		private IExtension extensionObject;
	}
}
