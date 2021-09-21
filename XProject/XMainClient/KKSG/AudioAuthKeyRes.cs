using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000354 RID: 852
	[ProtoContract(Name = "AudioAuthKeyRes")]
	[Serializable]
	public class AudioAuthKeyRes : IExtensible
	{
		// Token: 0x17000E79 RID: 3705
		// (get) Token: 0x06002EAA RID: 11946 RVA: 0x0005A280 File Offset: 0x00058480
		// (set) Token: 0x06002EAB RID: 11947 RVA: 0x0005A2AC File Offset: 0x000584AC
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x06002EAC RID: 11948 RVA: 0x0005A2BC File Offset: 0x000584BC
		// (set) Token: 0x06002EAD RID: 11949 RVA: 0x0005A2DC File Offset: 0x000584DC
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x0005A320 File Offset: 0x00058520
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x0005A338 File Offset: 0x00058538
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000E7B RID: 3707
		// (get) Token: 0x06002EB0 RID: 11952 RVA: 0x0005A344 File Offset: 0x00058544
		// (set) Token: 0x06002EB1 RID: 11953 RVA: 0x0005A370 File Offset: 0x00058570
		[ProtoMember(2, IsRequired = false, Name = "dwMainSvrId", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrId
		{
			get
			{
				return this._dwMainSvrId ?? 0U;
			}
			set
			{
				this._dwMainSvrId = new uint?(value);
			}
		}

		// Token: 0x17000E7C RID: 3708
		// (get) Token: 0x06002EB2 RID: 11954 RVA: 0x0005A380 File Offset: 0x00058580
		// (set) Token: 0x06002EB3 RID: 11955 RVA: 0x0005A3A0 File Offset: 0x000585A0
		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrIdSpecified
		{
			get
			{
				return this._dwMainSvrId != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrId == null);
				if (flag)
				{
					this._dwMainSvrId = (value ? new uint?(this.dwMainSvrId) : null);
				}
			}
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x0005A3E4 File Offset: 0x000585E4
		private bool ShouldSerializedwMainSvrId()
		{
			return this.dwMainSvrIdSpecified;
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x0005A3FC File Offset: 0x000585FC
		private void ResetdwMainSvrId()
		{
			this.dwMainSvrIdSpecified = false;
		}

		// Token: 0x17000E7D RID: 3709
		// (get) Token: 0x06002EB6 RID: 11958 RVA: 0x0005A408 File Offset: 0x00058608
		// (set) Token: 0x06002EB7 RID: 11959 RVA: 0x0005A434 File Offset: 0x00058634
		[ProtoMember(3, IsRequired = false, Name = "dwMainSvrUrl1", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrUrl1
		{
			get
			{
				return this._dwMainSvrUrl1 ?? 0U;
			}
			set
			{
				this._dwMainSvrUrl1 = new uint?(value);
			}
		}

		// Token: 0x17000E7E RID: 3710
		// (get) Token: 0x06002EB8 RID: 11960 RVA: 0x0005A444 File Offset: 0x00058644
		// (set) Token: 0x06002EB9 RID: 11961 RVA: 0x0005A464 File Offset: 0x00058664
		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrUrl1Specified
		{
			get
			{
				return this._dwMainSvrUrl1 != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrUrl1 == null);
				if (flag)
				{
					this._dwMainSvrUrl1 = (value ? new uint?(this.dwMainSvrUrl1) : null);
				}
			}
		}

		// Token: 0x06002EBA RID: 11962 RVA: 0x0005A4A8 File Offset: 0x000586A8
		private bool ShouldSerializedwMainSvrUrl1()
		{
			return this.dwMainSvrUrl1Specified;
		}

		// Token: 0x06002EBB RID: 11963 RVA: 0x0005A4C0 File Offset: 0x000586C0
		private void ResetdwMainSvrUrl1()
		{
			this.dwMainSvrUrl1Specified = false;
		}

		// Token: 0x17000E7F RID: 3711
		// (get) Token: 0x06002EBC RID: 11964 RVA: 0x0005A4CC File Offset: 0x000586CC
		// (set) Token: 0x06002EBD RID: 11965 RVA: 0x0005A4F8 File Offset: 0x000586F8
		[ProtoMember(4, IsRequired = false, Name = "dwMainSvrUrl2", DataFormat = DataFormat.TwosComplement)]
		public uint dwMainSvrUrl2
		{
			get
			{
				return this._dwMainSvrUrl2 ?? 0U;
			}
			set
			{
				this._dwMainSvrUrl2 = new uint?(value);
			}
		}

		// Token: 0x17000E80 RID: 3712
		// (get) Token: 0x06002EBE RID: 11966 RVA: 0x0005A508 File Offset: 0x00058708
		// (set) Token: 0x06002EBF RID: 11967 RVA: 0x0005A528 File Offset: 0x00058728
		[XmlIgnore]
		[Browsable(false)]
		public bool dwMainSvrUrl2Specified
		{
			get
			{
				return this._dwMainSvrUrl2 != null;
			}
			set
			{
				bool flag = value == (this._dwMainSvrUrl2 == null);
				if (flag)
				{
					this._dwMainSvrUrl2 = (value ? new uint?(this.dwMainSvrUrl2) : null);
				}
			}
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x0005A56C File Offset: 0x0005876C
		private bool ShouldSerializedwMainSvrUrl2()
		{
			return this.dwMainSvrUrl2Specified;
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x0005A584 File Offset: 0x00058784
		private void ResetdwMainSvrUrl2()
		{
			this.dwMainSvrUrl2Specified = false;
		}

		// Token: 0x17000E81 RID: 3713
		// (get) Token: 0x06002EC2 RID: 11970 RVA: 0x0005A590 File Offset: 0x00058790
		// (set) Token: 0x06002EC3 RID: 11971 RVA: 0x0005A5BC File Offset: 0x000587BC
		[ProtoMember(5, IsRequired = false, Name = "dwSlaveSvrId", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrId
		{
			get
			{
				return this._dwSlaveSvrId ?? 0U;
			}
			set
			{
				this._dwSlaveSvrId = new uint?(value);
			}
		}

		// Token: 0x17000E82 RID: 3714
		// (get) Token: 0x06002EC4 RID: 11972 RVA: 0x0005A5CC File Offset: 0x000587CC
		// (set) Token: 0x06002EC5 RID: 11973 RVA: 0x0005A5EC File Offset: 0x000587EC
		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrIdSpecified
		{
			get
			{
				return this._dwSlaveSvrId != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrId == null);
				if (flag)
				{
					this._dwSlaveSvrId = (value ? new uint?(this.dwSlaveSvrId) : null);
				}
			}
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x0005A630 File Offset: 0x00058830
		private bool ShouldSerializedwSlaveSvrId()
		{
			return this.dwSlaveSvrIdSpecified;
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x0005A648 File Offset: 0x00058848
		private void ResetdwSlaveSvrId()
		{
			this.dwSlaveSvrIdSpecified = false;
		}

		// Token: 0x17000E83 RID: 3715
		// (get) Token: 0x06002EC8 RID: 11976 RVA: 0x0005A654 File Offset: 0x00058854
		// (set) Token: 0x06002EC9 RID: 11977 RVA: 0x0005A680 File Offset: 0x00058880
		[ProtoMember(6, IsRequired = false, Name = "dwSlaveSvrUrl1", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrUrl1
		{
			get
			{
				return this._dwSlaveSvrUrl1 ?? 0U;
			}
			set
			{
				this._dwSlaveSvrUrl1 = new uint?(value);
			}
		}

		// Token: 0x17000E84 RID: 3716
		// (get) Token: 0x06002ECA RID: 11978 RVA: 0x0005A690 File Offset: 0x00058890
		// (set) Token: 0x06002ECB RID: 11979 RVA: 0x0005A6B0 File Offset: 0x000588B0
		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrUrl1Specified
		{
			get
			{
				return this._dwSlaveSvrUrl1 != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrUrl1 == null);
				if (flag)
				{
					this._dwSlaveSvrUrl1 = (value ? new uint?(this.dwSlaveSvrUrl1) : null);
				}
			}
		}

		// Token: 0x06002ECC RID: 11980 RVA: 0x0005A6F4 File Offset: 0x000588F4
		private bool ShouldSerializedwSlaveSvrUrl1()
		{
			return this.dwSlaveSvrUrl1Specified;
		}

		// Token: 0x06002ECD RID: 11981 RVA: 0x0005A70C File Offset: 0x0005890C
		private void ResetdwSlaveSvrUrl1()
		{
			this.dwSlaveSvrUrl1Specified = false;
		}

		// Token: 0x17000E85 RID: 3717
		// (get) Token: 0x06002ECE RID: 11982 RVA: 0x0005A718 File Offset: 0x00058918
		// (set) Token: 0x06002ECF RID: 11983 RVA: 0x0005A744 File Offset: 0x00058944
		[ProtoMember(7, IsRequired = false, Name = "dwSlaveSvrUrl2", DataFormat = DataFormat.TwosComplement)]
		public uint dwSlaveSvrUrl2
		{
			get
			{
				return this._dwSlaveSvrUrl2 ?? 0U;
			}
			set
			{
				this._dwSlaveSvrUrl2 = new uint?(value);
			}
		}

		// Token: 0x17000E86 RID: 3718
		// (get) Token: 0x06002ED0 RID: 11984 RVA: 0x0005A754 File Offset: 0x00058954
		// (set) Token: 0x06002ED1 RID: 11985 RVA: 0x0005A774 File Offset: 0x00058974
		[XmlIgnore]
		[Browsable(false)]
		public bool dwSlaveSvrUrl2Specified
		{
			get
			{
				return this._dwSlaveSvrUrl2 != null;
			}
			set
			{
				bool flag = value == (this._dwSlaveSvrUrl2 == null);
				if (flag)
				{
					this._dwSlaveSvrUrl2 = (value ? new uint?(this.dwSlaveSvrUrl2) : null);
				}
			}
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x0005A7B8 File Offset: 0x000589B8
		private bool ShouldSerializedwSlaveSvrUrl2()
		{
			return this.dwSlaveSvrUrl2Specified;
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x0005A7D0 File Offset: 0x000589D0
		private void ResetdwSlaveSvrUrl2()
		{
			this.dwSlaveSvrUrl2Specified = false;
		}

		// Token: 0x17000E87 RID: 3719
		// (get) Token: 0x06002ED4 RID: 11988 RVA: 0x0005A7DC File Offset: 0x000589DC
		// (set) Token: 0x06002ED5 RID: 11989 RVA: 0x0005A7FD File Offset: 0x000589FD
		[ProtoMember(8, IsRequired = false, Name = "szAuthKey", DataFormat = DataFormat.Default)]
		public string szAuthKey
		{
			get
			{
				return this._szAuthKey ?? "";
			}
			set
			{
				this._szAuthKey = value;
			}
		}

		// Token: 0x17000E88 RID: 3720
		// (get) Token: 0x06002ED6 RID: 11990 RVA: 0x0005A808 File Offset: 0x00058A08
		// (set) Token: 0x06002ED7 RID: 11991 RVA: 0x0005A824 File Offset: 0x00058A24
		[XmlIgnore]
		[Browsable(false)]
		public bool szAuthKeySpecified
		{
			get
			{
				return this._szAuthKey != null;
			}
			set
			{
				bool flag = value == (this._szAuthKey == null);
				if (flag)
				{
					this._szAuthKey = (value ? this.szAuthKey : null);
				}
			}
		}

		// Token: 0x06002ED8 RID: 11992 RVA: 0x0005A854 File Offset: 0x00058A54
		private bool ShouldSerializeszAuthKey()
		{
			return this.szAuthKeySpecified;
		}

		// Token: 0x06002ED9 RID: 11993 RVA: 0x0005A86C File Offset: 0x00058A6C
		private void ResetszAuthKey()
		{
			this.szAuthKeySpecified = false;
		}

		// Token: 0x17000E89 RID: 3721
		// (get) Token: 0x06002EDA RID: 11994 RVA: 0x0005A878 File Offset: 0x00058A78
		// (set) Token: 0x06002EDB RID: 11995 RVA: 0x0005A8A4 File Offset: 0x00058AA4
		[ProtoMember(9, IsRequired = false, Name = "dwExpireIn", DataFormat = DataFormat.TwosComplement)]
		public uint dwExpireIn
		{
			get
			{
				return this._dwExpireIn ?? 0U;
			}
			set
			{
				this._dwExpireIn = new uint?(value);
			}
		}

		// Token: 0x17000E8A RID: 3722
		// (get) Token: 0x06002EDC RID: 11996 RVA: 0x0005A8B4 File Offset: 0x00058AB4
		// (set) Token: 0x06002EDD RID: 11997 RVA: 0x0005A8D4 File Offset: 0x00058AD4
		[XmlIgnore]
		[Browsable(false)]
		public bool dwExpireInSpecified
		{
			get
			{
				return this._dwExpireIn != null;
			}
			set
			{
				bool flag = value == (this._dwExpireIn == null);
				if (flag)
				{
					this._dwExpireIn = (value ? new uint?(this.dwExpireIn) : null);
				}
			}
		}

		// Token: 0x06002EDE RID: 11998 RVA: 0x0005A918 File Offset: 0x00058B18
		private bool ShouldSerializedwExpireIn()
		{
			return this.dwExpireInSpecified;
		}

		// Token: 0x06002EDF RID: 11999 RVA: 0x0005A930 File Offset: 0x00058B30
		private void ResetdwExpireIn()
		{
			this.dwExpireInSpecified = false;
		}

		// Token: 0x06002EE0 RID: 12000 RVA: 0x0005A93C File Offset: 0x00058B3C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B96 RID: 2966
		private ErrorCode? _error;

		// Token: 0x04000B97 RID: 2967
		private uint? _dwMainSvrId;

		// Token: 0x04000B98 RID: 2968
		private uint? _dwMainSvrUrl1;

		// Token: 0x04000B99 RID: 2969
		private uint? _dwMainSvrUrl2;

		// Token: 0x04000B9A RID: 2970
		private uint? _dwSlaveSvrId;

		// Token: 0x04000B9B RID: 2971
		private uint? _dwSlaveSvrUrl1;

		// Token: 0x04000B9C RID: 2972
		private uint? _dwSlaveSvrUrl2;

		// Token: 0x04000B9D RID: 2973
		private string _szAuthKey;

		// Token: 0x04000B9E RID: 2974
		private uint? _dwExpireIn;

		// Token: 0x04000B9F RID: 2975
		private IExtension extensionObject;
	}
}
