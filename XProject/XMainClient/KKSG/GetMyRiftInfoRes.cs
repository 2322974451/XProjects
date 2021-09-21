using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000526 RID: 1318
	[ProtoContract(Name = "GetMyRiftInfoRes")]
	[Serializable]
	public class GetMyRiftInfoRes : IExtensible
	{
		// Token: 0x170014B0 RID: 5296
		// (get) Token: 0x060043B4 RID: 17332 RVA: 0x00080CBC File Offset: 0x0007EEBC
		// (set) Token: 0x060043B5 RID: 17333 RVA: 0x00080CE8 File Offset: 0x0007EEE8
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

		// Token: 0x170014B1 RID: 5297
		// (get) Token: 0x060043B6 RID: 17334 RVA: 0x00080CF8 File Offset: 0x0007EEF8
		// (set) Token: 0x060043B7 RID: 17335 RVA: 0x00080D18 File Offset: 0x0007EF18
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

		// Token: 0x060043B8 RID: 17336 RVA: 0x00080D5C File Offset: 0x0007EF5C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x00080D74 File Offset: 0x0007EF74
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170014B2 RID: 5298
		// (get) Token: 0x060043BA RID: 17338 RVA: 0x00080D80 File Offset: 0x0007EF80
		// (set) Token: 0x060043BB RID: 17339 RVA: 0x00080DAC File Offset: 0x0007EFAC
		[ProtoMember(2, IsRequired = false, Name = "curRiftID", DataFormat = DataFormat.TwosComplement)]
		public int curRiftID
		{
			get
			{
				return this._curRiftID ?? 0;
			}
			set
			{
				this._curRiftID = new int?(value);
			}
		}

		// Token: 0x170014B3 RID: 5299
		// (get) Token: 0x060043BC RID: 17340 RVA: 0x00080DBC File Offset: 0x0007EFBC
		// (set) Token: 0x060043BD RID: 17341 RVA: 0x00080DDC File Offset: 0x0007EFDC
		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftIDSpecified
		{
			get
			{
				return this._curRiftID != null;
			}
			set
			{
				bool flag = value == (this._curRiftID == null);
				if (flag)
				{
					this._curRiftID = (value ? new int?(this.curRiftID) : null);
				}
			}
		}

		// Token: 0x060043BE RID: 17342 RVA: 0x00080E20 File Offset: 0x0007F020
		private bool ShouldSerializecurRiftID()
		{
			return this.curRiftIDSpecified;
		}

		// Token: 0x060043BF RID: 17343 RVA: 0x00080E38 File Offset: 0x0007F038
		private void ResetcurRiftID()
		{
			this.curRiftIDSpecified = false;
		}

		// Token: 0x170014B4 RID: 5300
		// (get) Token: 0x060043C0 RID: 17344 RVA: 0x00080E44 File Offset: 0x0007F044
		// (set) Token: 0x060043C1 RID: 17345 RVA: 0x00080E70 File Offset: 0x0007F070
		[ProtoMember(3, IsRequired = false, Name = "curRiftFloor", DataFormat = DataFormat.TwosComplement)]
		public int curRiftFloor
		{
			get
			{
				return this._curRiftFloor ?? 0;
			}
			set
			{
				this._curRiftFloor = new int?(value);
			}
		}

		// Token: 0x170014B5 RID: 5301
		// (get) Token: 0x060043C2 RID: 17346 RVA: 0x00080E80 File Offset: 0x0007F080
		// (set) Token: 0x060043C3 RID: 17347 RVA: 0x00080EA0 File Offset: 0x0007F0A0
		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftFloorSpecified
		{
			get
			{
				return this._curRiftFloor != null;
			}
			set
			{
				bool flag = value == (this._curRiftFloor == null);
				if (flag)
				{
					this._curRiftFloor = (value ? new int?(this.curRiftFloor) : null);
				}
			}
		}

		// Token: 0x060043C4 RID: 17348 RVA: 0x00080EE4 File Offset: 0x0007F0E4
		private bool ShouldSerializecurRiftFloor()
		{
			return this.curRiftFloorSpecified;
		}

		// Token: 0x060043C5 RID: 17349 RVA: 0x00080EFC File Offset: 0x0007F0FC
		private void ResetcurRiftFloor()
		{
			this.curRiftFloorSpecified = false;
		}

		// Token: 0x170014B6 RID: 5302
		// (get) Token: 0x060043C6 RID: 17350 RVA: 0x00080F08 File Offset: 0x0007F108
		// (set) Token: 0x060043C7 RID: 17351 RVA: 0x00080F34 File Offset: 0x0007F134
		[ProtoMember(4, IsRequired = false, Name = "curSceneID", DataFormat = DataFormat.TwosComplement)]
		public int curSceneID
		{
			get
			{
				return this._curSceneID ?? 0;
			}
			set
			{
				this._curSceneID = new int?(value);
			}
		}

		// Token: 0x170014B7 RID: 5303
		// (get) Token: 0x060043C8 RID: 17352 RVA: 0x00080F44 File Offset: 0x0007F144
		// (set) Token: 0x060043C9 RID: 17353 RVA: 0x00080F64 File Offset: 0x0007F164
		[XmlIgnore]
		[Browsable(false)]
		public bool curSceneIDSpecified
		{
			get
			{
				return this._curSceneID != null;
			}
			set
			{
				bool flag = value == (this._curSceneID == null);
				if (flag)
				{
					this._curSceneID = (value ? new int?(this.curSceneID) : null);
				}
			}
		}

		// Token: 0x060043CA RID: 17354 RVA: 0x00080FA8 File Offset: 0x0007F1A8
		private bool ShouldSerializecurSceneID()
		{
			return this.curSceneIDSpecified;
		}

		// Token: 0x060043CB RID: 17355 RVA: 0x00080FC0 File Offset: 0x0007F1C0
		private void ResetcurSceneID()
		{
			this.curSceneIDSpecified = false;
		}

		// Token: 0x170014B8 RID: 5304
		// (get) Token: 0x060043CC RID: 17356 RVA: 0x00080FCC File Offset: 0x0007F1CC
		[ProtoMember(5, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		// Token: 0x170014B9 RID: 5305
		// (get) Token: 0x060043CD RID: 17357 RVA: 0x00080FE4 File Offset: 0x0007F1E4
		[ProtoMember(6, Name = "gotItemsCount", DataFormat = DataFormat.Default)]
		public List<MapIntItem> gotItemsCount
		{
			get
			{
				return this._gotItemsCount;
			}
		}

		// Token: 0x170014BA RID: 5306
		// (get) Token: 0x060043CE RID: 17358 RVA: 0x00080FFC File Offset: 0x0007F1FC
		// (set) Token: 0x060043CF RID: 17359 RVA: 0x00081028 File Offset: 0x0007F228
		[ProtoMember(7, IsRequired = false, Name = "isInActiviyTime", DataFormat = DataFormat.Default)]
		public bool isInActiviyTime
		{
			get
			{
				return this._isInActiviyTime ?? false;
			}
			set
			{
				this._isInActiviyTime = new bool?(value);
			}
		}

		// Token: 0x170014BB RID: 5307
		// (get) Token: 0x060043D0 RID: 17360 RVA: 0x00081038 File Offset: 0x0007F238
		// (set) Token: 0x060043D1 RID: 17361 RVA: 0x00081058 File Offset: 0x0007F258
		[XmlIgnore]
		[Browsable(false)]
		public bool isInActiviyTimeSpecified
		{
			get
			{
				return this._isInActiviyTime != null;
			}
			set
			{
				bool flag = value == (this._isInActiviyTime == null);
				if (flag)
				{
					this._isInActiviyTime = (value ? new bool?(this.isInActiviyTime) : null);
				}
			}
		}

		// Token: 0x060043D2 RID: 17362 RVA: 0x0008109C File Offset: 0x0007F29C
		private bool ShouldSerializeisInActiviyTime()
		{
			return this.isInActiviyTimeSpecified;
		}

		// Token: 0x060043D3 RID: 17363 RVA: 0x000810B4 File Offset: 0x0007F2B4
		private void ResetisInActiviyTime()
		{
			this.isInActiviyTimeSpecified = false;
		}

		// Token: 0x060043D4 RID: 17364 RVA: 0x000810C0 File Offset: 0x0007F2C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010E1 RID: 4321
		private ErrorCode? _error;

		// Token: 0x040010E2 RID: 4322
		private int? _curRiftID;

		// Token: 0x040010E3 RID: 4323
		private int? _curRiftFloor;

		// Token: 0x040010E4 RID: 4324
		private int? _curSceneID;

		// Token: 0x040010E5 RID: 4325
		private readonly List<Buff> _buffIDs = new List<Buff>();

		// Token: 0x040010E6 RID: 4326
		private readonly List<MapIntItem> _gotItemsCount = new List<MapIntItem>();

		// Token: 0x040010E7 RID: 4327
		private bool? _isInActiviyTime;

		// Token: 0x040010E8 RID: 4328
		private IExtension extensionObject;
	}
}
