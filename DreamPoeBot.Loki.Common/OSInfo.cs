using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DreamPoeBot.Loki.Common;

public static class OSInfo
{
	private struct Struct332
	{
		public int int_0;

		public readonly int int_1;

		public readonly int int_2;

		public readonly int int_3;

		public readonly int int_4;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public readonly string string_0;

		public readonly short short_0;

		public readonly short short_1;

		public readonly short short_2;

		public readonly byte byte_0;

		public readonly byte byte_1;
	}

	private static string string_0;

	private static string string_1;

	private const int int_0 = 0;

	private const int int_1 = 1;

	private const int int_2 = 2;

	private const int int_3 = 3;

	private const int int_4 = 4;

	private const int int_5 = 5;

	private const int int_6 = 6;

	private const int int_7 = 7;

	private const int int_8 = 8;

	private const int int_9 = 9;

	private const int int_10 = 10;

	private const int int_11 = 11;

	private const int int_12 = 12;

	private const int int_13 = 13;

	private const int int_14 = 14;

	private const int int_15 = 15;

	private const int int_16 = 16;

	private const int int_17 = 17;

	private const int int_18 = 18;

	private const int int_19 = 19;

	private const int int_20 = 20;

	private const int int_21 = 21;

	private const int int_22 = 22;

	private const int int_23 = 23;

	private const int int_24 = 24;

	private const int int_25 = 25;

	private const int int_26 = 26;

	private const int int_27 = 27;

	private const int int_28 = 28;

	private const int int_29 = 29;

	private const int int_30 = 30;

	private const int int_31 = 31;

	private const int int_32 = 32;

	private const int int_33 = 35;

	private const int int_34 = 36;

	private const int int_35 = 38;

	private const int int_36 = 40;

	private const int int_37 = 41;

	private const int int_38 = 42;

	private const int int_39 = 101;

	private const int int_40 = 98;

	private const int int_41 = 99;

	private const int int_42 = 100;

	private const int int_43 = 48;

	private const int int_44 = 1;

	private const int int_45 = 2;

	private const int int_46 = 3;

	private const int int_47 = 1;

	private const int int_48 = 2;

	private const int int_49 = 16;

	private const int int_50 = 128;

	private const int int_51 = 256;

	private const int int_52 = 512;

	private const int int_53 = 1024;

	public static int Bits
	{
		get
		{
			if (Environment.Is64BitOperatingSystem)
			{
				return 64;
			}
			return 32;
		}
	}

