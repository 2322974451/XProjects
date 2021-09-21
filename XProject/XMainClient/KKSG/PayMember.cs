using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069E RID: 1694
	[ProtoContract(Name = "PayMember")]
	[Serializable]
	public class PayMember : IExtensible
	{
		// Token: 0x170022E0 RID: 8928
		// (get) Token: 0x06006E32 RID: 28210 RVA: 0x000D2D98 File Offset: 0x000D0F98
		// (set) Token: 0x06006E33 RID: 28211 RVA: 0x000D2DC4 File Offset: 0x000D0FC4
		[ProtoMember(1, IsRequired = false, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public int ID
		{
			get
			{
				return this._ID ?? 0;
			}
			set
			{
				this._ID = new int?(value);
			}
		}

		// Token: 0x170022E1 RID: 8929
		// (get) Token: 0x06006E34 RID: 28212 RVA: 0x000D2DD4 File Offset: 0x000D0FD4
		// (set) Token: 0x06006E35 RID: 28213 RVA: 0x000D2DF4 File Offset: 0x000D0FF4
		[XmlIgnore]
		[Browsable(false)]
		public bool IDSpecified
		{
			get
			{
				return this._ID != null;
			}
			set
			{
				bool flag = value == (this._ID == null);
				if (flag)
				{
					this._ID = (value ? new int?(this.ID) : null);
				}
			}
		}

		// Token: 0x06006E36 RID: 28214 RVA: 0x000D2E38 File Offset: 0x000D1038
		private bool ShouldSerializeID()
		{
			return this.IDSpecified;
		}

		// Token: 0x06006E37 RID: 28215 RVA: 0x000D2E50 File Offset: 0x000D1050
		private void ResetID()
		{
			this.IDSpecified = false;
		}

		// Token: 0x170022E2 RID: 8930
		// (get) Token: 0x06006E38 RID: 28216 RVA: 0x000D2E5C File Offset: 0x000D105C
		// (set) Token: 0x06006E39 RID: 28217 RVA: 0x000D2E88 File Offset: 0x000D1088
		[ProtoMember(2, IsRequired = false, Name = "ExpireTime", DataFormat = DataFormat.TwosComplement)]
		public int ExpireTime
		{
			get
			{
				return this._ExpireTime ?? 0;
			}
			set
			{
				this._ExpireTime = new int?(value);
			}
		}

		// Token: 0x170022E3 RID: 8931
		// (get) Token: 0x06006E3A RID: 28218 RVA: 0x000D2E98 File Offset: 0x000D1098
		// (set) Token: 0x06006E3B RID: 28219 RVA: 0x000D2EB8 File Offset: 0x000D10B8
		[XmlIgnore]
		[Browsable(false)]
		public bool ExpireTimeSpecified
		{
			get
			{
				return this._ExpireTime != null;
			}
			set
			{
				bool flag = value == (this._ExpireTime == null);
				if (flag)
				{
					this._ExpireTime = (value ? new int?(this.ExpireTime) : null);
				}
			}
		}

		// Token: 0x06006E3C RID: 28220 RVA: 0x000D2EFC File Offset: 0x000D10FC
		private bool ShouldSerializeExpireTime()
		{
			return this.ExpireTimeSpecified;
		}

		// Token: 0x06006E3D RID: 28221 RVA: 0x000D2F14 File Offset: 0x000D1114
		private void ResetExpireTime()
		{
			this.ExpireTimeSpecified = false;
		}

		// Token: 0x170022E4 RID: 8932
		// (get) Token: 0x06006E3E RID: 28222 RVA: 0x000D2F20 File Offset: 0x000D1120
		// (set) Token: 0x06006E3F RID: 28223 RVA: 0x000D2F4C File Offset: 0x000D114C
		[ProtoMember(3, IsRequired = false, Name = "isClick", DataFormat = DataFormat.Default)]
		public bool isClick
		{
			get
			{
				return this._isClick ?? false;
			}
			set
			{
				this._isClick = new bool?(value);
			}
		}

		// Token: 0x170022E5 RID: 8933
		// (get) Token: 0x06006E40 RID: 28224 RVA: 0x000D2F5C File Offset: 0x000D115C
		// (set) Token: 0x06006E41 RID: 28225 RVA: 0x000D2F7C File Offset: 0x000D117C
		[XmlIgnore]
		[Browsable(false)]
		public bool isClickSpecified
		{
			get
			{
				return this._isClick != null;
			}
			set
			{
				bool flag = value == (this._isClick == null);
				if (flag)
				{
					this._isClick = (value ? new bool?(this.isClick) : null);
				}
			}
		}

		// Token: 0x06006E42 RID: 28226 RVA: 0x000D2FC0 File Offset: 0x000D11C0
		private bool ShouldSerializeisClick()
		{
			return this.isClickSpecified;
		}

		// Token: 0x06006E43 RID: 28227 RVA: 0x000D2FD8 File Offset: 0x000D11D8
		private void ResetisClick()
		{
			this.isClickSpecified = false;
		}

		// Token: 0x06006E44 RID: 28228 RVA: 0x000D2FE4 File Offset: 0x000D11E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A62 RID: 6754
		private int? _ID;

		// Token: 0x04001A63 RID: 6755
		private int? _ExpireTime;

		// Token: 0x04001A64 RID: 6756
		private bool? _isClick;

		// Token: 0x04001A65 RID: 6757
		private IExtension extensionObject;
	}
}
