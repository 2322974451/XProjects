using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000AE RID: 174
	[ProtoContract(Name = "QueryGuildCheckinRes")]
	[Serializable]
	public class QueryGuildCheckinRes : IExtensible
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x00019690 File Offset: 0x00017890
		// (set) Token: 0x06000BFF RID: 3071 RVA: 0x000196BC File Offset: 0x000178BC
		[ProtoMember(1, IsRequired = false, Name = "checkincount", DataFormat = DataFormat.TwosComplement)]
		public uint checkincount
		{
			get
			{
				return this._checkincount ?? 0U;
			}
			set
			{
				this._checkincount = new uint?(value);
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x000196CC File Offset: 0x000178CC
		// (set) Token: 0x06000C01 RID: 3073 RVA: 0x000196EC File Offset: 0x000178EC
		[XmlIgnore]
		[Browsable(false)]
		public bool checkincountSpecified
		{
			get
			{
				return this._checkincount != null;
			}
			set
			{
				bool flag = value == (this._checkincount == null);
				if (flag)
				{
					this._checkincount = (value ? new uint?(this.checkincount) : null);
				}
			}
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x00019730 File Offset: 0x00017930
		private bool ShouldSerializecheckincount()
		{
			return this.checkincountSpecified;
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x00019748 File Offset: 0x00017948
		private void Resetcheckincount()
		{
			this.checkincountSpecified = false;
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x00019754 File Offset: 0x00017954
		// (set) Token: 0x06000C05 RID: 3077 RVA: 0x00019780 File Offset: 0x00017980
		[ProtoMember(2, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x00019790 File Offset: 0x00017990
		// (set) Token: 0x06000C07 RID: 3079 RVA: 0x000197B0 File Offset: 0x000179B0
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

		// Token: 0x06000C08 RID: 3080 RVA: 0x000197F4 File Offset: 0x000179F4
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0001980C File Offset: 0x00017A0C
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x00019818 File Offset: 0x00017A18
		// (set) Token: 0x06000C0B RID: 3083 RVA: 0x00019844 File Offset: 0x00017A44
		[ProtoMember(3, IsRequired = false, Name = "checkin", DataFormat = DataFormat.TwosComplement)]
		public uint checkin
		{
			get
			{
				return this._checkin ?? 0U;
			}
			set
			{
				this._checkin = new uint?(value);
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x00019854 File Offset: 0x00017A54
		// (set) Token: 0x06000C0D RID: 3085 RVA: 0x00019874 File Offset: 0x00017A74
		[XmlIgnore]
		[Browsable(false)]
		public bool checkinSpecified
		{
			get
			{
				return this._checkin != null;
			}
			set
			{
				bool flag = value == (this._checkin == null);
				if (flag)
				{
					this._checkin = (value ? new uint?(this.checkin) : null);
				}
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x000198B8 File Offset: 0x00017AB8
		private bool ShouldSerializecheckin()
		{
			return this.checkinSpecified;
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x000198D0 File Offset: 0x00017AD0
		private void Resetcheckin()
		{
			this.checkinSpecified = false;
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x000198DC File Offset: 0x00017ADC
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x00019908 File Offset: 0x00017B08
		[ProtoMember(4, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x00019918 File Offset: 0x00017B18
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x00019938 File Offset: 0x00017B38
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

		// Token: 0x06000C14 RID: 3092 RVA: 0x0001997C File Offset: 0x00017B7C
		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00019994 File Offset: 0x00017B94
		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x000199A0 File Offset: 0x00017BA0
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x000199CC File Offset: 0x00017BCC
		[ProtoMember(5, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x000199DC File Offset: 0x00017BDC
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x000199FC File Offset: 0x00017BFC
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

		// Token: 0x06000C1A RID: 3098 RVA: 0x00019A40 File Offset: 0x00017C40
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x00019A58 File Offset: 0x00017C58
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x00019A64 File Offset: 0x00017C64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040002FB RID: 763
		private uint? _checkincount;

		// Token: 0x040002FC RID: 764
		private uint? _allcount;

		// Token: 0x040002FD RID: 765
		private uint? _checkin;

		// Token: 0x040002FE RID: 766
		private uint? _boxmask;

		// Token: 0x040002FF RID: 767
		private ErrorCode? _errorcode;

		// Token: 0x04000300 RID: 768
		private IExtension extensionObject;
	}
}
