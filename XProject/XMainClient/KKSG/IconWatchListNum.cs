using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B7 RID: 439
	[ProtoContract(Name = "IconWatchListNum")]
	[Serializable]
	public class IconWatchListNum : IExtensible
	{
		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x060019BA RID: 6586 RVA: 0x00033098 File Offset: 0x00031298
		// (set) Token: 0x060019BB RID: 6587 RVA: 0x000330C4 File Offset: 0x000312C4
		[ProtoMember(1, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x060019BC RID: 6588 RVA: 0x000330D4 File Offset: 0x000312D4
		// (set) Token: 0x060019BD RID: 6589 RVA: 0x000330F4 File Offset: 0x000312F4
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x00033138 File Offset: 0x00031338
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x00033150 File Offset: 0x00031350
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x0003315C File Offset: 0x0003135C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000665 RID: 1637
		private uint? _num;

		// Token: 0x04000666 RID: 1638
		private IExtension extensionObject;
	}
}
