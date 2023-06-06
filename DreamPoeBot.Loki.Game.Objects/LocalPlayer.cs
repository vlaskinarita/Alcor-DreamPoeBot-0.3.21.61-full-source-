using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class LocalPlayer : Player
{
	[Serializable]
	private sealed class Class291
	{
		public static readonly Class291 Class9 = new Class291();

		internal bool method_0(DatPassiveSkillWrapper datPassiveSkillWrapper_0)
		{
			return datPassiveSkillWrapper_0.Name == "Whispers of Doom";
		}

		internal bool method_1(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[0];
		}

		internal bool method_2(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[1];
		}

		internal bool method_3(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[2];
		}

		internal bool method_4(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[3];
		}

		internal bool method_5(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[4];
		}

		internal bool method_6(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[5];
		}

		internal bool method_7(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[6];
		}

		internal bool method_8(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[7];
		}

		internal bool method_9(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[8];
		}

		internal bool method_10(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[9];
		}

		internal bool method_11(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[10];
		}

		internal bool method_12(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[11];
		}

		internal bool method_13(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[12];
		}
	}

	private sealed class Class293
	{
		public string string_0;

		internal bool method_0(Skill skill_0)
		{
			if (skill_0 != null)
			{
				return skill_0.Name == string_0;
			}
			return false;
		}
	}

	private static readonly ILog ilog_2 = Logger.GetLoggerInstanceForType();

	private PerFrameCachedValue<int> perFrameCachedValue_9;

	public int BestiaryNetVariation
	{
		get
		{
			if (perFrameCachedValue_9 == null)
			{
				perFrameCachedValue_9 = new PerFrameCachedValue<int>(method_15);
			}
			return perFrameCachedValue_9;
		}
	}

	public Portal TownPortal => LokiPoe.ObjectManager.TownPortal(Name);

	public PartyStatus PartyStatus => LokiPoe.InstanceInfo.PartyStatus;

	public string League => LokiPoe.InstanceInfo.League;

	public List<ushort> SkillBarIds => LokiPoe.InstanceInfo.SkillBarIds;

	public List<Skill> SkillBarSkills => LokiPoe.InstanceInfo.SkillBarSkills;

	public bool IsInHideout => LokiPoe.CurrentWorldArea.IsHideoutArea;

	public bool IsInTown => LokiPoe.CurrentWorldArea.IsTown;

	public bool IsInOverworld => LokiPoe.CurrentWorldArea.IsOverworldArea;

	public bool IsInCorruptedArea => LokiPoe.CurrentWorldArea.IsCorruptedArea;

	public bool IsInMapRoom => LokiPoe.CurrentWorldArea.IsMapRoom;

	private static IEnumerable<Inventory> IEnumerable_0 => new Inventory[12]
	{
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffLeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffRightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Head),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Chest),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Gloves),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Boots),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Belt),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Neck)
	};

	public IEnumerable<Item> EquippedItems
	{
		get
		{
			new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				if (item2 != null)
				{
					Item item = item2.Items.FirstOrDefault();
					if (item != null)
					{
						yield return item;
					}
				}
			}
		}
	}

	public int NumberOfDeployedBrand
	{
		get
		{
			int num = 0;
			DreamPoeBot.Loki.Components.Actor component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Actor>();
			foreach (Skill item in component.AvailableSkills.Where((Skill x) => x.InternalId.Contains("_brand")))
			{
				num += item.SkillActiveToken;
			}
			return num;
		}
	}

	public int TotalCursesAllowed
	{
		get
		{
			int num = 1;
			foreach (Item equippedItem in EquippedItems)
			{
				if (equippedItem.Stats.TryGetValue(StatTypeGGG.NumberOfAdditionalCursesAllowed, out var value))
				{
					num += value;
				}
			}
			if (LokiPoe.ObjectManager.Me.Passives.Any(Class291.Class9.method_0))
			{
				num++;
			}
			return num;
		}
	}

	public IEnumerable<DatPassiveSkillWrapper> Passives
	{
		get
		{
			Dat.BuildPassinveLookupTable();
			foreach (ushort passiveSkillId in LokiPoe.InstanceInfo.PassiveSkillIds)
			{
				if (!Dat.dictionary_IdToPassiveSkillWrapper.TryGetValue(passiveSkillId, out var value))
				{
					ilog_2.ErrorFormat("[Passives] A passive with id {0} was not found.", (object)passiveSkillId);
				}
				else
				{
					yield return value;
				}
			}
		}
	}

	public List<DatPassiveSkillWrapper> AtlasPassiveSkills => LokiPoe.InstanceInfo.AtlasPassiveSkills;

	public int AtlasPassivePointsAvailable => LokiPoe.InstanceInfo.AtlasPassivePointsAvailable;

	public List<DatPassiveSkillWrapper> PassiveSkills => LokiPoe.InstanceInfo.PassiveSkills;

	public int PassiveSkillPointsAvailable => LokiPoe.InstanceInfo.PassiveSkillPointsAvailable;

	public int AscendencySkillPointsAvailable => LokiPoe.InstanceInfo.AscendencySkillPointsAvailable;

	public List<Item> EquippedSkillGems
	{
		get
		{
			List<Item> list = new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				foreach (Item item3 in item2.Items)
				{
					if (item3 == null || item3.Components.SocketsComponent == null)
					{
						continue;
					}
					for (int i = 0; i < item3.SocketedGems.Length; i++)
					{
						Item item = item3.SocketedGems[i];
						if (!(item == null))
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}
	}

	internal LocalPlayer(EntityWrapper entry)
		: base(entry)
	{
	}

	public Keys GetKeyForSkill(Skill skill)
	{
		ushort id = skill.Id;
		uint num2 = default(uint);
		while (true)
		{
			List<ushort> skillBarIds = SkillBarIds;
			while (true)
			{
				int num = 0;
				while (true)
				{
					if (num < skillBarIds.Count)
					{
						while (true)
						{
							if (skillBarIds[num] == id)
							{
								while (true)
								{
									switch (num)
									{
									case 0:
										goto IL_00fd;
									case 1:
										goto IL_0103;
									case 2:
										goto IL_0109;
									case 3:
										goto IL_010f;
									case 4:
										goto IL_0115;
									case 5:
										goto IL_011b;
									case 6:
										goto IL_0121;
									case 7:
										goto IL_0127;
									case 8:
										goto IL_012d;
									case 9:
										goto IL_0133;
									case 10:
										goto IL_0139;
									case 11:
										goto IL_013f;
									case 12:
										goto IL_0145;
									}
									int num3 = (int)(num2 * 1864087163) ^ -416885899;
									while (true)
									{
										switch ((num2 = (uint)num3 ^ 0x4EAC172Cu) % 23u)
										{
										case 21u:
											num3 = (int)((num2 * 1352402119) ^ 0x12FB20DA);
											continue;
										case 5u:
											break;
										case 13u:
											goto end_IL_0096;
										case 15u:
											goto IL_00df;
										case 2u:
										case 16u:
											goto end_IL_00d5;
										case 22u:
											goto end_IL_00e3;
										case 7u:
										case 20u:
											goto end_IL_00ee;
										default:
											goto IL_00fb;
										case 3u:
											goto IL_00fd;
										case 11u:
											goto IL_0103;
										case 1u:
											goto IL_0109;
										case 19u:
											goto IL_010f;
										case 9u:
											goto IL_0115;
										case 14u:
											goto IL_011b;
										case 0u:
											goto IL_0121;
										case 8u:
											goto IL_0127;
										case 12u:
											goto IL_012d;
										case 10u:
											goto IL_0133;
										case 18u:
											goto IL_0139;
										case 17u:
											goto IL_013f;
										case 4u:
											goto IL_0145;
										}
										break;
									}
									continue;
									IL_0103:
									return LokiPoe.Input.Binding.use_bound_skill2;
									IL_00fd:
									return LokiPoe.Input.Binding.use_bound_skill1;
									IL_0145:
									return LokiPoe.Input.Binding.use_bound_skill13;
									IL_013f:
									return LokiPoe.Input.Binding.use_bound_skill12;
									IL_0139:
									return LokiPoe.Input.Binding.use_bound_skill11;
									IL_0133:
									return LokiPoe.Input.Binding.use_bound_skill10;
									IL_012d:
									return LokiPoe.Input.Binding.use_bound_skill9;
									IL_0127:
									return LokiPoe.Input.Binding.use_bound_skill8;
									IL_0121:
									return LokiPoe.Input.Binding.use_bound_skill7;
									IL_011b:
									return LokiPoe.Input.Binding.use_bound_skill6;
									IL_0115:
									return LokiPoe.Input.Binding.use_bound_skill5;
									IL_010f:
									return LokiPoe.Input.Binding.use_bound_skill4;
									IL_0109:
									return LokiPoe.Input.Binding.use_bound_skill3;
									continue;
									end_IL_0096:
									break;
								}
								continue;
							}
							goto IL_00df;
							IL_00df:
							num++;
							break;
							continue;
							end_IL_00d5:
							break;
						}
						continue;
					}
					goto IL_00fb;
					IL_00fb:
					return Keys.None;
					continue;
					end_IL_00e3:
					break;
				}
				continue;
				end_IL_00ee:
				break;
			}
		}
	}

	public LokiPoe.Input.KeysCombo GetKeyComboForSkill(Skill skill)
	{
		ushort id = skill.Id;
		List<ushort> skillBarIds = SkillBarIds;
		uint num2 = default(uint);
		while (true)
		{
			int num = 0;
			while (true)
			{
				if (num < skillBarIds.Count)
				{
					while (true)
					{
						if (skillBarIds[num] == id)
						{
							while (true)
							{
								switch (num)
								{
								case 0:
									goto IL_00fb;
								case 1:
									goto IL_0101;
								case 2:
									goto IL_0107;
								case 3:
									goto IL_010d;
								case 4:
									goto IL_0113;
								case 5:
									goto IL_0119;
								case 6:
									goto IL_011f;
								case 7:
									goto IL_0125;
								case 8:
									goto IL_012b;
								case 9:
									goto IL_0131;
								case 10:
									goto IL_0137;
								case 11:
									goto IL_013d;
								case 12:
									goto IL_0143;
								}
								int num3 = (int)(num2 * 996214018) ^ -1073472376;
								while (true)
								{
									switch ((num2 = (uint)num3 ^ 0xE2B6D205u) % 21u)
									{
									case 10u:
										num3 = (int)(num2 * 1130259206) ^ -449301670;
										continue;
									case 5u:
										break;
									case 20u:
										goto end_IL_0095;
									case 3u:
										goto IL_00e0;
									case 14u:
										goto end_IL_00d4;
									case 0u:
									case 6u:
										goto end_IL_00e4;
									default:
										goto IL_00f3;
									case 8u:
										goto IL_00fb;
									case 1u:
										goto IL_0101;
									case 11u:
										goto IL_0107;
									case 4u:
										goto IL_010d;
									case 7u:
										goto IL_0113;
									case 9u:
										goto IL_0119;
									case 19u:
										goto IL_011f;
									case 15u:
										goto IL_0125;
									case 16u:
										goto IL_012b;
									case 12u:
										goto IL_0131;
									case 18u:
										goto IL_0137;
									case 13u:
										goto IL_013d;
									case 2u:
										goto IL_0143;
									}
									break;
								}
								continue;
								IL_0101:
								return LokiPoe.Input.Binding.use_bound_skill2_combo;
								IL_00fb:
								return LokiPoe.Input.Binding.use_bound_skill1_combo;
								IL_0143:
								return LokiPoe.Input.Binding.use_bound_skill13_combo;
								IL_013d:
								return LokiPoe.Input.Binding.use_bound_skill12_combo;
								IL_0137:
								return LokiPoe.Input.Binding.use_bound_skill11_combo;
								IL_0131:
								return LokiPoe.Input.Binding.use_bound_skill10_combo;
								IL_012b:
								return LokiPoe.Input.Binding.use_bound_skill9_combo;
								IL_0125:
								return LokiPoe.Input.Binding.use_bound_skill8_combo;
								IL_011f:
								return LokiPoe.Input.Binding.use_bound_skill7_combo;
								IL_0119:
								return LokiPoe.Input.Binding.use_bound_skill6_combo;
								IL_0113:
								return LokiPoe.Input.Binding.use_bound_skill5_combo;
								IL_010d:
								return LokiPoe.Input.Binding.use_bound_skill4_combo;
								IL_0107:
								return LokiPoe.Input.Binding.use_bound_skill3_combo;
								continue;
								end_IL_0095:
								break;
							}
							continue;
						}
						goto IL_00e0;
						IL_00e0:
						num++;
						break;
						continue;
						end_IL_00d4:
						break;
					}
					continue;
				}
				goto IL_00f3;
				IL_00f3:
				return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				continue;
				end_IL_00e4:
				break;
			}
		}
	}

	public IEnumerable<Keys> GetKeysForSkill(Skill skill)
	{
		uint num2 = default(uint);
		bool flag = default(bool);
		ushort id = default(ushort);
		List<ushort> skillBarIds = default(List<ushort>);
		int i = default(int);
		int num4 = default(int);
		while (true)
		{
			LocalPlayer localPlayer = this;
			while (true)
			{
				IL_02a5:
				int num;
				int num3;
				switch (num)
				{
				case 0:
					goto IL_01c8;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
					goto IL_0280;
				default:
					num3 = (int)((num2 * 1104848613) ^ 0x25E95A96);
					goto IL_002a;
				case 14:
					yield break;
					IL_01c8:
					flag = false;
					goto IL_01cf;
					IL_01cf:
					id = skill.Id;
					skillBarIds = localPlayer.SkillBarIds;
					i = 0;
					goto IL_01f3;
					IL_01f3:
					if (i < skillBarIds.Count)
					{
						goto IL_01a3;
					}
					goto IL_02f2;
					IL_01a3:
					if (skillBarIds[i] == id)
					{
						goto IL_019a;
					}
					goto IL_0280;
					IL_019a:
					flag = true;
					goto IL_0154;
					IL_0154:
					switch (i)
					{
					case 0:
						goto IL_0312;
					case 1:
						goto IL_0326;
					case 2:
						goto IL_033a;
					case 3:
						goto IL_034e;
					case 4:
						goto IL_0362;
					case 5:
						goto IL_0376;
					case 6:
						goto IL_038a;
					case 7:
						goto IL_039e;
					case 8:
						goto IL_03b2;
					case 9:
						goto IL_03c7;
					case 10:
						goto IL_03dc;
					case 11:
						goto IL_03f1;
					case 12:
						goto IL_0406;
					}
					num3 = ((int)num2 * -735148342) ^ 0x41E1E10A;
					goto IL_002a;
					IL_020b:
					i = num4 + 1;
					goto IL_01f3;
					IL_002a:
					while (true)
					{
						switch ((num2 = (uint)num3 ^ 0x22C97141u) % 69u)
						{
						case 42u:
							num3 = (int)((num2 * 790104494) ^ 0x55BDC6C2);
							continue;
						default:
							yield break;
						case 19u:
							break;
						case 26u:
							goto IL_019a;
						case 17u:
							goto IL_01a3;
						case 29u:
						case 50u:
							goto IL_01c8;
						case 31u:
							goto IL_01cf;
						case 51u:
						case 56u:
							goto IL_01f3;
						case 65u:
							goto IL_020b;
						case 0u:
						case 6u:
						case 9u:
						case 10u:
						case 16u:
						case 18u:
						case 22u:
						case 23u:
						case 35u:
						case 39u:
						case 44u:
						case 45u:
						case 47u:
						case 48u:
						case 49u:
						case 53u:
						case 58u:
						case 61u:
						case 63u:
						case 64u:
						case 68u:
							goto IL_0280;
						case 13u:
							goto IL_02a5;
						case 33u:
						case 59u:
							goto end_IL_02a6;
						case 25u:
							goto IL_02f2;
						case 8u:
							goto IL_02fd;
						case 41u:
							yield break;
						case 60u:
							try
							{
								goto IL_0310;
								IL_0310:
								/*Error near IL_0311: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=14.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 1u:
							goto IL_0310;
						case 66u:
							goto IL_0312;
						case 4u:
							try
							{
								/*Error near IL_0325: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 40u:
							goto IL_0326;
						case 46u:
							/*Error near IL_0339: Unexpected return in MoveNext()*/;
						case 57u:
							goto IL_033a;
						case 15u:
							/*Error near IL_034d: Unexpected return in MoveNext()*/;
						case 28u:
							goto IL_034e;
						case 21u:
							/*Error near IL_0361: Unexpected return in MoveNext()*/;
						case 67u:
							goto IL_0362;
						case 37u:
							try
							{
								goto IL_0374;
								IL_0374:
								/*Error near IL_0375: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 38u:
							goto IL_0374;
						case 27u:
							goto IL_0376;
						case 52u:
							try
							{
								/*Error near IL_0389: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=6.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 7u:
							goto IL_038a;
						case 62u:
							/*Error near IL_039d: Unexpected return in MoveNext()*/;
						case 12u:
							goto IL_039e;
						case 2u:
							/*Error near IL_03b1: Unexpected return in MoveNext()*/;
						case 20u:
							goto IL_03b2;
						case 30u:
							try
							{
								/*Error near IL_03c6: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 14u:
							goto IL_03c7;
						case 5u:
							goto IL_03dc;
						case 3u:
							try
							{
								goto IL_03ef;
								IL_03ef:
								/*Error near IL_03f0: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=11.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 55u:
							goto IL_03ef;
						case 24u:
							goto IL_03f1;
						case 34u:
							try
							{
								goto IL_0404;
								IL_0404:
								/*Error near IL_0405: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=12.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 11u:
							goto IL_0404;
						case 43u:
							goto IL_0406;
						case 36u:
							try
							{
								/*Error near IL_041a: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=13.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 32u:
							yield break;
						}
						break;
					}
					goto IL_0154;
					IL_0406:
					yield return LokiPoe.Input.Binding.use_bound_skill13;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_03f1:
					yield return LokiPoe.Input.Binding.use_bound_skill12;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_03dc:
					yield return LokiPoe.Input.Binding.use_bound_skill11;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_03c7:
					yield return LokiPoe.Input.Binding.use_bound_skill10;
					break;
					IL_03b2:
					yield return LokiPoe.Input.Binding.use_bound_skill9;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_039e:
					yield return LokiPoe.Input.Binding.use_bound_skill8;
					break;
					IL_038a:
					yield return LokiPoe.Input.Binding.use_bound_skill7;
					break;
					IL_0376:
					yield return LokiPoe.Input.Binding.use_bound_skill6;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_0362:
					yield return LokiPoe.Input.Binding.use_bound_skill5;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_034e:
					yield return LokiPoe.Input.Binding.use_bound_skill4;
					break;
					IL_033a:
					yield return LokiPoe.Input.Binding.use_bound_skill3;
					break;
					IL_0326:
					yield return LokiPoe.Input.Binding.use_bound_skill2;
					break;
					IL_0312:
					yield return LokiPoe.Input.Binding.use_bound_skill1;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_02f2:
					if (flag)
					{
						yield break;
					}
					goto IL_02fd;
					IL_02fd:
					yield return Keys.None;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_0280:
					num4 = i;
					goto IL_020b;
					end_IL_02a6:
					break;
				}
				break;
			}
		}
	}

	public IEnumerable<LokiPoe.Input.KeysCombo> GetKeysComboForSkill(Skill skill)
	{
		uint num2 = default(uint);
		bool flag = default(bool);
		ushort id = default(ushort);
		List<ushort> skillBarIds = default(List<ushort>);
		int i = default(int);
		int num4 = default(int);
		while (true)
		{
			LocalPlayer localPlayer = this;
			int num;
			int num3;
			switch (num)
			{
			case 0:
				goto IL_01bb;
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
				goto IL_026f;
			default:
				num3 = ((int)num2 * -175997637) ^ 0x7322ACE3;
				goto IL_002a;
			case 14:
				yield break;
				IL_01bb:
				flag = false;
				goto IL_01c9;
				IL_01c9:
				id = skill.Id;
				goto IL_01da;
				IL_01da:
				skillBarIds = localPlayer.SkillBarIds;
				goto IL_01e6;
				IL_01e6:
				i = 0;
				goto IL_01ed;
				IL_01ed:
				if (i < skillBarIds.Count)
				{
					goto IL_019d;
				}
				goto IL_02eb;
				IL_019d:
				if (skillBarIds[i] == id)
				{
					goto IL_0194;
				}
				goto IL_026f;
				IL_0194:
				flag = true;
				goto IL_018b;
				IL_018b:
				num4 = i;
				goto IL_014c;
				IL_014c:
				switch (num4)
				{
				case 0:
					goto IL_030f;
				case 1:
					goto IL_0323;
				case 2:
					goto IL_0337;
				case 3:
					goto IL_034b;
				case 4:
					goto IL_035f;
				case 5:
					goto IL_0373;
				case 6:
					goto IL_0387;
				case 7:
					goto IL_039b;
				case 8:
					goto IL_03af;
				case 9:
					goto IL_03c4;
				case 10:
					goto IL_03d9;
				case 11:
					goto IL_03ee;
				case 12:
					goto IL_0403;
				}
				num3 = (int)((num2 * 1208564206) ^ 0x4B971FDE);
				goto IL_002a;
				IL_026f:
				i++;
				goto IL_01ed;
				IL_002a:
				while (true)
				{
					switch ((num2 = (uint)num3 ^ 0x5FF37286u) % 67u)
					{
					case 13u:
						num3 = ((int)num2 * -1847652205) ^ 0x947222A;
						continue;
					default:
						yield break;
					case 19u:
						break;
					case 54u:
						goto IL_018b;
					case 28u:
						goto IL_0194;
					case 57u:
						goto IL_019d;
					case 52u:
						goto IL_01bb;
					case 5u:
						goto IL_01c9;
					case 27u:
						goto IL_01da;
					case 39u:
						goto IL_01e6;
					case 15u:
					case 16u:
						goto IL_01ed;
					case 0u:
					case 8u:
					case 9u:
					case 11u:
					case 14u:
					case 18u:
					case 21u:
					case 26u:
					case 30u:
					case 32u:
					case 33u:
					case 41u:
					case 42u:
					case 43u:
					case 44u:
					case 46u:
					case 49u:
					case 50u:
					case 60u:
					case 62u:
					case 63u:
					case 66u:
						goto IL_026f;
					case 20u:
					case 56u:
						goto end_IL_02a8;
					case 38u:
						goto IL_02eb;
					case 10u:
						goto IL_02f6;
					case 1u:
						/*Error near IL_030c: Unexpected return in MoveNext()*/;
					case 64u:
						yield break;
					case 65u:
						goto IL_030f;
					case 61u:
						try
						{
							/*Error near IL_0322: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 36u:
						goto IL_0323;
					case 12u:
						try
						{
							/*Error near IL_0336: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=2.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 2u:
						goto IL_0337;
					case 29u:
						goto IL_034b;
					case 59u:
						try
						{
							/*Error near IL_035e: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=4.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 47u:
						goto IL_035f;
					case 34u:
						try
						{
							goto IL_0371;
							IL_0371:
							/*Error near IL_0372: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 4u:
						goto IL_0371;
					case 17u:
						goto IL_0373;
					case 23u:
						try
						{
							goto IL_0385;
							IL_0385:
							/*Error near IL_0386: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=6.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 37u:
						goto IL_0385;
					case 45u:
						goto IL_0387;
					case 48u:
						try
						{
							goto IL_0399;
							IL_0399:
							/*Error near IL_039a: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=7.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 31u:
						goto IL_0399;
					case 53u:
						goto IL_039b;
					case 7u:
						/*Error near IL_03ae: Unexpected return in MoveNext()*/;
					case 40u:
						goto IL_03af;
					case 51u:
						try
						{
							/*Error near IL_03c3: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 22u:
						goto IL_03c4;
					case 24u:
						goto IL_03d9;
					case 3u:
						goto IL_03ee;
					case 25u:
						try
						{
							/*Error near IL_0402: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=12.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 6u:
						goto IL_0403;
					case 55u:
						/*Error near IL_0417: Unexpected return in MoveNext()*/;
					case 35u:
						yield break;
					}
					break;
				}
				goto IL_014c;
				IL_0403:
				yield return LokiPoe.Input.Binding.use_bound_skill13_combo;
				break;
				IL_03ee:
				yield return LokiPoe.Input.Binding.use_bound_skill12_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_03d9:
				yield return LokiPoe.Input.Binding.use_bound_skill11_combo;
				break;
				IL_03c4:
				yield return LokiPoe.Input.Binding.use_bound_skill10_combo;
				break;
				IL_03af:
				yield return LokiPoe.Input.Binding.use_bound_skill9_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_039b:
				yield return LokiPoe.Input.Binding.use_bound_skill8_combo;
				break;
				IL_0387:
				yield return LokiPoe.Input.Binding.use_bound_skill7_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_0373:
				yield return LokiPoe.Input.Binding.use_bound_skill6_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_035f:
				yield return LokiPoe.Input.Binding.use_bound_skill5_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_034b:
				yield return LokiPoe.Input.Binding.use_bound_skill4_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_0337:
				yield return LokiPoe.Input.Binding.use_bound_skill3_combo;
				break;
				IL_0323:
				yield return LokiPoe.Input.Binding.use_bound_skill2_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_030f:
				yield return LokiPoe.Input.Binding.use_bound_skill1_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_02eb:
				if (flag)
				{
					yield break;
				}
				goto IL_02f6;
				IL_02f6:
				yield return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				break;
				end_IL_02a8:
				break;
			}
		}
	}

	public Skill FromActionKey(ActionKeys key)
	{
		return key switch
		{
			ActionKeys.use_bound_skill1 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_1), 
			ActionKeys.use_bound_skill2 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_2), 
			ActionKeys.use_bound_skill3 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_3), 
			ActionKeys.use_bound_skill4 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_4), 
			ActionKeys.use_bound_skill5 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_5), 
			ActionKeys.use_bound_skill6 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_6), 
			ActionKeys.use_bound_skill7 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_7), 
			ActionKeys.use_bound_skill8 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_8), 
			ActionKeys.use_bound_skill9 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_9), 
			ActionKeys.use_bound_skill10 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_10), 
			ActionKeys.use_bound_skill11 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_11), 
			ActionKeys.use_bound_skill12 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_12), 
			ActionKeys.use_bound_skill13 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_13), 
			_ => null, 
		};
	}

	public Skill FromKey(Keys key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1 == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2 != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill3 != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill4 != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill5 != key)
					{
						if (LokiPoe.Input.Binding.use_bound_skill6 == key)
						{
							return FromActionKey(ActionKeys.use_bound_skill6);
						}
						if (LokiPoe.Input.Binding.use_bound_skill7 != key)
						{
							if (LokiPoe.Input.Binding.use_bound_skill8 != key)
							{
								if (LokiPoe.Input.Binding.use_bound_skill9 != key)
								{
									if (LokiPoe.Input.Binding.use_bound_skill10 != key)
									{
										if (LokiPoe.Input.Binding.use_bound_skill11 == key)
										{
											return FromActionKey(ActionKeys.use_bound_skill11);
										}
										if (LokiPoe.Input.Binding.use_bound_skill12 == key)
										{
											return FromActionKey(ActionKeys.use_bound_skill12);
										}
										if (LokiPoe.Input.Binding.use_bound_skill13 == key)
										{
											return FromActionKey(ActionKeys.use_bound_skill13);
										}
										return null;
									}
									return FromActionKey(ActionKeys.use_bound_skill10);
								}
								return FromActionKey(ActionKeys.use_bound_skill9);
							}
							return FromActionKey(ActionKeys.use_bound_skill8);
						}
						return FromActionKey(ActionKeys.use_bound_skill7);
					}
					return FromActionKey(ActionKeys.use_bound_skill5);
				}
				return FromActionKey(ActionKeys.use_bound_skill4);
			}
			return FromActionKey(ActionKeys.use_bound_skill3);
		}
		return FromActionKey(ActionKeys.use_bound_skill2);
	}

	public Skill FromKeyCombo(LokiPoe.Input.KeysCombo key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2_combo != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill3_combo != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill4_combo != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill5_combo != key)
					{
						if (LokiPoe.Input.Binding.use_bound_skill6_combo != key)
						{
							if (LokiPoe.Input.Binding.use_bound_skill7_combo != key)
							{
								if (LokiPoe.Input.Binding.use_bound_skill8_combo != key)
								{
									if (LokiPoe.Input.Binding.use_bound_skill9_combo == key)
									{
										return FromActionKey(ActionKeys.use_bound_skill9);
									}
									if (LokiPoe.Input.Binding.use_bound_skill10_combo != key)
									{
										if (LokiPoe.Input.Binding.use_bound_skill11_combo == key)
										{
											return FromActionKey(ActionKeys.use_bound_skill11);
										}
										if (LokiPoe.Input.Binding.use_bound_skill12_combo != key)
										{
											if (LokiPoe.Input.Binding.use_bound_skill13_combo == key)
											{
												return FromActionKey(ActionKeys.use_bound_skill13);
											}
											return null;
										}
										return FromActionKey(ActionKeys.use_bound_skill12);
									}
									return FromActionKey(ActionKeys.use_bound_skill10);
								}
								return FromActionKey(ActionKeys.use_bound_skill8);
							}
							return FromActionKey(ActionKeys.use_bound_skill7);
						}
						return FromActionKey(ActionKeys.use_bound_skill6);
					}
					return FromActionKey(ActionKeys.use_bound_skill5);
				}
				return FromActionKey(ActionKeys.use_bound_skill4);
			}
			return FromActionKey(ActionKeys.use_bound_skill3);
		}
		return FromActionKey(ActionKeys.use_bound_skill2);
	}

	public bool HasSkillOnBarByName(string name)
	{
		Class293 @class = new Class293();
		@class.string_0 = name;
		return LokiPoe.InstanceInfo.SkillBarSkills.Any(@class.method_0);
	}

	public bool HasAtlasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasAtlasPassive(value);
	}

	public bool HasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasPassive(value);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[LocalPlayer]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tClass: {base.Class}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\tExperience: {base.Experience}");
		stringBuilder.AppendLine($"\tPantheonMajor: {base.PantheonMajor}");
		stringBuilder.AppendLine($"\tPantheonMinor: {base.PantheonMinor}");
		DatHideoutWrapper hideout = base.Hideout;
		if (hideout != null)
		{
			stringBuilder.AppendLine($"\tHideout: {hideout.Id}");
			stringBuilder.AppendLine($"\tHideoutLevel: {base.HideoutLevel}");
		}
		Portal townPortal = TownPortal;
		if (townPortal != null)
		{
			stringBuilder.AppendLine($"\tTownPortal: {townPortal.Name}");
		}
		stringBuilder.AppendLine($"\tPartyStatus: {PartyStatus}");
		stringBuilder.AppendLine($"\tLeague: {League}");
		stringBuilder.AppendLine($"\tTotalCursesAllowed: {TotalCursesAllowed}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftHandWeaponVisual", base.LeftHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightHandWeaponVisual", base.RightHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "ChestVisual", base.ChestVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "HelmVisual", base.HelmVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "GlovesVisual", base.GlovesVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BootsVisual", base.BootsVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "UnknownVisual", base.UnknownVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftRingVisual", base.LeftRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightRingVisual", base.RightRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BeltVisual", base.BeltVisual));
		stringBuilder.AppendLine($"AscendencyTrialArea");
		string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
		foreach (string text in labyrinthTrialAreaIds)
		{
			stringBuilder.AppendLine($"\t\t{text}: {IsAscendencyTrialCompleted(text)}");
		}
		return stringBuilder.ToString();
	}

	private int method_15()
	{
		return GetStat(StatTypeGGG.BestiaryNetVariation);
	}
}
