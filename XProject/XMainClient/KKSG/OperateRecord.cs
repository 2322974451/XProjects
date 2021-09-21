using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000077 RID: 119
	[ProtoContract(Name = "OperateRecord")]
	[Serializable]
	public class OperateRecord : IExtensible
	{
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x000119AC File Offset: 0x0000FBAC
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x000119D8 File Offset: 0x0000FBD8
		[ProtoMember(1, IsRequired = false, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public uint position
		{
			get
			{
				return this._position ?? 0U;
			}
			set
			{
				this._position = new uint?(value);
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x000119E8 File Offset: 0x0000FBE8
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x00011A08 File Offset: 0x0000FC08
		[XmlIgnore]
		[Browsable(false)]
		public bool positionSpecified
		{
			get
			{
				return this._position != null;
			}
			set
			{
				bool flag = value == (this._position == null);
				if (flag)
				{
					this._position = (value ? new uint?(this.position) : null);
				}
			}
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00011A4C File Offset: 0x0000FC4C
		private bool ShouldSerializeposition()
		{
			return this.positionSpecified;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00011A64 File Offset: 0x0000FC64
		private void Resetposition()
		{
			this.positionSpecified = false;
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x00011A70 File Offset: 0x0000FC70
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x00011A91 File Offset: 0x0000FC91
		[ProtoMember(2, IsRequired = false, Name = "arg", DataFormat = DataFormat.Default)]
		public string arg
		{
			get
			{
				return this._arg ?? "";
			}
			set
			{
				this._arg = value;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00011A9C File Offset: 0x0000FC9C
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00011AB8 File Offset: 0x0000FCB8
		[XmlIgnore]
		[Browsable(false)]
		public bool argSpecified
		{
			get
			{
				return this._arg != null;
			}
			set
			{
				bool flag = value == (this._arg == null);
				if (flag)
				{
					this._arg = (value ? this.arg : null);
				}
			}
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00011AE8 File Offset: 0x0000FCE8
		private bool ShouldSerializearg()
		{
			return this.argSpecified;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00011B00 File Offset: 0x0000FD00
		private void Resetarg()
		{
			this.argSpecified = false;
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00011B0C File Offset: 0x0000FD0C
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x00011B2D File Offset: 0x0000FD2D
		[ProtoMember(3, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00011B38 File Offset: 0x0000FD38
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x00011B54 File Offset: 0x0000FD54
		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00011B84 File Offset: 0x0000FD84
		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00011B9C File Offset: 0x0000FD9C
		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00011BA8 File Offset: 0x0000FDA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001FD RID: 509
		private uint? _position;

		// Token: 0x040001FE RID: 510
		private string _arg;

		// Token: 0x040001FF RID: 511
		private string _account;

		// Token: 0x04000200 RID: 512
		private IExtension extensionObject;
	}
}
