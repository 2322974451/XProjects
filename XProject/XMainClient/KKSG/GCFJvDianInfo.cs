using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DE RID: 1758
	[ProtoContract(Name = "GCFJvDianInfo")]
	[Serializable]
	public class GCFJvDianInfo : IExtensible
	{
		// Token: 0x1700251F RID: 9503
		// (get) Token: 0x0600753B RID: 30011 RVA: 0x000E04CC File Offset: 0x000DE6CC
		// (set) Token: 0x0600753C RID: 30012 RVA: 0x000E04F8 File Offset: 0x000DE6F8
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GCFJvDianType type
		{
			get
			{
				return this._type ?? GCFJvDianType.GCF_JUDIAN_UP;
			}
			set
			{
				this._type = new GCFJvDianType?(value);
			}
		}

		// Token: 0x17002520 RID: 9504
		// (get) Token: 0x0600753D RID: 30013 RVA: 0x000E0508 File Offset: 0x000DE708
		// (set) Token: 0x0600753E RID: 30014 RVA: 0x000E0528 File Offset: 0x000DE728
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new GCFJvDianType?(this.type) : null);
				}
			}
		}

		// Token: 0x0600753F RID: 30015 RVA: 0x000E056C File Offset: 0x000DE76C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007540 RID: 30016 RVA: 0x000E0584 File Offset: 0x000DE784
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17002521 RID: 9505
		// (get) Token: 0x06007541 RID: 30017 RVA: 0x000E0590 File Offset: 0x000DE790
		// (set) Token: 0x06007542 RID: 30018 RVA: 0x000E05B1 File Offset: 0x000DE7B1
		[ProtoMember(2, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		// Token: 0x17002522 RID: 9506
		// (get) Token: 0x06007543 RID: 30019 RVA: 0x000E05BC File Offset: 0x000DE7BC
		// (set) Token: 0x06007544 RID: 30020 RVA: 0x000E05D8 File Offset: 0x000DE7D8
		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		// Token: 0x06007545 RID: 30021 RVA: 0x000E0608 File Offset: 0x000DE808
		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		// Token: 0x06007546 RID: 30022 RVA: 0x000E0620 File Offset: 0x000DE820
		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		// Token: 0x06007547 RID: 30023 RVA: 0x000E062C File Offset: 0x000DE82C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BD3 RID: 7123
		private GCFJvDianType? _type;

		// Token: 0x04001BD4 RID: 7124
		private string _guildname;

		// Token: 0x04001BD5 RID: 7125
		private IExtension extensionObject;
	}
}
