using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000152 RID: 338
	[ProtoContract(Name = "EnhanceTransterArg")]
	[Serializable]
	public class EnhanceTransterArg : IExtensible
	{
		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x060014A0 RID: 5280 RVA: 0x000298B0 File Offset: 0x00027AB0
		// (set) Token: 0x060014A1 RID: 5281 RVA: 0x000298DD File Offset: 0x00027ADD
		[ProtoMember(1, IsRequired = false, Name = "originuid", DataFormat = DataFormat.TwosComplement)]
		public ulong originuid
		{
			get
			{
				return this._originuid ?? 0UL;
			}
			set
			{
				this._originuid = new ulong?(value);
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x060014A2 RID: 5282 RVA: 0x000298EC File Offset: 0x00027AEC
		// (set) Token: 0x060014A3 RID: 5283 RVA: 0x0002990C File Offset: 0x00027B0C
		[XmlIgnore]
		[Browsable(false)]
		public bool originuidSpecified
		{
			get
			{
				return this._originuid != null;
			}
			set
			{
				bool flag = value == (this._originuid == null);
				if (flag)
				{
					this._originuid = (value ? new ulong?(this.originuid) : null);
				}
			}
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x00029950 File Offset: 0x00027B50
		private bool ShouldSerializeoriginuid()
		{
			return this.originuidSpecified;
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x00029968 File Offset: 0x00027B68
		private void Resetoriginuid()
		{
			this.originuidSpecified = false;
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x00029974 File Offset: 0x00027B74
		// (set) Token: 0x060014A7 RID: 5287 RVA: 0x000299A1 File Offset: 0x00027BA1
		[ProtoMember(2, IsRequired = false, Name = "destuid", DataFormat = DataFormat.TwosComplement)]
		public ulong destuid
		{
			get
			{
				return this._destuid ?? 0UL;
			}
			set
			{
				this._destuid = new ulong?(value);
			}
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x000299B0 File Offset: 0x00027BB0
		// (set) Token: 0x060014A9 RID: 5289 RVA: 0x000299D0 File Offset: 0x00027BD0
		[XmlIgnore]
		[Browsable(false)]
		public bool destuidSpecified
		{
			get
			{
				return this._destuid != null;
			}
			set
			{
				bool flag = value == (this._destuid == null);
				if (flag)
				{
					this._destuid = (value ? new ulong?(this.destuid) : null);
				}
			}
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x00029A14 File Offset: 0x00027C14
		private bool ShouldSerializedestuid()
		{
			return this.destuidSpecified;
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x00029A2C File Offset: 0x00027C2C
		private void Resetdestuid()
		{
			this.destuidSpecified = false;
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x00029A38 File Offset: 0x00027C38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000522 RID: 1314
		private ulong? _originuid;

		// Token: 0x04000523 RID: 1315
		private ulong? _destuid;

		// Token: 0x04000524 RID: 1316
		private IExtension extensionObject;
	}
}
