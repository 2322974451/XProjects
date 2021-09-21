using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200029F RID: 671
	[ProtoContract(Name = "GoldClickRes")]
	[Serializable]
	public class GoldClickRes : IExtensible
	{
		// Token: 0x17000B9E RID: 2974
		// (get) Token: 0x06002562 RID: 9570 RVA: 0x00048CC0 File Offset: 0x00046EC0
		// (set) Token: 0x06002563 RID: 9571 RVA: 0x00048CEC File Offset: 0x00046EEC
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x06002564 RID: 9572 RVA: 0x00048CFC File Offset: 0x00046EFC
		// (set) Token: 0x06002565 RID: 9573 RVA: 0x00048D1C File Offset: 0x00046F1C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06002566 RID: 9574 RVA: 0x00048D60 File Offset: 0x00046F60
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002567 RID: 9575 RVA: 0x00048D78 File Offset: 0x00046F78
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000BA0 RID: 2976
		// (get) Token: 0x06002568 RID: 9576 RVA: 0x00048D84 File Offset: 0x00046F84
		[ProtoMember(2, Name = "results", DataFormat = DataFormat.TwosComplement)]
		public List<uint> results
		{
			get
			{
				return this._results;
			}
		}

		// Token: 0x17000BA1 RID: 2977
		// (get) Token: 0x06002569 RID: 9577 RVA: 0x00048D9C File Offset: 0x00046F9C
		// (set) Token: 0x0600256A RID: 9578 RVA: 0x00048DC8 File Offset: 0x00046FC8
		[ProtoMember(3, IsRequired = false, Name = "freetimeleft", DataFormat = DataFormat.TwosComplement)]
		public uint freetimeleft
		{
			get
			{
				return this._freetimeleft ?? 0U;
			}
			set
			{
				this._freetimeleft = new uint?(value);
			}
		}

		// Token: 0x17000BA2 RID: 2978
		// (get) Token: 0x0600256B RID: 9579 RVA: 0x00048DD8 File Offset: 0x00046FD8
		// (set) Token: 0x0600256C RID: 9580 RVA: 0x00048DF8 File Offset: 0x00046FF8
		[XmlIgnore]
		[Browsable(false)]
		public bool freetimeleftSpecified
		{
			get
			{
				return this._freetimeleft != null;
			}
			set
			{
				bool flag = value == (this._freetimeleft == null);
				if (flag)
				{
					this._freetimeleft = (value ? new uint?(this.freetimeleft) : null);
				}
			}
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x00048E3C File Offset: 0x0004703C
		private bool ShouldSerializefreetimeleft()
		{
			return this.freetimeleftSpecified;
		}

		// Token: 0x0600256E RID: 9582 RVA: 0x00048E54 File Offset: 0x00047054
		private void Resetfreetimeleft()
		{
			this.freetimeleftSpecified = false;
		}

		// Token: 0x17000BA3 RID: 2979
		// (get) Token: 0x0600256F RID: 9583 RVA: 0x00048E60 File Offset: 0x00047060
		// (set) Token: 0x06002570 RID: 9584 RVA: 0x00048E8C File Offset: 0x0004708C
		[ProtoMember(4, IsRequired = false, Name = "freecount", DataFormat = DataFormat.TwosComplement)]
		public uint freecount
		{
			get
			{
				return this._freecount ?? 0U;
			}
			set
			{
				this._freecount = new uint?(value);
			}
		}

		// Token: 0x17000BA4 RID: 2980
		// (get) Token: 0x06002571 RID: 9585 RVA: 0x00048E9C File Offset: 0x0004709C
		// (set) Token: 0x06002572 RID: 9586 RVA: 0x00048EBC File Offset: 0x000470BC
		[XmlIgnore]
		[Browsable(false)]
		public bool freecountSpecified
		{
			get
			{
				return this._freecount != null;
			}
			set
			{
				bool flag = value == (this._freecount == null);
				if (flag)
				{
					this._freecount = (value ? new uint?(this.freecount) : null);
				}
			}
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x00048F00 File Offset: 0x00047100
		private bool ShouldSerializefreecount()
		{
			return this.freecountSpecified;
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x00048F18 File Offset: 0x00047118
		private void Resetfreecount()
		{
			this.freecountSpecified = false;
		}

		// Token: 0x17000BA5 RID: 2981
		// (get) Token: 0x06002575 RID: 9589 RVA: 0x00048F24 File Offset: 0x00047124
		// (set) Token: 0x06002576 RID: 9590 RVA: 0x00048F50 File Offset: 0x00047150
		[ProtoMember(5, IsRequired = false, Name = "freeallcount", DataFormat = DataFormat.TwosComplement)]
		public uint freeallcount
		{
			get
			{
				return this._freeallcount ?? 0U;
			}
			set
			{
				this._freeallcount = new uint?(value);
			}
		}

		// Token: 0x17000BA6 RID: 2982
		// (get) Token: 0x06002577 RID: 9591 RVA: 0x00048F60 File Offset: 0x00047160
		// (set) Token: 0x06002578 RID: 9592 RVA: 0x00048F80 File Offset: 0x00047180
		[XmlIgnore]
		[Browsable(false)]
		public bool freeallcountSpecified
		{
			get
			{
				return this._freeallcount != null;
			}
			set
			{
				bool flag = value == (this._freeallcount == null);
				if (flag)
				{
					this._freeallcount = (value ? new uint?(this.freeallcount) : null);
				}
			}
		}

		// Token: 0x06002579 RID: 9593 RVA: 0x00048FC4 File Offset: 0x000471C4
		private bool ShouldSerializefreeallcount()
		{
			return this.freeallcountSpecified;
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x00048FDC File Offset: 0x000471DC
		private void Resetfreeallcount()
		{
			this.freeallcountSpecified = false;
		}

		// Token: 0x17000BA7 RID: 2983
		// (get) Token: 0x0600257B RID: 9595 RVA: 0x00048FE8 File Offset: 0x000471E8
		// (set) Token: 0x0600257C RID: 9596 RVA: 0x00049014 File Offset: 0x00047214
		[ProtoMember(6, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000BA8 RID: 2984
		// (get) Token: 0x0600257D RID: 9597 RVA: 0x00049024 File Offset: 0x00047224
		// (set) Token: 0x0600257E RID: 9598 RVA: 0x00049044 File Offset: 0x00047244
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x0600257F RID: 9599 RVA: 0x00049088 File Offset: 0x00047288
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002580 RID: 9600 RVA: 0x000490A0 File Offset: 0x000472A0
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x06002581 RID: 9601 RVA: 0x000490AC File Offset: 0x000472AC
		// (set) Token: 0x06002582 RID: 9602 RVA: 0x000490D8 File Offset: 0x000472D8
		[ProtoMember(7, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		// Token: 0x17000BAA RID: 2986
		// (get) Token: 0x06002583 RID: 9603 RVA: 0x000490E8 File Offset: 0x000472E8
		// (set) Token: 0x06002584 RID: 9604 RVA: 0x00049108 File Offset: 0x00047308
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		// Token: 0x06002585 RID: 9605 RVA: 0x0004914C File Offset: 0x0004734C
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x06002586 RID: 9606 RVA: 0x00049164 File Offset: 0x00047364
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x06002587 RID: 9607 RVA: 0x00049170 File Offset: 0x00047370
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000943 RID: 2371
		private ErrorCode? _errorcode;

		// Token: 0x04000944 RID: 2372
		private readonly List<uint> _results = new List<uint>();

		// Token: 0x04000945 RID: 2373
		private uint? _freetimeleft;

		// Token: 0x04000946 RID: 2374
		private uint? _freecount;

		// Token: 0x04000947 RID: 2375
		private uint? _freeallcount;

		// Token: 0x04000948 RID: 2376
		private uint? _count;

		// Token: 0x04000949 RID: 2377
		private uint? _allcount;

		// Token: 0x0400094A RID: 2378
		private IExtension extensionObject;
	}
}
