﻿using DS2S_META.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DS2S_META.Randomizer
{
    public class LinkNGDrop
    {
        public int origID;
        public int ngplusID;

        public LinkNGDrop(int origID, int ngplusID)
        {
            this.origID = origID;
            this.ngplusID = ngplusID;
        }
    }


    internal abstract class ItemSetBase
    {
        // All others are simply the NGplus paramID rounded to nearest 10
        internal List<LinkNGDrop> LinkedNGs = new() { new LinkNGDrop(675000, 675010) };
        internal List<LinkedDrop> LinkedDrops = new()
        {
            StraightCopy(318000, 60008000), // Pursuer Fight/Platform
        }; // LinkedLots..

        internal static LinkedDrop StraightCopy(int id1, int id2)
        {
            return new LinkedDrop(id1, id2);
        }

        // Other Logic related things:
        internal static List<PICKUPTYPE> BanKeyTypes = new()
        {
            PICKUPTYPE.NPC,
            PICKUPTYPE.VOLATILE,
            PICKUPTYPE.EXOTIC,
            PICKUPTYPE.COVENANTEASY,
            PICKUPTYPE.COVENANTHARD,
            PICKUPTYPE.UNRESOLVED,
            PICKUPTYPE.REMOVED,
            PICKUPTYPE.NGPLUS,
            PICKUPTYPE.CRAMMED,
            PICKUPTYPE.WOODCHEST,
            PICKUPTYPE.SHOP,        // For now
            PICKUPTYPE.ENEMYDROP,   // For now
            PICKUPTYPE.GUARANTEEDENEMYDROP,   // For now
            PICKUPTYPE.CROWS,
        };

        internal static List<PICKUPTYPE> FullySafe = new()
        {
           PICKUPTYPE.NONVOLATILE,
           PICKUPTYPE.BOSS,
           PICKUPTYPE.METALCHEST,
         };
        internal static List<PICKUPTYPE> HalfSafe = new()
        {
           PICKUPTYPE.NONVOLATILE,
           PICKUPTYPE.BOSS,
           PICKUPTYPE.GUARANTEEDENEMYDROP,
           PICKUPTYPE.WOODCHEST,
           PICKUPTYPE.METALCHEST,
         };

        internal static Dictionary<eItemType, List<PICKUPTYPE>> ItemAllowTypes = new()
        {
            { eItemType.RING, HalfSafe },
            { eItemType.SPELLS, HalfSafe },
        };

        internal static Dictionary<int, List<PICKUPTYPE>> ManuallyRequiredItemsTypeRules = new()
        {
            // Add here / refactor as required.
            { 60155000, FullySafe },    // Estus Flask
            { 0x039B89C8, FullySafe },  // Estus Flask Shard
            { 0x039B8DB0, FullySafe },  // Sublime Bone Dust
            { 05400000, FullySafe },    // Pyromancy Flame
            { 05410000, FullySafe },    // Dark Pyromancy Flame 
            { 60355000, FullySafe },    // Aged Feather
            { 40420000, FullySafe },    // Silvercat Ring
        };


        internal static List<PICKUPTYPE> BanGeneralTypes = new List<PICKUPTYPE>()
        {
            PICKUPTYPE.EXOTIC,
            PICKUPTYPE.COVENANTHARD, // To split into cheap/annoying
            PICKUPTYPE.UNRESOLVED,
            PICKUPTYPE.REMOVED,
            PICKUPTYPE.CRAMMED,
            PICKUPTYPE.CROWS, // handled separately
        };
        internal List<PICKUPTYPE> BanFromLoot = new()
        {
            // List of places where loot cannot come from:
            PICKUPTYPE.CRAMMED,
            PICKUPTYPE.UNRESOLVED,
            PICKUPTYPE.REMOVED,
            PICKUPTYPE.LINKEDSLAVE,
        };
        internal List<PICKUPTYPE> BanFromBeingRandomized = new()
        {
            // List of places where loot cannot come from:
            PICKUPTYPE.EXOTIC,
            PICKUPTYPE.CRAMMED,
            PICKUPTYPE.UNRESOLVED,
            PICKUPTYPE.REMOVED,
            PICKUPTYPE.LINKEDSLAVE,
            PICKUPTYPE.COVENANTHARD,
        };

        internal List<int> CrowDuplicates = new()
        {
            // Prism: keep C loot:
            50000300, // B loot from prism
            50000301, // A loot from prism
            50000302, // S loot from prism

            // Small silky: keep B loot:
            50000001, // A loot from small silky
            50000002, // S loot from small silky
            50000003, // C loot from small silky

            // Silky: keep A loot
            50000100, // B loot from silky
            50000102, // S loot from silky
            50000103, // C loot from silky

            // Petrified: keep S loot
            50000200, // B loot from petrified
            50000201, // A loot from petrified
            50000203, // C loot from petrified
        };
        
        internal static List<DropInfo> FillerItems = new()
        {
            new DropInfo(0x0393AE10, 3), // Lifegem
            new DropInfo(0x0393D520), // Radiant Lifegem
            new DropInfo(0x0393FC30), // Old Radiant Lifegem
            new DropInfo(0x039413A0), // Dried Root
            new DropInfo(0x03942340), // Amber Herb
            new DropInfo(0x03944A50), // Twilight Herb
            new DropInfo(0x03947160), // Wilted Dusk Herb
            new DropInfo(0x03949870), // Poison Moss
            new DropInfo(0x0394E690), // Monastery Charm
            new DropInfo(0x03950DA0), // Dragon Charm
            new DropInfo(0x03952128), // Divine Blessing
            new DropInfo(0x039534B0), // Rouge Water
            new DropInfo(0x03955BC0), // Crimson Water
            new DropInfo(0x0395D4D8), // Human Effigy
            new DropInfo(0x0395F800), // Small Blue Burr
            new DropInfo(0x03961F10), // Small Yellow Burr
            new DropInfo(0x03964620), // Small Orange Burr
            new DropInfo(0x03966D30), // Dark Troches
            new DropInfo(0x03969440), // Common Fruit
            new DropInfo(0x0396BB50), // Red Leech Troches
            new DropInfo(0x03970970), // Triclops Snake Troches
            new DropInfo(0x03971CF8), // Old Growth Balm
            new DropInfo(0x039720E0), // Vine Balm
            new DropInfo(0x039724C8), // Blackweed Balm
            new DropInfo(0x039728B0), // Goldenfruit Balm
            new DropInfo(0x03973080), // Aromatic Ooze
            new DropInfo(0x03975790), // Gold Pine Resin
            new DropInfo(0x03977EA0), // Charcoal Pine Resin
            new DropInfo(0x0397A5B0), // Dark Pine Resin
            new DropInfo(0x0397CCC0), // Rotten Pine Resin
            new DropInfo(0x0397F3D0), // Bleeding Serum
            new DropInfo(0x039841F0), // Green Blossom
            new DropInfo(0x03986900), // Rusted Coin
            new DropInfo(0x0398DE30), // Homeward Bone
            new DropInfo(0x03992C50), // Silver Talisman
            new DropInfo(0x0399C890), // Repair Powder
            new DropInfo(0x039A16B0), // Flame Butterfly
            new DropInfo(0x039A64D0), // Prism Stone
            new DropInfo(0x039B4F30), // Rubbish
            new DropInfo(0x039B5318), // Petrified Something
            new DropInfo(0x039B9198), // Bonfire Ascetic
            new DropInfo(0x039B9D50), // Alluring Skull
            new DropInfo(0x039BA138), // Lloyd's Talisman
            new DropInfo(0x039BC460, 5), // Throwing Knife
            new DropInfo(0x039BEB70, 3), // Witching Urn
            new DropInfo(0x039C1280, 3), // Lightning Urn
            new DropInfo(0x039C3990, 3), // Firebomb
            new DropInfo(0x039C4D18, 3), // Black Firebomb
            new DropInfo(0x039C60A0, 3), // Hexing Urn
            new DropInfo(0x039C87B0, 5), // Poison Throwing Knife
            new DropInfo(0x039C9B38, 3), // Dung Pie
            new DropInfo(0x039CAEC0, 5), // Lacerating Knife
            new DropInfo(0x039CD5D0, 3), // Corrosive Urn
            new DropInfo(0x039CFCE0, 3), // Holy Water Urn
            new DropInfo(0x039D1068), // Fading Soul
            new DropInfo(0x039D23F0), // Soul of a Lost Undead
            new DropInfo(0x039D4B00), // Large Soul of a Lost Undead
            new DropInfo(0x039D7210), // Soul of a Nameless Soldier
            new DropInfo(0x039D9920), // Large Soul of a Nameless Soldier
            new DropInfo(0x039DC030), // Soul of a Proud Knight
            new DropInfo(0x039DE740), // Large Soul of a Proud Knight
            new DropInfo(0x039E0E50), // Soul of a Brave Warrior
            new DropInfo(0x039E3560), // Large Soul of a Brave Warrior
            new DropInfo(0x039E5C70), // Soul of a Hero
            
            new DropInfo(0x039F1FC0, 5), // Wood Arrow
            new DropInfo(0x039F46D0, 5), // Iron Arrow
            new DropInfo(0x039F6DE0, 5), // Magic Arrow
            new DropInfo(0x039F94F0, 5), // Lightning Arrow
            new DropInfo(0x039FBC00, 5), // Fire Arrow
            new DropInfo(0x039FE310, 5), // Dark Arrow
            new DropInfo(0x03A00A20, 5), // Poison Arrow
            new DropInfo(0x03A03130, 5), // Lacerating Arrow
            new DropInfo(0x03A07F50, 5), // Iron Greatarrow
            new DropInfo(0x03A0CD70, 5), // Lightning Greatarrow
            new DropInfo(0x03A0F480, 5), // Fire Greatarrow
            new DropInfo(0x03A142A0, 5), // Destructive Greatarrow
            new DropInfo(0x03A169B0, 5), // Wood Bolt
            new DropInfo(0x03A190C0, 5), // Heavy Bolt
            new DropInfo(0x03A1B7D0, 5), // Magic Bolt
            new DropInfo(0x03A1DEE0, 5), // Lightning Bolt
            new DropInfo(0x03A205F0, 5), // Fire Bolt
            new DropInfo(0x03A22D00, 5), // Dark Bolt
            
            new DropInfo(0x03A25410), // Titanite Shard
            new DropInfo(0x03A26798), // Large Titanite Shard
            new DropInfo(0x03A27B20), // Titanite Chunk
            new DropInfo(0x03A2C940), // Twinkling Titanite
            new DropInfo(0x03A33E70), // Petrified Dragon Bone
            new DropInfo(0x03A3B3A0), // Faintstone
            new DropInfo(0x03A3DAB0), // Boltstone
            new DropInfo(0x03A401C0), // Firedrake Stone
            new DropInfo(0x03A428D0), // Darknight Stone
            new DropInfo(0x03A44FE0), // Poison Stone
            new DropInfo(0x03A476F0), // Bleed Stone
            new DropInfo(0x03A4C510), // Raw Stone
            new DropInfo(0x03A4EC20), // Magic Stone
            new DropInfo(0x03A51330), // Old Mundane Stone
            new DropInfo(0x03A53A40), // Palestone
        };
        internal static Dictionary<int, int> SoulPriceList = new()
        {
            { 60625000, 50 },       // Fading soul
            { 60630000, 200 },      // Soul of a Lost Undead 
            { 60640000, 400 },      // Large Soul of a Lost Undead
            { 60650000, 800 },      // Soul of a Nameless Soldier
            { 60660000, 1000 },     // Large Soul of a Nameless Soldier
            { 60670000, 2000 },     // Soul of a Proud Knight
            { 60680000, 3000 },     // Large Soul of a Proud Knight
            { 60690000, 5000 },     // Soul of a Brave Warrior
            { 60700000, 8000 },     // Large Soul of a Brave Warrior
            { 60710000, 10000 },    // Soul of a Hero
            { 60720000, 20000 },    // Soul of a Great Hero
            //
            { 64010000, 6000 },     // Soul of the Last Giant
            { 64000000, 8000 },     // Soul of the Pursuer
            { 64020000, 6000 },     // Dragonrider Soul
            { 64030000, 10000 },    // Old Dragonslayer Soul
            { 64040000, 6000 },     // Flexile Sentry Soul
            { 64050000, 6000 },     // Ruin Sentinel Soul
            { 64060000, 25000 },    // Soul of the Lost Sinner
            { 64070000, 8000 },     // Executioner's Chariot Soul
            { 64080000, 6000 },     // Skeleton Lord's Soul
            { 64090000, 6000 },     // Covetous Demon Soul
            { 64100000, 10000 },    // Mytha's Soul
            { 64110000, 8000 },     // Smelter Demon Soul
            { 64120000, 25000 },    // Old Iron King Soul
            { 64130000, 6000 },     // Royal Rat Vanguard Soul
            { 64140000, 25000 },    // Soul of the Rotten
            { 64150000, 8000 },     // Najka Soul
            { 64160000, 6000 },     // Rat Authority Soul
            { 64170000, 25000 },    // Freja Soul
            { 64180000, 18000 },    // Mirror Knight Soul
            { 64190000, 12000 },    // Demon of Song Soul
            { 64200000, 15000 },    // Velstadt Soul
            { 64210000, 50000 },    // Soul of the King
            { 64220000, 14000 },    // Guardian Dragon Soul
            { 64230000, 75000 },    // Ancient Dragon Soul
            { 64240000, 25000 },    // Giant Lord Soul
            { 64250000, 30000 },    // Nashandra Soul
            { 64260000, 16000 },    // Throne Defender Soul
            { 64270000, 16000 },    // Throne Watcher Soul
            { 64280000, 22000 },    // Darklurker Soul
            { 64290000, 6000 },     // Gargoyles Soul
            { 64300000, 60000 },    // Old Witch Soul
            { 64310000, 60000 },    // Old King Soul
            { 64320000, 60000 },    // Old Dead One Soul
            { 64330000, 60000 },    // Old Paledrake Soul
            { 64500000, 16000 },    // Sinh Soul
            { 64510000, 16000 },    // Fume Knight Soul
            { 64520000, 16000 },    // Aava Soul
            { 64530000, 30000 },    // Elana Soul
            { 64540000, 30000 },    // Nadalia Soul
            { 64550000, 30000 },    // Alsanna Soul
            { 64560000, 16000 },    // Sir Alonne Soul
            { 64580000, 30000 },    // Ivory King Soul
            { 64590000, 16000 },    // Zallen Soul
            { 64610000, 16000 },    // Lud Soul
            // { 64600000, 16000 },    // Loyce Soul (nothing)
        };

        // Purely for printing:
        internal static List<KEYID> KeyOutputOrder = new()
        {
            // Actual Key Item IDs:
            KEYID.BLACKSMITH,
            KEYID.MANSION,
            KEYID.SOLDIER,
            KEYID.IRON,
            KEYID.DULLEMBER,
            KEYID.ANTIQUATED,
            KEYID.BASTILLEKEY,
            KEYID.ROTUNDA,
            KEYID.FORGOTTEN,
            KEYID.UNDEADLOCKAWAY,
            KEYID.FANG,
            KEYID.BRIGHTSTONE,
            KEYID.TSELDORADEN,
            KEYID.KINGSPASSAGE,
            KEYID.EMBEDDED,
            KEYID.KINGSRING,
            KEYID.ALDIASKEY,
            KEYID.ASHENMIST,
            KEYID.KINSHIP,
            //
            KEYID.PETRIFIEDEGG,
            KEYID.WHISPERS,
            KEYID.CRUSHEDEYEORB,
            KEYID.TOKENOFFIDELITY,
            KEYID.TOKENOFSPITE,
            //
            KEYID.DLC1,
            KEYID.DRAGONSTONE,
            KEYID.ETERNALSANCTUM,
            KEYID.DLC2KEY,
            KEYID.SCEPTER,
            KEYID.TOWER,
            KEYID.DLC3KEY,
            KEYID.GARRISONWARD,
            //
            KEYID.FRAGRANTBRANCH,
            KEYID.SOULOFAGIANT,
            KEYID.SMELTERWEDGE,
            KEYID.NADALIAFRAGMENT,
            KEYID.PHARROSLOCKSTONE,
        };
        internal string GetDesc(int paramid)
        {
            bool found = Dold.ContainsKey(paramid);
            if (!found)
                return "";

            return Dold[paramid].Description?? "";
        }

        // Overloads for quick construction, single or no key requirements:
        internal RandoInfo NpcInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.NPC, new KeySet(reqkey));
        }
        internal RandoInfo NpcSafeInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.NPC, PICKUPTYPE.NONVOLATILE), new KeySet(reqkey));
        }
        internal RandoInfo CovInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.COVENANTHARD, new KeySet(reqkey));
        }
        internal RandoInfo CovFineInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.COVENANTEASY, new KeySet(reqkey));
        }
        internal RandoInfo WChestInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.WOODCHEST, new KeySet(reqkey));
        }
        internal RandoInfo MChestInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.METALCHEST, new KeySet(reqkey));
        }
        internal RandoInfo NGPlusInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.NGPLUS, new KeySet(reqkey));
        }
        internal RandoInfo WChestNGPlusInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.WOODCHEST, PICKUPTYPE.NGPLUS), new KeySet(reqkey));
        }
        internal RandoInfo MChestNGPlusInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.METALCHEST, PICKUPTYPE.NGPLUS), new KeySet(reqkey));
        }
        internal RandoInfo SafeInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.NONVOLATILE, new KeySet(reqkey));
        }
        internal RandoInfo VolInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.VOLATILE, new KeySet(reqkey));
        }
        internal RandoInfo CrowsInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.CROWS, new KeySet(reqkey));
        }
        internal RandoInfo UnresolvedInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.UNRESOLVED, new KeySet(reqkey));
        }
        internal RandoInfo ExoticInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.EXOTIC, new KeySet(reqkey));
        }
        internal RandoInfo CrammedInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.CRAMMED, new KeySet(reqkey));
        }
        internal RandoInfo RemovedInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            return new RandoInfo(desc, PICKUPTYPE.REMOVED, new KeySet(reqkey));
        }
        internal RandoInfo BossInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            // This is essentially a flag on top of safeinfo
            return new RandoInfo(desc, PICKUPTYPE.BOSS, new KeySet(reqkey));
        }
        internal RandoInfo BossVolInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            // This is essentially a flag on top of safeinfo
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.BOSS, PICKUPTYPE.VOLATILE), new KeySet(reqkey));
        }
        internal RandoInfo BossNGPlusInfo(string desc, KEYID reqkey = KEYID.NONE)
        {
            // This is essentially a flag on top of safeinfo
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.BOSS, PICKUPTYPE.NGPLUS), new KeySet(reqkey));
        }
        internal RandoInfo LinkedSlave(string desc, KEYID reqkey = KEYID.NONE)
        {
            // This is essentially a flag on top of safeinfo
            return new RandoInfo(desc, PICKUPTYPE.LINKEDSLAVE, new KeySet(reqkey));
        }

        // Overloads for multiple key options:
        internal RandoInfo NpcInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.NPC, keysets);
        }
        internal RandoInfo NpcSafeInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.NPC, PICKUPTYPE.NONVOLATILE), keysets);
        }
        internal RandoInfo CovInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.COVENANTHARD, keysets);
        }
        internal RandoInfo CovFineInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.COVENANTEASY, keysets);
        }
        internal RandoInfo WChestInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.WOODCHEST, keysets);
        }
        internal RandoInfo MChestInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.METALCHEST, keysets);
        }
        internal RandoInfo NGPlusInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.NGPLUS, keysets);
        }
        internal RandoInfo WChestNGPlusInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.WOODCHEST, PICKUPTYPE.NGPLUS), keysets);
        }
        internal RandoInfo MChestNGPlusInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.METALCHEST, PICKUPTYPE.NGPLUS), keysets);
        }
        internal RandoInfo SafeInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.NONVOLATILE, keysets);
        }
        internal RandoInfo ExoticInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.EXOTIC, keysets);
        }
        internal RandoInfo CrammedInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.CRAMMED, keysets);
        }
        internal RandoInfo VolInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, PICKUPTYPE.VOLATILE, keysets);
        }
        internal RandoInfo BossInfo(string desc, params KeySet[] keysets)
        {
            // This is essentially a flag on top of safeinfo
            return new RandoInfo(desc, PICKUPTYPE.BOSS, keysets);
        }
        internal RandoInfo BossNGPlusInfo(string desc, params KeySet[] keysets)
        {
            return new RandoInfo(desc, TypeArray(PICKUPTYPE.BOSS, PICKUPTYPE.NGPLUS), keysets);
        }

        // Utility shorthand methods (for common purposes):
        internal PICKUPTYPE[] TypeArray(params PICKUPTYPE[] types)
        {
            return types;
        }
        internal KeySet KSO(params KEYID[] keys) // KeySetOption
        {
            return new KeySet(keys);
        }
        
        internal void AppendKvp(KeyValuePair<int, RandoInfo> kvp) 
        {
            Dold.Add(kvp.Key, kvp.Value);
        }
        
        // Softlock logic:
        internal static bool IsPlaced(KEYID kid, List<int> placedSoFar)
        {
            // Function to handle different checks depending on KeyTypes I guess:
            switch (kid)
            {
                case KEYID.NONE:
                    // no condition required:
                    return true;

                case KEYID.BELFRYLUNA:
                    // Branch && Pharros Lockstone x2
                    return condLuna();

                case KEYID.SINNERSRISE:
                    // Branch || Antiquated
                    return condSinner();

                case KEYID.DRANGLEIC:
                    // Branch && Rotunda && Sinner's Rise
                    return condDrangleic();

                case KEYID.AMANA:
                    // Drangleic && King's passage
                    return condAmana();

                case KEYID.ALDIASKEEP:
                    // Branch && King's Ring
                    return condAldias();

                case KEYID.MEMORYJEIGH:
                    // King's Ring && Ashen Mist
                    return condJeigh();

                case KEYID.GANKSQUAD:
                    // DLC1 && Eternal Sanctum
                    return condGankSquad();

                case KEYID.PUZZLINGSWORD:
                    // DLC1 (TODO Bow/Arrow as keys)
                    return condDLC1();

                case KEYID.ELANA:
                    // DLC1 && Dragon Stone
                    return condElana();

                case KEYID.FUME:
                    // DLC2 && Scorching Sceptor
                    return condFume();

                case KEYID.BLUESMELTER:
                    // DLC2 && Tower Key
                    return condBlueSmelter();

                case KEYID.ALONNE:
                    // DLC2 && Tower Key && Scorching Scepter && Ashen Mist
                    return condAlonne();

                case KEYID.DLC3:
                    // DLC3key && Drangleic
                    return condDLC3();

                case KEYID.FRIGIDOUTSKIRTS:
                    // DLC3 && Garrison Ward Key
                    return condFrigid();

                case KEYID.CREDITS:
                    // Drangleic & Memory of Jeigh
                    return condCredits();

                case KEYID.VENDRICK:
                    // Amana + SoaG x3
                    return condVendrick();

                case KEYID.BRANCH:
                    // Three branches available
                    return condBranch();

                case KEYID.TENBRANCHLOCK:
                    // Ten branches available
                    return condTenBranch();

                case KEYID.NADALIA:
                    // DLC2 && Scepter && Tower Key && 12x Smelter Wedge
                    return condNadalia();

                case KEYID.PHARROS:
                    // Eight Pharros lockstones available
                    return condPharros();

                case KEYID.BELFRYSOL:
                    // Rotunda Lockstone && Pharros Lockstone x2
                    return condSol();

                case KEYID.DARKLURKER:
                    // Drangleic && Forgotten key && Torch && Butterfly x3
                    return condDarklurker();

                case KEYID.DLC2:
                    // Rotunda Lockstone && DLC2 key
                    return condDLC2();

                case KEYID.MEMORYORRO:
                    // Soldier Key && Ashen Mist
                    return condOrro();

                default:
                    return condKey(kid); // Simple Key check
            }

            // Conditions wrappers:
            int countBranches() => placedSoFar.Where(i => i == (int)KEYID.FRAGRANTBRANCH).Count();
            int countPharros() => placedSoFar.Where(i => i == (int)KEYID.PHARROSLOCKSTONE).Count();
            bool condKey(KEYID keyid) => placedSoFar.Contains((int)keyid);
            bool condBranch() => countBranches() >= 3;
            bool condTenBranch() => countBranches() >= 10;
            bool condRotunda() => condKey(KEYID.ROTUNDA);
            bool condAshen() => condKey(KEYID.ASHENMIST);
            bool condKingsRing() => condKey(KEYID.KINGSRING);
            bool condDLC1() => condKey(KEYID.DLC1);
            bool condDLC2() => condRotunda() && condKey(KEYID.DLC2);
            bool condSinner() => condBranch() || condKey(KEYID.ANTIQUATED);
            bool condDrangleic() => condBranch() && condRotunda() && condSinner();
            bool condAmana() => condDrangleic() && condKey(KEYID.KINGSPASSAGE);
            bool condAldias() => condBranch() && condKingsRing();
            bool condJeigh() => condAshen() && condKingsRing();
            bool condGankSquad() => condDLC1() && condKey(KEYID.ETERNALSANCTUM);
            bool condElana() => condDLC1() && condKey(KEYID.DRAGONSTONE);
            bool condFume() => condDLC2() && condKey(KEYID.SCEPTER);
            bool condBlueSmelter() => condDLC2() && condKey(KEYID.TOWER);
            bool condAlonne() => condDLC2() && condKey(KEYID.TOWER) && condKey(KEYID.SCEPTER) && condAshen();
            bool condDLC3() => condKey(KEYID.DLC3KEY) && condDrangleic();
            bool condFrigid() => condDLC3() && condKey(KEYID.GARRISONWARD);
            bool condCredits() => condDrangleic() && condJeigh();
            bool condWedges() => placedSoFar.Where(i => i == (int)KEYID.SMELTERWEDGE).Count() == 12;
            bool condNadalia() => condFume() && condBlueSmelter() && condWedges();
            bool condVendrick() => condAmana() && (placedSoFar.Where(i => i == (int)KEYID.SOULOFAGIANT).Count() >= 3);
            bool condBigPharros() => countPharros() >= 2;
            bool condPharros() => countPharros() >= 8; // surely enough
            bool condLuna() => condBranch() && condBigPharros();
            bool condSol() => condRotunda() && condBigPharros();
            bool condButterflies() => placedSoFar.Where(i => i == (int)KEYID.FLAMEBUTTERFLY).Count() >= 3;
            bool condDarklurker() => condDrangleic() && condKey(KEYID.FORGOTTEN) && condButterflies() && condKey(KEYID.TORCH);
            bool condOrro() => condAshen() && condKey(KEYID.SOLDIER);
        }
        internal void TransformToUID(List<Randomization> rdzs)
        {
            foreach (var rdz in rdzs)
            {
                if (Dold.TryGetValue(rdz.UniqueParamID, out var randoinfo))
                {
                    rdz.RandoInfo = randoinfo; // store link
                    D.Add(rdz.GUID, randoinfo);
                }
                    
            }
        }

        // To implement:
        protected Dictionary<int, RandoInfo> Dold = new Dictionary<int, RandoInfo>();
        internal Dictionary<string, RandoInfo> D = new Dictionary<string, RandoInfo>();
        internal abstract void SetupItemSet();


    }
}
