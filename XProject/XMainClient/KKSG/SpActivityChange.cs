using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026B RID: 619
	[ProtoContract(Name = "SpActivityChange")]
	[Serializable]
	public class SpActivityChange : IExtensible
	{
		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x0600227A RID: 8826 RVA: 0x000435AC File Offset: 0x000417AC
		// (set) Token: 0x0600227B RID: 8827 RVA: 0x000435D8 File Offset: 0x000417D8
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

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x0600227C RID: 8828 RVA: 0x000435E8 File Offset: 0x000417E8
		// (set) Token: 0x0600227D RID: 8829 RVA: 0x00043608 File Offset: 0x00041808
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

		// Token: 0x0600227E RID: 8830 RVA: 0x0004364C File Offset: 0x0004184C
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x00043664 File Offset: 0x00041864
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x06002280 RID: 8832 RVA: 0x00043670 File Offset: 0x00041870
		// (set) Token: 0x06002281 RID: 8833 RVA: 0x0004369C File Offset: 0x0004189C
		[ProtoMember(2, IsRequired = false, Name = "taskid", DataFormat = DataFormat.TwosComplement)]
		public uint taskid
		{
			get
			{
				return this._taskid ?? 0U;
			}
			set
			{
				this._taskid = new uint?(value);
			}
		}

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06002282 RID: 8834 RVA: 0x000436AC File Offset: 0x000418AC
		// (set) Token: 0x06002283 RID: 8835 RVA: 0x000436CC File Offset: 0x000418CC
		[XmlIgnore]
		[Browsable(false)]
		public bool taskidSpecified
		{
			get
			{
				return this._taskid != null;
			}
			set
			{
				bool flag = value == (this._taskid == null);
				if (flag)
				{
					this._taskid = (value ? new uint?(this.taskid) : null);
				}
			}
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x00043710 File Offset: 0x00041910
		private bool ShouldSerializetaskid()
		{
			return this.taskidSpecified;
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x00043728 File Offset: 0x00041928
		private void Resettaskid()
		{
			this.taskidSpecified = false;
		}

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06002286 RID: 8838 RVA: 0x00043734 File Offset: 0x00041934
		// (set) Token: 0x06002287 RID: 8839 RVA: 0x00043760 File Offset: 0x00041960
		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06002288 RID: 8840 RVA: 0x00043770 File Offset: 0x00041970
		// (set) Token: 0x06002289 RID: 8841 RVA: 0x00043790 File Offset: 0x00041990
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x000437D4 File Offset: 0x000419D4
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x000437EC File Offset: 0x000419EC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x0600228C RID: 8844 RVA: 0x000437F8 File Offset: 0x000419F8
		// (set) Token: 0x0600228D RID: 8845 RVA: 0x00043824 File Offset: 0x00041A24
		[ProtoMember(4, IsRequired = false, Name = "progress", DataFormat = DataFormat.TwosComplement)]
		public uint progress
		{
			get
			{
				return this._progress ?? 0U;
			}
			set
			{
				this._progress = new uint?(value);
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x0600228E RID: 8846 RVA: 0x00043834 File Offset: 0x00041A34
		// (set) Token: 0x0600228F RID: 8847 RVA: 0x00043854 File Offset: 0x00041A54
		[XmlIgnore]
		[Browsable(false)]
		public bool progressSpecified
		{
			get
			{
				return this._progress != null;
			}
			set
			{
				bool flag = value == (this._progress == null);
				if (flag)
				{
					this._progress = (value ? new uint?(this.progress) : null);
				}
			}
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x00043898 File Offset: 0x00041A98
		private bool ShouldSerializeprogress()
		{
			return this.progressSpecified;
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x000438B0 File Offset: 0x00041AB0
		private void Resetprogress()
		{
			this.progressSpecified = false;
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x000438BC File Offset: 0x00041ABC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400088E RID: 2190
		private uint? _actid;

		// Token: 0x0400088F RID: 2191
		private uint? _taskid;

		// Token: 0x04000890 RID: 2192
		private uint? _state;

		// Token: 0x04000891 RID: 2193
		private uint? _progress;

		// Token: 0x04000892 RID: 2194
		private IExtension extensionObject;
	}
}
