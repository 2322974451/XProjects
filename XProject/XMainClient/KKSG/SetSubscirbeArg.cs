using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038F RID: 911
	[ProtoContract(Name = "SetSubscirbeArg")]
	[Serializable]
	public class SetSubscirbeArg : IExtensible
	{
		// Token: 0x17000F44 RID: 3908
		// (get) Token: 0x0600315D RID: 12637 RVA: 0x0005F1B4 File Offset: 0x0005D3B4
		[ProtoMember(1, Name = "msgid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> msgid
		{
			get
			{
				return this._msgid;
			}
		}

		// Token: 0x17000F45 RID: 3909
		// (get) Token: 0x0600315E RID: 12638 RVA: 0x0005F1CC File Offset: 0x0005D3CC
		// (set) Token: 0x0600315F RID: 12639 RVA: 0x0005F1F8 File Offset: 0x0005D3F8
		[ProtoMember(2, IsRequired = false, Name = "msgtype", DataFormat = DataFormat.TwosComplement)]
		public int msgtype
		{
			get
			{
				return this._msgtype ?? 0;
			}
			set
			{
				this._msgtype = new int?(value);
			}
		}

		// Token: 0x17000F46 RID: 3910
		// (get) Token: 0x06003160 RID: 12640 RVA: 0x0005F208 File Offset: 0x0005D408
		// (set) Token: 0x06003161 RID: 12641 RVA: 0x0005F228 File Offset: 0x0005D428
		[XmlIgnore]
		[Browsable(false)]
		public bool msgtypeSpecified
		{
			get
			{
				return this._msgtype != null;
			}
			set
			{
				bool flag = value == (this._msgtype == null);
				if (flag)
				{
					this._msgtype = (value ? new int?(this.msgtype) : null);
				}
			}
		}

		// Token: 0x06003162 RID: 12642 RVA: 0x0005F26C File Offset: 0x0005D46C
		private bool ShouldSerializemsgtype()
		{
			return this.msgtypeSpecified;
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x0005F284 File Offset: 0x0005D484
		private void Resetmsgtype()
		{
			this.msgtypeSpecified = false;
		}

		// Token: 0x17000F47 RID: 3911
		// (get) Token: 0x06003164 RID: 12644 RVA: 0x0005F290 File Offset: 0x0005D490
		// (set) Token: 0x06003165 RID: 12645 RVA: 0x0005F2B1 File Offset: 0x0005D4B1
		[ProtoMember(3, IsRequired = false, Name = "token", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000F48 RID: 3912
		// (get) Token: 0x06003166 RID: 12646 RVA: 0x0005F2BC File Offset: 0x0005D4BC
		// (set) Token: 0x06003167 RID: 12647 RVA: 0x0005F2D8 File Offset: 0x0005D4D8
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

		// Token: 0x06003168 RID: 12648 RVA: 0x0005F308 File Offset: 0x0005D508
		private bool ShouldSerializetoken()
		{
			return this.tokenSpecified;
		}

		// Token: 0x06003169 RID: 12649 RVA: 0x0005F320 File Offset: 0x0005D520
		private void Resettoken()
		{
			this.tokenSpecified = false;
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x0005F32C File Offset: 0x0005D52C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C42 RID: 3138
		private readonly List<uint> _msgid = new List<uint>();

		// Token: 0x04000C43 RID: 3139
		private int? _msgtype;

		// Token: 0x04000C44 RID: 3140
		private string _token;

		// Token: 0x04000C45 RID: 3141
		private IExtension extensionObject;
	}
}
