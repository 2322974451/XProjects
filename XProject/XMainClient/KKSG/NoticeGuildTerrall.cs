using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035A RID: 858
	[ProtoContract(Name = "NoticeGuildTerrall")]
	[Serializable]
	public class NoticeGuildTerrall : IExtensible
	{
		// Token: 0x17000E95 RID: 3733
		// (get) Token: 0x06002F0A RID: 12042 RVA: 0x0005AD80 File Offset: 0x00058F80
		// (set) Token: 0x06002F0B RID: 12043 RVA: 0x0005ADAC File Offset: 0x00058FAC
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

		// Token: 0x17000E96 RID: 3734
		// (get) Token: 0x06002F0C RID: 12044 RVA: 0x0005ADBC File Offset: 0x00058FBC
		// (set) Token: 0x06002F0D RID: 12045 RVA: 0x0005ADDC File Offset: 0x00058FDC
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

		// Token: 0x06002F0E RID: 12046 RVA: 0x0005AE20 File Offset: 0x00059020
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x0005AE38 File Offset: 0x00059038
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x06002F10 RID: 12048 RVA: 0x0005AE44 File Offset: 0x00059044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BAA RID: 2986
		private uint? _num;

		// Token: 0x04000BAB RID: 2987
		private IExtension extensionObject;
	}
}