	public static string Edition
	{
		get
		{
			if (string_0 == null)
			{
				uint num = default(uint);
				while (true)
				{
					string result = string.Empty;
					OperatingSystem oSVersion = Environment.OSVersion;
					while (true)
					{
						IL_0318:
						Struct332 struct332_ = default(Struct332);
						struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
						if (GetVersionEx(ref struct332_))
						{
							while (true)
							{
								IL_030a:
								int major = oSVersion.Version.Major;
								while (true)
								{
									IL_02f3:
									int minor = oSVersion.Version.Minor;
									byte byte_ = struct332_.byte_0;
									while (true)
									{
										IL_02e5:
										short short_ = struct332_.short_2;
										if (major != 4)
										{
											while (true)
											{
												IL_02dc:
												if (major != 5)
												{
													while (major == 6)
													{
														int int_;
														while (GetProductInfo(major, minor, struct332_.short_0, struct332_.short_1, out int_))
														{
															while (true)
															{
																switch (int_)
																{
																case 0:
																	goto IL_0390;
																case 1:
																	goto IL_039b;
																case 2:
																	goto IL_03a6;
																case 3:
																	goto IL_03b1;
																case 4:
																	goto IL_03bc;
																case 5:
																	goto IL_03c7;
																case 6:
																	goto IL_03d2;
																case 7:
																	goto IL_03dd;
																case 8:
																	goto IL_03e8;
																case 9:
																	goto IL_03f3;
																case 10:
																	goto IL_03fe;
																case 11:
																	goto IL_0409;
																case 12:
																	goto IL_0414;
																case 13:
																	goto IL_041f;
																case 14:
																	goto IL_042a;
																case 15:
																	goto IL_0435;
																case 16:
																	goto IL_0440;
																case 17:
																	goto IL_044b;
																case 18:
																	goto IL_0456;
																case 20:
																	goto IL_0461;
																case 21:
																	goto IL_046c;
																case 22:
																	goto IL_0477;
																case 23:
																	goto IL_0482;
																case 24:
																	goto IL_048d;
																case 26:
																	goto IL_0498;
																case 27:
																	goto IL_04a3;
																case 28:
																	goto IL_04ae;
																case 29:
																	goto IL_04b9;
																case 30:
																	goto IL_04c4;
																case 31:
																	goto IL_04cf;
																case 32:
																	goto IL_04da;
																case 35:
																	goto IL_04e5;
																case 36:
																	goto IL_04f0;
																case 38:
																	goto IL_04fb;
																case 40:
																	goto IL_0506;
																case 41:
																	goto IL_0511;
																case 42:
																	goto IL_051c;
																case 48:
																	goto IL_0527;
																case 19:
																case 25:
																case 33:
																case 34:
																case 37:
																case 39:
																case 43:
																case 44:
																case 45:
																case 46:
																case 47:
																	goto end_IL_01e3;
																}
																int num2 = ((int)num * -645764454) ^ 0x59842C2D;
																while (true)
																{
																	switch ((num = (uint)num2 ^ 0x193CAFD5u) % 104u)
																	{
																	case 94u:
																		num2 = ((int)num * -1407788862) ^ 0x7BE85702;
																		continue;
																	case 7u:
																		break;
																	case 42u:
																		goto IL_02b3;
																	case 74u:
																		goto IL_02d3;
																	case 58u:
																		goto IL_02dc;
																	case 39u:
																		goto IL_02e5;
																	case 3u:
																		goto IL_02f3;
																	case 100u:
																		goto IL_030a;
																	case 99u:
																		goto IL_0318;
																	case 36u:
																		goto end_IL_0318;
																	case 51u:
																		goto IL_0352;
																	case 9u:
																		goto IL_0359;
																	case 52u:
																	case 62u:
																		goto end_IL_0344;
																	case 91u:
																		goto IL_036a;
																	case 73u:
																		goto IL_0374;
																	case 6u:
																		goto IL_037a;
																	case 82u:
																		goto IL_0385;
																	case 48u:
																		goto IL_0390;
																	case 1u:
																		goto IL_039b;
																	case 41u:
																		goto IL_03a6;
																	case 2u:
																		goto IL_03b1;
																	case 54u:
																		goto IL_03bc;
																	case 87u:
																		goto IL_03c7;
																	case 85u:
																		goto IL_03d2;
																	case 40u:
																		goto IL_03dd;
																	case 10u:
																		goto IL_03e8;
																	case 68u:
																		goto IL_03f3;
																	case 45u:
																		goto IL_03fe;
																	case 16u:
																		goto IL_0409;
																	case 102u:
																		goto IL_0414;
																	case 77u:
																		goto IL_041f;
																	case 55u:
																		goto IL_042a;
																	case 81u:
																		goto IL_0435;
																	case 64u:
																		goto IL_0440;
																	case 89u:
																		goto IL_044b;
																	case 79u:
																		goto IL_0456;
																	case 32u:
																		goto IL_0461;
																	case 4u:
																		goto IL_046c;
																	case 29u:
																		goto IL_0477;
																	case 46u:
																		goto IL_0482;
																	case 12u:
																		goto IL_048d;
																	case 78u:
																		goto IL_0498;
																	case 14u:
																		goto IL_04a3;
																	case 63u:
																		goto IL_04ae;
																	case 97u:
																		goto IL_04b9;
																	case 72u:
																		goto IL_04c4;
																	case 60u:
																		goto IL_04cf;
																	case 31u:
																		goto IL_04da;
																	case 13u:
																		goto IL_04e5;
																	case 56u:
																		goto IL_04f0;
																	case 53u:
																		goto IL_04fb;
																	case 69u:
																		goto IL_0506;
																	case 21u:
																		goto IL_0511;
																	case 61u:
																		goto IL_051c;
																	case 43u:
																		goto IL_0527;
																	case 37u:
																		goto IL_0532;
																	case 71u:
																		goto IL_0537;
																	case 24u:
																		goto IL_0541;
																	case 98u:
																		goto IL_0549;
																	case 5u:
																		goto IL_0551;
																	case 59u:
																		goto IL_0558;
																	case 15u:
																		goto IL_055c;
																	case 34u:
																		goto IL_0566;
																	case 75u:
																		goto IL_056c;
																	case 28u:
																		goto IL_0574;
																	case 11u:
																		goto IL_057c;
																	case 93u:
																		goto IL_0584;
																	case 50u:
																		goto IL_058e;
																	case 66u:
																		goto IL_0594;
																	case 57u:
																		goto IL_059c;
																	case 23u:
																		goto IL_05a6;
																	case 76u:
																		goto IL_05ae;
																	case 18u:
																		goto IL_05b6;
																	case 0u:
																	case 8u:
																	case 17u:
																	case 19u:
																	case 20u:
																	case 22u:
																	case 25u:
																	case 26u:
																	case 27u:
																	case 30u:
																	case 33u:
																	case 35u:
																	case 38u:
																	case 44u:
																	case 47u:
																	case 49u:
																	case 65u:
																	case 67u:
																	case 70u:
																	case 80u:
																	case 83u:
																	case 84u:
																	case 86u:
																	case 88u:
																	case 90u:
																	case 92u:
																	case 95u:
																	case 101u:
																	case 103u:
																		goto end_IL_01e3;
																	default:
																		goto IL_05c2;
																	}
																	break;
																}
																continue;
																IL_039b:
																result = "Ultimate";
																break;
																IL_0390:
																result = "Unknown product";
																break;
																IL_0527:
																result = "Professional";
																break;
																IL_051c:
																result = "Microsoft Hyper-V Server";
																break;
																IL_0511:
																result = "Enterprise Server without Hyper-V (core installation)";
																break;
																IL_0506:
																result = "Standard Server without Hyper-V (core installation)";
																break;
																IL_04fb:
																result = "Enterprise Server without Hyper-V";
																break;
																IL_04f0:
																result = "Standard Server without Hyper-V";
																break;
																IL_04e5:
																result = "Windows Essential Server Solutions without Hyper-V";
																break;
																IL_04da:
																result = "Windows Essential Business Messaging Server";
																break;
																IL_04cf:
																result = "Windows Essential Business Security Server";
																break;
																IL_04c4:
																result = "Windows Essential Business Management Server";
																break;
																IL_04b9:
																result = "Web Server (core installation)";
																break;
																IL_04ae:
																result = "Ultimate N";
																break;
																IL_04a3:
																result = "Enterprise N";
																break;
																IL_0498:
																result = "Home Premium N";
																break;
																IL_048d:
																result = "Windows Essential Server Solutions";
																break;
																IL_0482:
																result = "Enterprise Storage Server";
																break;
																IL_0477:
																result = "Workgroup Storage Server";
																break;
																IL_046c:
																result = "Standard Storage Server";
																break;
																IL_0461:
																result = "Express Storage Server";
																break;
																IL_0456:
																result = "HPC Edition";
																break;
																IL_044b:
																result = "Web Server";
																break;
																IL_0440:
																result = "Business N";
																break;
																IL_0435:
																result = "Enterprise Server for Itanium-based Systems";
																break;
																IL_042a:
																result = "Enterprise Server (core installation)";
																break;
																IL_041f:
																result = "Standard Server (core installation)";
																break;
																IL_0414:
																result = "Datacenter Server (core installation)";
																break;
																IL_0409:
																result = "Starter";
																break;
																IL_03fe:
																result = "Enterprise Server";
																break;
																IL_03f3:
																result = "Windows Small Business Server";
																break;
																IL_03e8:
																result = "Datacenter Server";
																break;
																IL_03dd:
																result = "Standard Server";
																break;
																IL_03d2:
																result = "Business";
																break;
																IL_03c7:
																result = "Home Basic N";
																break;
																IL_03bc:
																result = "Enterprise";
																break;
																IL_03b1:
																result = "Home Premium";
																break;
																IL_03a6:
																result = "Home Basic";
																break;
																continue;
																end_IL_01e3:
																break;
															}
															break;
															IL_02b3:;
														}
														break;
														IL_02d3:;
													}
													break;
												}
												goto IL_0532;
												IL_05b6:
												result = "Datacenter";
												break;
												IL_0532:
												if (byte_ == 1)
												{
													goto IL_0537;
												}
												goto IL_0551;
												IL_0537:
												if ((short_ & 0x200) == 0)
												{
													goto IL_0541;
												}
												goto IL_0549;
												IL_0541:
												result = "Professional";
												break;
												IL_0549:
												result = "Home";
												break;
												IL_0551:
												if (byte_ != 3)
												{
													break;
												}
												goto IL_0558;
												IL_0558:
												if (minor == 0)
												{
													goto IL_055c;
												}
												goto IL_0584;
												IL_055c:
												if ((short_ & 0x80) == 0)
												{
													goto IL_0566;
												}
												goto IL_057c;
												IL_0566:
												if (((uint)short_ & 2u) != 0)
												{
													goto IL_056c;
												}
												goto IL_0574;
												IL_056c:
												result = "Advanced Server";
												break;
												IL_0574:
												result = "Server";
												break;
												IL_057c:
												result = "Datacenter Server";
												break;
												IL_0584:
												if ((short_ & 0x80) == 0)
												{
													goto IL_058e;
												}
												goto IL_05b6;
												IL_058e:
												if (((uint)short_ & 2u) != 0)
												{
													goto IL_0594;
												}
												goto IL_059c;
												IL_0594:
												result = "Enterprise";
												break;
												IL_059c:
												if ((short_ & 0x400) == 0)
												{
													goto IL_05a6;
												}
												goto IL_05ae;
												IL_05a6:
												result = "Standard";
												break;
												IL_05ae:
												result = "Web Edition";
												break;
											}
											break;
										}
										goto IL_0352;
										IL_0359:
										result = "Workstation";
										break;
										IL_0352:
										if (byte_ == 1)
										{
											goto IL_0359;
										}
										goto IL_036a;
										IL_036a:
										if (byte_ != 3)
										{
											break;
										}
										goto IL_0374;
										IL_0374:
										if ((short_ & 2) == 0)
										{
											goto IL_037a;
										}
										goto IL_0385;
										IL_037a:
										result = "Standard Server";
										break;
										IL_0385:
										result = "Enterprise Server";
										break;
									}
									break;
								}
								break;
							}
						}
						string_0 = result;
						goto IL_05c2;
						IL_05c2:
						return result;
						continue;
						end_IL_0318:
						break;
					}
					continue;
					end_IL_0344:
					break;
				}
			}
			return string_0;
		}
	}

