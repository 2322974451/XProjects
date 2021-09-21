using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000B RID: 11
	[ProtoContract(Name = "ErrorInfo")]
	[Serializable]
	public class ErrorInfo : IExtensible
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003990 File Offset: 0x00001B90
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000039BC File Offset: 0x00001BBC
		[ProtoMember(1, IsRequired = false, Name = "errorno", DataFormat = DataFormat.TwosComplement)]
		public uint errorno
		{
			get
			{
				return this._errorno ?? 0U;
			}
			set
			{
				this._errorno = new uint?(value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000039CC File Offset: 0x00001BCC
		// (set) Token: 0x06000084 RID: 132 RVA: 0x000039EC File Offset: 0x00001BEC
		[XmlIgnore]
		[Browsable(false)]
		public bool errornoSpecified
		{
			get
			{
				return this._errorno != null;
			}
			set
			{
				bool flag = value == (this._errorno == null);
				if (flag)
				{
					this._errorno = (value ? new uint?(this.errorno) : null);
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003A30 File Offset: 0x00001C30
		private bool ShouldSerializeerrorno()
		{
			return this.errornoSpecified;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003A48 File Offset: 0x00001C48
		private void Reseterrorno()
		{
			this.errornoSpecified = false;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003A54 File Offset: 0x00001C54
		[ProtoMember(2, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public List<uint> param
		{
			get
			{
				return this._param;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00003A6C File Offset: 0x00001C6C
		// (set) Token: 0x06000089 RID: 137 RVA: 0x00003A99 File Offset: 0x00001C99
		[ProtoMember(3, IsRequired = false, Name = "param64", DataFormat = DataFormat.TwosComplement)]
		public ulong param64
		{
			get
			{
				return this._param64 ?? 0UL;
			}
			set
			{
				this._param64 = new ulong?(value);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00003AA8 File Offset: 0x00001CA8
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00003AC8 File Offset: 0x00001CC8
		[XmlIgnore]
		[Browsable(false)]
		public bool param64Specified
		{
			get
			{
				return this._param64 != null;
			}
			set
			{
				bool flag = value == (this._param64 == null);
				if (flag)
				{
					this._param64 = (value ? new ulong?(this.param64) : null);
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00003B0C File Offset: 0x00001D0C
		private bool ShouldSerializeparam64()
		{
			return this.param64Specified;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003B24 File Offset: 0x00001D24
		private void Resetparam64()
		{
			this.param64Specified = false;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003B30 File Offset: 0x00001D30
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00003B5C File Offset: 0x00001D5C
		[ProtoMember(4, IsRequired = false, Name = "istip", DataFormat = DataFormat.Default)]
		public bool istip
		{
			get
			{
				return this._istip ?? false;
			}
			set
			{
				this._istip = new bool?(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00003B6C File Offset: 0x00001D6C
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00003B8C File Offset: 0x00001D8C
		[XmlIgnore]
		[Browsable(false)]
		public bool istipSpecified
		{
			get
			{
				return this._istip != null;
			}
			set
			{
				bool flag = value == (this._istip == null);
				if (flag)
				{
					this._istip = (value ? new bool?(this.istip) : null);
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003BD0 File Offset: 0x00001DD0
		private bool ShouldSerializeistip()
		{
			return this.istipSpecified;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003BE8 File Offset: 0x00001DE8
		private void Resetistip()
		{
			this.istipSpecified = false;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003BF4 File Offset: 0x00001DF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000028 RID: 40
		private uint? _errorno;

		// Token: 0x04000029 RID: 41
		private readonly List<uint> _param = new List<uint>();

		// Token: 0x0400002A RID: 42
		private ulong? _param64;

		// Token: 0x0400002B RID: 43
		private bool? _istip;

		// Token: 0x0400002C RID: 44
		private IExtension extensionObject;
	}
}
