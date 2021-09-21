using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B6 RID: 438
	[ProtoContract(Name = "GmfWaitFightArg")]
	[Serializable]
	public class GmfWaitFightArg : IExtensible
	{
		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x060019B2 RID: 6578 RVA: 0x00032FB4 File Offset: 0x000311B4
		// (set) Token: 0x060019B3 RID: 6579 RVA: 0x00032FE0 File Offset: 0x000311E0
		[ProtoMember(1, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x00032FF0 File Offset: 0x000311F0
		// (set) Token: 0x060019B5 RID: 6581 RVA: 0x00033010 File Offset: 0x00031210
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x00033054 File Offset: 0x00031254
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x060019B7 RID: 6583 RVA: 0x0003306C File Offset: 0x0003126C
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x060019B8 RID: 6584 RVA: 0x00033078 File Offset: 0x00031278
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000663 RID: 1635
		private uint? _lefttime;

		// Token: 0x04000664 RID: 1636
		private IExtension extensionObject;
	}
}
