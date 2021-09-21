using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000328 RID: 808
	[ProtoContract(Name = "HorseReConnectRes")]
	[Serializable]
	public class HorseReConnectRes : IExtensible
	{
		// Token: 0x17000DD2 RID: 3538
		// (get) Token: 0x06002C94 RID: 11412 RVA: 0x00056578 File Offset: 0x00054778
		// (set) Token: 0x06002C95 RID: 11413 RVA: 0x000565A4 File Offset: 0x000547A4
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000DD3 RID: 3539
		// (get) Token: 0x06002C96 RID: 11414 RVA: 0x000565B4 File Offset: 0x000547B4
		// (set) Token: 0x06002C97 RID: 11415 RVA: 0x000565D4 File Offset: 0x000547D4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06002C98 RID: 11416 RVA: 0x00056618 File Offset: 0x00054818
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002C99 RID: 11417 RVA: 0x00056630 File Offset: 0x00054830
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000DD4 RID: 3540
		// (get) Token: 0x06002C9A RID: 11418 RVA: 0x0005663C File Offset: 0x0005483C
		// (set) Token: 0x06002C9B RID: 11419 RVA: 0x00056654 File Offset: 0x00054854
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseRank rank
		{
			get
			{
				return this._rank;
			}
			set
			{
				this._rank = value;
			}
		}

		// Token: 0x17000DD5 RID: 3541
		// (get) Token: 0x06002C9C RID: 11420 RVA: 0x00056660 File Offset: 0x00054860
		// (set) Token: 0x06002C9D RID: 11421 RVA: 0x00056678 File Offset: 0x00054878
		[ProtoMember(3, IsRequired = false, Name = "selfarrive", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseFinal selfarrive
		{
			get
			{
				return this._selfarrive;
			}
			set
			{
				this._selfarrive = value;
			}
		}

		// Token: 0x17000DD6 RID: 3542
		// (get) Token: 0x06002C9E RID: 11422 RVA: 0x00056684 File Offset: 0x00054884
		// (set) Token: 0x06002C9F RID: 11423 RVA: 0x0005669C File Offset: 0x0005489C
		[ProtoMember(4, IsRequired = false, Name = "otherreach", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HorseAnimation otherreach
		{
			get
			{
				return this._otherreach;
			}
			set
			{
				this._otherreach = value;
			}
		}

		// Token: 0x17000DD7 RID: 3543
		// (get) Token: 0x06002CA0 RID: 11424 RVA: 0x000566A8 File Offset: 0x000548A8
		[ProtoMember(5, Name = "item", DataFormat = DataFormat.Default)]
		public List<DoodadItemAddNtf> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x06002CA1 RID: 11425 RVA: 0x000566C0 File Offset: 0x000548C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B07 RID: 2823
		private ErrorCode? _error;

		// Token: 0x04000B08 RID: 2824
		private HorseRank _rank = null;

		// Token: 0x04000B09 RID: 2825
		private HorseFinal _selfarrive = null;

		// Token: 0x04000B0A RID: 2826
		private HorseAnimation _otherreach = null;

		// Token: 0x04000B0B RID: 2827
		private readonly List<DoodadItemAddNtf> _item = new List<DoodadItemAddNtf>();

		// Token: 0x04000B0C RID: 2828
		private IExtension extensionObject;
	}
}
