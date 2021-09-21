using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200002E RID: 46
	[ProtoContract(Name = "DrawLotteryRes")]
	[Serializable]
	public class DrawLotteryRes : IExtensible
	{
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00008BD8 File Offset: 0x00006DD8
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00008C04 File Offset: 0x00006E04
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00008C14 File Offset: 0x00006E14
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00008C34 File Offset: 0x00006E34
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00008C78 File Offset: 0x00006E78
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00008C90 File Offset: 0x00006E90
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00008C9C File Offset: 0x00006E9C
		[ProtoMember(2, Name = "Items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> Items
		{
			get
			{
				return this._Items;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00008CB4 File Offset: 0x00006EB4
		// (set) Token: 0x0600032F RID: 815 RVA: 0x00008CE0 File Offset: 0x00006EE0
		[ProtoMember(3, IsRequired = false, Name = "nextgoodcount", DataFormat = DataFormat.TwosComplement)]
		public uint nextgoodcount
		{
			get
			{
				return this._nextgoodcount ?? 0U;
			}
			set
			{
				this._nextgoodcount = new uint?(value);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000330 RID: 816 RVA: 0x00008CF0 File Offset: 0x00006EF0
		// (set) Token: 0x06000331 RID: 817 RVA: 0x00008D10 File Offset: 0x00006F10
		[XmlIgnore]
		[Browsable(false)]
		public bool nextgoodcountSpecified
		{
			get
			{
				return this._nextgoodcount != null;
			}
			set
			{
				bool flag = value == (this._nextgoodcount == null);
				if (flag)
				{
					this._nextgoodcount = (value ? new uint?(this.nextgoodcount) : null);
				}
			}
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00008D54 File Offset: 0x00006F54
		private bool ShouldSerializenextgoodcount()
		{
			return this.nextgoodcountSpecified;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00008D6C File Offset: 0x00006F6C
		private void Resetnextgoodcount()
		{
			this.nextgoodcountSpecified = false;
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00008D78 File Offset: 0x00006F78
		[ProtoMember(4, Name = "spriteppt", DataFormat = DataFormat.TwosComplement)]
		public List<uint> spriteppt
		{
			get
			{
				return this._spriteppt;
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00008D90 File Offset: 0x00006F90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000D4 RID: 212
		private ErrorCode? _errorcode;

		// Token: 0x040000D5 RID: 213
		private readonly List<ItemBrief> _Items = new List<ItemBrief>();

		// Token: 0x040000D6 RID: 214
		private uint? _nextgoodcount;

		// Token: 0x040000D7 RID: 215
		private readonly List<uint> _spriteppt = new List<uint>();

		// Token: 0x040000D8 RID: 216
		private IExtension extensionObject;
	}
}
