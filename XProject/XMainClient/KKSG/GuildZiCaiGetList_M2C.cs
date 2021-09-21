using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000540 RID: 1344
	[ProtoContract(Name = "GuildZiCaiGetList_M2C")]
	[Serializable]
	public class GuildZiCaiGetList_M2C : IExtensible
	{
		// Token: 0x1700150A RID: 5386
		// (get) Token: 0x060044D4 RID: 17620 RVA: 0x00082E74 File Offset: 0x00081074
		// (set) Token: 0x060044D5 RID: 17621 RVA: 0x00082EA0 File Offset: 0x000810A0
		[ProtoMember(1, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		// Token: 0x1700150B RID: 5387
		// (get) Token: 0x060044D6 RID: 17622 RVA: 0x00082EB0 File Offset: 0x000810B0
		// (set) Token: 0x060044D7 RID: 17623 RVA: 0x00082ED0 File Offset: 0x000810D0
		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		// Token: 0x060044D8 RID: 17624 RVA: 0x00082F14 File Offset: 0x00081114
		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		// Token: 0x060044D9 RID: 17625 RVA: 0x00082F2C File Offset: 0x0008112C
		private void Resetec()
		{
			this.ecSpecified = false;
		}

		// Token: 0x1700150C RID: 5388
		// (get) Token: 0x060044DA RID: 17626 RVA: 0x00082F38 File Offset: 0x00081138
		[ProtoMember(2, Name = "itemlist", DataFormat = DataFormat.Default)]
		public List<GuildZiCaiItemData> itemlist
		{
			get
			{
				return this._itemlist;
			}
		}

		// Token: 0x060044DB RID: 17627 RVA: 0x00082F50 File Offset: 0x00081150
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001131 RID: 4401
		private ErrorCode? _ec;

		// Token: 0x04001132 RID: 4402
		private readonly List<GuildZiCaiItemData> _itemlist = new List<GuildZiCaiItemData>();

		// Token: 0x04001133 RID: 4403
		private IExtension extensionObject;
	}
}
