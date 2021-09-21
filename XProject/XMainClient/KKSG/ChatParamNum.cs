using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A5 RID: 1445
	[ProtoContract(Name = "ChatParamNum")]
	[Serializable]
	public class ChatParamNum : IExtensible
	{
		// Token: 0x17001827 RID: 6183
		// (get) Token: 0x06004E46 RID: 20038 RVA: 0x00094E64 File Offset: 0x00093064
		// (set) Token: 0x06004E47 RID: 20039 RVA: 0x00094E90 File Offset: 0x00093090
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

		// Token: 0x17001828 RID: 6184
		// (get) Token: 0x06004E48 RID: 20040 RVA: 0x00094EA0 File Offset: 0x000930A0
		// (set) Token: 0x06004E49 RID: 20041 RVA: 0x00094EC0 File Offset: 0x000930C0
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

		// Token: 0x06004E4A RID: 20042 RVA: 0x00094F04 File Offset: 0x00093104
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x00094F1C File Offset: 0x0009311C
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x00094F28 File Offset: 0x00093128
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400135D RID: 4957
		private uint? _num;

		// Token: 0x0400135E RID: 4958
		private IExtension extensionObject;
	}
}
