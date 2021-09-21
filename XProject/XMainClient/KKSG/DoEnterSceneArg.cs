using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000188 RID: 392
	[ProtoContract(Name = "DoEnterSceneArg")]
	[Serializable]
	public class DoEnterSceneArg : IExtensible
	{
		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x0002F598 File Offset: 0x0002D798
		// (set) Token: 0x060017B7 RID: 6071 RVA: 0x0002F5C4 File Offset: 0x0002D7C4
		[ProtoMember(1, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0002F5D4 File Offset: 0x0002D7D4
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x0002F5F4 File Offset: 0x0002D7F4
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

		// Token: 0x060017BA RID: 6074 RVA: 0x0002F638 File Offset: 0x0002D838
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x060017BB RID: 6075 RVA: 0x0002F650 File Offset: 0x0002D850
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x060017BC RID: 6076 RVA: 0x0002F65C File Offset: 0x0002D85C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005DA RID: 1498
		private uint? _sceneid;

		// Token: 0x040005DB RID: 1499
		private IExtension extensionObject;
	}
}
