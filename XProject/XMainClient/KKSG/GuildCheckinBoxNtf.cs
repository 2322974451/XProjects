using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B3 RID: 179
	[ProtoContract(Name = "GuildCheckinBoxNtf")]
	[Serializable]
	public class GuildCheckinBoxNtf : IExtensible
	{
		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00019E14 File Offset: 0x00018014
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x00019E40 File Offset: 0x00018040
		[ProtoMember(1, IsRequired = false, Name = "processbar", DataFormat = DataFormat.TwosComplement)]
		public uint processbar
		{
			get
			{
				return this._processbar ?? 0U;
			}
			set
			{
				this._processbar = new uint?(value);
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00019E50 File Offset: 0x00018050
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00019E70 File Offset: 0x00018070
		[XmlIgnore]
		[Browsable(false)]
		public bool processbarSpecified
		{
			get
			{
				return this._processbar != null;
			}
			set
			{
				bool flag = value == (this._processbar == null);
				if (flag)
				{
					this._processbar = (value ? new uint?(this.processbar) : null);
				}
			}
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x00019EB4 File Offset: 0x000180B4
		private bool ShouldSerializeprocessbar()
		{
			return this.processbarSpecified;
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00019ECC File Offset: 0x000180CC
		private void Resetprocessbar()
		{
			this.processbarSpecified = false;
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00019ED8 File Offset: 0x000180D8
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00019F04 File Offset: 0x00018104
		[ProtoMember(2, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
		public uint boxmask
		{
			get
			{
				return this._boxmask ?? 0U;
			}
			set
			{
				this._boxmask = new uint?(value);
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00019F14 File Offset: 0x00018114
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00019F34 File Offset: 0x00018134
		[XmlIgnore]
		[Browsable(false)]
		public bool boxmaskSpecified
		{
			get
			{
				return this._boxmask != null;
			}
			set
			{
				bool flag = value == (this._boxmask == null);
				if (flag)
				{
					this._boxmask = (value ? new uint?(this.boxmask) : null);
				}
			}
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x00019F78 File Offset: 0x00018178
		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		// Token: 0x06000C49 RID: 3145 RVA: 0x00019F90 File Offset: 0x00018190
		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		// Token: 0x06000C4A RID: 3146 RVA: 0x00019F9C File Offset: 0x0001819C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000309 RID: 777
		private uint? _processbar;

		// Token: 0x0400030A RID: 778
		private uint? _boxmask;

		// Token: 0x0400030B RID: 779
		private IExtension extensionObject;
	}
}
