namespace ODMO.Commons.Enums.ClientEnums
{
	public enum ConditionEnum
	{
		Default = 0,
		Ride = 1,
		Away = 2,

		/// <summary>
		/// Sets the tamer as a tamer shop.
		/// </summary>
		TamerShop = 4,

		/// <summary>
		/// Used on the preparing shop stage (tamer/consigned).
		/// </summary>
		PreparingShop = 8,

		PCBang = 0x00000010,    // ?? ?? pc? ???
		Peace = 0x00000020, // ??????
		s7 = 0x00000040,    // 
		s8 = 0x00000080,    // 

		s9 = 0x00000100,    // 
		Scanner0 = 0x00000200,  // 1:??? ??, 0:??? ???
		Scanner1 = 0x00000400,  // 1:??? ??? ??? ???, 0:??? ??? ???? ??? ???
		Scanner2 = 0x00000800,  // 1:??? ???, 0:??? ???

		s13 = 0x00001000,   // 
		s14 = 0x00002000,   // 
		s15 = 0x00004000,   // 
		s16 = 0x00008000,

		s17 = 0x00010000,   // 
		S18 = 0x00020000,   // 
		Guild = 0x00040000, // Join a guild
		S20 = 0x00080000,   // ???-?? ??

		S21 = 0x00100000,   // ?? ??
		Invisible = 0x00200000, // ????
		
		/// <summary>
		/// Fatigue level are bigger than the current health.
		/// </summary>
		Fatigued = 0x00400000,

		Immortal = 0x00800000,    // ??

		Run = 0x10000000,   // ??
		Rest = 0x20000000,  // ???
		Die = 0x40000000,   // ??
		//Battle = 0x80000000,    // ???

		Return = 0x02000000,    // ???? ????? ??, ???? ? ??? ??
	};
}