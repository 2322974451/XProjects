using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F4 RID: 500
	[ProtoContract(Name = "ItemFindBackData")]
	[Serializable]
	public class ItemFindBackData : IExtensible
	{
		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x06001C84 RID: 7300 RVA: 0x00038324 File Offset: 0x00036524
		// (set) Token: 0x06001C85 RID: 7301 RVA: 0x00038350 File Offset: 0x00036550
		[ProtoMember(1, IsRequired = false, Name = "isDayFirstNofity", DataFormat = DataFormat.Default)]
		public bool isDayFirstNofity
		{
			get
			{
				return this._isDayFirstNofity ?? false;
			}
			set
			{
				this._isDayFirstNofity = new bool?(value);
			}
		}

		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x06001C86 RID: 7302 RVA: 0x00038360 File Offset: 0x00036560
		// (set) Token: 0x06001C87 RID: 7303 RVA: 0x00038380 File Offset: 0x00036580
		[XmlIgnore]
		[Browsable(false)]
		public bool isDayFirstNofitySpecified
		{
			get
			{
				return this._isDayFirstNofity != null;
			}
			set
			{
				bool flag = value == (this._isDayFirstNofity == null);
				if (flag)
				{
					this._isDayFirstNofity = (value ? new bool?(this.isDayFirstNofity) : null);
				}
			}
		}

		// Token: 0x06001C88 RID: 7304 RVA: 0x000383C4 File Offset: 0x000365C4
		private bool ShouldSerializeisDayFirstNofity()
		{
			return this.isDayFirstNofitySpecified;
		}

		// Token: 0x06001C89 RID: 7305 RVA: 0x000383DC File Offset: 0x000365DC
		private void ResetisDayFirstNofity()
		{
			this.isDayFirstNofitySpecified = false;
		}

		// Token: 0x06001C8A RID: 7306 RVA: 0x000383E8 File Offset: 0x000365E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000719 RID: 1817
		private bool? _isDayFirstNofity;

		// Token: 0x0400071A RID: 1818
		private IExtension extensionObject;
	}
}
