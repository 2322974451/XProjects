using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000048 RID: 72
	[ProtoContract(Name = "GetActivityChestRes")]
	[Serializable]
	public class GetActivityChestRes : IExtensible
	{
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0000C200 File Offset: 0x0000A400
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x0000C22C File Offset: 0x0000A42C
		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0000C23C File Offset: 0x0000A43C
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0000C25C File Offset: 0x0000A45C
		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x0000C2B8 File Offset: 0x0000A4B8
		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		[ProtoMember(2, IsRequired = false, Name = "ChestGetInfo", DataFormat = DataFormat.TwosComplement)]
		public uint ChestGetInfo
		{
			get
			{
				return this._ChestGetInfo ?? 0U;
			}
			set
			{
				this._ChestGetInfo = new uint?(value);
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000C300 File Offset: 0x0000A500
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0000C320 File Offset: 0x0000A520
		[XmlIgnore]
		[Browsable(false)]
		public bool ChestGetInfoSpecified
		{
			get
			{
				return this._ChestGetInfo != null;
			}
			set
			{
				bool flag = value == (this._ChestGetInfo == null);
				if (flag)
				{
					this._ChestGetInfo = (value ? new uint?(this.ChestGetInfo) : null);
				}
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0000C364 File Offset: 0x0000A564
		private bool ShouldSerializeChestGetInfo()
		{
			return this.ChestGetInfoSpecified;
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0000C37C File Offset: 0x0000A57C
		private void ResetChestGetInfo()
		{
			this.ChestGetInfoSpecified = false;
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000C388 File Offset: 0x0000A588
		[ProtoMember(3, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemId
		{
			get
			{
				return this._ItemId;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060004F8 RID: 1272 RVA: 0x0000C3A0 File Offset: 0x0000A5A0
		[ProtoMember(4, Name = "ItemCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ItemCount
		{
			get
			{
				return this._ItemCount;
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000144 RID: 324
		private ErrorCode? _ErrorCode;

		// Token: 0x04000145 RID: 325
		private uint? _ChestGetInfo;

		// Token: 0x04000146 RID: 326
		private readonly List<uint> _ItemId = new List<uint>();

		// Token: 0x04000147 RID: 327
		private readonly List<uint> _ItemCount = new List<uint>();

		// Token: 0x04000148 RID: 328
		private IExtension extensionObject;
	}
}