	public static string Name
	{
		get
		{
			if (string_1 == null)
			{
				uint num = default(uint);
				string text = default(string);
				while (true)
				{
					string result = "unknown";
					OperatingSystem oSVersion = Environment.OSVersion;
					Struct332 struct332_ = default(Struct332);
					struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
					while (true)
					{
						IL_0195:
						if (GetVersionEx(ref struct332_))
						{
							while (true)
							{
								IL_0187:
								int major = oSVersion.Version.Major;
								while (true)
								{
									IL_0178:
									int minor = oSVersion.Version.Minor;
									while (true)
									{
										IL_016e:
										PlatformID platform = oSVersion.Platform;
										while (true)
										{
											IL_0164:
											if (platform != PlatformID.Win32Windows)
											{
												while (platform == PlatformID.Win32NT)
												{
													while (true)
													{
														byte byte_ = struct332_.byte_0;
														while (true)
														{
															switch (major)
															{
															case 3:
																goto IL_01d5;
															case 4:
																goto IL_01e0;
															case 5:
																goto IL_0205;
															case 6:
																goto IL_024e;
															}
															int num2 = (int)((num * 1233537534) ^ 0x15143A89);
															while (true)
															{
																switch ((num = (uint)num2 ^ 0x358B869Du) % 60u)
																{
																case 28u:
																	num2 = (int)((num * 527480185) ^ 0x569892F8);
																	continue;
																case 30u:
																	break;
																case 57u:
																	goto end_IL_0133;
																case 53u:
																	goto end_IL_0150;
																case 43u:
																	goto IL_0164;
																case 47u:
																	goto IL_016e;
																case 59u:
																	goto IL_0178;
																case 42u:
																	goto IL_0187;
																case 37u:
																	goto IL_0195;
																case 15u:
																	goto end_IL_0195;
																case 2u:
																case 55u:
																	goto end_IL_01a3;
																case 10u:
																	goto IL_01d5;
																case 56u:
																	goto IL_01e0;
																case 44u:
																	goto IL_01e5;
																case 33u:
																	goto IL_01f0;
																case 4u:
																	goto IL_01fa;
																case 0u:
																	goto IL_0205;
																case 32u:
																	goto IL_021d;
																case 7u:
																	goto IL_0228;
																case 3u:
																	goto IL_0233;
																case 21u:
																	goto IL_0238;
																case 36u:
																	goto IL_0243;
																case 39u:
																	goto IL_024e;
																case 12u:
																	goto IL_0266;
																case 52u:
																	goto IL_026b;
																case 48u:
																	goto IL_0273;
																case 25u:
																	goto IL_027e;
																case 51u:
																	goto IL_0289;
																case 18u:
																	goto IL_028e;
																case 54u:
																	goto IL_0299;
																case 23u:
																	goto IL_02a3;
																case 20u:
																	goto IL_02ae;
																case 58u:
																	goto IL_02b3;
																case 22u:
																	goto IL_02bb;
																case 14u:
																	goto IL_02c0;
																case 5u:
																	goto IL_02c8;
																case 1u:
																	goto IL_02ce;
																case 24u:
																	goto IL_02d6;
																case 13u:
																	goto IL_02da;
																case 40u:
																	goto IL_02e0;
																case 45u:
																	goto IL_02e6;
																case 31u:
																	goto IL_02ee;
																case 16u:
																	goto IL_02fc;
																case 26u:
																	goto IL_0304;
																case 46u:
																	goto IL_030c;
																case 35u:
																	goto IL_031a;
																case 49u:
																	goto IL_0328;
																case 8u:
																	goto IL_0330;
																case 6u:
																case 9u:
																case 11u:
																case 17u:
																case 19u:
																case 29u:
																case 34u:
																case 38u:
																case 41u:
																case 50u:
																	goto end_IL_015a;
																default:
																	goto IL_033c;
																}
																break;
															}
															continue;
															IL_01fa:
															result = "Windows NT 4.0 Server";
															goto end_IL_015a;
															IL_01d5:
															result = "Windows NT 3.51";
															goto end_IL_015a;
															IL_024e:
															switch (minor)
															{
															case 0:
																break;
															case 1:
																goto IL_0289;
															case 2:
																goto IL_02ae;
															default:
																goto end_IL_015a;
															}
															goto IL_0266;
															IL_02ae:
															if (byte_ == 1)
															{
																goto IL_02b3;
															}
															goto IL_02bb;
															IL_02b3:
															result = "Windows 8";
															goto end_IL_015a;
															IL_02bb:
															if (byte_ != 2)
															{
																goto end_IL_015a;
															}
															goto IL_02c0;
															IL_02c0:
															result = "Windows Server 2012 R2";
															goto end_IL_015a;
															IL_0289:
															if (byte_ == 1)
															{
																goto IL_028e;
															}
															goto IL_0299;
															IL_028e:
															result = "Windows 7";
															goto end_IL_015a;
															IL_0299:
															if (byte_ != 3)
															{
																goto end_IL_015a;
															}
															goto IL_02a3;
															IL_02a3:
															result = "Windows Server 2008 R2";
															goto end_IL_015a;
															IL_0266:
															if (byte_ != 1)
															{
																goto IL_026b;
															}
															goto IL_027e;
															IL_026b:
															if (byte_ != 3)
															{
																goto end_IL_015a;
															}
															goto IL_0273;
															IL_0273:
															result = "Windows Server 2008";
															goto end_IL_015a;
															IL_027e:
															result = "Windows Vista";
															goto end_IL_015a;
															IL_0205:
															switch (minor)
															{
															case 0:
																break;
															case 1:
																goto IL_0228;
															case 2:
																goto IL_0233;
															default:
																goto end_IL_015a;
															}
															goto IL_021d;
															IL_0233:
															if (byte_ == 1)
															{
																goto IL_0238;
															}
															goto IL_0243;
															IL_0238:
															result = "Windows XP";
															goto end_IL_015a;
															IL_0243:
															result = "Windows Server 2003";
															goto end_IL_015a;
															IL_0228:
															result = "Windows XP";
															goto end_IL_015a;
															IL_021d:
															result = "Windows 2000";
															goto end_IL_015a;
															IL_01e0:
															if (byte_ == 1)
															{
																goto IL_01e5;
															}
															goto IL_01f0;
															IL_01e5:
															result = "Windows NT 4.0";
															goto end_IL_015a;
															IL_01f0:
															if (byte_ != 3)
															{
																goto end_IL_015a;
															}
															goto IL_01fa;
															continue;
															end_IL_0133:
															break;
														}
														continue;
														end_IL_0150:
														break;
													}
													continue;
													end_IL_015a:
													break;
												}
												break;
											}
											goto IL_02c8;
											IL_0330:
											result = "Windows 95 OSR2";
											break;
											IL_02c8:
											if (major != 4)
											{
												break;
											}
											goto IL_02ce;
											IL_02ce:
											text = struct332_.string_0;
											goto IL_02d6;
											IL_02d6:
											if (minor != 0)
											{
												goto IL_02da;
											}
											goto IL_030c;
											IL_02da:
											if (minor != 10)
											{
												goto IL_02e0;
											}
											goto IL_02ee;
											IL_02e0:
											if (minor != 90)
											{
												break;
											}
											goto IL_02e6;
											IL_02e6:
											result = "Windows Me";
											break;
											IL_02ee:
											if (text == "A")
											{
												goto IL_02fc;
											}
											goto IL_0304;
											IL_02fc:
											result = "Windows 98 Second Edition";
											break;
											IL_0304:
											result = "Windows 98";
											break;
											IL_030c:
											if (!(text == "B"))
											{
												goto IL_031a;
											}
											goto IL_0330;
											IL_031a:
											if (!(text == "C"))
											{
												goto IL_0328;
											}
											goto IL_0330;
											IL_0328:
											result = "Windows 95";
											break;
										}
										break;
									}
									break;
								}
								break;
							}
						}
						string_1 = result;
						goto IL_033c;
						IL_033c:
						return result;
						continue;
						end_IL_0195:
						break;
					}
					continue;
					end_IL_01a3:
					break;
				}
			}
			return string_1;
		}
	}

	public static string ServicePack
	{
		get
		{
			string empty = string.Empty;
			Struct332 struct332_ = default(Struct332);
			struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
			if (GetVersionEx(ref struct332_))
			{
				empty = struct332_.string_0;
			}
			return empty;
		}
	}

	public static int BuildVersion => Environment.OSVersion.Version.Build;

	public static string VersionString => Environment.OSVersion.Version.ToString();

	public static Version Version => Environment.OSVersion.Version;

	public static int MajorVersion => Environment.OSVersion.Version.Major;

	public static int MinorVersion => Environment.OSVersion.Version.Minor;

	public static int RevisionVersion => Environment.OSVersion.Version.Revision;

	[DllImport("Kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool GetProductInfo(int int_54, int int_55, int int_56, int int_57, out int int_58);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool GetVersionEx(ref Struct332 struct332_0);
}
