using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000285 RID: 645
	[ProtoContract(Name = "GardenStealRes")]
	[Serializable]
	public class GardenStealRes : IExtensible
	{
		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x06002408 RID: 9224 RVA: 0x00046570 File Offset: 0x00044770
		// (set) Token: 0x06002409 RID: 9225 RVA: 0x0004659C File Offset: 0x0004479C
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

		// Token: 0x17000B34 RID: 2868
		// (get) Token: 0x0600240A RID: 9226 RVA: 0x000465AC File Offset: 0x000447AC
		// (set) Token: 0x0600240B RID: 9227 RVA: 0x000465CC File Offset: 0x000447CC
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

		// Token: 0x0600240C RID: 9228 RVA: 0x00046610 File Offset: 0x00044810
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x00046628 File Offset: 0x00044828
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000B35 RID: 2869
		// (get) Token: 0x0600240E RID: 9230 RVA: 0x00046634 File Offset: 0x00044834
		[ProtoMember(2, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x0004664C File Offset: 0x0004484C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008EA RID: 2282
		private ErrorCode? _result;

		// Token: 0x040008EB RID: 2283
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040008EC RID: 2284
		private IExtension extensionObject;
	}
}
