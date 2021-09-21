using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000139 RID: 313
	[ProtoContract(Name = "AgreeQAReq")]
	[Serializable]
	public class AgreeQAReq : IExtensible
	{
		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06001321 RID: 4897 RVA: 0x00026B5C File Offset: 0x00024D5C
		// (set) Token: 0x06001322 RID: 4898 RVA: 0x00026B88 File Offset: 0x00024D88
		[ProtoMember(1, IsRequired = false, Name = "agree", DataFormat = DataFormat.Default)]
		public bool agree
		{
			get
			{
				return this._agree ?? false;
			}
			set
			{
				this._agree = new bool?(value);
			}
		}

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x00026B98 File Offset: 0x00024D98
		// (set) Token: 0x06001324 RID: 4900 RVA: 0x00026BB8 File Offset: 0x00024DB8
		[XmlIgnore]
		[Browsable(false)]
		public bool agreeSpecified
		{
			get
			{
				return this._agree != null;
			}
			set
			{
				bool flag = value == (this._agree == null);
				if (flag)
				{
					this._agree = (value ? new bool?(this.agree) : null);
				}
			}
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x00026BFC File Offset: 0x00024DFC
		private bool ShouldSerializeagree()
		{
			return this.agreeSpecified;
		}

		// Token: 0x06001326 RID: 4902 RVA: 0x00026C14 File Offset: 0x00024E14
		private void Resetagree()
		{
			this.agreeSpecified = false;
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06001327 RID: 4903 RVA: 0x00026C20 File Offset: 0x00024E20
		// (set) Token: 0x06001328 RID: 4904 RVA: 0x00026C4C File Offset: 0x00024E4C
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

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x00026C5C File Offset: 0x00024E5C
		// (set) Token: 0x0600132A RID: 4906 RVA: 0x00026C7C File Offset: 0x00024E7C
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

		// Token: 0x0600132B RID: 4907 RVA: 0x00026CC0 File Offset: 0x00024EC0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x00026CD8 File Offset: 0x00024ED8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x0600132D RID: 4909 RVA: 0x00026CE4 File Offset: 0x00024EE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004C6 RID: 1222
		private bool? _agree;

		// Token: 0x040004C7 RID: 1223
		private uint? _type;

		// Token: 0x040004C8 RID: 1224
		private IExtension extensionObject;
	}
}
