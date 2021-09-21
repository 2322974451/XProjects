using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A4 RID: 1700
	[ProtoContract(Name = "SynCardAttr")]
	[Serializable]
	public class SynCardAttr : IExtensible
	{
		// Token: 0x17002318 RID: 8984
		// (get) Token: 0x06006EE0 RID: 28384 RVA: 0x000D42EC File Offset: 0x000D24EC
		[ProtoMember(1, Name = "addAttr", DataFormat = DataFormat.Default)]
		public List<CardAttr> addAttr
		{
			get
			{
				return this._addAttr;
			}
		}

		// Token: 0x17002319 RID: 8985
		// (get) Token: 0x06006EE1 RID: 28385 RVA: 0x000D4304 File Offset: 0x000D2504
		[ProtoMember(2, Name = "addper", DataFormat = DataFormat.Default)]
		public List<CardAttr> addper
		{
			get
			{
				return this._addper;
			}
		}

		// Token: 0x1700231A RID: 8986
		// (get) Token: 0x06006EE2 RID: 28386 RVA: 0x000D431C File Offset: 0x000D251C
		[ProtoMember(3, Name = "allAttr", DataFormat = DataFormat.Default)]
		public List<CardAttr> allAttr
		{
			get
			{
				return this._allAttr;
			}
		}

		// Token: 0x1700231B RID: 8987
		// (get) Token: 0x06006EE3 RID: 28387 RVA: 0x000D4334 File Offset: 0x000D2534
		// (set) Token: 0x06006EE4 RID: 28388 RVA: 0x000D4360 File Offset: 0x000D2560
		[ProtoMember(4, IsRequired = false, Name = "groupId", DataFormat = DataFormat.TwosComplement)]
		public uint groupId
		{
			get
			{
				return this._groupId ?? 0U;
			}
			set
			{
				this._groupId = new uint?(value);
			}
		}

		// Token: 0x1700231C RID: 8988
		// (get) Token: 0x06006EE5 RID: 28389 RVA: 0x000D4370 File Offset: 0x000D2570
		// (set) Token: 0x06006EE6 RID: 28390 RVA: 0x000D4390 File Offset: 0x000D2590
		[XmlIgnore]
		[Browsable(false)]
		public bool groupIdSpecified
		{
			get
			{
				return this._groupId != null;
			}
			set
			{
				bool flag = value == (this._groupId == null);
				if (flag)
				{
					this._groupId = (value ? new uint?(this.groupId) : null);
				}
			}
		}

		// Token: 0x06006EE7 RID: 28391 RVA: 0x000D43D4 File Offset: 0x000D25D4
		private bool ShouldSerializegroupId()
		{
			return this.groupIdSpecified;
		}

		// Token: 0x06006EE8 RID: 28392 RVA: 0x000D43EC File Offset: 0x000D25EC
		private void ResetgroupId()
		{
			this.groupIdSpecified = false;
		}

		// Token: 0x06006EE9 RID: 28393 RVA: 0x000D43F8 File Offset: 0x000D25F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A86 RID: 6790
		private readonly List<CardAttr> _addAttr = new List<CardAttr>();

		// Token: 0x04001A87 RID: 6791
		private readonly List<CardAttr> _addper = new List<CardAttr>();

		// Token: 0x04001A88 RID: 6792
		private readonly List<CardAttr> _allAttr = new List<CardAttr>();

		// Token: 0x04001A89 RID: 6793
		private uint? _groupId;

		// Token: 0x04001A8A RID: 6794
		private IExtension extensionObject;
	}
}
