using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200004A RID: 74
	[ProtoContract(Name = "FashionComposeArg")]
	[Serializable]
	public class FashionComposeArg : IExtensible
	{
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000C4BC File Offset: 0x0000A6BC
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000C4E8 File Offset: 0x0000A6E8
		[ProtoMember(1, IsRequired = false, Name = "fashion_id", DataFormat = DataFormat.TwosComplement)]
		public uint fashion_id
		{
			get
			{
				return this._fashion_id ?? 0U;
			}
			set
			{
				this._fashion_id = new uint?(value);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000C4F8 File Offset: 0x0000A6F8
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x0000C518 File Offset: 0x0000A718
		[XmlIgnore]
		[Browsable(false)]
		public bool fashion_idSpecified
		{
			get
			{
				return this._fashion_id != null;
			}
			set
			{
				bool flag = value == (this._fashion_id == null);
				if (flag)
				{
					this._fashion_id = (value ? new uint?(this.fashion_id) : null);
				}
			}
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0000C55C File Offset: 0x0000A75C
		private bool ShouldSerializefashion_id()
		{
			return this.fashion_idSpecified;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0000C574 File Offset: 0x0000A774
		private void Resetfashion_id()
		{
			this.fashion_idSpecified = false;
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x0000C580 File Offset: 0x0000A780
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x0000C5A1 File Offset: 0x0000A7A1
		[ProtoMember(2, IsRequired = false, Name = "uid1", DataFormat = DataFormat.Default)]
		public string uid1
		{
			get
			{
				return this._uid1 ?? "";
			}
			set
			{
				this._uid1 = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0000C5AC File Offset: 0x0000A7AC
		// (set) Token: 0x0600050C RID: 1292 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
		[XmlIgnore]
		[Browsable(false)]
		public bool uid1Specified
		{
			get
			{
				return this._uid1 != null;
			}
			set
			{
				bool flag = value == (this._uid1 == null);
				if (flag)
				{
					this._uid1 = (value ? this.uid1 : null);
				}
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0000C5F8 File Offset: 0x0000A7F8
		private bool ShouldSerializeuid1()
		{
			return this.uid1Specified;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0000C610 File Offset: 0x0000A810
		private void Resetuid1()
		{
			this.uid1Specified = false;
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0000C61C File Offset: 0x0000A81C
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0000C63D File Offset: 0x0000A83D
		[ProtoMember(3, IsRequired = false, Name = "uid2", DataFormat = DataFormat.Default)]
		public string uid2
		{
			get
			{
				return this._uid2 ?? "";
			}
			set
			{
				this._uid2 = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0000C648 File Offset: 0x0000A848
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x0000C664 File Offset: 0x0000A864
		[XmlIgnore]
		[Browsable(false)]
		public bool uid2Specified
		{
			get
			{
				return this._uid2 != null;
			}
			set
			{
				bool flag = value == (this._uid2 == null);
				if (flag)
				{
					this._uid2 = (value ? this.uid2 : null);
				}
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0000C694 File Offset: 0x0000A894
		private bool ShouldSerializeuid2()
		{
			return this.uid2Specified;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x0000C6AC File Offset: 0x0000A8AC
		private void Resetuid2()
		{
			this.uid2Specified = false;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000C6B8 File Offset: 0x0000A8B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400014B RID: 331
		private uint? _fashion_id;

		// Token: 0x0400014C RID: 332
		private string _uid1;

		// Token: 0x0400014D RID: 333
		private string _uid2;

		// Token: 0x0400014E RID: 334
		private IExtension extensionObject;
	}
}
