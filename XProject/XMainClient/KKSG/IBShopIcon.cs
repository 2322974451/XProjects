using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000216 RID: 534
	[ProtoContract(Name = "IBShopIcon")]
	[Serializable]
	public class IBShopIcon : IExtensible
	{
		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x06001DFA RID: 7674 RVA: 0x0003AEB8 File Offset: 0x000390B8
		[ProtoMember(1, Name = "viptag", DataFormat = DataFormat.TwosComplement)]
		public List<uint> viptag
		{
			get
			{
				return this._viptag;
			}
		}

		// Token: 0x17000961 RID: 2401
		// (get) Token: 0x06001DFB RID: 7675 RVA: 0x0003AED0 File Offset: 0x000390D0
		// (set) Token: 0x06001DFC RID: 7676 RVA: 0x0003AEFC File Offset: 0x000390FC
		[ProtoMember(2, IsRequired = false, Name = "limittag", DataFormat = DataFormat.Default)]
		public bool limittag
		{
			get
			{
				return this._limittag ?? false;
			}
			set
			{
				this._limittag = new bool?(value);
			}
		}

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06001DFD RID: 7677 RVA: 0x0003AF0C File Offset: 0x0003910C
		// (set) Token: 0x06001DFE RID: 7678 RVA: 0x0003AF2C File Offset: 0x0003912C
		[XmlIgnore]
		[Browsable(false)]
		public bool limittagSpecified
		{
			get
			{
				return this._limittag != null;
			}
			set
			{
				bool flag = value == (this._limittag == null);
				if (flag)
				{
					this._limittag = (value ? new bool?(this.limittag) : null);
				}
			}
		}

		// Token: 0x06001DFF RID: 7679 RVA: 0x0003AF70 File Offset: 0x00039170
		private bool ShouldSerializelimittag()
		{
			return this.limittagSpecified;
		}

		// Token: 0x06001E00 RID: 7680 RVA: 0x0003AF88 File Offset: 0x00039188
		private void Resetlimittag()
		{
			this.limittagSpecified = false;
		}

		// Token: 0x06001E01 RID: 7681 RVA: 0x0003AF94 File Offset: 0x00039194
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400077E RID: 1918
		private readonly List<uint> _viptag = new List<uint>();

		// Token: 0x0400077F RID: 1919
		private bool? _limittag;

		// Token: 0x04000780 RID: 1920
		private IExtension extensionObject;
	}
}
