using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027E RID: 638
	[ProtoContract(Name = "BanquetAwardRes")]
	[Serializable]
	public class BanquetAwardRes : IExtensible
	{
		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x0600237B RID: 9083 RVA: 0x00045450 File Offset: 0x00043650
		// (set) Token: 0x0600237C RID: 9084 RVA: 0x0004547C File Offset: 0x0004367C
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

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x0600237D RID: 9085 RVA: 0x0004548C File Offset: 0x0004368C
		// (set) Token: 0x0600237E RID: 9086 RVA: 0x000454AC File Offset: 0x000436AC
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

		// Token: 0x0600237F RID: 9087 RVA: 0x000454F0 File Offset: 0x000436F0
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002380 RID: 9088 RVA: 0x00045508 File Offset: 0x00043708
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06002381 RID: 9089 RVA: 0x00045514 File Offset: 0x00043714
		// (set) Token: 0x06002382 RID: 9090 RVA: 0x00045540 File Offset: 0x00043740
		[ProtoMember(2, IsRequired = false, Name = "banquet_id", DataFormat = DataFormat.TwosComplement)]
		public uint banquet_id
		{
			get
			{
				return this._banquet_id ?? 0U;
			}
			set
			{
				this._banquet_id = new uint?(value);
			}
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x00045550 File Offset: 0x00043750
		// (set) Token: 0x06002384 RID: 9092 RVA: 0x00045570 File Offset: 0x00043770
		[XmlIgnore]
		[Browsable(false)]
		public bool banquet_idSpecified
		{
			get
			{
				return this._banquet_id != null;
			}
			set
			{
				bool flag = value == (this._banquet_id == null);
				if (flag)
				{
					this._banquet_id = (value ? new uint?(this.banquet_id) : null);
				}
			}
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x000455B4 File Offset: 0x000437B4
		private bool ShouldSerializebanquet_id()
		{
			return this.banquet_idSpecified;
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x000455CC File Offset: 0x000437CC
		private void Resetbanquet_id()
		{
			this.banquet_idSpecified = false;
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x000455D8 File Offset: 0x000437D8
		[ProtoMember(3, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x000455F0 File Offset: 0x000437F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008CD RID: 2253
		private ErrorCode? _result;

		// Token: 0x040008CE RID: 2254
		private uint? _banquet_id;

		// Token: 0x040008CF RID: 2255
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040008D0 RID: 2256
		private IExtension extensionObject;
	}
}
