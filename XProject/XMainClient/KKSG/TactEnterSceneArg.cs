using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000485 RID: 1157
	[ProtoContract(Name = "TactEnterSceneArg")]
	[Serializable]
	public class TactEnterSceneArg : IExtensible
	{
		// Token: 0x1700128B RID: 4747
		// (get) Token: 0x06003C76 RID: 15478 RVA: 0x000737CC File Offset: 0x000719CC
		// (set) Token: 0x06003C77 RID: 15479 RVA: 0x000737F8 File Offset: 0x000719F8
		[ProtoMember(1, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x1700128C RID: 4748
		// (get) Token: 0x06003C78 RID: 15480 RVA: 0x00073808 File Offset: 0x00071A08
		// (set) Token: 0x06003C79 RID: 15481 RVA: 0x00073828 File Offset: 0x00071A28
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x06003C7A RID: 15482 RVA: 0x0007386C File Offset: 0x00071A6C
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x06003C7B RID: 15483 RVA: 0x00073884 File Offset: 0x00071A84
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x1700128D RID: 4749
		// (get) Token: 0x06003C7C RID: 15484 RVA: 0x00073890 File Offset: 0x00071A90
		// (set) Token: 0x06003C7D RID: 15485 RVA: 0x000738BC File Offset: 0x00071ABC
		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x1700128E RID: 4750
		// (get) Token: 0x06003C7E RID: 15486 RVA: 0x000738CC File Offset: 0x00071ACC
		// (set) Token: 0x06003C7F RID: 15487 RVA: 0x000738EC File Offset: 0x00071AEC
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06003C80 RID: 15488 RVA: 0x00073930 File Offset: 0x00071B30
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06003C81 RID: 15489 RVA: 0x00073948 File Offset: 0x00071B48
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x06003C82 RID: 15490 RVA: 0x00073954 File Offset: 0x00071B54
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F0D RID: 3853
		private uint? _actid;

		// Token: 0x04000F0E RID: 3854
		private uint? _sceneid;

		// Token: 0x04000F0F RID: 3855
		private IExtension extensionObject;
	}
}
