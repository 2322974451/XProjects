using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200022C RID: 556
	[ProtoContract(Name = "getguildbosstimeleftRes")]
	[Serializable]
	public class getguildbosstimeleftRes : IExtensible
	{
		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x06001F07 RID: 7943 RVA: 0x0003CE20 File Offset: 0x0003B020
		// (set) Token: 0x06001F08 RID: 7944 RVA: 0x0003CE4C File Offset: 0x0003B04C
		[ProtoMember(1, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06001F09 RID: 7945 RVA: 0x0003CE5C File Offset: 0x0003B05C
		// (set) Token: 0x06001F0A RID: 7946 RVA: 0x0003CE7C File Offset: 0x0003B07C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06001F0B RID: 7947 RVA: 0x0003CEC0 File Offset: 0x0003B0C0
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06001F0C RID: 7948 RVA: 0x0003CED8 File Offset: 0x0003B0D8
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06001F0D RID: 7949 RVA: 0x0003CEE4 File Offset: 0x0003B0E4
		// (set) Token: 0x06001F0E RID: 7950 RVA: 0x0003CF10 File Offset: 0x0003B110
		[ProtoMember(2, IsRequired = false, Name = "addAttrCount", DataFormat = DataFormat.TwosComplement)]
		public uint addAttrCount
		{
			get
			{
				return this._addAttrCount ?? 0U;
			}
			set
			{
				this._addAttrCount = new uint?(value);
			}
		}

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06001F0F RID: 7951 RVA: 0x0003CF20 File Offset: 0x0003B120
		// (set) Token: 0x06001F10 RID: 7952 RVA: 0x0003CF40 File Offset: 0x0003B140
		[XmlIgnore]
		[Browsable(false)]
		public bool addAttrCountSpecified
		{
			get
			{
				return this._addAttrCount != null;
			}
			set
			{
				bool flag = value == (this._addAttrCount == null);
				if (flag)
				{
					this._addAttrCount = (value ? new uint?(this.addAttrCount) : null);
				}
			}
		}

		// Token: 0x06001F11 RID: 7953 RVA: 0x0003CF84 File Offset: 0x0003B184
		private bool ShouldSerializeaddAttrCount()
		{
			return this.addAttrCountSpecified;
		}

		// Token: 0x06001F12 RID: 7954 RVA: 0x0003CF9C File Offset: 0x0003B19C
		private void ResetaddAttrCount()
		{
			this.addAttrCountSpecified = false;
		}

		// Token: 0x06001F13 RID: 7955 RVA: 0x0003CFA8 File Offset: 0x0003B1A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007BF RID: 1983
		private uint? _timeleft;

		// Token: 0x040007C0 RID: 1984
		private uint? _addAttrCount;

		// Token: 0x040007C1 RID: 1985
		private IExtension extensionObject;
	}
}
