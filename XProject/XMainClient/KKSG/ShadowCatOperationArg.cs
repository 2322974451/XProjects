using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055E RID: 1374
	[ProtoContract(Name = "ShadowCatOperationArg")]
	[Serializable]
	public class ShadowCatOperationArg : IExtensible
	{
		// Token: 0x17001579 RID: 5497
		// (get) Token: 0x06004653 RID: 18003 RVA: 0x00085934 File Offset: 0x00083B34
		// (set) Token: 0x06004654 RID: 18004 RVA: 0x00085960 File Offset: 0x00083B60
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700157A RID: 5498
		// (get) Token: 0x06004655 RID: 18005 RVA: 0x00085970 File Offset: 0x00083B70
		// (set) Token: 0x06004656 RID: 18006 RVA: 0x00085990 File Offset: 0x00083B90
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

		// Token: 0x06004657 RID: 18007 RVA: 0x000859D4 File Offset: 0x00083BD4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x000859EC File Offset: 0x00083BEC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700157B RID: 5499
		// (get) Token: 0x06004659 RID: 18009 RVA: 0x000859F8 File Offset: 0x00083BF8
		// (set) Token: 0x0600465A RID: 18010 RVA: 0x00085A24 File Offset: 0x00083C24
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700157C RID: 5500
		// (get) Token: 0x0600465B RID: 18011 RVA: 0x00085A34 File Offset: 0x00083C34
		// (set) Token: 0x0600465C RID: 18012 RVA: 0x00085A54 File Offset: 0x00083C54
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

		// Token: 0x0600465D RID: 18013 RVA: 0x00085A98 File Offset: 0x00083C98
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x0600465E RID: 18014 RVA: 0x00085AB0 File Offset: 0x00083CB0
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x0600465F RID: 18015 RVA: 0x00085ABC File Offset: 0x00083CBC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400118A RID: 4490
		private uint? _type;

		// Token: 0x0400118B RID: 4491
		private uint? _num;

		// Token: 0x0400118C RID: 4492
		private IExtension extensionObject;
	}
}
