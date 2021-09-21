using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E0 RID: 1504
	[ProtoContract(Name = "StageWatchInfo")]
	[Serializable]
	public class StageWatchInfo : IExtensible
	{
		// Token: 0x17001B05 RID: 6917
		// (get) Token: 0x06005701 RID: 22273 RVA: 0x000A5B14 File Offset: 0x000A3D14
		// (set) Token: 0x06005702 RID: 22274 RVA: 0x000A5B40 File Offset: 0x000A3D40
		[ProtoMember(1, IsRequired = false, Name = "wathccount", DataFormat = DataFormat.TwosComplement)]
		public uint wathccount
		{
			get
			{
				return this._wathccount ?? 0U;
			}
			set
			{
				this._wathccount = new uint?(value);
			}
		}

		// Token: 0x17001B06 RID: 6918
		// (get) Token: 0x06005703 RID: 22275 RVA: 0x000A5B50 File Offset: 0x000A3D50
		// (set) Token: 0x06005704 RID: 22276 RVA: 0x000A5B70 File Offset: 0x000A3D70
		[XmlIgnore]
		[Browsable(false)]
		public bool wathccountSpecified
		{
			get
			{
				return this._wathccount != null;
			}
			set
			{
				bool flag = value == (this._wathccount == null);
				if (flag)
				{
					this._wathccount = (value ? new uint?(this.wathccount) : null);
				}
			}
		}

		// Token: 0x06005705 RID: 22277 RVA: 0x000A5BB4 File Offset: 0x000A3DB4
		private bool ShouldSerializewathccount()
		{
			return this.wathccountSpecified;
		}

		// Token: 0x06005706 RID: 22278 RVA: 0x000A5BCC File Offset: 0x000A3DCC
		private void Resetwathccount()
		{
			this.wathccountSpecified = false;
		}

		// Token: 0x17001B07 RID: 6919
		// (get) Token: 0x06005707 RID: 22279 RVA: 0x000A5BD8 File Offset: 0x000A3DD8
		// (set) Token: 0x06005708 RID: 22280 RVA: 0x000A5C04 File Offset: 0x000A3E04
		[ProtoMember(2, IsRequired = false, Name = "likecount", DataFormat = DataFormat.TwosComplement)]
		public uint likecount
		{
			get
			{
				return this._likecount ?? 0U;
			}
			set
			{
				this._likecount = new uint?(value);
			}
		}

		// Token: 0x17001B08 RID: 6920
		// (get) Token: 0x06005709 RID: 22281 RVA: 0x000A5C14 File Offset: 0x000A3E14
		// (set) Token: 0x0600570A RID: 22282 RVA: 0x000A5C34 File Offset: 0x000A3E34
		[XmlIgnore]
		[Browsable(false)]
		public bool likecountSpecified
		{
			get
			{
				return this._likecount != null;
			}
			set
			{
				bool flag = value == (this._likecount == null);
				if (flag)
				{
					this._likecount = (value ? new uint?(this.likecount) : null);
				}
			}
		}

		// Token: 0x0600570B RID: 22283 RVA: 0x000A5C78 File Offset: 0x000A3E78
		private bool ShouldSerializelikecount()
		{
			return this.likecountSpecified;
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x000A5C90 File Offset: 0x000A3E90
		private void Resetlikecount()
		{
			this.likecountSpecified = false;
		}

		// Token: 0x0600570D RID: 22285 RVA: 0x000A5C9C File Offset: 0x000A3E9C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001523 RID: 5411
		private uint? _wathccount;

		// Token: 0x04001524 RID: 5412
		private uint? _likecount;

		// Token: 0x04001525 RID: 5413
		private IExtension extensionObject;
	}
}
