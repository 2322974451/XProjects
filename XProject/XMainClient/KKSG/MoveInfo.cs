using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000011 RID: 17
	[ProtoContract(Name = "MoveInfo")]
	[Serializable]
	public class MoveInfo : IExtensible
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00005210 File Offset: 0x00003410
		// (set) Token: 0x0600014C RID: 332 RVA: 0x0000523C File Offset: 0x0000343C
		[ProtoMember(1, IsRequired = false, Name = "Common", DataFormat = DataFormat.TwosComplement)]
		public int Common
		{
			get
			{
				return this._Common ?? 0;
			}
			set
			{
				this._Common = new int?(value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600014D RID: 333 RVA: 0x0000524C File Offset: 0x0000344C
		// (set) Token: 0x0600014E RID: 334 RVA: 0x0000526C File Offset: 0x0000346C
		[XmlIgnore]
		[Browsable(false)]
		public bool CommonSpecified
		{
			get
			{
				return this._Common != null;
			}
			set
			{
				bool flag = value == (this._Common == null);
				if (flag)
				{
					this._Common = (value ? new int?(this.Common) : null);
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x000052B0 File Offset: 0x000034B0
		private bool ShouldSerializeCommon()
		{
			return this.CommonSpecified;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000052C8 File Offset: 0x000034C8
		private void ResetCommon()
		{
			this.CommonSpecified = false;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000151 RID: 337 RVA: 0x000052D4 File Offset: 0x000034D4
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00005300 File Offset: 0x00003500
		[ProtoMember(2, IsRequired = false, Name = "PosXZ", DataFormat = DataFormat.TwosComplement)]
		public int PosXZ
		{
			get
			{
				return this._PosXZ ?? 0;
			}
			set
			{
				this._PosXZ = new int?(value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00005310 File Offset: 0x00003510
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00005330 File Offset: 0x00003530
		[XmlIgnore]
		[Browsable(false)]
		public bool PosXZSpecified
		{
			get
			{
				return this._PosXZ != null;
			}
			set
			{
				bool flag = value == (this._PosXZ == null);
				if (flag)
				{
					this._PosXZ = (value ? new int?(this.PosXZ) : null);
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005374 File Offset: 0x00003574
		private bool ShouldSerializePosXZ()
		{
			return this.PosXZSpecified;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000538C File Offset: 0x0000358C
		private void ResetPosXZ()
		{
			this.PosXZSpecified = false;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00005398 File Offset: 0x00003598
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000053C4 File Offset: 0x000035C4
		[ProtoMember(3, IsRequired = false, Name = "DesXZ", DataFormat = DataFormat.TwosComplement)]
		public int DesXZ
		{
			get
			{
				return this._DesXZ ?? 0;
			}
			set
			{
				this._DesXZ = new int?(value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000159 RID: 345 RVA: 0x000053D4 File Offset: 0x000035D4
		// (set) Token: 0x0600015A RID: 346 RVA: 0x000053F4 File Offset: 0x000035F4
		[XmlIgnore]
		[Browsable(false)]
		public bool DesXZSpecified
		{
			get
			{
				return this._DesXZ != null;
			}
			set
			{
				bool flag = value == (this._DesXZ == null);
				if (flag)
				{
					this._DesXZ = (value ? new int?(this.DesXZ) : null);
				}
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005438 File Offset: 0x00003638
		private bool ShouldSerializeDesXZ()
		{
			return this.DesXZSpecified;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005450 File Offset: 0x00003650
		private void ResetDesXZ()
		{
			this.DesXZSpecified = false;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000545C File Offset: 0x0000365C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400005A RID: 90
		private int? _Common;

		// Token: 0x0400005B RID: 91
		private int? _PosXZ;

		// Token: 0x0400005C RID: 92
		private int? _DesXZ;

		// Token: 0x0400005D RID: 93
		private IExtension extensionObject;
	}
}
