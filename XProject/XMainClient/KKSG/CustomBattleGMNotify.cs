using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000415 RID: 1045
	[ProtoContract(Name = "CustomBattleGMNotify")]
	[Serializable]
	public class CustomBattleGMNotify : IExtensible
	{
		// Token: 0x17001112 RID: 4370
		// (get) Token: 0x0600378B RID: 14219 RVA: 0x0006A5B4 File Offset: 0x000687B4
		// (set) Token: 0x0600378C RID: 14220 RVA: 0x0006A5E0 File Offset: 0x000687E0
		[ProtoMember(1, IsRequired = false, Name = "isgmcreate", DataFormat = DataFormat.Default)]
		public bool isgmcreate
		{
			get
			{
				return this._isgmcreate ?? false;
			}
			set
			{
				this._isgmcreate = new bool?(value);
			}
		}

		// Token: 0x17001113 RID: 4371
		// (get) Token: 0x0600378D RID: 14221 RVA: 0x0006A5F0 File Offset: 0x000687F0
		// (set) Token: 0x0600378E RID: 14222 RVA: 0x0006A610 File Offset: 0x00068810
		[XmlIgnore]
		[Browsable(false)]
		public bool isgmcreateSpecified
		{
			get
			{
				return this._isgmcreate != null;
			}
			set
			{
				bool flag = value == (this._isgmcreate == null);
				if (flag)
				{
					this._isgmcreate = (value ? new bool?(this.isgmcreate) : null);
				}
			}
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x0006A654 File Offset: 0x00068854
		private bool ShouldSerializeisgmcreate()
		{
			return this.isgmcreateSpecified;
		}

		// Token: 0x06003790 RID: 14224 RVA: 0x0006A66C File Offset: 0x0006886C
		private void Resetisgmcreate()
		{
			this.isgmcreateSpecified = false;
		}

		// Token: 0x17001114 RID: 4372
		// (get) Token: 0x06003791 RID: 14225 RVA: 0x0006A678 File Offset: 0x00068878
		// (set) Token: 0x06003792 RID: 14226 RVA: 0x0006A6A4 File Offset: 0x000688A4
		[ProtoMember(2, IsRequired = false, Name = "isgmjoin", DataFormat = DataFormat.Default)]
		public bool isgmjoin
		{
			get
			{
				return this._isgmjoin ?? false;
			}
			set
			{
				this._isgmjoin = new bool?(value);
			}
		}

		// Token: 0x17001115 RID: 4373
		// (get) Token: 0x06003793 RID: 14227 RVA: 0x0006A6B4 File Offset: 0x000688B4
		// (set) Token: 0x06003794 RID: 14228 RVA: 0x0006A6D4 File Offset: 0x000688D4
		[XmlIgnore]
		[Browsable(false)]
		public bool isgmjoinSpecified
		{
			get
			{
				return this._isgmjoin != null;
			}
			set
			{
				bool flag = value == (this._isgmjoin == null);
				if (flag)
				{
					this._isgmjoin = (value ? new bool?(this.isgmjoin) : null);
				}
			}
		}

		// Token: 0x06003795 RID: 14229 RVA: 0x0006A718 File Offset: 0x00068918
		private bool ShouldSerializeisgmjoin()
		{
			return this.isgmjoinSpecified;
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x0006A730 File Offset: 0x00068930
		private void Resetisgmjoin()
		{
			this.isgmjoinSpecified = false;
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x0006A73C File Offset: 0x0006893C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DC5 RID: 3525
		private bool? _isgmcreate;

		// Token: 0x04000DC6 RID: 3526
		private bool? _isgmjoin;

		// Token: 0x04000DC7 RID: 3527
		private IExtension extensionObject;
	}
}
