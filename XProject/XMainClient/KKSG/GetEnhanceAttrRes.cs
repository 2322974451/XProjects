using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200044B RID: 1099
	[ProtoContract(Name = "GetEnhanceAttrRes")]
	[Serializable]
	public class GetEnhanceAttrRes : IExtensible
	{
		// Token: 0x170011D0 RID: 4560
		// (get) Token: 0x06003A0E RID: 14862 RVA: 0x0006F114 File Offset: 0x0006D314
		// (set) Token: 0x06003A0F RID: 14863 RVA: 0x0006F140 File Offset: 0x0006D340
		[ProtoMember(1, IsRequired = false, Name = "isEnd", DataFormat = DataFormat.Default)]
		public bool isEnd
		{
			get
			{
				return this._isEnd ?? false;
			}
			set
			{
				this._isEnd = new bool?(value);
			}
		}

		// Token: 0x170011D1 RID: 4561
		// (get) Token: 0x06003A10 RID: 14864 RVA: 0x0006F150 File Offset: 0x0006D350
		// (set) Token: 0x06003A11 RID: 14865 RVA: 0x0006F170 File Offset: 0x0006D370
		[XmlIgnore]
		[Browsable(false)]
		public bool isEndSpecified
		{
			get
			{
				return this._isEnd != null;
			}
			set
			{
				bool flag = value == (this._isEnd == null);
				if (flag)
				{
					this._isEnd = (value ? new bool?(this.isEnd) : null);
				}
			}
		}

		// Token: 0x06003A12 RID: 14866 RVA: 0x0006F1B4 File Offset: 0x0006D3B4
		private bool ShouldSerializeisEnd()
		{
			return this.isEndSpecified;
		}

		// Token: 0x06003A13 RID: 14867 RVA: 0x0006F1CC File Offset: 0x0006D3CC
		private void ResetisEnd()
		{
			this.isEndSpecified = false;
		}

		// Token: 0x170011D2 RID: 4562
		// (get) Token: 0x06003A14 RID: 14868 RVA: 0x0006F1D8 File Offset: 0x0006D3D8
		[ProtoMember(2, Name = "attrs", DataFormat = DataFormat.Default)]
		public List<AttributeInfo> attrs
		{
			get
			{
				return this._attrs;
			}
		}

		// Token: 0x06003A15 RID: 14869 RVA: 0x0006F1F0 File Offset: 0x0006D3F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E64 RID: 3684
		private bool? _isEnd;

		// Token: 0x04000E65 RID: 3685
		private readonly List<AttributeInfo> _attrs = new List<AttributeInfo>();

		// Token: 0x04000E66 RID: 3686
		private IExtension extensionObject;
	}
}
