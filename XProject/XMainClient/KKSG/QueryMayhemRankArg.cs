using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200043D RID: 1085
	[ProtoContract(Name = "QueryMayhemRankArg")]
	[Serializable]
	public class QueryMayhemRankArg : IExtensible
	{
		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x0600393F RID: 14655 RVA: 0x0006D85C File Offset: 0x0006BA5C
		// (set) Token: 0x06003940 RID: 14656 RVA: 0x0006D888 File Offset: 0x0006BA88
		[ProtoMember(1, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		// Token: 0x17001193 RID: 4499
		// (get) Token: 0x06003941 RID: 14657 RVA: 0x0006D898 File Offset: 0x0006BA98
		// (set) Token: 0x06003942 RID: 14658 RVA: 0x0006D8B8 File Offset: 0x0006BAB8
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x0006D8FC File Offset: 0x0006BAFC
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06003944 RID: 14660 RVA: 0x0006D914 File Offset: 0x0006BB14
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x0006D920 File Offset: 0x0006BB20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E35 RID: 3637
		private int? _count;

		// Token: 0x04000E36 RID: 3638
		private IExtension extensionObject;
	}
}
