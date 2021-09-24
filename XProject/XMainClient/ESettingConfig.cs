using System;

namespace XMainClient
{

	public enum ESettingConfig
	{

		ESceneUnloadResource = 1,

		EMultiThreadProtoBuf,

		ESkipProtoIgnore = 4,

		EHalfTexResolution = 8,

		ELowEffect = 16,

		EUIGLOBALMERGE = 32,

		EUISELECTMERGE = 64,

		EUILOWDEVICEMERGE = 128,

		EApm = 256,

		EClearBundle = 512,

		ELoadCurveTable = 1024,

		EDelayLoad = 2048,

		EFilterFarFx = 4096
	}
}
