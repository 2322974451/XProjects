using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000402 RID: 1026
	[ProtoContract(Name = "ReplyPartyExchangeItemOptRes")]
	[Serializable]
	public class ReplyPartyExchangeItemOptRes : IExtensible
	{
		// Token: 0x170010CC RID: 4300
		// (get) Token: 0x0600369B RID: 13979 RVA: 0x000689B0 File Offset: 0x00066BB0
		// (set) Token: 0x0600369C RID: 13980 RVA: 0x000689DC File Offset: 0x00066BDC
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x170010CD RID: 4301
		// (get) Token: 0x0600369D RID: 13981 RVA: 0x000689EC File Offset: 0x00066BEC
		// (set) Token: 0x0600369E RID: 13982 RVA: 0x00068A0C File Offset: 0x00066C0C
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x0600369F RID: 13983 RVA: 0x00068A50 File Offset: 0x00066C50
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x00068A68 File Offset: 0x00066C68
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x170010CE RID: 4302
		// (get) Token: 0x060036A1 RID: 13985 RVA: 0x00068A74 File Offset: 0x00066C74
		// (set) Token: 0x060036A2 RID: 13986 RVA: 0x00068AA0 File Offset: 0x00066CA0
		[ProtoMember(2, IsRequired = false, Name = "lauch_role_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_role_id
		{
			get
			{
				return this._lauch_role_id ?? 0U;
			}
			set
			{
				this._lauch_role_id = new uint?(value);
			}
		}

		// Token: 0x170010CF RID: 4303
		// (get) Token: 0x060036A3 RID: 13987 RVA: 0x00068AB0 File Offset: 0x00066CB0
		// (set) Token: 0x060036A4 RID: 13988 RVA: 0x00068AD0 File Offset: 0x00066CD0
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_role_idSpecified
		{
			get
			{
				return this._lauch_role_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_role_id == null);
				if (flag)
				{
					this._lauch_role_id = (value ? new uint?(this.lauch_role_id) : null);
				}
			}
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x00068B14 File Offset: 0x00066D14
		private bool ShouldSerializelauch_role_id()
		{
			return this.lauch_role_idSpecified;
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x00068B2C File Offset: 0x00066D2C
		private void Resetlauch_role_id()
		{
			this.lauch_role_idSpecified = false;
		}

		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x060036A7 RID: 13991 RVA: 0x00068B38 File Offset: 0x00066D38
		// (set) Token: 0x060036A8 RID: 13992 RVA: 0x00068B64 File Offset: 0x00066D64
		[ProtoMember(3, IsRequired = false, Name = "lauch_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint lauch_item_id
		{
			get
			{
				return this._lauch_item_id ?? 0U;
			}
			set
			{
				this._lauch_item_id = new uint?(value);
			}
		}

		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x060036A9 RID: 13993 RVA: 0x00068B74 File Offset: 0x00066D74
		// (set) Token: 0x060036AA RID: 13994 RVA: 0x00068B94 File Offset: 0x00066D94
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_item_idSpecified
		{
			get
			{
				return this._lauch_item_id != null;
			}
			set
			{
				bool flag = value == (this._lauch_item_id == null);
				if (flag)
				{
					this._lauch_item_id = (value ? new uint?(this.lauch_item_id) : null);
				}
			}
		}

		// Token: 0x060036AB RID: 13995 RVA: 0x00068BD8 File Offset: 0x00066DD8
		private bool ShouldSerializelauch_item_id()
		{
			return this.lauch_item_idSpecified;
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x00068BF0 File Offset: 0x00066DF0
		private void Resetlauch_item_id()
		{
			this.lauch_item_idSpecified = false;
		}

		// Token: 0x170010D2 RID: 4306
		// (get) Token: 0x060036AD RID: 13997 RVA: 0x00068BFC File Offset: 0x00066DFC
		// (set) Token: 0x060036AE RID: 13998 RVA: 0x00068C28 File Offset: 0x00066E28
		[ProtoMember(4, IsRequired = false, Name = "lauch_status", DataFormat = DataFormat.Default)]
		public bool lauch_status
		{
			get
			{
				return this._lauch_status ?? false;
			}
			set
			{
				this._lauch_status = new bool?(value);
			}
		}

		// Token: 0x170010D3 RID: 4307
		// (get) Token: 0x060036AF RID: 13999 RVA: 0x00068C38 File Offset: 0x00066E38
		// (set) Token: 0x060036B0 RID: 14000 RVA: 0x00068C58 File Offset: 0x00066E58
		[XmlIgnore]
		[Browsable(false)]
		public bool lauch_statusSpecified
		{
			get
			{
				return this._lauch_status != null;
			}
			set
			{
				bool flag = value == (this._lauch_status == null);
				if (flag)
				{
					this._lauch_status = (value ? new bool?(this.lauch_status) : null);
				}
			}
		}

		// Token: 0x060036B1 RID: 14001 RVA: 0x00068C9C File Offset: 0x00066E9C
		private bool ShouldSerializelauch_status()
		{
			return this.lauch_statusSpecified;
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x00068CB4 File Offset: 0x00066EB4
		private void Resetlauch_status()
		{
			this.lauch_statusSpecified = false;
		}

		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x060036B3 RID: 14003 RVA: 0x00068CC0 File Offset: 0x00066EC0
		// (set) Token: 0x060036B4 RID: 14004 RVA: 0x00068CEC File Offset: 0x00066EEC
		[ProtoMember(5, IsRequired = false, Name = "target_role_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_role_id
		{
			get
			{
				return this._target_role_id ?? 0U;
			}
			set
			{
				this._target_role_id = new uint?(value);
			}
		}

		// Token: 0x170010D5 RID: 4309
		// (get) Token: 0x060036B5 RID: 14005 RVA: 0x00068CFC File Offset: 0x00066EFC
		// (set) Token: 0x060036B6 RID: 14006 RVA: 0x00068D1C File Offset: 0x00066F1C
		[XmlIgnore]
		[Browsable(false)]
		public bool target_role_idSpecified
		{
			get
			{
				return this._target_role_id != null;
			}
			set
			{
				bool flag = value == (this._target_role_id == null);
				if (flag)
				{
					this._target_role_id = (value ? new uint?(this.target_role_id) : null);
				}
			}
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x00068D60 File Offset: 0x00066F60
		private bool ShouldSerializetarget_role_id()
		{
			return this.target_role_idSpecified;
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x00068D78 File Offset: 0x00066F78
		private void Resettarget_role_id()
		{
			this.target_role_idSpecified = false;
		}

		// Token: 0x170010D6 RID: 4310
		// (get) Token: 0x060036B9 RID: 14009 RVA: 0x00068D84 File Offset: 0x00066F84
		// (set) Token: 0x060036BA RID: 14010 RVA: 0x00068DB0 File Offset: 0x00066FB0
		[ProtoMember(6, IsRequired = false, Name = "target_item_id", DataFormat = DataFormat.TwosComplement)]
		public uint target_item_id
		{
			get
			{
				return this._target_item_id ?? 0U;
			}
			set
			{
				this._target_item_id = new uint?(value);
			}
		}

		// Token: 0x170010D7 RID: 4311
		// (get) Token: 0x060036BB RID: 14011 RVA: 0x00068DC0 File Offset: 0x00066FC0
		// (set) Token: 0x060036BC RID: 14012 RVA: 0x00068DE0 File Offset: 0x00066FE0
		[XmlIgnore]
		[Browsable(false)]
		public bool target_item_idSpecified
		{
			get
			{
				return this._target_item_id != null;
			}
			set
			{
				bool flag = value == (this._target_item_id == null);
				if (flag)
				{
					this._target_item_id = (value ? new uint?(this.target_item_id) : null);
				}
			}
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x00068E24 File Offset: 0x00067024
		private bool ShouldSerializetarget_item_id()
		{
			return this.target_item_idSpecified;
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x00068E3C File Offset: 0x0006703C
		private void Resettarget_item_id()
		{
			this.target_item_idSpecified = false;
		}

		// Token: 0x170010D8 RID: 4312
		// (get) Token: 0x060036BF RID: 14015 RVA: 0x00068E48 File Offset: 0x00067048
		// (set) Token: 0x060036C0 RID: 14016 RVA: 0x00068E74 File Offset: 0x00067074
		[ProtoMember(7, IsRequired = false, Name = "target_status", DataFormat = DataFormat.TwosComplement)]
		public uint target_status
		{
			get
			{
				return this._target_status ?? 0U;
			}
			set
			{
				this._target_status = new uint?(value);
			}
		}

		// Token: 0x170010D9 RID: 4313
		// (get) Token: 0x060036C1 RID: 14017 RVA: 0x00068E84 File Offset: 0x00067084
		// (set) Token: 0x060036C2 RID: 14018 RVA: 0x00068EA4 File Offset: 0x000670A4
		[XmlIgnore]
		[Browsable(false)]
		public bool target_statusSpecified
		{
			get
			{
				return this._target_status != null;
			}
			set
			{
				bool flag = value == (this._target_status == null);
				if (flag)
				{
					this._target_status = (value ? new uint?(this.target_status) : null);
				}
			}
		}

		// Token: 0x060036C3 RID: 14019 RVA: 0x00068EE8 File Offset: 0x000670E8
		private bool ShouldSerializetarget_status()
		{
			return this.target_statusSpecified;
		}

		// Token: 0x060036C4 RID: 14020 RVA: 0x00068F00 File Offset: 0x00067100
		private void Resettarget_status()
		{
			this.target_statusSpecified = false;
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x00068F0C File Offset: 0x0006710C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D8D RID: 3469
		private ErrorCode? _result;

		// Token: 0x04000D8E RID: 3470
		private uint? _lauch_role_id;

		// Token: 0x04000D8F RID: 3471
		private uint? _lauch_item_id;

		// Token: 0x04000D90 RID: 3472
		private bool? _lauch_status;

		// Token: 0x04000D91 RID: 3473
		private uint? _target_role_id;

		// Token: 0x04000D92 RID: 3474
		private uint? _target_item_id;

		// Token: 0x04000D93 RID: 3475
		private uint? _target_status;

		// Token: 0x04000D94 RID: 3476
		private IExtension extensionObject;
	}
}
