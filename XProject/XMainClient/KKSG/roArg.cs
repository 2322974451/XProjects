using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000155 RID: 341
	[ProtoContract(Name = "roArg")]
	[Serializable]
	public class roArg : IExtensible
	{
		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x0002A26C File Offset: 0x0002846C
		// (set) Token: 0x060014F0 RID: 5360 RVA: 0x0002A298 File Offset: 0x00028498
		[ProtoMember(1, IsRequired = false, Name = "bNoShowLog", DataFormat = DataFormat.Default)]
		public bool bNoShowLog
		{
			get
			{
				return this._bNoShowLog ?? false;
			}
			set
			{
				this._bNoShowLog = new bool?(value);
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x0002A2A8 File Offset: 0x000284A8
		// (set) Token: 0x060014F2 RID: 5362 RVA: 0x0002A2C8 File Offset: 0x000284C8
		[XmlIgnore]
		[Browsable(false)]
		public bool bNoShowLogSpecified
		{
			get
			{
				return this._bNoShowLog != null;
			}
			set
			{
				bool flag = value == (this._bNoShowLog == null);
				if (flag)
				{
					this._bNoShowLog = (value ? new bool?(this.bNoShowLog) : null);
				}
			}
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0002A30C File Offset: 0x0002850C
		private bool ShouldSerializebNoShowLog()
		{
			return this.bNoShowLogSpecified;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0002A324 File Offset: 0x00028524
		private void ResetbNoShowLog()
		{
			this.bNoShowLogSpecified = false;
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0002A330 File Offset: 0x00028530
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000532 RID: 1330
		private bool? _bNoShowLog;

		// Token: 0x04000533 RID: 1331
		private IExtension extensionObject;
	}
}
