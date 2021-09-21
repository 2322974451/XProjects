using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F4 RID: 1524
	[ProtoContract(Name = "TrophyGetTypeDetail")]
	[Serializable]
	public class TrophyGetTypeDetail : IExtensible
	{
		// Token: 0x17001C5C RID: 7260
		// (get) Token: 0x06005AB5 RID: 23221 RVA: 0x000ACB6C File Offset: 0x000AAD6C
		// (set) Token: 0x06005AB6 RID: 23222 RVA: 0x000ACB98 File Offset: 0x000AAD98
		[ProtoMember(1, IsRequired = false, Name = "trophy_id", DataFormat = DataFormat.TwosComplement)]
		public uint trophy_id
		{
			get
			{
				return this._trophy_id ?? 0U;
			}
			set
			{
				this._trophy_id = new uint?(value);
			}
		}

		// Token: 0x17001C5D RID: 7261
		// (get) Token: 0x06005AB7 RID: 23223 RVA: 0x000ACBA8 File Offset: 0x000AADA8
		// (set) Token: 0x06005AB8 RID: 23224 RVA: 0x000ACBC8 File Offset: 0x000AADC8
		[XmlIgnore]
		[Browsable(false)]
		public bool trophy_idSpecified
		{
			get
			{
				return this._trophy_id != null;
			}
			set
			{
				bool flag = value == (this._trophy_id == null);
				if (flag)
				{
					this._trophy_id = (value ? new uint?(this.trophy_id) : null);
				}
			}
		}

		// Token: 0x06005AB9 RID: 23225 RVA: 0x000ACC0C File Offset: 0x000AAE0C
		private bool ShouldSerializetrophy_id()
		{
			return this.trophy_idSpecified;
		}

		// Token: 0x06005ABA RID: 23226 RVA: 0x000ACC24 File Offset: 0x000AAE24
		private void Resettrophy_id()
		{
			this.trophy_idSpecified = false;
		}

		// Token: 0x17001C5E RID: 7262
		// (get) Token: 0x06005ABB RID: 23227 RVA: 0x000ACC30 File Offset: 0x000AAE30
		[ProtoMember(2, Name = "detail", DataFormat = DataFormat.Default)]
		public List<TrophyDetail> detail
		{
			get
			{
				return this._detail;
			}
		}

		// Token: 0x06005ABC RID: 23228 RVA: 0x000ACC48 File Offset: 0x000AAE48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001611 RID: 5649
		private uint? _trophy_id;

		// Token: 0x04001612 RID: 5650
		private readonly List<TrophyDetail> _detail = new List<TrophyDetail>();

		// Token: 0x04001613 RID: 5651
		private IExtension extensionObject;
	}
}
