using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DD RID: 989
	[ProtoContract(Name = "CustomBattleOpArg")]
	[Serializable]
	public class CustomBattleOpArg : IExtensible
	{
		// Token: 0x17001028 RID: 4136
		// (get) Token: 0x06003486 RID: 13446 RVA: 0x00064BB0 File Offset: 0x00062DB0
		// (set) Token: 0x06003487 RID: 13447 RVA: 0x00064BDC File Offset: 0x00062DDC
		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public CustomBattleOp op
		{
			get
			{
				return this._op ?? CustomBattleOp.CustomBattle_Query;
			}
			set
			{
				this._op = new CustomBattleOp?(value);
			}
		}

		// Token: 0x17001029 RID: 4137
		// (get) Token: 0x06003488 RID: 13448 RVA: 0x00064BEC File Offset: 0x00062DEC
		// (set) Token: 0x06003489 RID: 13449 RVA: 0x00064C0C File Offset: 0x00062E0C
		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new CustomBattleOp?(this.op) : null);
				}
			}
		}

		// Token: 0x0600348A RID: 13450 RVA: 0x00064C50 File Offset: 0x00062E50
		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		// Token: 0x0600348B RID: 13451 RVA: 0x00064C68 File Offset: 0x00062E68
		private void Resetop()
		{
			this.opSpecified = false;
		}

		// Token: 0x1700102A RID: 4138
		// (get) Token: 0x0600348C RID: 13452 RVA: 0x00064C74 File Offset: 0x00062E74
		// (set) Token: 0x0600348D RID: 13453 RVA: 0x00064CA1 File Offset: 0x00062EA1
		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x1700102B RID: 4139
		// (get) Token: 0x0600348E RID: 13454 RVA: 0x00064CB0 File Offset: 0x00062EB0
		// (set) Token: 0x0600348F RID: 13455 RVA: 0x00064CD0 File Offset: 0x00062ED0
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06003490 RID: 13456 RVA: 0x00064D14 File Offset: 0x00062F14
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06003491 RID: 13457 RVA: 0x00064D2C File Offset: 0x00062F2C
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x1700102C RID: 4140
		// (get) Token: 0x06003492 RID: 13458 RVA: 0x00064D38 File Offset: 0x00062F38
		// (set) Token: 0x06003493 RID: 13459 RVA: 0x00064D50 File Offset: 0x00062F50
		[ProtoMember(3, IsRequired = false, Name = "config", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleConfig config
		{
			get
			{
				return this._config;
			}
			set
			{
				this._config = value;
			}
		}

		// Token: 0x1700102D RID: 4141
		// (get) Token: 0x06003494 RID: 13460 RVA: 0x00064D5C File Offset: 0x00062F5C
		// (set) Token: 0x06003495 RID: 13461 RVA: 0x00064D7D File Offset: 0x00062F7D
		[ProtoMember(4, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		// Token: 0x1700102E RID: 4142
		// (get) Token: 0x06003496 RID: 13462 RVA: 0x00064D88 File Offset: 0x00062F88
		// (set) Token: 0x06003497 RID: 13463 RVA: 0x00064DA4 File Offset: 0x00062FA4
		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		// Token: 0x06003498 RID: 13464 RVA: 0x00064DD4 File Offset: 0x00062FD4
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x06003499 RID: 13465 RVA: 0x00064DEC File Offset: 0x00062FEC
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x1700102F RID: 4143
		// (get) Token: 0x0600349A RID: 13466 RVA: 0x00064DF8 File Offset: 0x00062FF8
		// (set) Token: 0x0600349B RID: 13467 RVA: 0x00064E19 File Offset: 0x00063019
		[ProtoMember(5, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
		public string token
		{
			get
			{
				return this._token ?? "";
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x17001030 RID: 4144
		// (get) Token: 0x0600349C RID: 13468 RVA: 0x00064E24 File Offset: 0x00063024
		// (set) Token: 0x0600349D RID: 13469 RVA: 0x00064E40 File Offset: 0x00063040
		[XmlIgnore]
		[Browsable(false)]
		public bool tokenSpecified
		{
			get
			{
				return this._token != null;
			}
			set
			{
				bool flag = value == (this._token == null);
				if (flag)
				{
					this._token = (value ? this.token : null);
				}
			}
		}

		// Token: 0x0600349E RID: 13470 RVA: 0x00064E70 File Offset: 0x00063070
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x0600349F RID: 13471 RVA: 0x00064E88 File Offset: 0x00063088
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x17001031 RID: 4145
		// (get) Token: 0x060034A0 RID: 13472 RVA: 0x00064E94 File Offset: 0x00063094
		// (set) Token: 0x060034A1 RID: 13473 RVA: 0x00064EC0 File Offset: 0x000630C0
		[ProtoMember(6, IsRequired = false, Name = "querycross", DataFormat = DataFormat.Default)]
		public bool querycross
		{
			get
			{
				return this._querycross ?? false;
			}
			set
			{
				this._querycross = new bool?(value);
			}
		}

		// Token: 0x17001032 RID: 4146
		// (get) Token: 0x060034A2 RID: 13474 RVA: 0x00064ED0 File Offset: 0x000630D0
		// (set) Token: 0x060034A3 RID: 13475 RVA: 0x00064EF0 File Offset: 0x000630F0
		[XmlIgnore]
		[Browsable(false)]
		public bool querycrossSpecified
		{
			get
			{
				return this._querycross != null;
			}
			set
			{
				bool flag = value == (this._querycross == null);
				if (flag)
				{
					this._querycross = (value ? new bool?(this.querycross) : null);
				}
			}
		}

		// Token: 0x060034A4 RID: 13476 RVA: 0x00064F34 File Offset: 0x00063134
		private bool ShouldSerializequerycross()
		{
			return this.querycrossSpecified;
		}

		// Token: 0x060034A5 RID: 13477 RVA: 0x00064F4C File Offset: 0x0006314C
		private void Resetquerycross()
		{
			this.querycrossSpecified = false;
		}

		// Token: 0x17001033 RID: 4147
		// (get) Token: 0x060034A6 RID: 13478 RVA: 0x00064F58 File Offset: 0x00063158
		// (set) Token: 0x060034A7 RID: 13479 RVA: 0x00064F79 File Offset: 0x00063179
		[ProtoMember(7, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001034 RID: 4148
		// (get) Token: 0x060034A8 RID: 13480 RVA: 0x00064F84 File Offset: 0x00063184
		// (set) Token: 0x060034A9 RID: 13481 RVA: 0x00064FA0 File Offset: 0x000631A0
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060034AA RID: 13482 RVA: 0x00064FD0 File Offset: 0x000631D0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060034AB RID: 13483 RVA: 0x00064FE8 File Offset: 0x000631E8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060034AC RID: 13484 RVA: 0x00064FF4 File Offset: 0x000631F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D0C RID: 3340
		private CustomBattleOp? _op;

		// Token: 0x04000D0D RID: 3341
		private ulong? _uid;

		// Token: 0x04000D0E RID: 3342
		private CustomBattleConfig _config = null;

		// Token: 0x04000D0F RID: 3343
		private string _password;

		// Token: 0x04000D10 RID: 3344
		private string _token;

		// Token: 0x04000D11 RID: 3345
		private bool? _querycross;

		// Token: 0x04000D12 RID: 3346
		private string _name;

		// Token: 0x04000D13 RID: 3347
		private IExtension extensionObject;
	}
}
