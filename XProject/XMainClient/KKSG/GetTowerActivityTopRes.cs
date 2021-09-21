using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000109 RID: 265
	[ProtoContract(Name = "GetTowerActivityTopRes")]
	[Serializable]
	public class GetTowerActivityTopRes : IExtensible
	{
		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x00022640 File Offset: 0x00020840
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x0002266C File Offset: 0x0002086C
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x0002267C File Offset: 0x0002087C
		// (set) Token: 0x060010CF RID: 4303 RVA: 0x0002269C File Offset: 0x0002089C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x000226E0 File Offset: 0x000208E0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x000226F8 File Offset: 0x000208F8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x00022704 File Offset: 0x00020904
		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<TowerRecord> infos
		{
			get
			{
				return this._infos;
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x060010D3 RID: 4307 RVA: 0x0002271C File Offset: 0x0002091C
		// (set) Token: 0x060010D4 RID: 4308 RVA: 0x00022748 File Offset: 0x00020948
		[ProtoMember(3, IsRequired = false, Name = "leftResetCount", DataFormat = DataFormat.TwosComplement)]
		public int leftResetCount
		{
			get
			{
				return this._leftResetCount ?? 0;
			}
			set
			{
				this._leftResetCount = new int?(value);
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00022758 File Offset: 0x00020958
		// (set) Token: 0x060010D6 RID: 4310 RVA: 0x00022778 File Offset: 0x00020978
		[XmlIgnore]
		[Browsable(false)]
		public bool leftResetCountSpecified
		{
			get
			{
				return this._leftResetCount != null;
			}
			set
			{
				bool flag = value == (this._leftResetCount == null);
				if (flag)
				{
					this._leftResetCount = (value ? new int?(this.leftResetCount) : null);
				}
			}
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x000227BC File Offset: 0x000209BC
		private bool ShouldSerializeleftResetCount()
		{
			return this.leftResetCountSpecified;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x000227D4 File Offset: 0x000209D4
		private void ResetleftResetCount()
		{
			this.leftResetCountSpecified = false;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x000227E0 File Offset: 0x000209E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000434 RID: 1076
		private ErrorCode? _error;

		// Token: 0x04000435 RID: 1077
		private readonly List<TowerRecord> _infos = new List<TowerRecord>();

		// Token: 0x04000436 RID: 1078
		private int? _leftResetCount;

		// Token: 0x04000437 RID: 1079
		private IExtension extensionObject;
	}
}
