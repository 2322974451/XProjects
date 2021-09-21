using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000021 RID: 33
	[ProtoContract(Name = "SelectChestRes")]
	[Serializable]
	public class SelectChestRes : IExtensible
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600026F RID: 623 RVA: 0x000075C8 File Offset: 0x000057C8
		[ProtoMember(1, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<BattleRewardChest> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000270 RID: 624 RVA: 0x000075E0 File Offset: 0x000057E0
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0000760C File Offset: 0x0000580C
		[ProtoMember(2, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000761C File Offset: 0x0000581C
		// (set) Token: 0x06000273 RID: 627 RVA: 0x0000763C File Offset: 0x0000583C
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00007680 File Offset: 0x00005880
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00007698 File Offset: 0x00005898
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000076A4 File Offset: 0x000058A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040000A6 RID: 166
		private readonly List<BattleRewardChest> _rewards = new List<BattleRewardChest>();

		// Token: 0x040000A7 RID: 167
		private ErrorCode? _errcode;

		// Token: 0x040000A8 RID: 168
		private IExtension extensionObject;
	}
}
