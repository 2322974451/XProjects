using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068F RID: 1679
	[ProtoContract(Name = "SSceneState")]
	[Serializable]
	public class SSceneState : IExtensible
	{
		// Token: 0x1700226E RID: 8814
		// (get) Token: 0x06006CC7 RID: 27847 RVA: 0x000D0238 File Offset: 0x000CE438
		// (set) Token: 0x06006CC8 RID: 27848 RVA: 0x000D0264 File Offset: 0x000CE464
		[ProtoMember(1, IsRequired = false, Name = "isready", DataFormat = DataFormat.Default)]
		public bool isready
		{
			get
			{
				return this._isready ?? false;
			}
			set
			{
				this._isready = new bool?(value);
			}
		}

		// Token: 0x1700226F RID: 8815
		// (get) Token: 0x06006CC9 RID: 27849 RVA: 0x000D0274 File Offset: 0x000CE474
		// (set) Token: 0x06006CCA RID: 27850 RVA: 0x000D0294 File Offset: 0x000CE494
		[XmlIgnore]
		[Browsable(false)]
		public bool isreadySpecified
		{
			get
			{
				return this._isready != null;
			}
			set
			{
				bool flag = value == (this._isready == null);
				if (flag)
				{
					this._isready = (value ? new bool?(this.isready) : null);
				}
			}
		}

		// Token: 0x06006CCB RID: 27851 RVA: 0x000D02D8 File Offset: 0x000CE4D8
		private bool ShouldSerializeisready()
		{
			return this.isreadySpecified;
		}

		// Token: 0x06006CCC RID: 27852 RVA: 0x000D02F0 File Offset: 0x000CE4F0
		private void Resetisready()
		{
			this.isreadySpecified = false;
		}

		// Token: 0x17002270 RID: 8816
		// (get) Token: 0x06006CCD RID: 27853 RVA: 0x000D02FC File Offset: 0x000CE4FC
		// (set) Token: 0x06006CCE RID: 27854 RVA: 0x000D0328 File Offset: 0x000CE528
		[ProtoMember(2, IsRequired = false, Name = "runstate", DataFormat = DataFormat.TwosComplement)]
		public uint runstate
		{
			get
			{
				return this._runstate ?? 0U;
			}
			set
			{
				this._runstate = new uint?(value);
			}
		}

		// Token: 0x17002271 RID: 8817
		// (get) Token: 0x06006CCF RID: 27855 RVA: 0x000D0338 File Offset: 0x000CE538
		// (set) Token: 0x06006CD0 RID: 27856 RVA: 0x000D0358 File Offset: 0x000CE558
		[XmlIgnore]
		[Browsable(false)]
		public bool runstateSpecified
		{
			get
			{
				return this._runstate != null;
			}
			set
			{
				bool flag = value == (this._runstate == null);
				if (flag)
				{
					this._runstate = (value ? new uint?(this.runstate) : null);
				}
			}
		}

		// Token: 0x06006CD1 RID: 27857 RVA: 0x000D039C File Offset: 0x000CE59C
		private bool ShouldSerializerunstate()
		{
			return this.runstateSpecified;
		}

		// Token: 0x06006CD2 RID: 27858 RVA: 0x000D03B4 File Offset: 0x000CE5B4
		private void Resetrunstate()
		{
			this.runstateSpecified = false;
		}

		// Token: 0x06006CD3 RID: 27859 RVA: 0x000D03C0 File Offset: 0x000CE5C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A17 RID: 6679
		private bool? _isready;

		// Token: 0x04001A18 RID: 6680
		private uint? _runstate;

		// Token: 0x04001A19 RID: 6681
		private IExtension extensionObject;
	}
}
